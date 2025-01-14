```json
{
  "title": "幻术师",
  "icon": "minecraft:sea_lantern",
  "category": "trickster:tricks"
}
```

虚影方块，或称“回声”或“回声方块”，是叠加与实物方块之上的一层幻觉。当实物方块的状态变化时，或简单使用揭影之技巧后，虚影即会被祛除。

;;;;;

<|glyph@trickster:templates|trick-id=illusionist:disguise_block,title=虚影之技巧|>

vector, block -> boolean

<|cost-rule@trickster:templates|formula=20 kG|>

在给定位置处施加所给方块的虚影，同时检查并返回虚影成功出现与否。

;;;;;

<|glyph@trickster:templates|trick-id=illusionist:dispel_block_disguise,title=揭影之技巧|>

vector -> boolean

<|cost-rule@trickster:templates|formula=10 kG|>

祛除所给位置处的虚影，同时检查并返回该处原本是否存在虚影。
w