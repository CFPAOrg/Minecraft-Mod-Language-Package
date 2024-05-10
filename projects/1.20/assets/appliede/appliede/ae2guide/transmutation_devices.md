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

作为AE2既存<ItemLink id="ae2:interface" />、<ItemLink id="ae2:export_bus" />、<ItemLink id="ae2:import_bus" />等的对应，AppliedE添加了类似的各式设备。它们的功能和AE2原版的设备几乎完全一致，对普通的物品也仍然有效。关键的不同之处，则在于每次操作时，物品都会转化成EMC，或是从EMC转化回物品。

虽然这些设备可以设定为过滤任意物品，但相应的功能仍只对任意一位玩家在网络中<ItemLink id="appliede:emc_module">转化模块</ItemLink>处习得的物品生效。对于<ItemLink id="appliede:emc_interface" />来说，只有玩家已习得且网络已知晓的物品，才可进入其内部的存储空间，而后才会转化为EMC并送至相应的存储位置。<ItemLink id="appliede:emc_import_bus" />同样不会抽取未习得的物品。

## 炼金精通卡

<ItemImage id="learning_card" scale="4" />

然而，若是所有物品都必须预先习得才可在ME网络中转化成EMC，由此而来的重复劳动很快就会变得索然无味。为解决这一问题，可向<ItemLink id="appliede:emc_interface" />或<ItemLink id="appliede:emc_import_bus" />装入<ItemLink id="appliede:learning_card" />；此后它们便会在送入存在EMC值的物品时自动习得物品。

不过有一点需要注意，这些物品只会被相应设备的所有者（也即放下端口或输入总线的玩家）习得。

## 配方

<Recipe id="appliede:emc_interface" />
<Recipe id="appliede:emc_export_bus" />
<Recipe id="appliede:emc_import_bus" />
<Recipe id="appliede:learning_card" />
