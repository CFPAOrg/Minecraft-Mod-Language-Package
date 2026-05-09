---
navigation:
  title: "Comparator"
  icon: "comparator"
  parent: little_big_redstone:logic.md
  position: 23
categories:
  - logic
item_ids:
  - little_big_redstone:comparator
---

# Comparator

<FloatingColumn width="100" align="right">
	### Analog
	Comparators yield an output signal value equal to the value being compared against. This may either be the constant
	value set in the settings, or when the comparator is set to pass, the first input value.
</FloatingColumn>

<RecipeFor id="comparator" />

The comparator is a logic component that allows for comparing anywhere between 1 and 10 inputs' (B₁ - B₁₀) signal
strength against some other signal strength (A). The mode option for the comparator determines if all or just one of
the inputs must match the comparison for the output to be ON. When the output is ON, the output signal strength will
equal the signal strength of input A.

The comparator can be configured to have an input port for input A by setting the signal strength to pass.
Alternatively, it can be configured to have a constant signal used for comparison, in this case it will not have an
input port for input A.

Similar to other logic components that do comparisons against signal strengths, the comparator can be configured to
require the values be greater than or equal to, equal to, or less than or equal to input A.

<Row>
	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="a" x="0" y="4" type="io" data="{config:{direction:'east'}}" hide={true} />
			<Logic name="b" x="16" y="12" type="io" data="{config:{direction:'west'}}" hide={true} />
			<Logic name="comparator" x="48" y="8" type="comparator" />
			<Logic name="output" x="80" y="8" type="io" data="{config:{input:false,signal_strength:15}}" hide={true} />

			<Wire from="a" fromPort="0" to="comparator" toPort="0" />
			<Wire from="b" fromPort="0" to="comparator" toPort="1" />
			<Wire from="comparator" fromPort="0" to="output" toPort="0" />

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
			<Logic name="a" x="0" y="0" type="io" data="{config:{direction:'east'}}" hide={true} />
			<Logic name="comparator" x="32" y="0" type="comparator" data="{config:{signal_strength:15}}" />
			<Logic name="output" x="64" y="0" type="io" data="{config:{input:false,signal_strength:15}}" hide={true} />

			<Wire from="a" fromPort="0" to="comparator" toPort="0" />
			<Wire from="comparator" fromPort="0" to="output" toPort="0" />

			<RedstoneSignal step="0" direction="east" strength="0" />

			<RedstoneSignal step="1" direction="east" strength="10" />

			<RedstoneSignal step="2" direction="east" strength="15" />
		</MicrochipScene>
	</Column>

	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="a" x="0" y="-5" type="io" data="{config:{direction:'north'}}" hide={true} />
			<Logic name="b" x="0" y="0" type="io" data="{config:{direction:'south'}}" hide={true} />
			<Logic name="c" x="0" y="5" type="io" data="{config:{direction:'east'}}" hide={true} />
			<Logic name="comparator" x="32" y="0" type="comparator" data="{config:{signal_strength:15,inputs:3}}" />
			<Logic name="output" x="64" y="0" type="io" data="{config:{input:false,signal_strength:15}}" hide={true} />

			<Wire from="a" fromPort="0" to="comparator" toPort="0" />
			<Wire from="b" fromPort="0" to="comparator" toPort="1" />
			<Wire from="c" fromPort="0" to="comparator" toPort="2" />
			<Wire from="comparator" fromPort="0" to="output" toPort="0" />

			<RedstoneSignal step="0" direction="north" strength="10" />
			<RedstoneSignal step="0" direction="south" strength="0" />
			<RedstoneSignal step="0" direction="east" strength="0" />

			<RedstoneSignal step="1" direction="north" strength="10" />
			<RedstoneSignal step="1" direction="south" strength="0" />
			<RedstoneSignal step="1" direction="east" strength="10" />

			<RedstoneSignal step="2" direction="north" strength="10" />
			<RedstoneSignal step="2" direction="south" strength="15" />
			<RedstoneSignal step="2" direction="east" strength="15" />

			<RedstoneSignal step="3" direction="north" strength="15" />
			<RedstoneSignal step="3" direction="south" strength="15" />
			<RedstoneSignal step="3" direction="east" strength="15" />
		</MicrochipScene>
	</Column>
</Row>