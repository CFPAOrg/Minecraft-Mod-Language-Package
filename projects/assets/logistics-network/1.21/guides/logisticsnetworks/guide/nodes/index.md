---
item_ids: [logisticsnetworks:logistics_node]
navigation:
  title: Nodes
  icon: logisticsnetworks:logistics_node
  position: 1
---

# Nodes

Nodes are the core piece of every logistics network. You place one on a block (chest, tank, machine, cable, anything with storage) and the node takes care of moving resources to and from that block.

## The Basics

- **Every node has 9 channels.** Each channel is one transfer rule — direction, resource type, batch size, filters, and so on. A single node can run up to 9 transfers at the same time.
- **Nodes are entities, not blocks.** They do not take up a block space. They sit on the face of the block they were placed on, just like an item frame or a painting. You can still place, break, and interact with the block underneath.
- **Nodes are attached to the block, not the network.** Placing a node does nothing by itself — it only starts transferring once you assign it to a network and configure at least one channel.

## Configuring a Node

Right-click a placed node with a Wrench to open its configuration screen. The screen is split into three parts, and each part has its own chapter in this section:

1. [Header](header.md) — visibility toggle, node label, and the channel selector (picks which of the 9 channels you are editing).
2. [Channel Settings](channel-settings.md) — the settings for the currently selected channel: status, mode, type, side, redstone, distribution, priority, batch, and delay.
3. [Filters & Upgrades](filters-upgrades.md) — filter slots for the current channel, upgrade slots for the whole node, and the Tweaks button for advanced options.

Read the chapters in order if this is your first node.

## Crafting Recipe

<RecipeFor id="logisticsnetworks:logistics_node" />
