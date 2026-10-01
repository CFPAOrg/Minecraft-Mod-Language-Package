---
navigation:
  parent: items-blocks/index.md
  icon: network_wrench
  title: Network Wrench
description: toggles pipe connections and links Focus Nodes
item_ids:
- nodeworks:network_wrench
---

# Network Wrench

The Network Wrench is how you adjust the shape of a network without
breaking anything. It toggles individual pipe connections between blocks
and links <ItemLink id="focus_node" />s across distance.

<ItemImage scale="6" id="network_wrench" />

## Toggling pipe connections

Shift + right-click any face where two network blocks are touching to
toggle the pipe stub between them. The blocks stay where they are, but
the network treats the side as if there's no pipe there.

This is the everyday use of the wrench. A few common reasons to reach
for it:

- Keep a <ItemLink id="node" /> sitting next to a <ItemLink id="pipe" />
  without the two merging into one network branch
- Split a single network into two by toggling off a single pipe face
- Stop a <ItemLink id="terminal" /> or device from picking up an
  accidental adjacency to a neighbouring network

Repeat the action on the same face to restore the connection.

## Linking Focus Nodes

<ItemLink id="focus_node" />s are the exception. Two Focus Nodes can be
wired across distance with the wrench:

1. Shift + right-click a Focus Node on a face that isn't touching
   another network block to select it as the pending source. The block
   gains a border to show it's selected.
2. Right-click another Focus Node to toggle a link between the two.

The selection sticks after a successful link so you can chain one source
to many targets without re-selecting between each.

### Rules

- Both Focus Nodes must be in the **same dimension** as the selection.
- They must belong to the **same network controller**. The wrench won't
  bridge two separate networks.

The wrench tells you which rule failed via a chat message.

## Recipe

<RecipeFor id="network_wrench" />
