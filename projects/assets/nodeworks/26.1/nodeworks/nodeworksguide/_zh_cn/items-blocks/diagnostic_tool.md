---
navigation:
  parent: items-blocks/index.md
  icon: diagnostic_tool
  title: 诊断工具
categories:
  - tool
description: 考察网络拓扑、CPU、脚本，以及最近的错误信息
item_ids:
- nodeworks:diagnostic_tool
---

# 诊断工具

手持式节点工程网络考察诊断工具。右击网络中的任意方块可打开面板，其中会总结网络的组成和当前状态。

<ItemImage scale="6" id="diagnostic_tool" />

## 使用方法

右击目标网络的任意网络方块，<ItemLink id="node" />、<ItemLink id="terminal" />、<ItemLink id="network_controller" />、天线、存储器均可。也可点击[合成CPU](crafting_cpu.md)多方块（核心、缓存器、冷却器、载件、协处理器）的任意一处；工具会自行搜寻核心。

若所点击的方块不属于任何网络，工具便会通过叠加层消息告知，且不会打开面板。

## 显示内容

诊断面板会汇总网络公开的所有信息：

- **拓扑**。网络中的所有方块及其位置、类型，和各方块详情。<ItemLink id="node" />会列出各面的卡片与相邻的目标方块。
- **网络身份**。控制器的名称和颜色，附带其红石模式、handler重试上限、区块加载启用与否的概览。
- **CPU**。网络中的所有<ItemLink id="crafting_core" />，其当前的合成作业（若有）、缓存使用、效率，以及多方块是否正常形成。
- **终端**。网络中的所有<ItemLink id="terminal" />及其脚本列、自动运行标记、运行状态，以及各运行中脚本注册的[处理集](recipe_sets.md#处理集)handler。
- **可合成物品**。网络能自动合成的物品的完整列表，汇总自所有<ItemLink id="instruction_storage" />和<ItemLink id="processing_storage" />。
- **近期报错**。最近10次来自网络内终端的错误信息，附带错误发生到现在的时间（刻）。

此视图只读。你在其中如何点击都不会影响网络，它只是为厘清位置和错误而存在。

## 何时使用

- 合成失败，不想前去<ItemLink id="crafting_core" />周围也希望可以查看错误。
- 你刚接手一个大型复杂网络，需要一份地图。
- 你在尝试找出为何某配方无法自动合成；可合成物品列表会详尽显示网络实际知晓制作方式的物品。
- 脚本好像跑不通；终端面板会显示其运行状态和注册的handler，无需手动查看每一个终端。

## 配方

<RecipeFor id="diagnostic_tool" />
