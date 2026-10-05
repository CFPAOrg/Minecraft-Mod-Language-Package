---
navigation:
  title: "Battery"
  icon: "battery"
  parent: little_big_redstone:logic.md
  position: 13
categories:
  - logic
item_ids:
  - little_big_redstone:battery
---

# Battery

<FloatingColumn width="100" align="right">
	### Analog
	The output signal of the battery will equal the configured signal strength. The signal will not exceed the range of
	0 to 15.
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

The battery is a very simple logic component. The output signal strength will always be equal to the configured signal
strength value.

<MicrochipScene color="red" includeToolbar={true}>
	<Logic name="battery" x="0" y="0" type="battery" />
	<Logic name="output" x="32" y="0" type="io" data="{config:{input:false,signal_strength:15}}" hide={true} />

	<Wire from="battery" fromPort="0" to="output" toPort="0" />
</MicrochipScene>