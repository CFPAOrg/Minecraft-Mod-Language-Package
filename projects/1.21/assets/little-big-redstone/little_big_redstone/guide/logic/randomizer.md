---
navigation:
  title: "Randomizer"
  icon: "randomizer"
  parent: little_big_redstone:logic.md
  position: 21
categories:
  - logic
item_ids:
  - little_big_redstone:randomizer
---

# Randomizer

<RecipeFor id="randomizer" />

The randomizer can have anywhere between 1 and 10 outputs, however only one output can be ON at a time. When the input
is ON, every tick, a random output will be ON a configurable percentage of the time. By default, the chance is 100%,
but you can change it to any value. For example, with the chance set to 50%, half of the ticks when the input is ON,
a random output will be ON. Each output has an equal chance of being selected.

<Row>
	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="input" x="0" y="8" type="io" hide={true} />
			<Logic name="throttler" x="32" y="8" type="pulse_throttler" hide={true} />
			<Logic name="randomizer" x="64" y="0" type="randomizer" data="{config:{outputs:5}}" />
			<Logic name="output" x="96" y="0" type="or_gate" data="{config:{input_count:5}}" hide={true} />
		
			<Wire from="input" fromPort="0" to="throttler" toPort="0" />
			<Wire from="throttler" fromPort="0" to="randomizer" toPort="0" />
			<Wire from="randomizer" fromPort="0" to="output" toPort="0" />
			<Wire from="randomizer" fromPort="1" to="output" toPort="1" />
			<Wire from="randomizer" fromPort="2" to="output" toPort="2" />
			<Wire from="randomizer" fromPort="3" to="output" toPort="3" />
			<Wire from="randomizer" fromPort="4" to="output" toPort="4" />
		
			<RedstoneSignal step="0" direction="north" strength="15" />
			<RedstoneSignal step="1" direction="north" strength="0" />
		</MicrochipScene>
	</Column>

	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="input" x="0" y="8" type="io" hide={true} />
			<Logic name="throttler" x="32" y="8" type="pulse_throttler" hide={true} />
			<Logic name="randomizer" x="64" y="0" type="randomizer" data="{config:{outputs:5,chance:0.5}}" />
			<Logic name="output" x="96" y="0" type="or_gate" data="{config:{input_count:5}}" hide={true} />
		
			<Wire from="input" fromPort="0" to="throttler" toPort="0" />
			<Wire from="throttler" fromPort="0" to="randomizer" toPort="0" />
			<Wire from="randomizer" fromPort="0" to="output" toPort="0" />
			<Wire from="randomizer" fromPort="1" to="output" toPort="1" />
			<Wire from="randomizer" fromPort="2" to="output" toPort="2" />
			<Wire from="randomizer" fromPort="3" to="output" toPort="3" />
			<Wire from="randomizer" fromPort="4" to="output" toPort="4" />
		
			<RedstoneSignal step="0" direction="north" strength="15" />
			<RedstoneSignal step="1" direction="north" strength="0" />
		</MicrochipScene>
	</Column>
</Row>

The above examples have their inputs shortened to a single tick. Note that if you do not do the same, the output will
be different every tick. Below is an example of what that would look like.

<Row>
	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="input" x="0" y="8" type="io" hide={true} />
			<Logic name="randomizer" x="32" y="0" type="randomizer" data="{config:{outputs:5}}" />
			<Logic name="output" x="64" y="0" type="or_gate" data="{config:{input_count:5}}" hide={true} />

			<Wire from="input" fromPort="0" to="randomizer" toPort="0" />
			<Wire from="randomizer" fromPort="0" to="output" toPort="0" />
			<Wire from="randomizer" fromPort="1" to="output" toPort="1" />
			<Wire from="randomizer" fromPort="2" to="output" toPort="2" />
			<Wire from="randomizer" fromPort="3" to="output" toPort="3" />
			<Wire from="randomizer" fromPort="4" to="output" toPort="4" />
		
			<RedstoneSignal step="0" direction="north" strength="15" />
			<RedstoneSignal step="1" direction="north" strength="0" />
		</MicrochipScene>
	</Column>

	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="input" x="0" y="8" type="io" hide={true} />
			<Logic name="randomizer" x="32" y="0" type="randomizer" data="{config:{outputs:5,chance:0.5}}" />
			<Logic name="output" x="64" y="0" type="or_gate" data="{config:{input_count:5}}" hide={true} />
		
			<Wire from="input" fromPort="0" to="randomizer" toPort="0" />
			<Wire from="randomizer" fromPort="0" to="output" toPort="0" />
			<Wire from="randomizer" fromPort="1" to="output" toPort="1" />
			<Wire from="randomizer" fromPort="2" to="output" toPort="2" />
			<Wire from="randomizer" fromPort="3" to="output" toPort="3" />
			<Wire from="randomizer" fromPort="4" to="output" toPort="4" />
		
			<RedstoneSignal step="0" direction="north" strength="15" />
			<RedstoneSignal step="1" direction="north" strength="0" />
		</MicrochipScene>
	</Column>
</Row>