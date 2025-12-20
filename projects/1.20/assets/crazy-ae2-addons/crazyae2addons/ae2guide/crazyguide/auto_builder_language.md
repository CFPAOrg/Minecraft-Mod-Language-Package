---
navigation:
  parent: crazyae2addons_index.md
  title: Auto Builder Language
  icon: crazyae2addons:builder_pattern
categories:
   - Monitoring and Automation
item_ids:
   - crazyae2addons:builder_pattern
---

# AutoBuilder Programming Language – Full Tutorial

The AutoBuilder language lets you script a programmable builder, which executes actions like moving, placing blocks, breaking blocks, waiting, and more — using a concise, macro-friendly syntax.

---

## Program Structure

Each AutoBuilder program is split into 2 or 3 parts, separated by the pipe symbol |:

BLOCK_MAP | MACROS | MAIN_PROGRAM

You may also skip macros:

BLOCK_MAP | MAIN_PROGRAM

### Block Map

Defines what blocks can be used and assigns them numeric IDs. The syntax is:

0(minecraft:stone),1(minecraft:dirt),2(minecraft:oak_planks)

Each entry is:

\<number\>(\<block_id\>)

Block IDs **must not** contain NBT data, but can include blockstates for example:

0(minecraft:oak_log\[axis=y\])

### Macros (optional)

Macros are reusable blocks of code, defined using square brackets:

\[macroName\](instructions)

Example:

\[stairs\](P(0)D) \[floor\](3{P(1)R})

In your main program, use them like:

\[floor\]\[stairs\]

### Program Code

This is where your logic goes. It can use raw instructions, loops, macros, and block placement.

---

## Instructions Reference

### Movement

| Code | Meaning          |
|------|------------------|
| U    | Move Up          |
| D    | Move Down        |
| F    | Move Forward     |
| B    | Move Backward    |
| L    | Move Left        |
| R    | Move Right       |
| H    | Return Home      |
| X    | Clear (break)    |

All directions are **relative to the AutoBuilder’s current facing orientation**, not world cardinal directions.

Each move shifts the builder cursor by **1 block** in that direction.

---

### Place Block

P(n)

Places a block defined in the block map. For example:

P(0)

Places block with ID 0, e.g. minecraft:stone.

---

### Break Block

X

Breaks the block at the current position.

---

### Loops

3{ ... }

Repeats the contents of the curly braces **3 times**.

Example:

4{P(1)R}

Places block "1" and moves right, 4 times.

Loops can be nested.

Example:

2{3{P(1)F}U}

Repeat: 3x place + move forward, then move up. Do this sequence 2 times.

---

### Wait

Z(n)

Waits for "n" Minecraft ticks (20 ticks = 1 second).

Example:

P(0)Z(40)P(1)

Place block 0, wait 2 seconds, place block 1.

---

### Return Home

H

Returns the builder to its starting position.

---

### Macros

Defined in the macro section, and used in the program with:

[macroName]

Macros can include other macros, loops, etc.

Example:

\[stairStep\](P(0)U F)

---

## Examples

### 1. Simple 3-block line of stone

0(minecraft:stone) | P(0)F P(0)F P(0)F

Same using a loop:

0(minecraft:stone) | 3{P(0)F}

---

### 2. Destroy and Rebuild

0(minecraft:oak_planks) | X Z(20) P(0)

Break block, wait 1 second, place oak planks.

---

### 3. Build staircase

0(minecraft:oak_planks) | 5{P(0)U F}

Builds 5 steps upward and forward.

---

### 4. Return to base

0(minecraft:stone) | 4{P(0)F} H

Build a path 4 blocks to the front, then return to start.

---

### 5. Using Macros

0(minecraft:stone),1(minecraft:dirt) | \[line\](3{P(0)F}) \[top\](U \[line\]) | \[line\]\[top\]\[line\]

- Defines a "line" of stone (3 blocks to the front).
- Defines "top" as 1 layer higher with the same line.

---

## Error Handling

The language is strict:

- P(n) with missing ID in block map -> error.
- Unbalanced brackets ({}, (), []) -> error.
- Infinite macro recursion -> error.