---
navigation:
  title: "Logic Arrays"
  icon: "red_logic_array"
  position: 3
item_ids:
  - little_big_redstone:white_logic_array
  - little_big_redstone:light_gray_logic_array
  - little_big_redstone:gray_logic_array
  - little_big_redstone:black_logic_array
  - little_big_redstone:brown_logic_array
  - little_big_redstone:red_logic_array
  - little_big_redstone:orange_logic_array
  - little_big_redstone:yellow_logic_array
  - little_big_redstone:lime_logic_array
  - little_big_redstone:green_logic_array
  - little_big_redstone:cyan_logic_array
  - little_big_redstone:light_blue_logic_array
  - little_big_redstone:blue_logic_array
  - little_big_redstone:purple_logic_array
  - little_big_redstone:magenta_logic_array
  - little_big_redstone:pink_logic_array
---

# Logic Arrays

<FloatingColumn align="right">
	<PaddedBox left="5">
		<RecipeFor id="red_logic_array" />
	</PaddedBox>
</FloatingColumn>

<FloatingColumn>
	<PaddedBox left="5" right="10" bottom="0">
		<Row gap="1">
			<ItemImage id="red_logic_array" />
			<ItemImage id="orange_logic_array" />
			<ItemImage id="yellow_logic_array" />
			<ItemImage id="lime_logic_array" />
		</Row>
		<Row gap="1">
			<ItemImage id="green_logic_array" />
			<ItemImage id="cyan_logic_array" />
			<ItemImage id="light_blue_logic_array" />
			<ItemImage id="blue_logic_array" />
		</Row>
		<Row gap="1">
			<ItemImage id="purple_logic_array" />
			<ItemImage id="magenta_logic_array" />
			<ItemImage id="pink_logic_array" />
			<ItemImage id="brown_logic_array" />
		</Row>
		<Row gap="1">
			<ItemImage id="white_logic_array" />
			<ItemImage id="light_gray_logic_array" />
			<ItemImage id="gray_logic_array" />
			<ItemImage id="black_logic_array" />
		</Row>
	</PaddedBox>
</FloatingColumn>

Logic arrays can hold [logic](logic/introduction.md) and [Redstone Bits](redstone_bits.md) to save on inventory space
and allow for easy access when building your circuits.

### Inventory

Logic arrays have 28 slots. The inventory can be opened by holding the logic array in hand and then pressing
**<KeyBind id="key.use" />**. While in the menu for a [Microchip](microchips.md), you can view the contents of any of
the logic arrays in your inventory. By default it will select the first logic array in your inventory to display. At
any point while in the microchip menu, you can left-click one of your logic arrays to select it. That way, you can
have multiple logic arrays and access all of them while working on your circuit.

Below are two examples of what you can expect from the logic array's menu. On the left is when you open the logic
array on its own, and on the right is when you open the logic array when inside the microchip.

<FloatingImage src="assets/logic_array_menu.png" />

<FloatingImage src="assets/logic_array_in_microchip_menu.png" />