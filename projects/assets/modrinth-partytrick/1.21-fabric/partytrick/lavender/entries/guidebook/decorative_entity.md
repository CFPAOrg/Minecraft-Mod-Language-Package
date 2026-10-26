```json
{
  "title": "Decorative Entities",
  "icon": "minecraft:armor_stand",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "Pinocchio's Ingress",
    "Cleo's Ploy",
    "Mr. Jollyboy's Ploy"
    ]
}
```

Tricks added by Party Trick for manipulating decorative entities like armor stands, item frames, and paintings.   

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:move_decorative_entity,cost=length^2 * 0.5G|>

Moves the given decorative entity by the given vector. Cost compounds the same way as [Kinetic Ploy](^trickster:ploys/entity#3). Trying to move a non-decorative entity will blunder.

;;;;;

<|page-title@lavender:book_components|title=Note: Properties|>Some properties of decorative entities can be altered directly. Every property is represented by a pattern, a combination of which can be used to affected multiple properties at once, in the listed order.


Vectors represent Euler angles, rotation is in radians, and scale is more restrictive than [Ploy of Occupation](^trickster:ploys/entity#5).

;;;;;

<|pattern@partytrick:templates|pattern=41|>  {#aa7711}Head{}
<|pattern@partytrick:templates|pattern=47|>  {#aa7711}Body{}
<|pattern@partytrick:templates|pattern=40|>  {#aa7711}Left Arm{}
<|pattern@partytrick:templates|pattern=42|>  {#aa7711}Right Arm{}
<|pattern@partytrick:templates|pattern=76|>  {#aa7711}Left Leg{}
<|pattern@partytrick:templates|pattern=78|>  {#aa7711}Right Leg{}
<|pattern@partytrick:templates|pattern=63452|>  {#ddaa00}Rotation{}
<|pattern@partytrick:templates|pattern=072|>  {#ddaa00}Permanent Scale{}
<|pattern@partytrick:templates|pattern=375|>  {#aa3355}Small{}
<|pattern@partytrick:templates|pattern=06482|>  {#aa3355}Arms{}
<|pattern@partytrick:templates|pattern=68|>  {#aa3355}Base Plate{}
<|pattern@partytrick:templates|pattern=3273|>  {#aa3355}Visible{}
<|pattern@partytrick:templates|pattern=610218|>  {#aa3355}Gravity{}
<|pattern@partytrick:templates|pattern=6301258|>  {#aa3355}Protected{}
<|pattern@partytrick:templates|pattern=05830|>  {#aa3355}Name Visible{}

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_decorative_entity_property|>

Returns the property values for the given decorative entity and properties pattern.

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:set_decorative_entity_property,cost=1G|>

Changes a given decorative entity's properties based on the given properties pattern and inputs. 
