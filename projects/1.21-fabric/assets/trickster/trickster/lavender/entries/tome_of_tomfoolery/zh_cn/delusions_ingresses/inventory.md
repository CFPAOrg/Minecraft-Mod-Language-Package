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
    "丰裕之辑流"
  ]
}
```

从施法者物品栏中获取信息的戏法。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_item_in_slot,title=销赃人之辑流|>

slot -> item

---

返回给定槽位中物品的类型。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:other_hand,title=杂耍之错觉|>

-> item

---

返回施法者另一只手中物品的类型。

;;;;;

<|page-title@lavender:book_components|title=笔记：槽位引用|>物品槽位可被法术引用。制造此类引用没有消耗。但若要使用此类引用以移动槽位中的物品，就需要付出移动所需的代价。此消耗等价于(距离 * 数量 * 0.5 kG)。槽位引用必定指向方块的位置，或是指向*移动物品时的施法者*。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:other_hand_slot,title=抛接之错觉|>

-> slot

---

返回施法者另一只手的槽位引用。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_inventory_slot,title=侵入之辑流|>

number, [vector | entity] -> slot

---

根据物品栏或容器和索引构建槽位引用，默认使用施法者作为物品栏的来源。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:check_hat,title=颅骨之错觉|>

-> number | void

---

返回施法者[高顶礼帽](^trickster:items/top_hat)的所选槽位。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_mana_in_slot,title=权威之辑流|>

slot... -> number

---

返回给定槽位中的魔力的量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_max_mana_in_slot,title=加冕之辑流|>

slot... -> number

---

返回给定槽位中能容纳的最大魔力的量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_count_in_slot,title=丰裕之辑流|>

slot -> number

---

返回给定槽位中物品的数量。