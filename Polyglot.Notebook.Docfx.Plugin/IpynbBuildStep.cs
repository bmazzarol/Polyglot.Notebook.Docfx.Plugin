using System.Collections.Immutable;
using System.Composition;
using System.Text;
using Docfx.Plugins;
using PolyglotNotebookDocfxPlugin.Extensions;
using PolyglotNotebookDocfxPlugin.Models;

namespace PolyglotNotebookDocfxPlugin;

/// <summary>
/// Build step to convert ipynb files to html.\
/// </summary>
[Export(nameof(IpynbDocumentProcessor), typeof(IDocumentBuildStep))]
public sealed class IpynbBuildStep : IDocumentBuildStep
{
    /// <inheritdoc />
    public string Name => nameof(IpynbBuildStep);

    /// <inheritdoc />
    public int BuildOrder => 0;

    /// <inheritdoc />
    public IEnumerable<FileModel> Prebuild(ImmutableList<FileModel> models, IHostService host)
    {
        return models;
    }

    /// <inheritdoc />
    public void Build(FileModel model, IHostService host)
    {
        var notebookModel = model.Get<IpynbFile>();

        if (notebookModel == null)
        {
            return;
        }

        var sb = new StringBuilder();
        WriteMarkdownContent(sb, notebookModel);

        // convert the md content to html
        var htmlContent = host.Markup(sb.ToString(), model.FileAndType);

        model.Content = new FileModelDetails(
            (FileModelDetails)model.Content,
            StringComparer.Ordinal
        )
        {
            ["conceptual"] = htmlContent.Html,
        };
    }

    internal static void WriteMarkdownContent(StringBuilder sb, IpynbFile notebookModel)
    {
        foreach (var cell in notebookModel.Cells)
        {
            WriteCell(sb, cell);
        }
    }

    private static void WriteCell(StringBuilder sb, Cell cell)
    {
        switch (cell.Type)
        {
            case "code":
            {
                WriteCode(sb, cell);

                break;
            }
            case "markdown":
            {
                WriteLines(sb, cell.Source);
                sb.AppendLine();

                break;
            }
        }
    }

    private static void WriteLines(StringBuilder sb, IReadOnlyList<string> lines)
    {
        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            sb.Append(line);

            if (i == lines.Count - 1)
            {
                sb.AppendLine();
            }
        }
    }

    private static void WriteCode(StringBuilder sb, Cell cell)
    {
        var language = cell.Metadata?.Language;
        if (language == null)
        {
            return;
        }

        sb.Append("```").AppendLine(language);
        WriteLines(sb, cell.Source);
        sb.AppendLine("```");
        sb.AppendLine();

        if (cell.Outputs is null)
        {
            return;
        }

        foreach (var output in cell.Outputs)
        {
            WriteCellOutput(sb, output);
            sb.AppendLine();
        }
    }

    private static void WriteCellOutput(StringBuilder sb, CellOutput output)
    {
        if (!string.Equals(output.OutputType, "display_data", StringComparison.Ordinal))
        {
            return;
        }

        foreach (var (contentType, lines) in output.Data)
        {
            switch (contentType)
            {
                case "text/plain":
                    sb.AppendLine("```");
                    WriteLines(sb, lines);
                    sb.AppendLine("```");
                    break;
                default:
                    WriteLines(sb, lines);
                    break;
            }
        }
    }

    /// <inheritdoc />
    public void Postbuild(ImmutableList<FileModel> models, IHostService host) { }
}
