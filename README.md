![Polyglot Notebook docfx Plugin](notebook-icon.png)

# Polyglot Notebook docfx Plugin

**Notebooks that become documentation.**

Renders Polyglot Notebook cells as docfx pages, supporting everything docfx markdown supports, and letting you hide setup cells from the output.

[![Nuget](https://img.shields.io/nuget/v/Polyglot.Notebook.Docfx.Plugin)](https://www.nuget.org/packages/Polyglot.Notebook.Docfx.Plugin/) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=bmazzarol_Polyglot.Notebook.Docfx.Plugin&metric=coverage)](https://sonarcloud.io/summary/new_code?id=bmazzarol_Polyglot.Notebook.Docfx.Plugin) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=bmazzarol_Polyglot.Notebook.Docfx.Plugin&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=bmazzarol_Polyglot.Notebook.Docfx.Plugin) [![CD Build](https://github.com/bmazzarol/Polyglot.Notebook.Docfx.Plugin/actions/workflows/cd-build.yml/badge.svg)](https://github.com/bmazzarol/Polyglot.Notebook.Docfx.Plugin/actions/workflows/cd-build.yml) [![Check Markdown](https://github.com/bmazzarol/Polyglot.Notebook.Docfx.Plugin/actions/workflows/check-markdown.yml/badge.svg)](https://github.com/bmazzarol/Polyglot.Notebook.Docfx.Plugin/actions/workflows/check-markdown.yml)

[:running: **_Getting Started_**](https://bmazzarol.github.io/Polyglot.Notebook.Docfx.Plugin/getting-started.html) | [:books: **_Documentation_**](https://bmazzarol.github.io/Polyglot.Notebook.Docfx.Plugin/)

## Why?

[Docfx](https://dotnet.github.io/docfx/)
is a great tool for creating documentation, but it lacks support for
[Polyglot Notebooks](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.dotnet-interactive-vscode)
.
This plugin aims to fill that gap by providing a way to
render
[Polyglot Notebooks](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.dotnet-interactive-vscode)
in [Docfx](https://dotnet.github.io/docfx/).

Everything
[supported by Docfx in markdown files](https://dotnet.github.io/docfx/docs/markdown.html?tabs=linux%2Cdotnet)
is also supported in Polyglot Notebooks.

### Hiding Cells

If you want to hide cells from displaying in the final output,
you can use the `hidden-in-docfx` attribute in the cell metadata.

```json
{
  "metadata": {
    "tags": [
      "hidden-in-docfx"
    ]
  }
}
```

This allows you to keep cells in your notebook for setup or notebook only
purposes, but not have them show up in the final docfx output.

## Attributions

[Icons created by juicy_fish](https://www.flaticon.com/free-icons/construction)
