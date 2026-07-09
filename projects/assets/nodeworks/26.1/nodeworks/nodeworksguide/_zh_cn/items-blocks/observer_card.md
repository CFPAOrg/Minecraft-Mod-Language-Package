---
navigation:
  parent: items-blocks/index.md
  icon: observer_card
  title: 侦测卡
categories:
  - card
description: 读取节点面所朝方块的ID、属性、状态改变事件
item_ids:
- nodeworks:observer_card
---

# 侦测卡

读取卡片所安装面方向上的方块。公开方块的ID，方块的所有状态属性（`age`、`facing`、`waterlogged`、`lit`……），以及一个状态改变回调函数。脚本可用回调函数在方块变化至特殊状态时立即作出反应。

<ItemImage scale="6" id="observer_card" />

## 用途

受生长状态限制的农场是最主要的使用场景。连接至原版侦测器的活塞会在每一次生长阶段变化时伸出一次，也即会直接破坏小型晶芽得到1个碎片，而不会等候长成晶簇的4个碎片。脚本可以通过侦测卡直接读取生长阶段，并只在方块进入最后阶段时向破坏器发出脉冲。

它也是读取非红石信号状态的恰当工具：活板门开关、门状态、蜂箱蜂蜜水平、滴水石锥填充、阳光探测器读数、甜浆果/海带/甘蔗生长状态、方块下方冰/雪的形成，以至于任何具有可比较`BlockState`属性的事物。

## 安装与脚本

安装方式与<ItemLink id="io_card" />相同。详细步骤参见[IO卡安装](./io_card.md#安装)。侦测卡会读取*所处面*前方的方块。

所公开方法的详情参见[侦测卡脚本API](../lua-api/card-handle.md#侦测卡)。

## 频道

侦测卡的GUI中有一个频道选择器。有关频道限制脚本能否访问此卡片的详情，参见[选择频道](../lua-api/channel.md#选择频道)。

## 配方

<RecipeFor id="observer_card" />
