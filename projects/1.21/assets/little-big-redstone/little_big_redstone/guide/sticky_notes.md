---
navigation:
  title: "Sticky Notes"
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

# Sticky Notes

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

Sticky Notes are items that can be placed into the world similarly to how item frames work. On each face of a block,
you can place 4 sticky notes with any combination of colors and rotations.

Additionally, sticky notes can be placed inside of [Microchips](microchips.md) in the same way that you place
[logic](logic/introduction.md). In this way, sticky notes can be used to further organize your logic. Sticky notes
that are placed inside of Microchips can be edited by pressing right-click on it.

### Reading / Editing

To view the text on a sticky note, use **<KeyBind id="key.use" />** on the sticky note. Once a sticky note has been
opened, you can press the Edit button to edit the text. Alternatively, you can press **<KeyBind id="key.sneak" />**
and **<KeyBind id="key.use" />** on the sticky note to directly open the edit menu. Sticky notes retain their text
contents and colors when broken and placed.

Text lines will only appear on the sticky notes in-world when text is written on them.

### Markdown

The text written on a sticky note supports basic markdown functionality:

\**italics*\*, \*\***bold**\*\*, \_\_<Underlined>underline</Underlined>\_\_, and \~\~~strikethrough~\~\~

### Coloring

The text on sticky notes can be colored by pressing **<KeyBind id="key.use" />** with dye.

Similarly, you can use a water bucket or snowballs to clear the color from the logic component. Note that snowballs
will be consumed, whereas water buckets will not.

Text will appear colored both in-world and in the viewing/editing menu.