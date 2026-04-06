```json
{
  "title": "方块查询",
  "icon": "minecraft:white_wool",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "校验之辑流",
    "硬度之辑流",
    "适用之辑流",
    "逻辑之辑流",
    "谐振之辑流",
    "光辉之辑流"
  ]
}
```

本节的戏法能用于查询或检视世界中的方块。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:check_block,title=校验之辑流|>

vector -> block

---

返回所给位置处方块的类型。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_block_hardness,title=硬度之辑流|>

vector -> number

---

返回所给位置处方块的硬度。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:can_place_block,title=适用之辑流|>

vector, [block] -> boolean

---

检查所给位置能否放置所给方块。若未给定方块，检查该位置方块可否被替换。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_redstone_power,title=逻辑之辑流|>

vector -> number

---

返回所给位置处收到的红石信号强度。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:check_resonator,title=谐振之辑流|>

vector -> number

---

返回所给位置处[法术谐振器](^trickster:items/spell_resonator)的信号强度。


;;;;;

<|glyph@trickster:templates|trick-id=trickster:light_level,title=光辉之辑流|>

vector, [boolean] -> number

---

返回所给位置处的光照等级。可以再传入一个布尔值，用于规定光照的来源：true为天空光照，false为方块光照。
