---
navigation:
  parent: nodeworks-mechanics/index.md
  title: Subnets
  icon: broadcast_antenna
categories:
  - networking
  - mechanic
---

# Subnets

A subnet is just a second network that exposes some of its capabilities
to another network wirelessly. Each subnet has its own
<ItemLink id="network_controller" />, its own storage, and its own
crafting setup. They communicate with the main network through paired
<ItemLink id="broadcast_antenna" />s and
<ItemLink id="receiver_antenna" />s.

<GameScene zoom="3" interactive={true} paddingTop="30" paddingLeft="50" paddingRight="50">
  <ImportStructure src="../assets/assemblies/subnet.snbt" />
</GameScene>

## Why split a network

A monolithic network works fine for small bases, but as you add more
machines and recipes, splitting things up becomes a useful organizing
tool:

- **Specialization**. A subnet dedicated to smelting, brewing, or ore
  processing keeps the recipes and machines for that job in one place
  instead of scattered across the main base.
- **Reuse**. Build a smeltery subnet once, then pair its recipes with
  every base you have.
- **Isolation**. A crash, lag spike, or stuck craft on one subnet
  doesn't affect the rest. Each network runs its own CPU, storage, and
  scripts.
- **Tidiness**. The main network only sees the recipes the subnet
  broadcasts, not the pipes and machines behind them.

## Exposing processing recipes

The most common subnet setup: a subnet that owns a cluster of
<ItemLink id="processing_storage" /> blocks full of
<ItemLink id="processing_set" /> recipes, broadcasting them so any
other network can pull from those recipes during autocrafting.

1. On the subnet, build out the
   <ItemLink id="processing_storage" /> cluster with whatever
   <ItemLink id="processing_set" />s the subnet should provide.
2. Place a <ItemLink id="broadcast_antenna" /> directly on top of any
   <ItemLink id="processing_storage" /> in the cluster.
3. Pair it with a <ItemLink id="link_crystal" /> from the antenna's GUI.
4. On the receiving network, place a
   <ItemLink id="receiver_antenna" /> wired into the network and slot
   the same <ItemLink id="link_crystal" /> into its GUI.

The receiving network now sees every recipe in the subnet's Processing
Storage cluster as if they were stored locally. Crafts that need those
recipes work like any other autocraft.

The subnet still owns the machines and ingredients. The receiving
network just gets to ask for the output and trust the subnet to deliver.

## Wireless item transfer

Subnets can also exchange items directly using broadcasting
<ItemLink id="export_chest" />s paired to
<ItemLink id="receiver_antenna" />s on top of
<ItemLink id="import_chest" />s. See the export chest and receiver
antenna pages for the pairing flow.

## Range

Antennas have a default range of 128 blocks. Range upgrades extend that
across chunks and dimensions, so a subnet doesn't have to be next to
the network using it. Common patterns:

- A smeltery subnet in the Nether feeding a main base in the Overworld.
- A mob farm subnet broadcasting drops to a sorting base elsewhere.
- A shared "library" subnet of generic recipes that every other base
  on the server consumes.
