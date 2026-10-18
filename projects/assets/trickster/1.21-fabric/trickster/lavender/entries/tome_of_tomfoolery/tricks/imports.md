```json
{
  "title": "Reusability",
  "icon": "trickster:top_hat",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "Assistance Deviation",
    "Cranium Deviation"
  ]
}
```

Multiple patterns exist for easy reusability of spell fragments stored in the caster's inventory.


These directly execute spells stored in items with given arguments, 
which can potentially return fragments back to the calling spell,
or have other side effects.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:import,title=Assistance Deviation|>

item, any... -> any

---

Searches the caster's inventory for a specific item.
The first item found with an inscribed spell will be cast with the provided arguments.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:import_hat,title=Cranium Deviation|>

number, any... -> any

---

Grabs the spell from the specified slot in the caster's [Top Hat](^trickster:items/top_hat), casts it with the provided arguments, and returns the result.
