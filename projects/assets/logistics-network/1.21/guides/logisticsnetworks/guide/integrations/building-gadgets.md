---
navigation:
  title: Building Gadgets
  parent: integrations/index.md
  position: 2
---

# Building Gadgets

With [Building Gadgets](https://www.curseforge.com/minecraft/mc-mods/building-gadgets) installed, nodes travel with the blocks they are attached to. The Cut and Paste gadget moves them, and the Copy and Paste gadget and templates copy their settings.

## Cut and Paste — Moving Nodes

Cutting an area picks up every node attached to a block inside it. Nothing drops. When you paste, each node is put back on its block as soon as the block finishes its placement animation, exactly as it was:

- Same network, channels, filters, upgrades, label, visibility and owner.
- Nodes stay members of their network while they are in the gadget, so cutting a whole build does not delete the network.
- Rotating the cut before pasting rotates every channel's side with the blocks. Up, Down and All stay as they are.

Moving is free — the nodes and their upgrades travel with the cut, so nothing is charged.

## Copy and Paste — Copying Node Settings

Copying an area also records the settings of every node in it that you can access (your own, and your teammates' where the server allows it). The settings are the same ones the [Wrench clipboard](../wrench/copy-paste.md) copies: channels, filters, upgrades, label, network and visibility.

Pasting creates a new node on each pasted block:

- **Survival:** each node costs one Logistics Node plus every upgrade it had. They are taken from the same places the gadget takes blocks from — a bound inventory, Curios, backpacks and your inventory. Filters are free.
- **Creative:** free.
- **Missing items:** the block is still placed, but without a node. The action bar shows `Node not pasted, needs: …` with what was missing.
- The gadget's **Material List** includes the Logistics Nodes and upgrades the paste will need.

Pasted nodes join the original network if it still exists and you can access it. Otherwise a new network is created for you, named after the original — one per original network per paste, never one per node.

If an area holds too many node settings, chat says `Too many node settings to copy; nodes were left out` and only the blocks are copied.

## Templates

Templates saved in the Template Manager, exported template JSON and redprints keep the copied node settings. Pasting one follows the Copy and Paste rules above, including the item cost. A template brought in from another world creates new networks named after the originals.

## Good to Know

- If a pasted block cannot hold a node — no storage, it already has a node, or it is blacklisted — that node's items drop on the spot.
- If part of a cut could not be pasted (space occupied, protected or out of energy), the leftover nodes drop at your feet when the paste finishes.
- Undoing a paste while blocks are still animating gives back the node items it took.
- The Copy and Paste undo and the Destruction gadget do not restore nodes. A node on a removed block drops like a normal break.
- Swapping a block with the Exchanger drops the node that was on it.
- Cutting again with a gadget that still holds an unpasted cut replaces that cut, and its nodes are lost along with its blocks.
- Nodes on moving Create contraptions are left alone.
