---
navigation:
  parent: example-setups/example-setups-index.md
  title: 基于标准发信器的自动维持物品量
  icon: level_emitter
---

# 基于标准发信器的自动维持物品量

有人可能会问：“如何在库存中维持一定数量的物品，并在缺少时自动补足？”

解决方案之一便是使用<ItemLink id="export_bus" />、<ItemLink id="level_emitter" />，以及<ItemLink id="crafting_card" />以自动向网络的[自动合成](../ae2-mechanics/autocrafting.md)系统发送请求。这种设施更适用于维持大量单种物品。

也可以令网络持续合成，省略标准发信器和红石卡即可。

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/level_emitter_autostocking.snbt" />

  <BoxAnnotation color="#dddddd" min="1 1 0" max="2 1.3 1">
        （1）输出总线：设置为过滤所需物品。装有红石卡和合成卡。红石模式设置为“有红石信号时激活”，合成行为设置为“不使用已存储物品”。
        <Row><ItemImage id="redstone_card" scale="2" /> <ItemImage id="crafting_card" scale="2" /></Row>
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="0.7 1 0" max="1 2 1">
        （2）标准发信器：配置为所需数量个所需物品，设置为“当数量小于设定数值时发出红石信号”。
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="1 0 0" max="2 1 1">
        （3）接口：默认配置。
  </BoxAnnotation>

<DiamondAnnotation pos="4 0.5 0.5" color="#00ff00">
        至主网络
    </DiamondAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 配置

* <ItemLink id="export_bus" />（1）设置为过滤所需物品。装有<ItemLink id="redstone_card" />和<ItemLink id="crafting_card" />。“红石模式”设置为“有红石信号时激活”，“合成行为”设置为“不使用已存储物品”。
* <ItemLink id="level_emitter" />（2）配置为所需数量个所需物品，并设置为“当数量小于设定数值时发出红石信号”。
* <ItemLink id="interface" />（3）处于默认配置。

## 工作原理

1. 若[网络存储](../ae2-mechanics/import-export-storage.md)中所需物品的数量少于<ItemLink id="level_emitter" />中设定的值，则发信器会发出红石信号。
2. 在收到红石信号时，<ItemLink id="export_bus" />（装有<ItemLink id="crafting_card" />并设置为不使用已存储物品）会向网络的[自动合成](../ae2-mechanics/autocrafting.md)系统发送合成该物品的请求，并输出产物。
3. 在收到物品时，<ItemLink id="interface" />（未设置存储任何事物）会将其送入网络存储。