```json
{
  "title": "颜色",
  "icon": "minecraft:white_dye",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "突显之技巧",
    "画家之技巧",
    "吸管之辑流"
  ]
}
```

颜色有两种表示方法，可以是染料物品，也可以是各分量在0到255之间、分别代表红、绿、蓝的向量。

由派对戏法（Party Trick）添加。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:glow,cost=1G * 距离^3|>

令实体发光5秒。不指定颜色会让辉光消退。可以选择给定实体列表，给定则只有这些实体能看见辉光。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:change_color,cost=40G * 数量|>

改变所给方块、槽位、实体的颜色。

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_color|>

若可行，返回一个颜色。