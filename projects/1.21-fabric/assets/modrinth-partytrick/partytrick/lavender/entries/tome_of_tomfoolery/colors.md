```json
{
  "title": "Colors ",
  "icon": "minecraft:white_dye",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "Illumination Ploy",
    "Radiance Ploy",
    "Painter's Ploy",
    "Eye Dropper's Ingress",
    "Designer's Distortion"
  ]
}
```

Color can be used in two ways, either a dye item or vector that represents the red, green and blue with values from 0 to 255.

Added by Party Trick.

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:change_color,cost=40G * amount|>

Changes the color of the given block, slot or entity.

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_color|>

Returns a color if available.

;;;;;

<|trick@trickster:templates|trick-id=partytrick:dye_to_vector|>

Returns the rgb vector associated with the given dye.

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:conjure_colored_light,cost=20G|>

Conjures a permanent light source at the given position. Optionally a color can be provided using a color vector.

;;;;;

<|trick@trickster:templates|trick-id=partytrick:light_particle|>

Conjures a light particle at the given position. Optionally a velocity and color vector can be provided.