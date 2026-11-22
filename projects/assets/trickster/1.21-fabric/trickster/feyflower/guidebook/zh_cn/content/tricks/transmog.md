```json
{
  "title": "幻化",
  "icon": "transmog:void_fragment",
  "ordinal": 100,
  "fabric:load_conditions": {
    "condition": "fabric:any_mods_loaded",
    "values": [
      "transmog"
    ]
  }
}
```

这个世界似乎有些不同寻常，物品可以被幻化而变形成另一种物品。


幻化只会转换物品的外观，而不会影响其属性和行为。

;;;;;

#<trickster:trick id="trickster:transmog" />

将给定槽位中的物品幻化为给定物品。

;;;;;

#<trickster:trick id="trickster:hidden_transmog" />

将给定槽位中的物品幻化为虚无。

;;;;;

#<trickster:trick id="trickster:remove_transmog" />

去除给定槽位中物品的幻化。

;;;;;

#<trickster:trick id="trickster:get_transmog" />

返回给定槽位物品上的幻化效果。若未经幻化，返回$$trickster:void$$。
