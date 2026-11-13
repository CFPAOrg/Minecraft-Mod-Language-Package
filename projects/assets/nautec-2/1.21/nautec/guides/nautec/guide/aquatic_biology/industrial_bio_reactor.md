---
navigation:
  title: Industrial Bio Reactor
  icon: nautec:industrial_bio_reactor
  position: 12
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:industrial_bio_reactor
---

# <Color id="light_purple">Industrial Bio Reactor</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="industrial_bio_reactor" scale="2"/>
  A 5 by 5 by 4 reactor that runs nine colonies with four upgrade slots.
</Column>

It works like the [Bio Reactor](bio_reactor.md): the same [production formula](production_rates.md) and base speed, the same [feeding](colony_feeding.md), aging and decay, and the same [upgrades](reactor_upgrades.md). What it adds is room: 9 colony slots with 9 output slots, 3 nutrient slots and 4 upgrade slots.

***

## <Color id="gold">Building It</Color>

Four layers, each 5 by 5:

* Layer 1 (bottom): Dark Prismarine Pillars in the four corners, Polished Prismarine everywhere else.
* Layers 2 and 3: Dark Prismarine Pillars in the corners and Bacteria Containment Shields along the edges, with the 3 by 3 middle left empty. The Industrial Bio Reactor takes the place of the middle shield of one wall in layer 2.
* Layer 4 (roof): Dark Prismarine Pillars in the corners, Aquarine Steel Blocks everywhere else.

<GameScene zoom="3" background="#333333" interactive={true}>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="0" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="4" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="0" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="4" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="0" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="4" y="0" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="0" z="4"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="4"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="4"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="0" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="1" z="0"/>
  <Block id="nautec:industrial_bio_reactor" x="2" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="1" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="1" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="1" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="3"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="1" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="1" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="1" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="1" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="1" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="1" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="2" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="2" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="2" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="2" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="2" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="2" z="3"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="2" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="2" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="2" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="2" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="2" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="2" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="3" z="0"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="3" z="0"/>
  <Block id="nautec:aquarine_steel_block" x="2" y="3" z="0"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="3" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="3" z="0"/>
  <Block id="nautec:aquarine_steel_block" x="0" y="3" z="1"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="3" z="1"/>
  <Block id="nautec:aquarine_steel_block" x="2" y="3" z="1"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="3" z="1"/>
  <Block id="nautec:aquarine_steel_block" x="4" y="3" z="1"/>
  <Block id="nautec:aquarine_steel_block" x="0" y="3" z="2"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="3" z="2"/>
  <Block id="nautec:aquarine_steel_block" x="2" y="3" z="2"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="3" z="2"/>
  <Block id="nautec:aquarine_steel_block" x="4" y="3" z="2"/>
  <Block id="nautec:aquarine_steel_block" x="0" y="3" z="3"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="3" z="3"/>
  <Block id="nautec:aquarine_steel_block" x="2" y="3" z="3"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="3" z="3"/>
  <Block id="nautec:aquarine_steel_block" x="4" y="3" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="3" z="4"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="3" z="4"/>
  <Block id="nautec:aquarine_steel_block" x="2" y="3" z="4"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="3" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="3" z="4"/>
  <IsometricCamera yaw="225" pitch="30"/>
</GameScene>

The Industrial Bio Reactor can go in the middle of any of the four walls, so you can build the frame first and put the reactor block in whichever side faces you. The scene shows it in the north wall. The 3 by 3 by 2 chamber inside must be air, with no water and no blocks in it. Without the roof it looks like this:

<GameScene zoom="3" background="#333333" interactive={true}>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="0" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="4" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="0" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="4" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="0" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="4" y="0" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="0" z="4"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="4"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="4"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="0" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="1" z="0"/>
  <Block id="nautec:industrial_bio_reactor" x="2" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="1" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="1" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="1" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="3"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="1" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="1" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="1" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="1" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="1" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="1" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="2" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="2" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="2" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="2" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="2" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="2" z="3"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="2" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="2" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="2" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="2" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="2" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="2" z="4"/>
  <IsometricCamera yaw="225" pitch="30"/>
</GameScene>

Right-click the Industrial Bio Reactor with an <ItemLink id="aquarine_steel_wrench"/> in Rotate mode, without sneaking, to form it. If a block is wrong, chat names its position, what is there and what should be. Breaking any block of the formed reactor takes it apart again.

Once it is formed, right-click any of its blocks without the wrench in your hand to open it.

***

## <Color id="gold">Power</Color>

It needs 100 AP plus 50 AP per filled colony slot: 150 AP for one colony and 550 AP for nine, before upgrades multiply it. Like the Bio Reactor, this is a minimum. Below it nothing runs and all progress resets, and a stronger beam above it speeds the reactor up (see Stronger Beams below).

Power goes in through hatches in the roof. Right-click one of the Aquarine Steel Blocks of the formed roof with the wrench to turn it into a hatch, and again to turn it back. This does not work in Item Sides mode, which sets the reactor's sides instead. A hatch takes a beam pointing down into it from above, and a hatch on the roof's edge also takes one pointing into its outer side. You can open as many hatches as you like, and their power adds together. A beam into the front of the Industrial Bio Reactor block itself counts as well.

That is far more than one catalyst gives. An [Energy Converter](nautec:laser_chemistry/energy_converter.md) with no upgrades sends up to 150 AP per tick, so four of them on four hatches cover nine colonies without upgrades. Beams can also be combined in a <ItemLink id="laser_junction"/> before they reach a hatch.

***

## <Color id="gold">The Screen</Color>

* The 3 by 3 grid on the left holds the colonies. The thin bar to the right of each is its nutrient buffer and the bar under it is its progress.
* The 3 by 3 grid on the right holds the output, one slot per colony in the same order.
* The bottom row has the three nutrient slots on the left and the four upgrade slots on the right.
* The arrow in the middle shows the average progress. Hover it to see the power arriving against the power needed, and what the upgrades are doing.

Nine colonies need feeding from only three nutrient slots, so run no more than three different nutrients at once. [Colony Feeding](colony_feeding.md) has the details.

***

## <Color id="gold">Automation</Color>

* Every outer face of every block takes and gives items: a hopper on the roof or pointing into a wall feeds nutrients and upgrades, hoppers under the floor pull output, and a pipe works anywhere on the outside.
* [Side Configuration](nautec:getting_started/utilities.md) sets what each side of the structure does. Use the tab on the right of the reactor's screen, or the wrench in Item Sides mode on any block of the reactor. One setting covers a whole side: Front is the wall with the Industrial Bio Reactor block in it, and Left and Right are the walls on your left and right as you face that block from outside. For example, set the roof to Insert and the floor to Extract so pipes on the roof never pull output and pipes under the floor never push into it.

Colonies load and unload through the Dish Port. A dish goes into the upper slot between the colony grid and the outputs, and dishes holding a colony come out of the lower one; empty dishes come out of the slot in the bottom row, between the nutrients and the upgrades. A Petri Dish holding a colony loads it into the first colony slot that can take all of it. Once every colony slot is full, a new colony dish swaps instead, but only for a Senescent colony: its colony replaces the oldest Senescent one, and the old colony comes out in that same dish, so no empty dish is left over. While no colony is Senescent the dish waits in the port, and a swap also waits while the colony output slot is full. An empty dish takes out the oldest Senescent colony and waits in the port while none is Senescent, and the port refuses dishes holding a Senescent colony, so one chest can collect from the port and feed it at the same time. To take out a colony that is not Senescent, click its colony slot with an empty dish. Automation reaches the port wherever it reaches the other slots.

Automation only puts items into the nutrient, upgrade and Dish Port slots and only takes them from the output slots and the Dish Port. Keep hoppers off the roof hatches: a block sitting on a hatch stops a beam coming down into it.

A simple layout: a chest and hopper on one corner of the roof for nutrients, hatches with beams on the rest of the roof, and hoppers under the floor leading to storage. A capped colony can fill its output slot in about ten seconds, so give the output more than one hopper once the colonies are strong.

***

## <Color id="gold">Recipe</Color>

<RecipeFor id="industrial_bio_reactor"/>

***

## <Color id="gold">Stronger Beams</Color>

The Industrial Bio Reactor first works out the AP it needs from its colonies and upgrades. A stronger beam than that speeds up production on top of its Speed Upgrades: speed is the square root of (beam ÷ what it needs).

| Beam, as a multiple of what it needs | Speed |
|---|---|
| 1× | ×1 (normal) |
| 4× | ×2 |
| 9× | ×3 |
| 16× | ×4 |

The two multiply. A reactor whose Speed Upgrade makes it run ×1.5 and that gets four times the power it needs runs ×3. Nutrients are spent per tick of work, so a stronger beam makes more items from the same nutrient. Hover a progress arrow to see the beam speed and the total speed with upgrades; Jade shows the beam speed too.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.
