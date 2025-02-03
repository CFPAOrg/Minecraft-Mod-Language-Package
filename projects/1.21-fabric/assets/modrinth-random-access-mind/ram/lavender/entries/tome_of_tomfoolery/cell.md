```json
{
  "title": "World Cells",
  "icon": "minecraft:shulker_box",
  "category": "trickster:tricks"
}
```

Each world has within it a store where fragments may be cached indefinitely, accessible by all. 
Values may be written to each cell only once, but may be read from any amount of times by anyone with a valid reference.

;;;;;

<|glyph@trickster:templates|trick-id=ram:acquire_cell,title=Antiquarian's Ploy|>

-> cell

---

Acquires an empty cell from the world.

;;;;;

<|glyph@trickster:templates|trick-id=ram:read_cell,title=Archivist's Ingress|>

cell -> any

---

Returns the value contained within the cell.

;;;;;

<|glyph@trickster:templates|trick-id=ram:write_cell,title=Archivist's Ploy|>

cell, any -> cell

---

Writes the given value to the cell. This operation makes it *impossible* to ever write to the cell again.