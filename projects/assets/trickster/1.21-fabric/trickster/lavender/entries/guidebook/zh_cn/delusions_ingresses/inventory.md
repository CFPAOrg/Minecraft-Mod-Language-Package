```json
{
  "title": "物品栏信息",
  "icon": "minecraft:bundle",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "销赃人之辑流",
    "收藏家之辑流",
    "物品栏之辑流",
    "储货之辑流",
    "容展之辑流",
    "丰裕之辑流",
    "稳固之辑流",
    "坚忍之辑流"
  ]
}
```

这些戏法可用于获取有关$$dev.enjarai.trickster.spell.fragment.storage.StorageFragment$$的信息。


牢记：创建$$dev.enjarai.trickster.spell.fragment.storage.StorageFragment$$无需消耗魔力。不过，若移动了槽位内的资源，则需消耗(距离 * 数量 * 0.5G)的魔力。**移动的消耗与各技巧术给出的消耗相独立。**

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_item_in_slot|>

返回给定槽位中物品的类型。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_slots|>

返回容器的槽位列表。传入无法以槽位表示的容器会导致失策。

;;;;;

可传入资源类型或其列表以进行筛选，使戏法只返回容器中的有关槽位。

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_resources|>

返回容器中的资源类型列表。

;;;;;

<|trick@trickster:templates|trick-id=trickster:count_resources|>

返回容器中给定资源类型的量。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_inventory_size|>

返回容器的槽位数。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_count_in_slot|>

返回给定槽位中物品的数量。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_durability|>

以数的形式返回所给槽位中物品剩余的耐久度。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_max_damage|>

返回所给槽位中物品能承受的最大损坏值。
