---
navigation:
  title: Copy / Paste
  parent: wrench/index.md
  position: 2
---

# Copy / Paste Mode

This mode turns the wrench into a clipboard tool. You copy a fully configured node onto the wrench, then paste that setup onto other nodes — one at a time, or in bulk across every matching connected block. Copy/Paste also has a dedicated editor screen if you want to build a template directly on the wrench without touching a live node.

Switch to Copy/Paste with **Shift + mouse wheel**. The HUD overlay confirms the mode.

## Copy a Node

**Right-click a configured node** with the wrench. The wrench clipboard is replaced with a full copy of the node's setup:

- All 9 channels (status, mode, type, side, redstone, distribution, priority, batch, delay, channel name).
- Every filter item in every channel's filter grid.
- Every upgrade installed on the node.
- The node's label.
- The node's network assignment.
- The node's render visibility state.

Nothing is removed from the node — copying is non-destructive. The clipboard is stored on the wrench item itself and **persists across game sessions**, so you can craft a wrench, copy a template, put it in a chest, and pick it back up weeks later.

## Paste Onto a Node

**Shift + right-click a node** with the wrench. The wrench tries to apply its clipboard to the target node. Three things happen on a successful paste:

1. The target node's channels, filters, and upgrades are overwritten with the clipboard's setup.
2. Any filter or upgrade items that the target needs and is missing are **pulled out of your inventory automatically**. The wrench figures out what it has to consume.
3. Any filter or upgrade items that the target had **before** the paste are returned to your inventory. If your inventory is full, they drop on the ground next to you so nothing is lost.

### When a paste fails

- **Missing items** — you do not have the filter or upgrade items the clipboard's template requires. The paste is aborted; nothing on the target node changes. Grab the missing items and try again.
- **No changes** — the clipboard is empty or matches the target exactly; nothing to do.

The wrench prints a short chat message telling you what happened.

### Copy/Paste also copies the label

Pasting **keeps the clipboard's label** on the target node. This means the target instantly joins the source's label group and stays in sync with it — any future tweak to one label-mate applies to every node with the same label.

If you do not want the label to carry over, edit the clipboard (see below) and clear the label field before pasting.

## Bulk Paste to Connected Blocks

**Ctrl + right-click a node** in Copy/Paste mode. The wrench flood-fills from that node through every **connected block of the same block type** (scanning up to 16,384 blocks) and pastes the clipboard onto every node it finds on that connected run.

Typical use: you have a long row of 20 furnaces with nodes on each one. Configure one furnace node, copy it, then Ctrl + right-click any of the 20 — all 19 others are updated at once.

Inventory consumption rules still apply per node: if you run out of filter or upgrade items mid-paste, the remaining nodes are skipped and the wrench tells you how many were applied.

## Clipboard Editor

Instead of copying from a live node, you can build a template directly on the wrench.

**Right-click air** (no block in front of you) in Copy/Paste mode. The Clipboard Editor screen opens. Inside you can:

- Edit every channel setting (status, mode, type, side, redstone, distribution, priority, batch, delay, name) exactly as you would on a real node.
- Drag filter items from your inventory into the filter slots; drag them back to remove.
- Drag upgrade items into the upgrade slots.
- Clear the whole clipboard with the **Clear Clipboard** button.

Changes are saved to the wrench's NBT when the menu closes, so the template persists.

The Clipboard Editor is useful for designing a setup once and mass-placing it onto fresh blocks without ever configuring a physical reference node first.
