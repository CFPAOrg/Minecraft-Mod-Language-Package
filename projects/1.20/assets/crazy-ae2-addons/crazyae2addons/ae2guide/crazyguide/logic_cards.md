---
navigation:
  parent: crazyae2addons_index.md
  title: Logic Cards
  icon: crazyae2addons:add_card
categories:
  - Data Variables
---

## Logic Cards Overview

<ItemImage id="crazyae2addons:add_card" scale="4"></ItemImage>
<ItemImage id="crazyae2addons:sub_card" scale="4"></ItemImage>

When configuring Data Processors and Isolated Data Processors, you will use logic cards to define operations:

- **Add Card**: Adds two numbers.
- **Sub Card**: Subtracts the second number from the first.
- **Mul Card**: Multiplies two numbers.
- **Div Card**: Divides the first number by the second (only if the second is not zero).
- **Min Card**: Returns the smaller of two numbers.
- **Max Card**: Returns the larger of two numbers.
- **BSR Card**: Bitwise right shift (shifts bits of the first number to the right by the second number).
- **BSL Card**: Bitwise left shift (shifts bits of the first number to the left by the second number).
- **HIT Card**: Conditional jump. If the first number is greater than 0, jumps to the slot number specified by the second number.
- **HIF Card**: Conditional jump. If the first number is less than or equal to 0, jumps to the slot number specified by the second number.

Logic cards allow you to create complex math operations, conditional checks, loops, and branching behaviors.