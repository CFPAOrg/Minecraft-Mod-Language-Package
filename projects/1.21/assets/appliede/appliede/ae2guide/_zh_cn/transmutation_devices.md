---
navigation:
  parent: appliede-index.md
  title: 转化设备
  icon: emc_interface
  position: 10
categories:
  - appliede
item_ids:
  - appliede:emc_interface
  - appliede:cable_emc_interface
  - appliede:emc_export_bus
  - appliede:emc_import_bus
  - appliede:learning_card
---

# 转化设备

<GameScene zoom="4" background="transparent">
  <ImportStructure src="assemblies/transmutation_devices.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

对应AE2既存的<ItemLink id="ae2:interface" />、<ItemLink id="ae2:export_bus" />、<ItemLink id="ae2:import_bus" />等，AppliedE添加了类似的各式设备。它们的功能和AE2的设备几乎完全一致，也仍然对普通的物品有效。关键的不同之处，则在于每次操作时，物品都会转化成EMC，或是从EMC转化回物品。

虽然这些设备可以设定为过滤任意物品，但相应的功能仍只对玩家在网络中<ItemLink id="appliede:emc_module">转化模块</ItemLink>处习得的物品生效。对于<ItemLink id="appliede:emc_interface" />来说，只有玩家已习得且网络已知晓的物品，才可进入其内部的存储空间，而后才会转化为EMC并送至相应的存储位置。<ItemLink id="appliede:emc_import_bus" />同样不会抽取未习得的物品。

## 炼金精通卡

<ItemImage id="learning_card" scale="4" />

然而，要是所有物品都必须预先习得才可在ME网络中转化成EMC，单是繁琐的操作就能逼退兴趣。为解决这一问题，可向<ItemLink id="appliede:emc_interface" />或<ItemLink id="appliede:emc_import_bus" />装入<ItemLink id="appliede:learning_card" />；此后这些设备便会在送入存在EMC值的物品时自动习得它们。

不过有一点需要注意，只有相应设备的所有者（接口、输入总线、或将物品送入接口的网络设备的放置者）才能习得这些物品。

## 配方

<RecipeFor id="appliede:emc_interface" />
<RecipeFor id="appliede:emc_export_bus" />
<RecipeFor id="appliede:emc_import_bus" />
<RecipeFor id="appliede:learning_card" />
