```json
{
  "title": "Entity Ploys",
  "icon": "minecraft:sheep_spawn_egg",
  "category": "trickster:ploys"
}
```

Various tricks related to manipulating entities.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:add_velocity,title=Impulse Ploy|>

entity, vector -> entity

<|cost-rule@trickster:templates|formula=3kG + length^3 * 2kG|>

Applies the given vector as velocity to the given entity.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:polymorph,title=Polymorph Ploy|>

entity, entity ->

<|cost-rule@trickster:templates|formula=8000kG|>

Polymorphs the first entity to appear to be the second in every way. Only works with players.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:dispel_polymorph,title=Dispel Polymorph Ploy|>

entity -> entity

<|cost-rule@trickster:templates|formula=1000kG|>

Dispels any polymorph on the given entity.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:store_entity,title=Containment Ploy|>

entity ->

<|cost-rule@trickster:templates|formula=2000kG + distance ^ (distance / 5kG)|>

Stores the given entity in the caster's offhand item. 
The item must support entity storage, and the entity must not be a player.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:release_entity,title=Extrication Ploy|>

vector -> entity | void

<|cost-rule@trickster:templates|formula=2000kG + distance ^ (distance / 5kG)|>

Releases the entity stored in the caster's offhand item to the given position, returning it. 
Returns void if there is no entity.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:set_scale,title=Ploy of Occupation|>

entity, number -> entity

<|cost-rule@trickster:templates|formula=abs(currentScale - newScale)^2 * 100kG + newScale * 50kG|>

Changes the scale of the given entity. Entities cannot be scaled below 0.0625 or above 8 times their usual size.
