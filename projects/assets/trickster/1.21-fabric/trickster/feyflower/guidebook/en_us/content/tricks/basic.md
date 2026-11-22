```json
{
  "title": "Basic Tricks",
  "icon": "minecraft:bricks",
  "ordinal": 0
}
```

*"The foundations are arguably the most important part of any skillset. 
There is no shame in revisiting them every now and then."*


— An excerpt from a lecture by Prof. Olivine

;;;;;

#<trickster:note title="Inscribed Fragments" />

A fragment can be inscribed onto any item, with some being able to [trigger](*trickster:concepts/trigger_items) the inscribed spell. If inscribed on a block, the fragment will be removed if the block is placed.


Tricks related to reading and writing are limited to a range of 16 blocks.

;;;;;

#<trickster:trick id="trickster:read_spell" />

Reads the fragment from the item in the given slot, or in the caster's offhand if no slot is given.
Returns void if no fragment is inscribed.

;;;;;

#<trickster:trick id="trickster:write_spell" />

Inscribes a fragment onto the item in the given slot, or in the caster's offhand if no slot is given.
Returns its input, after [decay](*trickster:concepts/fragment_decay).

;;;;;

#<trickster:trick id="trickster:clear_spell" />

Clears any inscribed fragment from the item in the given slot, or in the caster's offhand if no slot is given.

;;;;;

#<trickster:trick id="trickster:reveal" />

Shows all given values as a chat message to the caster and returns the first.

;;;;;

#<trickster:trick id="trickster:reveal_action_bar" />

Shows all given values above the caster's hotbar and returns the first. Clears the message when no inputs are provided.

;;;;;

#<trickster:note title="The Crow Mind" />

The Crow Mind, not to be confused with other black bird related minds, 
lets spells store and retrieve any one fragment, **persistently**, between casts.


This can be used for many things, such as counters, 
marking locations, and selecting targets.

;;;;;

#<trickster:trick id="trickster:read_crow_mind" />

Returns the value currently stored in the caster's crow mind.

;;;;;

#<trickster:trick id="trickster:write_crow_mind" />

Stores the supplied value in the caster's Crow Mind, overwriting any value that might already be present.
