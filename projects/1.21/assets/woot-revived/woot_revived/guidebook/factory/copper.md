---
navigation:
    parent: factory/factory-index.md
    title: "Copper"
    icon: "woot_revived:copper_cell"
    position: 1
---
# Copper

The first tier of your factory, it is the minimal version of it.

Perfect to start the mod, or to build a basic one mob factory!

## Design

First you will need to build the middle base of the factory, then you can finish with the surrounding

The <ItemImage id="layout" scale="0.5"/> [Layout](../machines-blocks/layout.md#copper) configured on the first tier can help you to build it

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

## Copper Blocks

<Row>
  <BlockImage id="copper_pylon" scale="4" p:attached="true" />
  <BlockImage id="copper_plinth" scale="4" p:attached="true" />
  <BlockImage id="copper_cell" scale="4" p:attached="true" />
</Row>

For the factory, you will need the blocks from [Common Blocks](common-blocks.md) but also some tier specific blocks

For this one you will need
17 <ItemImage id="copper_pylon" scale="0.5"/> Copper Pylon,
6 <ItemImage id="copper_plinth" scale="0.5"/> Copper Plinth,
1 <ItemImage id="copper_cell" scale="0.5"/> Copper Vitality Cell

<Row>
  <RecipeFor id="copper_pylon" />
  <RecipeFor id="copper_plinth" />
  <RecipeFor id="copper_cell" />
</Row>