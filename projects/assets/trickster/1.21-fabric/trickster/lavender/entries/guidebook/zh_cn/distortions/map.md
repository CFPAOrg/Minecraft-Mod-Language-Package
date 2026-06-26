```json
{
  "title": "映射",
  "icon": "minecraft:filled_map",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "舆图之修订",
    "计量之曲变",
    "编表之谋略",
    "领航员之曲变",
    "海军将领之谋略",
    "废止之谋略"
  ]
}
```

本节的戏法用于操纵映射。映射能建立法术片段到法术片段的联系，类似于字典能将字和其释义联系起来。

;;;;;

<|revision@trickster:templates|revision-id=trickster:empty_map|>

[常量修订术](^trickster:constants)，会将符记替换为空映射。

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_size|>

返回映射中键值对的个数。

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

移除给定映射中键为所给输入的键值对。
