---
navigation:
    parent: factory/factory-index.md
    title: "Common Blocks"
    icon: "woot_revived:factory_connect"
    position: 0
---
# Common Blocks

Each factory have a common setup with these blocks. To get more details on placement, go to the tier pages

## Factory Heart

The <ItemImage id="heart" scale="0.5"/> [Factory Heart](../machines-blocks/heart.md) is the main controller of your factory

<RecipeFor id="heart" />

## Upgrade Slot

The <ItemImage id="factory_upgrade" scale="0.5"/> [Upgrade Slot](../machines-blocks/upgrade-slot.md) store your upgrade items for the factory

<RecipeFor id="factory_upgrade" />

## Fake Spawner

The <ItemImage id="fake_spawner" scale="0.5"/> [Fake Spawner](../mob-shard.md) store the mob to be simulated

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="../assets/anvil/fake_spawner.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="fake_spawner" scale="2"/>
  To craft it you need a programmed <ItemImage id="mob_shard" scale="0.5"/> Mob Shard, a <ItemImage id="prism" scale="0.5"/> Prism and a <ItemImage id="factory_base" scale="0.5"/> Factory Base
</Row>

## Primary Base and Secondary Base

The <ItemImage id="factory_ctr_base_pri" scale="0.5"/> Primary Base and the <ItemImage id="factory_ctr_base_sec" scale="0.5"/> Secondary Base are the base for your <ItemImage id="fake_spawner" scale="0.5"/> Fake Spawner

Note that the fake spawners on the secondary bases are optional

<Row>
  <RecipeFor id="factory_ctr_base_pri" />
  <RecipeFor id="factory_ctr_base_sec" />
</Row>

## Factory Connector

The <ItemImage id="factory_ctr_base_pri" scale="0.5"/> Factory Connector connect the ingredients to your factory

<RecipeFor id="factory_connect" />

## Ingredient Importer

The <ItemImage id="import" scale="0.5"/> [Ingredient Importer](../machines-blocks/import.md) let you import items or fluids that are needed to spawn the mob

<RecipeFor id="import" />

## Loot Exporter

The <ItemImage id="export" scale="0.5"/> [Loot Exporter](../machines-blocks/export.md) is where all the items or fluids produced by the mobs will be thrown

<RecipeFor id="export" />

## Vitality Cells

Note that all the Vitality Cells are common to all factory tiers!

You can notice that by using the [Layout](../machines-blocks/layout.md), you will see that the vitality cell block switch between every vitality cells