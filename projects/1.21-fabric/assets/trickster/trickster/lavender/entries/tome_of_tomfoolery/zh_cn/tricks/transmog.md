```json
{
  "title": "幻化",
  "icon": "transmog:void_fragment",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "幻化之技巧",
    "诡谋之技巧",
    "原形之技巧",
    "幻化之辑流"
  ],
  "fabric:load_conditions": {
    "condition": "fabric:any_mods_loaded",
    "values": [
      "transmog"
    ]
  }
}
```

这个世界似乎有些不同寻常：其中物品的外形能幻化成另一种物品。


幻化只会转换物品的外观，而不会影响其属性和行为。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:transmog,title=幻化之技巧|>

slot, item -> boolean

<|cost-rule@trickster:templates|formula=20kG|>

将给定槽位中的物品幻化为给定物品。若幻化成功，返回true。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:hidden_transmog,title=诡谋之技巧|>

slot -> boolean

<|cost-rule@trickster:templates|formula=30kG|>

将给定槽位中的物品幻化为虚无。若幻化成功，返回true。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:remove_transmog,title=原形之技巧|>

slot -> boolean

<|cost-rule@trickster:templates|formula=10kG|>

去除给定槽位中物品的幻化。若去除成功，返回true。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_transmog,title=幻化之辑流|>

slot -> item

---

返回给定槽位物品上的幻化效果。若未经幻化，返回void。
