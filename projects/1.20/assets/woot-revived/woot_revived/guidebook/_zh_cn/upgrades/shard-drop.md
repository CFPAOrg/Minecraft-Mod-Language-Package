---
navigation:
    parent: upgrades/upgrades-index.md
    title: "碎片掉落升级"
    icon: "woot_revived:iron_shard_drop_upgrade"
    position: 1
---
# 碎片掉落升级

<Row>
  <ItemImage id="iron_shard_drop_upgrade" scale="3"/>
  <ItemImage id="gold_shard_drop_upgrade" scale="3"/>
  <ItemImage id="diamond_shard_drop_upgrade" scale="3"/>
  <ItemImage id="netherite_shard_drop_upgrade" scale="3"/>
</Row>

碎片掉落升级可掉落各级碎片

## 如何获得铜碎片

如你所见，这些升级不能产出<ItemImage id="copper_shard" scale="0.5"/>铜碎片

这是因为<ItemImage id="copper_shard" scale="0.5"/>铜碎片需要使用<ItemImage id="stygian_anvil" scale="0.5"/>幽冥砧来合成

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="../assets/anvil/copper_shard.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="copper_shard" scale="2"/>
  要合成该物品，你需要<ItemImage id="shard_mold" scale="0.5"/>碎片模具以及4个<ItemImage id="minecraft:copper_ingot" scale="0.5"/>铜锭
</Row>

## 碎片掉落升级 I

30%概率掉落<ItemImage id="iron_shard" scale="0.5"/>铁碎片。

该升级需安装在等级至少为铜级的工厂来产出<ItemImage id="iron_shard" scale="0.5"/>铁碎片

<RecipeFor id="iron_shard_drop_upgrade" />

## 碎片掉落升级 II

30%概率掉落<ItemImage id="iron_shard" scale="0.5"/>铁碎片。

20%概率掉落<ItemImage id="gold_shard" scale="0.5"/>金碎片。

该升级需安装在等级至少为铁级的工厂来产出<ItemImage id="gold_shard" scale="0.5"/>金碎片

<RecipeFor id="gold_shard_drop_upgrade" />

## 碎片掉落升级 III

30%概率掉落<ItemImage id="iron_shard" scale="0.5"/>铁碎片。

20%概率掉落<ItemImage id="gold_shard" scale="0.5"/>金碎片。

10%概率掉落<ItemImage id="diamond_shard" scale="0.5"/>钻石碎片。

该升级需安装在等级至少为金级的工厂来产出<ItemImage id="diamond_shard" scale="0.5"/>钻石碎片

<RecipeFor id="diamond_shard_drop_upgrade" />

## 碎片掉落升级 IV

30%概率掉落<ItemImage id="iron_shard" scale="0.5"/>铁碎片。

20%概率掉落<ItemImage id="gold_shard" scale="0.5"/>金碎片。

10%概率掉落<ItemImage id="diamond_shard" scale="0.5"/>钻石碎片。

5%概率掉落<ItemImage id="netherite_shard" scale="0.5"/>下界合金碎片。

该升级需安装在等级至少为钻石级的工厂来产出<ItemImage id="netherite_shard" scale="0.5"/>下界合金碎片

<RecipeFor id="netherite_shard_drop_upgrade" />
