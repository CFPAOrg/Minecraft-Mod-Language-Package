---
navigation:
  title: "读取器"
  icon: "reader"
  parent: little_big_redstone:logic.md
  position: 11
categories:
  - logic
item_ids:
  - little_big_redstone:reader
---

# 读取器

<FloatingColumn width="100" align="right">
	### 模拟
	在比较器模式下，读取器会取对应方块的比较器输出值作为输出。其他情况下，读取器只会输出0（OFF）或1（ON）。
</FloatingColumn>

<RecipeFor id="reader" />

读取器是一种逻辑元件。它不会接收来自电路内部的信号，而是会根据相邻容器方块的填充程度输出信号，读取的方向可配置。

读取器接受的容器包括物品容器（箱子、木桶、熔炉等）、流体容器（模组提供的流体容器）、能量容器（电池等模组提供的FE容器）。默认情况下，读取器会读取物品的填充程度，可在配置菜单中修改读取对象。

读取器可配置为检测容器的填充程度是否达到某个阈值，符合条件才输出ON。该阈值可为常值或百分比。在值的末尾补上%，即视为使用百分比。

下方示例中，读取器会在箱子至少填充到50%时点亮红石灯。

<PaddedBox left="5" top="5">
	<Row>
		<Column>
			<PaddedBox top="4">
				<GameScene zoom="2" padding="0">
					<Block id="minecraft:chest" />
					<BlockAnnotation>
						箱子的填充程度不低于50%
					</BlockAnnotation>
					<Block id="red_microchip" x="-1" />
					<Block id="minecraft:redstone_lamp" x="-2" p:lit="true" />
					<IsometricCamera yaw="200" pitch="30" />
				</GameScene>
			</PaddedBox>
		</Column>
	
		<Column>
			<MicrochipScene color="red" padding="0" marginWidth="16">
				<Logic name="reader" x="0" y="0" type="reader" data="{config:{direction:'west'}}" />
				<Logic name="output" x="32" y="0" type="io" data="{config:{direction:'east',input:false,signal_strength:15}}" />
	
				<Wire from="reader" fromPort="0" to="output" toPort="0" powered="1" />
			</MicrochipScene>
		</Column>
	</Row>
	
	<Row>
		<Column>
			<PaddedBox top="4">
				<GameScene zoom="2" padding="0">
					<Block id="minecraft:chest" />
					<BlockAnnotation>
						箱子的填充程度低于50%
					</BlockAnnotation>
					<Block id="red_microchip" x="-1" />
					<Block id="minecraft:redstone_lamp" x="-2" p:lit="false" />
					<IsometricCamera yaw="200" pitch="30" />
				</GameScene>
			</PaddedBox>
		</Column>
	
		<Column>
			<MicrochipScene color="red" padding="0" marginWidth="16">
				<Logic name="reader" x="0" y="0" type="reader" data="{config:{direction:'west'}}" />
				<Logic name="output" x="32" y="0" type="io" data="{config:{direction:'east',input:false,signal_strength:15}}" />
	
				<Wire from="reader" fromPort="0" to="output" toPort="0" />
			</MicrochipScene>
		</Column>
	</Row>
</PaddedBox>