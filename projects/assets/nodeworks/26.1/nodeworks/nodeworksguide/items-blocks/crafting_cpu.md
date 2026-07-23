---
navigation:
  parent: items-blocks/index.md
  icon: crafting_core
  title: Crafting CPU
categories:
  - autocrafting
description: the brain of the autocrafting system in a network
item_ids:
- nodeworks:crafting_core
- nodeworks:crafting_storage
- nodeworks:substrate
- nodeworks:stabilizer
- nodeworks:co_processor
---

# Crafting CPU

A Crafting CPU is the brain of the autocrafting system. It reads recipes out of
[Storage Blocks](./storage_blocks.md) (in network and in broadcasted sub-net Processing Sets)
and pulls ingredients out of the network, runs the craft, and puts the result back.
For how to actually *use* a built CPU to run crafts, see [Auto Crafting](../nodeworks-mechanics/autocrafting.md).

## Forming the CPU

A CPU always has exactly one <ItemLink id="crafting_core" /> at its heart. The
Core on its own isn't enough though, it needs at least one <ItemLink id="crafting_storage" />
(the "buffer") touching it somewhere. Without a buffer the CPU has no room to stash
items mid-craft, so it stays dark.

Placement is freeform. You don't need a wrench, and there's no required shape.
Drop a Core down, stick a buffer on any face, wire the Core to a Node, and it lights up.

<GameScene zoom="5" interactive={true} paddingLeft="50" paddingRight="60">
  <ImportStructure src="../assets/assemblies/basic_crafting_cpu.snbt" />
  <BlockAnnotation x="1" y="0" z="0">
    Generates heat and should be paired with 2 Coolant blocks
  </BlockAnnotation>
</GameScene>

> **Tip:** it's recommended for a starter Crafting CPU to have two <ItemLink id="stabilizer" />
> blocks connected to the <ItemLink id="crafting_storage" /> to ensure **Effiency**
> is at least 100%

## Expanding the CPU

The other CPU blocks let you make the same CPU bigger or faster:

- <ItemLink id="crafting_storage" /> (**Crafting Buffer**): required at least
once. More buffers means more room for ingredients and intermediates while
a craft is running. Each one carries **2 heat**.
- <ItemLink id="co_processor" /> (**Crafting Co-Processor**): each one lets
the CPU run one additional craft in parallel. Each one carries **3 heat**.
- <ItemLink id="stabilizer" /> (**Crafting Coolant**): cancels heat. A lone
Coolant block puts out **1 cooling**, but every Coolant block touching it
adds **1 more**. A Coolant block surrounded by four other Coolant blocks
outputs **5 cooling**, so Coolant is much stronger in clusters than spread
out.
- <ItemLink id="substrate" /> (**Crafting Substrate**): the speed lever.
Every face of a Buffer or Co-Processor that touches a Substrate block
speeds the CPU up by **10%**, up to a cap of **4× (400%) speed**.
Substrate faces touching the Core, other Substrate, or Coolant do nothing,
so sandwich Substrate between Buffers and Co-Processors for the best
effect.

All of these just need to touch the Core or chain off something that's already
part of the CPU. No wrench, no GUI step. Add blocks and they get absorbed on the
next tick.

### Heat, cooling, and speed

Every Buffer and Co-Processor you place is its own little furnace, and the Coolant
block's job is to soak up heat from the heart sources it physically touches.
The layout matters as much as the count:

- Stacking heat sources face to face adds an extra **1 heat per shared face**,
  on top of the heat those blocks already carry. A tight cube of Buffers and
  Co-Processors runs much hotter than the same blocks spread out.
- Each Coolant block outputs a total cooling value (1 alone, higher in a
  cluster). That output is **split evenly across the heat sources the
  Coolant is touching**. A Coolant sandwiched between two Buffers gives
  half its cooling to each, a Coolant sitting in the middle of six heat
  sources is almost useless on any one of them.
- When the CPU's total cooling can't cover its total heat, speed **throttles
  down** proportionally, all the way to a floor of **25%**. The CPU never
  stops, it just crawls.
- Coolant only neutralizes heat, it never boosts speed above 100%. The only
  block that does that is Substrate, up to the 4× cap.

<GameScene zoom="5" interactive={false} paddingLeft="60" paddingRight="60">
  <IsometricCamera yaw="180" roll="0" pitch="0" />
  <ImportStructure src="../assets/assemblies/overheating_crafting_cpu.snbt" />

  <LineAnnotation from="2.5 0 0" to="4.5 3 0" color="#ff0000" thickness="0.05" />
  <LineAnnotation from="2.5 3 0" to="4.5 0 0" color="#ff0000" thickness="0.05" />

  <LineAnnotation from="1 0 0" to="2.5 1.25 0" color="#00ff00" thickness="0.05" />
  <LineAnnotation from="1.02 0 0" to="-0.8 3 0" color="#00ff00" thickness="0.05" />
</GameScene>

> **Tip:** there's also a visual indication of a block overheating when it's tinted
> yellow/orange/red or smoking.

The practical takeaway: don't try to smother a big pile of Buffers and
Co-Processors with a handful of Coolant blocks pressed against them.
Build Coolant into dedicated walls or fins (where Coolant blocks touch each
other), and arrange heat sources so each Coolant has only one or two
heat faces to deal with. Then add Substrate on the remaining Buffer/
Co-Processor faces to crank the speed.

## Recipes

<Row>
    <RecipeFor id="nodeworks:crafting_core" />
    <RecipeFor id="nodeworks:crafting_storage" />
    <RecipeFor id="nodeworks:substrate" />
    <RecipeFor id="nodeworks:stabilizer" />
    <RecipeFor id="nodeworks:co_processor" />
</Row>
