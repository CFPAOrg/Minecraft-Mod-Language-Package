---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 能源元件
  icon: energy_cell
  position: 110
categories:
- network infrastructure
item_ids:
- ae2:energy_cell
- ae2:dense_energy_cell
- ae2:creative_energy_cell
---

# 能源元件

<Row gap="20">
  <BlockImage id="energy_cell" scale="8" p:fullness="4" />

  <BlockImage id="dense_energy_cell" scale="8" p:fullness="4" />

  <BlockImage id="creative_energy_cell" scale="8" />
</Row>

能源元件给予网络更大的[能量](../ae2-mechanics/energy.md)容量。一定量的能量缓存能减少大量输入输出造成的能量尖峰影响，更大的能量存储容量则使得网络能在脱离供电时（例如晚上的太阳能板阵列）运作，也可处理[空间存储](../ae2-mechanics/spatial-io.md)产生的巨量瞬时能量消耗。

## 填充条

<Row>
<BlockImage id="energy_cell" scale="4" p:fullness="0" />
<BlockImage id="energy_cell" scale="4" p:fullness="1" />
<BlockImage id="energy_cell" scale="4" p:fullness="2" />
<BlockImage id="energy_cell" scale="4" p:fullness="3" />
<BlockImage id="energy_cell" scale="4" p:fullness="4" />
</Row>

元件侧面的填充条对应其能量水平。

*   充满程度少于25%时为0。
*   充满程度在25%到50%之间时为1。
*   充满程度在50%到75%之间时为2。
*   充满程度在75%到99%之间时为3。
*   充满程度超过99%时为4。

## 元件种类

*   <ItemLink id="energy_cell" />可存储200kAE，这能轻松应对普通网络的能量尖峰；通常，每个网络中放一个就够了。
*   <ItemLink id="dense_energy_cell" />可存储1.6MAE，适用于脱离能量供应运行网络的情况和处理大型[空间存储](../ae2-mechanics/spatial-io.md)的巨量瞬时能量消耗。
*   <ItemLink id="creative_energy_cell" />是用于测试的创造模式物品，能提供无！限！能！量！

## 配方

<Row>
  <RecipeFor id="energy_cell" />

  <RecipeFor id="dense_energy_cell" />
</Row>
