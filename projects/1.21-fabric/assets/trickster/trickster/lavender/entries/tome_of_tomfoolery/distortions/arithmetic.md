```json
{
  "title": "Arithmetic",
  "icon": "minecraft:copper_bulb",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "Annexation Stratagem",
    "Desertion Stratagem",
    "Domination Stratagem",
    "Submission Stratagem",
    "Distortion of Wholes",
    "Distortion of Supremacy",
    "Distortion of Inferiority",
    "Noble Stratagem",
    "Insignificance Stratagem",
    "Distortion of Grandeur",
    "Distortion of Humility",
    "Distortion of Objectivity",
    "Distortion of Decline",
    "Negation Distortion",
    "Absolutist's Distortion",
    "Primary Distortion of Geometry",
    "Secondary Distortion of Geometry",
    "Tertiary Distortion of Geometry",
    "Primary Inverse Distortion of Geometry",
    "Secondary Inverse Distortion of Geometry",
    "Tertiary Inverse Distortion of Geometry",
    "Cartesian Angle Distortion"
  ]
}
```

The following patterns regard basic arithmetic and mathematical operations.


Some of the base arithmetic tricks accept a combination of types of fragment. 
These will have their signatures labelled with, for example, {#aa4444}Addable{} or {#aa4444}Roundable{}.
These terms are shorthands for a combination of options:

;;;;;

{#aa4444}Addable{} and {#aa4444}Subtractable{} are either {#ddaa00}Numbers{}, {#aa7711}Vectors{}, or {#6644aa}Patterns{}.


{#aa4444}Multiplicable{}, {#aa4444}Divisible{}, and {#aa4444}Roundable{}
are only {#ddaa00}Numbers{} or {#aa7711}Vectors{}.

;;;;;

Distortions here that take many arguments at once will apply their operation cumulatively.
For example:


1, 2, 3 into Annexation Stratagem = 1 + 2 + 3 = 6


or


1, 2, 3 into Submission Stratagem = 1 / 2 / 3 = 0.1666...

;;;;;

<|trick@trickster:templates|trick-id=trickster:add|>

Adds fragments together.

;;;;;

<|trick@trickster:templates|trick-id=trickster:subtract|>

Subtracts multiple fragments from the first fragment.

;;;;;

<|trick@trickster:templates|trick-id=trickster:multiply|>

Multiplies a bunch of fragments.

;;;;;

<|trick@trickster:templates|trick-id=trickster:divide|>

Divides fragments sequentially, starting from the first.

;;;;;

<|trick@trickster:templates|trick-id=trickster:modulo|>

Returns the remainder of dividing the first number by the second number.

;;;;;

<|trick@trickster:templates|trick-id=trickster:power|>

Returns the first number raised to the power of the second.

;;;;;

<|trick@trickster:templates|trick-id=trickster:logarithm|>

Given two numbers, returns the power that the first number must be raised by to equal the second.

;;;;;

<|trick@trickster:templates|trick-id=trickster:max|>

Returns the highest of its input values.

;;;;;

<|trick@trickster:templates|trick-id=trickster:min|>

Returns the lowest of its input values.

;;;;;

<|trick@trickster:templates|trick-id=trickster:ceil|>

Returns the value of the input rounded up.

;;;;;

<|trick@trickster:templates|trick-id=trickster:floor|>

Returns the value of the input rounded down.

;;;;;

<|trick@trickster:templates|trick-id=trickster:round|>

Returns the rounded value of the input.

;;;;;

<|trick@trickster:templates|trick-id=trickster:sqrt|>

Returns the square root of the input.

;;;;;

<|trick@trickster:templates|trick-id=trickster:invert|>

Inverts the given number or vector.

;;;;;

<|trick@trickster:templates|trick-id=trickster:abs|>

If the given number is negative, returns its positive equivalent. Otherwise, returns the number as-is.

;;;;;

<|trick@trickster:templates|trick-id=trickster:sin|>

Returns the sine of the given number.

;;;;;

<|trick@trickster:templates|trick-id=trickster:cos|>

Returns the cosine of the given number.

;;;;;

<|trick@trickster:templates|trick-id=trickster:tan|>

Returns the tangent of the given number.

;;;;;

<|trick@trickster:templates|trick-id=trickster:arcsin|>

Returns the arcsine of the given number.

;;;;;

<|trick@trickster:templates|trick-id=trickster:arccos|>

Returns the arccosine of the given number.

;;;;;

<|trick@trickster:templates|trick-id=trickster:arctan|>

Returns the arctangent of the given number.

;;;;;

<|trick@trickster:templates|trick-id=trickster:arctan2|>

Returns the angle measure between positive X axis and the ray from the origin to the point (y, x).
