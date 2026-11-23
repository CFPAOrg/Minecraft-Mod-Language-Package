---
navigation:
  title: Player Augmentation
  icon: nautec:claw_robot_arm
  position: 2
  parent: laser_augmentation/laser_augmentation-index.md
---

# <Color id="light_purple">Player Augmentation</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="claw_robot_arm" scale="2"/>
  Your body has nine augment slots, and each slot holds one augment.
</Column>

Every augment fits only certain slots. The station screen lists the slots a part can go into when you step on it.

***

## <Color id="gold">Body Slots</Color>

| Slot | Augments that fit |
|---|---|
| Head | Vent Carapace, Resonance (Resonance Charm) |
| Eyes | Guardian Eye, Abyssal Eyes |
| Body | Dolphin Fin, Creative Flight (Buoyancy Tank), Photophore Skin, Vent Carapace |
| Lungs | Drowned Lung |
| Heart | Eldritch Heart, Bonus Hearts (Auxiliary Ventricle) |
| Left Arm, Right Arm | Magnet, Ender Magnet, Underwater Mining Speed, Bouncing Trident, Spreading Trident, Random Potion Throwing |
| Left Leg, Right Leg | Leap, Step Up, Prevent Fall Damage, Walking Speed |

Flight, the Dolphin Fin and Photophore Skin all need the Body slot, so you get one of the three. Vent Carapace can go in Head instead, which keeps the Body slot free, but then it competes with the Resonance augment.

The Resonance augment is a [Resonance Charm](nautec:deep_engineering/resonance_network.md) installed as a part, so it charges your items without taking a charm slot.

Two copies of the same leg part do nothing more than one, so fit two different legs. The same goes for Vent Carapace in both Head and Body.

***

## <Color id="gold">Installing</Color>

Load the part and a Claw Robot Arm into one extension of a formed [Augmentation Station](augmentation_station.md), give that extension a 25 AP beam from below, then stand on the middle block, pick a slot and press Apply. The install takes four seconds, during which you cannot move.

***

## <Color id="gold">Replacing and Removing</Color>

Installing into a slot that already holds an augment replaces it. The old augment is destroyed, not returned as an item.

To empty a slot, take every part out of the station's extensions and stand on the middle block. The buttons along the bottom then list your installed augments. Pick one and press Remove. You are held in place for four seconds, as with an install, and stepping off cancels it. You get back the part that made the augment, with the same data it had when you installed it, so a Resonance Charm keeps its binding. If your inventory is full it drops at your feet. Removal doesn't require a beam or any parts.

Operators can also use `/nautec augments remove <slot>` (for example `nautec:left_arm`) or `/nautec augments clear`, which act on the player running the command.

Augments are kept when you die.

***

## <Color id="gold">Key Bindings</Color>

Most augments work on their own. These ones need a key, listed in the Controls screen under the Nautec category:

| Key (default) | Binding name | Augment |
|---|---|---|
| B | Open the Augmentation Screen | Shows your installed augments and their slots |
| L (hold) | Activate Guardian Eye Augment Laser | Guardian Eye |
| Left Alt | Leap | Leap (Hydraulic Leg) |
| Y | Throw Trident | Bouncing Trident (Trident Launcher Arm) |
| U | Throw Spreading Trident | Spreading Trident (Volley Trident Arm) |
| G | Throw Potion | Random Potion Throwing (Syringe Robot Arm) |
| Not set | Toggle Magnet Augments | Turns Magnet and Ender Magnet on or off |

None of the active augments use power or items. Leap and the three throwing arms have a short cooldown between uses; the Guardian Eye fires for as long as you hold the key.
