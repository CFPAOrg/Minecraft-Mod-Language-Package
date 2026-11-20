---
navigation:
  title: Wrench Mode
  parent: wrench/index.md
  position: 1
---

# Wrench Mode

The default mode. If you just crafted a wrench and picked it up, it is already in this mode. Use it to open node settings, remove or place nodes, and link an AE2 or Refined Storage network.

## Open Node Configuration

Use **Secondary Interaction (default: Right Click)** on a placed node with the wrench in Wrench mode. The node configuration screen opens and you can edit all 9 channels, filters, upgrades, labels, and so on.

Use **Modifier Key 1 + Secondary Interaction** on a compatible block without a node to place one. The wrench first consumes a Logistics Node from your inventory, then checks the linked storage network, and finally requests autocrafting when a pattern is available.

## Remove a Node

Use **Modifier Key 1 (default: Shift) + Secondary Interaction** on a node with the wrench. The node is removed and drops back as a Logistics Node item. Any filters and upgrades installed on the node also drop at the node's position, so nothing is lost.

This is the clean way to pick up a node. Breaking the block the node is attached to also removes the node, but Modifier Key 1 + Secondary Interaction is preferred — you stay in control of which side of the block the node was on, and you do not need to break and replace the block itself.

## Storage Linking

With Applied Energistics 2 or Refined Storage installed, use **Modifier Key 1 + Secondary Interaction** on an active block from that network to toggle the wrench link.

- A wrench holds exactly one storage link: either AE2 or Refined Storage.
- Use the same linked endpoint again to unlink it.
- Trying another endpoint while a link exists leaves the original link unchanged and tells you to unlink first.
- The HUD and tooltip show which backend is linked.
- Linked storage supplies node placement, mass placement, clipboard and label upgrade synchronization, and the upgrade picker. Missing items can be autocrafted when the backend supports it.

Refined Storage actions honor its extract, insert, and autocrafting security permissions.

## Good to Know

- Copying and area selection remain in the other wrench modes.
- Switch to another mode any time with **Modifier Key 1 + Mouse Wheel**; the HUD overlay updates to show the new mode.
