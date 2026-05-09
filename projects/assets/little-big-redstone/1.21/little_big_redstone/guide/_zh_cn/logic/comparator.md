---
navigation:
  title: "比较器"
  icon: "comparator"
  parent: little_big_redstone:logic.md
  position: 23
categories:
  - logic
item_ids:
  - little_big_redstone:comparator
---

# 比较器

<FloatingColumn width="100" align="right">
	### 模拟
	比较器所输出信号的值与比较基准信号的相等。基准可为设定中指定的值，或在比较器设为直通时取首个输入信号的值。
</FloatingColumn>

<RecipeFor id="comparator" />

比较器是能将1到10个输入信号（B₁ - B₁₀）的信号与某个其他信号（A）进行比较的逻辑元件。模式选项决定了输出ON需要全部输入均通过比较，还是任意一个通过比较即可。输出为ON时，其强度等于比较基准信号A的强度。

比较器配置为直通时，会开放输入A的端口。也可为其指定常量比较基准，此时不会开放输入A的端口。

与其他会比较信号强度的逻辑元件类似，比较器也可配置为输入值大于等于、等于或小于等于输入A时视为通过比较。

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