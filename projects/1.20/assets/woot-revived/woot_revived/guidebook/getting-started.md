---
navigation:
  title: "Getting Started"
  position: 10
  icon: "woot_revived:stygian_ingot"
---
# Getting Started

## Getting the Stygian Ingot

To get started with Woot Revived, you first need to craft some <ItemImage id="stygian_dust" scale="0.5"/> Stygian Dust
<Recipe id="stygian_dust" />

Then you will need to cook them to do <ItemImage id="stygian_ingot" scale="0.5"/> Stygian Ingot
<Recipe id="stygian_ingot_cook" />

## Getting the Molds

First you will need to do a <ItemImage id="stygian_anvil" scale="0.5"/> Stygian Anvil and a <ItemImage id="stygian_hammer" scale="0.5"/> Stygian Hammer
<Row>
    <Recipe id="stygian_anvil" />
    <Recipe id="stygian_hammer" />
</Row>

Then you will need to put the Stygian Anvil on a <ItemImage id="minecraft:magma_block" scale="0.5"/> Magma Block

To craft items with the Stygian Anvil, you will need to right click it with the Stygian Hammer

For each mold you will need a <ItemImage id="minecraft:quartz" scale="0.5"/> Quartz, and a <ItemImage id="stygian_ingot" scale="0.5"/> Stygian Ingot

Note that molds don't consume when you craft with them, you only need one of them

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="assets/anvil/plate_mold.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="plate_mold" scale="2"/>
  To craft a plate mold you will need an <ItemImage id="minecraft:iron_trapdoor" scale="0.5"/> Iron Trapdoor
</Row>

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="assets/anvil/shard_mold.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="shard_mold" scale="2"/>
  To craft a shard mold you will need a <ItemImage id="minecraft:prismarine_shard" scale="0.5"/> Prismarine Shard
</Row>

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="assets/anvil/dye_casing_mold.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="dye_casing_mold" scale="2"/>
  To craft a dye casing mold you will need <ItemImage id="minecraft:white_dye" scale="0.5"/> any dye
</Row>

## Crafting the Factory Base

To create all the blocks of the mod you will need to craft the Factory Base

First you will need some <ItemImage id="stygian_plate" scale="0.5"/> Stygian Plate

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="assets/anvil/stygian_plate.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="stygian_plate" scale="2"/>
  To craft it you need the <ItemImage id="plate_mold" scale="0.5"/> plate mold and a <ItemImage id="stygian_ingot" scale="0.5"/> Stygian Ingot
</Row>

Then you will be able to craft a Factory Base block

<Recipe id="factory_base" />

## And after?

Now you can start to [capture mobs](mob-shard.md), or you can start [building your first factory](factory/copper.md)!