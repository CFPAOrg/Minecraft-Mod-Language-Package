---
navigation:
  title: 海棱单片镜
  icon: nautec:prism_monocle
  position: 9
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:prism_monocle
---

# <Color id="light_purple">海棱单片镜</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="prism_monocle" scale="2"/>
  为所看的海蓝科技机器显示统计数据。
</Column>

可在头盔槽或独立的单片镜饰品槽佩戴单片镜。启用时，看向海蓝科技机器或激光方块，可在屏幕中央显示相应数据。它还能清除水下迷雾，和佩戴潜水头盔的效果一致。

<Recipe id="nautec:prism_monocle"/>

***

## <Color id="gold">所得数据</Color>

| 方块                                                                            | 显示                                                                             |
| ------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| 任意机器、中继器、光学仪器以及其他激光方块                                      | 收到的功率（AP每刻）和纯度                                                       |
| <ItemLink id="aquatic_catalyst"/>                                               | 持续时间：当前燃料物品的燃烧时间                                                 |
| <ItemLink id="bacterial_fuel_cell"/>                                            | 输出（AP每刻）、纯度、燃料，或显示无菌落                                         |
| <ItemLink id="pressure_forge"/>                                                 | 放入的模拟器，压力足够时显示蚀刻酸（mB）和纯度，不足时显示需要什么深度和水深     |
| <ItemLink id="resonance_chamber"/>                                              | 充能、上限、纯度，冷却时显示已破裂                                               |
| <ItemLink id="gateway"/>及其圆环                                                | 地址；状态为开放、就绪、空闲、供能不足、被红石关闭或被阻挡；是否是天然门径；储能 |
| <ItemLink id="submarine_dock"/>                                                 | 有无海洋斥候停靠                                                                 |
| 深海排水口壁                                                                    | 储能和流体存量                                                                   |
| <ItemLink id="bubble_anchor"/>                                                  | 状态、力场尺寸、剩余燃料、结束至什么                                             |
| <ItemLink id="oxygen_diffuser"/>                                                | 运行时显示范围，或显示所需AP                                                     |
| <ItemLink id="energy_converter"/>                                               | 发送的AP、共射出几条光束、消耗的FE/t，或为何不运作                               |
| <ItemLink id="grafting_station"/>和<ItemLink id="advanced_bacterial_analyzer"/> | 状态、供能、纯度                                                                 |
| <ItemLink id="colony_replicator"/>                                              | 状态、模式是复制还是剪接、生物质                                                 |
| <ItemLink id="uplink_array"/>                                                   | 状态                                                                             |

在找配方的问题之前，可以先用它检查光束是否足够纯净。相较于只有高纯度光束的情况，有其他低纯度光束同时射入时，综合纯度会稍稍下降。

佩戴于护符槽的<ItemLink id="resonance_charm"/>也有同样的功能，不必同时佩戴两者。参见[共鸣网络](nautec:deep_engineering/resonance_network.md)。

***

## <Color id="gold">配合Jade</Color>

安装有Jade时，它会在你看向部分方块时显示相应提示文本：海蓝催化器的状态、待使用的燃料、剩余刻数、AP每刻、光束目标；搅拌机、激光转接器、深海排水口、约束刷怪笼、育晶仪、海晶水晶、聚变反应堆控制器、潮汐转子机、喷口汇热器、能量转换器等也会相应显示。
