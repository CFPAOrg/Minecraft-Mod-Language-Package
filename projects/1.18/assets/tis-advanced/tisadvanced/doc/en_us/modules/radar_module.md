# Radar Module

![Sometimes it's better to know what's coming before it hits you.](item:tisadvanced:radar_module)

The radar module can be used to detect and record information about nearby entities. Write operations control the module settings, and read operations return data about the target entity. The module settings are described below:

Bit 0: If the most significant bit is set, subsequent read operations will target entities starting with the furthest entity away from the radar module, rather than the closest. See the index parameter below for more information.

Bits 1-2: Bits 1 & 2 represent the axis from which the offset between the entity and radar module will be calculated. 0 is a special value that will return the straight-line distance between the target entity and the radar. Setting this value to 1 will cause read operations to return the difference in X coordinate between the radar and target. Setting this value to 2 or 3 will cause read operations to return the difference in Y and Z coordinates, respectively.

Bits 3-15: The remaining bits correspond to the index of the target entity. Setting this parameter to zero will set the target entity to be the closest entity to the radar module (or furthest if bit 0 is set). Setting this parameter to 1 or more will set the target entity to the n-th closest (or furthest) entity relative to the radar module.

Additionally, by holding and right-clicking (or shift-right-clicking) the radar module, the entity type filter can be controlled. Below are the available filters:

- NONE: This filter matches all entities.
- PLAYER: This filter matches players.
- ANIMAL: This filter matches wild and livestock animals, pets, bees, striders, axolotls, bats, etc.
- GOLEM: This filter matches iron and snow golems.
- MONSTER: This filter matches hostile mobs and boss mobs.
- VEHICLE: This filter matches boats and minecarts.
- PROJ: This filter matches projectiles such as arrows and fire charges.
- ITEM: This filter matches dropped items.
- BLOCK: This filter matches entities with corresponding blocks, such as falling sand and primed TNT.
- OTHER: This is a catch-all filter that matches all entities not matched by any above filter.

The indicator light in the top right corner of the module's indicates if any entities matching the configured filter were found in the last scan attempt. If the light is green, matching entities were found. If the light is red, no matching entities were found.
