---
navigation:
  parent: items-blocks/index.md
  icon: network_controller
  title: Network Controller
categories:
  - infrastructure
description: the heart of a network, every network requires one
item_ids:
- nodeworks:network_controller
---

# Network Controller

Every Nodeworks network needs exactly one Controller. Without it, the
[Pipes](pipe.md) and [Nodes](node.md) connected to it stay dormant.

<GameScene interactive={true} zoom="5">
  <IsometricCamera yaw="200" pitch="10" />
  <ImportStructure src="../assets/assemblies/controller_node_terminal.snbt" />
</GameScene>

Place a Controller, run pipes from it, and any block that connects to
those pipes joins the network.

## Identity

The Controller's GUI lets you name the network and pick a colour. The
name is cosmetic, the colour tints the node glows so multiple networks
in the same area stay easy to tell apart.

## Chunk loading

Toggling chunk loading in the GUI keeps every chunk that the network
touches forced-loaded. Useful for autocrafting setups that need to keep
running while you're far away.

## One per network

Two Controllers connected to the same pipe run will conflict and both
networks shut down until one is removed.

## Recipe

<RecipeFor id="network_controller" />
