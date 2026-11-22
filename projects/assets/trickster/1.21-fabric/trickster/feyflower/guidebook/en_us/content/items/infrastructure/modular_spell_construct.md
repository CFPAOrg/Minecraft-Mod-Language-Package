```json
{
  "title": "Modular Spell Construct",
  "icon": "trickster:modular_spell_construct",
  "ordinal": 20,
  "associated_items": [
    "trickster:modular_spell_construct"
  ]
}
```

A Modular Spell Construct, unlike the simple [Spell Construct](*trickster:items/infrastructure/spell_construct), does not execute the spell inscribed onto it. 
Instead, up to four [Spell Cores](*trickster:items/infrastructure/spell_core) may be inserted into the Construct's corner slots, where they will be executed concurrently. 
The Spell Cores draw mana from the [Knot](*trickster:items/mana/knots) placed in the Construct's center, and share the same [Crow Mind](*trickster:tricks/basic@note&The Crow Mind).

;;;;;

The multiple cores in this Construct type can access and delegate tasks to one
another using the same tricks as the ones used for player spell slot manipulation.
This lets advanced spell casters design persistent multithreaded spells.

<feyflower:crafting id="trickster:modular_spell_construct" />
