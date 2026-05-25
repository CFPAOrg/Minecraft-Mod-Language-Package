---
navigation:
  title: "便签"
  icon: "red_sticky_note"
  position: 5
item_ids:
  - little_big_redstone:white_sticky_note
  - little_big_redstone:light_gray_sticky_note
  - little_big_redstone:gray_sticky_note
  - little_big_redstone:black_sticky_note
  - little_big_redstone:brown_sticky_note
  - little_big_redstone:red_sticky_note
  - little_big_redstone:orange_sticky_note
  - little_big_redstone:yellow_sticky_note
  - little_big_redstone:lime_sticky_note
  - little_big_redstone:green_sticky_note
  - little_big_redstone:cyan_sticky_note
  - little_big_redstone:light_blue_sticky_note
  - little_big_redstone:blue_sticky_note
  - little_big_redstone:purple_sticky_note
  - little_big_redstone:magenta_sticky_note
  - little_big_redstone:pink_sticky_note
---

# 便签

<FloatingColumn align="right">
	<PaddedBox left="5">
		<RecipeFor id="red_sticky_note" />
	</PaddedBox>
</FloatingColumn>

<FloatingColumn>
	<PaddedBox left="5" right="10" bottom="5">
		<Row gap="1">
			<ItemImage id="red_sticky_note" />
			<ItemImage id="orange_sticky_note" />
			<ItemImage id="yellow_sticky_note" />
			<ItemImage id="lime_sticky_note" />
		</Row>
		<Row gap="1">
			<ItemImage id="green_sticky_note" />
			<ItemImage id="cyan_sticky_note" />
			<ItemImage id="light_blue_sticky_note" />
			<ItemImage id="blue_sticky_note" />
		</Row>
		<Row gap="1">
			<ItemImage id="purple_sticky_note" />
			<ItemImage id="magenta_sticky_note" />
			<ItemImage id="pink_sticky_note" />
			<ItemImage id="brown_sticky_note" />
		</Row>
		<Row gap="1">
			<ItemImage id="white_sticky_note" />
			<ItemImage id="light_gray_sticky_note" />
			<ItemImage id="gray_sticky_note" />
			<ItemImage id="black_sticky_note" />
		</Row>

		<PaddedBox left="2" top="10">
			<GameScene zoom="3.3" padding="0" background="transparent">
				<Entity id="little_big_redstone:sticky_note" x="0.75" y="0.75" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:' ',TextColor:15,Color:14,Facing:0,AttachedFace:2,Quadrant:0}" />
				<Entity id="little_big_redstone:sticky_note" x="0.25" y="0.75" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:'',Color:1,Facing:0,AttachedFace:2,Quadrant:1}" />
				<Entity id="little_big_redstone:sticky_note" x="-0.75" y="0.75" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:'',Color:4,Facing:0,AttachedFace:2,Quadrant:0}" />
				<Entity id="little_big_redstone:sticky_note" x="-0.25" y="0.75" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:'',Color:5,Facing:0,AttachedFace:2,Quadrant:1}" />

				<Entity id="little_big_redstone:sticky_note" x="0.75" y="0.25" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:'',Color:13,Facing:0,AttachedFace:2,Quadrant:2}" />
				<Entity id="little_big_redstone:sticky_note" x="0.25" y="0.25" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:' ',TextColor:15,Color:9,Facing:0,AttachedFace:2,Quadrant:3}" />
				<Entity id="little_big_redstone:sticky_note" x="-0.75" y="0.25" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:'',Color:3,Facing:0,AttachedFace:2,Quadrant:2}" />
				<Entity id="little_big_redstone:sticky_note" x="-0.25" y="0.25" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:'',Color:11,Facing:0,AttachedFace:2,Quadrant:3}" />
	
				<Entity id="little_big_redstone:sticky_note" x="0.75" y="-0.75" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:'',Color:10,Facing:0,AttachedFace:2,Quadrant:0}" />
				<Entity id="little_big_redstone:sticky_note" x="0.25" y="-0.75" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:'',Color:2,Facing:0,AttachedFace:2,Quadrant:1}" />
				<Entity id="little_big_redstone:sticky_note" x="-0.75" y="-0.75" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:' ',TextColor:15,Color:6,Facing:0,AttachedFace:2,Quadrant:0}" />
				<Entity id="little_big_redstone:sticky_note" x="-0.25" y="-0.75" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:'',Color:12,Facing:0,AttachedFace:2,Quadrant:1}" />
	
				<Entity id="little_big_redstone:sticky_note" x="0.75" y="-0.25" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:'',Color:0,Facing:0,AttachedFace:2,Quadrant:2}" />
				<Entity id="little_big_redstone:sticky_note" x="0.25" y="-0.25" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:'',Color:8,Facing:0,AttachedFace:2,Quadrant:3}" />
				<Entity id="little_big_redstone:sticky_note" x="-0.75" y="-0.25" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:'',Color:7,Facing:0,AttachedFace:2,Quadrant:2}" />
				<Entity id="little_big_redstone:sticky_note" x="-0.25" y="-0.25" z="0.96875" rotationY="180" rotationX="0" data="{StickyNote:' ',TextColor:0,Color:15,Facing:0,AttachedFace:2,Quadrant:3}" />
	
				<IsometricCamera yaw="180" pitch="0" />
			</GameScene>
		</PaddedBox>
	</PaddedBox>
</FloatingColumn>

便签是能放置到世界中的物品，放置方式与物品展示框类似。方块的一面上可以放置4张便签，颜色和朝向不限。

此外，便签还可以放置在[微芯片](microchips.md)内，放置方式与[逻辑元件](logic/introduction.md)类似。如此放置的便签可用于进一步组织管理逻辑电路。右击微芯片内部的便签即可进行编辑。

### 阅读和编辑

对便签按下&zwnj;**<KeyBind id="key.use" />**&zwnj;可查看其上文本。打开便签后，可以点击“编辑”按钮来编辑文本，也可直接对便签按下&zwnj;**<KeyBind id="key.sneak" />**&zwnj;和&zwnj;**<KeyBind id="key.use" />**&zwnj;打开编辑菜单。便签在被破坏和放置时会保留其文本内容和颜色。

放置在世界中的便签只会在其上写有文本时显示文本线纹理。

便签可以用蜜脾密封，和告示牌类似。密封的便签不可再编辑。可以将便签与蜜脾合成以密封，也可手持蜜脾对放置在世界中的便签按下&zwnj;**<KeyBind id="key.sneak" />**&zwnj;和&zwnj;**<KeyBind id="key.use" />**&zwnj;。

### Markdown

便签中的文本支持基础的Markdown语法：

\**斜体*\*、\*\***粗体**\*\*、\_\_<Underlined>下划线</Underlined>\_\_、\~\~~删除线~\~\~

便签内可用占位格式符打出逻辑元件的符号。将对应元件的ID放在小于号（\<）和大于号（\>）之间。例如：\<io\>、\<not_gate\>、\<and_gate\>。

在行首使用连字符（\-）或星号（\*），后再接一个空格，即可创建无序列表表项。行首可附加任意数量的空格，用以缩进表项。而且，在表项符后使用\[ \]或\[x\]还可创建勾选框。例如：

\- 普通表项。

\- \[ \] 未勾选的勾选框表项。

\- \[x\] 勾选的勾选框表项。

### 染色

用染料对便签按下&zwnj;**<KeyBind id="key.sneak" />**&zwnj;和&zwnj;**<KeyBind id="key.use" />**&zwnj;可为其上文本染色。

可以用水桶和雪球去除文本的染色效果，操作方法类似。雪球使用后即消耗，而水桶不会消耗。

染色后，便签会在世界中纹理和查看/编辑菜单内以该颜色显示文本。

### 物品展示

在世界中手持物品对便签按下&zwnj;**<KeyBind id="key.use" />**&zwnj;，即可把该物品放置到便签上。该便签不会再显示文本，而是会显示物品。若设置了便签的文本颜色，则物品会被染上该颜色；文本颜色为默认色则不进行染色。

### 便签板

看向世界中的便签时，其内容会显示在屏幕上，显示位置可在便签板菜单中调整；还可在该菜单中将便签固定在屏幕上！按下“打开便签板”键（**<KeyBind id="key.little_big_redstone.open_note_board" />**），即可打开便签板。可在其中选取物品栏内的便签进行固定，固定位置不限。固定的便签可用**鼠标右键**编辑。每个世界、每位玩家单独保存便签板内容。死亡不会移除便签。