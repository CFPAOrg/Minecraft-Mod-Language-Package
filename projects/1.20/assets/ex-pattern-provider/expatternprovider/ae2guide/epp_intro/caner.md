---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME装罐机
    icon: expatternprovider:caner
categories:
- extended devices
item_ids:
- expatternprovider:caner
---

# ME装罐机

<BlockImage id="expatternprovider:caner" scale="8"></BlockImage>

ME装罐机是一个“罐装”东西的机器，包括液体、Mekanism气体、能量甚至植物魔法！ 第一个槽放置需要被填充的物品，第二个槽放置用来容纳它的容器；排空模式反之亦然。它需要能源来运行，每次操作花费80AE。

![GUI](../pic/caner_gui.png)

默认情况下，它只填充液体，你需要安装相应的Mod，使其能填充其它东西。

### 支持的Mod:
- Applied Flux
- 应用能源：通用机械附属
- 应用能源：植物魔法附属

## 连接ME装罐机

只有顶部和底部可以输入能量并连接到网络。

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../structure/caner_example.snbt"></ImportStructure>
</GameScene>

对于ME装罐机有一个简便的处理方法：ME装罐机将自动弹出到由<ItemLink id="ae2:pattern_provider" />输入的物品。

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../structure/caner_auto.snbt"></ImportStructure>
</GameScene>

该模式的样板必须只包含要填充的材料和要填充的容器。
以下是一些例子:

装满水桶：

![P1](../pic/fill_water.png)

充满能量板（需要”应用能源：通用机械附属“）：

![P1](../pic/fill_energy.png)


## 排空模式

你也可以在排空模式下从容器中排出物品。只需要点击模式切换按钮切换输入和输出模式。
