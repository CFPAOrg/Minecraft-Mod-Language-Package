---
navigation:
  title: Solar Module
  icon: nautec:solar_module
  position: 7
  parent: submarine/submarine-index.md
item_ids:
  - nautec:solar_module
---

# <Color id="light_purple">Solar Module</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="solar_module" scale="2"/>
  Passive charging from daylight.
</Column>

The Solar Module adds 2,000 power (0.2% of the cell, about 20 per tick) to the hull every 5 seconds while the sun is up and the hull can see the sky.

***

## <Color id="gold">How It Charges</Color>

It is passive and works from any slot. It sees the sky through water, so the hull can stay submerged, but any solid block between the hull and the sky stops it. It only works during the day, and not in dimensions without a day cycle such as the Nether and the End.

It keeps charging with nobody aboard. A hull parked in open water fills from empty in about 42 minutes of sunlight. A [Sea Scout Dock](submarine_dock.md) is twice as fast.

One module is all you need, since a second one adds nothing. The rate is configurable (`submarineSolarPercentPer5s`).

***

### <Color id="aqua">Solar Module Recipe</Color>

<Recipe id="nautec:solar_module"/>
