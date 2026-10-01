---
navigation:
  parent: example-setups/index.md
  icon: milky_soul_ball
  title: 奶液灵魂球农场
categories:
  - example
---

# 奶液灵魂球农场

<GameScene zoom="4" interactive={true} paddingLeft="30" paddingRight="30">
  <ImportStructure src="../assets/assemblies/milky_soul_farm.snbt" />
  <Entity id="minecraft:cow" x="2.5" z="1.5" rotationY="170"/>
  <IsometricCamera yaw="200" pitch="20" />
  <BlockAnnotation x="5" y="1" z="1">
    <ItemGrid>
        <ItemIcon id="minecraft:bucket" />
        <ItemIcon id="minecraft:soul_sand" />
    </ItemGrid>
  </BlockAnnotation>
  <BlockAnnotation x="3" y="1" z="1">
    使用器对牛使用空铁桶
  </BlockAnnotation>
  <BlockAnnotation x="3" y="4" z="1">
    使用器对灵魂沙使用奶桶，并将产出的奶液灵魂球和空铁桶送回网络存储
  </BlockAnnotation>
  <BlockAnnotation x="1" y="4" z="1">
    放置器在使用器前方放置灵魂沙
  </BlockAnnotation>
</GameScene>

此农场中的<ItemLink id="user" />会用空铁桶为奶牛挤奶，并将奶桶送回[网络存储](../nodeworks-mechanics/network-storage.md)。另一个使用器则会对<ItemLink id="placer" />放置的<ItemLink id="minecraft:soul_sand" />使用<ItemLink id="minecraft:milk_bucket" />。

> **注意：**&zwnj;放置器和使用器的红石模式均为低，以让它们保持运作。