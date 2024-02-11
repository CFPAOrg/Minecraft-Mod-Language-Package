---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: ME存储总线
  icon: storage_bus
  position: 220
categories:
- devices
item_ids:
- ae2:storage_bus
---

# 存储总线

<GameScene zoom="8" background="transparent">
<ImportStructure src="../assets/blocks/storage_bus.snbt" />
</GameScene>

有想过*不把*箱子仓库换成其他更合理的设施吗？我们为此推出了存储总线！

存储总线会将其所连接的容器视为[网络存储](../ae2-mechanics/import-export-storage.md)。它使得网络能查看该容器的内容物，并可对该容器输入输出以满足[设备](../ae2-mechanics/devices.md)的输入输出需求。

鉴于AE2的[设备](../ae2-mechanics/devices.md)功能交互产生涌现机制的哲学，存储总线*并不*只具有*存储*功能。如果将[子网络](../ae2-mechanics/subnetworks.md)的*唯一*存储位置设置为若干存储总线，就可将这些总线视为物品传输的起点或终点。（见[“管道”子网络](../example-setups/pipe-subnet.md)。）

存储总线是[线缆子部件](../ae2-mechanics/cable-subparts.md)。

## 过滤

默认情况下，存储总线会存储所有事物。放入其过滤槽的物品会加入白名单，也即只会存储其中指明的事物。

如果没有所需物品或流体，可从JEI/REI中拖拽以放入过滤槽。

用流体容器（如铁桶或流体储罐）右击即可将流体设为过滤，而非铁桶和储罐物品。

## 优先级

可点击GUI右上角扳手以设置优先级。输入网络的物品会优先进入最高优先级的存储位置，如果有两个优先级相同的存储位置，则会优先选择已经存有该物品的那个。所有白名单元件在同优先级情况下视作已经存有该物品。从存储中输出的物品会优先从最低优先级的位置输出。这一优先级系统使得在输入输出物品的过程中，高优先级的存储位置会被填满，而低优先级的会被搬空。

## 设置

*   存储总线可分区（过滤）为相邻容器当前的内容物。
*   可设置相邻容器中无法被总线抽出的物品是否对网络可见（例如，存储总线无法从<ItemLink id="inscriber" />的中间输入槽中抽出物品）。
*   存储总线可设置为双向过滤或仅过滤存入操作。
*   存储总线可为双向、仅存入、仅输出。

## 升级

存储总线支持以下[升级](upgrade_cards.md)：

*   <ItemLink id="capacity_card" />增加过滤槽位数
*   <ItemLink id="fuzzy_card" />使得总线能按耐久度或忽略物品NBT过滤
*   <ItemLink id="inverter_card" />将白名单变为黑名单
*   <ItemLink id="void_card" />会在对应容器为满时清空输入的物品，可避免农场产物堆积。设置分区的时候要小心！

## 配方

<RecipeFor id="storage_bus" />
