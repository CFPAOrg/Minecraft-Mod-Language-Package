---
navigation:
  parent: example-setups/example-setups-index.md
  title: 专用本地存储
  icon: drive
---

# 专用本地存储

将[接口的特殊行为](../items-blocks-machines/interface.md#special-interactions)加以运用，就能让[子网络](../ae2-mechanics/subnetworks.md)不可访问主网络存储，而其存储内容又在主网络中可见，且只会占用最多1个[频道](../ae2-mechanics/channels.md)。

适用于某些农场的本地存储，可避免主网络存储物品过载。

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/local_storage.snbt" />

<BoxAnnotation color="#dddddd" min="4 0 0" max="5 2 1">
        （1）物品输入部分（此例中为接口）。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="3 0 0" max="4 1 1">
        （2）驱动器：装有若干元件。元件应过滤农场输出产物。可装有均分卡和溢出销毁卡。
        <Row><ItemImage id="item_storage_cell_4k" scale="2" /> <ItemImage id="equal_distribution_card" scale="2" /> <ItemImage id="void_card" scale="2" /></Row>
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="3 1 0" max="4 2 0.3">
        （3）合成终端：此终端可查看子网络驱动器的内容物，但无法查看主网络存储。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="2 0 0" max="2.3 1 1">
        （4）终端#2：默认配置。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1.7 0 0" max="2 1 1">
        （5）存储总线：优先级高于主存储，可过滤农场输出产物。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1 1 0" max="2 2 0.3">
        合成终端：此终端可同时查看主网络存储*和*子网络存储。
  </BoxAnnotation>

<DiamondAnnotation pos="0 0.5 0.5" color="#00ff00">
        至主网络
    </DiamondAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 配置

* 第一个<ItemLink id="interface" />（1）只会接受农场产物并送入子网络。
* <ItemLink id="drive" />（2）内装有若干[元件](../items-blocks-machines/storage_cells.md)。元件应被[分区](../items-blocks-machines/cell_workbench.md)为农场产物。元件可装有<ItemLink id="equal_distribution_card" />和<ItemLink id="void_card" />。
* 第二个<ItemLink id="interface" />（4）处于默认配置。
* <ItemLink id="storage_bus" />的[优先级](../ae2-mechanics/import-export-storage.md#storage-priority)高于主存储。可设置为过滤农场产物。

## 工作原理

* 子网络上的<ItemLink id="interface" />会向主网络上的<ItemLink id="storage_bus" />展示<ItemLink id="drive" />的内容物。也即存储总线可直接向该驱动器中的元件输入输出。
* 存储总线的[优先级](../ae2-mechanics/import-export-storage.md#storage-priority)较高，由此物品会优先放入子网络而非主网络。
* 重要的是，假如子网络的元件被填满了，多出的物品不会溢出至主网络。如果农场会因堵塞而失效，可装入<ItemLink id="void_card" />以删除多余物品。
* 如果农场产出多种物品，<ItemLink id="equal_distribution_card" />可避免产物之一填满所有元件而其余产物无法存储的情况。