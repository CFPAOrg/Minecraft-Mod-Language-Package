---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 接口
  icon: interface
  position: 210
categories:
- devices
item_ids:
- ae2:interface
- ae2:cable_interface
---

# 接口

<Row gap="20">
<BlockImage id="interface" scale="8" />
<GameScene zoom="8" background="transparent">
  <ImportStructure src="../assets/blocks/cable_interface.snbt" />
</GameScene>
</Row>

接口可视作小型箱子和流体储罐，能根据自身设置对[网络存储](../ae2-mechanics/import-export-storage.md)输入输出。其会尝试在单个游戏刻内完成输入输出，也即1游戏刻最多可传输9组物品，这也让其成为一种快速的输入输出手段，适用于快速物品管道。

接口还有一个实用特性，大多数流体储罐只能存储1种流体，而接口能存储最多9种，物品也是一样。它们实际上就是带有若干额外功能的箱子/多流体储罐，且可断开网络连接以禁用额外功能。因此，在某些需要存储少量多种事物的特定场合下，它们十分有用。

## 接口内部的工作原理

正如前文所提，接口本质上就是箱子和储罐，再附上一些超级酷炫的<ItemLink id="import_bus" />和<ItemLink id="export_bus" />以及<ItemLink id="level_emitter" />。

<GameScene zoom="3" interactive={true}>
  <ImportStructure src="../assets/assemblies/interface_internals.snbt" />

  <BoxAnnotation color="#dddddd" min="1.3 0.3 1.3" max="9.7 1 1.7">
        一系列标准发信器，用于维持设定的物品数量
        <GameScene zoom="4" background="transparent">
        <ImportStructure src="../assets/blocks/level_emitter.snbt" />
        </GameScene>
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="1.3 4 1.3" max="9.7 4.7 1.7">
        一系列标准发信器，用于维持设定的物品数量
        <GameScene zoom="4" background="transparent">
        <ImportStructure src="../assets/blocks/level_emitter.snbt" />
        </GameScene>
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="1.3 1.3 1.3" max="9.7 2 1.7">
        一系列超级酷炫的输入总线，每游戏刻能传输1组事物
        <GameScene zoom="4" background="transparent">
        <ImportStructure src="../assets/blocks/import_bus.snbt" />
        </GameScene>
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="1.3 3 1.3" max="9.7 3.7 1.7">
        一系列超级酷炫的输出总线，每游戏刻能传输1组事物
        <GameScene zoom="4" background="transparent">
        <ImportStructure src="../assets/blocks/export_bus.snbt" />
        </GameScene>
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="1 2 1" max="10 3 2">
        9个独立的内部槽位
  </BoxAnnotation>

  <IsometricCamera yaw="195" pitch="15" />
</GameScene>

## 特殊交互

接口和其他AE2[设备](../ae2-mechanics/devices.md)间有若干种特殊交互功能：

连接有<ItemLink id="storage_bus" />的未经修改的接口会将其所处网络的[网络存储](../ae2-mechanics/import-export-storage.md)向存储总线所处网络展示，此时接口网络就好像一整个接有存储总线的大箱子。在接口的过滤槽中设置物品会禁用此特性。

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/interface_storage.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

样板供应器和接口有一特殊交互效果——[子网络](../ae2-mechanics/subnetworks.md)：如果接口未经修改（请求槽内无内容），则供应器会跳过接口，直接输出到该子网络的[存储模块](../ae2-mechanics/import-export-storage.md)，而非输出到接口的存储槽；更重要的是，只要对应的存储模块没有足够的空间，下一批物品就不会输出。

<GameScene zoom="6" background="transparent">
<ImportStructure src="../assets/assemblies/provider_interface_storage.snbt" />

<BoxAnnotation color="#dddddd" min="2.7 0 1" max="3 1 2">
        接口（必须为面板型，不能为方块型）
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1 0 0" max="1.3 1 4">
        存储总线
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="0 0 0" max="1 1 4">
        样板供应目的地（多台机器，或单台机器的多个面）
  </BoxAnnotation>

<IsometricCamera yaw="185" pitch="30" />
</GameScene>

## 变种

接口有2种变种：普通、面板/[子部件](../ae2-mechanics/cable-subparts.md)。这会影响各面输出材料，接收物品，提供网络连接的能力。

*   普通型接口会向各面输出材料，会从各面接收物品，且和大多数AE2机器一样向各面提供网络连接，类似线缆。

*   面板型接口是[线缆子部件](../ae2-mechanics/cable-subparts.md)因此可在同一线缆上放置多个该种供应器，便于设计紧凑设施。它们能从其存储空间输出，或接收物品至存储空间，并给予其他事物访问其存储空间的权限，但不提供网络连接。

接口的普通和面板形态可在合成方格中转换。

## 设置

接口上排槽位设定需要存储于自身的物品。可直接放入或从JEI/REI中拖拽放入，有物品的槽位上方会出现扳手图标，可用其设置数量。

用流体容器（如铁桶或流体储罐）右击即可将流体设为过滤，而非铁桶和储罐物品。

## 升级

接口支持以下[升级](upgrade_cards.md)：

*   <ItemLink id="fuzzy_card" />使得接口能按耐久度或忽略物品NBT过滤
*   <ItemLink id="crafting_card" />使接口能向[自动合成](../ae2-mechanics/autocrafting.md)系统发送所需物品的请求；其会优先从存储中获取物品，无足够物品才会发送合成请求

## 优先级

可点击GUI右上角扳手以设置优先级。高优先级的接口会先于低优先级接口获取物品。

## 配方

<Recipe id="network/blocks/interfaces_interface" />

<RecipeFor id="cable_interface" />
