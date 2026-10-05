---
navigation:
  title: "Calculator"
  icon: "calculator"
  parent: little_big_redstone:logic.md
  position: 24
categories:
  - logic
item_ids:
  - little_big_redstone:calculator
---

# Calculator

<FloatingColumn width="100" align="right">
	### Analog
	The output signal of the calculator will equal the total calculated value of all the inputs. The signal will not
	exceed the range of 0 to 15.
</FloatingColumn>

<RecipeFor id="calculator" />

The calculator can take anywhere from 2 to 10 inputs. The input signals will either be added or subtracted depending on
the selected mode. The output signal then is the total calculated result of the inputs.

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

Do note that the order of inputs is taken into account. This means that while in subtract mode, if you have a lower
value first and then a higher value second, the output will be 0. This is because the signal cannot go negative. For
example, on a subtract mode calculator, if input A is 5, and then input B is 10, the calculated value would be -5.
However, the output signal would be 0, and thus off.