---
navigation:
  parent: items-blocks/index.md
  icon: processing_handler
  title: 处理操作器
categories:
  - autocrafting
description: 使用微型网络注册一个处理集handler
item_ids:
- nodeworks:processing_handler
---

# 处理操作器

适用于[处理集](./recipe_sets.md#处理集)配方的方块型handler。放置处理操作器，接入网络，再为其绑定配方，[合成CPU](./crafting_cpu.md)即会将配方的原材料路由到机器中，并将产物拉回网络，整个过程无需Lua脚本参与。

<GameScene zoom="5" interactive={true} paddingLeft="30" paddingRight="30">
  <IsometricCamera yaw="160" roll="0" pitch="10" />
  <ImportStructure src="../assets/assemblies/basic_processing_handler.snbt" />
  <BoxAnnotation min="0 2 0" max="1 2.25 1" color="#3C44AA">
    指向熔炉顶面的蓝色频道存储卡
  </BoxAnnotation>
  <BoxAnnotation min="0 0.75 0" max="1 1 1" color="#B02E26">
    指向熔炉底面的红色频道存储卡
  </BoxAnnotation>
</GameScene>

## 操作器的两个面

操作器区分前面和后面：

- **后面**：接入包含<ItemLink id="crafting_core" />和<ItemLink id="processing_storage" />的父网络。
- **前面**：接入其自身组建，由管道、节点、存储卡组成的**微型网络**操作器相当于该网络的控制器，所以该网络无需（也不允许）加入<ItemLink id="network_controller" />。

将操作器的后面接回主网络，再从前面为实际处理配方的机器接线。

## 绑定配方

右击操作器打开GUI，在其中选择父网络处理存储器内的一张<ItemLink id="processing_set" />。处理集中的每一种原材料都各居一行，且各配有频道颜色，外加一行用于配方输出。

## 频道路由

操作器使用频道决定微型网络中哪些<ItemLink id="storage_card" />收到哪些物品：

- **输入频道**（每种原材料各一个，默认蓝色）。CPU开始合成作业时，各项输入会被送至微型网络中频道匹配该原材料颜色的存储卡。
    - *若需要借助表达式、物品数据、可堆叠性等自定义路由：输入物品会遵守存储卡的筛选器*
- **输出频道**（共用同一个颜色，默认红色）。操作器会监测微型网络中在此频道下的存储卡，并将产物抽出送回父网络。

对于上方的熔炉示例场景：熔炉顶面的蓝色存储卡接收待烧炼的输入，熔炉进行加工，底部的红色存储卡则抽出产物。

若机器需要不同原材料进入不同槽位，也可让不同原材料使用不同的颜色。比如要求输入进入某一面，燃料进入另一面时。

## 与脚本handler对比

处理操作器是[`network:handle(...)`](../lua-api/network.md#handle)的无脚本版本。若配方形同“送原材料出产物”，则使用操作器；如需处理自定义时序或多步流程，请使用脚本handler。

## 配方

<RecipeFor id="processing_handler" />
