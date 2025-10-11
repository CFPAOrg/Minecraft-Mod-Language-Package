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


These all have very aggressive cost scaling with distance.
They should ideally be used at positions as near to the caster as possible.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:summon_arrow,cost=20G + 1G * distance ^ (distance / 3)|>

Summons an arrow at the given position, returning it. 
Requires an arrow.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:summon_fireball,cost=20G + 1G * distance ^ (distance / 3)|>

Summons a fireball at the given position, returning it. 
Requires a fire charge.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:summon_dragon_breath,cost=20G + 1G * distance ^ (distance / 3)|>

Summons a ball of dragon's breath at the given position, returning it. 
Requires a bottle of dragon's breath and a fire charge.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:summon_tnt,cost=20G + 1G * distance ^ (distance / 3)|>

Summons lit TNT at the given position, returning it.
Requires TNT.
