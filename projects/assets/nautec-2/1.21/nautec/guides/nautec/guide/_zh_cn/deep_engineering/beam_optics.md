---
navigation:
  title: 激光光学
  icon: nautec:focusing_lens
  position: 0
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:focusing_lens
---

# <Color id="light_purple">激光光学</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="focusing_lens" scale="2"/>
  纯度，以及能提升纯度的透镜。
</Column>

<ItemLink id="prismarine_laser_relay"/>能够沿直线传播光束，<ItemLink id="laser_junction"/>能够让光束转向、合并、分叉，但它们都无法改变光束的纯度（参见[传输激光功率](nautec:laser_chemistry/laser_manipulation.md)）。配方会在执行之前检查纯度，规划时建议以光束末端机器的纯度需求为基准。

***

## <Color id="gold">纯度</Color>

纯度由光束源给定。合并光束会让纯度稍稍下降，聚焦透镜则能让纯度上升。

| 来源                                                | 纯度                                |
| --------------------------------------------------- | ----------------------------------- |
| 燃烧海晶碎片的<ItemLink id="aquatic_catalyst"/>     | 0.4                                 |
| 燃烧海晶砂粒的海蓝催化器                            | 0.8                                 |
| 燃烧海晶水晶碎片的海蓝催化器                        | 1.2                                 |
| <ItemLink id="bacterial_fuel_cell"/>                | 最高2.5                             |
| <ItemLink id="prismarine_crystal"/>，从侧面射入光束 | 3.0，或人造水晶本身的纯度（最高12） |

人造水晶的纯度可通过[细菌富集催化机](bacterial_enrichment_catalyst.md)提升至6.0之上。

每有一个海晶母岩接触海蓝催化器，可向光束追加0.1的纯度，最高至2.0。参见[激光功率](nautec:getting_started/laser_power.md)。

本章节涉及的机器所需纯度如下：

| 产物           | 机器                                | 纯度 |
| -------------- | ----------------------------------- | ---- |
| 无瑕的海晶水晶 | [深渊压力锻造机](pressure_forge.md) | 2.0  |
| 海洋金锭       | 深渊压力锻造机                      | 2.0  |
| 深海钢衬板     | 深渊压力锻造机                      | 2.5  |
| 共鸣碎片       | [共鸣室](resonance_chamber.md)      | 3.0  |
| 海晶水晶种子   | 共鸣室                              | 3.0  |

有多个光束射到同一个方块时，会求所有光束的功率和，最终纯度则接近于其中最纯净的光束：最高纯度减去其与所有光束平均纯度差值的四分之一（`beamMergePurityDrop`）。合并纯度3.0和纯度0的光束，所得会是约2.6。

***

<Row>
  <ItemImage id="focusing_lens"/>
  ### <Color id="aqua">聚焦透镜</Color>
</Row>

光束穿过它后纯度会提升（`lensPurityBonus`），最高可达2.0。放置时看向光束的目的方向：朝向你的面会接受光束，远离你的会发射，最远至16格（`laserDistance`）。它不会改变光束的功率，且可放置在水下。

透镜只会给已有一定纯度的光束进一步提升，需要把它放在相应的来源之上。纯度1.8的光束经过它，所得纯度是2.0；纯度在2.0及以上的光束经过它，所得纯度仍是2.0。连续放置透镜，最终纯度也不会超过2.0。连续放置两个，即可将水晶碎片催化器光束（1.2）提升至压力锻造机制造无瑕的海晶水晶需要的2.0纯度。对于2.5和3.0，可使用细菌燃料单元或海晶水晶作为光束源。

<Recipe id="nautec:focusing_lens"/>
