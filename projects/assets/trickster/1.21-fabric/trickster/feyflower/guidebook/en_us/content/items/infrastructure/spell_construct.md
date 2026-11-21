```json
{
  "title": "Spell Construct",
  "icon": "trickster:spell_construct",
  "ordinal": 10,
  "associated_items": [
    "trickster:spell_construct"
  ]
}
```

A Spell Construct is a relatively simple device that, 
when inscribed with a spell and placed into the world, will persistently cast said spell at <trickster:cpt /> circles per tick.


Constructs are most useful for [long-running](*trickster:concepts/multi_tick) 
spells that respond to happenings in the world, or trigger periodically.

;;;;;

If a source of mana is required, any [Knot](*trickster:items/mana/knots) 
may be inserted into the center of the Construct with a right-click.
They may also be shift-right-clicked to reset the currently running spell, 
ignoring any previous blunders.

<feyflower:crafting id="trickster:spell_construct" />
