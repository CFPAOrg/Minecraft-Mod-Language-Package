```json
{
  "title": "多彩派对戏法",
  "icon": "minecraft:white_dye",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "突显之技巧",
    "画家之技巧",
    "清教徒之技巧",
    "吸管之辑流",
    "着染之技巧",
    "着染之辑流"
  ]
}
```

由派对戏法（Party Trick）新添加的额外颜色戏法。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:remove_dye_color,cost=40G * 数量|>

参数前面与[损蚀之技巧](^trickster:ploys/block#13)类似：接受一个目标和一处水源。移除目标的颜色。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:set_dye_color,cost=40G * 所用染料量|>

将给定目标的颜色改为给定槽位内染料的颜色，会消耗染料。

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_dye_color|>

若可行，根据目标颜色返回一个染料。

;;;;;

<|trick@trickster:templates|trick-id=partytrick:set_color|>

将所给可染色物品染为所给颜色。未指定颜色则移除颜色。

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_color|>

返回所给可染色物品的确切颜色，无色则返回null。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:glow,cost=1G * 距离^3|>

让实体发光5秒。未指定颜色则消除发光。可以选择指定能看见发光的实体列表。