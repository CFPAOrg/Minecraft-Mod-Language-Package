---
navigation:
    parent: factory/factory-index.md
    title: "铜"
    icon: "woot_revived:copper_cell"
    position: 1
---
# 铜

最初等级的工厂，也是其最基础的版本。

对于本模组起步来说十分完美，也可用于搭建基础的生物工厂！

## 结构

首先需要建造工厂的中央基座，然后即可完成周围部分的搭建

将<ItemImage id="layout" scale="0.5"/>[结构展示器](../machines-blocks/layout.md#copper)配置为最初等级来协助搭建

<Row>
    <GameScene zoom="2.5" interactive={true}>
        <ImportStructure src="../assets/factory/copper_half.snbt" />
        <IsometricCamera yaw="195" pitch="6" />
    </GameScene>

    <GameScene zoom="2.5" interactive={true}>
        <ImportStructure src="../assets/factory/copper.snbt" />
        <IsometricCamera yaw="195" pitch="6" />
    </GameScene>
</Row>

## 铜级方块

<Row>
  <BlockImage id="copper_pylon" scale="4" p:attached="true" />
  <BlockImage id="copper_plinth" scale="4" p:attached="true" />
  <BlockImage id="copper_cell" scale="4" p:attached="true" />
</Row>

工厂除了[通用方块](common-blocks.md)之外，还需要一些等级特定的方块

对于此工厂，你需要
17个<ItemImage id="copper_pylon" scale="0.5"/>铜塔柱，
6个<ItemImage id="copper_plinth" scale="0.5"/>铜柱基，
1个<ItemImage id="copper_cell" scale="0.5"/>铜生命单元

<Row>
  <RecipeFor id="copper_pylon" />
  <RecipeFor id="copper_plinth" />
  <RecipeFor id="copper_cell" />
</Row>