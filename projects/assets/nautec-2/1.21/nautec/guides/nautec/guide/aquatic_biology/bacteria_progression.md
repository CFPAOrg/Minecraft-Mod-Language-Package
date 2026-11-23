---
navigation:
  title: Bacteria Progression
  icon: nautec:bio_reactor
  position: 1
  parent: aquatic_biology/aquatic_biology-index.md
---

# <Color id="light_purple">Bacteria Progression</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="bio_reactor" scale="2"/>
  A route from your first colony to a wall of reactors, and the power each step needs.
</Column>

A colony pays off once it sits in a powered [Bio Reactor](bio_reactor.md) with its nutrient beside it: it then makes items for as long as the power lasts, without aging. Everything else on these pages is about getting a good colony there and keeping more of them running.

This page lists what to build in order, what each machine needs before you can craft it, and how to power it at each stage. [Strain Tree](strain_tree.md) shows which mutations lead to which strains.

***

## <Color id="gold">Before You Start</Color>

The biology machines need three things from the rest of the mod:

* **Salt Water.** The [Mutator](mutator.md) is crafted with a bucket of Electrolyte Algae Serum, which the [Mixer](nautec:laser_chemistry/mixer.md) makes from Salt Water. A [Deep Sea Drain](nautec:laser_chemistry/drain.md) is the steady source.
* **A beam of purity 1.5.** The Laser Channeling Coil inside the Incubator, Bio Reactor and Fuel Cell is made by [Item Transformation](nautec:getting_started/item_transformation.md) at purity 1.5. An <ItemLink id="aquatic_catalyst"/> burning <ItemLink id="prismarine_crystal_shard"/> gives 1.2, and each <ItemLink id="budding_prismarine"/> touching it adds 0.1, so three of them reach 1.5.
* **Aquarine Steel**, for the Analyzer, the shields and the lenses.

***

## <Color id="gold">Power at a Glance</Color>

Every number here is a minimum. Below it a machine waits, and above it most machines run faster ([Stronger Beams](nautec:getting_started/stronger_beams.md)).

| Machine | Needs | Beam goes into |
|---|---|---|
| [Bacterial Analyzer](bacterial_analyzer.md) | 5 AP | the bottom face |
| [Mutator](mutator.md) | 10 AP | the top or bottom face |
| [Incubator](incubator.md) | 20 AP | the top or bottom face, and both add up |
| [Bio Reactor](bio_reactor.md) | 20 AP for 1 colony, 50 AP for 3 | hatches in its top layer |
| [Advanced Bacterial Analyzer](bacterial_analyzer.md) | 40 AP at purity 2.1 | any face but the front |
| [Colony Replicator](colony_replicator.md) | 80 AP at purity 2.0 | any face but the front |
| [Grafting Station](bacteria_grafting.md) | 100 AP at purity 2.8 | any face but the front |
| [Industrial Bio Reactor](industrial_bio_reactor.md) | 150 AP for 1 colony, 550 AP for 9 | roof hatches |

[Reactor Upgrades](reactor_upgrades.md) multiply a reactor's figure.

One Aquatic Catalyst on Prismarine Shards gives 12 AP and burns two shards a minute. Each Budding Prismarine touching it adds 25%, so a catalyst with one gives 15 AP. That covers every early machine: a Bio Reactor runs one colony on two catalysts, two colonies on three, and all three on four catalysts with a Budding Prismarine each. A line of catalysts eats a lot of shards, so moving the reactor onto an [Energy Converter](nautec:laser_chemistry/energy_converter.md) early saves a lot of prismarine.

***

## <Color id="gold">Stage 1: A First Colony</Color>

**Build:** Petri Dishes, a Grafting Tool, a Bacterial Analyzer and one catalyst under it.

Take a stack of empty dishes and graft. The best first grafts:

* **Lithophiles** from <ItemLink id="budding_prismarine"/> in a Warm Ocean, Deep Lukewarm Ocean or the deep ocean biomes (30%). Every metal and gem strain descends from it, and grafting it skips a mutation.
* **Halobacteria** from Sand on any beach (40%). Kelp in the Mutator turns it into Halotrophs at 75%, the easiest first mutation, and Halotrophs lead to Lipophiles, which make the lipids for [Combustion Dynamo](nautec:getting_started/combustion_dynamo.md) oil.
* The deep ocean strains are ready to work as soon as you have them: Halotrophs (kelp), Algaeformers (seagrass), Phototrophs (sugar cane), Calciophiles (bone meal) and Sulfurophiles (gunpowder). See [Bacteria Grafting](bacteria_grafting.md) for where.

Cyanobacteria, Halobacteria, Methanogens and Thermophiles make nothing. They only exist to be mutated.

Analyze each colony to see its stats. You do not have to: every machine works on unanalyzed colonies too. Analysis tells you which one to keep.

***

## <Color id="gold">Stage 2: A Working Line</Color>

**Build, in this order:** the Mutator, then the Bio Reactor, then the Incubator.

**1. Mutate to the strain you want.** Put a small, fresh colony and the catalyst in the Mutator. Do not grow it first: a bigger colony mutates slightly less often, and the new colony starts at its own size whatever the parent was. Put an Electrolyte Algae Serum Vial in the booster slot whenever you can. It triples the chance and stops failures shrinking the colony, and it is only used up on a success. Most early steps are 15%: about 7 tries without a vial and 2 or 3 with one.

**2. Put it to work.** Load the colony into the Bio Reactor and put its nutrient in a nutrient slot. JEI's Colony Feeding category, or hovering the empty nutrient slot, shows what it eats. A fed colony never ages, so it never needs to leave. Many metal strains eat the item they make, so a reactor can feed itself from its own output.

**3. Grow it, if you want.** The Incubator doubles a colony's speed at most: a colony at the size cap works twice as fast as a tiny one. It is worth building, but a fresh colony in a fed reactor is already making items, so it can wait until the line runs. Its other job is reviving a colony that went Senescent.

A fresh colony is slow but useful: a new Ferrophiles colony makes about 24 iron ingots a minute and eats one iron ingot a minute.

**Powering this stage:**

* Analyzer and Mutator: one catalyst each.
* Incubator: one catalyst above and one below.
* Bio Reactor: one catalyst per hatch, two for one colony and three for two. Three colonies need 50 AP: four catalysts with a Budding Prismarine each, or a [Laser Junction](nautec:laser_chemistry/laser_manipulation.md) merging several catalysts into one hatch.

***

## <Color id="gold">Stage 3: Scaling Up</Color>

**Switch to FE power.** An [Energy Converter](nautec:laser_chemistry/energy_converter.md) turns 10 FE into 1 AP and sends up to 150 AP a tick. It fires out of every side that has a receiver in line and splits the AP between them, so one converter between a Mutator and an Incubator powers both. Good sources, in the order you reach them:

| Generator | FE per tick | AP through a converter |
|---|---|---|
| Tidal Rotor | 40 to 80 | 4 to 8 each |
| Combustion Dynamo on Lipophiles oil | 320 | 32 |
| Thermal Vent Tap | 350 to 1,250 | 35 to 125 |

See [Ocean Generators](nautec:getting_started/ocean_generators.md).

**Breed better stats.** A colony's stats only change through the Mutator. To improve a colony without changing its strain, use the storage block of the item it makes as the catalyst (an Iron Block for Ferrophiles). That refines it: 25% base chance, same strain, stats shifted a little. Keep the better results and refine those again. Breed Production Rate first for reactor colonies. [Bacteria Stats](bacteria_stats.md) explains each stat.

**Upgrade the reactor.** [Reactor Upgrades](reactor_upgrades.md) are made from Aquatic Chips, Deep Steel Plating, Resonant Shards and Flawless Prismarine Crystals. For output per AP, a Yield Upgrade beats a Speed Upgrade.

**Use old colonies for power.** A [Bacterial Fuel Cell](bacterial_fuel_cell.md) burns any colony, senescent or not, into a beam of up to 48 AP. A colony with high Mutation Resistance gives a pure beam: 0.8 resistance gives purity 2.0.

**Keep colonies sorted** in [Dish Storage](dish_storage.md), which never merges or mixes dishes.

**Feed the Mutator a stronger beam.** 40 AP gives it twice as many tries a minute as 10 AP.

***

## <Color id="gold">Stage 4: Late Game</Color>

A [Prismarine Crystal](nautec:getting_started/laser_power.md) beam (purity 3.0) unlocks the high purity biology machines:

* **[Grafting Station](bacteria_grafting.md):** grafts without the tool or the biome, every cycle a sure success. With a Grafting Anchor fitted, one block grafts forever. This is where fodder colonies come from.
* **[Colony Replicator](colony_replicator.md):** copies your best colony using colonies of the same strain, or the item it makes, as biomass. Breed one great colony, then fill a reactor with copies. Breed Mutation Resistance up first if you want the copies to be exact.
* **[Advanced Bacterial Analyzer](bacterial_analyzer.md):** nine dishes at once.
* **[Industrial Bio Reactor](industrial_bio_reactor.md):** nine colonies and four upgrade slots. Power it with several Energy Converters on its roof hatches.

Every one of these machines has a Dish Port, so pipes can carry dishes through the whole line: Grafting Station to Analyzer to Replicator to reactor. Once a reactor is full, a new colony arriving at its port takes the place of its oldest Senescent colony, which comes back out in the same dish.

***

## <Color id="gold">Common Mistakes</Color>

* **A reactor below its power.** Nothing runs and all progress resets. Hover the progress arrow to see the power arriving against the power needed.
* **A "!" on a reactor colony.** Its nutrient is missing or it has gone Senescent. Hover it to see which.
* **No nutrient in the reactor.** A fresh colony has between 45 seconds and two minutes of Lifespan, then turns Senescent and starts shrinking. One stack of its nutrient prevents this.
* **More nutrient types than nutrient slots.** A Bio Reactor feeds at most two different nutrients and the Industrial Bio Reactor three. Fill a reactor with strains that share them.
* **A full output slot.** That colony pauses until there is room, so pipe the output away.
* **Growing a colony before mutating it.** It only lowers the chance and gives failures more to eat.
* **A base strain in a reactor.** Cyanobacteria, Halobacteria, Methanogens and Thermophiles make nothing.
* **Empty dishes in a reactor's Dish Port.** An empty dish takes a colony out.
