```json
{
  "title": "方块查询",
  "icon": "minecraft:white_wool"
}
```

本节的戏法可用于查询世界中的方块及其属性。


如果无法观测到方块，这些戏法会产生失策。

;;;;;

#<trickster:trick id="trickster:check_block" />

返回所给位置处方块的类型。

;;;;;

#<trickster:trick id="trickster:get_block_hardness" />

返回所给位置处方块的硬度，或返回所给方块类型的硬度。

;;;;;

#<trickster:trick id="trickster:can_place_block" />

检查所给位置能否放置所给方块。若未给定方块，检查该位置方块在通常情况下可否被替换。

;;;;;

p
返回所给位置处收到的红石信号强度。

;;;;;

#<trickster:trick id="trickster:check_resonator" />

返回所给位置处[法术谐振器](*trickster:items/infrastructure/spell_resonator)的信号强度。该处没有谐振器会导致失策。

;;;;;

#<trickster:trick id="trickster:light_level" />

返回所给位置处的光照等级。可以再传入一个布尔值，用于规定光照的来源：{#33ab89}True{}为天空光照，{#aa3355}False{}为方块光照。
