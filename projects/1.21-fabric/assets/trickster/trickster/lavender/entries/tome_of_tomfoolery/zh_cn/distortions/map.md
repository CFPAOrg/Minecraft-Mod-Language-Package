```json
{
  "title": "映射",
  "icon": "minecraft:filled_map",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "制图师之错觉",
    "编表之谋略",
    "领航员之曲变",
    "海军将领之谋略",
    "废止之谋略"
  ]
}
```

本节的图案用于操纵映射。映射能建立法术片段到法术片段的联系，类似于字典能将字和其释义联系起来。

;;;;;

<|trick@trickster:templates|trick-id=trickster:map_create|>

新建一个空映射。

;;;;;

<|trick@trickster:templates|trick-id=trickster:map_insert|>

将键值对插入给定映射。

;;;;;

<|trick@trickster:templates|trick-id=trickster:map_get|>

若给定法术片段与映射中某键相等，则返回对应值；否则返回void。

;;;;;

<|trick@trickster:templates|trick-id=trickster:map_merge|>

将多个映射合并。键相同的键值对取输入索引小的。

;;;;;

<|trick@trickster:templates|trick-id=trickster:map_remove|>

移除给定映射中键为所给参数的键值对。
