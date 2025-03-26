using System.Text.Json.Serialization;

namespace PolyglotNotebookDocfxPlugin.Models;

public sealed record Cell(
    [property: JsonPropertyName("cell_type")] string Type,
    Metadata? Metadata,
    IReadOnlyList<string> Source,
    IReadOnlyList<CellOutput>? Outputs
);

public sealed record Metadata(
    [property: JsonPropertyName("polyglot_notebook")] KernelSpec? KernelSpec,
    [property: JsonPropertyName("dotnet_interactive")] InteractiveSpec? InteractiveSpec
)
{
    public string? Language => KernelSpec?.Language ?? InteractiveSpec?.Language;
};

public sealed record KernelSpec([property: JsonPropertyName("kernelName")] string Language);

public sealed record InteractiveSpec([property: JsonPropertyName("language")] string Language);

public sealed record CellOutput(
    [property: JsonPropertyName("output_type")] string OutputType,
    IReadOnlyDictionary<string, IReadOnlyList<string>> Data
);
