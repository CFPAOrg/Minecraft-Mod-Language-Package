---
navigation:
  title: "时序器"
  icon: "sequencer"
  parent: little_big_redstone:logic.md
  position: 18
categories:
  - logic
item_ids:
  - little_big_redstone:sequencer
---

# 时序器

<Row>
	<Column>
		<RecipeFor id="sequencer" />
	</Column>

	<Column>
		<GameScene zoom="1.48" padding="3" interactive={true}>
			<ImportStructure src="../assets/structures/sequencer.snbt" />
			<BoxAnnotation min="2 1 0" max="3 1.5 1" color="#FFFFFF">
				时序器比中继器要灵活许多，但两者的概念是相似的。
			</BoxAnnotation>
			<IsometricCamera yaw="150" pitch="30" />
		</GameScene>
	</Column>
</Row>

> **注意：**&zwnj;Minecraft中的20刻对应现实中的1秒。

时序器是一种逻辑元件，用于精确延时信号。

时序器共有三种模式：弱、强、计数器（更多内容见此页面后续）。时序器有一个内部计数器，其取值范围为0到所设延时（默认为20）。选择的模式不同，该计数器的增减方式也不同。时序器内部计数器达到最大值时，输出为ON；否则输出为OFF。

可将该计数器配置为达到最大值时即复位为0。如此，输出的ON信号便只会恰好保持1刻。

<MicrochipScene color="red" includeToolbar={true}>
	<Logic name="input" x="0" y="0" type="io" hide={true} />
	<Logic name="sequencer" x="32" y="0" type="sequencer" data="{config:{delay:30,auto_reset:true}}" />
	<Logic name="output" x="80" y="0" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />

	<Wire from="input" fromPort="0" to="sequencer" toPort="0" />
	<Wire from="sequencer" fromPort="0" to="output" toPort="0" />

	<RedstoneSignal direction="north" strength="15" />
</MicrochipScene>

此外，还可将时序器配置为拥有两个输入端口。第二个输入端口为ON时，内部计数器就将被复位为0。

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

### 弱模式

向计数器的第一个输入端口传递ON信号后，无论该信号持续多长时间，内部计数器都会持续递增，直至达到所配置的延时。如只需将某信号延后一段时间，可选择此模式。

下方示例中，时序器的延时为100刻（5秒），且会在达到最大值时自动复位。输入信号的持续时间较短，但无论有无ON信号输入，时序器都会不断递增。

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

### 强模式

只要时序器的第一个输入接收到ON信号，时序器即会不断递增。但如果撤走输入信号，时序器即会递减。

下方示例中，时序器的延时为100刻（5秒）。

此示例中ON信号的持续时间足够长，可让时序器的输出变为ON；这之后，输入信号会在OFF保持同样长的时间，以让时序器恢复到初始状态。

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

此示例的ON信号只够时序器递增至半程。这之后，输入信号会变为OFF，时序器会在此时间段内回到初始状态。正因此，此示例中的时序器永远无法达到最大值，输出一直为OFF。

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

### 计数器模式

只要时序器的第一个输入接收到ON信号，时序器即会不断递增。此模式下时序器的计数器值只会因自动复位选项或复位端口而下降。

下方示例中，时序器的延时为100刻（5秒），且会在达到最大值时自动复位。输入不断在ON和OFF间切换，但时序器不会在输入为OFF时递减。

<MicrochipScene color="red" includeToolbar={true}>
	<Logic name="input" x="0" y="0" type="io" hide={true} />
	<Logic name="sequencer" x="32" y="0" type="sequencer" data="{config:{delay:100,mode:'counter',auto_reset:true}}" />
	<Logic name="output" x="80" y="0" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />

	<Wire from="input" fromPort="0" to="sequencer" toPort="0" />
	<Wire from="sequencer" fromPort="0" to="output" toPort="0" />

	<RedstoneSignal step="0" direction="north" strength="15" />
	<RedstoneSignal step="1" direction="north" strength="0" />
</MicrochipScene>

下方示例中，时序器的延时为5刻，且会在达到最大值时自动复位。输入信号经[脉冲节流器](pulse_throttler.md)缩短，以防止信号的持续时间超出1刻。如此，时序器便只会在接收到5个相互隔断的ON信号时输出ON。

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