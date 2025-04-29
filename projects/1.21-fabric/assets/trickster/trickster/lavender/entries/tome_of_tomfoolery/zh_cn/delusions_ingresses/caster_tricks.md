```json
{
  "title": "施法上下文",
  "icon": "trickster:wand",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "定位之错觉",
    "朝向之错觉",
    "自审之错觉",
    "维度之错觉",
    "权威之错觉",
    "加冕之错觉",
    "序数之错觉",
    "框选之错觉",
    "宏之错觉"
  ]
}
```

本节中的错觉术能获取施法实体和方块的上下文。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:reflection,title=定位之错觉|>

-> vector

---

返回法术施放的位置。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:facing_reflection,title=朝向之错觉|>

-> vector

---

若可行，将施法方块或实体的朝向返回为单位向量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:caster_reflection,title=自审之错觉|>

-> entity

---

返回施放法术的实体。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_dimension,title=维度之错觉|>

-> dimension

---

返回法术施放的维度。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:mana_reflection,title=权威之错觉|>

-> number

---

返回法术直接可用的魔力的量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:max_mana_reflection,title=加冕之错觉|>

-> number

---

返回法术最多*可能*可用的魔力的量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:current_thread,title=序数之错觉|>

-> number | void

---

返回运行此法术的法术槽；若不支持法术槽，返回void。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:hotbar_reflection,title=框选之错觉|>

-> number

---

若可用，返回施法者所选中的快捷栏槽位。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:read_macro_ring,title=宏之错觉|>

-> {pattern: spell}

---

获取并结合所佩戴所有戒指中的映射。
