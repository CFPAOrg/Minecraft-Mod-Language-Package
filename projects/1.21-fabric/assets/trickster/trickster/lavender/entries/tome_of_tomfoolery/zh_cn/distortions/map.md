```json
{
  "title": "映射",
  "icon": "minecraft:filled_map",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "编表之谋略",
    "领航员之曲变",
    "海军将领之谋略",
    "废止之谋略"
  ]
}
```

本节的图案用于操纵映射。映射能建立法术片段到法术片段的联系，类似于字典能将字和其释义联系起来。


如需生成空映射常量，请参见相关的[修订术](^trickster:constants#4)。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:map_insert,title=编表之谋略|>

{any: any}, [any, any]... -> any

---

将键值对插入给定映射。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:map_get,title=领航员之曲变|>

{any: any}, any -> any

---

若给定法术片段与映射中某键相等，则返回其值；否则返回void。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:map_merge,title=海军将领之谋略|>

{any: any}, {any: any}... -> {any: any}

---

将多个映射合一。键相同的键值对取输入索引小的。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:map_remove,title=废止之谋略|>

{any: any}, any... -> {any: any}

---

移除给定映射中键为所给参数的键值对。
