```json
{
  "title": "Entity Targeting",
  "icon": "minecraft:chicken_spawn_egg",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "Embracing Ingress",
    "Ingress of Shared Fate"
  ]
}
```

These tricks may help to find and target entities in the world. 
Both of them may be optionally restricted to certain entity types by providing either a set of individual types, or a list.


They may give nothing when the position they target is not being observed.


Keep in mind that entity fragments may [decay](^trickster:concepts/fragment_decay).

;;;;;

<|trick@trickster:templates|trick-id=trickster:block_find_entity|>

Finds and returns an entity at a specific block position.

;;;;;

<|trick@trickster:templates|trick-id=trickster:range_find_entity|>

Finds and returns a list of all entities in the provided range around a specific block position.
