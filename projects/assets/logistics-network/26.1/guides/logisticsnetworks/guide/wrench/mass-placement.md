---
navigation:
  title: Mass Placement
  parent: wrench/index.md
  position: 3
---

# Mass Placement Mode

The mode for building out large, repetitive setups in one action. You mark a rectangular area with two corners, choose which block type inside that area should receive nodes, then place configured nodes on every valid matching block.

Switch to Mass Placement with **Shift + mouse wheel**. The HUD overlay shows the current wrench mode.

## Select an Area

**Right-click a block** to set the first corner. **Right-click another block** to set the second corner. The wrench draws a green cuboid border around the selected area so you can see exactly what will be scanned.

- The selected area is stored on the wrench until you clear it or place nodes.
- Selections are **per-dimension**: an area selected in the Overworld does not apply in the Nether.
- The selected area can contain up to **10,000 blocks**.
- Starting a new area is simple: right-click again after both corners are set, and that click becomes the new first corner.

## Open the Placement Menu

Open the Mass Placement menu with **Shift + right-click**. This works on blocks and in air, so you do not have to aim away from your build.

Once two corners are selected, the menu lists block types inside the area that can accept a node. Pick the block type you want, such as chests, barrels, furnaces, or machines. Blocks without item, fluid, energy, chemical, or source capability are not shown.

Only the chosen block type receives nodes. Other blocks inside the green cuboid are ignored.

## Placement Limits

The area can be large, but a single placement run creates at most **2048 nodes**. If more than 2048 matching capability blocks exist, the menu count shows the cap and placement stops at 2048.

The menu shows:

- Selected area size.
- Nodes required for the chosen target block.
- Required Logistics Node items.
- Required filters and upgrades from the clipboard template.
- Whether the placement can currently run.

## Place Nodes

Click **Place Nodes** and the wrench:

1. Pays the required items out of your inventory or linked AE2 network.
2. Places a node on every valid matching target block, up to 2048 nodes.
3. Applies the clipboard template to every newly placed node: channels, filters, upgrades, label, and network.

If a selected target block changes before placement, the menu re-checks it. Invalid blocks are skipped and no node item is consumed for them.

## Template + Label Sync

Every node placed in a Mass Placement run inherits the clipboard template **including its label**. That means the whole batch lands already in the same label group, with no post-configuration needed.

Typical workflow:

1. Build a template in the [Clipboard Editor](copy-paste.md#clipboard-editor) or copy from a working node.
2. Give the template a label like `furnace_row`.
3. Switch to Mass Placement and right-click two corners around the build area.
4. Shift + right-click to open the menu.
5. Choose the target block type.
6. Click Place Nodes.

Every node that appears already has nine configured channels, the right filters, the right upgrades, and the shared label. Future edits to any one of them propagate to all the others automatically.

## Good to Know

- Mass Placement can place bare nodes without a clipboard template, but copied templates are what make it useful.
- The in-menu **Clear** button wipes the selected area and target block without placing anything.
- The target block choice is recalculated from the current world when the menu opens, so broken or replaced blocks are handled before placement.
