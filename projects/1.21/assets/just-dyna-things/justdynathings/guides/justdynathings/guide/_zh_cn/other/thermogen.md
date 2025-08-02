---
navigation:
  title: 热力发电器
  icon: "justdynathings:thermo_generator"
  position: 6
  parent: justdynathings:other.md
item_ids:
  - justdynathings:thermo_generator
---

# 大地的力量

根据热源方块和流体冷却剂产生Forge能量（Forge Energy，FE）的新型发电机。

<BlockImage id="justdynathings:thermo_generator" scale="4.0" p:facing="down" p:active="true"/>

<Recipe id="justdynathings:thermo_generator" />

## 默认热源

| 物品                                                                  | 效率  |
| --------------------------------------------------------------------- | ----- |
| <ItemLink id= "minecraft:campfire"  scale="0.75" />                   | 0.5x  |
| <ItemLink id= "minecraft:flint_and_steel"   scale="0.75" />（火）     | 0.5x  |
| <ItemLink id="minecraft:magma_block"   scale="0.75" />                | 0.75x |
| <ItemLink id="minecraft:soul_campfire"  scale="0.75" />               | 0.75x |
| <ItemLink id="minecraft:flint_and_steel"    scale="0.75" />（灵魂火） | 0.75x |
| <ItemLink id= "minecraft:cauldron"   scale="0.75" />（熔岩）          | 0.99x |
| <ItemLink id= "minecraft:lava_bucket"         scale="0.75" />         | 1.0x  |
| <ItemLink id= "justdirethings:coalblock_t1"  scale="0.75" />          | 2.5x  |
| <ItemLink id="justdirethings:coalblock_t2"  scale="0.75" />           | 5.5x  |
| <ItemLink id="justdirethings:coalblock_t3"  scale="0.75" />           | 7.5x  |
| <ItemLink id="justdirethings:coalblock_t4"  scale="0.75" />           | 10.5x |

## 默认冷却剂

| 物品                                                                     | 倍率  |
| ------------------------------------------------------------------------ | ----- |
| <ItemLink id= "minecraft:water_bucket"            scale="0.75" />        | 1.0x  |
| <ItemLink id= "justdirethings:polymorphic_fluid_bucket"  scale="0.75" /> | 2.5x  |
| <ItemLink id= "justdirethings:time_fluid_bucket"    scale="0.75" />      | 10.0x |

## 详细原理

FE生成 = 125 x 冷却剂效率 x 热源效率

流体mB消耗 = 125 / 冷却剂效率

[[冷却剂](https://github.com/DevDyna/JustDynaThings/blob/main/src/generated/resources/data/justdynathings/data_maps/fluid/thermo_coolants.json)] [[热源](https://github.com/DevDyna/JustDynaThings/blob/main/src/generated/resources/data/justdynathings/data_maps/block/thermo_heat_sources.json)]
