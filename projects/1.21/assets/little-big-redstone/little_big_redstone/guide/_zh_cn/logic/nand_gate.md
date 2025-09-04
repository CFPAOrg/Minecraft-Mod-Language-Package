---
navigation:
  title: "与非门"
  icon: "nand_gate"
  parent: little_big_redstone:logic.md
  position: 13
categories:
  - logic
item_ids:
  - little_big_redstone:nand_gate
---

# 与非门

<FloatingColumn width="100" align="right">
	### 真值表
	<TruthTable inputs="2">
		<TruthState input="0,0" output="1" />
		<TruthState input="0,1" output="1" />
		<TruthState input="1,0" output="1" />
		<TruthState input="1,1" output="0" />
	</TruthTable>
	*真值表的详细介绍见[此](introduction.md)页面。*
</FloatingColumn>

<Row>
	<Column>
		<RecipeFor id="nand_gate" />
	</Column>

	<Column>
		<GameScene zoom="1.48" padding="3" interactive={true}>
			<ImportStructure src="../assets/structures/nand_gate.snbt" />
			<IsometricCamera yaw="150" pitch="30" />
		</GameScene>
	</Column>
</Row>

与非门是一种逻辑元件，只在所有输入均为ON时输出才为OFF。它的输出和[与门](and_gate.md)成相反关系。

与非门的输入端口数目最少为2，最多为10。

<Row>
	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="a" x="0" y="12" type="io" data="{config:{direction:'east'}}" hide={true} />
			<Logic name="b" x="0" y="20" type="io" data="{config:{direction:'west'}}" hide={true} />
			<Logic name="and" x="32" y="16" type="nand_gate" />
			<Logic name="output" x="64" y="16" type="io" data="{config:{input:false,signal_strength:15}}" hide={true} />

			<Wire from="a" fromPort="0" to="and" toPort="0" />
			<Wire from="b" fromPort="0" to="and" toPort="1" />
			<Wire from="and" fromPort="0" to="output" toPort="0" />

			<RedstoneSignal step="0" direction="east" strength="0" />
			<RedstoneSignal step="0" direction="west" strength="0" />

			<RedstoneSignal step="1" direction="east" strength="0" />
			<RedstoneSignal step="1" direction="west" strength="15" />

			<RedstoneSignal step="2" direction="east" strength="15" />
			<RedstoneSignal step="2" direction="west" strength="0" />

			<RedstoneSignal step="3" direction="east" strength="15" />
			<RedstoneSignal step="3" direction="west" strength="15" />
		</MicrochipScene>
	</Column>

	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="a" x="0" y="12" type="io" data="{config:{direction:'north'}}" hide={true} />
			<Logic name="b" x="0" y="20" type="io" data="{config:{direction:'south'}}" hide={true} />
			<Logic name="c" x="0" y="28" type="io" data="{config:{direction:'east'}}" hide={true} />
			<Logic name="d" x="0" y="36" type="io" data="{config:{direction:'west'}}" hide={true} />
			<Logic name="and" x="32" y="16" type="nand_gate" data="{config:{input_count:4}}" />
			<Logic name="output" x="64" y="24" type="io" data="{config:{direction:'up',input:false,signal_strength:15}}" hide={true} />

			<Wire from="a" fromPort="0" to="and" toPort="0" />
			<Wire from="b" fromPort="0" to="and" toPort="1" />
			<Wire from="c" fromPort="0" to="and" toPort="2" />
			<Wire from="d" fromPort="0" to="and" toPort="3" />
			<Wire from="and" fromPort="0" to="output" toPort="0" />

			<RedstoneSignal step="0" direction="north" strength="0" />
			<RedstoneSignal step="0" direction="south" strength="0" />
			<RedstoneSignal step="0" direction="east" strength="0" />
			<RedstoneSignal step="0" direction="west" strength="0" />

			<RedstoneSignal step="1" direction="north" strength="15" />
			<RedstoneSignal step="1" direction="south" strength="0" />
			<RedstoneSignal step="1" direction="east" strength="0" />
			<RedstoneSignal step="1" direction="west" strength="0" />

			<RedstoneSignal step="2" direction="north" strength="0" />
			<RedstoneSignal step="2" direction="south" strength="15" />
			<RedstoneSignal step="2" direction="east" strength="0" />
			<RedstoneSignal step="2" direction="west" strength="0" />

			<RedstoneSignal step="3" direction="north" strength="0" />
			<RedstoneSignal step="3" direction="south" strength="0" />
			<RedstoneSignal step="3" direction="east" strength="15" />
			<RedstoneSignal step="3" direction="west" strength="0" />

			<RedstoneSignal step="4" direction="north" strength="0" />
			<RedstoneSignal step="4" direction="south" strength="0" />
			<RedstoneSignal step="4" direction="east" strength="0" />
			<RedstoneSignal step="4" direction="west" strength="15" />

			<RedstoneSignal step="5" direction="north" strength="0" />
			<RedstoneSignal step="5" direction="south" strength="15" />
			<RedstoneSignal step="5" direction="east" strength="0" />
			<RedstoneSignal step="5" direction="west" strength="15" />

			<RedstoneSignal step="6" direction="north" strength="15" />
			<RedstoneSignal step="6" direction="south" strength="0" />
			<RedstoneSignal step="6" direction="east" strength="15" />
			<RedstoneSignal step="6" direction="west" strength="0" />

			<RedstoneSignal step="7" direction="north" strength="15" />
			<RedstoneSignal step="7" direction="south" strength="15" />
			<RedstoneSignal step="7" direction="east" strength="15" />
			<RedstoneSignal step="7" direction="west" strength="15" />
		</MicrochipScene>
	</Column>
</Row>