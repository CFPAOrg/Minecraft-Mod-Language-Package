```json
{
  "title": "风暴",
  "icon": "minecraft:wind_charge",
  "category": "trickster:ploys",
  "required_advancements": [
    "trickster:stable_storm_mana"
  ],
  "additional_search_terms": [
    "暴怒者之技巧",
    "动能之技巧",
    "海员之技巧"
  ],
  "trickster:page_texture": "trickster:textures/gui/white_book_note.png"
}
```

本节的技巧术需要消耗风暴魔力，而不是常规魔力。

;;;;;

<|ploy2@trickster:templates|trick-id=trickster:summon_lightning,cost=5kG + 1.1G ^ 距离,mana-type=trickster:storm|>

尝试向所给位置落下闪电。需要稳定度<50%。

;;;;;

<|ploy2@trickster:templates|trick-id=trickster:add_velocity,cost=3G + 长度^3 * 16G,mana-type=trickster:storm|>

若风暴魔力的量足够，[动能之技巧](^trickster:ploys/entity#3)会优先于常规魔力消耗它。需要稳定度>50%。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:summon_wind_charge,cost=20G + 1G * 距离 ^ (距离 / 3)|>

若可行，[海员之技巧](^trickster:ploys/projectile#5)会优先于风弹消耗500G的风暴魔力。
