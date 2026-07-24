```json
{
  "title": "物品",
  "icon": "minecraft:grass_block",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "放置之曲变",
    "拾取之曲变",
    "容宽之曲变"
  ]
}
```

用于转换与物品有关法术片段的戏法。

;;;;;

<|trick@trickster:templates|trick-id=trickster:block_from_item|>

返回所给物品类型放置后的方块的类型。若所给物品无法放置为方块，返回void。

;;;;;

<|trick@trickster:templates|trick-id=trickster:item_from_block|>

返回放置所给方块类型所需的物品的类型。若所给方块没有对应物品，返回void。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_max_count|>

返回所给物品的最大堆叠数。
