---
navigation:
  title: "I/O Port"
  icon: "io"
  parent: little_big_redstone:logic.md
  position: 10
categories:
  - logic
item_ids:
  - little_big_redstone:io
---

# I/O Port

<RecipeFor id="io" />

I/O ports are how you can input and output redstone signals to and from your circuits. When I/O ports are placed into
a circuit, you will be able to see redstone faces on the sides of the microchip block that may accept or provide a
redstone signal.

<br />

Each I/O port has a direction that it links to: <Color color="#4CFF00">north</Color>,
<Color color="#0094FF">south</Color>, <Color color="#FF0000">east</Color>, <Color color="#FF6A00">west</Color>,
<Color color="#FFFFFF">up</Color>, and <Color color="#FFD800">down</Color>. The color of a direction can be seen on the
side of a microchip by crouching and looking at it.

**NOTE:** Each direction may only either act as an input or output, not both. If I/O ports are placed in a circuit such
that one is an input and the other is an output on the same face - neither port will work and a warning indicator will
be displayed.

<br />

You may also configure the signal strength of an I/O port. When the port is in input mode, the redstone signal inputted
must meet or exceed the signal in order for the port to provide an output of ON. When the port is in output mode, and
the input port is provided with an ON signal, the redstone signal provided will be equal to the signal strength set.

<Row>
	<Column>
		<MicrochipScene color="red" marginWidth="16" includeToolbar={true}>
			<Logic name="input" x="0" y="0" type="io" />
			<Logic name="output" x="32" y="0" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />

			<Wire from="input" fromPort="0" to="output" toPort="0" />
		</MicrochipScene>
	</Column>
	
	<Column>
		<MicrochipScene color="red" marginWidth="16" includeToolbar={true}>
			<Logic name="input" x="0" y="0" type="io" hide={true} />
			<Logic name="output" x="32" y="0" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" />
		
			<Wire from="input" fromPort="0" to="output" toPort="0" />
		</MicrochipScene>
	</Column>
</Row>