---
navigation:
  title: Tools and Utilities
  icon: nautec:aquarine_steel_wrench
  position: 7
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:aquarine_steel_wrench
  - nautec:configuration_card
---

# <Color id="light_purple">Tools and Utilities</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="aquarine_steel_wrench" scale="2"/>
  The Wrench sets up and turns NauTec blocks, and sets which faces of a machine hoppers and pipes can use.
</Column>

***

<Row>
  <ItemImage id="aquarine_steel_wrench"/>
  ### <Color id="aqua">Aquarine Steel Wrench</Color>
</Row>

The wrench has four modes. Sneak and right-click the air to switch between them; the tooltip and the message above the hotbar show the current one.

* Rotate: right-click any block with a facing, such as the <ItemLink id="aquatic_catalyst"/>, a relay or a machine, to turn it to its next direction. Keep clicking to go all the way round.
* Item Sides and Fluid Sides: right-click a face of a machine to change what hoppers and pipes can do through it, and sneak right-click to step back. In Item Sides mode, any block of a formed Bio Reactor or Industrial Bio Reactor sets that side of the whole reactor. See Side Configuration below.
* Link: aims two laser blocks at each other in two clicks. Right-click the block that sends the beam, such as a <ItemLink id="prismarine_laser_relay"/>, a <ItemLink id="laser_junction"/> or an <ItemLink id="aquatic_catalyst"/>, to save it as the start. Then right-click the block the beam should reach, such as another relay or a machine. The wrench turns the start so it sends toward the second block and turns the second block so it takes the beam from the start; on a junction it opens the matching output or input face instead. The two blocks must be in a straight line and within the beam's reach, and the message above the hotbar says if something stands in the way. After a link the saved start clears, ready for the next one. Right-clicking the air, or a block that does not send or take laser beams, clears the saved start, and the tooltip shows where it is while one is saved. In this mode the wrench works on machines without opening their screens. A relay takes its beam from behind and sends it out of its front, so linking one onward around a corner turns it away from the beam it was taking; the message warns you, and a <ItemLink id="laser_junction"/> turns beams around corners.

These work in every mode:

* An unformed Augmentation Station, Bio Reactor, Industrial Bio Reactor or Deep Sea Drain forms its multiblock when you click the controller block without sneaking.
* A <ItemLink id="gateway"/> forms its ring when you click it, and a sneak right-click on a formed ring packs the whole ring into one item. See [Gateway](nautec:deep_engineering/gateway.md).
* Sneak right-clicking a Prismarine Crystal you grew yourself picks the whole crystal up. Wild crystals cannot be moved. See [Crystal Cultivation](nautec:deep_engineering/crystal_cultivation.md).
* Right-clicking a Sea Scout opens its module screen. See [Sea Scout](nautec:submarine/submarine.md).
* A <ItemLink id="laser_junction"/> face becomes an input with a right-click and an output with a sneak right-click. Clicking a face again the same way turns it off.
* A top edge block of a formed [Bio Reactor](nautec:aquatic_biology/bio_reactor.md), a roof block of a formed [Industrial Bio Reactor](nautec:aquatic_biology/industrial_bio_reactor.md), or the outer side face of a middle wall block of a formed [Deep Sea Drain](nautec:laser_chemistry/drain.md) opens a laser port there, so a beam can feed the machine. On the drain the port is the exact face you click, so click the side, not the top or bottom. A reactor port closes again with another click. On the reactors this does not work in Item Sides mode, since that mode sets the reactor's sides.

<Recipe id="nautec:aquarine_wrench"/>

***

## <Color id="gold">Side Configuration</Color>

Every NauTec machine that holds items or fluids lets you choose, face by face, what automation can do there. Items and fluids are set separately. Each face has one of four modes:

* Insert and Extract (green): hoppers and pipes can insert into the input slots and extract from the output slots. Every face starts like this.
* Insert (blue): hoppers and pipes can insert, nothing comes out.
* Extract (orange): hoppers and pipes can extract, nothing goes in.
* Off (grey): hoppers and pipes cannot reach this face at all.

A machine only ever takes inputs into its input slots and gives outputs from its output slots, whatever the face mode, so a pipe cannot pull your ingredients back out.

Change a face with the wrench in Item Sides or Fluid Sides mode, or open the machine and click the small tab on the right edge of its screen. The tab opens a cross of six faces: front, back, left, right, top and bottom, named as you look at the machine's front. Left-click a face for the next mode and right-click for the previous one. Machines that hold both items and fluids have Items and Fluids buttons above the faces. Machines without a facing, or facing straight up or down, treat north as their front.

The Bio Reactor and Industrial Bio Reactor have one item setting per side for the whole structure: the faces in the reactor's screen stand for the six outer sides of the multiblock, with its north side as the front. Other multiblocks such as the Deep Sea Drain and the Fusion Plant keep their own rules, described on their pages.

***

<Row>
  <ItemImage id="configuration_card"/>
  ### <Color id="aqua">Configuration Card</Color>
</Row>

Copies settings from one block to another. Sneak and right-click a machine to copy its settings onto the card, then right-click another block to paste them. Sneak and right-click the air to clear the card. The tooltip shows where the settings came from and what they cover. Right-clicking with the card always pastes, even on blocks that would otherwise open their screen.

* The side configuration pastes onto any machine with side configuration, so one card can set up a whole row of different machines the same way.
* A block's own settings only paste onto the same kind of block:
  * a <ItemLink id="confined_spawner"/>'s filter and whitelist mode
  * a <ItemLink id="resonance_node"/>'s network, input or output mode, priority, limit and chunk loading
  * an <ItemLink id="uplink_array"/>'s network and chunk loading
  * a <ItemLink id="laser_junction"/>'s input and output faces
  * a Conduit Tap's faces
  * a <ItemLink id="laser_purification_smelter"/>'s auto-distribute setting
* Upgrades and filters copy as well, onto the same kind of block: a Conduit Tap's upgrade and filter, an <ItemLink id="energy_converter"/>'s upgrades, a Bio Reactor's upgrades and a Laser Purification Smelter's conduit upgrade. Pasting takes them from your inventory and hands back whatever the target held in those slots. If you are missing any, nothing is pasted and the card tells you what you need.

Pasting a resonance network checks that you are allowed to use it, the same as choosing it in the screen.

<Recipe id="nautec:configuration_card"/>
