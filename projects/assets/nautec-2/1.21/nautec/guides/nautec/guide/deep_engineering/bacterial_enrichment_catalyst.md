---
navigation:
  title: Bacterial Enrichment Catalyst
  icon: nautec:bacterial_enrichment_catalyst
  position: 17
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:bacterial_enrichment_catalyst
---

# <Color id="light_purple">Bacterial Enrichment Catalyst</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="bacterial_enrichment_catalyst" scale="2"/>
  Raises the purity of a Cultivated Prismarine Crystal past the 6.00 it can roll, up to 12.
</Column>

A crystal rolls a purity between 3.00 and 6.00 when it grows in a [Crystal Cradle](crystal_cultivation.md). The Catalyst raises it further a little at a time. It works in cycles, and each cycle spends beam power from a second crystal and some of a Prismatophiles colony.

***

## <Color id="gold">The Layout</Color>

Two crystals take part. The **target** is the one you want to improve. The **source** is a second crystal whose purity sets how far the target can be pushed.

<GameScene zoom="4" background="#333333" interactive={true}>
  <ImportStructure src="bacterial_enrichment_catalyst.nbt" />
  <IsometricCamera yaw="225" pitch="30" />
  <BoxAnnotation min="0.97 0.97 0.97" max="2.03 7.03 2.03" color="#ff6ec7" thickness="0.06" alwaysOnTop={true}>
    **Target crystal.** A Cultivated Prismarine Crystal of purity 4.0 or more, six blocks tall.
  </BoxAnnotation>
  <BoxAnnotation min="1.97 1.97 0.97" max="3.03 8.03 2.03" color="#52e8ff" thickness="0.06" alwaysOnTop={true}>
    **Source crystal.** Stands in the Catalyst's own column, directly above it. Its bottom tip fires down into the Catalyst.
  </BoxAnnotation>
  <BoxAnnotation min="1.97 0.97 0.97" max="3.03 2.03 2.03" color="#ffd86b" thickness="0.06" alwaysOnTop={true}>
    **Bacterial Enrichment Catalyst.** Against the target crystal with its back to it, directly under the source crystal.
  </BoxAnnotation>
  <BoxAnnotation min="0.97 -0.03 0.97" max="2.03 1.03 2.03" color="#9aa5b1" thickness="0.06" alwaysOnTop={true}>
    **Crystal Cradle.** Only here because this crystal was grown in place. A crystal you moved with a wrench does not need one.
  </BoxAnnotation>
  <BoxAnnotation min="2.97 3.97 0.97" max="4.03 5.03 2.03" color="#52e8ff" thickness="0.06" alwaysOnTop={true}>
    **Laser.** Aimed into the side of the source crystal.
  </BoxAnnotation>
  <BoxAnnotation min="1.97 3.97 1.97" max="3.03 5.03 3.03" color="#52e8ff" thickness="0.06" alwaysOnTop={true}>
    **Laser.** Aimed into the side of the source crystal.
  </BoxAnnotation>
</GameScene>

The colored boxes mark where the two crystals stand. Hover a box to see what it is, and drag the scene to turn it.

1. Stand a Cultivated Prismarine Crystal with purity 4.0 or more. This is the target.
2. Place the <ItemLink id="bacterial_enrichment_catalyst"/> against any side of the target's column, with its back to the crystal.
3. Stand the source crystal in the Catalyst's own column, directly above or below it, so the crystal's tip fires straight into the Catalyst's top or bottom. The Catalyst takes a beam from nothing else: not from lasers, relays, lenses, nodes or the target's own tip.
4. Aim your lasers into the sides of the source crystal. A crystal passes on all the power it receives at its own purity, so the source's purity is what counts and the total AP from all your lasers sets the speed.
5. Load a <ItemLink id="petri_dish"/> of Prismatophiles. A full dish loads the colony, and putting an empty dish in takes the colony back out.
6. Open the Catalyst and set a target purity. A redstone signal pauses it.

Only one Catalyst works on a crystal at a time. The Catalyst needs at least **500 AP** from the source crystal.

***

## <Color id="gold">Cycles and Cost</Color>

The Catalyst works in cycles. A cycle costs 1,000,000 AP for a crystal at purity 6, and the cost doubles for each whole point of purity. All of a beam's power counts every tick, so doubling the beam halves the time.

| Crystal purity | AP per cycle | Colony per cycle | Time at 1,000 AP/t |
|---|---|---|---|
| 4 | 250,000 | about 50 | 12.5 seconds |
| 6 | 1,000,000 | 100 | 50 seconds |
| 8 | 4,000,000 | about 200 | 3 minutes 20 seconds |
| 10 | 16,000,000 | about 400 | 13 minutes |
| 12 | 64,000,000 | about 800 | 53 minutes |

At the end of a cycle the crystal either gains **0.10 purity** or regresses by **0.20**. Regression never takes a crystal below 4.0. The crystal keeps firing its beams while it is being enriched, and it keeps its purity when you move it with a wrench.

***

## <Color id="gold">Risk and Laddering Up</Color>

The chance of regression depends on how far the target's purity is above the source's:

| Target against source | Regression chance |
|---|---|
| Source purer by 1.0 or more | 2% |
| Equal | 10% |
| Target 1.5 above the source | 30% |

At 1.5 above the source the Catalyst stops, so a 6.0 source can take a crystal to 7.5. That crystal can then be the source for the next one, up to 9.0, and so on. Two crystals can also take turns raising each other.

A purer source is safer and uses less colony (see The Colony below). Check a crystal's purity on its item tooltip or with a <ItemLink id="prism_monocle"/>.

***

## <Color id="gold">Target Purity and Pausing</Color>

Set the target purity in the Catalyst's screen. When the crystal reaches it, the Catalyst stops until you raise the target. A crystal cannot go past 12. A redstone signal pauses the Catalyst, and it keeps its progress and carries on when the signal stops.

A crystal cannot be enriched while it is inside a formed [Fusion Plant](fusion_plant.md). Enrich it outside, pick it up with a wrench and place it as the heart.

***

## <Color id="gold">The Colony</Color>

The Catalyst runs on **Prismatophiles**. You make them in the [Mutator](nautec:aquatic_biology/mutator.md) from Smaragdophiles (the emerald strain) with an <ItemLink id="atlantic_gold_ingot"/> as the catalyst, at a 5% chance. They produce nothing in a Bio Reactor. Grow and feed them in the [Incubator](nautec:aquatic_biology/incubator.md) on <ItemLink id="prismarine_crystal_shard"/>s, and refine their stats in the Mutator on a Prismarine Crystal Shard (25% base chance). See the [Strain Tree](nautec:aquatic_biology/strain_tree.md).

Each cycle uses colony: 100 at purity 6, growing by about 1.41 times per point of purity (about 800 near purity 12). When the target is above the source, the cost goes up by the base amount again for each point of the gap, so it is twice as much at 1.0 above. A colony at the Mutation Resistance cap pays half. The colony has to be at least one cycle's cost or the Catalyst waits.

***

## <Color id="gold">When It Stops</Color>

The top line of the screen shows the first problem the Catalyst finds, in this order.

| Status | What to do |
|---|---|
| No crystal | Nothing is behind the Catalyst. Put a cultivated crystal against its back. |
| Wild crystal | Wild crystals cannot be enriched. Grow one in a Crystal Cradle. |
| Crystal in use | Another Catalyst already has this crystal. Remove one of them. |
| Crystal too impure | The crystal is below purity 4.0. Use one that rolled 4.0 or more. |
| Maximum purity | The crystal is at 12 and cannot go any higher. |
| Target reached | Raise the target purity in the screen. |
| Paused | Turn the redstone signal off. |
| No source beam | Put a crystal in the Catalyst's column and aim lasers into its sides. |
| Beam too weak | It needs 500 AP. Add power to the lasers feeding the source crystal. |
| Source too weak | The crystal is 1.5 or more above the source. Use a purer source crystal. |
| No colony | Load a Petri Dish of Prismatophiles. |
| Colony too small | The colony is smaller than one cycle's cost. Regrow it, or use a purer source to cut the cost. |
| Enriching | Nothing, it is running. The number is the progress of the current cycle. |

***

## <Color id="gold">What Purity Gives You</Color>

* [Crystal Cultivator](nautec:laser_chemistry/crystal_cultivator.md): one Fortune level per purity point through 6, then Fortune VIII at purity 9 and Fortune IX at 12.
* [Laser Purification Smelter](laser_purification_smelter.md): a cheaper smelt.
* [Resonance Chamber](resonance_chamber.md): a higher ceiling.
* [Fusion Plant](fusion_plant.md): more FE per AP from injector beams above purity 3.0, and a higher output ceiling from the heart's own purity.

***

## <Color id="gold">Crafting</Color>

<RecipeFor id="bacterial_enrichment_catalyst"/>

The AP, purity, risk and colony numbers are the `enrichment` settings in `config/nautec-common.toml`.
