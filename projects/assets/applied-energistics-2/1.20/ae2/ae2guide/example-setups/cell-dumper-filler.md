---
navigation:
  parent: example-setups/example-setups-index.md
  title: 元件清空器与装填器
  icon: io_port
---

# 元件清空器与装填器

有人可能会问：“怎么迅速将元件清空至箱子或者抽屉阵列或者背包，以及怎么从这些地方填满元件？”

答案便是使用<ItemLink id="io_port" />和限制其清空或装填位置的子网络。

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/cell_dumper_filler.snbt" />

<BoxAnnotation color="#dddddd" min="1 1 0" max="2 2 1">
        （1）IO端口：可使用GUI中间的箭头按钮将其设置为“从元件导入网络”或“传输数据到存储元件中”。装有3张加速卡。
        <ItemImage id="speed_card" scale="2" />
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="0 0.7 0" max="1 1 1">
        （2）存储总线：默认配置。
  </BoxAnnotation>

<BoxAnnotation color="#33dd33" min="0 1 0" max="1 2 1">
        在这里放置用于装填或清空的事物。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="2 0.35 0.35" max="2.3 0.65 0.65">
        石英纤维：仅在能量供给来自另一网络时必需。
  </BoxAnnotation>

<DiamondAnnotation pos="3 0.5 0.5" color="#00ff00">
        至能量源，例如另一网络和能源接收器。
    </DiamondAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 配置

* <ItemLink id="io_port" />（1）可使用GUI中间的箭头按钮将其设置为“从元件导入网络”或“传输数据到存储元件中”。装有3张加速卡以达到最大速度。
* <ItemLink id="storage_bus" />（2）处于默认配置。

## 工作原理

### “传输至网络”模式

1. <ItemLink id="io_port" />尝试将其中[存储元件](../items-blocks-machines/storage_cells.md)所存事物清空至[网络存储](../ae2-mechanics/import-export-storage.md)。
2. 子网络中唯一存储位置是<ItemLink id="storage_bus" />，可将物品，流体等事物存入放在其上的容器。
* <ItemLink id="energy_cell" />则提供了足够大的[能量缓存](../ae2-mechanics/energy.md)，以避免每游戏刻传输率过高导致能量耗尽。

### “传输至元件”模式

1. <ItemLink id="io_port" />尝试将[网络存储](../ae2-mechanics/import-export-storage.md)所存事物装填至其中[存储元件](../items-blocks-machines/storage_cells.md)。
2. 子网络中唯一存储位置是<ItemLink id="storage_bus" />, 可从放在其上的容器中抽出物品，流体等事物。
* <ItemLink id="energy_cell" />则提供了足够大的[能量缓存](../ae2-mechanics/energy.md)，以避免每游戏刻传输率过高导致能量耗尽。