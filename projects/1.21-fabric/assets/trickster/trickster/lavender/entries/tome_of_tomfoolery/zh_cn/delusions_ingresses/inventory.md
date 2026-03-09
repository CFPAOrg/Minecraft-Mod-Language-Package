```json
{
  "title": "物品栏信息",
  "icon": "minecraft:bundle",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "销赃人之辑流",
    "杂耍之错觉",
    "抛接之错觉",
    "物仓之辑流",
    "液仓之辑流",
    "侵入之辑流",
    "收藏家之辑流",
    "物品栏之辑流",
    "颅骨之错觉",
    "权威之辑流",
    "加冕之辑流",
    "丰裕之辑流",
    "探查之辑流"
  ]
}
```

这些戏法会从物品栏中获取信息。可以是施法者自己的物品栏，也可以是外部方块或实体的。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_item_in_slot|>

返回给定槽位中物品的类型。

;;;;;

<|trick@trickster:templates|trick-id=trickster:other_hand|>

返回施法者副手中物品的类型。

;;;;;

<|page-title@lavender:book_components|title=笔记：槽位引用|>法术可以引用资源槽位。制造此类引用无需消耗魔力，但若要借助它们移动槽位中的资源，就需要消耗移动的魔力。此消耗等价于(距离 * 数量 * 0.5G)。

;;;;;

在计算消耗时，槽位引用会使用移动物品时施法者的位置，或是会使用其目标的位置。


可以将掉落的物品、矿车、驴等许多实体视为容器。此性质不适用于除施法者外的其他玩家。

;;;;;

<|trick@trickster:templates|trick-id=trickster:other_hand_slot|>

返回施法者副手的槽位引用。
;;;;;

<|trick@trickster:templates|trick-id=trickster:get_item_container|>

;;;;;

返回所给值中物品容器的引用，或返回施法者的物品容器引用。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_fluid_container|>

返回所给值中流体容器的引用。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_slot|>

使用容器和索引构建槽位。传入无法以槽位表示的容器会导致失策。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_slots|>

返回容器的槽位列表。传入无法以槽位表示的容器会导致失策。

;;;;;

可传入资源类型或其列表以进行过滤，使戏法只返回容器中的有关槽位。

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

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_equipment|>

以物品列表形式返回所给实体当前穿戴的装备。顺序如下：主手、副手、靴子、护腿、胸甲、头盔。
