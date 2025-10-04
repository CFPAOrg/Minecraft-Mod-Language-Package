---
navigation:
    parent: factory/factory-index.md
    title: "钻石"
    icon: "woot_revived:diamond_cell"
    position: 4
---
# 钻石

第四等级的工厂。

## 结构

注意：预览中小号的伪刷怪笼为可选项

将<ItemImage id="layout" scale="0.5"/>[结构展示器](../machines-blocks/layout.md#copper)配置为第四等级来协助搭建

<GameScene zoom="2.5" interactive={true}>
    <ImportStructure src="../assets/factory/diamond.snbt" />
    <IsometricCamera yaw="195" pitch="6" />
</GameScene>

## 钻石级方块

<Row>
  <BlockImage id="diamond_pylon" scale="4" p:attached="true" />
  <BlockImage id="diamond_plinth" scale="4" p:attached="true" />
  <BlockImage id="diamond_cell" scale="4" p:attached="true" />
</Row>


对于此工厂，你需要
32个<ItemImage id="diamond_pylon" scale="0.5"/>钻石塔柱，
32个<ItemImage id="diamond_plinth" scale="0.5"/>钻石柱基，
1个<ItemImage id="diamond_cell" scale="0.5"/>钻石生命单元

<Row>
  <RecipeFor id="diamond_pylon" />
  <RecipeFor id="diamond_plinth" />
  <RecipeFor id="diamond_cell" />
</Row>