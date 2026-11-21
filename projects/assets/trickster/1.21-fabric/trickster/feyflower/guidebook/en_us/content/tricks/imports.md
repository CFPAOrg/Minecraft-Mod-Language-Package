```json
{
  "title": "Reusability",
  "icon": "trickster:top_hat",
  "ordinal": 20
}
```

Multiple tricks exist for easy reusability of spell fragments stored in the caster's inventory.


These directly execute spells stored in items with given [arguments](*trickster:tricks/delusions_ingresses/arguments), 
which can potentially return fragments back to the calling spell,
or have other side effects.

;;;;;

#<trickster:trick id="trickster:import" />

Searches the caster's inventory for a specific item type.
The first item of this type found to have an inscribed spell will be cast with the provided [arguments](*trickster:tricks/delusions_ingresses/arguments).

;;;;;

#<trickster:trick id="trickster:import_hat" />

Grabs the spell from the specified slot in the caster's [Hat](*trickster:items/writing_casting/hats), casts it with the provided [arguments](*trickster:tricks/delusions_ingresses/arguments), and returns the result.
