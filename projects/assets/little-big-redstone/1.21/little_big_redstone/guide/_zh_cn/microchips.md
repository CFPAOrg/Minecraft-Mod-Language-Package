---
navigation:
  title: "微芯片"
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

# 微芯片

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

微芯片是一类红石方块，可在其中放置[逻辑元件](logic/introduction.md)以搭建复杂的系统。逻辑元件之间可用[导线](redstone_bits.md)相连，以在元件之间传递信号。

微芯片的菜单可以滚动滚轮缩放。按住左键拖动可移动电路编辑界面的视野。

### 方向

使用对世界输入输出的逻辑元件时，应当设置该元件使用的交互面方向。微芯片支持轴向方向，也即<Color color="#4CFF00">北</Color>、<Color color="#0094FF">南</Color>、<Color color="#FF0000">东</Color>、<Color color="#FF6A00">西</Color>、<Color color="#FFFFFF">上</Color>、<Color color="#FFD800">下</Color>。按住&zwnj;**<KeyBind id="key.sneak" />**&zwnj;看向微芯片的侧面可查看该面对应方向的颜色。

### 染色

微芯片可以染成标准的16种染料颜色，其菜单也会使用该颜色。逻辑元件可以独立于微芯片进行染色，但默认情况下它们会继承所处微芯片的颜色。可以和往常一样在合成方格内为逻辑元件染色，也可选择用染料右击菜单中的逻辑元件。

可以使用水桶和雪球去除逻辑元件的染色效果，操作方法类似。雪球使用后即消耗，而水桶不会消耗。