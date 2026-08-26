---
navigation:
  title: Welcome to Logistics Network
  position: 0
---

# Logistics Networks

Logistics Networks is an item, fluid, energy, and chemical transfer mod built around nodes and channels.

## Core Concepts

- **Nodes** are small entities placed on blocks with storage capabilities (chests, tanks, machines, etc.)
- **Networks** are logical groups of nodes that share resources
- **Channels** define what a node does — each node has 9 configurable channels
- **Filters** control exactly what gets transferred

## Getting Started

1. Craft a [Wrench](wrench/index.md) and a [Logistics Node](nodes/index.md)
2. Place the node on any block with an inventory, tank, or energy storage
3. Right-click the node with the wrench to open configuration
4. Assign the node to a network (or create a new one)
5. Configure channels to import or export resources

## Understanding Transfer

Nodes do not transfer anything by themselves. A node just sticks to a block. The real work happens inside the node's **channels**.

Every channel has a direction:

- **Sender** — takes resources **out of** the block the node is attached to.
- **Receiver** — puts resources **into** the block the node is attached to.

A network is a group of nodes that can talk to each other. Each node has 9 channel slots, numbered 1 through 9. **A Sender only talks to a Receiver on the same channel number**, across the whole network.

So a Sender on channel 3 only sends to Receivers on channel 3. A Sender on channel 7 only sends to Receivers on channel 7. Channel numbers act like labelled pipes — matching numbers are connected, different numbers are not.

### Simple Example

1. Place a node on a chest full of iron. Set **channel 1** to **Sender — Items**.
2. Place a node on a furnace. Set **channel 1** to **Receiver — Items**.
3. Put both nodes on the same network.

Both nodes use channel 1, so they are linked. The Sender pulls iron out of the chest. The network hands it to the Receiver on channel 1. The Receiver pushes the iron into the furnace.

That is all a transfer is: a Sender pulls out, a Receiver on the same channel number pushes in, and the network connects them.

## Guides

- [Nodes](nodes/index.md) — Placing, configuring, and labeling nodes
- [Filters](filters/index.md) — Controlling what gets transferred
- [Computer](computer/index.md) — Network monitoring and telemetry
- [Upgrades](nodes/upgrades-performance.md) — Performance tiers and special upgrades (under Nodes)
