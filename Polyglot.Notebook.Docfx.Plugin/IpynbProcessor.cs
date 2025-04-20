using System.Diagnostics.CodeAnalysis;
using System.Text;
using Docfx.Common.Git;
using Docfx.DataContracts.Common;
using Docfx.Plugins;
using Polyglot.Notebook.Docfx.Plugin.Models;
using static Docfx.DataContracts.Common.Constants;

namespace Polyglot.Notebook.Docfx.Plugin;

internal static class IpynbProcessor
{
    [ExcludeFromCodeCoverage(Justification = "Can only be used within a Docfx execution context.")]
    internal static FileModelDetails ReadAsConceptual(string file, IpynbFile model)
    {
        var filePath = EnvironmentContext.FileAbstractLayer.GetPhysicalPath(file);
        var repoInfo = GitUtility.TryGetFileDetail(filePath);

        var sb = new StringBuilder();
        WriteMarkdownContent(sb, model);

        return new FileModelDetails(StringComparer.Ordinal)
        {
            [PropertyName.Conceptual] = sb.ToString(),
            [PropertyName.Type] = nameof(PropertyName.Conceptual),
            [PropertyName.Source] = new SourceDetail { Remote = repoInfo },
            [PropertyName.Path] = file,
            [PropertyName.Documentation] = new SourceDetail { Remote = repoInfo },
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
}
