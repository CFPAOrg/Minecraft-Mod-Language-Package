```json
{
  "title": "The Drifter",
  "icon": "minecraft:ender_pearl"
}
```

*"They tell stories of it, you know.*


*They say it can walk through walls, 
that it can make you disappear without a trace.*


*They say this to their children. It's amusing to them. They don't think it's real.*


*But I met it once. And let me tell you, it's real. And if you met it too, you'd wish it wasn't."*


— An anonymous interviewee

;;;;;

#<trickster:image texture="trickster:textures/gui/img/opened_eye.png" width="124" height="60" center-vertically="true" />

;;;;;

#<trickster:trick id="trickster:prepare_displace" cost="120G + 1.35G^distance" />

Creates a temporary displacement fragment from an entity.
These fragments can only be used for five seconds after creation.

;;;;;

#<trickster:trick id="trickster:displace" cost="20G + 1.35G^offset + distance * 3G" />

Consumes a displacement fragment to teleport its entity to the given position relative to the caster.
If the entity is not the caster, a delay is applied.

;;;;;

A couple caveats of note:


Distance for displacement is calculated from the subjects current position to the casters,
and an additional cost of 1000 gandalfs will be added if they are in different dimensions.


Only three displacements can be created for any given entity per five seconds, 
each of which can only be used once before becoming invalid.

;;;;;

#<trickster:trick id="trickster:get_displacements" />

Given an entity, returns the amount of displacements it has immediately available.

;;;;;

#<trickster:trick id="trickster:get_position" />

Given a displacement fragment, returns the position of its entity.

;;;;;

#<trickster:trick id="trickster:get_dimension" />

Returns the dimension that a displacement fragment came from.
