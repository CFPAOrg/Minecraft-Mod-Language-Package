---
navigation:
  title: "Tag"
  icon: "tag"
  parent: little_big_redstone:logic.md
  position: 12
categories:
  - logic
item_ids:
  - little_big_redstone:tag
---

# Tag

<RecipeFor id="tag" />

Tags allow you to wirelessly send signals between circuits. Tags have two modes, sensor and emitter. Sensors are how
you receive signals, and emitters are how you transmit signals.

<br />

Each tag can have a label set. For a sensor to be able to detect an emitter, they must both have the same label. Labels
are **case sensitive**. Labels are not required, and if left empty, will only match with other tags that also have an
empty label.

A sensor has a threshold setting, which determines how many emitters it must detect in order for it to yield an output
of ON. For example, if you have a sensor with a threshold of 2 and a label of "something", you must have 2 emitters
also with the label "something" that are ON for the sensor to have an ON output.

Note that sensors can detect emitters in the same circuit.

<br />

Sensors can also choose whether they are global or not. In other words, whether it detects emitters placed by someone
else on a multiplayer server. By default, sensors are not global - meaning they will only sense your emitters.

<br />

Below is an example of a tag emitter and sensor both having the same label. Because they share a label and the sensor
only has a threshold of 1, when the emitter is ON, the sensor is also ON.

<Row>
	<Column>
		<MicrochipScene color="red" marginWidth="16" includeToolbar={true}>
			<Logic name="input1" x="0" y="0" type="io" hide={true} />
			<Logic name="output1" x="32" y="0" type="tag" data="{config:{input:false,label:'something'}}" />

			<Logic name="tag2" x="64" y="0" type="tag" data="{config:{label:'something'}}" />
			<Logic name="input2" x="64" y="0" type="io" hide={true} />
			<Logic name="output2" x="96" y="0" type="io" data="{config:{input:false,signal_strength:15}}" hide={true} />

			<Wire from="input1" fromPort="0" to="output1" toPort="0" />
			<Wire from="input2" fromPort="0" to="output2" toPort="0" />

			<RedstoneSignal step="0" direction="north" strength="15" />
			<RedstoneSignal step="1" direction="north" strength="0" />
		</MicrochipScene>
	</Column>
</Row>

Notice that below the two tags have different labels. Because of this, the sensor does not detect the emitter.

<Row>
	<Column>
		<MicrochipScene color="red" marginWidth="16" includeToolbar={true}>
			<Logic name="input1" x="0" y="0" type="io" hide={true} />
			<Logic name="output1" x="32" y="0" type="tag" data="{config:{input:false,label:'something'}}" />

			<Logic name="input2" x="64" y="0" type="tag" data="{config:{label:'something_else'}}" />
			<Logic name="output2" x="96" y="0" type="io" data="{config:{input:false,signal_strength:15}}" hide={true} />

			<Wire from="input1" fromPort="0" to="output1" toPort="0" />
			<Wire from="input2" fromPort="0" to="output2" toPort="0" />

			<RedstoneSignal step="0" direction="north" strength="15" />
			<RedstoneSignal step="1" direction="north" strength="0" />
		</MicrochipScene>
	</Column>
</Row>