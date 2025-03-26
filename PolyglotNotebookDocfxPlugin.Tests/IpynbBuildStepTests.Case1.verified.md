# How to dynamically update cell content?

The `display()` function allows for updating from an async data source.

```csharp
var title = display("querying...");

var currentDisplay = display("starting...");

async IAsyncEnumerable<string> Items(){
    for (int i = 0; i < 10; i++){
        yield return $"item {i}";
        await Task.Delay(1000);
    }
}

await foreach (var item in Items()){
    currentDisplay.Update(item);
}

title.Update("done!");

```

```
done!
```

```
item 9
```

This applies to any custom display output, for example a `IEnumerable` of content.

So in this case we will render an async source of data over and over again, replacing the table output each time.

```csharp
var title = display("querying...");

// some custom record
record Widget(string Name, int Value);

// some async source of widgets
async IAsyncEnumerable<Widget> Widgets(){
    for (int i = 0; i < 10; i++){
        yield return new Widget($"widget {i}", i);
        await Task.Delay(1000);
    }
}

var widgets = new List<Widget>();
var currentDisplay = display(widgets);
// display the widgets as they are produced, appending to the table output
await foreach (var widget in Widgets()){
    widgets.Add(widget);
    currentDisplay.Update(widgets); // render all collected widgets so far
}

title.Update("A complete list of widgets:");
```

```
A complete list of widgets:
```

<table><thead><tr><th><i>index</i></th><th>value</th></tr></thead><tbody><tr><td>0</td><td><details class="dni-treeview"><summary><span class="dni-code-hint"><code>Widget { Name = widget 0, Value = 0 }</code></span></summary><div><table><thead><tr></tr></thead><tbody><tr><td>Name</td><td><div class="dni-plaintext"><pre>widget 0</pre></div></td></tr><tr><td>Value</td><td><div class="dni-plaintext"><pre>0</pre></div></td></tr></tbody></table></div></details></td></tr><tr><td>1</td><td><details class="dni-treeview"><summary><span class="dni-code-hint"><code>Widget { Name = widget 1, Value = 1 }</code></span></summary><div><table><thead><tr></tr></thead><tbody><tr><td>Name</td><td><div class="dni-plaintext"><pre>widget 1</pre></div></td></tr><tr><td>Value</td><td><div class="dni-plaintext"><pre>1</pre></div></td></tr></tbody></table></div></details></td></tr><tr><td>2</td><td><details class="dni-treeview"><summary><span class="dni-code-hint"><code>Widget { Name = widget 2, Value = 2 }</code></span></summary><div><table><thead><tr></tr></thead><tbody><tr><td>Name</td><td><div class="dni-plaintext"><pre>widget 2</pre></div></td></tr><tr><td>Value</td><td><div class="dni-plaintext"><pre>2</pre></div></td></tr></tbody></table></div></details></td></tr><tr><td>3</td><td><details class="dni-treeview"><summary><span class="dni-code-hint"><code>Widget { Name = widget 3, Value = 3 }</code></span></summary><div><table><thead><tr></tr></thead><tbody><tr><td>Name</td><td><div class="dni-plaintext"><pre>widget 3</pre></div></td></tr><tr><td>Value</td><td><div class="dni-plaintext"><pre>3</pre></div></td></tr></tbody></table></div></details></td></tr><tr><td>4</td><td><details class="dni-treeview"><summary><span class="dni-code-hint"><code>Widget { Name = widget 4, Value = 4 }</code></span></summary><div><table><thead><tr></tr></thead><tbody><tr><td>Name</td><td><div class="dni-plaintext"><pre>widget 4</pre></div></td></tr><tr><td>Value</td><td><div class="dni-plaintext"><pre>4</pre></div></td></tr></tbody></table></div></details></td></tr><tr><td>5</td><td><details class="dni-treeview"><summary><span class="dni-code-hint"><code>Widget { Name = widget 5, Value = 5 }</code></span></summary><div><table><thead><tr></tr></thead><tbody><tr><td>Name</td><td><div class="dni-plaintext"><pre>widget 5</pre></div></td></tr><tr><td>Value</td><td><div class="dni-plaintext"><pre>5</pre></div></td></tr></tbody></table></div></details></td></tr><tr><td>6</td><td><details class="dni-treeview"><summary><span class="dni-code-hint"><code>Widget { Name = widget 6, Value = 6 }</code></span></summary><div><table><thead><tr></tr></thead><tbody><tr><td>Name</td><td><div class="dni-plaintext"><pre>widget 6</pre></div></td></tr><tr><td>Value</td><td><div class="dni-plaintext"><pre>6</pre></div></td></tr></tbody></table></div></details></td></tr><tr><td>7</td><td><details class="dni-treeview"><summary><span class="dni-code-hint"><code>Widget { Name = widget 7, Value = 7 }</code></span></summary><div><table><thead><tr></tr></thead><tbody><tr><td>Name</td><td><div class="dni-plaintext"><pre>widget 7</pre></div></td></tr><tr><td>Value</td><td><div class="dni-plaintext"><pre>7</pre></div></td></tr></tbody></table></div></details></td></tr><tr><td>8</td><td><details class="dni-treeview"><summary><span class="dni-code-hint"><code>Widget { Name = widget 8, Value = 8 }</code></span></summary><div><table><thead><tr></tr></thead><tbody><tr><td>Name</td><td><div class="dni-plaintext"><pre>widget 8</pre></div></td></tr><tr><td>Value</td><td><div class="dni-plaintext"><pre>8</pre></div></td></tr></tbody></table></div></details></td></tr><tr><td>9</td><td><details class="dni-treeview"><summary><span class="dni-code-hint"><code>Widget { Name = widget 9, Value = 9 }</code></span></summary><div><table><thead><tr></tr></thead><tbody><tr><td>Name</td><td><div class="dni-plaintext"><pre>widget 9</pre></div></td></tr><tr><td>Value</td><td><div class="dni-plaintext"><pre>9</pre></div></td></tr></tbody></table></div></details></td></tr></tbody></table><style>
.dni-code-hint {
    font-style: italic;
    overflow: hidden;
    white-space: nowrap;
}
.dni-treeview {
    white-space: nowrap;
}
.dni-treeview td {
    vertical-align: top;
    text-align: start;
}
details.dni-treeview {
    padding-left: 1em;
}
table td {
    text-align: start;
}
table tr { 
    vertical-align: top; 
    margin: 0em 0px;
}
table tr td pre 
{ 
    vertical-align: top !important; 
    margin: 0em 0px !important;
} 
table th {
    text-align: start;
}
</style>

We can also use the `Dataframe` type to produce a better displayed result out of our widgets type.

```csharp
#r "nuget:Microsoft.Data.Analysis,0.22.2"

using Microsoft.Data.Analysis;

var nameColumn = new StringDataFrameColumn("Name");
var ageColumn = new Int32DataFrameColumn("Age");

// we loop through the data and add it to the columns and redraw the dataframe each time
var title = display("querying...");
var currentDisplay = display(new DataFrame(nameColumn, ageColumn));
await foreach (var widget in Widgets()){
    nameColumn.Append(widget.Name);
    ageColumn.Append(widget.Value);
    currentDisplay.Update(new DataFrame(nameColumn, ageColumn));
}

title.Update("A complete list of widgets:");
```

<div><div></div><div></div><div><strong>Installed Packages</strong><ul><li><span>Microsoft.Data.Analysis, 0.22.2</span></li></ul></div></div>

```
Loading extensions from `{UserProfile}\.nuget\packages\microsoft.data.analysis\0.22.2\interactive-extensions\dotnet\Microsoft.Data.Analysis.Interactive.dll`
```

```
A complete list of widgets:
```

<table id="table_638784077199149971"><thead><tr><th><i>index</i></th><th>Name</th><th>Age</th></tr></thead><tbody><tr><td><i><div class="dni-plaintext"><pre>0</pre></div></i></td><td>widget 0</td><td><div class="dni-plaintext"><pre>0</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>1</pre></div></i></td><td>widget 1</td><td><div class="dni-plaintext"><pre>1</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>2</pre></div></i></td><td>widget 2</td><td><div class="dni-plaintext"><pre>2</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>3</pre></div></i></td><td>widget 3</td><td><div class="dni-plaintext"><pre>3</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>4</pre></div></i></td><td>widget 4</td><td><div class="dni-plaintext"><pre>4</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>5</pre></div></i></td><td>widget 5</td><td><div class="dni-plaintext"><pre>5</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>6</pre></div></i></td><td>widget 6</td><td><div class="dni-plaintext"><pre>6</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>7</pre></div></i></td><td>widget 7</td><td><div class="dni-plaintext"><pre>7</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>8</pre></div></i></td><td>widget 8</td><td><div class="dni-plaintext"><pre>8</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>9</pre></div></i></td><td>widget 9</td><td><div class="dni-plaintext"><pre>9</pre></div></td></tr></tbody></table><style>
.dni-code-hint {
    font-style: italic;
    overflow: hidden;
    white-space: nowrap;
}
.dni-treeview {
    white-space: nowrap;
}
.dni-treeview td {
    vertical-align: top;
    text-align: start;
}
details.dni-treeview {
    padding-left: 1em;
}
table td {
    text-align: start;
}
table tr { 
    vertical-align: top; 
    margin: 0em 0px;
}
table tr td pre 
{ 
    vertical-align: top !important; 
    margin: 0em 0px !important;
} 
table th {
    text-align: start;
}
</style>

