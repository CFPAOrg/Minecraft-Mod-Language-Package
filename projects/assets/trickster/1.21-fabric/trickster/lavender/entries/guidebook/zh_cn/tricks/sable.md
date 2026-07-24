```json
{
  "title": "脱离式结构",
  "icon": "minecraft:compass",
  "category": "trickster:tricks",
  "ordinal": 100,
  "additional_search_terms": [
    "飞行员之辑流",
    "导航员之辑流"
  ],
  "fabric:load_conditions": [
    {
      "condition": "fabric:any_mods_loaded",
      "values": [
        "sable"
      ]
    },
    {
      "condition": "fabric:not",
      "value": {
        "condition": "fabric:any_mods_loaded",
        "values": [
          "mage_mech"
        ]
      }
    }
  ]
}
```

大型结构可通过未知方式从世界的基础网格中剥离而出。


这些“脱离式结构”中方块的位置也可用向量表示，但这些向量的模长非常大。

;;;;;

虽然这类向量可用来直接与结构中的方块交互，但对其他操作来说不太顺手。


本节中记录的辑流术可将这些向量根据脱离式结构的实际位置进行转换。

;;;;;

<|trick@trickster:templates|trick-id=trickster:project_position|>

给定脱离式结构内部的位置，返回其在世界中的实际位置。

;;;;;

<|trick@trickster:templates|trick-id=trickster:project_direction|>

给定脱离式结构内部的位置，根据结构的朝向旋转第二个向量并返回。
