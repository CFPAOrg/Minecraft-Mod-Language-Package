---
navigation:
    parent: factory/factory-index.md
    title: "Gold"
    icon: "woot_revived:gold_cell"
    position: 3
---
# Gold

The third tier of your factory.

## Design

Note that the Fake Spawner that are small in the preview are optional

The <ItemImage id="layout" scale="0.5"/> [Layout](../machines-blocks/layout.md#gold) configured on the third tier can help you to build it

<GameScene zoom="2.5" interactive={true}>
    <ImportStructure src="../assets/factory/gold.snbt" />
    <IsometricCamera yaw="195" pitch="6" />
</GameScene>

## Gold Blocks

<Row>
  <BlockImage id="gold_pylon" scale="4" p:attached="true" />
  <BlockImage id="gold_plinth" scale="4" p:attached="true" />
  <BlockImage id="gold_cell" scale="4" p:attached="true" />
</Row>


For this one you will need
36 <ItemImage id="gold_pylon" scale="0.5"/> Gold Pylon,
24 <ItemImage id="gold_plinth" scale="0.5"/> Gold Plinth,
1 <ItemImage id="gold_cell" scale="0.5"/> Gold Vitality Cell

<Row>
  <RecipeFor id="gold_pylon" />
  <RecipeFor id="gold_plinth" />
  <RecipeFor id="gold_cell" />
</Row>