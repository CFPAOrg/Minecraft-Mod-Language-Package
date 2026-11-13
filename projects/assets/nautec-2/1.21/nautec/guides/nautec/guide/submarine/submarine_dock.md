---
navigation:
  title: Sea Scout Dock
  icon: nautec:submarine_dock
  position: 4
  parent: submarine/submarine-index.md
item_ids:
  - nautec:submarine_dock
---

# <Color id="light_purple">Sea Scout Dock</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="submarine_dock" scale="2"/>
  A charging pad for a parked hull.
</Column>

The Sea Scout Dock charges a Sea Scout parked over it, holds an empty hull in place, and keeps the crew breathing.

***

## <Color id="gold">Setting It Up</Color>

The dock is a low pad that can be placed under water. Power it with a laser beam of at least 20 AP from any side (see [Laser Power](nautec:getting_started/laser_power.md)). The beam only has to be present: the dock does not use it up, so the hull charges at the same rate however strong the beam is.

Park the hull over the pad. It counts as docked when it overlaps the 3 by 3 area directly above the pad, up to 3 blocks high. The dock clamps with a clunk when it takes hold and releases when the hull leaves or the beam drops below 20 AP. Looking at the pad through a <ItemLink id="prism_monocle"/> shows whether a Sea Scout is docked.

***

## <Color id="gold">What It Does</Color>

* Charges the hull at 40 power per tick on a 20 AP beam, about 21 minutes from empty to full, without picking the hull up. A stronger beam charges faster (see below). The rate is configurable.
* Holds an empty hull still, so what you leave on the pad is still there when you come back. A pilot always overrides the clamps and can drive straight off.
* Keeps everyone aboard breathing on the dock's power, even with the hull's cell empty.

***

### <Color id="aqua">Sea Scout Dock Recipe</Color>

<Recipe id="nautec:submarine_dock"/>

***

## <Color id="gold">Stronger Beams</Color>

The Submarine Dock needs 20 AP. A stronger beam charges a docked submarine faster: its speed is the square root of (beam ÷ 20).

| Beam | Speed |
|---|---|
| 20 AP | ×1 (normal) |
| 80 AP | ×2 |
| 180 AP | ×3 |
| 320 AP | ×4 |

It charges 40 power per tick on a 20 AP beam, 80 per tick on 80 AP, and so on.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.
