---
navigation:
  title: "信号源"
  icon: "battery"
  parent: little_big_redstone:logic.md
  position: 13
categories:
  - logic
item_ids:
  - little_big_redstone:battery
---

# 信号源

<FloatingColumn width="100" align="right">
	### 模拟
	计数器会取各输入的计算结果作为输出。信号值不会超出0到15的范围。
</FloatingColumn>

<Row>
	<Column>
		<RecipeFor id="battery" />
	</Column>

	<Column>
		<GameScene zoom="1.48" padding="3" interactive={true}>
			<ImportStructure src="../assets/structures/battery.snbt" />
			<IsometricCamera yaw="150" pitch="30" />
		</GameScene>
	</Column>
</Row>

信号源是非常简单的逻辑元件。其输出信号的强度始终会等于所设的强度值。

<MicrochipScene color="red" includeToolbar={true}>
	<Logic name="battery" x="0" y="0" type="battery" />
	<Logic name="output" x="32" y="0" type="io" data="{config:{input:false,signal_strength:15}}" hide={true} />

	<Wire from="battery" fromPort="0" to="output" toPort="0" />
</MicrochipScene>