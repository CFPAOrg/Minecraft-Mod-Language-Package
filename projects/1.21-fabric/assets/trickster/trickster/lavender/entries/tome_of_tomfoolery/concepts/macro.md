```json
{
  "title": "Macros",
  "icon": "trickster:macro_ring",
  "category": "trickster:concepts"
}
```

Macros allow you to create your own revisions to aid with spell scribing. 


A [map](^trickster:distortions/map) that links a set of patterns to a set of spells is used to define macros.
These maps, when inscribed into any ring and worn in a ring slot, will be checked for keys matching any drawn patterns.

;;;;;

A simple [Macro Ring](^trickster:items/ring) can be used for this purpose if no other rings are available.


If a macro for a drawn pattern is found, the associated spell will be cast and given one argument:
A copy of the circle it is drawn in. 
The spell is then expected to return a new spell fragment to replace the fragment given.


This effectively lets anyone create their own set of revisions.

;;;;;

Note: Macro spells are not capable of [long casting](^trickster:concepts/multi_tick). 
This means they do not take a spell slot, but also can't run more than about 64 circles.
