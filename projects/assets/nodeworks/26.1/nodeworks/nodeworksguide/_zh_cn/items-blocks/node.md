---
navigation:
  parent: items-blocks/index.md
  icon: node
  title: 节点
categories:
  - infrastructure
description: 管道网络中容纳和使用卡片的主体
item_ids:
- nodeworks:node
- nodeworks:focus_node
---

# 节点

节点是能保有[卡片](../nodeworks-mechanics/cards.md)的方块。网络的连接通过[管道](pipe.md)传递，如需在某处通过卡片与相邻的方块交互，将该处的管道替换为节点即可。

<BlockImage scale="6" id="node" />

## 面

节点每一面的功能都受相邻方块的影响。朝向其他网络方块的面会变为管道连接，同时禁用该面的卡片槽。朝向常规方块的面则可容纳卡片，并会以该方块为交互目标。

## 打开GUI

右击非管道面以打开卡片方格。Shift+右击可打开*背侧*面，在背侧面被阻挡时很好用。管道面无法打开，界面中这些面的标签也会变暗。

![](../assets/images/node_gui.png)

## 卡片

向设备面9个槽位中的任意一个放入一张卡片，可赋予该面相应能力：

- <ItemImage scale="0.5" id="io_card" /> <ItemLink id="io_card" />：可让网络向相邻方块送入/从中移出物品。
- <ItemImage scale="0.5" id="storage_card" /> <ItemLink id="storage_card" />：将相邻方块的物品栏标记为网络存储成员。
- <ItemImage scale="0.5" id="redstone_card" /> <ItemLink id="redstone_card" />：从该面读取和向该面发出红石信号。
- <ItemImage scale="0.5" id="observer_card" /> <ItemLink id="observer_card" />：读取所朝向方块的状态。

同一面中多张卡的能力可叠加。同时放有IO卡和红石卡的面能在该面上移动物品**和**发出红石信号。

## 焦准节点

<GameScene interactive={true} zoom="5">
  <IsometricCamera yaw="200" pitch="10" />
  <ImportStructure src="../assets/assemblies/focus_node.snbt" />
</GameScene>

<ItemLink id="focus_node" />是为长距连接设计的变种节点。使用<ItemLink id="network_wrench" />为两个焦准节点配对，网络即会将它们视作相连，即便中间没有管道。很适合用来连通管线缺口和跳过机器集群。

焦准节点六面的行为与常规的节点一致：同样的管道/设备/临空面交互模式，同样的卡片槽，同样的与相邻管道自动连接。扳手配对得到的链接叠加于相邻面功能之上，两者互不干扰。

## 配方

<RecipeFor id="node" />

<RecipeFor id="focus_node" />
