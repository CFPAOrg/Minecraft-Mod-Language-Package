---
navigation:
  parent: example-setups/index.md
  icon: milky_soul_ball
  title: Milky Soul Ball Farm
categories:
  - example
---

# Milky Soul Ball Farm

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
    User uses empty buckets on cows
  </BlockAnnotation>
  <BlockAnnotation x="3" y="4" z="1">
    User uses milk buckets on Soul Sand and puts the resulting Milky Soul Balls
    and empty bucket back into Network Storage
  </BlockAnnotation>
  <BlockAnnotation x="1" y="4" z="1">
    Placer places soul sand in front of the User
  </BlockAnnotation>
</GameScene>

This farm has a <ItemLink id="user" /> milking cows using empty buckets and put the milk buckets into [Network Storage](../nodeworks-mechanics/network-storage.md). Then another User will use those <ItemLink id="minecraft:milk_bucket" />s on the <ItemLink id="minecraft:soul_sand" /> placed by a <ItemLink id="placer" />

> **Note:** Placers and Users have redstone mode set to Low so they're all active