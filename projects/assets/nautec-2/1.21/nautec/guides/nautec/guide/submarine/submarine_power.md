---
navigation:
  title: Power and Air
  icon: nautec:prismatic_battery
  position: 2
  parent: submarine/submarine-index.md
---

# <Color id="light_purple">Power and Air</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="prismatic_battery" scale="2"/>
  What the cell pays for.
</Column>

The Sea Scout runs everything from one cell of 1,000,000 power: thrust, the crew's air and every module.

***

## <Color id="gold">Running Costs</Color>

The hull only draws power while someone is aboard. An empty hull, parked or drifting, keeps its charge.

| While aboard | Power per tick |
|---|---|
| Sitting still | 1 |
| Moving | 6 more |
| Keeping the crew breathing | 2 more |
| Flying, with a [Flight Module](flight_module.md) | 4 more |

A crewed hull under way uses 9 per tick, so a full cell gives about an hour and a half of travel. Modules draw on the same cell and cost far more per use, so a busy dive empties it much sooner (see [Modules](submarine_modules.md)).

All of these are configurable. Pilots in creative mode use no power.

***

## <Color id="gold">Air</Color>

While the cell has any charge, the hull is sealed and everyone aboard keeps a full air bar, however deep you go.

When the cell hits zero the seal goes with it. The readout reads CHG, the thrusters stop, and your air starts draining like normal swimming. Surface or get to a [Sea Scout Dock](submarine_dock.md) before that happens, or wear a [Diving Suit](nautec:getting_started/diving_gear.md) as a backup.

The hull itself cannot drown.

***

## <Color id="gold">Charging</Color>

| Source | Rate | Empty to full |
|---|---|---|
| [Sea Scout Dock](submarine_dock.md) | 40 per tick | about 21 minutes |
| <ItemLink id="charger"/> (hull as an item) | what the beam delivers, up to 128 per tick | about 6 and a half minutes at 128 AP, longer with a weaker beam |
| [Solar Module](solar_module.md) | 2,000 every 5 seconds in daylight (about 20 per tick) | about 42 minutes |

The dock is the practical way to refill a hull: park it, leave it, come back. A Charger needs the hull picked up first, and how fast it fills depends on the beam feeding it: a beam of 40 AP matches the dock, and anything stronger beats it. A Solar Module keeps working whether or not anyone is aboard, so a hull parked in open water during the day refills itself.
