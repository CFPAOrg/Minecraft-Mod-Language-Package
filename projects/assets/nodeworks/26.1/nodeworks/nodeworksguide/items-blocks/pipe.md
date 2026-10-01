---
navigation:
  parent: items-blocks/index.md
  icon: pipe
  title: Vacuum Pipe
categories:
  - infrastructure
description: the building block of every network
item_ids:
- nodeworks:pipe
- nodeworks:covered_pipe
---

# Vacuum Pipe

The wire of a Nodeworks network. Pipes carry items, signals, and routing
between every block on the network.

<GameScene interactive={true} zoom="5" paddingLeft="20" paddingTop="20" paddingBottom="20">
  <IsometricCamera yaw="200" pitch="10" />
  <ImportStructure src="../assets/assemblies/vacuum_pipe.snbt" />
</GameScene>

Place pipes next to each other (or next to any network block) and they
connect automatically.

## Hiding Pipes

### Covered Pipes

You can also hide pipes by crafting Covered Pipe by taking one block and surrounding
it in 8 Vacuum Pipes in a crafting table.

<GameScene interactive={true} zoom="5" paddingLeft="20" paddingTop="20" paddingBottom="20">
  <IsometricCamera yaw="200" pitch="10" />
  <ImportStructure src="../assets/assemblies/covered_pipe.snbt" />
</GameScene>

### Focus Nodes

You can also use <ItemLink id="focus_node" />s to go through glass as a way to get through walls

<GameScene interactive={true} zoom="5" paddingLeft="20" paddingTop="20" paddingBottom="20">
  <IsometricCamera yaw="200" pitch="10" />
  <ImportStructure src="../assets/assemblies/focus_node_glass.snbt" />
</GameScene>

## Recipe

<RecipeFor id="pipe" />
