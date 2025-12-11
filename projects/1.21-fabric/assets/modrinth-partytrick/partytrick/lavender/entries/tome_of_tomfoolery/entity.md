```json
{
  "title": "Entity Party Tricks",
  "icon": "minecraft:pig_spawn_egg",
  "category": "trickster:tricks",
  "additional_search_terms": [
    ]
}
```

Additional tricks related to entities added by Party Trick.

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_vehicle|>

Returns the given entity's vehicle or void if it's not riding anything.

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:ride_entity,cost=20G + 1.35G^distance|>

Causes the first given entity to ride the second entity. With the mana cost scaling based on distance between them.

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:dismount_entity,cost=distance^2 * 1G|>

Causes the given entity to dismount their vehicle. Some entities keep their momentum when dismounted.

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_breeding_age|>

Returns the breeding age of the given animal in ticks. When the breeding age is below 0 they are a child and above 0 on cooldown.

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:add_breeding_age,cost=amount^2 * 1G|>

Adds an amount of ticks to the given animals breeding age. Cost stacks the same as [Kinetic Ploy](^trickster:ploys/entity#3).