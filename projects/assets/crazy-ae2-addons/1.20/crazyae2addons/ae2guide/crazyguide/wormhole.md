---
navigation:
  parent: crazyae2addons_index.md
  title: Wormhole
  icon: crazyae2addons:wormhole
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:wormhole
---

# Wormhole

The **Wormhole** is a universal P2P tunnel that bridges two or more locations.

Unlike normal P2P tunnels, it is not limited to one resource type. It can proxy capabilities, forward interactions, and teleport the player to the other side.

---

## Capability proxy

A block placed in front of an output Wormhole can expose its capabilities through the input Wormhole.

This allows pipes, cables, machines, and other systems connected to the input side to interact with the block on the output side as if it were local.

Supported capability types depend on config, but can include items, fluids, Forge Energy, GregTech EU, and other Forge capabilities.

---

## Multiple outputs

When multiple outputs are paired to the same input, the input can expose them as one merged target.

For example, multiple inventories can appear as one combined inventory, and multiple tanks can appear as one combined fluid target.

If merged proxying is disabled in config, the input forwards to the first available output instead.

---

## Remote interactions

Interacting with a paired Wormhole can activate the block on the other side.

This can open remote GUIs or activate blocks such as buttons, levers, doors, and machines.

Remote interaction may work across dimensions if the target side is loaded.

This behavior can be disabled in config.

---

## Teleportation

Holding an Ender Pearl and using a paired Wormhole teleports the player to the block in front of the opposite side.

The Ender Pearl is consumed, unless the player is in Creative mode.

Teleportation can work across dimensions, but the target chunk must be loaded and ticking.

This behavior can be disabled in config.

---