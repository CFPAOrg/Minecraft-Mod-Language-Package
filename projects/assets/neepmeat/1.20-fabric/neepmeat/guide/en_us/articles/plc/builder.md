---
id: builder
lookup: neepmeat:builder
---

# Builder

The Builder is a robot that can place and break blocks, controllable by a PLC. It has a base station, which gives access to its inventory and shows its currently selected slot.

## Usage

There are a number of operations that can control a Builder:

- BPLACE
- BBREAK
- SELSLOT
- SELITEM

## Inventory

Any items dropped from blocks that a Builder breaks will go directly into its inventory.

Before it can place a block, a Builder needs to know what item it should place. 

With the `SELSLOT` and `SELITEM` operations, an inventory slot or a specific item can be selected. 

`SELSLOT` takes an integer from the stack and tells the Builder to use items in that inventory slot.

`SELITEM` takes a string and tells the Builder to only use items whose IDs match the string.

## Example 1

This example shows the use of `BPLACE`, `BBREAK`, `SELSLOT` and `SELITEM`.

```
# Select the Builder at coordinates (1, 2, 3)
robot @(1 2 3) 

# Select the first slot
0 selslot

# Place a block
@(2, 2, 3) .bplace

# Break a block
@(2, 2, 3) .bbreak

# Select an item
selitem "minecraft:dirt"

# The pattern string can also be read from the stack:
"minecraft:dirt" .selitem -

# Place a dirt block
@(2, 2, 3) .bplace
```

## Example 2

This example shows how to fill a cuboid area with dirt. It uses the `AREA3` instruction to iterate through a cuboid area.

The `AREA3` operation calls an execution address for each block within an area defined by two corner positions. The first argument it takes is the execution address. The second and third arguments are corner positions.

```
selitem "minecraft:dirt"

# Create a callback word
# It consumes a world target, and returns nothing.
: callback ( pos -- )
    bplace
    # Discard the result of BPLACE
    drop
;

# Grab the execution address of callback
"callback" '

# First corner
@(0 0 0)

# Second corner
@(10 10 10)
area3
```