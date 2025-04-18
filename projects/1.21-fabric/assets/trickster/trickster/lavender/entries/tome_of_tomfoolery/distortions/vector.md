```json
{
  "title": "Vectors",
  "icon": "minecraft:arrow",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "Primary Distortion",
    "Secondary Distortion",
    "Tertiary Distortion",
    "Absorption Distortion",
    "Magnitude Distortion",
    "Alignment Distortion",
    "Perpendicular Distortion",
    "Regularity Distortion",
    "Aligned Regularity Distortion"
  ]
}
```

While much vector math can be done with basic [arithmetic](^trickster:distortions/arithmetic) patterns, 
some operations require more specialized functionality.
This chapter provides some of these.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:extract_x,title=Primary Distortion|>

vector -> number

---

Returns the X component of the given vector.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:extract_y,title=Secondary Distortion|>

vector -> number

---

Returns the Y component of the given vector.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:extract_z,title=Tertiary Distortion|>

vector -> number

---

Returns the Z component of the given vector.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:merge_vector,title=Absorption Distortion|>

number, number, number -> vector

---

Merges three input numbers into a vector.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:length,title=Magnitude Distortion|>

vector -> number

---

Returns the length of the given vector.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:dot_product,title=Alignment Distortion|>

vector, vector -> number

---

Returns the dot product of the given vectors.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:cross_product,title=Perpendicular Distortion|>

vector, vector -> vector

---

Returns the cross product of the given vectors.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:normalize,title=Regularity Distortion|>

vector -> vector

---

Normalizes the given vector to a length of one.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:align_vector,title=Aligned Regularity Distortion|>

vector -> vector

---

Normalizes the given vector to a length of one and aligns it to the nearest cardinal axis.
