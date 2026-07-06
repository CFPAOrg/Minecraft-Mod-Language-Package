---
item_ids: [logisticsnetworks:wrench]
navigation:
  title: Wrench
  icon: logisticsnetworks:wrench
  position: 2
---

# Wrench

The Wrench is the tool you use for everything related to nodes — opening their configuration, removing them, copying setups between nodes, and bulk-placing lots of nodes at once.

It has three modes, and every mode does something different. Cycle through them with **Shift + Mouse Wheel** while holding the wrench. The current mode is shown in the HUD overlay at the top of the screen.

## Modes at a Glance

- [Wrench](wrench-mode.md) — the default. Open a node's configuration, remove nodes, and (with AE2 installed) toggle AE2 linking.
- [Copy / Paste](copy-paste.md) — clone a node's entire setup — channels, filters, upgrades, label — onto another node. Supports bulk-paste to every connected node of the same block type.
- [Mass Placement](mass-placement.md) — select many blocks at once, then place configured nodes on all of them in one click.

## Quick Reference

| Mode | Right-click | Shift + Right-click | Ctrl + Right-click |
|------|-------------|---------------------|--------------------|
| Wrench | Open node config | Remove node (or toggle AE2 link) | — |
| Copy / Paste | Copy node → clipboard (or open Clipboard Editor on air) | Paste clipboard → node | Paste to every connected same-block-type node |
| Mass Placement | Toggle block in selection (or open Placement Menu on air) | Same as right-click | Flood-fill select connected same-block-type |

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
