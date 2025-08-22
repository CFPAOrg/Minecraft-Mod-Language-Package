```json
{
  "title": "Block Interaction",
  "icon": "minecraft:string",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "Ploy of Destruction",
    "Ploy of Creation",
    "Ploy of Exchange",
    "Ploy of Featherweight",
    "Ploy of Investiture",
    "Ploy of Divestiture",
    "Ploy of Attrition",
    "Floral Ploy",
    "Aquatic Ploy",
    "Illumination Ploy",
    "Resonance Ploy"
  ]
}
```

This entry contains tricks that operate directly on blocks in the world.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:break_block,title=Ploy of Destruction|>

vector -> vector

<|cost-rule@trickster:templates|formula=max(hardness * 1kG\, 8kG)|>

Breaks the block at the given position. 

;;;;;

<|glyph@trickster:templates|trick-id=trickster:place_block,title=Ploy of Creation|>

vector, slot, [vector, vector] |

vector, block, [vector, vector] -> vector

<|cost-rule@trickster:templates|formula=max(distance * 1kG\, 8kG)|>

Places the given block at the given position. Will consume its respective item. 

;;;;;

This ploy optionally takes two additional arguments. 

- The first defines the direction to place from.
- The second defines what side of an adjacent block is interacted with when placing.

Some blocks may change their facing or other properties based on these values.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:change_weight,title=Ploy of Featherweight|>

vector, number -> entity

<|cost-rule@trickster:templates|formula=60kG * (1 - multiplier)|>

Given a number between zero and one, levitates the block at the given position, using the number as its gravity multiplier.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:swap_block,title=Ploy of Exchange|>

vector, vector ->

<|cost-rule@trickster:templates|formula=60kG + distance * 1kG|>

Exchanges the blocks at two positions in the world. Neither of the positions can be empty.

;;;;;

<|page-title@lavender:book_components|title=Note: Heating and Cooling|>By pushing or pulling a large quantity of mana into or from a block, it may be rapidly heated or cooled.


Given these extreme temperature changes, some blocks may change significantly in useful ways, 
though some collateral effects on surrounding blocks should be expected.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:heat,title=Ploy of Investiture|>

vector -> vector

<|cost-rule@trickster:templates|formula=80kG|>

Instantly heat up the given block significantly.


Heating a furnace like this would be quite effective.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:cool,title=Ploy of Divestiture|>

vector -> vector

<|cost-rule@trickster:templates|formula=80kG|>

Instantly cools off the given block significantly.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:erode,title=Ploy of Attrition|>

vector, vector -> vector

<|cost-rule@trickster:templates|formula=80kG|>

Wears down the block at the first given position, making use of the water at the second given position.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:conjure_flower,title=Floral Ploy|>

vector -> vector

<|cost-rule@trickster:templates|formula=5kG|>

Conjures a random flower at the given position.
The block underneath must have a solid top face.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:conjure_water,title=Aquatic Ploy|>

vector -> vector

<|cost-rule@trickster:templates|formula=15kG|>

Conjures a small splash of water at the given position.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:conjure_light,title=Illumination Ploy|>

vector -> vector

<|cost-rule@trickster:templates|formula=20kG|>

Conjures a permanent light source at the given position.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:power_resonator,title=Resonance Ploy|>

vector, number -> boolean

<|cost-rule@trickster:templates|formula=distance / 2kG|>

Powers the [Spell Resonator](^trickster:items/spell_resonator) at the given position with the given power level, between 0 and 15.
