---
navigation:
  parent: items-blocks/index.md
  icon: diagnostic_tool
  title: Diagnostic Tool
categories:
  - tool
description: inspect a network's topology, CPUs, scripts, and recent errors
item_ids:
- nodeworks:diagnostic_tool
---

# Diagnostic Tool

A handheld inspector for a Nodeworks network. Right-click any block on
a network to open a panel that summarises everything the network is
made of and everything it's currently doing.

<ItemImage scale="6" id="diagnostic_tool" />

## How to use it

Right-click any network block on the target network. A
<ItemLink id="node" />, <ItemLink id="terminal" />,
<ItemLink id="network_controller" />, antenna, or storage block all
work. You can also click any piece of a
[Crafting CPU](crafting_cpu.md) multiblock (Core, Buffer, Coolant,
Substrate, Co-Processor); the tool walks the cluster to find the Core
for you.

If the block you click isn't on a network, the tool tells you so via an
overlay message and doesn't open.

## What it shows

The diagnostic panel pulls together everything the network exposes:

- **Topology**. Every block on the network with its position, type, and
  per-block details. <ItemLink id="node" />s list the cards on each
  face along with the adjacent block they target.
- **Network identity**. The controller's name and colour, with a quick
  glance at its redstone mode, handler retry limit, and chunk-loading
  toggle.
- **CPUs**. Each <ItemLink id="crafting_core" /> on the network, its
  current craft (if any), buffer usage, efficiency, and whether the
  multiblock is properly formed.
- **Terminals**. Every <ItemLink id="terminal" /> on the network with
  its script list, autorun flag, running state, and which
  [Processing Set](recipe_sets.md#processing-set) handlers each running
  script has registered.
- **Craftable items**. The full list of items the network can
  autocraft, gathered from every <ItemLink id="instruction_storage" />
  and <ItemLink id="processing_storage" />.
- **Recent errors**. The last 10 script errors from terminals on the
  network, with the tick offset showing how long ago each one fired.

The view is read-only. Nothing you click in the panel changes the
network, it's purely for figuring out what's where and what went
wrong.

## When to reach for it

- A craft failed and you want to see the error without standing next
  to the <ItemLink id="crafting_core" />.
- You inherited a sprawling network and need a map.
- You're trying to figure out why a recipe isn't autocraftable, the
  craftable-item list shows what the network actually knows how to make.
- A script seems stuck, the terminal panel surfaces its running state
  and registered handlers without opening every terminal manually.

## Recipe

<RecipeFor id="diagnostic_tool" />
