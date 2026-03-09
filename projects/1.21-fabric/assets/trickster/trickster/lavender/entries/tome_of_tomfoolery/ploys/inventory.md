```json
{
  "title": "Inventory Manipulation",
  "icon": "minecraft:chest",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "Ploy of Offering",
    "Organizer's Ploy",
    "Swindler's Ploy",
    "Cranial Shift Ploy"
  ]
}
```

*"Note that inventory ploys are heavily restricted in almost all jurisdictions."*


*"Not because they're very dangerous mind you, it's just that humans collectively have a strange obsession with this thing they call 'personal property.'"*


-- An excerpt from a lecture by Prof. Dr. Gerune.


Creating a slot reference comes at no cost. However, using the reference in a way that moves the items inside the slot will always have a cost of (distance * amount * 0.5G).

;;;;;

<|trick@trickster:templates|trick-id=trickster:drop_stack_from_slot|>

Drops items from the given slot at a position, returning their entity. Optionally, an amount can be specified.

;;;;;

<|trick@trickster:templates|trick-id=trickster:move_resource|>

Moves resources from one storage into another.

;;;;;

A number can be provided to limit the amount transferred, and a resource type or list of such can be provided as a filter.

;;;;;

<|trick@trickster:templates|trick-id=trickster:swap_slot|>

Swaps the resources within the given slots.

;;;;;

<|trick@trickster:templates|trick-id=trickster:set_hat|>

Sets the selected slot in the caster's [Hat](^trickster:items/top_hat), returning a boolean based on success.
