```json
{
  "title": "Entity Ploys",
  "icon": "minecraft:sheep_spawn_egg",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "Kinetic Ploy",
    "Ploy of Featherweight",
    "Ploy of the Usurper",
    "Polymorph Ploy",
    "Dispel Polymorph Ploy",
    "Containment Ploy",
    "Extrication Ploy",
    "Ploy of Occupation"
  ]
}
```

*"You've read up on the Manton Effect before, I expect? It's a weird one."*


*"No one is quite sure why these limitations exist as they are, or if we just haven't found the right methods yet.
Regardless, one must keep them in mind at all times."*


-- An excerpt from a lecture by Prof. Olivine.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:change_weight,cost=10G + 30G * (1 - multiplier)|>

Given a number between zero and one, multiplies the given entity's effective gravity by that number for one second, provided it is alive.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:add_velocity,cost=3G + length^3 * 2G|>

Applies the given vector as velocity to the given entity.

;;;;;

Cost scaling on Kinetic Ploy is *very* aggressive.
Additional casts of the ploy within the same 1/20th of a second will incur 
the cost *as if* it was cast with **the added length of both casts** in one go.


Because of the cubic scaling of cost on this ploy, this is very likely to be undesirable.
Consider using [Deviation of Suspension](^trickster:tricks/functions#3) 
to delay the next cast before stacking it where possible.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:set_scale,cost=abs(currentScale - newScale)^2 * 100G + newScale * 50G|>

Changes the scale of the given entity. Entities cannot be scaled below 0.0625 or above 8 times their usual size.

;;;;;

Entities scaled in this way will slowly revert back to their original scale over time, 
unless the ploy is recast periodically.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:displace,cost=20G + 1.35G^length|>

Displaces the given entity by the given vector after two seconds. 
This ploy has the same aggressive and stacking cost scaling as Kinetic Ploy.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:polymorph,cost=8000G|>

Changes the first entity's appearance to match the second, returning the first.
Both entities must be players.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:dispel_polymorph,cost=1000G|>

Dispels any polymorph applied to the given entity.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:store_entity,cost=2000G + 1G * distance ^ (distance / 5)|>

Stores the given entity in the caster's [Hat](^trickster:items/top_hat). 
The hat must be held in the caster's offhand, and the entity must not be a player.

;;;;;

Some entities cannot be stored into a hat, usually because they are too large.
Trying to store such entities will result in a blunder.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:release_entity,cost=2000G + 1G * distance ^ (distance / 5)|>

Releases the entity stored in the caster's [Hat](^trickster:items/top_hat) to the given position, returning a reference to it.
Returns void if there is no entity to release.
