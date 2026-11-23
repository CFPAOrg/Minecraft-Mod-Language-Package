---
navigation:
  title: Augmentation Station
  icon: nautec:augmentation_station
  position: 1
  parent: laser_augmentation/laser_augmentation-index.md
item_ids:
  - nautec:augmentation_station
  - nautec:augmentation_station_extension
  - nautec:claw_robot_arm
---

# <Color id="light_purple">Augmentation Station</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="augmentation_station" scale="2"/>
  The Augmentation Station is the multiblock that installs augments into your body.
</Column>

You stand on the middle block, the four extensions around you hold the part, and their robot arms fit it.

***

## <Color id="gold">Building It</Color>

The structure is one layer, 5 by 5, with the corners left empty:

* The Augmentation Station in the middle.
* Polished Prismarine directly north, south, east and west of it.
* Aquarine Steel Blocks on the four diagonals.
* An Augmentation Station Extension two blocks out on each side.

<GameScene zoom="4" background="#333333" interactive={true}>
  <Block id="nautec:augmentation_station_extension" x="2" y="0" z="0"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="1"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="0" z="1"/>
  <Block id="nautec:augmentation_station_extension" x="0" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="2"/>
  <Block id="nautec:augmentation_station" x="2" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="2"/>
  <Block id="nautec:augmentation_station_extension" x="4" y="0" z="2"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="3"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="0" z="3"/>
  <Block id="nautec:augmentation_station_extension" x="2" y="0" z="4"/>
  <IsometricCamera yaw="225" pitch="30"/>
</GameScene>

Right-click the middle Augmentation Station block with the <ItemLink id="aquarine_steel_wrench"/> without crouching to form it. All four extensions have to be in place, even if you only load one of them. Breaking any block of the formed station unforms all of it; replace the block and use the wrench again.

***

## <Color id="gold">Loading an Extension</Color>

Right-click a formed extension to open it. It has two slots, each holding one item:

* The top slot takes the <ItemLink id="claw_robot_arm"/>. Without it the extension is ignored.
* The bottom slot takes the part you want installed.

Load as many extensions as the augment has parts. Almost every augment uses a single part, so load exactly one extension and leave the others empty. The Vent Carapace is the exception: it takes a Chitin Plate in each of the four extensions. The station only recognises the recipe when the loaded extensions match it exactly, so an extra loaded extension stops anything from being offered.

***

## <Color id="gold">Powering It</Color>

Every extension holding a part needs a laser beam of at least 25 AP coming up into it from the block below. The power is only checked, not used up, but it has to stay at 25 AP or more for the whole install. Empty extensions need no beam.

Since the beam has to enter from underneath, put your catalyst or relay under the floor and fire it straight up. See [Laser Power](nautec:getting_started/laser_power.md) for getting a beam started.

The 25 AP threshold is configurable (`augmentationPowerRequirement`).

***

## <Color id="gold">Using It</Color>

Stand on the middle block. After half a second the station's screen opens. It updates live while you stand there, so you can load parts or fix the beam with it open:

* The status bar at the top says whether the station is ready, and if not, what is wrong. Hover over it for the full explanation.
* The augment box names the augment the loaded parts make and what it does.
* The four extension columns show each extension's part, with a red frame if the part has no Claw Robot Arm, and the beam it gets. The number turns green at 25 AP or more and red below it. Hover over a column for details.
* Hover over yourself on the left to see the augments you already have.

Pick a body slot along the bottom and press Apply. If that slot already holds an augment, the Apply button turns red and its tooltip says what will be replaced. If you closed the screen, step off and back on to open it again. Standing on a station that is not formed shows a reminder above your hotbar instead.

For the next four seconds you are held in place while the robot arms work, and a bar shows the progress. Stepping off, the beam dropping below 25 AP, or the part being taken out cancels the install and nothing is used. When it finishes, the part is used up, the Claw Robot Arm stays, and the augment is in your chosen slot.

To remove an augment, take every part out of the extensions first. With nothing loaded, the buttons along the bottom list the slots that hold an augment and Apply becomes Remove. Pick a slot and press it: you are held in place for four seconds, then the augment comes out and its part goes back into your inventory. Removal doesn't require a beam.

[Player Augmentation](augmentation.md) lists what each slot takes and how replacing and removing an augment works.

***

## <Color id="gold">Recipes</Color>

<Recipe id="nautec:augmentation_station"/>

<Recipe id="nautec:augmentation_station_extension"/>

<Recipe id="nautec:claw_robot_arm"/>

***

## <Color id="gold">Stronger Beams</Color>

Each extension in use needs 25 AP. A stronger beam installs faster: speed is the square root of (beam ÷ 25), and the install runs at the pace of the weakest extension in use, so power them evenly.

| Beam | Speed |
|---|---|
| 25 AP | ×1 (normal) |
| 100 AP | ×2 |
| 225 AP | ×3 |
| 400 AP | ×4 |

The four seconds an install takes is with every extension at 25 AP.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.
