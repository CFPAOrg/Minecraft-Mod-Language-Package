---
navigation:
    parent: factory/factory-index.md
    title: "金"
    icon: "woot_revived:gold_cell"
    position: 3
---
# 金

第三等级的工厂。

## 结构

注意：预览中小号的伪刷怪笼为可选项

将<ItemImage id="layout" scale="0.5"/>[结构展示器](../machines-blocks/layout.md#copper)配置为第三等级来协助搭建

<GameScene zoom="2.5" interactive={true}>
    <ImportStructure src="../assets/factory/gold.snbt" />
    <IsometricCamera yaw="195" pitch="6" />
</GameScene>

## 金级方块

<Row>
  <BlockImage id="gold_pylon" scale="4" p:attached="true" />
  <BlockImage id="gold_plinth" scale="4" p:attached="true" />
  <BlockImage id="gold_cell" scale="4" p:attached="true" />
</Row>


对于此工厂，你需要
36个<ItemImage id="gold_pylon" scale="0.5"/>金塔柱，
24个<ItemImage id="gold_plinth" scale="0.5"/>金柱基，
1个<ItemImage id="gold_cell" scale="0.5"/>金生命单元

<Row>
  <RecipeFor id="gold_pylon" />
  <RecipeFor id="gold_plinth" />
  <RecipeFor id="gold_cell" />
</Row>