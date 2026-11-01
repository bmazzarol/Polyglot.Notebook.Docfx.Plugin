![Polyglot Notebook docfx Plugin](https://raw.githubusercontent.com/bmazzarol/Polyglot.Notebook.Docfx.Plugin/main/notebook-icon-small.png)

# Polyglot Notebook docfx Plugin

**Notebooks that become documentation.**

Renders Polyglot Notebook cells as docfx pages, supporting everything docfx markdown supports, and letting you hide setup cells from the output.

[![Nuget](https://img.shields.io/nuget/v/Polyglot.Notebook.Docfx.Plugin)](https://www.nuget.org/packages/Polyglot.Notebook.Docfx.Plugin/)

```shell
dotnet add package Polyglot.Notebook.Docfx.Plugin
```

[Getting started](https://bmazzarol.github.io/Polyglot.Notebook.Docfx.Plugin/getting-started.html) - [Full documentation](https://bmazzarol.github.io/Polyglot.Notebook.Docfx.Plugin/)

## Why?

Docfx does not support
[Polyglot Notebooks](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.dotnet-interactive-vscode).
This plugin renders notebook cells as docfx pages. Everything
[supported by docfx in markdown](https://dotnet.github.io/docfx/docs/markdown.html)
is supported in a notebook.

## Setup

Get the package, then copy `Polyglot.Notebook.Docfx.Plugin.dll` into the
`plugins` folder of a
[custom docfx template](https://dotnet.github.io/docfx/docs/template.html?tabs=modern#custom-template).

Reference `.ipynb` files in `docfx.json` the same way you reference `.md` files.

## Hiding cells

Cells used for notebook setup can be kept out of the rendered page with the
`hidden-in-docfx` tag in the cell metadata:

```json
{
  "metadata": {
    "tags": [
      "hidden-in-docfx"
    ]
  }
}
```

## What it does not do

- Cells are not executed. The plugin renders the cells and the outputs stored in
  the notebook
- `display_data` outputs are the only outputs rendered

## See also

- [Getting started](https://bmazzarol.github.io/Polyglot.Notebook.Docfx.Plugin/getting-started.html)

## Attributions

[Icons created by juicy_fish](https://www.flaticon.com/free-icons/construction)
