---
navigation:
  title: Incubator
  icon: nautec:incubator
  position: 7
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:incubator
---

# <Color id="light_purple">Incubator</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="incubator" scale="2"/>
  The Incubator grows a colony and restores its Vitality.
</Column>

Put the colony in the bacteria slot and its nutrient in the item slot. Each strain has its own nutrient, listed in JEI's Bacteria Incubation category along with its growth range and consume chance. Hover the empty nutrient slot with a colony loaded to see what it grows on, and hover the progress arrow to see what the Incubator is waiting for. The Incubator only starts when the nutrient matches the strain. The item slot holds one nutrient at a time.

Every strain that has a nutrient also takes the item it makes and that item's storage block. Ferrophiles, for example, take iron ore, Iron Ingots or Iron Blocks. The item it makes has one and a half times the consume chance of the strain's own nutrient, and a storage block a ninth of that, so one block lasts as long as nine of the item. See [Colony Feeding](colony_feeding.md) for how the block is found.

Cyanobacteria, Halobacteria, Methanogens and Thermophiles have no nutrient. [Mutate](mutator.md) them first.

***

## <Color id="gold">Each Cycle</Color>

A cycle takes 5 seconds. At the end of it:

* The colony grows by a roll from the recipe's growth range plus 3% of its current size, all multiplied by its Growth Rate. A bigger colony grows faster.
* The nutrient has the recipe's consume chance of being used up. Growth happens either way.
* The colony's age resets, so its Vitality is back to 100%.

Lithophiles on stone, for example, rolls 8 to 25 per cycle with a 5% consume chance. A colony of 400 with a Growth Rate of 1 gains about 28 in its first cycle, and one of 10,000 gains about 316. Growing from 400 to the size cap takes around 150 cycles, about 13 minutes on a 20 AP beam, and eats about one stone every 20 cycles. At Growth Rate 2 it takes about half as long.

Growth stops exactly at the size cap of 40,000 (configurable). A colony at the cap still runs: each cycle leaves its size at the cap and resets its age.

***

## <Color id="gold">Power</Color>

It needs a beam of at least 20 AP entering its top or bottom face, and beams into both faces add together. One <ItemLink id="aquatic_catalyst"/> burning <ItemLink id="prismarine_crystal_shard"/>s gives exactly 20 AP. On Prismarine Shards it gives 12, so run one above and one below, or combine beams in a <ItemLink id="laser_junction"/> first. The cycle time (100 ticks) and the power are configurable.

***

## <Color id="gold">Incubator or Reactor</Color>

You do not need to carry a working colony back here. A [Bio Reactor](bio_reactor.md) keeps its colonies from aging by feeding them from its nutrient slots, and by default each strain eats the same nutrient there as it does in the Incubator. [Colony Feeding](colony_feeding.md) covers it.

The Incubator is still the place to grow a colony, and the only way to reset its age. A colony that went Senescent before you started feeding it stays Senescent in a reactor, and one completed cycle here brings its Vitality back to 100%.

Hoppers and pipes can insert the nutrient, so a chest feeding the Incubator keeps a long growing run going. Every face allows it by default; [Side Configuration](nautec:getting_started/utilities.md) changes that.

The two slots at the bottom left are the Dish Port: a dish goes in on the left and dishes holding a colony come out on the right. A Petri Dish holding a colony loads its colony, as long as the bacteria slot is empty or holds the same strain with exactly the same stats and room to spare, and the strain is one the Incubator can grow. A colony already at the size cap only goes in if it has aged, since a fresh one has nothing left to gain. The emptied dish stays in the port, and once the colony reaches the size cap it takes the colony back out and moves it to the output slot, which frees the port for the next one. The port only accepts a dish it can use right then, so a pipe or hopper keeps hold of anything else instead of jamming the machine.

***

## <Color id="gold">Recipe</Color>

<Recipe id="nautec:incubator"/>

***

## <Color id="gold">Stronger Beams</Color>

The Incubator needs 20 AP. A stronger beam runs its growth cycles faster: its speed is the square root of (beam ÷ 20).

| Beam | Speed |
|---|---|
| 20 AP | ×1 (normal) |
| 80 AP | ×2 |
| 180 AP | ×3 |
| 320 AP | ×4 |

Every cycle still has its own chance to eat a nutrient, so a faster Incubator grows the colony and goes through nutrient at the same higher rate. The 5 second cycle is on a 20 AP beam.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.
