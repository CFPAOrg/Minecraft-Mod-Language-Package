---
navigation:
  title: Flight Module
  icon: nautec:flight_module
  position: 15
  parent: submarine/submarine-index.md
item_ids:
  - nautec:flight_module
---

# <Color id="light_purple">Flight Module</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="flight_module" scale="2"/>
  Lifts the Sea Scout out of the water and lets it fly.
</Column>

With a Flight Module installed, the hull no longer drops when it leaves the water. It holds itself up in the air and flies the same way it swims, only faster.

***

## <Color id="gold">Flying</Color>

It is passive and works from any slot. Drive out of the water, or press Space on land to lift off, and the hull keeps going.

* It steers exactly as it does under water: the nose follows your view and pitches up or down, Space rises and C dives.
* In the air it moves about half again as fast as it does under water, and its top speed is half again as high.
* Land by diving onto the ground or back into the water.

If nobody is piloting, a flying hull sinks gently to the ground instead of dropping, so climbing out in mid-air does not wreck it. The hull never takes fall damage.

***

## <Color id="gold">Power</Color>

Holding the hull up costs 4 power per tick on top of its normal running costs, whenever it is in the air with someone aboard. If the cell runs dry in the air the hull falls like any other, so keep an eye on the readout on long flights.

The speed bonus and the upkeep are configurable (`submarineFlightSpeedMultiplier`, `submarineFlightPowerUsage`). One module is all you need, since a second one adds nothing.

***

### <Color id="aqua">Flight Module Recipe</Color>

<Recipe id="nautec:flight_module"/>
