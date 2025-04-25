```json
{
  "title": "实体交互",
  "icon": "minecraft:sheep_spawn_egg",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "动能之技巧",
    "轻羽之技巧",
    "篡夺者之技巧",
    "变身之技巧",
    "解除变身之技巧",
    "收容之技巧",
    "释脱之技巧",
    "居形之技巧"
  ]
}
```

与操纵实体有关的各种戏法。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:add_velocity,title=动能之技巧|>

entity, vector -> entity

<|cost-rule@trickster:templates|formula=3kG + 向量长度^3 * 2kG|>

将所给向量视为速度，并施予所给实体。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:change_weight,title=轻羽之技巧|>

entity, number -> entity

<|cost-rule@trickster:templates|formula=60kG * (1 - 倍数)|>

给定0到1之间的数，若实体为生物实体，则让其所受重力变为原重力与所给数的积，持续1秒。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:displace,title=篡夺者之技巧|>

entity, vector -> entity

<|cost-rule@trickster:templates|formula=20kG + 1.35^长度|>

在两秒后按照所给向量令给定实体位移。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:polymorph,title=变身之技巧|>

entity, entity ->

<|cost-rule@trickster:templates|formula=8000kG|>

将第一个实体变身为第二个实体，仅会变换外形。**目前只对玩家有效。**

;;;;;

<|glyph@trickster:templates|trick-id=trickster:dispel_polymorph,title=解除变身之技巧|>

entity -> entity

<|cost-rule@trickster:templates|formula=1000kG|>

解除所给实体上的变身效果。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:store_entity,title=收容之技巧|>

entity ->

<|cost-rule@trickster:templates|formula=2000kG + 距离 ^ (距离 / 5kG)|>

将所给实体存储到施法者的副手物品中。该物品必须能存储实体，且实体不可为玩家。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:release_entity,title=释脱之技巧|>

vector -> entity | void

<|cost-rule@trickster:templates|formula=2000kG + 距离 ^ (距离 / 5kG)|>

将存储在施法者副手物品中的实体释放到给定位置，并返回该实体。若无实体，返回void。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:set_scale,title=居形之技巧|>

entity, number -> entity

<|cost-rule@trickster:templates|formula=abs(当前尺寸 - 新尺寸)^2 * 100kG + 新尺寸 * 50kG|>

变动所给实体的尺寸。目标尺寸不可小于原大的0.0625，也不可大于原大的8倍。
