# Display Module
![Paint by numbers](item:tis3d:display_module)

The display module provides a highly flexible method of visualizing arbitrary data as a two-dimensional grid of colored cells (*Editor's note*: "pixels" as the kids like to call them). The color of these cells can be changed by providing a sequence of numbers to any of the four ports of the display module, containing a color code and position and size of the rectangle to fill.

The display module continuously reads values from all four of its ports and accumulates five values into a single draw call. Once all five values required for a draw call have been received, the described rectangle is applied to the color grid.

## Draw Call Specification
Each sequence of five received by the display module is interpreted as a draw call with the components: color, column, row, width and height. The grid is quadratic and has twenty-four (24) columns and rows. Color values are from a fixed palette. The exact color values may vary by vendor, however the general color names follow the physical spectrum of this world:
- `0`: White
- `1`: Orange
- `2`: Magenta
- `3`: Light Blue
- `4`: Yellow
- `5`: Lime
- `6`: Pink
- `7`: Gray
- `8`: Silver
- `9`: Cyan
- `10`: Purple
- `11`: Blue
- `12`: Brown
- `13`: Green
- `14`: Red
- `15`: Black

Providing illegal values for either color or coordinates is undefined behavior, but should generally be handled gracefully at the vendor's discretion.

A simple program drawing vertical lines in the different colors:
`MOV 16 ACC`
`LOOP:`
`SUB 1`
`MOV ACC LEFT # COLOR`
`MOV ACC LEFT # X`
`MOV 0 LEFT # Y`
`MOV 1 LEFT # WIDTH`
`MOV 28 LEFT # HEIGHT`
`JNZ LOOP`
