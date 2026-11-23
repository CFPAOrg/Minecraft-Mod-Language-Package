---
navigation:
  title: Strain Tree
  icon: nautec:mutator
  position: 2
  parent: aquatic_biology/aquatic_biology-index.md
---

# <Color id="light_purple">Strain Tree</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="mutator" scale="2"/>
  Which strain mutates into which, with the catalyst and its chance.
</Column>

Every strain except the grafted ones comes from the [Mutator](mutator.md). Each row below is one mutation: put a colony of the parent strain in the Mutator with the catalyst. The catalyst is never used up. Packs can change these recipes; JEI's Bacteria Mutations category always shows the current ones, and its Strain Lineage category shows the fastest route to any strain from one you can graft. Look up the recipes for a strain's dish to see it.

***

## <Color id="gold">How Long a Mutation Takes</Color>

On average, for a fresh colony on a 10 AP beam (12 seconds a try):

| Chance | Tries | Time | With a booster vial |
|---|---|---|---|
| 75% | 1 or 2 | about 15 seconds | 1 try |
| 30% | 3 or 4 | about 40 seconds | 1 or 2 tries |
| 15% | about 7 | under 1.5 minutes | 2 or 3 tries |
| 9% | about 11 | about 2 minutes | about 4 tries |
| 5% | 20 | 4 minutes | about 7 tries |
| 3% | 33 | about 7 minutes | about 11 tries |

A 40 AP beam halves every time. An Electrolyte Algae Serum Vial in the booster slot triples the chance, stops failures shrinking the colony, and is used up only on a success.

***

## <Color id="gold">Starting Strains</Color>

| Strain | Graft from | Where |
|---|---|---|
| Thermophiles | Netherrack | the Nether |
| Lithophiles | <ItemLink id="budding_prismarine"/> | Prismarine Reef, Bioluminescent Grove, Abyssal Trench, Warm Ocean, Deep Lukewarm Ocean |
| Halobacteria | Sand | any beach |
| Cyanobacteria | Stone, or a Glow Polyp in a Bioluminescent Grove | any ocean |
| Methanogens | Podzol | any forest |

[Bacteria Grafting](bacteria_grafting.md) lists every graft, including the deep ocean strains that skip the first mutation.

***

## <Color id="gold">Stone, Minerals and Metals</Color>

The most valuable branch. Graft Lithophiles from Budding Prismarine to skip its first step. Every step up to iron, redstone and lapis is 15%; gold, diamond and emerald stay at 5%.

| Strain | Makes | Parent | Catalyst | Chance |
|---|---|---|---|---|
| Lithophiles | Stone | Thermophiles | Stone | 15% |
| Calciophiles | Bone Meal | Lithophiles | Bone Meal | 15% |
| Silicophiles | Sand | Lithophiles | Sand | 15% |
| Carbophages | Coal | Lithophiles | Coal | 15% |
| Metallophiles | Copper Ingot | Carbophages | Copper Ingot | 15% |
| Ferrophiles | Iron Ingot | Metallophiles | Iron Ingot | 15% |
| Acidophiles | Redstone | Metallophiles | Redstone | 15% |
| Azuritophiles | Lapis Lazuli | Metallophiles | Lapis Lazuli | 15% |
| Sulfurophiles | Gunpowder | Acidophiles | Gunpowder | 15% |
| Aurrophiles | Gold Ingot | Ferrophiles | Gold Ingot | 5% |
| Adamantophiles | Diamond | Aurrophiles | Diamond | 5% |
| Smaragdophiles | Emerald | Adamantophiles | Emerald | 5% |
| Prismatophiles | Nothing | Smaragdophiles | Atlantic Gold Ingot | 5% |
| Prismatophiles (refine) | Nothing | Prismatophiles | Prismarine Crystal Shard | 25% |

Sulfurophiles can also be grafted from a Vent Tubeworm in the Hydrothermal Vents.

Shortest routes from a grafted Lithophiles colony:

| Target | Route | Mutations |
|---|---|---|
| Coal | Lithophiles, Carbophages | 1 |
| Copper | then Metallophiles | 2 |
| Iron, Redstone or Lapis | then Ferrophiles, Acidophiles or Azuritophiles | 3 |
| Gold or Gunpowder | then Aurrophiles or Sulfurophiles | 4 |
| Diamond | then Adamantophiles | 5 |
| Emerald | then Smaragdophiles | 6 |
| Prismatophiles | then Prismatophiles | 7 |

Starting from Thermophiles adds one more. You need one of each catalyst along the way, and since a catalyst is never used up, one iron ingot unlocks Ferrophiles for good.

Prismatophiles make nothing in a Bio Reactor. They feed the [Bacterial Enrichment Catalyst](nautec:deep_engineering/bacterial_enrichment_catalyst.md).

***

## <Color id="gold">Other Mods' Materials</Color>

Strains for other mods' metals and gems only exist when a mod in the pack adds that material. The catalyst is always the material's own ingot or gem, and the parent depends on how rare it is:

| Parent | Chance | Materials |
|---|---|---|
| Lithophiles | 30% | aluminum, bauxite, brass, bronze, graphite, lead, pig iron, steel, tin, zinc, apatite |
| Metallophiles | 30% | silver, nickel, antimony, bismuth, boron, constantan, electrum, invar, rose gold, stainless steel, amethyst bronze, and gems such as ruby, sapphire, peridot and topaz |
| Ferrophiles | 5% | osmium, uranium, cobalt, titanium, tungsten and most other mid-tier metals, certus and black quartz |
| Aurrophiles | 5% | platinum, iridium, palladium, enderium and other precious metals |
| Adamantophiles | 3% | netherite, allthemodium, vibranium, unobtainium and the other top-tier metals |

[Production Rates](production_rates.md) has the full list with each one's Strain Yield.

***

## <Color id="gold">Ocean Plants and Oil</Color>

| Strain | Makes | Parent | Catalyst | Chance |
|---|---|---|---|---|
| Halotrophs | Kelp | Halobacteria | Kelp | 75% |
| Algaeformers | Seagrass | Halobacteria | Seagrass | 75% |
| Lipophiles | Algal Lipid | Halotrophs | Kelp Slurry | 30% |
| Phototrophs | Sugar Cane | Halotrophs | Sugar Cane | 15% |
| Phototrophs | Sugar Cane | Cyanobacteria | Sugar Cane | 30% |
| Cryobionts | Ice | Algaeformers | Blue Ice | 15% |

Lipophiles make the lipids that become oil for the [Combustion Dynamo](nautec:getting_started/combustion_dynamo.md), which makes it the first step toward power that pays for itself.

***

## <Color id="gold">Crops</Color>

| Strain | Makes | Parent | Catalyst | Chance |
|---|---|---|---|---|
| Cactophyles | Cactus | Phototrophs | Cactus | 30% |
| Rhizobacteria | Wheat | Phototrophs | Wheat | 15% |
| Bamboophages | Bamboo | Rhizobacteria | Bamboo | 30% |
| Beta Phylobacteria | Beetroot | Rhizobacteria | Beetroot | 30% |
| Carotophyles | Carrot | Rhizobacteria | Carrot | 30% |
| Solanophiles | Potato | Rhizobacteria | Potato | 30% |
| Cucurbitophiles | Pumpkin | Rhizobacteria | Pumpkin | 30% |
| Melophages | Melon Slice | Cucurbitophiles | Melon Slice | 30% |
| Bryophytophiles | Moss Block | Rhizobacteria | Moss Block | 15% |

***

## <Color id="gold">Wood, Fungi and Flesh</Color>

| Strain | Makes | Parent | Catalyst | Chance |
|---|---|---|---|---|
| Lignocytes | Oak Log | Methanogens | Oak Log | 15% |
| Betulophiles, Boreophiles, Acaciophyles, Junglophiles, Dark Lignocytes, Prunus Lignocytes, Rhizophora Lignocytes | Birch, Spruce, Acacia, Jungle, Dark Oak, Cherry and Mangrove Logs | Lignocytes | that log | 15% |
| Crimson Lignocytes, Warped Lignocytes | Crimson and Warped Stems | Lignocytes | that stem | 9% |
| Cocoaphiles | Cocoa Beans | Junglophiles | Cocoa Beans | 30% |
| Carnivorous Bacteria | Rotten Flesh | Methanogens | Rotten Flesh | 15% |
| Brown Mycotrophic Bacteria | Brown Mushroom | Methanogens | Brown Mushroom Block | 60% |
| Red Mycotrophic Bacteria | Red Mushroom | Methanogens | Red Mushroom Block | 60% |
| Crimson Microbes, Warped Microbes | Crimson and Warped Fungus | either Mycotrophic strain | that fungus | 9% |

***

## <Color id="gold">Refining</Color>

Any strain that makes something can also mutate into itself. Use the storage block of the item it makes as the catalyst (an Iron Block for Ferrophiles, a Hay Bale for Rhizobacteria), or the item itself if it has no block. A refine has a 25% base chance, keeps the strain and the colony's size, and shifts its stats a little. It is how you breed a better colony of the strain you already have. See [Mutator](mutator.md).
