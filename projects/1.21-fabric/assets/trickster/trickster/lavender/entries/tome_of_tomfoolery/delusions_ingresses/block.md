```json
{
  "title": "Block Querying",
  "icon": "minecraft:white_wool",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "Ingress of Validation",
    "Ingress of Hardness",
    "Ingress of Suitability",
    "Ingress of Logic",
    "Ingress of Resonance"
  ]
}
```

This entry contains tricks that query or inspect blocks in the world.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:check_block,title=Ingress of Validation|>

vector -> block

---

Returns the block type at the given position.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_block_hardness,title=Ingress of Hardness|>

vector -> number

---

Returns the hardness of the block at the given position.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:can_place_block,title=Ingress of Suitability|>

vector, [block] -> boolean

---

Returns whether the given block can be placed at the given position. If no block is given, returns whether the position is replaceable.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_redstone_power,title=Ingress of Logic|>

vector -> number

---

Returns the redstone power level inputted into the given block position.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:check_resonator,title=Ingress of Resonance|>

vector -> number

---

Returns the power level of the [Spell Resonator](^trickster:items/spell_resonator) at the given position.


;;;;;

<|glyph@trickster:templates|trick-id=trickster:light_level,title=Ingress of Luminance|>

vector, [boolean] -> number

---

Returns the light level at the given position. 
A boolean can be specified to check only sky light (if true) or block light (if false).
