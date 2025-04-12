# Load [D3.js](https://d3js.org/) using `import`.

```html
<svg id="d3_target"></svg>
```

<svg id="d3_target"></svg>

# Now, you can use `d3` to render an image.

```javascript
d3 = await import("https://cdn.jsdelivr.net/npm/d3@7/+esm");

const width = 400;
const height = 400;
const svg = d3.select("#d3_target");

svg
  .attr("width", width)
  .attr("height", 400)
  .attr("viewBox", [0, 0, width, height])
  .attr("style", "max-width: 100%; height: auto; height: intrinsic;");

svg
  .append("circle")
  .attr("fill", "red")
  .attr("cx", width/2)
  .attr("cy", height/2)
  .attr("r", "100");
```

