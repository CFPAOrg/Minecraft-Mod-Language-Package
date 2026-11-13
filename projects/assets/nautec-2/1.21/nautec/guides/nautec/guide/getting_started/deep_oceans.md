---
navigation:
  title: The Deep Oceans
  icon: nautec:luminescent_algae
  position: 11
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:hydrothermal_vent
---

# <Color id="light_purple">The Deep Oceans</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="luminescent_algae" scale="2"/>
  NauTec adds four ocean biomes, each with its own plants and creatures.
</Column>

The four biomes are added alongside the vanilla oceans rather than replacing them. They only generate in chunks that have not been generated yet, so in an existing world you find them past the edge of explored ground.

All four count as oceans. The [Deep Sea Drain](nautec:laser_chemistry/drain.md), lucky fishing zones, NauTec structures, vanilla ocean ruins and shipwrecks all work in them, and so does bucket Salt Water collection when a pack turns on `collectSaltWater` in `config/nautec-common.toml`.

NauTec also makes oceans deeper than vanilla. With Tectonic installed, Tectonic decides ocean depth instead.

| Biome | Where | Visibility |
|---|---|---|
| Abyssal Trench | farthest from land, cold climates | about 20 blocks |
| Bioluminescent Grove | deep ocean, temperate climates | about 130 blocks |
| Hydrothermal Vents | deep ocean, warm climates | about 50 blocks |
| Prismarine Reef | shallow water off the coast, temperate to hot climates | about 145 blocks |

***

## <Color id="gold">Abyssal Trench</Color>

The deepest and darkest of the four, with near-black water and drifting motes.

* Drowned spawn far more often than in other oceans, and the Abyssal Maw hunts in the dark below y 40.
* Abyssal Coral grows on the floor. Silt Skippers, cod, squid and glow squid swim here.
* <ItemLink id="budding_prismarine"/> forms in the top of the sea floor. Look for its faint glow.
* The best place for the [Abyssal Pressure Forge](nautec:deep_engineering/pressure_forge.md), which needs depth and a column of water above it.

***

## <Color id="gold">Bioluminescent Grove</Color>

Clear teal water with glowing spores drifting through it.

* Deep Kelp, Luminescent Algae, seagrass and sea pickles on the floor, and Glow Polyp spreading over stone on floors, walls and ceilings.
* Lantern Jellies, Silt Skippers and extra glow squid.
* Budding Prismarine forms in the top of the sea floor, as in the Trench.

### Glow Grottos

Flooded caves hollowed out under the grove floor, reached by a narrow shaft down from the sea bed. Glow Polyp covers the walls and Luminescent Algae and sea pickles light the floor, so they are bright enough to find from the shaft.

* Each grotto holds one <ItemLink id="budding_prismarine"/> in its floor, often with Prismarine Clusters already grown.
* About one in three has a <ItemLink id="rusty_crate"/> on the floor with salvage inside.
* They never open into dry caves, so a grotto is always full of water.

***

## <Color id="gold">Hydrothermal Vents</Color>

Murky brown water over a floor patched with basalt and magma, with bubbles rising all the time.

* Vent Tubeworms grow on the floor.
* Vent Crawlers walk the floor and drop Chitin Plate.
* Magma exposed on the floor makes bubble columns, which fill Glass Bottles with pressurized air for the [Diving Suit](diving_gear.md).

### Vent Fields

Clusters of two to five black chimneys of basalt and blackstone rising from the floor, the tallest up to eight blocks. Each is capped with a <ItemLink id="hydrothermal_vent"/> pouring out smoke and bubbles, with magma inside and under it and Vent Tubeworms crowded around the base.

* The chimney walls are studded with copper, iron and gold ore.
* A Hydrothermal Vent burns anything that stands on it, like magma. Sneak to cross it safely.
* Mine it with a pickaxe to take it home. A [Thermal Vent Tap](nautec:getting_started/ocean_generators.md) sitting over it counts it as three heat sources, as much as three magma blocks.

***

## <Color id="gold">Prismarine Reef</Color>

Bright, clear shallow water.

* Coral, sea pickles and patches of prismarine in the sea floor, with Prismarine Fronds growing between them.
* <ItemLink id="budding_prismarine"/> sits in the top of the sea floor and in the prismarine patches. It is the easiest place to find one.
* Tropical fish, Silt Skippers, squid and dolphins.

***

## <Color id="gold">For Pack Makers</Color>

`enableBiomeInjection` in `config/nautec-worldgen.toml` turns the biomes off. Packs using a custom overworld preset should add it to `injectableWorldPresets`. With Lithostitched installed, placement comes from the biome injector files in `data/nautec/lithostitched/biome_injector` instead, which also covers Terralith and Tectonic.

The biome tag `nautec:has_budding_prismarine` lists the non-NauTec biomes that get the odd Budding Prismarine in their sea floor, Warm Ocean and Deep Lukewarm Ocean by default. Add another mod's warm oceans to it to give them the same. `nautec:budding_prismarine_grafting` lists where Lithophiles can be grafted from it, and already includes the first tag.

Plants and creatures are covered in [Life in the Deep](deep_life.md).
