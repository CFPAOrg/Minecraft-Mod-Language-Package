---
navigation:
  title: "I/O端口"
  icon: "io"
  parent: little_big_redstone:logic.md
  position: 10
categories:
  - logic
item_ids:
  - little_big_redstone:io
---

# I/O端口

<RecipeFor id="io" />

I/O端口是对电路传入和读取红石信号的途径。将I/O端口放入电路后，微芯片的对应面即会变为红石面，可借此输入输出红石信号。

<br />

每个I/O端口都有一个对应方向：<Color color="#4CFF00">北</Color>、<Color color="#0094FF">南</Color>、<Color color="#FF0000">东</Color>、<Color color="#FF6A00">西</Color>、<Color color="#FFFFFF">上</Color>、<Color color="#FFD800">下</Color>。潜行看向微芯片可查看侧面对应方向的颜色。

**注意：**单个方向可以是输入，也可以是输出，但不能兼做输入和输出。如果电路中I/O端口的排布使得某一面同时是输入和输出，那么与之相关的端口均不会运作，且会显示一则警告。

<br />

I/O端口的信号强度也可进行配置。端口处于输入模式时，如要让其输出ON，输入红石信号的强度就应大于等于设置值。处于输出模式时，向端口提供ON信号，则输出红石信号的强度即是所设值。

<Row>
	<Column>
		<MicrochipScene color="red" marginWidth="16" includeToolbar={true}>
			<Logic name="input" x="0" y="0" type="io" />
			<Logic name="output" x="32" y="0" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" hide={true} />

			<Wire from="input" fromPort="0" to="output" toPort="0" />
		</MicrochipScene>
	</Column>
	
	<Column>
		<MicrochipScene color="red" marginWidth="16" includeToolbar={true}>
			<Logic name="input" x="0" y="0" type="io" hide={true} />
			<Logic name="output" x="32" y="0" type="io" data="{config:{input:false,direction:'south',signal_strength:15}}" />
		
			<Wire from="input" fromPort="0" to="output" toPort="0" />
		</MicrochipScene>
	</Column>
</Row>