```json
{
  "title": "Colorful Party Tricks",
  "icon": "minecraft:white_dye"
}
```

Additional color related tricks added by Party Trick.

;;;;;

#<trickster:trick id="partytrick:remove_dye_color" cost="40G * amount" />

Similar to [Ploy of Attrition](*trickster:tricks/ploys/block@trick&trickster:erode) takes a target and a source of water. Removes the color of the target. 

;;;;;

#<trickster:trick id="partytrick:set_dye_color" cost="40G * 'amount of dye used'" />

Changes the color of the given target to the dye inside the given slot, using the dye in the process.

;;;;;

#<trickster:trick id="partytrick:get_dye_color" />

Returns a dye based on the targets color if available.

;;;;;

#<trickster:trick id="partytrick:set_color" />

Sets the exact color of the given item. When no color is provided removes it instead.

;;;;;

#<trickster:trick id="partytrick:get_color" />

Returns the exact color of the given item or void if it has no exact color applied to it.

;;;;;

#<trickster:trick id="partytrick:glow" cost="1G * distance^3" />

Makes an entity glow for 5 seconds. When no color is provided, the glow vanishes. Optionally, a list of effected viewers can be given.