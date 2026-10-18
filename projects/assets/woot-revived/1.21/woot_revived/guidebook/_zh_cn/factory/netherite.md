---
navigation:
    parent: factory/factory-index.md
    title: "下界合金"
    icon: "woot_revived:netherite_cell"
    position: 5
---
# 下界合金

第五等级，也是最高等级的工厂。

## 结构

注意：预览中小号的伪刷怪笼为可选项

将<ItemImage id="layout" scale="0.5"/>[结构展示器](../machines-blocks/layout.md#copper)配置为第五等级来协助搭建

<GameScene zoom="2.5" interactive={true}>
    <ImportStructure src="../assets/factory/netherite.snbt" />
    <IsometricCamera yaw="195" pitch="6" />
</GameScene>

## 下界合金级方块

<Row>
  <BlockImage id="netherite_pylon" scale="4" p:attached="true" />
  <BlockImage id="netherite_plinth" scale="4" p:attached="true" />
  <BlockImage id="netherite_cell" scale="4" p:attached="true" />
</Row>


对于此工厂，你需要
12个<ItemImage id="netherite_pylon" scale="0.5"/>下界合金塔柱，
24个<ItemImage id="netherite_plinth" scale="0.5"/>下界合金柱基
1个<ItemImage id="netherite_cell" scale="0.5"/>下界合金生命单元

<Row>
  <RecipeFor id="netherite_pylon" />
  <RecipeFor id="netherite_plinth" />
  <RecipeFor id="netherite_cell" />
</Row>