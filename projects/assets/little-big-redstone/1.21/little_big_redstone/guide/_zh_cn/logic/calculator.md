---
navigation:
  title: "计算器"
  icon: "calculator"
  parent: little_big_redstone:logic.md
  position: 24
categories:
  - logic
item_ids:
  - little_big_redstone:calculator
---

# 计算器

<FloatingColumn width="100" align="right">
	### 模拟
	计数器会取各输入的计算结果作为输出。信号值不会超出0到15的范围。
</FloatingColumn>

<RecipeFor id="calculator" />

计算器的输入端口数目最少为2，最多为10。根据当前模式，计算器会对各输入执行加法或减法。计算结果即为输出值。

<Row>
	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="a" x="0" y="4" type="io" data="{config:{direction:'east'}}" hide={true} />
			<Logic name="b" x="16" y="12" type="io" data="{config:{direction:'west'}}" hide={true} />
			<Logic name="calculator" x="48" y="8" type="calculator" />
			<Logic name="output" x="80" y="8" type="io" data="{config:{input:false,signal_strength:15}}" hide={true} />

			<Wire from="a" fromPort="0" to="calculator" toPort="0" />
			<Wire from="b" fromPort="0" to="calculator" toPort="1" />
			<Wire from="calculator" fromPort="0" to="output" toPort="0" />

			<RedstoneSignal step="0" direction="east" strength="0" />
			<RedstoneSignal step="0" direction="west" strength="0" />

			<RedstoneSignal step="1" direction="east" strength="1" />
			<RedstoneSignal step="1" direction="west" strength="1" />

			<RedstoneSignal step="2" direction="east" strength="0" />
			<RedstoneSignal step="2" direction="west" strength="0" />

			<RedstoneSignal step="3" direction="east" strength="10" />
			<RedstoneSignal step="3" direction="west" strength="5" />
		</MicrochipScene>
	</Column>

	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="a" x="0" y="4" type="io" data="{config:{direction:'east'}}" hide={true} />
			<Logic name="b" x="16" y="12" type="io" data="{config:{direction:'west'}}" hide={true} />
			<Logic name="calculator" x="48" y="8" type="calculator" data="{config:{mode:'subtraction'}}" />
			<Logic name="output" x="80" y="8" type="io" data="{config:{input:false,signal_strength:15}}" hide={true} />

			<Wire from="a" fromPort="0" to="calculator" toPort="0" />
			<Wire from="b" fromPort="0" to="calculator" toPort="1" />
			<Wire from="calculator" fromPort="0" to="output" toPort="0" />

			<RedstoneSignal step="0" direction="east" strength="0" />
			<RedstoneSignal step="0" direction="west" strength="0" />

			<RedstoneSignal step="1" direction="east" strength="2" />
			<RedstoneSignal step="1" direction="west" strength="1" />

			<RedstoneSignal step="2" direction="east" strength="0" />
			<RedstoneSignal step="2" direction="west" strength="0" />

			<RedstoneSignal step="3" direction="east" strength="10" />
			<RedstoneSignal step="3" direction="west" strength="5" />
		</MicrochipScene>
	</Column>
</Row>

需要注意，计算器会根据顺序区分输入。也即，在减法模式下，若向靠前端口输入较小值，向靠后端口输入较大值，输出结果即会变为0。这是由于输出不可为负。例如，减法模式下，若计算器输入A为5，输入B为10，计算结果会是-5；但是输出结果为0，因此为OFF。