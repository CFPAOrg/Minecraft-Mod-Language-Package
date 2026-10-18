---
navigation:
  parent: example-setups/example-setups-index.md
  title: 紫水晶农场
  icon: minecraft:amethyst_shard
---

# 刷取紫水晶

虽然<ItemLink id="growth_accelerator" />对紫水晶有效，但以<ItemLink id="annihilation_plane" />过滤[赛特斯石英芽](../items-blocks-machines/budding_certus.md)的常用方法对紫晶芽无效。不像未长成的赛特斯石英芽能掉落<ItemLink id="certus_quartz_dust" />，未长成的紫晶芽什么都不会掉落，而网络永远能存下“空气”，因此破坏面板会一直破坏它们。

绕过此问题的方法是将破坏面板附上精准采集。此情况下未长成的紫晶芽就*会*掉落物品（各阶段的紫晶芽本身）了，并可过滤处理。

<ItemLink id="minecraft:amethyst_cluster" />需由<ItemLink id="formation_plane" />再次放置并由不带精准采集的<ItemLink id="annihilation_plane" />再次破坏即可得到<ItemLink id="minecraft:amethyst_shard" />。

注意因为紫水晶簇有方向性，成型面板的对侧应当有一个完整方块面。

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/amethyst_farm.snbt" />

  <BoxAnnotation color="#dddddd" min="2.7 1 1" max="3 2 2">
        （1）破坏面板#1：无可用GUI，附有精准采集。
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="2 1 1" max="2.3 2 2">
        （2）成型面板：过滤紫水晶簇。
        <ItemImage id="minecraft:amethyst_cluster" scale="2" />
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="1.3 0.7 1" max="2 1 2">
        （3）破坏面板#2：无可用GUI，可附有时运。
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="1 0 1" max="1.3 1 2">
        （4）存储总线#1：过滤紫水晶碎片。
        <ItemImage id="minecraft:amethyst_shard" scale="2" />
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="0 0 .7" max="1 1 1">
        （5）存储总线#2：过滤紫水晶碎片。优先级高于主存储。
        <ItemImage id="minecraft:amethyst_shard" scale="2" />
  </BoxAnnotation>

<DiamondAnnotation pos="0 0.5 0.5" color="#00ff00">
        至主网络
    </DiamondAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 配置

* 第一个<ItemLink id="annihilation_plane" />（1）没有GUI且无法配置，但必须附有精准采集。
* <ItemLink id="formation_plane" />（2）设置为过滤<ItemLink id="minecraft:amethyst_cluster" />。
* 第二个<ItemLink id="annihilation_plane" />（3）没有GUI且无法配置，可附有时运。
* 第一个<ItemLink id="storage_bus" />（4）设置为过滤<ItemLink id="minecraft:amethyst_shard" />。
* 第二个<ItemLink id="storage_bus" />（5）设置为过滤<ItemLink id="minecraft:amethyst_shard" />，且[优先级](../ae2-mechanics/import-export-storage.md#storage-priority)高于主存储。

## 工作原理

1. 第一个<ItemLink id="annihilation_plane" />会尝试破坏其前方的事物，但由于子网络中唯一存储位置便是过滤为紫水晶簇的<ItemLink id="formation_plane" />，其只会破坏<ItemLink id="minecraft:amethyst_cluster" />。只会在面板附有精准采集时起效，若未附有该魔咒则也会破坏什么都不掉落的未长成晶芽。
2. <ItemLink id="formation_plane" />将紫水晶簇放置于其对侧的方块。
3. 第二个<ItemLink id="annihilation_plane" />破坏紫水晶簇而得<ItemLink id="minecraft:amethyst_shard" />。
4. 第一个<ItemLink id="storage_bus" />将紫水晶碎片存入木桶。由于第二个破坏面板有可能破坏的事物只会是长成的紫水晶簇，此总线实际不需设置过滤。
5. 第二个<ItemLink id="storage_bus" />使得主网络能访问木桶内的所有紫水晶簇。其[优先级](../ae2-mechanics/import-export-storage.md#storage-priority)应高于主网络，由此紫水晶碎片会优先存入木桶而非主存储。
