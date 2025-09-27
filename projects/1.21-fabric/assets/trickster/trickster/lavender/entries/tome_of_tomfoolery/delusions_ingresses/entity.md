```json
{
  "title": "Entity Querying",
  "icon": "minecraft:cow_spawn_egg",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "Motive Verification Ingress",
    "Locational Ingress",
    "Perspective Ingress",
    "Directional Ingress",
    "Movement Ingress",
    "Stature Ingress",
    "Alternative Ingress",
    "Hearth's Ingress",
    "Trekking Ingress",
    "Guard Ingress",
    "Vigor Ingress",
    "Fettle Ingress",
    "Bulwark Ingress",
    "Ingress of Occupation",
    "Observer's Ingress",
    "Ingress of Appetite",
    "Ingress of Fulfilment"
  ]
}
```

This collection of tricks provides options to gather information from entities in the world.


These tricks will blunder if their target is not being observed.


Keep in mind that entity fragments may [decay](^trickster:concepts/fragment_decay).

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_entity_type|>

Given an entity, returns its type.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_position|>

Given an entity, returns the position of its feet.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_eye_position|>

Given an entity, returns the position of its head.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_facing|>

Given an entity, returns the facing of its head as a unit vector.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_velocity|>

Given an entity, returns its current velocity as a vector in blocks per tick.

;;;;;

<|trick@trickster:templates|trick-id=trickster:height_reflection|>

Given an entity, returns its height in blocks.

;;;;;

<|trick@trickster:templates|trick-id=trickster:sneaking_reflection|>

Given an entity, returns whether the entity is crouching. 
If the entity is unable to crouch, false will always be given.

;;;;;

<|trick@trickster:templates|trick-id=trickster:burning_reflection|>

Given an entity, returns whether the entity is on fire.

;;;;;

<|trick@trickster:templates|trick-id=trickster:sprinting_reflection|>

Given an entity, returns whether the entity is sprinting.
If the entity is incapable of sprinting, false will always be given.

;;;;;

<|trick@trickster:templates|trick-id=trickster:blocking_reflection|>

Given an entity, returns whether the entity is blocking using a shield.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_max_health|>

Given an entity, returns its maximum health.
Blunders if the entity does not have health.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_health|>

Given an entity, returns its current health.
Blunders if the entity does not have health.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_armour|>

Given an entity, returns its total armor value.
Blunders if the entity cannot have armor.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_scale|>

Returns the scale of the given entity.
Blunders if the entity cannot scale.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_flecks|>

Returns the identifiers of all the flecks the given player can see.
If no player is supplied, the caster is queried for this information instead.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_player_food|>

Given a player, returns their current food level.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_player_saturation|>

Given a player, returns their current saturation.
