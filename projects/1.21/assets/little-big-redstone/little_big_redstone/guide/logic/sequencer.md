---
navigation:
  title: "Sequencer"
  icon: "sequencer"
  parent: little_big_redstone:logic.md
  position: 18
categories:
  - logic
item_ids:
  - little_big_redstone:sequencer
---

# Sequencer

<Row>
	<Column>
		<RecipeFor id="sequencer" />
	</Column>

	<Column>
		<GameScene zoom="1.48" padding="3" interactive={true}>
			<ImportStructure src="../assets/structures/sequencer.snbt" />
			<BoxAnnotation min="2 1 0" max="3 1.5 1" color="#FFFFFF">
				The sequencer is quite a bit more flexible than a repeater, but its similar in concept.
			</BoxAnnotation>
			<IsometricCamera yaw="150" pitch="30" />
		</GameScene>
	</Column>
</Row>

> **Note:** In Minecraft, there are 20 ticks per real-life second.

The sequencer is a logic component that allows you to delay signals with precise control.

There are three different modes that can be used: Weak, Strong, and Counter (see the sections below for further 
information). The sequencer has an internal counter that ranges from 0 to the delay set (default 20). Based on the mode
selected, the counter will increment or decrement differently. When the sequencer's counter is at its maximum, the
output is ON, otherwise it is OFF.

The sequencer can be configured to have its internal counter reset to 0 once it reaches its maximum value. At which it
will output an ON signal for exactly 1 tick.

<MicrochipScene color="red" includeToolbar={true}>
	<Logic name="input" x="0" y="0" type="io" hide={true} />
	<Logic name="sequencer" x="32" y="0" type="sequencer" data="{config:{delay:30,auto_reset:true}}" />
	<Logic name="output" x="80" y="0" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />

	<Wire from="input" fromPort="0" to="sequencer" toPort="0" />
	<Wire from="sequencer" fromPort="0" to="output" toPort="0" />

	<RedstoneSignal direction="north" strength="15" />
</MicrochipScene>

Additionally, the sequencer can be configured to have a second input port. Whenever this second input port is ON, the
internal counter of the sequencer will be reset to 0.

<MicrochipScene color="red" includeToolbar={true}>
	<Logic name="input1" x="0" y="12" type="io" data="{config:{direction:'east'}}" hide={true} />
	<Logic name="input2" x="0" y="20" type="io" data="{config:{direction:'west'}}" hide={true} />
	<Logic name="sequencer" x="32" y="16" type="sequencer" data="{config:{delay:50,reset_port:true}}" />
	<Logic name="output" x="80" y="16" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />

	<Wire from="input1" fromPort="0" to="sequencer" toPort="0" />
	<Wire from="input2" fromPort="0" to="sequencer" toPort="1" />
	<Wire from="sequencer" fromPort="0" to="output" toPort="0" />

	<RedstoneSignal step="0" direction="east" strength="15" />
	<RedstoneSignal step="1" direction="east" strength="0" />
	<RedstoneSignal step="2" direction="east" strength="0" />
	<RedstoneSignal step="3" direction="west" strength="15" />
	<RedstoneSignal step="4" direction="west" strength="0" />
</MicrochipScene>

<br />

### Weak Mode

After an ON signal is passed to the first input port of the sequencer, regardless of the duration of the signal, the
sequencer will increment until it reaches the configured delay. Use this mode when you want to simply delay a signal
a set amount of time.

Below is an example of a sequencer that is set to delay 100 ticks (5 seconds) and automatically reset once it
completes. The input signal is somewhat brief, but the sequencer continues to increment regardless of whether the
input remains on or not.

<MicrochipScene color="red" includeToolbar={true}>
	<Logic name="input" x="0" y="0" type="io" hide={true} />
	<Logic name="sequencer" x="32" y="0" type="sequencer" data="{config:{delay:100,auto_reset:true}}" />
	<Logic name="output" x="80" y="0" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />

	<Wire from="input" fromPort="0" to="sequencer" toPort="0" />
	<Wire from="sequencer" fromPort="0" to="output" toPort="0" />

	<RedstoneSignal step="0" direction="north" strength="15" />
	<RedstoneSignal step="1" direction="north" strength="0" />
	<RedstoneSignal step="2" direction="north" strength="0" />
	<RedstoneSignal step="3" direction="north" strength="0" />
</MicrochipScene>

<br />

### Strong Mode

So long as an ON signal is passed to the first input port of the sequencer, the sequencer will increment. However, if
the signal ceases, the sequencer will decrement.

Below are examples of a sequencer that is set to delay 100 ticks (5 seconds).

This one has an ON signal long enough that the sequencer reaches its ON state, and then turns off equally as long so
that it returns back to its original state.

<MicrochipScene color="red" includeToolbar={true}>
	<Logic name="input" x="0" y="0" type="io" hide={true} />
	<Logic name="sequencer" x="32" y="0" type="sequencer" data="{config:{delay:100,mode:'strong'}}" />
	<Logic name="output" x="80" y="0" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />

	<Wire from="input" fromPort="0" to="sequencer" toPort="0" />
	<Wire from="sequencer" fromPort="0" to="output" toPort="0" />

	<RedstoneSignal step="0" direction="north" strength="15" />
	<RedstoneSignal step="1" direction="north" strength="15" />
	<RedstoneSignal step="2" direction="north" strength="15" />
	<RedstoneSignal step="3" direction="north" strength="15" />
	<RedstoneSignal step="4" direction="north" strength="0" />
	<RedstoneSignal step="5" direction="north" strength="0" />
	<RedstoneSignal step="6" direction="north" strength="0" />
	<RedstoneSignal step="7" direction="north" strength="0" />
</MicrochipScene>

This one has an ON signal only long enough for the sequencer to reach about the half way point. Then the input signal
turns off, and it decrements all the way back to its original state. Because of this, it never reaches the completed
state and thus the output is always OFF.

<MicrochipScene color="red" includeToolbar={true}>
	<Logic name="input" x="0" y="0" type="io" hide={true} />
	<Logic name="sequencer" x="32" y="0" type="sequencer" data="{config:{delay:100,mode:'strong'}}" />
	<Logic name="output" x="80" y="0" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />

	<Wire from="input" fromPort="0" to="sequencer" toPort="0" />
	<Wire from="sequencer" fromPort="0" to="output" toPort="0" />

	<RedstoneSignal step="0" direction="north" strength="15" />
	<RedstoneSignal step="1" direction="north" strength="15" />
	<RedstoneSignal step="2" direction="north" strength="0" />
	<RedstoneSignal step="3" direction="north" strength="0" />
</MicrochipScene>

<br />

### Counter Mode

So long as an ON signal is passed to the first input port of the sequencer, the sequencer will increment. The only way
the sequencer will go down in this mode is if it is reset either by the auto reset option or by the reset port.

Below is an example of a sequencer that is set to delay 100 ticks (5 seconds) and automatically reset once it
completes. The input goes on and off frequently, but the sequencer does not decrement when the input is OFF.

<MicrochipScene color="red" includeToolbar={true}>
	<Logic name="input" x="0" y="0" type="io" hide={true} />
	<Logic name="sequencer" x="32" y="0" type="sequencer" data="{config:{delay:100,mode:'counter',auto_reset:true}}" />
	<Logic name="output" x="80" y="0" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />

	<Wire from="input" fromPort="0" to="sequencer" toPort="0" />
	<Wire from="sequencer" fromPort="0" to="output" toPort="0" />

	<RedstoneSignal step="0" direction="north" strength="15" />
	<RedstoneSignal step="1" direction="north" strength="0" />
</MicrochipScene>

Below is an example of a sequencer that is set to delay 5 ticks and automatically resets once it completes. The input
is throttled by a [Pulse Throttler](pulse_throttler.md) to prevent the input signal being longer than a single tick.
This way, the sequencer will only emit an output signal for a single tick once 5 separate ON inputs have been received.

<MicrochipScene color="red" includeToolbar={true}>
	<Logic name="input" x="0" y="0" type="io" hide={true} />
	<Logic name="pulse_throttler" x="32" y="0" type="pulse_throttler" />
	<Logic name="sequencer" x="64" y="0" type="sequencer" data="{config:{delay:5,mode:'counter',auto_reset:true}}" />
	<Logic name="output" x="112" y="0" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />

	<Wire from="input" fromPort="0" to="pulse_throttler" toPort="0" />
	<Wire from="pulse_throttler" fromPort="0" to="sequencer" toPort="0" />
	<Wire from="sequencer" fromPort="0" to="output" toPort="0" />

	<RedstoneSignal step="0" direction="north" strength="15" />
	<RedstoneSignal step="1" direction="north" strength="0" />
</MicrochipScene>