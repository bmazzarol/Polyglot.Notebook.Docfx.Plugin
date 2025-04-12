using Docfx.Plugins;

namespace PolyglotNotebookDocfxPlugin.Extensions;

internal static class FileModelExtensions
{
    public static T? Get<T>(this FileModel model, string? key = null)
    {
        if (model.Content is not FileModelDetails details)
        {
            return default;
        }

        return details.TryGetValue(key ?? typeof(T).Name, out var value) && value is T valueT
            ? valueT
            : default;
    }
}
