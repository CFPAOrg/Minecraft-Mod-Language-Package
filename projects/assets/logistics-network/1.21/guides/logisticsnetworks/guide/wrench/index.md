---
item_ids: [logisticsnetworks:wrench]
navigation:
  title: Wrench
  icon: logisticsnetworks:wrench
  position: 2
---

# Wrench

The Wrench is the tool you use for everything related to nodes — opening their configuration, removing them, copying setups between nodes, and bulk-placing lots of nodes at once.

It has three modes. Hold **R** while holding the wrench to open the mode wheel, point at a mode, then release to select it. Release in the centre or press Escape to cancel. Remap the wheel key in Minecraft's Controls menu.

You can also cycle modes with **Modifier Key 1 (default: Shift) + Mouse Wheel**. The HUD beside the hotbar shows the active mode: blue for Wrench, green for Copy / Paste, and gold for Mass Placement.

## Modes at a Glance

- [Wrench](wrench-mode.md) — the default. Open or remove nodes, place nodes, and link an AE2 or Refined Storage network.
- [Copy / Paste](copy-paste.md) — clone a node's entire setup — channels, filters, upgrades, label — onto another node. Supports bulk-paste to every connected node of the same block type.
- [Mass Placement](mass-placement.md) — select a two-corner area, choose a target block type, then place configured nodes on matching blocks with **Primary Interaction (default: Left Click)**.

## Quick Reference

| Mode | Secondary Interaction (default: Right Click) | Modifier Key 1 + Secondary Interaction | Modifier Key 2 (default: Ctrl) + Secondary Interaction |
|------|-------------|---------------------|--------------------|
| Wrench | Open node config | Remove a node, place a node, or toggle a storage link | — |
| Copy / Paste | Copy node → clipboard (or open Clipboard Editor on air) | Paste clipboard → node | Paste to every connected same-block-type node |
| Mass Placement | Set area corners (or open Placement Menu on air) | Open Placement Menu | — |

## Using Labels With The Wrench

Labels pair very well with the wrench. When you paste a setup onto a node, the source's label is copied too — so the pasted node immediately joins that label group and stays in sync with every other node sharing the label.

Typical workflow:

1. Configure one node with the setup you want.
2. Give it a label (see [Header → Set Label](../nodes/header.md)).
3. Copy its config onto the wrench clipboard.
4. Paste (or mass-place) onto all the other nodes that should share this setup.

Every node now carries the same label. Later edits to any one of them propagate to the whole group automatically. You do not need to re-copy-paste when tweaking.

## Crafting Recipe

<RecipeFor id="logisticsnetworks:wrench" />
