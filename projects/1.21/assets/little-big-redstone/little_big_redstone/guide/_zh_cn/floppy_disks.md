---
navigation:
  title: "软盘"
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

# 软盘

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

软盘能存储[微芯片](microchips.md)中的程序，并将其安装到其他微芯片，操作简捷。

手持软盘对微芯片按下&zwnj;**<KeyBind id="key.sneak" />**+**<KeyBind id="key.use" />**&zwnj;，即可将微芯片的程序存入软盘。

软盘内存储有微芯片程序时，可对微芯片按下&zwnj;**<KeyBind id="key.use" />**&zwnj;为其安装程序；如此操作需要你持有所需的逻辑元件和红石位粒。在安装程序时，[逻辑阵列](logic_arrays.md)中的物品视为直接存放于物品栏中。手持软盘看向微芯片时，快捷栏上方会显示安装程序所需的物品。

微芯片程序还可以保存到本地和从本地读取！持有软盘（且未看向微芯片）时按下&zwnj;**<KeyBind id="key.use" />**&zwnj;可打开相关菜单。“保存”按钮会将当前程序保存为文件，其名称需在“程序名称”文本框中指定。与之类似，“加载”按钮会从使用所给名称的文件中加载程序。如果没有文件使用所给名称，“加载”按钮就无法点击。已保存的程序在游戏目录内的&zwnj;**/little_big_redstone/microchips**&zwnj;目录下。这些文件可跨世界和服务器访问。