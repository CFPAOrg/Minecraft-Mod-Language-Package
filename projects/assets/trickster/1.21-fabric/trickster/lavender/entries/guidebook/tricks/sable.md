```json
{
  "title": "Detached Structures",
  "icon": "minecraft:compass",
  "category": "trickster:tricks",
  "ordinal": 100,
  "additional_search_terms": [
    "Aviator's Ingress",
    "Wayfinder's Ingress"
  ],
  "fabric:load_conditions": [
    {
      "condition": "fabric:any_mods_loaded",
      "values": [
        "sable"
      ]
    },
    {
      "condition": "fabric:not",
      "value": {
        "condition": "fabric:any_mods_loaded",
        "values": [
          "mage_mech"
        ]
      }
    }
  ]
}
```

Through unknown means, structures may be severed from the foundational grid of the world.


The positions of blocks within these "Detached Structures" are represented by vectors of enormous magnitude.

;;;;;

While such vectors are useful when trying to directly interact with the detached blocks, 
they are often unfit for other operations.


Documented here are Ingresses which transform vectors with respect to the actual position of a Detached Structure.

;;;;;

<|trick@trickster:templates|trick-id=trickster:project_position|>

Given a position within a Detached Structure, returns its actual position within the world.

;;;;;

<|trick@trickster:templates|trick-id=trickster:project_direction|>

Given a position within a Detached Structure, returns the second given vector rotated by the Structure's orientation.
