```json
{
  "title": "Projectiles",
  "icon": "minecraft:fire_charge",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "Ballista's Ploy",
    "Pyromancer's Ploy",
    "Dragon's Ploy",
    "Demolitionist's Ploy"
  ]
}
```

Tricks for manipulating projectiles. Tricks in this category will take the required item from their caster's inventory, 
or optionally a specific slot.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:summon_arrow,title=Ballista's Ploy|>

vector, [slot] -> entity

<|cost-rule@trickster:templates|formula=20kG + distance ^ (distance / 3kG)|>

Summons an arrow at the given position, returning it. 
Requires an arrow.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:summon_fireball,title=Pyromancer's Ploy|>

vector, [slot] -> entity

<|cost-rule@trickster:templates|formula=20kG + distance ^ (distance / 3kG)|>

Summons a fireball at the given position, returning it. 
Requires a fire charge.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:summon_dragon_breath,title=Dragon's Ploy|>

vector, [slot], [slot] -> entity

<|cost-rule@trickster:templates|formula=20kG + distance ^ (distance / 3kG)|>

Summons a ball of dragon's breath at the given position, returning it. 
Requires a bottle of dragon's breath and a fire charge.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:summon_tnt,title=Demolitionist's Ploy|>

vector, [slot] -> entity

<|cost-rule@trickster:templates|formula=20kG + distance ^ (distance / 3kG)|>

Summons lit TNT at the given position, returning it.
Requires TNT.
