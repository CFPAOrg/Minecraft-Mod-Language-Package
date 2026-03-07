```json
{
  "title": "Entity Party Tricks",
  "icon": "minecraft:pig_spawn_egg",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "Partner Ingress",
    "Passion Ploy",
    "Descend Ploy",
    "Memento’s Ingress",
    "Temporal Ploy",
    "Pinocchio's Ingress",
    "Cleo's Ploy",
    "Mr. Jollyboy's Ploy"
    ]
}
```

Additional tricks related to entities added by Party Trick.

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_vehicle|>

Returns the given entity's vehicle or void if it's not riding anything.

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:ride_entity,cost=20G + 1.35G^distance|>

Causes the first given entity to ride the second entity, returning the rider entity. With the mana cost scaling based on distance between them.

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:dismount_entity,cost=1G * distance^2|>

Causes the given entity to dismount their vehicle, with some entities keep their momentum when dismounted.

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_breeding_age|>

Returns the breeding age of the given animal in ticks. When the breeding age is below 0 they are a child and above 0 on cooldown.

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:add_breeding_age,cost=1G * amount^2|>

Adds an amount of ticks to the given animals breeding age. Cost stacks the same as [Kinetic Ploy](^trickster:ploys/entity#3).

;;;;;

<|page-title@lavender:book_components|title=Note: Armor Stands|>By infusing armor stands with mana their properties can be changed. 
Properties are indexed in the order seen on the next page. With vectors representing Euler angles, rotation being in degrees, and scale being much more limited than [Ploy of Occupation](^trickster:ploys/entity#5).

;;;;;


0. {#aa7711}Head{}
1. {#aa7711}Body{}
2. {#aa7711}Left Arm{}
3. {#aa7711}Right Arm{}
4. {#aa7711}Left Leg{}
5. {#aa7711}Right Leg{}
6. {#ddaa00}Rotation{}
7. {#ddaa00}Permanent Scale{}
8. {#aa3355}No Gravity{} 
9. {#aa3355}No Base Plate{}
10. {#aa3355}Invisible{}
11. {#aa3355}Show Arms{}
12. {#aa3355}Small{}
13. {#aa3355}Name Visible{}
14. {#aa3355}Protected{}

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_armor_stand_state|>

Returns the given armor stand's value for the property at the given index.


Next ploy sets it instead →

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:set_armor_stand_state,cost=1G|>

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:move_armor_stand,cost=distance^2 * 1G|>

Moves the given armor stand or other decorative entities by the given vector. Trying to move anything that isn't a valid entity with this will result in a blunder.