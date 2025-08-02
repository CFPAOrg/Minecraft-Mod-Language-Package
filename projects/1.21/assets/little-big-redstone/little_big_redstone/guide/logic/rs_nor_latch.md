---
navigation:
  title: "RS NOR Latch"
  icon: "rs_nor_latch"
  parent: little_big_redstone:logic.md
  position: 23
categories:
  - logic
item_ids:
  - little_big_redstone:rs_nor_latch
---

# RS NOR Latch

<FloatingColumn width="100" align="right">
	### Truth Table
	<TruthTable inputs="2" outputs="1">
		<TruthState input="0,0" output="0" />
		<TruthState input="0,1" output="0" />
		<TruthState input="1,0" output="1" />
		<TruthState input="1,1" output="0" />
	</TruthTable>
	*For details about truth tables, see the page [here](introduction.md).*
</FloatingColumn>

<Row>
	<Column>
		<RecipeFor id="rs_nor_latch" />
	</Column>

	<Column>
		<GameScene zoom="1.48" padding="3" interactive={true}>
			<ImportStructure src="../assets/structures/rs_nor_latch.snbt" />
			<IsometricCamera yaw="150" pitch="30" />
		</GameScene>
	</Column>
</Row>

The rs nor latch, also known as the reset-set nor latch, is a logic component that has 2 inputs and 1 output.

Input A, or what is also referred to as the Set input, when ON will set the output to ON and it will remain ON even
after A has turned OFF. Any further ON inputs to A will not change the output, so long as the output is still ON.

Input B, also known as the Reset input, when ON will set the output to OFF and it will remain OFF even after B has
turned OFF - assuming that A is also OFF. Any further ON inputs to B will not change the output, so long as the
output is still OFF.

When A and B are both ON, the output state is OFF.

<Row>
	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="a" x="0" y="0" type="io" data="{config:{direction:'east'}}" hide={true} />
			<Logic name="b" x="0" y="8" type="io" data="{config:{direction:'west'}}" hide={true} />
			<Logic name="rs_nor_latch" x="32" y="4" type="rs_nor_latch" />
			<Logic name="output" x="64" y="4" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />

			<Wire from="a" fromPort="0" to="rs_nor_latch" toPort="0" />
			<Wire from="b" fromPort="0" to="rs_nor_latch" toPort="1" />
			<Wire from="rs_nor_latch" fromPort="0" to="output" toPort="0" />
		
			<RedstoneSignal step="0" direction="east" strength="15" />
			<RedstoneSignal step="1" direction="east" strength="0" />
			<RedstoneSignal step="2" direction="west" strength="15" />
			<RedstoneSignal step="3" direction="west" strength="0" />
		</MicrochipScene>
	</Column>

	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="a" x="0" y="0" type="io" data="{config:{direction:'east'}}" hide={true} />
			<Logic name="b" x="0" y="8" type="io" data="{config:{direction:'west'}}" hide={true} />
			<Logic name="rs_nor_latch" x="32" y="4" type="rs_nor_latch" />
			<Logic name="output" x="64" y="4" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />
		
			<Wire from="a" fromPort="0" to="rs_nor_latch" toPort="0" />
			<Wire from="b" fromPort="0" to="rs_nor_latch" toPort="1" />
			<Wire from="rs_nor_latch" fromPort="0" to="output" toPort="0" />
		
			<RedstoneSignal step="0" direction="east" strength="15" />
			<RedstoneSignal step="1" direction="east" strength="0" />
		</MicrochipScene>
	</Column>

	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="a" x="0" y="0" type="io" data="{config:{direction:'east'}}" hide={true} />
			<Logic name="b" x="0" y="8" type="io" data="{config:{direction:'west'}}" hide={true} />
			<Logic name="rs_nor_latch" x="32" y="4" type="rs_nor_latch" />
			<Logic name="output" x="64" y="4" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />
		
			<Wire from="a" fromPort="0" to="rs_nor_latch" toPort="0" />
			<Wire from="b" fromPort="0" to="rs_nor_latch" toPort="1" />
			<Wire from="rs_nor_latch" fromPort="0" to="output" toPort="0" />
		
			<RedstoneSignal step="0" direction="west" strength="15" />
			<RedstoneSignal step="1" direction="west" strength="0" />
		</MicrochipScene>
	</Column>

	<Column>
		<MicrochipScene color="red">
			<Logic name="a" x="0" y="0" type="io" data="{config:{direction:'east'}}" hide={true} />
			<Logic name="b" x="0" y="8" type="io" data="{config:{direction:'west'}}" hide={true} />
			<Logic name="rs_nor_latch" x="32" y="4" type="rs_nor_latch" />
			<Logic name="output" x="64" y="4" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />
		
			<Wire from="a" fromPort="0" to="rs_nor_latch" toPort="0" />
			<Wire from="b" fromPort="0" to="rs_nor_latch" toPort="1" />
			<Wire from="rs_nor_latch" fromPort="0" to="output" toPort="0" />
		
			<RedstoneSignal step="0" direction="east" strength="15" />
			<RedstoneSignal step="0" direction="west" strength="15" />
		</MicrochipScene>
	</Column>
</Row>