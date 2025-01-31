```json
{
  "title": "Flecks",
  "icon": "minecraft:ghast_tear",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "Marketer's Ploy",
    "Artist's Ploy"
  ]
}
```

*In this world,*

*I wander.*


*In our minds,*

*I carve.*


*In their eyes,*

*I behold,*


*A beauty so fine,*

*It cannot be held.*


-- Oapheli

;;;;;

Flecks are a method of displaying data to select players. 
They last for a mere second, needing to be continuously refreshed.


All fleck-creating tricks take an identifying number, which may be used by any caster to update and overwrite the fleck. 
The number is returned for chaining. 
All flecks can also take an optional list of players, or a sole player, for which the fleck will display only to them.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:draw_spell,title=Marketer's Ploy|>

number, vector, vector, spell, [entity[] | entity] -> number

---

At the given position, with the given facing, display the given spell.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:draw_line,title=Artist's Ploy|>

number, vector, vector, [entity[] | entity] -> number

---

Draws a line between the given positions.
