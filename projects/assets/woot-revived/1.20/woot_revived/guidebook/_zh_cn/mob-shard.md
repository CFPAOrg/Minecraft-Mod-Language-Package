---
navigation:
  title: "如何捕捉生物？"
  position: 20
  icon: "mob_shard"
---
# 如何捕捉生物？

要捕捉生物，你需要一个<ItemImage id="mob_shard" scale="0.5"/>生物碎片

## 如何合成生物碎片

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="assets/anvil/mob_shard.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="mob_shard" scale="2"/>
  要合成生物碎片，你需要<ItemImage id="shard_mold" scale="0.5"/>碎片模具，以及2个<ItemImage id="stygian_ingot" scale="0.5"/>幽冥锭
</Row>

## 如何使用生物碎片

有了生物碎片，就该捕捉生物了。首先，你需要用碎片来攻击生物

也可以右击将碎片丢给生物。如此丢出后，除了遇到熔岩，碎片物品实体不会被摧毁

如果在攻击后，生物碎片还是处于未捕捉状态，说明该生物处于黑名单中，或者目标不是生物实体。

成功捕捉生物后，需要在物品栏中存在生物碎片的情况下，使用任意工具击杀5次同种生物。

完成5次击杀后，生物碎片将完全编入，然后就可以将其转变为<ItemImage id="fake_spawner" scale="0.5"/>伪刷怪笼

## 如何合成伪刷怪笼

要让工厂识别你捕捉到的生物，你需要将<ItemImage id="mob_shard" scale="0.5"/>生物碎片转变为<ItemImage id="fake_spawner" scale="0.5"/>伪刷怪笼

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="assets/anvil/fake_spawner.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="fake_spawner" scale="2"/>
  要合成该方块，你需要<ItemImage id="mob_shard" scale="0.5"/>生物碎片，一个<ItemImage id="prism" scale="0.5"/>棱镜，以及一个<ItemImage id="factory_base" scale="0.5"/>工厂基座
</Row>