using System.Collections.Immutable;
using System.Composition;
using System.Text.Json;
using Docfx.Common;
using Docfx.DataContracts.Common;
using Docfx.Plugins;
using Polyglot.Notebook.Docfx.Plugin.Models;
using static Polyglot.Notebook.Docfx.Plugin.DefaultConceptualProcessorAccessor;

namespace Polyglot.Notebook.Docfx.Plugin;

/// <summary>
/// Document processor for ipynb files
/// </summary>
[Export(typeof(IDocumentProcessor))]
public sealed class IpynbDocumentProcessor : IDocumentProcessor
{
    private readonly string[] _systemKeys =
    [
        "conceptual",
        "type",
        "source",
        "path",
        "documentation",
        "title",
        "rawTitle",
        "wordCount",
    ];

    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = false,
    };

    /// <inheritdoc />
    public string Name => nameof(IpynbDocumentProcessor);

    /// <inheritdoc />
    [ImportMany(nameof(IpynbDocumentProcessor))]
    public IEnumerable<IDocumentBuildStep>? BuildSteps { get; set; }

    /// <inheritdoc />
    public ProcessingPriority GetProcessingPriority(FileAndType file)
    {
        if (
            file.Type == DocumentType.Article
            && file.File.EndsWith(".ipynb", StringComparison.Ordinal)
        )
        {
            return ProcessingPriority.Normal;
        }

        return ProcessingPriority.NotSupported;
    }

    /// <inheritdoc />
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

        var content = IpynbProcessor.ReadAsConceptual(file.File, ipynbFile);

        foreach (var (key, value) in metadata.OrderBy(item => item.Key, StringComparer.Ordinal))
        {
            content[key] = value;
        }
        content[Constants.PropertyName.SystemKeys] = _systemKeys;

        var localPathFromRoot = PathUtility.MakeRelativePath(
            EnvironmentContext.BaseDirectory,
            EnvironmentContext.FileAbstractLayer.GetPhysicalPath(file.File)
        );

        return new FileModel(file, content) { LocalPathFromRoot = localPathFromRoot };
    }

    /// <inheritdoc />
    public SaveResult Save(FileModel model)
    {
        return DocumentProcessor.Save(model);
    }

    /// <inheritdoc />
    public void UpdateHref(FileModel model, IDocumentBuildContext context)
    {
        DocumentProcessor.UpdateHref(model, context);
    }
}
