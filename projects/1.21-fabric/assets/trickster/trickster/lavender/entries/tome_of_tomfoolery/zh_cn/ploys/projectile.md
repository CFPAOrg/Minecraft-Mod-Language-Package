```json
{
  "title": "弹射物",
  "icon": "minecraft:fire_charge",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "弩炮之技巧",
    "火焰术师之技巧",
    "巨龙之技巧",
    "爆破师之技巧"
  ]
}
```

能操纵弹射物的戏法。本节戏法会消耗施法者物品栏中的物品，或是需要提供槽位信息。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:summon_arrow,title=弩炮之技巧|>

vector, [slot] -> entity

<|cost-rule@trickster:templates|formula=20kG + 距离 ^ (距离 / 3kG)|>

在给定位置召唤一根箭，并返回其实体。需要消耗箭。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:summon_fireball,title=火焰术师之技巧|>

vector, [slot] -> entity

<|cost-rule@trickster:templates|formula=20kG + 距离 ^ (距离 / 3kG)|>

在给定位置召唤一个火球，并返回其实体。需要消耗火焰弹。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:summon_dragon_breath,title=巨龙之技巧|>

vector, [slot], [slot] -> entity

<|cost-rule@trickster:templates|formula=20kG + 距离 ^ (距离 / 3kG)|>

在给定位置召唤一个末影龙火球，并返回其实体。需要消耗龙息和火焰弹。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:summon_tnt,title=爆破师之技巧|>

vector, [slot] -> entity

<|cost-rule@trickster:templates|formula=20kG + 距离 ^ (距离 / 3kG)|>

在给定位置召唤一个激活的TNT，并返回其实体。需要消耗TNT。
