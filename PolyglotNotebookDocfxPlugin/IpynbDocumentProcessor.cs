using System.Collections.Immutable;
using System.Composition;
using System.Text.Json;
using Docfx.Common;
using Docfx.Plugins;
using PolyglotNotebookDocfxPlugin.Models;

namespace PolyglotNotebookDocfxPlugin;

[Export(typeof(IDocumentProcessor))]
public sealed class IpynbDocumentProcessor : IDocumentProcessor
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = false,
    };

    public string Name => nameof(IpynbDocumentProcessor);

    [ImportMany(nameof(IpynbDocumentProcessor))]
    public IEnumerable<IDocumentBuildStep>? BuildSteps { get; set; }

    public ProcessingPriority GetProcessingPriority(FileAndType file)
    {
        if (file.Type == DocumentType.Article && file.File.EndsWith(".ipynb"))
        {
            return ProcessingPriority.Normal;
        }

        return ProcessingPriority.NotSupported;
    }

    public FileModel Load(FileAndType file, ImmutableDictionary<string, object> metadata)
    {
        using var stream = new FileStream(
            Path.Combine(file.BaseDir, file.File),
            FileMode.Open,
            FileAccess.Read
        );
        var ipynbFile =
            JsonSerializer.Deserialize<IpynbFile>(stream, Options)
            ?? throw new InvalidOperationException("Failed to deserialize polyglot notebook file.");

        var content = new FileModelDetails(StringComparer.Ordinal)
        {
            [nameof(IpynbFile)] = ipynbFile,
            ["type"] = "Conceptual",
            ["path"] = file.File,
        };
        var localPathFromRoot = PathUtility.MakeRelativePath(
            EnvironmentContext.BaseDirectory,
            EnvironmentContext.FileAbstractLayer.GetPhysicalPath(file.File)
        );

        return new FileModel(file, content) { LocalPathFromRoot = localPathFromRoot };
    }

    public SaveResult Save(FileModel model)
    {
        return new SaveResult
        {
            DocumentType = "Conceptual",
            FileWithoutExtension = Path.ChangeExtension(path: model.File, extension: null),
        };
    }

    public void UpdateHref(FileModel model, IDocumentBuildContext context) { }
}
