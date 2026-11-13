---
navigation:
  title: Beam Optics
  icon: nautec:focusing_lens
  position: 0
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:focusing_lens
---

# <Color id="light_purple">Beam Optics</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="focusing_lens" scale="2"/>
  Purity, and the lens that raises it.
</Column>

A <ItemLink id="prismarine_laser_relay"/> passes a beam on in a straight line and a <ItemLink id="laser_junction"/> turns, merges and splits it, and neither changes its purity (see [Moving Laser Power](nautec:laser_chemistry/laser_manipulation.md)). Recipes check purity before they run, so plan your source around the purity the machine at the end needs.

***

## <Color id="gold">Purity</Color>

Purity is set by the source. Merging beams lowers it a little, and a Focusing Lens raises it.

| Source | Purity |
|---|---|
| <ItemLink id="aquatic_catalyst"/> on Prismarine Shards | 0.4 |
| Aquatic Catalyst on Prismarine Crystals | 0.8 |
| Aquatic Catalyst on Prismarine Crystal Shards | 1.2 |
| <ItemLink id="bacterial_fuel_cell"/> | up to 2.5 |
| <ItemLink id="prismarine_crystal"/>, hit from the side | 3.0, or a cultivated crystal's own purity (up to 12) |

A cultivated crystal can be raised past 6.0 with a [Bacterial Enrichment Catalyst](bacterial_enrichment_catalyst.md).

Each Budding Prismarine block touching an Aquatic Catalyst adds 0.1 to its beam's purity, up to 2.0. See [Laser Power](nautec:getting_started/laser_power.md).

The machines in this section need these purities:

| Output | Machine | Purity |
|---|---|---|
| Flawless Prismarine Crystal | [Abyssal Pressure Forge](pressure_forge.md) | 2.0 |
| Atlantic Gold Ingot | Abyssal Pressure Forge | 2.0 |
| Deep Steel Plating | Abyssal Pressure Forge | 2.5 |
| Resonant Shard | [Resonance Chamber](resonance_chamber.md) | 3.0 |
| Prismarine Crystal Seed | Resonance Chamber | 3.0 |

When two or more beams feed the same block, their power adds up and their purity stays close to the purest beam. The result is the highest purity minus a quarter of the gap between it and the average of all of them (`beamMergePurityDrop`), so a 3.0 beam merged with a 0 beam comes out at about 2.6.

***

<Row>
  <ItemImage id="focusing_lens"/>
  ### <Color id="aqua">Focusing Lens</Color>
</Row>

Raises the purity of a beam that passes straight through it by 0.5 (`lensPurityBonus`), up to a limit of 2.0. Place it while looking the way the beam travels: the face toward you takes the beam in, the far face sends it on, up to 16 blocks (`laserDistance`). Power passes through unchanged, and it can be placed under water.

The lens only adds purity to a beam that already has some, so put it after a working source. A beam at 1.8 comes out at 2.0, and a beam already at 2.0 or higher passes through unchanged, so a row of lenses tops out at 2.0. Run two in a row to lift a Prismarine Crystal Shard catalyst (1.2) to the 2.0 the Pressure Forge needs for Flawless Prismarine Crystals. For 2.5 and 3.0, use a Bacterial Fuel Cell or a Prismarine Crystal as the source.

<Recipe id="nautec:focusing_lens"/>
