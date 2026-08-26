---
navigation:
  title: Mass Placement
  parent: wrench/index.md
  position: 3
---

# Mass Placement Mode

The mode for building out large, repetitive setups in one action. You walk around flagging blocks, then open the placement screen and place a pre-configured node on every flagged block in one click.

Switch to Mass Placement with **Shift + mouse wheel**. The HUD overlay shows the mode and the current selection count.

## Select Blocks

**Right-click a block** to add it to the wrench's selection set. Right-click the same block again to remove it.

- Selections persist on the wrench until you clear them or place, so you can walk around, load a new chunk, come back — the selection is still there.
- Selections are **per-dimension**: blocks you flag in the Overworld are tracked separately from blocks flagged in the Nether, so a selection made in one dimension does not accidentally carry into another.
- Maximum **2048 selections per wrench**. Beyond that the newest selection is rejected.

## Flood-Fill Select

**Ctrl + right-click a block** to select every connected block of the **same block type** in one go. This is how you light up a long row of furnaces, a storage wall of chests, or a branching line of machines without clicking each one by hand.

Same 2048 cap applies.

## Placement Menu

Once you have your selection, **right-click air** (no block in front of you) to open the Mass Placement menu. The menu shows:

- Total selections.
- Valid selections (selections that can actually accept a node — blocks that still exist, have storage, and have not been built over).
- Required items — the Logistics Node items, plus any filter and upgrade items the clipboard template needs.

The menu also has a **Place Nodes** button. Click it and the wrench:

1. Pays the required items out of your inventory.
2. Places a node on every valid selection.
3. Applies the clipboard template to every newly placed node — same channels, filters, upgrades, label, and network as the template.

Invalid selections are skipped with no charge; valid selections that fail mid-run (inventory ran out, chunk unloaded, etc.) are reported so you know exactly how many landed.

## Template + Label Sync

Every node placed in a Mass Placement run inherits the clipboard template **including its label**. That means the whole batch lands already in the same label group — no post-configuration needed.

Typical workflow:

1. Build a template in the [Clipboard Editor](copy-paste.md#clipboard-editor) (or copy from a working node).
2. Give the template a label like `furnace_row`.
3. Switch to Mass Placement, select every target block.
4. Open the menu and click Place Nodes.

Every node that pops into existence already has nine configured channels, the right filters, the right upgrades, and the shared label. Future edits to any one of them propagate to all the others automatically.

## Good to Know

- Mass Placement does nothing without a clipboard template. If the wrench is empty, the menu's Place Nodes button is disabled. Copy something first.
- Clearing selections: the in-menu **Clear Selection** button wipes the entire selection set without placing anything.
- You do not have to place everything at once — close the menu and keep collecting more selections; the wrench remembers the list.
