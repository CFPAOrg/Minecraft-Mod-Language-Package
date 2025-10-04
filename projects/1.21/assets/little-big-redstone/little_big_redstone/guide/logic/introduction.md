---
navigation:
  title: "Introduction"
  parent: little_big_redstone:logic.md
  position: 0
---

# Introduction to Logic

<FloatingColumn align="right">
	### Index
	<LogicIndex />
</FloatingColumn>

Logic components, or what are also sometimes referred to as logic gates, are what drives your circuit. All logic 
components will either have input or output ports. These ports are how you pass and modify signals to get the results
that you want. Logic components behave purely on a boolean basis - meaning that signals may either have a value of
off (0) or on (1).

<br />

### Truth Tables

Logic will behave differently depending on their input signals, typically in a deterministic manner. Thus, most logic 
components have what is called a truth table associated with them. A truth table is a table that shows the output
state for every combination of inputs for the given logic component. The corresponding page for each logic component
that can be described using a truth table will have one present on it.

Inputs are represented by sequentially ordered letters. For example, the first input would be A, the second B, and so
on and so forth. Outputs are represented by Q. If multiple outputs are present, the Q is followed by subscript denoting
the specific output. For example, Q₁, Q₂, and so on. However, in most cases there will only be one output to a gate.

<br />

### Using Logic

Logic can be placed or picked up in a [Microchip](../microchips.md)'s interface using left-click. While holding logic in your
cursor, you can hold the ctrl key to snap its placement to a grid.

To configure a logic component (if there is anything to configure), you can use right-click on it. This will open a
menu that you can change the settings for the component. Every component's settings are described in their
corresponding page.

For information on how to connect logic together using their ports, see the page on [wires](../redstone_bits.md).

Logic components can be dyed separately from the microchip, but by default they will inherit the color of the microchip
they are placed into. To dye logic components, you can either do so in your crafting grid as you would normally, or you
can right click the logic in the menu with the dye to apply it.

Similarly, you can use a water bucket or snowballs to clear the color from the logic component. Note that snowballs
will be consumed, whereas water buckets will not.