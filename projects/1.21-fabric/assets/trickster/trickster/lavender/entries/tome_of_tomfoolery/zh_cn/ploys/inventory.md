```json
{
  "title": "物品栏操纵",
  "icon": "minecraft:chest",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "祭献之技巧",
    "骗徒之技巧",
    "颅骨挪移之技巧"
  ]
}
```

本节技巧术能与物品栏的槽位及其他特性交互。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:drop_stack_from_slot,title=祭献之技巧|>

slot, vector, [number] -> entity

---

在给定位置处丢出物品，并返回该物品实体。有丢出数目参数可选。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:swap_slot,title=骗徒之技巧|>

slot, slot ->

---

交换给定槽位的物品组。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:set_hat,title=颅骨挪移之技巧|>

number -> boolean

---

将施法者[高顶礼帽](^trickster:items/top_hat)的所选槽位设为该数，根据成功与否返回布尔值。
