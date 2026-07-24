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

Sticky notes can be sealed using Honeycomb, much like signs. A sealed sticky note can no longer be edited. This can be
done either through crafting a sticky note with a Honeycomb, or by using **<KeyBind id="key.sneak" />** and
**<KeyBind id="key.use" />** on a sticky note placed in world with a Honeycomb.

### Markdown

The text written on a sticky note supports basic markdown functionality:

\**italics*\*, \*\***bold**\*\*, \_\_<Underlined>underline</Underlined>\_\_, and \~\~~strikethrough~\~\~

Logic component symbols can be typed into sticky notes using placeholder formatting. Simply write the ID of the logic
component you want to display surrounded by the less than and greater than signs. For example: \<io\> \<not_gate\>
\<and_gate\>

Bullet point lists can also be made by starting a line with a hyphen (\-) or asterisk (\*) followed by a space. You may
have as many spaces as you want at the start of the line to create indented line items. Additionally, you can put check
boxes by putting \[ \] or \[x\] after the space after the bullet point symbol. For example:

\- A normal line item.

\- \[ \] An unchecked box item.

\- \[x\] A checked box item.

### Coloring

The text on sticky notes can be colored by pressing **<KeyBind id="key.sneak" />** and **<KeyBind id="key.use" />**
with dye.

Similarly, you can use a water bucket or snowballs to clear the color from the logic component. Note that snowballs
will be consumed, whereas water buckets will not.

Text will appear colored both in-world and in the viewing/editing menu.

### Item Display

Items can be placed onto sticky notes using **<KeyBind id="key.use" />** in world. The item will display on the sticky
note instead of text lines. The item will be tinted to match the color of the text for the sticky note, unless the text
color is the default color for that color of note.

### Note Board

The note board is a menu where you can move where notes in-world will be shown on screen when looked at, as well as
pinning notes you have made to your screen! Open the note board using the keybind "Open Note Board"
(**<KeyBind id="key.little_big_redstone.open_note_board" />**). Sticky notes that are in your inventory can then be
placed in the menu wherever you'd like. Pinned notes in the note board can also be edited using **Right Button**. Notes
held in your cursor can be resized using the scroll wheel. Notes in the note board are saved per-world and per-player.
Dying does not remove the notes out of the note board.