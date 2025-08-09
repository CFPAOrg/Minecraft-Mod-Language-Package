---
navigation:
  title: "Reader"
  icon: "reader"
  parent: little_big_redstone:logic.md
  position: 17
categories:
  - logic
item_ids:
  - little_big_redstone:reader
---

# Reader

<RecipeFor id="reader" />

The reader is a logic component that has no input inside of the circuit. Instead, the reader will output a signal based
on the fullness of the container directly adjacent to the microchip in the direction it is configured to.

Valid containers for the reader consist of item containers (chests, barrels, furnaces, etc.), fluid containers (modded
fluid tanks), and energy containers (modded FE containers such as batteries). By default it reads item fullness, but
you may change this in the logic config menu.

A reader can be configured to detect a minumum percentage of a container in order for it to have an output signal of
ON. By default the minimum fill percentage is 50%.

Below is an example of a reader being used to light up a redstone lamp when the chest is at least 50% full.

<PaddedBox left="5" top="5">
	<Row>
		<Column>
			<PaddedBox top="4">
				<GameScene zoom="2" padding="0">
					<Block id="minecraft:chest" />
					<BlockAnnotation>
						The chest is at least 50% full
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
	
				<Wire from="reader" fromPort="0" to="output" toPort="0" powered={true} />
			</MicrochipScene>
		</Column>
	</Row>
	
	<Row>
		<Column>
			<PaddedBox top="4">
				<GameScene zoom="2" padding="0">
					<Block id="minecraft:chest" />
					<BlockAnnotation>
						The chest is less than 50% full
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