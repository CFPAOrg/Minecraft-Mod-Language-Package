---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 破坏面板
  icon: annihilation_plane
  position: 210
categories:
- devices
item_ids:
- ae2:annihilation_plane
---

# 破坏面板

<GameScene zoom="8" background="transparent">
<ImportStructure src="../assets/blocks/annihilation_plane.snbt" />
</GameScene>

破坏面板能破坏方块和捡起物品。它会将物品输入[网络存储](../ae2-mechanics/import-export-storage.md)，与<ItemLink id="import_bus" />工作方式类似。它只会捡起与面板碰撞的物品，而不是区域内所有物品。

破坏面板接受所有镐魔咒，因此只要模组包允许，就可以为其附上等级很高的时运再放去[自动化矿石处理](../example-setups/ore-fortuner.md) 。此外，精准采集和带有此魔咒的工具表现相同，效率能减少破坏方块的能量消耗，耐久则提升破坏时不使用能量的概率。

破坏面板是[线缆子部件](../ae2-mechanics/cable-subparts.md)。

**记得在你认领的区块内允许放置假玩家**

## 过滤

破坏面板只会在掉落物或物品能存入网络时破坏方块或捡起物品。也即*需要限制其网络中可存储物品的种类*才能过滤破坏面板，通常会将其放在[子网络](../ae2-mechanics/subnetworks.md)中。使用<ItemLink id="storage_bus" />或设置[分区](cell_workbench.md)的[元件](../items-blocks-machines/storage_cells.md)可达成这一点。

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/annihilation_filtering.snbt" />

  <DiamondAnnotation pos="1 0.5 0.5" color="#00ff00">
        过滤为所破坏事物的掉落物
  </DiamondAnnotation>

  <DiamondAnnotation pos=".5 0.5 2.5" color="#00ff00">
        分区为所破坏事物的掉落物
  </DiamondAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

破坏面板过滤的是*掉落物*。因此假如要设置仅破坏<ItemLink id="minecraft:amethyst_cluster" />，则面板必须附有精准采集。未长成的紫晶芽什么都不会掉落，而网络永远能存下“空气”，因此普通的破坏面板会一直破坏它们。

## 破坏面板

<RecipeFor id="annihilation_plane" />
