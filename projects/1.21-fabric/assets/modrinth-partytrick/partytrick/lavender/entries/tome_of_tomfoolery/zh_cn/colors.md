```json
{
  "title": "颜色",
  "icon": "minecraft:white_dye",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "辐光之技巧",
    "耀光之技巧",
    "画家之技巧",
    "吸管之辑流",
    "设计师之曲变"
  ]
}
```

颜色有两种表示方法，可以是染料物品，也可以是各分量在0到255之间、分别代表红、绿、蓝的向量。

由派对戏法（Party Trick）添加。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:change_color,cost=40G * 数量|>

改变所给方块、槽位、实体的颜色。

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_color|>

若可行，返回一个颜色。

;;;;;

<|trick@trickster:templates|trick-id=partytrick:dye_to_vector|>

返回所给染料对应的RGB向量。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:conjure_colored_light,cost=20G|>

在所给位置处构筑出一个永久性光源。可以选择提供一个颜色向量。

;;;;;

<|trick@trickster:templates|trick-id=partytrick:light_particle|>

在所给位置处构筑出一个光源粒子。可以选择提供速度和颜色向量。