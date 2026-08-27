---
navigation:
  parent: items-blocks/index.md
  icon: instruction_set
  title: Recipe Sets
categories:
  - autocrafting
description: stores crafting recipes for [autocrafting](../nodeworks-mechanics/autocrafting.md)
item_ids:
- nodeworks:instruction_set
- nodeworks:processing_set
---

# Recipe Sets

There are two types of recipe sets that are used to store crafting recipes used
in [autocrafting](../nodeworks-mechanics/autocrafting.md).

Recipes Sets are template items that store a single recipe for the
[autocrafting](../nodeworks-mechanics/autocrafting.md) system to carry out. Each
Set is authored in its own GUI, then dropped into a matching [Storage Block](./storage_blocks.md)

Two flavors exist, covering two kinds of recipes:

- **Instruction Set:** vanilla 3x3 crafting recipes (shaped and shapeless)
- **Processing Set:** everything else (smelting, modded machines, multi-output processes, anything with a timeout)

---

## Instruction Set

<ItemImage scale="4" id="instruction_set" />

A 3x3 crafting template. Anything that works in a vanilla crafting table works here.

### Creating a recipe

Right-click to open. Click a ghost slot with an item in hand to pin a ghost
copy there (no inventory consumption), click an empty slot again to clear.
The result slot auto-fills whenever the pattern matches a known crafting
recipe. **Clear All** resets the grid.

The GUI also has a **tag substitutions** toggle. When on (the default),
the recipe accepts any item from the same tag as the pinned ingredient,
so an oak plank slot will happily use birch, spruce, or anything else in
`#minecraft:planks`. Turn it off to lock the recipe to exact item ids.

> **Tip:** JEI's **(+)** recipe-transfer button works on this GUI so you can pick any crafting
> recipe in JEI and hit (+) to fill the grid in one step

### Deploying it

Drop the filled Set into an <ItemLink id="instruction_storage" />. Adjacent
Instruction Storages form a cluster. Every Set in the cluster is visible to
the CPU as long as *any* block in the cluster is on the network.

---

## Processing Set

<ItemImage scale="4" id="processing_set" />

A freeform recipe with up to 9 inputs and 3 outputs, plus an optional
per-craft timeout. Use it for anything the 3×3 grid can't express (smelting,
blasting, modded machine recipes, multi-output processes, or anything where
*"N ticks elapse before the output appears"*)

### Creating a recipe

Right-click to open. The GUI has:

- **Input grid**: (3×3) ghost slots for any inputs, in any position.
- **Output column**: (3 slots) ghost slots for outputs.
- **Timeout field**: 0–999 ticks (0 = no timeout). `+` and `-` buttons step by 20, shift-click steps by 100.
- **Serial toggle**: when on, the CPU won't run this recipe in parallel with
  itself.
- **Clear All**: resets everything.

Per-slot counts are adjusted by scrolling over a filled slot (scroll up +1,
scroll down -1, scroll down at 1 clears).

> **Tip:** JEI's **(+)** works here too, and it's *universal*. Any recipe category JEI
> knows about (smelting / blasting / modded) is fair game.

### Deploying it

Drop the filled Set into a <ItemLink id="processing_storage" />. Like
Instruction Storage, adjacent Processing Storages form a cluster. The CPU
coordinates with whichever external machine actually carries out the recipe.

## Recipes

<Row>
    <RecipeFor id="instruction_set" />
    <RecipeFor id="processing_set" />
</Row>