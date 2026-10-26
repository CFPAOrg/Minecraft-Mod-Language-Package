```json
{
  "title": "Flecks",
  "icon": "minecraft:ghast_tear",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "Marketer's Ploy",
    "Swift Marketer's Ploy",
    "Observant Marketer's Ploy",
    "Artist's Ploy",
    "Orwell's Ploy"
  ]
}
```

*"In this world,*

*I wander.*


*In our minds,*

*I carve.*


*In their eyes,*

*I behold,*


*A beauty so fine,*

*It cannot be held."*


— Oapheli

;;;;;

Flecks are a method of displaying data to select observers. 
They last for a mere second, needing to be continuously refreshed.


All fleck-creating tricks take an identifying number, which may be used by any caster to update and overwrite the fleck. 
The number is returned for chaining. 
All flecks can also take an optional list of players, or a sole player, for which the fleck will display only to them.

;;;;;

<|trick@trickster:templates|trick-id=trickster:draw_spell|>

At the given position, with the given facing, display a spell.

;;;;;

<|trick@trickster:templates|trick-id=trickster:entity_draw_spell|>

Displays a spell similarly to Marketer's Ploy, but attached to an entity.

;;;;;

<|trick@trickster:templates|trick-id=trickster:entity_head_draw_spell|>

Displays a spell, but attached to an entity's *head*.

;;;;;

<|trick@trickster:templates|trick-id=trickster:draw_line|>

Draws a line between the given positions.

;;;;;

<|trick@trickster:templates|trick-id=trickster:scale_fleck|>

Scales an existing fleck.

;;;;;

<|trick@trickster:templates|trick-id=trickster:roll_fleck|>

Changes the rotation of the fleck about its facing direction.
Only has an effect on flecks drawn with [Marketer's Ploy](^trickster:ploys/flecks#2).

;;;;;

<|trick@trickster:templates|trick-id=trickster:delete_fleck|>

Removes any fleck with the given identifier.

;;;;;

<|trick@trickster:templates|trick-id=trickster:paint|>

Paints the fleck with the given color. Only works on line flecks.
