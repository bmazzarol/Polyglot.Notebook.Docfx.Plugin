using System.Collections.Immutable;
using System.Composition;
using System.Diagnostics.CodeAnalysis;
using Docfx.Plugins;
using static Polyglot.Notebook.Docfx.Plugin.DefaultConceptualProcessorAccessor;

namespace Polyglot.Notebook.Docfx.Plugin;

/// <summary>
/// Build step to convert ipynb files to html
/// </summary>
[Export(nameof(IpynbDocumentProcessor), typeof(IDocumentBuildStep))]
[ExcludeFromCodeCoverage(Justification = "Can only be used within a Docfx execution context.")]
public sealed class IpynbBuildStep : IDocumentBuildStep
{
    /// <inheritdoc />
    public string Name => nameof(IpynbBuildStep);

    /// <inheritdoc />
    public int BuildOrder => BuildStep.BuildOrder;

    /// <inheritdoc />
    public IEnumerable<FileModel> Prebuild(ImmutableList<FileModel> models, IHostService host)
    {
        return BuildStep.Prebuild(models, host);
    }

    /// <inheritdoc />
    public void Build(FileModel model, IHostService host)
    {
        BuildStep.Build(model, host);
    }

    /// <inheritdoc />
    public void Postbuild(ImmutableList<FileModel> models, IHostService host)
    {
        BuildStep.Postbuild(models, host);
    }
}
