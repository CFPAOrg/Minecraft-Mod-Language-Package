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

The following patterns regard basic arithmetic and simple mathematical operations.


Many base arithmetical operations, though not all, will work on both single numbers and vectors.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:add,title=Annexation Stratagem|>

(number | vec)... | (number | vec)[] -> (number | vec)

---

Adds many numbers or vectors into a single value. 
A number and a vector will combine into a vector.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:subtract,title=Desertion Stratagem|>

(number | vec)... | (number | vec)[] -> (number | vec)

---

Subtracts many numbers or vectors into a single value.
A number and a vector will combine into a vector.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:multiply,title=Domination Stratagem|>

(number | vec)... | (number | vec)[] -> (number | vec)

---

Multiplies many numbers or vectors into a single value.
A number and a vector will combine into a vector.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:divide,title=Submission Stratagem|>

(number | vec)... | (number | vec)[] -> (number | vec)

---

Divides many numbers or vectors into a single value.
A number and a vector will combine into a vector.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:modulo,title=Distortion of Wholes|>

number, number -> number

---

Returns the remainder of dividing the first number by the second number.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:power,title=Distortion of Supremacy|>

number, number -> number

---

Returns the first number raised to the power of the second.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:max,title=Noble Stratagem|>

number... | number[] -> number

---

Returns the highest of many input values.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:min,title=Insignificance Stratagem|>

number... | number[] -> number

---

Returns the lowest of many input values.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:ceil,title=Distortion of Grandeur|>

number -> number

---

Returns the value of the input rounded up.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:floor,title=Distortion of Humility|>

number -> number

---

Returns the value of the input rounded down.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:round,title=Distortion of Objectivity|>

number -> number

---

Returns the rounded value of the input.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:sqrt,title=Distortion of Decline|>

number -> number

---

Returns the square root of the input.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:invert,title=Negation Distortion|>

number -> number | vec -> vec

---

Inverts the given number or vector.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:abs,title=Absolutist's Distortion|>

number -> number

---

If the given number is negative, returns its positive equivalent. Otherwise, does nothing.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:sin,title=Primary Distortion of Geometry|>

number -> number

---

Returns the sine of the given number.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:cos,title=Secondary Distortion of Geometry|>

number -> number

---

Returns the cosine of the given number.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:tan,title=Tertiary Distortion of Geometry|>

number -> number

---

Returns the tangent of the given number.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:arcsin,title=Primary Inverse Distortion of Geometry|>

number -> number

---

Returns the arcsine of the given number.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:arccos,title=Secondary Inverse Distortion of Geometry|>

number -> number

---

Returns the arccosine of the given number.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:arctan,title=Tertiary Inverse Distortion of Geometry|>

number -> number

---

Returns the arctangent of the given number.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:arctan2,title=Cartesian Angle Distortion|>

number, number -> number

---

Returns the angle measure between positive X axis and the ray from the origin to the point (y, x).