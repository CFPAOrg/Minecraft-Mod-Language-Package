---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: ME IO端口
  icon: io_port
  position: 210
categories:
- devices
item_ids:
- ae2:io_port
---

# ME IO端口

<BlockImage id="io_port" p:powered="true" scale="8" />

IO能以[网络存储](../ae2-mechanics/import-export-storage.md)迅速填满或清空[存储元件](../items-blocks-machines/storage_cells.md)。

可被<ItemLink id="certus_quartz_wrench" />旋转。

## 设置

*   IO端口可设置为在元件为空、元件装满、工序完成时将元件移至输出槽。
*   若装有<ItemLink id="redstone_card" />，则会出现红石信号相关的选项。
*   在GUI中央有一指示传输方向的箭头，方向可为从元件至[网络存储](../ae2-mechanics/import-export-storage.md)和从网络存储至元件。

## 升级

IO端口支持如下[升级](upgrade_cards.md)：

*   <ItemLink id="speed_card" />增加每次传输时移动的物品数
*   <ItemLink id="redstone_card" />加入红石控制功能，使其会在高信号、低信号、遇脉冲时启动

## 配方

<RecipeFor id="io_port" />
