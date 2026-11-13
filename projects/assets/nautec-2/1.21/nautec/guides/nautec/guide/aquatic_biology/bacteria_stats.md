---
navigation:
  title: Bacteria Stats
  icon: nautec:petri_dish
  position: 5
  parent: aquatic_biology/aquatic_biology-index.md
---

# <Color id="light_purple">Bacteria Stats</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="petri_dish" scale="2"/>
  Size, Vitality and four stats decide what a colony is worth.
</Column>

Each colony rolls its stats from its strain's starting range when it is grafted or mutated. After that the stats only change when the colony mutates or is refined in the [Mutator](mutator.md), and the new colony carries them forward with a small random shift. Growth Rate and Production Rate each move up or down by at most stat / (10 x (1 + Mutation Resistance)), so a colony with a Production Rate of 1 and no resistance ends up between 0.9 and 1.1, and higher resistance keeps it closer to the parent. Lifespan moves by up to 100 ticks, also less with higher resistance. Mutation Resistance itself never drops: each mutation adds a little to it, less the closer it is to the cap. Breeding a strong colony means a chain of mutations or refines. Growing, feeding and working a colony never changes its stats.

Analyze a dish in the [Bacterial Analyzer](bacterial_analyzer.md) to read them, then hold Shift over it.

***

## <Color id="gold">The Four Stats</Color>

| Stat | Cap | What it does |
|---|---|---|
| Growth Rate | 5 | Multiplies the size an [Incubator](incubator.md) cycle adds. |
| Mutation Resistance | 1 | Lowers the [Mutator](mutator.md)'s success chance by up to half, and cuts what a failed attempt costs down to nothing at the cap. Sets the purity of a [Bacterial Fuel Cell](bacterial_fuel_cell.md) beam. |
| Production Rate | 2 | Multiplies how fast a [Bio Reactor](bio_reactor.md) makes items. Sets a Fuel Cell's power and how fast it burns the colony. |
| Lifespan | 24,000 | The ticks a colony can work in a reactor without nutrients before it turns Senescent. |

All four caps are configurable. A stat shown in red in the tooltip is at its cap.

For a strain that makes something, the analyzed tooltip also shows Strain Yield. That belongs to the strain rather than the colony, so mutation never changes it, and it scales how fast the strain produces: 1 for stone, 0.12 for diamonds. [Production Rates](production_rates.md) lists every strain.

Every strain starts low: a Growth Rate between 0.4 and 1.2, a Production Rate between 0.08 and 0.7, a Mutation Resistance of 0.2 at most, and a Lifespan between 900 and 2,600 ticks, which is under a minute to just over two minutes of unfed reactor work. JEI's Bio Reactor category shows each strain's starting Production Rate range.

***

## <Color id="gold">Size</Color>

Size is how much colony you have. A grafted or mutated colony starts somewhere between 120 and 600 and can grow to the size cap of 40,000 (configurable) in the Incubator, which grows bigger colonies faster.

* In a reactor, a colony at the cap works twice as fast as a tiny one.
* In the Mutator, a bigger colony has a slightly lower success chance, up to a quarter lower at the cap, and the new colony's size does not depend on the old one.
* In the Fuel Cell, size is simply how long the colony lasts.

***

## <Color id="gold">Vitality</Color>

Vitality is the part of the Lifespan a colony has left. It only drops while the colony works in a powered reactor with no nutrients, by one tick of age per tick. A colony the reactor is feeding does not age, and neither does one paused because its output slot is full. Dishes, the Incubator, the Mutator and the Fuel Cell never age a colony. [Colony Feeding](colony_feeding.md) explains how a reactor feeds its colonies.

The tooltip shows it as a percentage: green from 50%, yellow from 20%, red below that. At 0% it reads Senescent. A senescent colony that runs out of nutrients in a reactor loses 2% of its size (at least 1) every second it works (configurable), so about half of it is gone after 35 seconds. Feeding it stops the loss but leaves it Senescent.

Every completed [Incubator](incubator.md) cycle sets Vitality back to 100%. A senescent colony still burns at full strength in a Fuel Cell.
