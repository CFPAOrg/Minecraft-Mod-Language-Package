---
navigation:
  title: "随机发生器"
  icon: "randomizer"
  parent: little_big_redstone:logic.md
  position: 21
categories:
  - logic
item_ids:
  - little_big_redstone:randomizer
---

# 随机发生器

<RecipeFor id="randomizer" />

随机发生器的输出端口数目最少为1，最多为10，且同一时刻只会有一个端口输出ON。输入为ON时，每刻都有一定概率任选一个输出端口输出ON信号。该概率可配置，默认情况下此概率为100%，可修改成任意值。例如将该概率设为50%，则在输入为ON时，有一半的时间内会任选一个端口输出ON。各输出的选中概率相等。

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

上方示例中输入信号的持续时间为1刻。如果不对此加以限制，那么每刻的输出都可能会不同。下方的示例就是这样。

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