---
navigation:
  title: Item Transformation
  icon: nautec:aquarine_steel_ingot
  position: 2
  parent: getting_started/getting_started-index.md
---

# <Color id="light_purple">Item Transformation</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="aquarine_steel_ingot" scale="2"/>
  A powered laser beam turns items dropped into it into something else.
</Column>

Drop an item so it lies inside a powered beam, anywhere between the sending block and the receiver. If a transformation recipe matches the item and the beam's purity is high enough, the item changes after the recipe time. Nothing needs clicking, and the whole dropped stack changes at once, with each input item giving the recipe's full output: 3 Prismarine Crystals give 6 Prismarine Crystal Shards.

The item has to stay in the beam for the full time. If it is pushed out, or the beam loses power even for a moment, it starts over.

***

## <Color id="gold">Recipes</Color>

| Input | Output | Purity needed | Time |
|---|---|---|---|
| Aquarine Steel Compound | Aquarine Steel Ingot | any | 5 s |
| Aquarine Steel Compound | 2 Aquarine Steel Ingots | 2.0 | 4 s |
| <ItemLink id="burnt_coil"/> | Laser Channeling Coil | 1.5 | 10 s |
| Prismarine Crystals | 2 <ItemLink id="prismarine_crystal_shard"/>s | 2.0 | 8 s |
| <ItemLink id="cast_iron_block"/> | 4 <ItemLink id="gear"/>s | 2.5 | 8 s |

When more than one recipe matches, the beam uses the one with the highest purity it meets, so a beam of 2.0 or more turns each compound into 2 ingots.

JEI lists every transformation, including ones added by other mods or datapacks, under Item Transformation.

To automate these, the [Laser Crafting Matrix](laser_crafting_matrix.md) does every transformation on this page inside a machine, fed by pipes.

***

## <Color id="gold">Aquarine Steel</Color>

Aquarine Steel is the first thing to make. Its compound needs no purity, so any running <ItemLink id="aquatic_catalyst"/> beam will do: point the catalyst at a receiver such as a <ItemLink id="prismarine_laser_relay"/> and drop the compound on the floor under the beam.

<Recipe id="nautec:aquarine_steel_compound"/>

The [Mixer](nautec:laser_chemistry/mixer.md) makes the compound in bulk later on.

***

## <Color id="gold">Higher Purity</Color>

The Laser Channeling Coil and Prismarine Crystal Shards need more purity than a catalyst's 1.2. Use one of these:

* A <ItemLink id="prismarine_crystal"/>, purity 3.0. See the setup below.
* A <ItemLink id="bacterial_fuel_cell"/>, up to 2.5 depending on its colony.
* A <ItemLink id="focusing_lens"/> in the beam's path, which adds 0.5 to the beam passing straight through it, up to 2.0 (`lensPurityBonus`).
* <ItemLink id="budding_prismarine"/> touching the catalyst, which adds 0.1 per block, up to 2.0. See [Laser Power](laser_power.md).

An item is judged by the purity of the beam it lies in. In a beam leaving a lens, that is the purity after the lens has raised it. A catalyst on Prismarine Crystal Shards firing through one lens gives 1.7 in the lens's outgoing beam, enough for the coil.

***

## <Color id="gold">Under a Prismarine Crystal</Color>

Every Crystal Geode (see [Structures](structures.md)) has a Prismarine Crystal standing over an open gap (one block in a stone geode, two in a deepslate geode), which is the setup this needs.

* Place an Aquatic Catalyst level with any block of the crystal, facing it from the side. Keep it within 16 blocks with nothing solid in between.
* Load the catalyst with any fuel. The crystal's bottom block now fires a purity 3.0 beam straight down into the floor.
* Drop your items into the gap under the crystal so they lie on the floor inside that beam.

Keep the catalyst fed. When it runs dry the crystal's beams stop and every item in them starts over.

<Color id="gold">Tip</Color>: beams burn anything standing in them. Drop items in from the side instead of stepping under the crystal.
