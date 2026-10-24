---
navigation:
  parent: nodeworks-mechanics/index.md
  title: Network Storage
  icon: minecraft:chest
categories:
  - mechanic
---

# Network Storage

Network Storage is the shared pool of items and fluids a Nodeworks network
treats as its own. Any block with a <ItemLink id="storage_card" /> installed
joins this pool. Scripts read from and write to it, the
<ItemLink id="inventory_terminal" /> displays and interacts with it, and the
crafting system pulls ingredients from it.

<GameScene zoom="5" interactive={true} paddingLeft="50" paddingRight="60">
  <ImportStructure src="../assets/assemblies/network_storage.snbt" />
  <BoxAnnotation min="2.25 1.1 0.1" max="2 1.9 0.9" color="#AA83E0">
    <ItemImage id="nodeworks:storage_card" /> includes this chest into Network Storage
  </BoxAnnotation>
  <BoxAnnotation min="2.25 0.1 0.1" max="2 0.9 0.9" color="#AA83E0">
    <ItemImage id="nodeworks:storage_card" /> includes this chest into Network Storage
  </BoxAnnotation>
  <BlockAnnotation x="3" y="1" z="0">
    You can use the <ItemLink id="inventory_terminal" /> to view inside Network Storage
  </BlockAnnotation>
</GameScene>

## What's in the Network Storage pool

Everything inside every block attached to a <ItemLink id="storage_card" />. If you break a
Storage Card's node connection, that block drops out of the pool immediately.

### Not in the pool

<ItemLink id="io_card" />'s blocks are NOT part of Network Storage.
Scripts have to explicitly move items to/from an IO-carded block. The
network won't see its contents via `network:find`, and the <ItemLink id="inventory_terminal" /> or <ItemLink id="portable_inventory_terminal" /> won't list them.

## Priority and routing

Each <ItemLink id="storage_card" /> has a **priority** that controls the order
`network:insert` / `:tryInsert` fill storage. Writes land in the highest-priority
matching card first and spill into lower-priority cards as each one fills up.
Two cards with the same priority are filled in connection order.

Scripts can override the default priority order for specific items by registering
a route with [`network:route`](../lua-api/network.md#route).

Set a card's priority directly in its GUI. See
[Storage Card](../items-blocks/storage_card.md#configuring-priority) for the interface, and
the <ItemLink id="card_programmer" /> for copying priority (and every other
card setting) across a batch of cards at once.

## Scripting with Network Storage

See the [Network API](../lua-api/network.md) page for the full set of read/write
functions scripts use to interact with the pool.

## Viewing and managing through the Inventory Terminal

<Row align="center">
  <BlockImage scale="3.3" id="inventory_terminal" />
  <ItemImage scale="4" id="portable_inventory_terminal" />
</Row>

The <ItemLink id="inventory_terminal" /> and <ItemLink id="portable_inventory_terminal" /> are the primary
ways to see and interact with Network Storage without writing scripts.
It shows the full pool in a searchable grid, lets you extract items into your
inventory, insert items back into storage, and request crafts. Everything it
displays is pulled live from the Storage Cards connected to this network.

See the [Inventory Terminal](../items-blocks/inventory_terminal.md) page for
the interface details.
