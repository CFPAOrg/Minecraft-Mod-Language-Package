```json
{
  "title": "Macros",
  "icon": "trickster:macro_ring"
}
```

Macros allow a caster to create their own additional revisions to aid with spell scribing. 


A [map](*trickster:tricks/distortions_stratagems/map) that links a set of patterns to a set of spells is used to define macros.
These maps, when inscribed into any ring and worn in a ring slot, will be checked for keys matching any drawn patterns.


A simple [Macro Ring](*trickster:items/writing_casting/ring) can be used for this purpose if no other rings are available.

;;;;;

If a macro for a drawn pattern is found, the associated spell will be cast and given one [argument](*trickster:tricks/delusions_ingresses/arguments):
A copy of the circle it is drawn in. 
The spell is then expected to return a new spell fragment to replace the fragment given.


When making the map, a [pattern literal](*trickster:editing@revision&trickster:quote_pattern) can be used to provide a pattern.
