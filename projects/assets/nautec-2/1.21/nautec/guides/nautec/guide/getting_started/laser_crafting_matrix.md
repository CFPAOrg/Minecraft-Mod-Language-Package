---
navigation:
  title: Laser Crafting Matrix
  icon: nautec:laser_crafting_matrix
  position: 2
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:laser_crafting_matrix
---

# <Color id="light_purple">Laser Crafting Matrix</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="laser_crafting_matrix" scale="2"/>
  Runs laser transformations inside a machine, so they can be automated.
</Column>

Every [Item Transformation](item_transformation.md) can also be done in the matrix, one craft at a time, with items and fluids going in and out through pipes instead of off the floor.

## <Color id="gold">Setting It Up</Color>

The matrix only takes a laser from the **top**. Point a relay or catalyst down onto it. Beams arriving at the sides or bottom are ignored.

Each recipe needs a beam of at least its AP and at least its purity. While either is short, the matrix waits and keeps its progress. A stronger beam than the recipe needs runs it faster, the same as the other machines (see [Stronger Beams](stronger_beams.md)).

Right-click it with an empty hand to open it.

* Three input slots on the left of the arrow and three output slots on the right.
* Two input tanks on the far left and two output tanks on the far right, each holding 16,000 mB (configurable).
* Each input slot holds a different item and each input tank a different fluid, so pipes never spread one item across every slot.
* Right-click with a filled bucket to fill an input tank, or with an empty bucket to take fluid out, output tanks first.
* Hoppers and pipes insert into the inputs and pull from the outputs. [Side Configuration](utilities.md) sets each face separately for items and fluids.

The panel shows the AP and purity the current recipe needs, green when the beam meets them and red when it does not. Hover over the arrow for the exact numbers. Jade shows the same, plus what the recipe makes and why the matrix is waiting.

The middle band spins and the lens pulses while it works.

***

## <Color id="gold">Recipes</Color>

JEI lists every recipe under Laser Crafting.

| Input | Output | AP | Purity | Time |
|---|---|---|---|---|
| Aquarine Steel Compound | Aquarine Steel Ingot | 10 | any | 1 s |
| Aquarine Steel Compound | 2 Aquarine Steel Ingots | 20 | 2.0 | 1 s |
| <ItemLink id="burnt_coil"/> | Laser Channeling Coil | 20 | 1.5 | 5 s |
| Prismarine Crystals | 2 <ItemLink id="prismarine_crystal_shard"/>s | 20 | 2.0 | 2 s |
| <ItemLink id="cast_iron_block"/> | 4 <ItemLink id="gear"/>s | 40 | 2.5 | 4 s |

When more than one recipe matches, the matrix uses the one with the highest purity the beam meets.

Modpacks and datapacks can add their own `nautec:laser_crafting` recipes with up to three item inputs, two fluid inputs, three item outputs and two fluid outputs.

<RecipeFor id="laser_crafting_matrix"/>
