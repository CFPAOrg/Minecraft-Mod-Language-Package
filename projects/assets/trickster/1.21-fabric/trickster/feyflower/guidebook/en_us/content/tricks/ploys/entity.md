```json
{
  "title": "Entity Ploys",
  "icon": "minecraft:sheep_spawn_egg"
}
```

*"You've read up on the Manton Effect before, I expect? It's a weird one.*


*No one is quite sure why these limitations exist as they are, or if we just haven't found the right methods yet.
Regardless, one must keep them in mind at all times."*


— An excerpt from a lecture by Prof. Olivine

;;;;;

#<trickster:trick id="trickster:change_weight" cost="10G + 30G * (1 - multiplier)" />

Given a number between zero and one, multiplies the given entity's effective gravity by that number for one second, provided it is alive.

;;;;;

#<trickster:trick id="trickster:add_velocity" cost="3G + length^3 * 16G" />

Applies the given vector as velocity to the given entity.

;;;;;

Cost scaling on Kinetic Ploy is *very* aggressive.
Additional casts of the ploy within the same 1/20th of a second will incur 
the cost *as if* it was cast with **the added length of both casts** in one go.


Because of the cubic scaling of cost on this ploy, this is very likely to be undesirable.
Consider using [Deviation of Suspension](*trickster:tricks/functions@trick&trickster:delay_execution) 
to delay the next cast before stacking it where possible.

;;;;;

#<trickster:trick id="trickster:set_scale" cost="abs(currentScale - newScale)^2 * 100G + newScale * 50G" />

Changes the scale of the given entity. Entities cannot be scaled below 0.0625 or above 8 times their usual size.


Entities scaled in this way will slowly revert back to their original scale over time, 
unless the ploy is recast periodically.

;;;;;

#<trickster:trick id="trickster:polymorph" cost="8000G" />

Changes the first entity's appearance to match the second, returning the first.
Both entities must be players.

;;;;;

#<trickster:trick id="trickster:dispel_polymorph" cost="1000G" />

Dispels any polymorph applied to the given entity.

;;;;;

#<trickster:trick id="trickster:store_entity" cost="2000G + 1G * distance ^ (distance / 5)" />

Stores the given entity in the caster's [Hat](*trickster:items/writing_casting/hats). 
The hat must be held in the caster's offhand, and the entity must not be a player.

;;;;;

Some entities cannot be stored in a hat, usually because they are too large.
Trying to store such entities will result in a blunder.

;;;;;

#<trickster:trick id="trickster:release_entity" cost="2000G + 1G * distance ^ (distance / 5)" />

Releases the entity stored in the caster's [Hat](*trickster:items/writing_casting/hats) to the given position, returning a reference to it.
Returns void if there is no entity to release.
