---
navigation:
    parent: factory/factory-index.md
    title: "铁"
    icon: "woot_revived:iron_cell"
    position: 2
---
# 铁

第二等级的工厂。

## 结构

注意：预览中小号的伪刷怪笼为可选项

将<ItemImage id="layout" scale="0.5"/>[结构展示器](../machines-blocks/layout.md#copper)配置为第二等级来协助搭建

<GameScene zoom="2.5" interactive={true}>
    <ImportStructure src="../assets/factory/iron.snbt" />
    <IsometricCamera yaw="195" pitch="6" />
</GameScene>

## 铁级方块

<Row>
  <BlockImage id="iron_pylon" scale="4" p:attached="true" />
  <BlockImage id="iron_plinth" scale="4" p:attached="true" />
  <BlockImage id="iron_cell" scale="4" p:attached="true" />
</Row>


对于此工厂，你需要
20个<ItemImage id="iron_pylon" scale="0.5"/>铁塔柱，
12个<ItemImage id="iron_plinth" scale="0.5"/>铁柱基。
1个<ItemImage id="iron_cell" scale="0.5"/>铁生命单元

<Row>
  <RecipeFor id="iron_pylon" />
  <RecipeFor id="iron_plinth" />
  <RecipeFor id="iron_cell" />
</Row>