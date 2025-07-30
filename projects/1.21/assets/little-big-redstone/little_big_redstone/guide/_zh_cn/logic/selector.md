---
navigation:
  title: "选择器"
  icon: "selector"
  parent: little_big_redstone:logic.md
  position: 20
categories:
  - logic
item_ids:
  - little_big_redstone:selector
---

# 选择器

<RecipeFor id="selector" />

选择器的输出端口数目最少为2，最多10，且同一时刻只会有一个输出为ON。选择器共有两种模式：计数器和置位器（更多内容见此页面后续）。

### 计数器模式

计数器模式下的选择器有两个输入。上方的输入为ON时，ON信号的输出位置会向上转移一个端口，如是最上方的端口则转移至最下方。下方的输入轮换方向相反。换言之，它会让ON信号向下转移一个端口，最下方转移至最上方。

<Row>
	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="up" x="0" y="0" type="io" data="{config:{direction:'up'}}" hide={true} />
			<Logic name="up_throttle" x="32" y="0" type="pulse_throttler" hide={true} />
			<Logic name="down" x="0" y="16" type="io" data="{config:{direction:'down'}}" hide={true} />
			<Logic name="down_throttle" x="32" y="16" type="pulse_throttler" hide={true} />
			<Logic name="selector" x="64" y="0" type="selector" data="{config:{outputs:5}}" />
			<Logic name="output" x="96" y="0" type="or_gate" data="{config:{input_count:5}}" hide={true} />

			<Wire from="up" fromPort="0" to="up_throttle" toPort="0" />
			<Wire from="up_throttle" fromPort="0" to="selector" toPort="0" />
			<Wire from="down" fromPort="0" to="down_throttle" toPort="0" />
			<Wire from="down_throttle" fromPort="0" to="selector" toPort="1" />
			<Wire from="selector" fromPort="0" to="output" toPort="0" />
			<Wire from="selector" fromPort="1" to="output" toPort="1" />
			<Wire from="selector" fromPort="2" to="output" toPort="2" />
			<Wire from="selector" fromPort="3" to="output" toPort="3" />
			<Wire from="selector" fromPort="4" to="output" toPort="4" />
		
			<RedstoneSignal step="0" direction="up" strength="15" />
			<RedstoneSignal step="1" direction="up" strength="0" />
		</MicrochipScene>
	</Column>

	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="up" x="0" y="0" type="io" data="{config:{direction:'up'}}" hide={true} />
			<Logic name="up_throttle" x="32" y="0" type="pulse_throttler" hide={true} />
			<Logic name="down" x="0" y="16" type="io" data="{config:{direction:'down'}}" hide={true} />
			<Logic name="down_throttle" x="32" y="16" type="pulse_throttler" hide={true} />
			<Logic name="selector" x="64" y="0" type="selector" data="{config:{outputs:5}}" />
			<Logic name="output" x="96" y="0" type="or_gate" data="{config:{input_count:5}}" hide={true} />
		
			<Wire from="up" fromPort="0" to="up_throttle" toPort="0" />
			<Wire from="up_throttle" fromPort="0" to="selector" toPort="0" />
			<Wire from="down" fromPort="0" to="down_throttle" toPort="0" />
			<Wire from="down_throttle" fromPort="0" to="selector" toPort="1" />
			<Wire from="selector" fromPort="0" to="output" toPort="0" />
			<Wire from="selector" fromPort="1" to="output" toPort="1" />
			<Wire from="selector" fromPort="2" to="output" toPort="2" />
			<Wire from="selector" fromPort="3" to="output" toPort="3" />
			<Wire from="selector" fromPort="4" to="output" toPort="4" />
		
			<RedstoneSignal step="0" direction="down" strength="15" />
			<RedstoneSignal step="1" direction="down" strength="0" />
		</MicrochipScene>
	</Column>
</Row>

### 置位器模式

在置位器模式下，选择器的输入端口和输出端口数量一致。各个输入在收到ON时会将ON信号转移至对应的输出端口。若同一时刻有多个输入为ON，则选择其中最下方的输出端口。

<Row>
	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="north" x="0" y="0" type="io" data="{config:{direction:'north'}}" hide={true} />
			<Logic name="south" x="0" y="6" type="io" data="{config:{direction:'south'}}" hide={true} />
			<Logic name="east" x="0" y="12" type="io" data="{config:{direction:'east'}}" hide={true} />
			<Logic name="west" x="0" y="18" type="io" data="{config:{direction:'west'}}" hide={true} />
			<Logic name="up" x="0" y="24" type="io" data="{config:{direction:'up'}}" hide={true} />
			<Logic name="selector" x="32" y="4" type="selector" data="{config:{outputs:5,mode:'setter'}}" />
			<Logic name="output" x="64" y="4" type="or_gate" data="{config:{input_count:5}}" hide={true} />

			<Wire from="north" fromPort="0" to="selector" toPort="0" />
			<Wire from="south" fromPort="0" to="selector" toPort="1" />
			<Wire from="east" fromPort="0" to="selector" toPort="2" />
			<Wire from="west" fromPort="0" to="selector" toPort="3" />
			<Wire from="up" fromPort="0" to="selector" toPort="4" />
			<Wire from="selector" fromPort="0" to="output" toPort="0" />
			<Wire from="selector" fromPort="1" to="output" toPort="1" />
			<Wire from="selector" fromPort="2" to="output" toPort="2" />
			<Wire from="selector" fromPort="3" to="output" toPort="3" />
			<Wire from="selector" fromPort="4" to="output" toPort="4" />
		
			<RedstoneSignal step="0" direction="north" strength="15" />
			<RedstoneSignal step="1" direction="south" strength="15" />
			<RedstoneSignal step="2" direction="east" strength="15" />
			<RedstoneSignal step="3" direction="west" strength="15" />
			<RedstoneSignal step="4" direction="up" strength="15" />
		</MicrochipScene>
	</Column>

	<Column>
		<MicrochipScene color="red" includeToolbar={true}>
			<Logic name="north" x="0" y="0" type="io" data="{config:{direction:'north'}}" hide={true} />
			<Logic name="south" x="0" y="6" type="io" data="{config:{direction:'south'}}" hide={true} />
			<Logic name="east" x="0" y="12" type="io" data="{config:{direction:'east'}}" hide={true} />
			<Logic name="west" x="0" y="18" type="io" data="{config:{direction:'west'}}" hide={true} />
			<Logic name="up" x="0" y="24" type="io" data="{config:{direction:'up'}}" hide={true} />
			<Logic name="selector" x="32" y="4" type="selector" data="{config:{outputs:5,mode:'setter'}}" />
			<Logic name="output" x="64" y="4" type="or_gate" data="{config:{input_count:5}}" hide={true} />
		
			<Wire from="north" fromPort="0" to="selector" toPort="0" />
			<Wire from="south" fromPort="0" to="selector" toPort="1" />
			<Wire from="east" fromPort="0" to="selector" toPort="2" />
			<Wire from="west" fromPort="0" to="selector" toPort="3" />
			<Wire from="up" fromPort="0" to="selector" toPort="4" />
			<Wire from="selector" fromPort="0" to="output" toPort="0" />
			<Wire from="selector" fromPort="1" to="output" toPort="1" />
			<Wire from="selector" fromPort="2" to="output" toPort="2" />
			<Wire from="selector" fromPort="3" to="output" toPort="3" />
			<Wire from="selector" fromPort="4" to="output" toPort="4" />
		
			<RedstoneSignal step="0" direction="north" strength="15" />
			<RedstoneSignal step="0" direction="south" strength="15" />
			<RedstoneSignal step="1" direction="south" strength="15" />
			<RedstoneSignal step="1" direction="east" strength="15" />
			<RedstoneSignal step="2" direction="east" strength="15" />
			<RedstoneSignal step="2" direction="west" strength="15" />
			<RedstoneSignal step="3" direction="west" strength="15" />
			<RedstoneSignal step="3" direction="up" strength="15" />
			<RedstoneSignal step="4" direction="up" strength="15" />
			<RedstoneSignal step="4" direction="north" strength="15" />
		</MicrochipScene>
	</Column>
</Row>