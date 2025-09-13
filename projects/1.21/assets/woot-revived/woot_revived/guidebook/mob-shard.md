---
navigation:
  title: "How to capture a mob?"
  position: 20
  icon: "mob_shard"
---
# How to capture a mob?

To capture mob you will need a <ItemImage id="mob_shard" scale="0.5"/> Mob Shard

## How to craft a Mob Shard

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="assets/anvil/mob_shard.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="mob_shard" scale="2"/>
  To craft it you need the <ItemImage id="shard_mold" scale="0.5"/> shard mold and 2 <ItemImage id="stygian_ingot" scale="0.5"/> Stygian Ingot
</Row>

## How to use the Mob Shard

After you got the Mob Shard to capture a mob you first need to hit it with the shard

You can also throw the shard at the mob. When you throw the shard,
it becomes invulnerable to everything except lava

If you see that the Mob Shard is not in captured state after you hit the mob, it probably means that the mob is blacklisted or is not a living entity.

After you successfully captured a mob, you need to kill it 5 times using any tools while keeping
the Mob Shard in your inventory.

After the 5 kills the Mob Shard will be fully programmed, and you can turn it to a <ItemImage id="fake_spawner" scale="0.5"/> Fake Spawner

## How to craft a Fake Spawner

For the factory to consider your capture, you will need to turn your <ItemImage id="mob_shard" scale="0.5"/> Mob Shard into a <ItemImage id="fake_spawner" scale="0.5"/> Fake Spawner

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="assets/anvil/fake_spawner.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="fake_spawner" scale="2"/>
  To craft it you need the <ItemImage id="mob_shard" scale="0.5"/> Mob Shard, a <ItemImage id="prism" scale="0.5"/> Prism and a <ItemImage id="factory_base" scale="0.5"/> Factory Base
</Row>