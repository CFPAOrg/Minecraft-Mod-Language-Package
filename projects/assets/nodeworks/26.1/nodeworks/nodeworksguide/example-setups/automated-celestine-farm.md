---
navigation:
  parent: example-setups/index.md
  icon: celestine_shard
  title: Celestine Farm
categories:
  - example
---

# Celestine Farm

<ItemLink id="budding_celestine" /> can be easily farmed using a <ItemLink id="breaker" /> and a <ItemLink id="terminal" />.

<GameScene zoom="4" interactive={true} paddingLeft="30" paddingRight="30">
  <ImportStructure src="../assets/assemblies/celestine_farm.snbt" />
  <IsometricCamera yaw="200" pitch="20" />
</GameScene>

Or optionally you can use Focus Nodes to connect everything together

<GameScene zoom="4" interactive={true} paddingLeft="30" paddingRight="30">
  <ImportStructure src="../assets/assemblies/celestine_farm_focus_node.snbt" />
  <IsometricCamera yaw="200" pitch="20" />
</GameScene>

Then in the GUIs of the Breakers you set them to Low redstone mode which keeps them
active without a redstone signal. And set each of them to break <ItemLink id="celestine_cluster" />.

They'll break the fully grown celestine clusters and insert them into [network storage](../nodeworks-mechanics/network-storage.md).