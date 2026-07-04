```json
{
  "title": "Tempest Ploys",
  "icon": "minecraft:wind_charge",
  "category": "trickster:ploys",
  "required_advancements": [
    "trickster:stable_storm_mana"
  ],
  "additional_search_terms": [
    "Ploy of the Wrathful",
    "Kinetic Ploy",
    "Mariner's Ploy"
  ],
  "trickster:page_texture": "trickster:textures/gui/white_book_note.png"
}
```

Following my discovery of Tempest mana, I've been experimenting with more unique uses for the stuff.
Converting it to Traditional mana at a tremendous loss is great and all, 
but there have to be things only *this* mana can do... right?


What I've been able to find so far is something, but still rather niche.
There must be more to uncover here...

;;;;;

<|ploy2@trickster:templates|trick-id=trickster:summon_lightning,cost=5kG + 1.1G ^ distance,mana-type=trickster:storm|>

Attempts to strike the given position with a bolt of lightning. Requires <50% stability.

;;;;;

<|ploy2@trickster:templates|trick-id=trickster:add_velocity,cost=3G + length^3 * 16G,mana-type=trickster:storm|>

[Kinetic Ploy](^trickster:ploys/entity#3) will consume Tempest mana in place of Traditional if there is enough available. Requires >50% stability.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:summon_wind_charge,cost=20G + 1G * distance ^ (distance / 3)|>

[Mariner's Ploy](^trickster:ploys/projectile#5) will consume 500G of Tempest mana in place of a wind charge if possible.
