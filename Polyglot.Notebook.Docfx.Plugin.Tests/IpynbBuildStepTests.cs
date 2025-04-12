using System.Text;
using System.Text.Json;
using Polyglot.Notebook.Docfx.Plugin.Models;

namespace Polyglot.Notebook.Docfx.Plugin.Tests;

public sealed class IpynbBuildStepTests
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = false,
    };

    [Fact(DisplayName = "A polyglot notebook should be converted to markdown")]
    public async Task Case1()
    {
        var notebook = await File.ReadAllTextAsync(
            "Examples/example1.ipynb",
            TestContext.Current.CancellationToken
        );

        var ipynbFile =
            JsonSerializer.Deserialize<IpynbFile>(notebook, Options)
            ?? throw new InvalidOperationException("Failed to deserialize polyglot notebook file.");

        var builder = new StringBuilder();
        IpynbBuildStep.WriteMarkdownContent(builder, ipynbFile);

        var markdown = builder.ToString().Replace("\r\n", "\n", StringComparison.Ordinal);
        await Verify(markdown, extension: "md");
    }

    [Fact(DisplayName = "Dataframe getting started example should be converted to markdown")]
    public async Task Case2()
    {
        var notebook = await File.ReadAllTextAsync(
            "Examples/DataFrame-Getting Started.ipynb",
            TestContext.Current.CancellationToken
        );

        var ipynbFile =
            JsonSerializer.Deserialize<IpynbFile>(notebook, Options)
            ?? throw new InvalidOperationException("Failed to deserialize polyglot notebook file.");

        var builder = new StringBuilder();
        IpynbBuildStep.WriteMarkdownContent(builder, ipynbFile);

        var markdown = builder.ToString().Replace("\r\n", "\n", StringComparison.Ordinal);
        await Verify(markdown, extension: "md");
    }

    [Fact(DisplayName = "Introduction to F# example should be converted to markdown")]
    public async Task Case3()
    {
        var notebook = await File.ReadAllTextAsync(
            "Examples/Introduction to F#.ipynb",
            TestContext.Current.CancellationToken
        );

        var ipynbFile =
            JsonSerializer.Deserialize<IpynbFile>(notebook, Options)
            ?? throw new InvalidOperationException("Failed to deserialize polyglot notebook file.");

        var builder = new StringBuilder();
        IpynbBuildStep.WriteMarkdownContent(builder, ipynbFile);

        var markdown = builder.ToString().Replace("\r\n", "\n", StringComparison.Ordinal);
        await Verify(markdown, extension: "md");
    }

    [Fact(DisplayName = "D3.js with import example should be converted to markdown")]
    public async Task Case4()
    {
        var notebook = await File.ReadAllTextAsync(
            "Examples/D3.js with import.ipynb",
            TestContext.Current.CancellationToken
        );

        var ipynbFile =
            JsonSerializer.Deserialize<IpynbFile>(notebook, Options)
            ?? throw new InvalidOperationException("Failed to deserialize polyglot notebook file.");

        var builder = new StringBuilder();
        IpynbBuildStep.WriteMarkdownContent(builder, ipynbFile);

        var markdown = builder.ToString().Replace("\r\n", "\n", StringComparison.Ordinal);
        await Verify(markdown, extension: "md");
    }
}
