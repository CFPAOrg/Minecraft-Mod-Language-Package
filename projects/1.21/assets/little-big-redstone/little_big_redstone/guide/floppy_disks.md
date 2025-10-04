---
navigation:
  title: "Floppy Disks"
  icon: "red_floppy_disk"
  position: 4
item_ids:
  - little_big_redstone:white_floppy_disk
  - little_big_redstone:light_gray_floppy_disk
  - little_big_redstone:gray_floppy_disk
  - little_big_redstone:black_floppy_disk
  - little_big_redstone:brown_floppy_disk
  - little_big_redstone:red_floppy_disk
  - little_big_redstone:orange_floppy_disk
  - little_big_redstone:yellow_floppy_disk
  - little_big_redstone:lime_floppy_disk
  - little_big_redstone:green_floppy_disk
  - little_big_redstone:cyan_floppy_disk
  - little_big_redstone:light_blue_floppy_disk
  - little_big_redstone:blue_floppy_disk
  - little_big_redstone:purple_floppy_disk
  - little_big_redstone:magenta_floppy_disk
  - little_big_redstone:pink_floppy_disk
---

# Floppy Disks

<FloatingColumn align="right">
	<PaddedBox left="5">
		<RecipeFor id="red_floppy_disk" />
	</PaddedBox>
</FloatingColumn>

<FloatingColumn>
	<PaddedBox left="5" right="10" bottom="0">
		<Row gap="1">
			<ItemImage id="red_floppy_disk" />
			<ItemImage id="orange_floppy_disk" />
			<ItemImage id="yellow_floppy_disk" />
			<ItemImage id="lime_floppy_disk" />
		</Row>
		<Row gap="1">
			<ItemImage id="green_floppy_disk" />
			<ItemImage id="cyan_floppy_disk" />
			<ItemImage id="light_blue_floppy_disk" />
			<ItemImage id="blue_floppy_disk" />
		</Row>
		<Row gap="1">
			<ItemImage id="purple_floppy_disk" />
			<ItemImage id="magenta_floppy_disk" />
			<ItemImage id="pink_floppy_disk" />
			<ItemImage id="brown_floppy_disk" />
		</Row>
		<Row gap="1">
			<ItemImage id="white_floppy_disk" />
			<ItemImage id="light_gray_floppy_disk" />
			<ItemImage id="gray_floppy_disk" />
			<ItemImage id="black_floppy_disk" />
		</Row>
	</PaddedBox>
</FloatingColumn>

Floppy disks allow you to store the program in a [Microchip](microchips.md) and then install it onto another microchip
with ease.

By pressing **<KeyBind id="key.sneak" />** + **<KeyBind id="key.use" />** on a microchip while holding a floppy disk,
it will store the microchip's program into the floppy disk.

Once a program has been stored in the floppy disk, you can press **<KeyBind id="key.use" />** on a microchip to install
it, given that you have the logic components and redstone bits necessary. Items in [Logic Arrays](logic_arrays.md)
count as items in your inventory for the sake of installing programs. The items required to install the program will
display above the hotbar when looking at a microchip with a floppy disk in hand.

Programs can be saved and loaded to and from your local computer too! Open the menu for this by pressing
**<KeyBind id="key.use" />** while holding a floppy disk (and not looking at a microchip). The "Save" button will save
the currently stored program to a file with the name you provide in the "Program Name" text box. Similarly, the "Load"
button will load the program from the file with the name provided. If there is not an existing file with this name, the
"Load" button will not be clickable. Saved programs are stored in the **/little_big_redstone/microchips** directory in
your game directory. These files are accessible across worlds and servers.