```json
{
  "title": "物品栏操纵",
  "icon": "minecraft:chest",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "祭献之技巧",
    "骗徒之技巧",
    "组织者之技巧",
    "颅骨挪移之技巧"
  ]
}
```

本节的技巧术能与物品栏的槽位及其他特性交互。

;;;;;

<|trick@trickster:templates|trick-id=trickster:drop_stack_from_slot|>

在给定位置处丢出物品，并返回该物品实体。丢出数目参数可选。

;;;;;

<|trick@trickster:templates|trick-id=trickster:swap_slot|>

交换给定槽位的物品组。

;;;;;

<|trick@trickster:templates|trick-id=trickster:move_stack|>

将所给槽位中的物品移动到另一个槽位，移动数量上限参数可选。可以合并和拆分物品组。

;;;;;

<|trick@trickster:templates|trick-id=trickster:set_hat|>

将施法者[帽子](^trickster:items/top_hat)的所选槽位设为该数，根据成功与否返回布尔值。
