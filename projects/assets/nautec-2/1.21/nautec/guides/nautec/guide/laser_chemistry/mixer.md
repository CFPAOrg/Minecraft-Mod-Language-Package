---
navigation:
  title: Mixer
  icon: nautec:mixer
  position: 4
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:mixer
---

# <Color id="light_purple">Mixer</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="mixer" scale="2"/>
  Mixes items into Salt Water to make chemicals, Aquarine Steel Compound and machine parts.
</Column>

## <Color id="gold">Setting It Up</Color>

The Mixer takes a laser beam into any face and runs while at least 10 AP per tick arrives (configurable). One <ItemLink id="aquatic_catalyst"/> burning Prismarine Shards or Prismarine Crystal Shards is enough. One burning Prismarine Crystals is not; add a second source through a [Laser Junction](laser_manipulation.md).

Right-click it with an empty hand to open it. It has four ingredient slots, one output slot, an input tank and an output tank, each tank holding 64,000 mB (64 buckets, configurable).

* Right-click with a <ItemLink id="saltwater_bucket"/> to fill the input tank. Salt Water comes from the [Deep Sea Drain](drain.md), or from the Mixer itself with a Water Bucket and Salt.
* Right-click with an empty Bucket to take fluid out of the output tank.
* Hoppers and pipes can insert ingredients, fill the input tank and drain the output tank.
* Item results can be pulled out of the output slot.
* Every face does all of this by default. [Side Configuration](nautec:getting_started/utilities.md) sets each face separately for items and fluids.

The whisk spins while it works. The <ItemLink id="prism_monocle"/> shows the power arriving, and Jade also shows its tanks, mixing progress and how many crafts it runs at once.

***

## <Color id="gold">Recipes</Color>

JEI lists the ingredients under Mixing.

| Result | Fluid used | Time |
|---|---|---|
| 1,000 mB Salt Water | 1,000 mB Water and 1 <ItemLink id="salt"/> | 5 seconds |
| 1,000 mB Electrolyte Algae Serum | 1,000 mB Salt Water | 10 seconds |
| 1,000 mB Etching Acid | 1,000 mB Salt Water | 7.5 seconds |
| 5 Aquarine Steel Compound | 1,000 mB Salt Water | 5 seconds |
| 1 <ItemLink id="burnt_coil"/> | 1,000 mB Salt Water | 10 seconds |
| 2 <ItemLink id="aquatic_chip"/>s | 1,000 mB Salt Water | 10 seconds |
| 1 <ItemLink id="pressure_synthesizer"/> | 8,000 mB Salt Water | 20 seconds |
| 1 <ItemLink id="atlantean_pressure_synthesizer"/> | 8,000 mB Salt Water | 30 seconds |

A recipe only starts when its result fits in the output, so empty the output tank or slot between batches. Losing power pauses a mix without resetting it.

<Color id="gold">Tip</Color>: while the output tank holds fluid, right-clicking with a bucket works on the output tank, so a Salt Water Bucket will not go in. Empty the output first.

See [Chemistry Fluids](chemistry_introduction.md) for what each fluid is for.

***

### <Color id="aqua">Mixer Recipe</Color>

The <ItemLink id="whisk"/> is repaired from a Broken Whisk, or crafted from Cast Iron Rods, a Prismarine Crystal Shard and an Aquarine Steel Ingot.

***

## <Color id="gold">Stronger Beams</Color>

The Mixer needs 10 AP. A stronger beam first runs more crafts at once: every 10 AP adds one craft per cycle, up to 64 (configurable). When a cycle ends it makes as many as its ingredients, its input tank and the room in its output allow, so 640 AP with a stack of Salt and 64,000 mB of Water makes 64,000 mB of Salt Water in one 5 second cycle.

Past 64 crafts, more AP speeds the cycle up instead: its speed is the square root of (beam ÷ (crafts × 10)). Below 640 AP a beam between two steps of 10 gives only a small speed-up.

| Beam | Crafts per cycle | Speed |
|---|---|---|
| 10 AP | 1 | ×1 (normal) |
| 40 AP | 4 | ×1 |
| 640 AP | 64 | ×1 |
| 2,560 AP | 64 | ×2 |
| 5,760 AP | 64 | ×3 |
| 10,240 AP | 64 | ×4 |

The times in the recipe table are for one cycle at ×1.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.

<RecipeFor id="mixer"/>
