---
navigation:
  title: Thermo Generator
  icon: "justdynathings:thermo_generator"
  position: 6
  parent: justdynathings:other.md
item_ids:
  - justdynathings:thermo_generator
---

# The Power of Earth

A new generator that generate Forge Energy based on a heat source blocks and a fluid coolant

<BlockImage id="justdynathings:thermo_generator" scale="4.0" p:facing="down" p:active="true"/>

<Recipe id="justdynathings:thermo_generator" />

## Default Heat Sources

| Item                                                                     | Registry ID                 | Efficiency (float) |
| ------------------------------------------------------------------------ | --------------------------- | ------------------ |
| <ItemImage id= "minecraft:campfire"  scale="0.75" />                     | minecraft:campfire          | 0.5x               |
| <ItemImage id= "minecraft:flint_and_steel"   scale="0.75" /> (fire)      | minecraft:fire              | 0.5x               |
| <ItemImage id="minecraft:magma_block"   scale="0.75" />                  | minecraft:magma_block       | 0.75x              |
| <ItemImage id="minecraft:soul_campfire"  scale="0.75" />                 | minecraft:soul_campfire     | 0.75x              |
| <ItemImage id="minecraft:flint_and_steel"    scale="0.75" /> (soul_fire) | minecraft:soul_fire         | 0.75x              |
| <ItemImage id= "minecraft:cauldron"   scale="0.75" /> (lava)             | minecraft:lava_cauldron     | 0.99x              |
| <ItemImage id= "minecraft:lava_bucket"         scale="0.75" />           | minecraft:lava              | 1.0x               |
| <ItemImage id= "justdirethings:coalblock_t1"  scale="0.75" />            | justdirethings:coalblock_t1 | 2.5x               |
| <ItemImage id="justdirethings:coalblock_t2"  scale="0.75" />             | justdirethings:coalblock_t2 | 5.5x               |
| <ItemImage id="justdirethings:coalblock_t3"  scale="0.75" />             | justdirethings:coalblock_t3 | 7.5x               |
| <ItemImage id="justdirethings:coalblock_t4"  scale="0.75" />             | justdirethings:coalblock_t4 | 10.5x              |

## Default Coolants

| Item                                                                      | Registry ID                             | Efficiency (float) |
| ------------------------------------------------------------------------- | --------------------------------------- | ------------------ |
| <ItemImage id= "minecraft:water_bucket"            scale="0.75" />        | minecraft:water                         | 1.0x               |
| <ItemImage id= "justdirethings:polymorphic_fluid_bucket"  scale="0.75" /> | justdirethings:polymorphic_fluid_source | 2.5x               |
| <ItemImage id= "justdirethings:time_fluid_bucket"    scale="0.75" />      | justdirethings:time_fluid_source        | 10.0x              |

## Looking inside

FE gen = 125 x CoolantEfficiency x HeatEfficiency

MB cost = 125 / CoolantEfficiency

[[Coolants](https://github.com/DevDyna/JustDynaThings/blob/main/src/generated/resources/data/justdynathings/data_maps/fluid/thermo_coolants.json)] [[Heat Sources](https://github.com/DevDyna/JustDynaThings/blob/main/src/generated/resources/data/justdynathings/data_maps/block/thermo_heat_sources.json)]