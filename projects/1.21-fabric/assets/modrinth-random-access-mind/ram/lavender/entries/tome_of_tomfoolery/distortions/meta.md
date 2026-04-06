```json
{
  "title": "Meta Additions",
  "icon": "minecraft:loom",
  "category": "trickster:distortions"
}
```

Included herein are a handful of tricks useful for manipulating spells in the ways available from the [Spell Manipulation](^trickster:distortions/tree) chapter.

;;;;;

<|glyph@trickster:templates|trick-id=ram:pattern_as_int,title=Distortion of Compression|>

pattern -> number

---

Compresses the given pattern into a number.

;;;;;

<|glyph@trickster:templates|trick-id=ram:pattern_from_int,title=Distortion of Expansion|>

number -> pattern

---

Expands the given number into a pattern.

;;;;;

<|glyph@trickster:templates|trick-id=ram:pattern_from_int_list,title=Distortion of Composition|>

number[] | number... -> pattern

---

Constructs a pattern from the given grid positions.

;;;;;

<|glyph@trickster:templates|trick-id=ram:glyph_from_spell_part,title=Distortion of Baring|>

spell -> any

---

Returns the glyph of the root of the given spell.