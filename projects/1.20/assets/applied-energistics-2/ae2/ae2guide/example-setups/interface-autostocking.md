---
navigation:
  parent: example-setups/example-setups-index.md
  title: 基于接口的自动维持物品量
  icon: interface
---

# 基于接口的自动维持物品量

有人可能会问：“如何在库存中维持一定数量的物品，并在缺少时自动补足？”

解决方案之一便是使用装有<ItemLink id="crafting_card" />的<ItemLink id="interface" />以自动向网络的[自动合成](../ae2-mechanics/autocrafting.md)系统发送请求。这种设施更适用于维持少量多种物品。

此演示设施经过截短以便于缩减宽度，使用4个<ItemLink id="interface" />和4个<ItemLink id="storage_bus" />应当最为高效，可完全占用普通[线缆](../items-blocks-machines/cables.md)的所有8个[频道](../ae2-mechanics/channels.md)。

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/interface_autostocking.snbt" />

<BoxAnnotation color="#dddddd" min="0 0 0" max="2 1 1">
        （1）接口：设置为在自身处存储所需物品。装有合成卡。
        <ItemImage id="crafting_card" scale="2" />
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="0 1 0" max="2 1.3 1">
        （2）存储总线：“输入/输出模式”设置为“仅取出”。
  </BoxAnnotation>

<DiamondAnnotation pos="4 0.5 0.5" color="#00ff00">
        至主网络
    </DiamondAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 配置

* <ItemLink id="interface" />（1）设置为在自身处存储所需物品，将物品直接放入或从JEI中拖拽入上排槽位，然后点击槽位上方扳手图标以设置数量。装有<ItemLink id="crafting_card" />。
* <ItemLink id="storage_bus" />（2）的“输入/输出模式”设置为“仅取出”。

## 工作原理

1. 若<ItemLink id="interface" />无法从[网络存储](../ae2-mechanics/import-export-storage.md)中获得足量所配置的物品（且其装有<ItemLink id="crafting_card" />），则其会向网络的[自动合成](../ae2-mechanics/autocrafting.md)系统发送合成该物品的请求。
2. <ItemLink id="storage_bus" />允许网络访问接口的内容物。