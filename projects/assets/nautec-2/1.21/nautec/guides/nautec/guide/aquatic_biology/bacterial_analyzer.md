---
navigation:
  title: Bacterial Analyzer
  icon: nautec:bacterial_analyzer
  position: 4
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:bacterial_analyzer
  - nautec:advanced_bacterial_analyzer
---

# <Color id="light_purple">Bacterial Analyzer</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="bacterial_analyzer" scale="2"/>
  The Bacterial Analyzer reveals a colony's size, Vitality and stats.
</Column>

Put a <ItemLink id="petri_dish"/> holding an unanalyzed colony in the left slot. After 3 seconds the analyzed dish moves to the right slot. Empty the right slot before the next dish can start. The left slot only takes dishes holding an unanalyzed colony, so a pipe never clogs it with empty or finished dishes.

The machines all work on unanalyzed colonies too. Analysis only lets you read the numbers, but you need those numbers to choose which colony to mutate, grow or burn. A colony that comes out of the [Mutator](mutator.md) is unanalyzed again.

***

## <Color id="gold">Setup</Color>

The Analyzer is two blocks tall, so it needs a free block above it when you place it. Right-click either half to open it.

It needs a beam of at least 5 AP entering its bottom face from below. The power is a threshold, not a cost: below 5 AP it pauses, at 5 AP it runs at normal speed, and a stronger beam runs it faster (see below).

Both the time (60 ticks) and the power (5 AP) are configurable.

Hoppers and pipes can feed dishes into the lower block and pull analyzed dishes out, through any face by default. [Side Configuration](nautec:getting_started/utilities.md) changes what each face allows.

***

## <Color id="gold">Reading an Analyzed Dish</Color>

The tooltip shows Size, Vitality and, for a strain that makes something, its Strain Yield. Hold Shift to see the item the strain produces and its four stats. Hold Shift and Control together to also see the range each stat can move to when the colony next mutates. Shift also lists what the strain eats in a reactor, what it grows on in the Incubator, and the strains it can mutate into, with each catalyst and chance. A stat shown in red is at its cap. [Bacteria Stats](bacteria_stats.md) explains each one.

***

## <Color id="gold">Recipe</Color>

<Recipe id="nautec:bacterial_analyzer"/>

***

## <Color id="gold">Advanced Bacterial Analyzer</Color>

<Row>
  <ItemImage id="advanced_bacterial_analyzer" scale="2"/>
</Row>

Analyzes nine dishes at once. It has nine input slots and nine output slots, and every dish in the inputs works through its own 60 tick analysis at the same time, so a full load finishes as fast as a single dish does in the basic Analyzer. Each input slot fills from the bottom as its dish progresses.

* Power: a beam of at least 40 AP at purity 2.1 or higher, into any face except the front. Below either, it pauses and keeps its progress. A [Prismarine Crystal](nautec:getting_started/laser_power.md) beam (3.0) or a full purity <ItemLink id="bacterial_fuel_cell"/> (2.5) covers the purity.
* Only dishes holding an unanalyzed colony go in, so a pipe feeding it never clogs it with finished or empty dishes.
* When all nine output slots are full, finished dishes wait in their input slot until one frees up.

Hover over the arrow to see what it is waiting for, or look at it through a <ItemLink id="prism_monocle"/>. Hoppers and pipes can feed it and empty it through any face by default ([Side Configuration](nautec:getting_started/utilities.md)). Its time, power and purity are in `config/nautec-common.toml`.

<Recipe id="nautec:advanced_bacterial_analyzer"/>

***

## <Color id="gold">Stronger Beams</Color>

Both analyzers run faster on a beam stronger than they need: speed is the square root of (beam ÷ what it needs). The Bacterial Analyzer needs 5 AP, so 20 AP analyzes twice as fast. The Advanced Bacterial Analyzer needs 40 AP at purity 2.1, so 160 AP at that purity analyzes all nine dishes twice as fast. Purity never speeds either of them up.

| Beam, as a multiple of what it needs | Speed |
|---|---|
| 1× | ×1 (normal) |
| 4× | ×2 |
| 9× | ×3 |
| 16× | ×4 |

The Bacterial Analyzer's 3 seconds per dish is on a 5 AP beam.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.
