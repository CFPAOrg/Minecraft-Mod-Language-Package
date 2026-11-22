```json
{
  "title": "Entity Party Tricks",
  "icon": "minecraft:pig_spawn_egg"
}
```

Additional tricks related to entities added by Party Trick.

;;;;;

#<trickster:trick id="partytrick:get_vehicle" />

Returns the given entity's vehicle or void if it's not riding anything.

;;;;;

#<trickster:trick id="partytrick:ride_entity" cost="20G + 1.35G^distance" />

Causes the first given entity to ride the second entity, returning the rider entity. With the mana cost scaling based on distance between them.

;;;;;

#<trickster:trick id="partytrick:dismount_entity" cost="1G * distance^2" />

Causes the given entity to dismount their vehicle, with some entities keep their momentum when dismounted.

;;;;;

#<trickster:trick id="partytrick:get_breeding_age"/>

Returns the breeding age of the given animal in ticks. When the breeding age is below 0 they are a child and above 0 on cooldown.

;;;;;

#<trickster:trick id="partytrick:add_breeding_age" cost="1G * amount^2" />

Adds an amount of ticks to the given animals breeding age, with cost compounding the same way as [Kinetic Ploy](*trickster:tricks/ploys/entity@trick&trickster:add_velocity).

;;;;;

#<trickster:trick id="partytrick:summon_spit" cost="20G + 1G * distance ^ (distance / 3)" />

Extracts spit out of the given mob or caster when available. Distance is the distance between the spit source and given position.

;;;;;

#<trickster:trick id="partytrick:get_cooldown" />

Returns if the given player is temporally unable to use a given item.