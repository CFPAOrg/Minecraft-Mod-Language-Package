```json
{
  "title": "Colors",
  "icon": "minecraft:white_dye",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "Ploy of Contrast",
    "Painter's Ploy",
    "Eye Dropper's Ingress"
  ]
}
```

Color can be used in two ways, either a dye item or vector that represents the red, green and blue with values from 0 to 255.

Added by Party Trick

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:glow,cost=1G * distance^3|>

Makes an entity glow for 5 seconds. When no color is provided, the glow vanishes. Optionally, a list of effected viewers can be given.

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:change_dye_color,cost=40G * amount|>

Changes the color of the given block, slot or entity.

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_dye_color|>

Returns a color if available.