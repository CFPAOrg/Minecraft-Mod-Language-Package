---
navigation:
  title: Crystal Cultivator
  icon: nautec:crystal_cultivator
  position: 13
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:crystal_cultivator
---

# Crystal Cultivator

<ItemImage id="crystal_cultivator" scale="2"/>

Attach a Crystal Cultivator to any face of a budding block, then aim a laser into its outward-facing crystal tip. It accelerates growth and harvests fully grown clusters from the remaining faces, leaving young buds and the source block in place.

Use it with Budding Prismarine to automate Prismarine Crystal Shards, or with vanilla Budding Amethyst. GeoOre budding blocks and AE2 budding quartz are supported when those mods are installed.

## Power and purity

The Cultivator needs **20 AP** to harvest. At 20 AP, crystals grow **2.5x** as fast as they would on their own; **100 AP gives 25x growth**. Power between those points scales linearly. Higher power continues to help, with diminishing returns: 180 AP gives about 40.6x and 260 AP about 49.7x growth.

Purity determines the Fortune enchantment used to harvest. Each whole purity level gives one Fortune level through purity 6: 2.0 purity gives Fortune II and 6.0 gives Fortune VI. Above 6, gains diminish; purity 9 gives Fortune VIII and purity 12 gives Fortune IX. Purity above 6 comes from a [Bacterial Enrichment Catalyst](nautec:deep_engineering/bacterial_enrichment_catalyst.md) working on the crystal. The cluster's normal loot table determines its drops and how Fortune affects them.

## Collecting the harvest

The nine-slot output buffer accepts extraction by pipes and hoppers. Right-click with an empty hand to take a stack, or sneak and right-click to collect everything. If the complete harvest will not fit, the mature cluster stays in place until there is room. Waterlogged clusters leave their water behind.

Use one Cultivator per budding block. Additional attachments do not stack their growth bonuses. A Cultivator without power does not harvest or accelerate growth, but the budding block can still grow naturally.

## Mod compatibility

The Cultivator runs the source block's own growth logic, retaining mod growth settings and requirements. It respects the world's random tick speed, including disabling accelerated growth when that rule is zero.

AE2's Flawed, Chipped and Damaged Budding Quartz retain their normal chance to decay after successful growth, so faster growth also uses them up sooner. Use **Flawless Budding Quartz** for a lasting Certus Quartz farm.

Pack makers can extend or restrict support with the `nautec:cultivator_sources` and `nautec:cultivator_clusters` block tags. These include the common `c:budding_blocks` and `c:clusters` tags. Only add fully grown harvestable clusters to the latter; immature buds should remain untouched.

## Crafting

<RecipeFor id="crystal_cultivator"/>
