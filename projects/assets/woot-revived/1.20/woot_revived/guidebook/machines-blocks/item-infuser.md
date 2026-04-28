---
navigation:
    parent: machines-blocks/machines-blocks-index.md
    title: "Item Infuser"
    icon: "woot_revived:item_infuser"
---
# Item Infuser

<BlockImage id="item_infuser" scale="5"/>

The <ItemImage id="item_infuser" scale="0.5"/> Item Infuser produces items by combining ingredients and injecting fluid in them

## Craft

<RecipeFor id="item_infuser" />

## Prism

The <ItemImage id="prism" scale="0.5"/> prism is the main ingredient to craft a <ItemImage id="fake_spawner" scale="0.5"/> Fake Spawner

<Recipe id="item_infuser/prism" />

## Dye Plates

Before getting Dye Plates you will need to get the specific Dye Casing

Here is the example on how to create a <ItemImage id="white_dye_casing" scale="0.5"/> White Casing Dye, but you can create one of each dye.

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="../assets/anvil/dye_casing.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="white_dye_casing" scale="2"/>
  To craft it you need the <ItemImage id="dye_casing_mold" scale="0.5"/> dye casing mold and a <ItemImage id="minecraft:white_dye" scale="0.5"/> White Dye
</Row>

Ones you have your dye plate you can use it in the item infuser with <ItemImage id="pure_dye_fluid_bucket" scale="0.5"/> Pure Dye Fluid to get a dye plate

<Recipe id="item_infuser/white_dye_plate" />

## Enchanted Plates

To craft the Vitality Fuel Cells you will need their respective enchanted plates.

For example, to get a <ItemImage id="copper_cell" scale="0.5"/> Copper Vitality Cell you will need <ItemImage id="copper_enchanted_plate" scale="0.5"/> Copper Enchanted Plate

To get these plates you will need <ItemImage id="enchanted_fluid_bucket" scale="0.5"/> Enchanted Fluid and their respective shard also

<Row>
  <Recipe id="item_infuser/copper_enchanted_plate" />
  <Recipe id="item_infuser/iron_enchanted_plate" />
  <Recipe id="item_infuser/gold_enchanted_plate" />
  <Recipe id="item_infuser/diamond_enchanted_plate" />
  <Recipe id="item_infuser/netherite_enchanted_plate" />
</Row>

## Miscellaneous

You can also get some vanilla items using the machine

<Row>
    <Recipe id="item_infuser/magma_block" />
    <Recipe id="item_infuser/netherrack" />
    <Recipe id="item_infuser/fire_charge" />
    <Recipe id="item_infuser/crying_obsidian" />
    <Recipe id="item_infuser/soul_soil" />
</Row>