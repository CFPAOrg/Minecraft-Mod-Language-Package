---
navigation:
  title: Deep Materials
  icon: nautec:flawless_prismarine_crystal
  position: 4
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:resonant_shard
  - nautec:flawless_prismarine_crystal
  - nautec:deep_steel_plating
---

# <Color id="light_purple">Deep Materials</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="flawless_prismarine_crystal" scale="2"/>
  The three crafting materials made by the Resonance Chamber and the Abyssal Pressure Forge.
</Column>

Each of these comes from exactly one machine recipe. JEI shows the recipes with their purity and depth requirements.

***

<Row>
  <ItemImage id="resonant_shard"/>
  ### <Color id="aqua">Resonant Shard</Color>
</Row>

Made in a [Resonance Chamber](resonance_chamber.md) from a <ItemLink id="prismarine_crystal_shard"/>, on a beam of purity 3.0 or higher. One shard in, one Resonant Shard out.

Used in the [Gateway](gateway.md), the [Abyssal Pressure Forge](pressure_forge.md), [Neptune's Trident](neptunes_trident.md), the Laser Injector of the [Fusion Plant](fusion_plant.md), the Dormant Crystal Seed and the [Resonance Network](resonance_network.md) blocks, and pressed into Flawless Prismarine Crystals.

***

<Row>
  <ItemImage id="flawless_prismarine_crystal"/>
  ### <Color id="aqua">Flawless Prismarine Crystal</Color>
</Row>

Made in an [Abyssal Pressure Forge](pressure_forge.md) from a Resonant Shard. Needs purity 2.0, the Forge at Y -20 or lower, and 10 seconds per crystal.

Used in the [Atlantean Rifle](atlantean_rifle.md), [Neptune's Trident](neptunes_trident.md), the [Gateway](gateway.md), the Fusion Controller, the Crystal Cradle, the Dormant Crystal Seed and the Pressure Synthesizer.

***

<Row>
  <ItemImage id="deep_steel_plating"/>
  ### <Color id="aqua">Deep Steel Plating</Color>
</Row>

Made in an [Abyssal Pressure Forge](pressure_forge.md) from an Aquarine Steel Ingot. Needs purity 2.5, the Forge at Y -40 or lower, and 15 seconds per plate.

Used in the [Atlantean Rifle](atlantean_rifle.md), [Neptune's Trident](neptunes_trident.md), the [Gateway](gateway.md), most [Fusion Plant](fusion_plant.md) parts and the Crystal Cradle.

It also repairs a <ItemLink id="submarine"/> on an anvil. Put the picked-up Sea Scout in the left slot and plating in the right. Each plate restores 20% of the hull and costs 2 levels. The repair item and the amount per item are `submarineRepairItem` and `submarineRepairPercent` in `config/nautec-common.toml`.
