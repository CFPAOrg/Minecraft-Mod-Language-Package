---
navigation:
  title: Impulse Laser
  icon: nautec:impulse_laser_module
  position: 13
  parent: submarine/submarine-index.md
item_ids:
  - nautec:impulse_laser_module
---

# <Color id="light_purple">Impulse Laser</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="impulse_laser_module" scale="2"/>
  Twin forward beams.
</Column>

The Impulse Laser Module fires two beams from the hull's nose that meet under your crosshair, like a pair of Atlantean Rifles, for as long as you hold the fire key.

***

## <Color id="gold">Using It</Color>

| | Default |
|---|---|
| Charge | Half a second before the beams appear |
| Ramp | 5 seconds of fire to reach full strength |
| Power | 400 a tick, rising to 1,400 a tick |
| Range | 64 blocks |
| Damage per beam | 2 rising to 6, plus 0.4% rising to 1.25% of the target's maximum health, four times a second |

Select the module on the ability bar and hold attack or the ability key. The laser charges for half a second, then both beams fire. The longer you keep firing, the wider and brighter the beams grow and the harder they hit, up to full strength after five seconds. Let go and they stop at once; firing again starts from the charge.

Aim by pointing the hull: while you steer, both beams meet on whatever creature or solid block is under the crosshair, or at full range if nothing is there. They follow the nose, not your view, so in free look they keep firing where the hull points. Each beam stops at the first creature or solid block in its path, and a target caught by both takes both hits. The damage ignores armor, and the beams pass the hull's own crew by.

***

## <Color id="gold">Power</Color>

A fully ramped laser burns 28,000 power a second, so short bursts go much further than holding fire. It stops when the cell runs too low to feed it, when the pilot leaves the hull, or when the module is taken out.

All the figures are configurable.

***

### <Color id="aqua">Impulse Laser Module Recipe</Color>

<Recipe id="nautec:impulse_laser_module"/>
