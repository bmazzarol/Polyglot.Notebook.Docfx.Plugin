#pragma warning disable MA0048
using System.Text.Json.Serialization;

namespace Polyglot.Notebook.Docfx.Plugin.Models;

internal sealed record IpynbFile(IReadOnlyList<Cell> Cells);

internal sealed record Cell(
    [property: JsonPropertyName("cell_type")] string Type,
    Metadata? Metadata,
    IReadOnlyList<string> Source,
    IReadOnlyList<CellOutput>? Outputs
);

internal sealed record Metadata(
    [property: JsonPropertyName("polyglot_notebook")] KernelSpec? KernelSpec,
    [property: JsonPropertyName("dotnet_interactive")] InteractiveSpec? InteractiveSpec,
    IReadOnlyList<string>? Tags
)
{
    public string? Language => KernelSpec?.Language ?? InteractiveSpec?.Language;

    public bool ShouldHide => Tags?.Contains("hidden-in-docfx", StringComparer.Ordinal) ?? false;
};

internal sealed record KernelSpec([property: JsonPropertyName("kernelName")] string Language);

internal sealed record InteractiveSpec([property: JsonPropertyName("language")] string Language);

internal sealed record CellOutput(
    [property: JsonPropertyName("output_type")] string OutputType,
    IReadOnlyDictionary<string, IReadOnlyList<string>> Data
);
