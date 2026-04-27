```json
{
  "title": "Colorful Party Tricks",
  "icon": "minecraft:white_dye",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "Ploy of Contrast",
    "Painter's Ploy",
    "Puritan’s Ploy",
    "Eye Dropper's Ingress",
    "Ploy of Dyestuffation",
    "Dyestuff Ingress"
  ]
}
```

Additional color related tricks added by Party Trick.

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:remove_dye_color,cost=40G * amount|>

Similar to [Ploy of Attrition](^trickster:ploys/block#13) takes a target and a source of water. Removes the color of the target. 

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:set_dye_color,cost=40G * "amount of dye used"|>

Changes the color of the given target to the dye inside the given slot, using the dye in the process.

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_dye_color|>

Returns a dye based on the targets color if available.

;;;;;

<|trick@trickster:templates|trick-id=partytrick:set_color|>

Sets the exact color of the given dyeable item. When no color is provided removes it instead.

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_color|>

Returns the exact color of the given dyeable item or void if it has no exact color applied to it.

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:glow,cost=1G * distance^3|>

Makes an entity glow for 5 seconds. When no color is provided, the glow vanishes. Optionally, a list of effected viewers can be given.