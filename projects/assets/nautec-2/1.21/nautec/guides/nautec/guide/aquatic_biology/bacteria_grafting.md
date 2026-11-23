---
navigation:
  title: Bacteria Grafting
  icon: nautec:grafting_tool
  position: 3
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:grafting_tool
  - nautec:grafting_station
  - nautec:grafting_anchor
  - nautec:advanced_grafting_anchor
---

# <Color id="light_purple">Bacteria Grafting</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="grafting_tool" scale="2"/>
  The Grafting Tool scrapes a first colony off a block into a Petri Dish.
</Column>

Hold the Grafting Tool in your main hand and an empty <ItemLink id="petri_dish"/> in your off hand, then right-click a graftable block in the biome it needs. Each try costs one point of durability and has a chance to put a new colony in the dish. Keep clicking until one takes.

<Color id="gold">Tip</Color>: graft into an empty dish. If the off-hand dish already holds a colony, the tool shows "This Petri Dish already holds a colony" and does nothing, with no durability used.

***

## <Color id="gold">Grafting Tool</Color>

<RecipeFor id="grafting_tool"/>

The tool has 80 durability.

***

## <Color id="gold">Where to Graft</Color>

| Block | Biome | Strain | Chance |
|---|---|---|---|
| Stone | any ocean | Cyanobacteria | 40% |
| Sand | any beach | Halobacteria | 40% |
| Podzol | any forest | Methanogens | 40% |
| Netherrack | the Nether | Thermophiles | 40% |
| Glow Polyp | Bioluminescent Grove | Cyanobacteria | 50% |
| Deep Kelp | Bioluminescent Grove | Halotrophs | 30% |
| Luminescent Algae | Bioluminescent Grove | Algaeformers | 30% |
| Prismarine Frond | Prismarine Reef | Phototrophs | 35% |
| <ItemLink id="budding_prismarine"/> | Prismarine Reef, Bioluminescent Grove, Abyssal Trench, Warm Ocean, Deep Lukewarm Ocean | Lithophiles | 30% |
| Abyssal Coral | Abyssal Trench | Calciophiles | 30% |
| Vent Tubeworm | Hydrothermal Vents | Sulfurophiles | 25% |

Packs can change this list. JEI's Bacteria Grafting category always shows the current one, with the biome under "Only In".

***

## <Color id="gold">Grafting Station</Color>

<Row>
  <ItemImage id="grafting_station" scale="2"/>
</Row>

The Grafting Station grafts without the tool, and without the biome. Give it an empty <ItemLink id="petri_dish"/>, one of the graftable blocks from the table above, and Salt Water, and every cycle puts a fresh colony in the dish. There is no chance roll, so it never wastes a try.

* Power: a beam of at least 100 AP at purity 2.8 or higher, into any face except the front. A <ItemLink id="prismarine_crystal"/> beam (3.0) fed straight in, or through relays and junctions, works.
* Salt Water: 4,000 mB per colony. The tank holds 16,000 mB. Pipe it in or right-click with a bucket.
* Time: one minute per colony. A weak beam pauses it without losing progress.
* Each colony uses up one dish and one block, unless a Grafting Anchor or Advanced Grafting Anchor is fitted.

Right-click it to open it. Hover over the arrow to see what it is waiting for, or look at it through a <ItemLink id="prism_monocle"/>. Hoppers and pipes can insert dishes and blocks and pull colonized dishes out, through any face by default ([Side Configuration](nautec:getting_started/utilities.md)). The front window lights up while it works.

All of these values are in `config/nautec-common.toml`.

<RecipeFor id="grafting_station"/>

<Row>
  <ItemImage id="grafting_anchor"/>
  ### <Color id="aqua">Grafting Anchor</Color>
</Row>

An upgrade for the Grafting Station. Put it in the slot at the bottom left of the station's screen, and the sample block stays put after each graft, so one block grafts colonies for as long as you keep the dishes and Salt Water coming. Shift-clicking the anchor from your inventory puts it straight into its slot. Pipes cannot reach that slot, so automation never pulls it out by mistake.

<RecipeFor id="grafting_anchor"/>

<Row>
  <ItemImage id="advanced_grafting_anchor"/>
  ### <Color id="aqua">Advanced Grafting Anchor</Color>
</Row>

A Grafting Anchor upgraded with four Reactor Speed Upgrades from the [Bio Reactor](bio_reactor.md). It goes in the same slot and keeps the sample block the same way, and it also grafts 200% faster, so a colony takes 20 seconds instead of a minute. The catch is power: the station then needs a beam of 500 AP, five times the usual 100, still at purity 2.8 or higher. Hover over the arrow in the station's screen to see what it needs with the anchor you have fitted.

<RecipeFor id="advanced_grafting_anchor"/>

***

## <Color id="gold">Stronger Beams</Color>

The Grafting Station grafts faster on a beam stronger than it needs: speed is the square root of (beam ÷ what it needs). It needs 100 AP, or 500 AP with an Advanced Grafting Anchor, always at purity 2.8 or higher.

| Beam, as a multiple of what it needs | Speed |
|---|---|
| 1× | ×1 (normal) |
| 4× | ×2 |
| 9× | ×3 |
| 16× | ×4 |

The two stack. An Advanced Grafting Anchor already grafts three times as fast on its 500 AP, and a 2,000 AP beam doubles that again, so a colony takes 10 seconds instead of 60.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.

***

## <Color id="gold">Which Colony to Start With</Color>

Cyanobacteria, Halobacteria, Methanogens and Thermophiles produce nothing and cannot be incubated. They are starting points: take them straight to the [Mutator](mutator.md) and turn them into a strain that makes something.

The deep ocean strains are ready to work as soon as you have them. Halotrophs make kelp, Algaeformers seagrass, Phototrophs sugar cane, Lithophiles stone, Calciophiles bone meal and Sulfurophiles gunpowder. Lithophiles is the parent of many other strains, and grafting it from Budding Prismarine skips a 15% mutation from Thermophiles, so a trip to the [Deep Oceans](nautec:getting_started/deep_oceans.md) saves a lot of mutating.

A fresh colony is unanalyzed. Run it through the [Bacterial Analyzer](bacterial_analyzer.md) to see what you got.
