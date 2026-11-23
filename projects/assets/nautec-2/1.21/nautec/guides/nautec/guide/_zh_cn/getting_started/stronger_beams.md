---
navigation:
  title: 更强大的光束
  icon: nautec:focusing_lens
  position: 2
  parent: getting_started/getting_started-index.md
---

# <Color id="light_purple">更强大的光束</Color>

所有需要激光光束的海蓝科技机器都有一个最小需求：它收到的AP/t必须大于该值，不然就不会运转。光束的功率超过该值也不会产生浪费；大多数机器会因此加快运作速度，深海排水口则会增加泵水量。

***

## <Color id="gold">规则</Color>

**速度乘数 = (光束功率 ÷ 所需功率)的平方根。**

四倍功率可让机器两倍速运转。九倍功率对应三倍速。乘数没有上限，但随着乘数不断增加相同量，所需的功率会越来越多。

| 光束，以所需功率倍数计 | 速度       |
| ---------------------- | ---------- |
| 小于1×                 | 不运转     |
| 1×                     | ×1（正常） |
| 2×                     | ×1.41      |
| 4×                     | ×2         |
| 9×                     | ×3         |
| 16×                    | ×4         |
| 25×                    | ×5         |
| 100×                   | ×10        |

需要10 AP的机器若收到40 AP的光束，它便会以2倍速运转；收到90 AP时则以3倍速运转。

提高纯度没有加速效应。有最小纯度需求的机器（高级细菌分析机、菌落复制机、移植站）会在纯度不足时停工，无论功率多少。

***

## <Color id="gold">适用于哪些机器</Color>

| 机器                                                               | 需求（默认）                            | 加速效应作用范围                                              |
| ------------------------------------------------------------------ | --------------------------------------- | ------------------------------------------------------------- |
| [搅拌机](nautec:laser_chemistry/mixer.md)                          | 10 AP                                   | 每周期作业数，每10 AP一次，最多64次；超过640 AP时加快运作速度 |
| [诱变机](nautec:aquatic_biology/mutator.md)                        | 10 AP                                   | 突变尝试，即增加每分钟尝试次数                                |
| [培养机](nautec:aquatic_biology/incubator.md)                      | 20 AP                                   | 生长周期，以及每周期消耗的营养物质                            |
| [细菌分析机](nautec:aquatic_biology/bacterial_analyzer.md)         | 5 AP                                    | 分析                                                          |
| [高级细菌分析机](nautec:aquatic_biology/bacterial_analyzer.md)     | 40 AP，纯度2.1                          | 所有九个培养皿的分析                                          |
| [压力锻造机](nautec:deep_engineering/pressure_forge.md)            | 40 AP                                   | 锻压                                                          |
| [菌落复制机](nautec:aquatic_biology/colony_replicator.md)          | 80 AP，纯度2.0                          | 每次复制                                                      |
| [移植站](nautec:aquatic_biology/bacteria_grafting.md)              | 100 AP，纯度2.8，有高级移植锚时为500 AP | 每次移植                                                      |
| [生物反应机](nautec:aquatic_biology/bio_reactor.md)                | 5 AP，每个菌落追加15，再乘以升级乘数    | 产出量                                                        |
| [工业生物反应机](nautec:aquatic_biology/industrial_bio_reactor.md) | 100 AP，每个菌落追加50，再乘以升级乘数  | 产出量                                                        |
| [强化站](nautec:laser_augmentation/augmentation_station.md)        | 每个用到的扩展单元25 AP                 | 最慢扩展单元植入强化件的速度                                  |
| [潜水器停靠坞](nautec:submarine/submarine_dock.md)                 | 20 AP                                   | 为停靠潜水器充能的速度                                        |
| [深海排水口](nautec:laser_chemistry/drain.md)                      | 大于20 AP                               | 每秒盐水泵送量，与光束功率成正比                              |
| [渗透滤水机](nautec:laser_chemistry/osmosis_filter.md)             | 无                                      | 每40 AP令水产量翻倍                                           |

**叠加。**&zwnj;生物反应机会先根据其中菌落和升级计算出所需，再在速度升级的效果之上叠加强激光的效果。若有反应机通过升级获得1.5倍速，向其供应四倍功率，最终速度会是3倍速。强激光不会让菌落加快消耗营养物质，也就是单纯地增加了产出量。高级移植锚的机制和它一致：它会先将移植站的需求升至500 AP，同时加快移植速度；提供强于500 AP的光束可进一步加速。

**无加速。**&zwnj;[激光纯化烧炼机](nautec:deep_engineering/laser_purification_smelter.md)的运作速度由其导管升级决定，与光束强度无关。纯净的光束可减少它需要的AP。

**已在加速。**&zwnj;[共鸣室](nautec:deep_engineering/resonance_chamber.md)会根据收到的功率调整充能速度，[晶体培植器](nautec:deep_engineering/crystal_cultivation.md)则按收到的总能量培育水晶，这两者无需强激光效应的参与就已进行了成比例的加速。

***

## <Color id="gold">查看效应</Color>

Jade能显示所有这些机器的速度，同时给出它收到的光束和它的需求，例如“光束强度为40 AP（需要10），速度x2.00”。光束太弱时会显示为红色。<ItemLink id="prism_monocle"/>能显示任意激光方块收到的功率和纯度。

要制造强激光，可用[激光转接器](nautec:laser_chemistry/laser_manipulation.md)汇合多个激光源，也可通过[能量转换器](nautec:laser_chemistry/energy_converter.md)利用其他强大发电器的产出。

***

## <Color id="gold">给整合包作者</Color>

`config/nautec-common.toml`中的`beamOverclock`可关闭加速；关闭后即便功率超过阈值，机器的运转速度也不会加快。`beamOverclockMaxSpeed`可用于设置速度乘数上限，0代表没有上限。深海排水口有独立的设置，详见其页面。
