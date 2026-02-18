```json
{
  "title": "Basic Tricks",
  "icon": "minecraft:bricks",
  "category": "trickster:tricks",
  "ordinal": 0,
  "additional_search_terms": [
    "Notulist's Ingress",
    "Notulist's Ploy",
    "Proprietary Notulist's Ploy",
    "Alethophobe's Ploy",
    "Showcase Ploy",
    "Crow Mind Delusion",
    "Crow Mind Ploy"
  ]
}
```

*"The foundations are arguably the most important part of any skillset. 
There is no shame in revisiting them every now and then."*


-- An excerpt from a lecture by Prof. Olivine.

;;;;;

<|page-title@lavender:book_components|title=Note: Inscribed Fragments|>A fragment can be inscribed onto any item that a player can hold in their inventory.
If inscribed on a block, the fragment will be removed if the block is placed.


Some items may have additional interactions when inscribed with fragments, 
[Wands](^trickster:items/wand) for example will cast a spell fragment when right-clicked.

;;;;;

<|trick@trickster:templates|trick-id=trickster:read_spell|>

Reads the fragment from the item in the given slot, or in the caster's offhand if no slot is given.
Returns void if no fragment is inscribed.

;;;;;

<|trick@trickster:templates|trick-id=trickster:write_spell|>

Inscribes a fragment onto the item in the given slot, or in the caster's offhand if no slot is given.
Returns its input, after [decay](^trickster:concepts/fragment_decay).

;;;;;

<|trick@trickster:templates|trick-id=trickster:write_closed_spell|>

Same as Notulist's Ploy, but the fragment cannot be read by conventional means.

;;;;;

<|trick@trickster:templates|trick-id=trickster:clear_spell|>

Clears any inscribed fragment from the item in the given slot, or in the caster's offhand if no slot is given.

;;;;;

<|trick@trickster:templates|trick-id=trickster:reveal|>

Shows all given values as a chat message to the caster and returns the first.

;;;;;

<|trick@trickster:templates|trick-id=trickster:reveal_action_bar|>

Shows all given values above the caster's hotbar and returns the first. Clears the message when no inputs are provided.

;;;;;

<|page-title@lavender:book_components|title=Note: The Crow Mind|>The Crow Mind, not to be confused with other black bird related minds, 
lets spells store and retrieve any one fragment, **persistently**, between casts.


This can be used for many things, such as counters, 
marking locations, and selecting targets.

;;;;;

<|trick@trickster:templates|trick-id=trickster:read_crow_mind|>

Returns the value currently stored in the caster's crow mind.

;;;;;

<|trick@trickster:templates|trick-id=trickster:write_crow_mind|>

Stores the supplied value in the caster's Crow Mind, overwriting any value that might already be present.
