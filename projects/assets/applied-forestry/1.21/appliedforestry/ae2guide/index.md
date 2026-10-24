---
navigation:
  title: Applied Forestry
  icon: appliedforestry:genetic_terminal
item_ids:
  - appliedforestry:genetic_terminal
  - appliedforestry:genetic_export_bus
  - appliedforestry:genetic_import_bus
  - appliedforestry:genetic_level_emitter
  - appliedforestry:genetic_cell_4k
  - appliedforestry:genetic_cell_16k
  - appliedforestry:genetic_cell_64k
  - appliedforestry:genetic_cell_256k
---

# Applied Forestry

Applied Forestry adds Forestry-aware storage and automation to Applied Energistics 2. Organisms always remain their original exact ItemStacks; the addon only builds a searchable semantic index over their Forestry Data Components.

<ItemGrid>
  <ItemIcon id="appliedforestry:genetic_terminal" />
  <ItemIcon id="appliedforestry:genetic_export_bus" />
  <ItemIcon id="appliedforestry:genetic_import_bus" />
  <ItemIcon id="appliedforestry:genetic_level_emitter" />
  <ItemIcon id="appliedforestry:genetic_cell_4k" />
  <ItemIcon id="appliedforestry:genetic_cell_16k" />
  <ItemIcon id="appliedforestry:genetic_cell_64k" />
  <ItemIcon id="appliedforestry:genetic_cell_256k" />
</ItemGrid>

## ME Genetic Terminal

The terminal groups exact Forestry organisms by category, species, life stage and purity. Expand a group to select a specific exact genome. Its search field accepts normal text and the genetic predicates described on the [filter reference](filters.md).

## Genetic buses

The Genetic Export Bus and Genetic Import Bus use the same predicate editor. The Export Bus can retain a combined semantic stock amount, even when that stock consists of many exact genome variants. Speed and Redstone Cards behave like their AE2 bus counterparts.

## Genetic Level Emitter

Counts all exact organism variants matching one semantic filter and emits redstone above or below the configured threshold.

## Genetic storage cells

The 4K, 16K, 64K and 256K Genetic Storage Cells accept Forestry organisms only and trade general-purpose storage for substantially higher type limits. Exact Data Components, mates and analyzed state are preserved. Exact partitioning and Inverter Cards work through the Cell Workbench.

All part filter settings can be copied with an AE2 Memory Card.

