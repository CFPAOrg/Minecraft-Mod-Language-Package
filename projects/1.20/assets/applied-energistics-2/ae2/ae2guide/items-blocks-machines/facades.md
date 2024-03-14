---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 伪装板
  icon: facade
  position: 110
categories:
- network infrastructure
item_ids:
- ae2:facade
---

# 伪装板

伪装板能让基地看起来更整洁。它们能遮挡各种形制的线缆，且可由多种方块制成。

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/facades_1.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

它们能够遮挡线缆的每一面，但[子部件](../ae2-mechanics/cable-subparts.md)和线缆连接不会被遮断。

<GameScene zoom="6"  interactive={true}>
  <ImportStructure src="../assets/assemblies/facades_2.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

灵活使用伪装板。提升基地观感，制造各面材质不同的方块，如此种种都能做到。

<GameScene zoom="4" interactive={true}>
  <ImportStructure src="../assets/assemblies/facades_3.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 配方

将带有想要伪装成的材质的方块放在4个<ItemLink id="cable_anchor" />中间即可。

![伪装板配方](../assets/diagrams/facade_recipe.png)
