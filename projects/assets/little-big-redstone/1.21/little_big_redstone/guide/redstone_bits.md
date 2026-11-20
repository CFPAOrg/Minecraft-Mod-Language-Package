---
navigation:
  title: "Redstone Bits"
  icon: "redstone_bit"
  position: 2
item_ids:
  - little_big_redstone:redstone_bit
---

# Redstone Bits

<FloatingColumn align="right">
	<PaddedBox left="5">
		<RecipeFor id="redstone_bit" />
	</PaddedBox>
</FloatingColumn>

<FloatingColumn>
	<ItemImage id="redstone_bit" scale="2" />
</FloatingColumn>

Redstone bits are used to create wires that connect between ports. Ports refer to the triangular protrusions on the
side of [logic](logic/introduction.md). Output ports are always on the right side of logic, and input ports are always
on the left side of logic.

Each input port can have exactly one wire connected to it. As for output ports, there is no limit on how many wires
can come out of them. If you need to combine multiple wires into one input port, use an [OR gate](logic/or_gate.md).

Redstone bits work similarly to normal redstone dust, where it may have a signal strength ranging from 0 to 15. Of
course, a signal strength of 0 would mean the wire is off, and 1 and above are considered on.

### Working with wires

Wires can be created by left-clicking an output port, and then left-clicking the desired input port. A held wire can be
discarded by right-clicking. Wires can also be picked up after they have been placed using left-click.

Each wire costs exactly one redstone bit, and the bit will only be consumed once the wire has been connected to the
input port.