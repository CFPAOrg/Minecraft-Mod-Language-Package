```json
{
  "title": "列表",
  "icon": "minecraft:string",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "计量之曲变",
    "扩展之谋略",
    "集合之谋略",
    "孤立之曲变",
    "计数之曲变",
    "膨胀之谋略",
    "提取之曲变",
    "定目之曲变",
    "驱散之谋略",
    "放逐之谋略",
    "间奏之曲变"
  ]
}
```

法术中可以创建列表。列表中能容纳任意个片段，整体又被视为单个值。


列表索引自零起始。如需生成空列表常量，请参见相关的[修订术](^trickster:constants#3)。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_size,title=计量之曲变|>

any[] -> number

---

返回所给列表中元素的数目。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_add,title=扩展之谋略|>

any[], any... -> any[]

---

将任意个元素接到给定列表末尾。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_add_range,title=集合之谋略|>

any[], any[]... -> any[]

---

创建一个新列表，其中包含所有给定列表中的元素。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_take_range,title=孤立之曲真|>

any[], number, [number] -> any[]

---

取出列表中索引由第一个数起始、在第二个数之前结束的元素，组成子列表并返回。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_reverse,title=计数之曲真|>

any[] -> any[]

---

倒置所给列表。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_insert,title=膨胀之谋略|>

any[], number, any... -> any[]

---

在给定列表给定位置处插入任意个元素。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_get,title=提取之曲变|>

any[], number -> any

---

查询并返回给定列表给定索引处的元素。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_index_of,title=定目之曲变|>

any[], any -> number | void

---

查询并返回给定元素在给定列表中的索引，若列表中不存在该元素，返回void。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_remove,title=驱散之谋略|>

any[], number... -> any[]

---

根据索引移除给定列表中任意个元素。移除过程中索引不会变化。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_remove_element,title=放逐之谋略|>

any[], any... -> any[]

---

检查给定列表中元素是否与所给参数一致，若一致则移除。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:create_number_range,title=间奏之曲变|>

number, number -> number[]

---

返回一个列表，其中包含自第一个数起、在第二个数前结束的所有整数。