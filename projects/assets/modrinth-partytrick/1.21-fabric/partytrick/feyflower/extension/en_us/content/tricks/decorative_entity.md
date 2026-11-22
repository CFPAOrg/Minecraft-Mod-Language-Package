```json
{
  "title": "Decorative Entities",
  "icon": "minecraft:armor_stand"
}
```

Tricks added by Party Trick for manipulating decorative entities like armor stands, item frames, and paintings.   

;;;;;

#<trickster:trick id="partytrick:move_decorative_entity" cost="length^2 * 0.5G" />

Moves the given decorative entity by the given vector. Cost compounds the same way as [Kinetic Ploy](*trickster:tricks/ploys/entity@trick&trickster:add_velocity). Trying to move a non-decorative entity will blunder.

;;;;;

#<trickster:note title="Properties" />

Some properties of decorative entities can be altered directly. Every property is represented by a pattern, a combination of which can be used to affected multiple properties at once, in the listed order.


Vectors represent Euler angles, rotation is in radians, and scale is more restrictive than [Ploy of Occupation](*trickster:tricks/ploys/entity@trick&trickster:set_scale).

;;;;;

<partytrick:pattern pattern="41" />  {#aa7711}Head{}
<partytrick:pattern pattern="47" />  {#aa7711}Body{}
<partytrick:pattern pattern="40" />  {#aa7711}Left Arm{}
<partytrick:pattern pattern="42" />  {#aa7711}Right Arm{}
<partytrick:pattern pattern="76" />  {#aa7711}Left Leg{}
<partytrick:pattern pattern="78" />  {#aa7711}Right Leg{}
<partytrick:pattern pattern="63452" />  {#ddaa00}Rotation{}
<partytrick:pattern pattern="072" />  {#ddaa00}Permanent Scale{}
<partytrick:pattern pattern="375" />  {#aa3355}Small{}
<partytrick:pattern pattern="06482" />  {#aa3355}Arms{}
<partytrick:pattern pattern="68" />  {#aa3355}Base Plate{}
<partytrick:pattern pattern="3273" />  {#aa3355}Visible{}
<partytrick:pattern pattern="610218" />  {#aa3355}Gravity{}
<partytrick:pattern pattern="6301258" />  {#aa3355}Protected{}
<partytrick:pattern pattern="05830" />  {#aa3355}Name Visible{}

;;;;;

#<trickster:trick id="partytrick:get_decorative_entity_property" />

Returns the property values for the given decorative entity and properties pattern.

;;;;;

#<trickster:trick id="partytrick:set_decorative_entity_property" cost="1G" />

Changes a given decorative entity's properties based on the given properties pattern and inputs. 
