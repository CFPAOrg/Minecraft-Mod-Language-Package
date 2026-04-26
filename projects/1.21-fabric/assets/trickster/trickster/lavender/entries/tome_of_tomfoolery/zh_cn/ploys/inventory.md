```json
{
  "title": "物品栏操纵",
  "icon": "minecraft:chest",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "祭献之技巧",
    "组织者之技巧",
    "骗徒之技巧",
    "颅骨挪移之技巧"
  ]
}
```

*“需要着重说明，在现今所有法律体系中，对物品栏戏法作了严格的限制的占绝大多数。*


*“倒不是因为它们非常危险，而是因为人类有种奇怪的集体执念——他们管这个叫‘个人财产’。”*


——摘自格鲁内教授的讲座


创建槽位引用无需消耗魔力。不过，若在使用此类引用时移动了槽位内的物品，则需消耗(距离 * 数量 * 0.5G)的魔力。

;;;;;

<|trick@trickster:templates|trick-id=trickster:drop_stack_from_slot|>

在给定位置处丢出物品，并返回该物品实体。丢出数目参数可选。

;;;;;

<|trick@trickster:templates|trick-id=trickster:move_resource|>

在仓储空间之间移动资源。

;;;;;

可给定数以设定移动上限，也可指定资源类型或其列表以进行过滤。

;;;;;

<|trick@trickster:templates|trick-id=trickster:swap_slot|>

交换给定槽位内的资源。

;;;;;

<|trick@trickster:templates|trick-id=trickster:set_hat|>

将施法者[帽子](^trickster:items/writing_casting/top_hat)的所选槽位设为该数，根据成功与否返回布尔值。
