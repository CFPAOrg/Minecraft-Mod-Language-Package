```json
{
  "title": "Colors",
  "icon": "minecraft:cyan_dye",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "Pigment Ingress",
    "Vibrant Ingress"
  ]
}
```

*"I kept a bullet in the chamber for a rainy day."*


*"But what's the point in planning for it anyway?"*


*"I've got too many colors for a shade of gray."*


*"And I can make it autumn every single day."*

;;;;;

These tricks give access to color information.
Color fragments can represent any color along with translucency. 


They are {#aa4444}Addable{}, {#aa4444}Multiplicable{}, {#aa4444}Roundable{}, and {#aa4444}Averageable{}, but not {#aa4444}Subtractable{} or {#aa4444}Divisible{}

;;;;;

Addition mixes colors through an operation known as "screen."


Multiplication simply mixes multiplicatively.


Averaging mixes colors as one would with leather equipment.


Flooring and ceiling a color coerces it to the nearest result of Pigment and Vibrant Ingress, respectively. Rounding coerces to the nearest of either.

;;;;;

<|trick@trickster:templates|trick-id=trickster:item_to_color|>

;;;;;

Given a dye item type, returns the color that the dye applies to leather armor.


Given glass, returns a fully transparent color.


Given a vector, gets the color that has been imbued into the magical block at that position.

;;;;;

<|trick@trickster:templates|trick-id=trickster:item_to_glow_color|>

;;;;;

Functions identically, except for the case of dye item types. 
The colors produced are much more intense, similar to the result of mixing glow ink with the dye.
