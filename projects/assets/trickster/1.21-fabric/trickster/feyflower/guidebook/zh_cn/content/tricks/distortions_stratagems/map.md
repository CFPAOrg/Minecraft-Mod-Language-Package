```json
{
  "title": "映射",
  "icon": "minecraft:filled_map"
}
```

本节的戏法用于操纵映射。映射能建立法术片段到法术片段的联系，类似于字典能将字和其释义联系起来。

;;;;;

#<trickster:revision id="trickster:empty_map" />

[常量修订术](*trickster:constants)，会将符记替换为空映射。

;;;;;

#<trickster:trick id="trickster:list_size" />

返回映射中键值对的个数。

;;;;;

#<trickster:trick id="trickster:map_insert" />

将键值对插入给定映射。

;;;;;

#<trickster:trick id="trickster:map_merge" />

将多个映射合并。键相同的键值对取输入索引小的。

;;;;;

#<trickster:trick id="trickster:map_get" />

若给定法术片段与映射中某键相等，则返回对应值；否则返回void。

;;;;;

#<trickster:trick id="trickster:map_get_keys" />

返回所给映射所有键组成的列表。

;;;;;

#<trickster:trick id="trickster:map_get_values" />

返回所给映射所有值组成的列表。

;;;;;

#<trickster:trick id="trickster:map_remove" />

移除给定映射中键为所给输入的键值对。
