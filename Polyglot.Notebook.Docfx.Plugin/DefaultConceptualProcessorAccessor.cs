using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Docfx.Plugins;

namespace Polyglot.Notebook.Docfx.Plugin;

[ExcludeFromCodeCoverage(Justification = "Can only be used within a Docfx execution context.")]
internal static class DefaultConceptualProcessorAccessor
{
    public static IDocumentProcessor DocumentProcessor { get; }

    public static IDocumentBuildStep BuildStep { get; }

    static DefaultConceptualProcessorAccessor()
    {
        var assembly = Assembly.Load(assemblyString: "Docfx.Build");

        DocumentProcessor = Get<IDocumentProcessor>(assembly, "ConceptualDocumentProcessor");
        BuildStep = Get<IDocumentBuildStep>(assembly, "BuildConceptualDocument");
    }

    private static T Get<T>(Assembly assembly, string typeName)
    {
        var type = assembly.GetType(name: $"Docfx.Build.ConceptualDocuments.{typeName}");
        if (type == null)
        {
            throw new InvalidOperationException($"Failed to get {typeName}.");
        }

        var constructorInfo = type.GetConstructor(Type.EmptyTypes);

        if (constructorInfo == null)
        {
            throw new InvalidOperationException($"Failed to get {typeName} constructor.");
        }

        var instance = constructorInfo.Invoke(parameters: null);

        if (instance is not T processor)
        {
            throw new InvalidOperationException($"Failed to create {typeName} instance.");
        }

        return processor;
    }
}
