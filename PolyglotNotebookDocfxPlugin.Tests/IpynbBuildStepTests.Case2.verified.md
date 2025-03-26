[this doc on github](https://github.com/dotnet/interactive/tree/main/samples/notebooks/csharp/Samples)


```csharp
#i "nuget:https://api.nuget.org/v3/index.json" 
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json" 
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json" 

#r "nuget:Microsoft.Data.Analysis, 0.21.0"
#r "nuget: Plotly.NET.Interactive, 4.2.0"
#r "nuget: Plotly.Net, 4.2.0"

using Microsoft.Data.Analysis;
```

<div><div><strong>Restore sources</strong><ul><li><span>https://api.nuget.org/v3/index.json</span></li><li><span>https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json</span></li><li><span>https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json</span></li></ul></div><div></div><div><strong>Installed Packages</strong><ul><li><span>Microsoft.Data.Analysis, 0.21.0</span></li><li><span>Plotly.Net, 4.2.0</span></li><li><span>Plotly.NET.Interactive, 4.2.0</span></li></ul></div></div>

```
Loading extensions from `{UserProfile}\.nuget\packages\plotly.net.interactive\4.2.0\lib\netstandard2.1\Plotly.NET.Interactive.dll`
```

```
Loading extensions from `{UserProfile}\.nuget\packages\microsoft.data.analysis\0.21.0\interactive-extensions\dotnet\Microsoft.Data.Analysis.Interactive.dll`
```

```csharp
DateTimeDataFrameColumn dateTimes = new DateTimeDataFrameColumn("DateTimes"); // Default length is 0.
Int32DataFrameColumn ints = new Int32DataFrameColumn("Ints", 6); // Makes a column of length 3. Filled with nulls initially
StringDataFrameColumn strings = new StringDataFrameColumn("Strings", 6); // Makes a column of length 3. Filled with nulls initially
```

```csharp
// Append 6 values to dateTimes
dateTimes.Append(DateTime.Parse("2019/01/01"));
dateTimes.Append(DateTime.Parse("2019/01/01"));
dateTimes.Append(DateTime.Parse("2019/01/02"));
dateTimes.Append(DateTime.Parse("2019/02/02"));
dateTimes.Append(DateTime.Parse("2019/02/02"));
dateTimes.Append(DateTime.Parse("2019/03/02"));
```

```csharp
DataFrame df = new DataFrame(dateTimes, ints, strings ); // This will throw if the columns are of different lengths
```

```csharp
df
```

<table id="table_638786010731680225"><thead><tr><th><i>index</i></th><th>DateTimes</th><th>Ints</th><th>Strings</th></tr></thead><tbody><tr><td><i><div class="dni-plaintext"><pre>0</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>1</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>2</pre></div></i></td><td><span>2019-01-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>3</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>4</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>5</pre></div></i></td><td><span>2019-03-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr></tbody></table><style>
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

```csharp
// To change a value directly through df
df[0, 1] = 10; // 0 is the rowIndex, and 1 is the columnIndex. This sets the 0th value in the Ints columns to 10
df
```

<table id="table_638786010732792985"><thead><tr><th><i>index</i></th><th>DateTimes</th><th>Ints</th><th>Strings</th></tr></thead><tbody><tr><td><i><div class="dni-plaintext"><pre>0</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>10</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>1</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>2</pre></div></i></td><td><span>2019-01-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>3</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>4</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>5</pre></div></i></td><td><span>2019-03-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr></tbody></table><style>
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

```csharp
// Modify ints and strings columns by indexing
ints[1] = 24;
strings[1] = "Foo!";
df
```

<table id="table_638786010733433778"><thead><tr><th><i>index</i></th><th>DateTimes</th><th>Ints</th><th>Strings</th></tr></thead><tbody><tr><td><i><div class="dni-plaintext"><pre>0</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>10</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>1</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>24</pre></div></td><td>Foo!</td></tr><tr><td><i><div class="dni-plaintext"><pre>2</pre></div></i></td><td><span>2019-01-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>3</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>4</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>5</pre></div></i></td><td><span>2019-03-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr></tbody></table><style>
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

```csharp
// Indexing can throw when types don't match.
// ints[1] = "this will throw because I am a string";  
// Info can be used to figure out the type of data in a column. 
df.Info()
```

<table id="table_638786010734527778"><thead><tr><th><i>index</i></th><th>Info</th><th>DateTimes</th><th>Ints</th><th>Strings</th></tr></thead><tbody><tr><td><i><div class="dni-plaintext"><pre>0</pre></div></i></td><td>DataType</td><td>System.DateTime</td><td>System.Int32</td><td>System.String</td></tr><tr><td><i><div class="dni-plaintext"><pre>1</pre></div></i></td><td>Length (excluding null values)</td><td>6</td><td>2</td><td>6</td></tr></tbody></table><style>
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

```csharp
// Add 5 to ints through the DataFrame
df["Ints"].Add(5, inPlace: true);
df
```

<table id="table_638786010735532761"><thead><tr><th><i>index</i></th><th>DateTimes</th><th>Ints</th><th>Strings</th></tr></thead><tbody><tr><td><i><div class="dni-plaintext"><pre>0</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>15</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>1</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>29</pre></div></td><td>Foo!</td></tr><tr><td><i><div class="dni-plaintext"><pre>2</pre></div></i></td><td><span>2019-01-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>3</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>4</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>5</pre></div></i></td><td><span>2019-03-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr></tbody></table><style>
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

```csharp
// We can also use binary operators. Binary operators produce a copy, so assign it back to our Ints column 
df["Ints"] = (ints / 5) * 20;
df
```

<table id="table_638786010737897597"><thead><tr><th><i>index</i></th><th>DateTimes</th><th>Ints</th><th>Strings</th></tr></thead><tbody><tr><td><i><div class="dni-plaintext"><pre>0</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>60</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>1</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Foo!</td></tr><tr><td><i><div class="dni-plaintext"><pre>2</pre></div></i></td><td><span>2019-01-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>3</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>4</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>5</pre></div></i></td><td><span>2019-03-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td><td><div class="dni-plaintext"><pre>&lt;null&gt;</pre></div></td></tr></tbody></table><style>
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

```csharp
// Fill nulls in our columns, if any. Ints[2], Strings[0] and Strings[1] are null
df["Ints"].FillNulls(100, inPlace: true);
df["Strings"].FillNulls("Bar", inPlace: true);
df
```

<table id="table_638786010738505747"><thead><tr><th><i>index</i></th><th>DateTimes</th><th>Ints</th><th>Strings</th></tr></thead><tbody><tr><td><i><div class="dni-plaintext"><pre>0</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>60</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>1</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Foo!</td></tr><tr><td><i><div class="dni-plaintext"><pre>2</pre></div></i></td><td><span>2019-01-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>3</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>4</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>5</pre></div></i></td><td><span>2019-03-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr></tbody></table><style>
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

```csharp
// To inspect the first row
DataFrameRow row0 = df.Rows[0];
row0
```

<details open="open" class="dni-treeview"><summary><span class="dni-code-hint"><code>[ 1/1/2019 12:00:00 AM, 60, Bar ]</code></span></summary><div><table><thead><tr></tr></thead><tbody><tr><td><i>(values)</i></td><td><table><thead><tr><th><i>index</i></th><th><i>type</i></th><th>value</th></tr></thead><tbody><tr><td>0</td><td><span><a href="https://docs.microsoft.com/dotnet/api/system.datetime?view=net-7.0">System.DateTime</a></span></td><td><span>2019-01-01 00:00:00Z</span></td></tr><tr><td>1</td><td><span><a href="https://docs.microsoft.com/dotnet/api/system.int32?view=net-7.0">System.Int32</a></span></td><td><div class="dni-plaintext"><pre>60</pre></div></td></tr><tr><td>2</td><td><span><a href="https://docs.microsoft.com/dotnet/api/system.string?view=net-7.0">System.String</a></span></td><td><div class="dni-plaintext"><pre>Bar</pre></div></td></tr></tbody></table></td></tr></tbody></table></div></details><style>
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

```csharp
// Filter rows based on equality
PrimitiveDataFrameColumn<bool> boolFilter = df["Strings"].ElementwiseEquals("Bar");
boolFilter
```

<details open="open" class="dni-treeview"><summary><span class="dni-code-hint"><code>[ True, False, True, True, True, True ]</code></span></summary><div><table><thead><tr></tr></thead><tbody><tr><td>NullCount</td><td><div class="dni-plaintext"><pre>0</pre></div></td></tr><tr><td>Length</td><td><div class="dni-plaintext"><pre>6</pre></div></td></tr><tr><td>Name</td><td><div class="dni-plaintext"><pre>Strings</pre></div></td></tr><tr><td>DataType</td><td><span><a href="https://docs.microsoft.com/dotnet/api/system.boolean?view=net-7.0">System.Boolean</a></span></td></tr><tr><td><i>(values)</i></td><td><div class="dni-plaintext"><pre>[ True, False, True, True, True, True ]</pre></div></td></tr></tbody></table></div></details><style>
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

```csharp
DataFrame filtered = df.Filter(boolFilter);
filtered
```

<table id="table_638786010741062441"><thead><tr><th><i>index</i></th><th>DateTimes</th><th>Ints</th><th>Strings</th></tr></thead><tbody><tr><td><i><div class="dni-plaintext"><pre>0</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>60</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>1</pre></div></i></td><td><span>2019-01-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>2</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>3</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>4</pre></div></i></td><td><span>2019-03-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr></tbody></table><style>
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

```csharp
// Sort our dataframe using the Ints column
DataFrame sorted = df.OrderBy("Ints");
sorted
```

<table id="table_638786010741823897"><thead><tr><th><i>index</i></th><th>DateTimes</th><th>Ints</th><th>Strings</th></tr></thead><tbody><tr><td><i><div class="dni-plaintext"><pre>0</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>60</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>1</pre></div></i></td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Foo!</td></tr><tr><td><i><div class="dni-plaintext"><pre>2</pre></div></i></td><td><span>2019-01-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>3</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>4</pre></div></i></td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>5</pre></div></i></td><td><span>2019-03-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr></tbody></table><style>
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

```csharp
//Clone dataframe
var newDf = df.Clone();

//Add new column
StringDataFrameColumn newColumn = new StringDataFrameColumn("Month", ((DateTimeDataFrameColumn)df["DateTimes"]).Select(x => x.Value.ToString("MMMM")));
newDf.Columns.Add(newColumn);
```

```csharp
// GroupBy month
GroupBy groupBy = newDf.GroupBy("Month");

//Show grouped data
DataFrame groupedDf = groupBy.Head(10);
groupedDf
```

<table id="table_638786010744222142"><thead><tr><th><i>index</i></th><th>Month</th><th>DateTimes</th><th>Ints</th><th>Strings</th></tr></thead><tbody><tr><td><i><div class="dni-plaintext"><pre>0</pre></div></i></td><td>January</td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>60</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>1</pre></div></i></td><td>January</td><td><span>2019-01-01 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Foo!</td></tr><tr><td><i><div class="dni-plaintext"><pre>2</pre></div></i></td><td>January</td><td><span>2019-01-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>3</pre></div></i></td><td>February</td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>4</pre></div></i></td><td>February</td><td><span>2019-02-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr><tr><td><i><div class="dni-plaintext"><pre>5</pre></div></i></td><td>March</td><td><span>2019-03-02 00:00:00Z</span></td><td><div class="dni-plaintext"><pre>100</pre></div></td><td>Bar</td></tr></tbody></table><style>
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

```csharp
// Count of values in each group
DataFrame groupCounts = groupBy.Count();
groupCounts
```

<table id="table_638786010744748852"><thead><tr><th><i>index</i></th><th>Month</th><th>DateTimes</th><th>Ints</th><th>Strings</th></tr></thead><tbody><tr><td><i><div class="dni-plaintext"><pre>0</pre></div></i></td><td>January</td><td><div class="dni-plaintext"><pre>3</pre></div></td><td><div class="dni-plaintext"><pre>3</pre></div></td><td><div class="dni-plaintext"><pre>3</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>1</pre></div></i></td><td>February</td><td><div class="dni-plaintext"><pre>2</pre></div></td><td><div class="dni-plaintext"><pre>2</pre></div></td><td><div class="dni-plaintext"><pre>2</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>2</pre></div></i></td><td>March</td><td><div class="dni-plaintext"><pre>1</pre></div></td><td><div class="dni-plaintext"><pre>1</pre></div></td><td><div class="dni-plaintext"><pre>1</pre></div></td></tr></tbody></table><style>
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

```csharp
// Alternatively find the sum of the values in each group in Ints
DataFrame intsGroupSum = groupBy.Sum("Ints");
intsGroupSum
```

<table id="table_638786010745341347"><thead><tr><th><i>index</i></th><th>Month</th><th>Ints</th></tr></thead><tbody><tr><td><i><div class="dni-plaintext"><pre>0</pre></div></i></td><td>January</td><td><div class="dni-plaintext"><pre>260</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>1</pre></div></i></td><td>February</td><td><div class="dni-plaintext"><pre>200</pre></div></td></tr><tr><td><i><div class="dni-plaintext"><pre>2</pre></div></i></td><td>March</td><td><div class="dni-plaintext"><pre>100</pre></div></td></tr></tbody></table><style>
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

```csharp
using Plotly.NET;
using System.Linq;
using Microsoft.FSharp.Core;
```

```csharp
display(Chart2D.Chart.Column<int, string, string, string, string>(
    ((Int32DataFrameColumn)intsGroupSum["Ints"]).Select(x => x ?? default), new FSharpOption<IEnumerable<string>>(((StringDataFrameColumn)intsGroupSum["Month"]))));
```

<div><div id="914da2a6-3a7f-42b9-8388-0562b7248f8b"><!-- Plotly chart will be drawn inside this DIV --></div><script type="text/javascript">
var renderPlotly_914da2a63a7f42b983880562b7248f8b = function() {
    var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-2.21.0.min'}}) || require;
    fsharpPlotlyRequire(['plotly'], function(Plotly) {
        var data = [{"type":"bar","x":["January","February","March"],"y":[260,200,100],"orientation":"v","marker":{"pattern":{}}}];
        var layout = {"width":600,"height":600,"template":{"layout":{"title":{"x":0.05},"font":{"color":"rgba(42, 63, 95, 1.0)"},"paper_bgcolor":"rgba(255, 255, 255, 1.0)","plot_bgcolor":"rgba(229, 236, 246, 1.0)","autotypenumbers":"strict","colorscale":{"diverging":[[0.0,"#8e0152"],[0.1,"#c51b7d"],[0.2,"#de77ae"],[0.3,"#f1b6da"],[0.4,"#fde0ef"],[0.5,"#f7f7f7"],[0.6,"#e6f5d0"],[0.7,"#b8e186"],[0.8,"#7fbc41"],[0.9,"#4d9221"],[1.0,"#276419"]],"sequential":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]],"sequentialminus":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]},"hovermode":"closest","hoverlabel":{"align":"left"},"coloraxis":{"colorbar":{"outlinewidth":0.0,"ticks":""}},"geo":{"showland":true,"landcolor":"rgba(229, 236, 246, 1.0)","showlakes":true,"lakecolor":"rgba(255, 255, 255, 1.0)","subunitcolor":"rgba(255, 255, 255, 1.0)","bgcolor":"rgba(255, 255, 255, 1.0)"},"mapbox":{"style":"light"},"polar":{"bgcolor":"rgba(229, 236, 246, 1.0)","radialaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""},"angularaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","ticks":""}},"scene":{"xaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"yaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true},"zaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","gridwidth":2.0,"zerolinecolor":"rgba(255, 255, 255, 1.0)","backgroundcolor":"rgba(229, 236, 246, 1.0)","showbackground":true}},"ternary":{"aaxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"baxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"caxis":{"ticks":"","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)"},"bgcolor":"rgba(229, 236, 246, 1.0)"},"xaxis":{"title":{"standoff":15},"ticks":"","automargin":"height+width+left+right+top+bottom","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"yaxis":{"title":{"standoff":15},"ticks":"","automargin":"height+width+left+right+top+bottom","linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","zerolinecolor":"rgba(255, 255, 255, 1.0)","zerolinewidth":2.0},"annotationdefaults":{"arrowcolor":"#2a3f5f","arrowhead":0,"arrowwidth":1},"shapedefaults":{"line":{"color":"rgba(42, 63, 95, 1.0)"}},"colorway":["rgba(99, 110, 250, 1.0)","rgba(239, 85, 59, 1.0)","rgba(0, 204, 150, 1.0)","rgba(171, 99, 250, 1.0)","rgba(255, 161, 90, 1.0)","rgba(25, 211, 243, 1.0)","rgba(255, 102, 146, 1.0)","rgba(182, 232, 128, 1.0)","rgba(255, 151, 255, 1.0)","rgba(254, 203, 82, 1.0)"]},"data":{"bar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}},"error_x":{"color":"rgba(42, 63, 95, 1.0)"},"error_y":{"color":"rgba(42, 63, 95, 1.0)"}}],"barpolar":[{"marker":{"line":{"color":"rgba(229, 236, 246, 1.0)","width":0.5},"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"carpet":[{"aaxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"},"baxis":{"linecolor":"rgba(255, 255, 255, 1.0)","gridcolor":"rgba(255, 255, 255, 1.0)","endlinecolor":"rgba(42, 63, 95, 1.0)","minorgridcolor":"rgba(255, 255, 255, 1.0)","startlinecolor":"rgba(42, 63, 95, 1.0)"}}],"choropleth":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contour":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"contourcarpet":[{"colorbar":{"outlinewidth":0.0,"ticks":""}}],"heatmap":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"heatmapgl":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram":[{"marker":{"pattern":{"fillmode":"overlay","size":10,"solidity":0.2}}}],"histogram2d":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"histogram2dcontour":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"mesh3d":[{"colorbar":{"outlinewidth":0.0,"ticks":""}}],"parcoords":[{"line":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"pie":[{"automargin":true}],"scatter":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatter3d":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}},"line":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattercarpet":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattergeo":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattergl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scattermapbox":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterpolar":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterpolargl":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"scatterternary":[{"marker":{"colorbar":{"outlinewidth":0.0,"ticks":""}}}],"surface":[{"colorbar":{"outlinewidth":0.0,"ticks":""},"colorscale":[[0.0,"#0d0887"],[0.1111111111111111,"#46039f"],[0.2222222222222222,"#7201a8"],[0.3333333333333333,"#9c179e"],[0.4444444444444444,"#bd3786"],[0.5555555555555556,"#d8576b"],[0.6666666666666666,"#ed7953"],[0.7777777777777778,"#fb9f3a"],[0.8888888888888888,"#fdca26"],[1.0,"#f0f921"]]}],"table":[{"cells":{"fill":{"color":"rgba(235, 240, 248, 1.0)"},"line":{"color":"rgba(255, 255, 255, 1.0)"}},"header":{"fill":{"color":"rgba(200, 212, 227, 1.0)"},"line":{"color":"rgba(255, 255, 255, 1.0)"}}}]}}};
        var config = {"responsive":true};
        Plotly.newPlot('914da2a6-3a7f-42b9-8388-0562b7248f8b', data, layout, config);
    });
};
if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
    var script = document.createElement("script");
    script.setAttribute("charset", "utf-8");
    script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
    script.onload = function(){
        renderPlotly_914da2a63a7f42b983880562b7248f8b();
    };
    document.getElementsByTagName("head")[0].appendChild(script);
}
else {
    renderPlotly_914da2a63a7f42b983880562b7248f8b();
}
</script></div>

