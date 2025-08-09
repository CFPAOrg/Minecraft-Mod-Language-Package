---
navigation:
  title: "非门"
  icon: "not_gate"
  parent: little_big_redstone:logic.md
  position: 11
categories:
  - logic
item_ids:
  - little_big_redstone:not_gate
---

# 非门

<FloatingColumn width="100" align="right">
	### 真值表
	<TruthTable>
		<TruthState input="0" output="1" />
		<TruthState input="1" output="0" />
	</TruthTable>
	*真值表的详细介绍见[此](introduction.md)页面。*
</FloatingColumn>

<Row>
	<Column>
		<RecipeFor id="not_gate" />
	</Column>

	<Column>
		<GameScene zoom="1.48" padding="3" interactive={true}>
			<ImportStructure src="../assets/structures/not_gate.snbt" />
			<IsometricCamera yaw="150" pitch="30" />
		</GameScene>
	</Column>
</Row>

非门是最简单的逻辑门。它只接受一个输入，只有一个输出，且只会反转信号。

<MicrochipScene color="red" includeToolbar={true}>
	<Logic name="1" x="0" y="0" type="io" hide={true} />
	<Logic name="2" x="32" y="0" type="not_gate" />
	<Logic name="3" x="64" y="0" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />

	<Wire from="1" fromPort="0" to="2" toPort="0" />
	<Wire from="2" fromPort="0" to="3" toPort="0" />

	<RedstoneSignal step="0" direction="north" strength="15" />
	<RedstoneSignal step="1" direction="north" strength="0" />
</MicrochipScene>