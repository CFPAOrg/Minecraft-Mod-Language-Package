---
navigation:
  title: "Microchips"
  icon: "red_microchip"
  position: 1
item_ids:
  - little_big_redstone:white_microchip
  - little_big_redstone:light_gray_microchip
  - little_big_redstone:gray_microchip
  - little_big_redstone:black_microchip
  - little_big_redstone:brown_microchip
  - little_big_redstone:red_microchip
  - little_big_redstone:orange_microchip
  - little_big_redstone:yellow_microchip
  - little_big_redstone:lime_microchip
  - little_big_redstone:green_microchip
  - little_big_redstone:cyan_microchip
  - little_big_redstone:light_blue_microchip
  - little_big_redstone:blue_microchip
  - little_big_redstone:purple_microchip
  - little_big_redstone:magenta_microchip
  - little_big_redstone:pink_microchip
---

# Microchips

<FloatingColumn align="right">
	<PaddedBox left="5">
		<RecipeFor id="red_microchip" />
	</PaddedBox>
</FloatingColumn>

<FloatingColumn>
	<PaddedBox left="5" right="10" bottom="5">
		<GameScene zoom="1.5" padding="0" background="transparent">
			<ImportStructure src="assets/structures/microchips.snbt" />
			<IsometricCamera yaw="135" pitch="30" />
		</GameScene>
	</PaddedBox>
</FloatingColumn>

Microchips are blocks that can have [logic](logic/introduction.md) placed inside of it to create complex systems.
[Wires](redstone_bits.md) can be placed between logic to allow signals to be carried from one logic component to
another.

While in the microchip menu, you can zoom in and out using the scroll wheel. Holding left-click and dragging will move
the view area of the circuit.

### Directions

When using logic components that take input from or output to the world, you will need to set the direction it uses.
The microchip uses cardinal directions, meaning <Color color="#4CFF00">north</Color>,
<Color color="#0094FF">south</Color>, <Color color="#FF0000">east</Color>, and <Color color="#FF6A00">west</Color> as
well as <Color color="#FFFFFF">up</Color> and <Color color="#FFD800">down</Color>. The color of a direction can be seen
on the side of a microchip by pressing **<KeyBind id="key.sneak" />** and looking at it.

### Coloring

Microchips can be dyed any of the standard 16 dye colors, and the menu will reflect the color. Logic components can be
dyed separately from the microchip, but by default they will inherit the color of the microchip they are placed into.
To dye logic components, you can either do so in your crafting grid as you would normally, or you can right click the
logic in the menu with the dye to apply it.

Similarly, you can use a water bucket or snowballs to clear the color from the logic component. Note that snowballs
will be consumed, whereas water buckets will not.