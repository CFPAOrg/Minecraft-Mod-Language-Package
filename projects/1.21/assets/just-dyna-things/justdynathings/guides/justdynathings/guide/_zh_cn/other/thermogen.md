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

| 物品                                                                   | 注册ID                      | 效率（浮点） |
| ---------------------------------------------------------------------- | --------------------------- | ------------ |
| <ItemImage id= "minecraft:campfire"  scale="0.75" />                   | minecraft:campfire          | 0.5x         |
| <ItemImage id= "minecraft:flint_and_steel"   scale="0.75" />（火）     | minecraft:fire              | 0.5x         |
| <ItemImage id="minecraft:magma_block"   scale="0.75" />                | minecraft:magma_block       | 0.75x        |
| <ItemImage id="minecraft:soul_campfire"  scale="0.75" />               | minecraft:soul_campfire     | 0.75x        |
| <ItemImage id="minecraft:flint_and_steel"    scale="0.75" />（灵魂火） | minecraft:soul_fire         | 0.75x        |
| <ItemImage id= "minecraft:cauldron"   scale="0.75" />（熔岩）          | minecraft:lava_cauldron     | 0.99x        |
| <ItemImage id= "minecraft:lava_bucket"         scale="0.75" />         | minecraft:lava              | 1.0x         |
| <ItemImage id= "justdirethings:coalblock_t1"  scale="0.75" />          | justdirethings:coalblock_t1 | 2.5x         |
| <ItemImage id="justdirethings:coalblock_t2"  scale="0.75" />           | justdirethings:coalblock_t2 | 5.5x         |
| <ItemImage id="justdirethings:coalblock_t3"  scale="0.75" />           | justdirethings:coalblock_t3 | 7.5x         |
| <ItemImage id="justdirethings:coalblock_t4"  scale="0.75" />           | justdirethings:coalblock_t4 | 10.5x        |

## 默认冷却剂

| 物品                                                                      | 注册ID                                  | 效率（浮点） |
| ------------------------------------------------------------------------- | --------------------------------------- | ------------ |
| <ItemImage id= "minecraft:water_bucket"            scale="0.75" />        | minecraft:water                         | 1.0x         |
| <ItemImage id= "justdirethings:polymorphic_fluid_bucket"  scale="0.75" /> | justdirethings:polymorphic_fluid_source | 2.5x         |
| <ItemImage id= "justdirethings:time_fluid_bucket"    scale="0.75" />      | justdirethings:time_fluid_source        | 10.0x        |

## 详细原理

FE生成 = 125 x 冷却剂效率 x 热源效率

流体mB消耗 = 125 / 冷却剂效率

[[冷却剂](https://github.com/DevDyna/JustDynaThings/blob/main/src/generated/resources/data/justdynathings/data_maps/fluid/thermo_coolants.json)] [[热源](https://github.com/DevDyna/JustDynaThings/blob/main/src/generated/resources/data/justdynathings/data_maps/block/thermo_heat_sources.json)]