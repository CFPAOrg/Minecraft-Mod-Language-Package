---
navigation:
  title: Wrench Mode
  parent: wrench/index.md
  position: 1
---

# Wrench Mode

The default mode. If you just crafted a wrench and picked it up, it is already in this mode. This is where you go to open a node's settings, remove a node, or link up an AE2 controller if AE2 is installed.

## Open Node Configuration

**Right-click a placed node** with the wrench in Wrench mode. The node configuration screen opens and you can edit all 9 channels, filters, upgrades, labels, and so on.

Nothing happens if you right-click a block that does not have a node on it — the wrench does not place nodes. Place nodes by holding a **Logistics Node** item in your hand and right-clicking the block instead.

## Remove a Node

**Shift + right-click a node** with the wrench. The node is removed and drops back as a Logistics Node item. Any filters and upgrades installed on the node also drop at the node's position, so nothing is lost.

This is the clean way to pick up a node. Breaking the block the node is attached to also removes the node, but shift-right-click is preferred — you stay in control of which side of the block the node was on, and you do not need to break and replace the block itself.

## AE2 Linking (if Applied Energistics 2 is installed)

When AE2 is installed alongside Logistics Networks, the wrench gains one extra use in this mode: **shift + right-click an AE2 block** (drive, controller, interface, subnet-capable block) to toggle the AE2 link.

- Linking an AE2 block lets the logistics network treat it as a bridged storage destination.
- Unlinking severs that bridge.
- The HUD overlay at the top of the screen shows whether the wrench is currently "AE2-linked" — useful for checking before you start clicking.

If AE2 is not installed, shift + right-click on non-node blocks does nothing.

## Good to Know

- The wrench in this mode is purely **configuration and removal**. It never places nodes, never copies, and never selects — those are the other modes.
- Switch to another mode any time with **Shift + mouse wheel**; the HUD overlay updates to show the new mode.
