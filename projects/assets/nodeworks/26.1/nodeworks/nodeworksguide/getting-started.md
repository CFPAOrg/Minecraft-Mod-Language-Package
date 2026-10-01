---
navigation:
  title: Getting Started
  position: 10
---

# Getting Started

## Required Materials

Nodework networks are powered by the reflective properties of <ItemLink id="celestine_shard" />s

## Growing Celestine

Growing Celestine like <ItemLink id="minecraft:amethyst_cluster" />s will grow from
a budding block, <ItemLink id="budding_celestine" />

## First Nodeworks Network

A simple network with no scripting involved, just viewing items into as many
connected chests as you'd like using an Inventory Terminal.

<GameScene interactive={true} zoom="5">
  <IsometricCamera yaw="200" pitch="10" />
  <ImportStructure src="assets/assemblies/first_network.snbt" />
</GameScene>

- This network contains the following:
  - 1x <ItemLink id="network_controller" />
  - 1x <ItemLink id="inventory_terminal" />
  - Some <ItemLink id="pipe" />s to connect all devices together
  - Some <ItemLink id="node" />s to connect external blocks to the network such as chests
  - 1x <ItemLink id="storage_card" /> placed in the Node's face toward the chest

### Expanding your Nodeworks Network

- [Moving items](./example-setups/moving-items.md)
- [Autocrafting](./nodeworks-mechanics/autocrafting.md)
- [Example Setups](./example-setups/index.md)
