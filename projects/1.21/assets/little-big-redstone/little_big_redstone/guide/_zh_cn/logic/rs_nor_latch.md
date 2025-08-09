---
navigation:
  title: "RS或非锁存器"
  icon: "rs_nor_latch"
  parent: little_big_redstone:logic.md
  position: 23
categories:
  - logic
item_ids:
  - little_big_redstone:rs_nor_latch
---

# RS或非锁存器

<FloatingColumn width="100" align="right">
	### 真值表
	<TruthTable inputs="2" outputs="1">
		<TruthState input="0,0" output="0" />
		<TruthState input="0,1" output="0" />
		<TruthState input="1,0" output="1" />
		<TruthState input="1,1" output="0" />
	</TruthTable>
	*真值表的详细介绍见[此](introduction.md)页面。*
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

RS或非锁存器，即复位-置位或非锁存器，是拥有两个输入端口和一个输出端口的逻辑元件。

输入A也称“置位”/“Set”输入。它为ON时输出会变为ON，该输入变为OFF后输出会保持为ON。只要输出仍为ON，无论向此端口发送多少个ON信号都不会改变输出。

输入B也称“复位”/“Reset”输入。它为ON时输出会变为OFF，该输入变为OFF后输出会保持为OFF——假定输入A也为OFF。只要输出仍为OFF，无论向此端口发送多少个ON信号都不会改变输出。

A和B均为ON时，输出为OFF。

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