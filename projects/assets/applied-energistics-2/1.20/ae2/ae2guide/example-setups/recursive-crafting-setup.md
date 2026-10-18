---
navigation:
  parent: example-setups/example-setups-index.md
  title: 递归合成
  icon: minecraft:netherite_upgrade_smithing_template
---

# 递归合成设施

如[自动合成](../ae2-mechanics/autocrafting.md)中所说，自动合成规划算法无法处理首要输出同时是输入的配方。例如，它无法处理复制<ItemLink id="minecraft:netherite_upgrade_smithing_template" />的配方。

解决方案之一便是将<ItemLink id="level_emitter" />用作[样板](../items-blocks-machines/patterns.md)。

此后，便可以运用该标准发信器，启动一个持续合成的小设施即可。本节我们主要以复制<ItemLink id="minecraft:netherite_upgrade_smithing_template" />的设施为例。

<RecipeFor id="minecraft:netherite_upgrade_smithing_template" />

***

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/recursive_recipe_setup.snbt" />

  <BoxAnnotation color="#dddddd" min="1 0 0" max="2 1 1">
        （1）接口：设置为存储所需的额外材料：钻石和下界岩。
        <Row><ItemImage id="minecraft:diamond" scale="2" /> <ItemImage id="minecraft:netherrack" scale="2" /></Row>
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="2.3 1 0.3" max="2.7 1.3 0.7">
        （2）标准发信器：配置为“下界合金升级锻造模板”，设置为“发出红石信号以合成物品”。
        <Row><ItemImage id="minecraft:netherite_upgrade_smithing_template" scale="2" /> <ItemImage id="crafting_card" scale="2" /></Row>
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="2 0 0" max="2.3 1 1">
        （3）输入总线#1：过滤接口所存储的物品。装有红石卡。红石模式设置为“有红石信号时激活”。
        <Row>
        <ItemImage id="minecraft:diamond" scale="2" />
        <ItemImage id="minecraft:netherrack" scale="2" />
        <ItemImage id="redstone_card" scale="2" />
        </Row>
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="3 1 1" max="4 1.3 2">
        （4）存储总线#1：优先级高于另一个存储总线。非常重要。
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="3 0 1" max="4 1 2">
        （5）分子装配室：装有复制锻造模板的样板。

        ![样板](../assets/diagrams/smithing_template_pattern_small.png)

        搭建时需向其中手动放入一个锻造模板。
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="2.7 0 1" max="3 1 2">
        （6）输入总线#2：默认配置。
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="1 0 1" max="2 1 1.3">
        （7）存储总线#2：过滤“下界合金升级锻造模板”。优先级低于另一个存储总线。
        <ItemImage id="minecraft:netherite_upgrade_smithing_template" scale="2" />
  </BoxAnnotation>

<DiamondAnnotation pos="0 0.5 0.5" color="#00ff00">
        至主网络
    </DiamondAnnotation>

  <IsometricCamera yaw="15" pitch="30" />
</GameScene>

## 配置

* <ItemLink id="interface" />（1）设置为存储所需的额外材料：钻石和下界岩。
* <ItemLink id="level_emitter" />（2）配置为“下界合金升级锻造模板”，设置为“发出红石信号以合成物品”。
* 第一个<ItemLink id="import_bus" />（3）设置为过滤接口所存储的物品。装有红石卡。红石模式设置为“有红石信号时激活”。
* 第一个<ItemLink id="storage_bus" />（4）的[优先级](../ae2-mechanics/import-export-storage.md#storage-priority)需*高于*第二个存储总线。
* <ItemLink id="molecular_assembler" />（5）装有复制锻造模板的样板，以及一个手动放入的锻造模板。

  ![样板](../assets/diagrams/smithing_template_pattern.png)

* 第二个<ItemLink id="import_bus" />（6）处于默认配置。
* 第二个<ItemLink id="storage_bus" />（7）设置为过滤“下界合金升级锻造模板”。其[优先级](../ae2-mechanics/import-export-storage.md#storage-priority)*低于*第一个存储总线。

## 工作原理

1. 由于其装有<ItemLink id="crafting_card" />且设置为“发出红石信号以合成物品”，<ItemLink id="level_emitter" />相当于一个[样板](../items-blocks-machines/patterns.md)。“下界合金升级锻造模板”会出现在[终端](../items-blocks-machines/terminals.md)中作为可[自动合成](../ae2-mechanics/autocrafting.md)物品。
2. 收到来自玩家或系统的合成请求时，标准发信器会开启。
3. 第一个<ItemLink id="import_bus" />被标准发信器激活，并从<ItemLink id="interface" />中抽出材料。
4. 网络中能存储这些材料的<ItemLink id="storage_bus" />仅有装配室上的。
5. <ItemLink id="molecular_assembler" />收到材料（其中已有1个锻造模板），开始合成，产出2个锻造模板。
6. 第二个<ItemLink id="import_bus" /> 抽出1个锻造模板。
7. 第一个存储总线的优先级更高，因此锻造模板会返回装配室。
8. 第二个<ItemLink id="import_bus" /> 抽出1个锻造模板。
9. 装配室无法再接受锻造模板，因此第二个锻造模板会进入低优先级存储总线，并送入接口。
10. <ItemLink id="interface" />（未设置存储锻造模板）会将其送回网络。