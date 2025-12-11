---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 成型面板
  icon: formation_plane
  position: 210
categories:
- devices
item_ids:
- ae2:formation_plane
---

# 成型面板

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../assets/blocks/formation_plane.snbt" />
</GameScene>

成型面板能放置方块和投出物品。它会在[设备](../ae2-mechanics/devices.md)（如<ItemLink id="import_bus" />和<ItemLink id="interface" />）将物品存入[网络存储](../ae2-mechanics/import-export-storage.md)时放置或投出它们，与仅存入的<ItemLink id="storage_bus" />工作方式类似。

<GameScene zoom="8" interactive={true}>
  <ImportStructure src="../assets/assemblies/formation_plane_demonstration.snbt" />
  <IsometricCamera yaw="255" pitch="30" />
</GameScene>

注意，这些设备在[管道子网络](../example-setups/pipe-subnet.md)中类似输入总线 -> 存储总线和接口 -> 存储总线。

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/import_storage_pipe.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/interface_storage_pipe.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

在[管道子网络](../example-setups/pipe-subnet.md)等设施中，此[设备](../ae2-mechanics/devices.md)的行为方式类似存储总线；如果需要放置方块或投出物品而非传输的话，也能替代存储总线。

成型面板是[线缆子部件](../ae2-mechanics/cable-subparts.md)。

**记得在你认领的区块内允许放置假玩家**

## 过滤

默认情况下，成型面板不会放置或投出任何东西。放入其过滤槽的物品会加入白名单，也即只会放置其中指明的事物。

如果没有所需物品或流体，可从JEI/REI中拖拽以放入过滤槽。

用流体容器（如铁桶或流体储罐）右击即可将流体设为过滤，而非铁桶和储罐物品。

## 优先级

单击GUI右上角扳手图标以设置优先级。进入网络的物品会优先送至优先级最高的存储位置。

## 设置

*   成型面板可设置为放置方块或投出物品。

## 升级

成型面板支持如下[升级](upgrade_cards.md)：

*   <ItemLink id="capacity_card" />增加过滤槽位数
*   <ItemLink id="fuzzy_card" />使得面板能按耐久度或忽略物品NBT过滤
*   <ItemLink id="inverter_card" />将白名单变为黑名单

## 配方

<RecipeFor id="formation_plane" />
