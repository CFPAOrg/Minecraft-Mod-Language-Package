---
navigation:
  parent: nodeworks-mechanics/index.md
  title: 网络存储
  icon: minecraft:chest
categories:
  - mechanic
---

# 网络存储

网络存储是节点工程网络视为自身具有的物品/流体共享储存空间。所有安装有<ItemLink id="storage_card" />的方块均为该空间的成员。脚本可对其读写，<ItemLink id="inventory_terminal" />能显示它和与它交互，合成系统则能从中取出原材料。

<GameScene zoom="5" interactive={true} paddingLeft="50" paddingRight="60">
  <ImportStructure src="../assets/assemblies/network_storage.snbt" />
  <BoxAnnotation min="2.25 1.1 0.1" max="2 1.9 0.9" color="#AA83E0">
    <ItemImage id="nodeworks:storage_card" />将此箱子纳入网络存储
  </BoxAnnotation>
  <BoxAnnotation min="2.25 0.1 0.1" max="2 0.9 0.9" color="#AA83E0">
    <ItemImage id="nodeworks:storage_card" />将此箱子纳入网络存储
  </BoxAnnotation>
  <BlockAnnotation x="3" y="1" z="0">
    可以通过<ItemLink id="inventory_terminal" />查看网络存储
  </BlockAnnotation>
</GameScene>

## 网络存储空间的成员

绑定至<ItemLink id="storage_card" />的所有方块的所有内容物。若破坏了存储卡的节点连接，则相应方块会立即脱离网络存储。

### 非空间成员

<ItemLink id="io_card" />对应的方块不是网络存储的成员。脚本需要显式对IO卡方块送入/取出物品。网络无法通过`network:find`查看这些方块的内容物，<ItemLink id="inventory_terminal" />和<ItemLink id="portable_inventory_terminal" />也不会列出它们。

## 优先级与路由

每一张<ItemLink id="storage_card" />都有其**优先级**，用于控制`network:insert`/`:tryInsert`的填充顺序。写操作会首先前往优先级最高、相匹配的卡片，并在填满后溢出到优先级较低的卡片。同优先级的卡片按连接顺序填充。

脚本可通过[`network:route`](../lua-api/network.md#route)注册路由而覆盖默认的优先级顺序。

可在卡片的GUI内直接设置其优先级，界面详情参见[存储卡](../items-blocks/storage_card.md#配置)。也可使用<ItemLink id="card_programmer" />一次性为多张卡片复制优先级（以及所有其他卡片设置）。

## 与网络存储相关的脚本

与网络存储交互所用读写函数的完整列表参见[网络API](../lua-api/network.md)页面。

## 通过物品栏终端进行查看和管理

<Row align="center">
  <BlockImage scale="3.3" id="inventory_terminal" />
  <ItemImage scale="4" id="portable_inventory_terminal" />
</Row>

<ItemLink id="inventory_terminal" />和<ItemLink id="portable_inventory_terminal" />是不依赖脚本查看网络存储和与之交互的主要方式。它们会在槽位方格内显示网络存储的内容，允许你搜索、从中取出物品、放入物品，以及请求合成。它们会向网络中的各存储卡实时获取内容。

界面详情参见[物品栏终端](../items-blocks/inventory_terminal.md)页面。
