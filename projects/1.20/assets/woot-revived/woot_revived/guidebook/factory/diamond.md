---
navigation:
    parent: factory/factory-index.md
    title: "Diamond"
    icon: "woot_revived:diamond_cell"
    position: 4
---
# Diamond

The fourth tier of your factory.

## Design

Note that the Fake Spawner that are small in the preview are optional

The <ItemImage id="layout" scale="0.5"/> [Layout](../machines-blocks/layout.md#diamond) configured on the fourth tier can help you to build it

<GameScene zoom="2.5" interactive={true}>
    <ImportStructure src="../assets/factory/diamond.snbt" />
    <IsometricCamera yaw="195" pitch="6" />
</GameScene>

## Diamond Blocks

<Row>
  <BlockImage id="diamond_pylon" scale="4" p:attached="true" />
  <BlockImage id="diamond_plinth" scale="4" p:attached="true" />
  <BlockImage id="diamond_cell" scale="4" p:attached="true" />
</Row>


For this one you will need
32 <ItemImage id="diamond_pylon" scale="0.5"/> Diamond Pylon,
32 <ItemImage id="diamond_plinth" scale="0.5"/> Diamond Plinth,
1 <ItemImage id="diamond_cell" scale="0.5"/> Diamond Vitality Cell

<Row>
  <RecipeFor id="diamond_pylon" />
  <RecipeFor id="diamond_plinth" />
  <RecipeFor id="diamond_cell" />
</Row>