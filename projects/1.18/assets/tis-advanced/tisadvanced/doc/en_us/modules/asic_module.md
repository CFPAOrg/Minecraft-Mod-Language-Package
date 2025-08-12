# ASIC Module

![I need more math!](item:tisadvanced:asic_module)

The Application Specific Integrated Circuit (or ASIC) Module supports calculating several advanced mathematical operations that are too complex to perform in hand-written assembly. The available functions are listed below:

- Sine
- Cosine
- Tangent
- Square Root
- Cube Root
- Exponentiation
- Natural Logarithm
- Hypotenuse Calculation
- Arcsine
- Arccosine
- Arctangent
- Hyperbolic Sine
- Hyperbolic Cosine
- Hyperbolic Tangent

Cycling through the selected functions is done by holding the item in your hand and right-clicking. Cycling backwards can be done by right-clicking while sneaking. 

Calculating the outputs of these functions is done by writing the input value to the module, at which point the module will write the output to all ports. An output value will only be transferred to one port. **All input and output values are IEEE-754 half-precision floating point values.**

All trigonometric functions operate in degrees.

For multi-parameter functions such as hypotenuse calculation, all inputs must be written to the module in sequence before the output can be read.
