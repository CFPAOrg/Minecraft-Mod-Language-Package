```json
{
  "title": "Raycasting",
  "icon": "minecraft:spectral_arrow",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "Pinpoint Ingress",
    "Bearing Ingress",
    "Mark Ingress"
  ]
}
```

Raycasting tricks take either an entity or a position and a direction, and will give what the entity is looking at, 
or what the vectors are pointing to.


When using vectors, the first vector is interpreted as the position to start from, 
while the second is seen as a unit vector representing the look direction.

;;;;;

Raycasts which target blocks may optionally be made to hit fluids if their last argument is true.


If a raycast misses and does not hit anything of relevance within 64 blocks, void will be given.

;;;;;

<|trick@trickster:templates|trick-id=trickster:raycast|>

Returns the position of the block that is hit.

;;;;;

<|trick@trickster:templates|trick-id=trickster:raycast_entity|>

Returns the entity that is hit.

;;;;;

<|trick@trickster:templates|trick-id=trickster:raycast_side|>

;;;;;

Returns a unit vector representing the side of the block that is hit.
