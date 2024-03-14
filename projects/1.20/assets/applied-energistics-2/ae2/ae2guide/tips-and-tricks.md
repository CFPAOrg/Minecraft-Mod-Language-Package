---
navigation:
  title: 提示与技巧
  position: 20
---

# 提示与技巧

一大堆小推荐。

* 移除Optifine。
* 可以旋转或缩放带有缩放和显隐注释图标的指南示例图。
* 保持网络的树状结构，避免构造环状结构。
* 方块形态[设备](ae2-mechanics/devices.md)一区域最多8个，除非你对[频道](ae2-mechanics/channels.md)在网络中的分布了解很深。
* 在所有[样板](items-blocks-machines/patterns.md)中只采用一种木材。允许样板使用替代材料偶尔确实有用，但在所有地方都用同种木材能大大减少麻烦。
* 在<ItemLink id="pattern_access_terminal" />中纵向排布[样板](items-blocks-machines/patterns.md)，或是将样板分到各[供应器](items-blocks-machines/pattern_provider.md)中以并行使用配方。
* 加入[能源元件](items-blocks-machines/energy_cells.md)以处理网络能量尖峰。
* 可向<ItemLink id="condenser" />输入水。
* 保持网络通畅的最好方式是不放入剑、盔甲之类的生物随机掉落物，每一种魔咒和耐久度的组合都分属不同[类型](ae2-mechanics/bytes-and-types.md)。
* 传输回[处理样板](items-blocks-machines/patterns.md)的产物时必须发生一次“物品输入系统”事件，例如通过<ItemLink id="import_bus" />、<ItemLink id="interface" />，或是<ItemLink id="pattern_provider" />的返回栏，不能只将产物输入接有<ItemLink id="storage_bus" />的箱子。
* 切记你可以旋转或缩放带有缩放和显隐注释图标的指南示例图。
* <ItemLink id="pattern_provider" />只会传出完整的配方材料批次且只会从一面传出。这在避免机器只拿到一部分材料上很有用，但有时会需要材料输入多个位置。这点可用<ItemLink id="interface" />实现，用作[“管道”子网络](example-setups/pipe-subnet.md)，或是利用其能同时存储多种不同的物品组、流体，化学品等的能力作为缓冲箱子/储罐。
* 可以旋转或缩放带有缩放和显隐注释图标的指南示例图。