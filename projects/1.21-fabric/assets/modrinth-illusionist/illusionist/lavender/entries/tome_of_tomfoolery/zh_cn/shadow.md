```json
{
  "title": "幻术师",
  "icon": "minecraft:sea_lantern",
  "category": "trickster:tricks"
}
```

虚影方块，或称“伪影”或“造影”，是叠加于实物方块之上的一层幻觉。当实物方块的状态变化时，或使用揭影之技巧后，虚影即会被祛除。

;;;;;

<|glyph@trickster:templates|trick-id=illusionist:disguise_block,title=虚影之技巧|>

vector, block -> boolean

<|cost-rule@trickster:templates|formula=20kG|>

在给定位置处施加所给方块的虚影，同时检查并返回虚影创建成功与否。

;;;;;

<|glyph@trickster:templates|trick-id=illusionist:dispel_block_disguise,title=揭影之技巧|>

vector -> boolean

<|cost-rule@trickster:templates|formula=10kG|>

祛除所给位置处的虚影，同时检查并返回该处原本是否存在虚影。
