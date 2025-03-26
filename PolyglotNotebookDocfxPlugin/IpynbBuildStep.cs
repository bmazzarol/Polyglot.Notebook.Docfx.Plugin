using System.Collections.Immutable;
using System.Composition;
using System.Text;
using Docfx.Plugins;
using PolyglotNotebookDocfxPlugin.Extensions;
using PolyglotNotebookDocfxPlugin.Models;

namespace PolyglotNotebookDocfxPlugin;

[Export(nameof(IpynbDocumentProcessor), typeof(IDocumentBuildStep))]
public sealed class IpynbBuildStep : IDocumentBuildStep
{
    public string Name => nameof(IpynbBuildStep);
    public int BuildOrder => 0;

    public IEnumerable<FileModel> Prebuild(ImmutableList<FileModel> models, IHostService host)
    {
        return models;
    }

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

        model.Content = new FileModelDetails((FileModelDetails)model.Content)
        {
            ["conceptual"] = htmlContent,
        };
    }

    public static void WriteMarkdownContent(StringBuilder sb, IpynbFile notebookModel)
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

        sb.AppendLine($"```{language}");
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
        if (output.OutputType != "display_data")
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

    public void Postbuild(ImmutableList<FileModel> models, IHostService host) { }
}
