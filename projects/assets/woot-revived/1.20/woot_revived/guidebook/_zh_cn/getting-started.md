---
navigation:
  title: "入门起步"
  position: 10
  icon: "woot_revived:stygian_ingot"
---
# 入门起步

## 获得幽冥锭

要开始发展Woot：重生，首先你需要合成一些<ItemImage id="stygian_dust" scale="0.5"/>幽冥粉
<Recipe id="stygian_dust" />

然后，你得把它们烧炼为<ItemImage id="stygian_ingot" scale="0.5"/>幽冥锭
<Recipe id="stygian_ingot_cook" />

## 获得模具

首先，你需要合成一个<ItemImage id="stygian_anvil" scale="0.5"/>幽冥砧和一个<ItemImage id="stygian_hammer" scale="0.5"/>幽冥锤
<Row>
    <Recipe id="stygian_anvil" />
    <Recipe id="stygian_hammer" />
</Row>

然后，你需要把幽冥砧放置在<ItemImage id="minecraft:magma_block" scale="0.5"/>岩浆块上

使用幽冥锤右击来通过幽冥砧合成物品

每个模具需要一个<ItemImage id="minecraft:quartz" scale="0.5"/>石英，以及一个<ItemImage id="stygian_ingot" scale="0.5"/>幽冥锭

注意：通过模具合成物品时，模具不会被消耗，所以每种只需要一个就够了

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="assets/anvil/plate_mold.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="plate_mold" scale="2"/>
  要合成板模具，你需要一个<ItemImage id="minecraft:iron_trapdoor" scale="0.5"/>铁活板门
</Row>

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="assets/anvil/shard_mold.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="shard_mold" scale="2"/>
  要合成碎片模具，你需要一个<ItemImage id="minecraft:prismarine_shard" scale="0.5"/>海晶碎片
</Row>

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="assets/anvil/dye_casing_mold.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="dye_casing_mold" scale="2"/>
  要合成碎片模具，你需要一个<ItemImage id="minecraft:white_dye" scale="0.5"/>任意类型的染料
</Row>

## 合成工厂基座

要制作本模组的所有方块，首先需要合成工厂基座

首先，需要一些<ItemImage id="stygian_plate" scale="0.5"/>幽冥板

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="assets/anvil/stygian_plate.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="stygian_plate" scale="2"/>
  要合成该物品，你需要<ItemImage id="plate_mold" scale="0.5"/>板模具以及一个<ItemImage id="stygian_ingot" scale="0.5"/>幽冥锭
</Row>

然后，便能合成一个工厂基座方块

<Recipe id="factory_base" />

## 接下来呢？

现在，可以开始[捕捉生物](mob-shard.md)了，或者也可以开始[搭建首个工厂](factory/copper.md)！