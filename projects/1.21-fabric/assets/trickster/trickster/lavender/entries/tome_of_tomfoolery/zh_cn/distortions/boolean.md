```json
{
  "title": "布尔逻辑",
  "icon": "minecraft:comparator",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "决策之曲变",
    "对抵之谋略",
    "失抵之谋略",
    "无例外之谋略",
    "通常态之谋略",
    "缺失态之谋略",
    "较小之曲变",
    "较大之曲变"
  ]
}
```

本节的图案能够执行布尔逻辑运算。


虽然此处会称符记要求传入布尔值，但仍应注意：如有需求，任何法术片段都会自动强制转换为布尔值。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:if_else,title=决策之曲变|>

(any, any)..., any -> any

---

根据布尔值返回两个输入量中的一个。若为true，返回第一个；否则返回第二个。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:equals,title=对抵之谋略|>

any... -> boolean

---

检查各输入是否相等。若全部相等，返回true。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:not_equals,title=失抵之谋略|>

any... -> boolean

---

检查各输入是否不等。若有至少两个输入相等，返回false。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:all,title=无例外之谋略|>

boolean... -> boolean

---

若所有输入为true，返回true。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:any,title=通常态之谋略|>

boolean... -> boolean

---

若任意输入为true，返回true。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:none,title=缺失态之谋略|>

boolean... -> boolean

---

若没有输入为true，返回true。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:lesser_than,title=较小之曲变|>

number, number -> boolean

---

检查第一个数是否小于第二个数。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:greater_than,title=较大之曲变|>

number, number -> boolean

---

检查第一个数是否大于第二个数。