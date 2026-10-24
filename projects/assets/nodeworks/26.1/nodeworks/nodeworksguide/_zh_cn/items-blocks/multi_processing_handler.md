---
navigation:
  parent: items-blocks/index.md
  icon: multi_processing_handler
  title: 多处理操作器
categories:
  - autocrafting
  - requires_controller
description: 能处理多个处理集配方的单个handler
item_ids:
- nodeworks:multi_processing_handler
---

# 多处理操作器

能同时操作多个[处理集](./recipe_sets.md#处理集)的<ItemLink id="processing_handler" />。将多个矿石处理配方绑定至放在熔炉组前的同一个处理器，[合成CPU](./crafting_cpu.md)便会将相应的合成作业路由至它，无需Lua脚本也无需为每个配方注册handler。

> 需要<ItemLink id="network_controller" />才可使用

<GameScene zoom="3" interactive={true} paddingLeft="50" paddingRight="50" paddingTop="30">
  <IsometricCamera yaw="160" roll="0" pitch="10" />
  <ImportStructure src="../assets/assemblies/multi_processor_handler.snbt" />
  <BoxAnnotation min="0 2 0" max="1 2.25 1" color="#3C44AA">
    <ItemImage id="storage_card" />蓝色频道存储卡
  </BoxAnnotation>
  <BoxAnnotation min="0 0.75 0" max="1 1 1" color="#B02E26">
    <ItemImage id="storage_card" />红石频道存储卡
  </BoxAnnotation>
  <BlockAnnotation x="2" y="1">
    配置为多个烧炼配方。
  </BlockAnnotation>
</GameScene>

## 两个面

样式和处理操作器一致：**后面**接入主网络，**前面**接入由管道、节点、存储卡组成的微型网络。排布方式参见[操作器的两个面](./processing_handler.md#操作器的两个面)。

## 选择配方

右击操作器可打开其GUI。其中会列出主网络中的所有处理集，各项附带一个勾选框。勾选该操作器应接受的配方即可。勾选的配方会置顶，搜索框可按配方或物品名缩小列表范围。

角落处的计数器会显示当前勾选数量和数量上限。脚本或其他操作器拥有的配方会变灰，达到数量上限后所有配方都会变灰。

后续离开处理存储器的勾选配方会被标记为缺失，以便取消勾选。处理集回到网络后配方也会恢复。

## 频道

一个输入频道和一个输出频道，所有配方共享。勾选配方的原材料会进入微型网络中输入频道下的<ItemLink id="storage_card" />，所得产物则从输出频道下的卡片处抽取。对于熔炉组而言，可在各熔炉顶部使用蓝色频道卡片，底部使用红色频道卡片。

所有原材料的频道均相同，因此具体的筛选由卡片实现。为每一张存储卡设置[筛选器](./storage_card.md#筛选器)，此后便只有匹配的物品会进入它对应的方块：各熔炉侧面允许`#c:coal`通过的卡片接受燃料，顶面禁止该标签通过的接受矿石，且两者都需在蓝色频道上。

![](../assets/images/in_out_channels.png)

## 并行模式

默认情况下，操作器同一时刻只会运行一个合成作业，来自同一个合成树的多个配方会依次排序，而不会竞争熔炉的使用权。等待配方的协处理器会转而处理其他配方。若不想这样，可点击**并行**开关，让合成作业并行运行。

![](../assets/images/parallel_toggle.png)

## 和处理操作器比较

若配方需要单独的机器，或不同原材料需要不同的频道，应使用<ItemLink id="processing_handler" />。若多个配方可共享同一个机器组，且所有配方的路由方式相同，可使用多处理操作器。

## 配方

<RecipeFor id="multi_processing_handler" />
