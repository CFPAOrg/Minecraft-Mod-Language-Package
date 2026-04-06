```json
{
  "title": "Inventory Manipulation",
  "icon": "minecraft:chest",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "Ploy of Offering",
    "Swindler's Ploy",
    "Cranial Shift Ploy"
  ]
}
```

Listed here are ploys that interact with inventory slots or other inventory features.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:drop_stack_from_slot,title=Ploy of Offering|>

slot, vector, [number] -> entity

---

Drops items from the given slot at a position, returning their entity. Optionally, an amount can be specified.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:swap_slot,title=Swindler's Ploy|>

slot, slot ->

---

Swaps the item stacks within the given slots.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:set_hat,title=Cranial Shift Ploy|>

number -> boolean

---

Sets the selected slot in the caster's [Top Hat](^trickster:items/top_hat), returning a boolean based on success.
