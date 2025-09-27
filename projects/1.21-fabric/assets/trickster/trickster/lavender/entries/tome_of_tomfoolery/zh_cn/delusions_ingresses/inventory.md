```json
{
  "title": "物品栏信息",
  "icon": "minecraft:bundle",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "销赃人之辑流",
    "杂耍之错觉",
    "抛接之错觉",
    "侵入之辑流",
    "颅骨之错觉",
    "权威之辑流",
    "加冕之辑流",
    "丰裕之辑流",
    "收藏家之辑流",
    "容展之辑流"
  ]
}
```

这些戏法会从物品栏中获取信息。可以是施法者自己的物品栏，也可以是外部方块或实体的。


它们无法和除施法者之外的玩家的物品栏交互。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_item_in_slot|>

返回给定槽位中物品的类型。

;;;;;

<|trick@trickster:templates|trick-id=trickster:other_hand|>

返回施法者副手中物品的类型。

;;;;;

<|page-title@lavender:book_components|title=笔记：槽位引用|>法术可以引用物品槽位。制造此类引用无需消耗魔力，但若要借助它们移动槽位中的物品，就需要消耗移动的魔力。此消耗等价于(距离 * 数量 * 0.5G)。在计算消耗时，槽位引用会使用移动物品时施法者的位置，或是会使用其目标的位置。

;;;;;

<|trick@trickster:templates|trick-id=trickster:other_hand_slot|>

返回施法者副手的槽位引用。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_inventory_slot|>

使用索引和物品栏来源构建槽位引用，不传入时默认使用施法者作为来源。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_inventory_slots|>

返回物品栏来源的槽位列表。

;;;;;

若未指定来源，则使用施法者的物品栏。可以传入物品或物品列表作为过滤器，以让戏法仅统计物品栏来源中的相关槽位。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_inventory_size|>

返回物品栏来源的槽位数，不传入时默认使用施法者作为来源。

;;;;;

<|trick@trickster:templates|trick-id=trickster:check_hat|>

返回施法者[帽子](^trickster:items/top_hat)的所选槽位。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_mana_in_slot|>

返回所给槽位中魔力的总量。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_max_mana_in_slot|>

返回所给槽位中能容纳的最大魔力总量。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_count_in_slot|>

返回给定槽位中物品的数量。
