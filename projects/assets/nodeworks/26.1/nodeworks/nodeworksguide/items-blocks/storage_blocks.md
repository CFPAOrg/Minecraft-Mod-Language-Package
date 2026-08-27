---
navigation:
  parent: items-blocks/index.md
  icon: instruction_storage
  title: Recipe Storage Blocks
categories:
  - autocrafting
description: houses Recipe Sets so Crafting CPUs can see them
item_ids:
- nodeworks:instruction_storage
- nodeworks:processing_storage
---

# Recipe Storage Blocks

Storage Blocks are where you keep your filled out [Recipe Sets](./recipe_sets.md)
once they're read for the <ItemLink id="crafting_core" /> to use. Righ-click to
open, drop the Recipe Sets into the slots, and you're done.

Each type of Recipe Set has its own Storage Block

- **Instruction Storage:** holds Instruction Sets
- **Processing Storage:** holds Processing Sets

## How they work

Wire a Storage Block to a Node and every Recipe Set inside becomes visible to
the CPU.

<GameScene zoom="3.5" interactive={true} paddingTop="20" paddingLeft="50" paddingRight="60">
  <ImportStructure src="../assets/assemblies/processing_storage_cluster.snbt" />
  <BoxAnnotation min="0 0 0" max="3 1 1">
    A cluster of **connected** Processing Storage all get exported together since they're touching
  </BoxAnnotation>
</GameScene>

Storage Blocks can also be placed right next to each other to form a cluster.
You only need to wire **one** block in a cluster, the rest tag along through
the shared faces. Break the block that bridges two halves and the group
splits back into two, each figuring out on its own whether it's still
reachable. The block's emissive glow matches the network colour of whichever
network it belongs to, so at a glance you can tell which group goes where.

## Clustering Recipe Storage Blocks

If you have one Recipe Storage Blocks connected to a network, any adjacent Recipe Storage Blockss
will cluster together and also connect to the network.

## Recipes

<Row>
    <RecipeFor id="instruction_storage" />
    <RecipeFor id="processing_storage" />
</Row>