---
navigation:
  title: Ancient Machine Parts
  icon: nautec:ancient_valve
  position: 5
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:burnt_coil
  - nautec:rusty_gear
  - nautec:gear
  - nautec:ancient_valve
  - nautec:valve
  - nautec:damaged_aquatic_chip
  - nautec:aquatic_chip
---

# <Color id="light_purple">Ancient Machine Parts</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="ancient_valve" scale="2"/>
  Broken parts from the sea floor that you repair before a recipe will take them.
</Column>

Gears, valves, coils, chips and whisks come from the sea floor already damaged, and each kind is repaired in its own way. [Salvage](salvage.md) lists where they turn up. Once you reach a Crystal Geode you can also make every one of them yourself, so you never have to wait on a lucky find: see Making Them Yourself at the bottom of this page.

| Found | Repaired | How |
|---|---|---|
| <ItemLink id="rusty_gear"/> | <ItemLink id="gear"/> | [Etching](etching.md) |
| <ItemLink id="ancient_valve"/> | <ItemLink id="valve"/> | [Etching](etching.md) |
| <ItemLink id="burnt_coil"/> | Laser Channeling Coil | [Item Transformation](item_transformation.md) at purity 1.5 |
| <ItemLink id="damaged_aquatic_chip"/> | <ItemLink id="aquatic_chip"/> | crafting |
| Broken Whisk | Whisk | crafting |

***

<Row>
  <ItemImage id="gear"/>
  ### <Color id="aqua">Gear</Color>
</Row>

Drop Rusty Gears into Etching Acid. Gears go into the Aquarine Steel pickaxe, axe and shovel, the Mixer, the Fishing Station, the Deep Sea Drain and two augments.

***

<Row>
  <ItemImage id="valve"/>
  ### <Color id="aqua">Valve</Color>
</Row>

Drop Ancient Valves into Etching Acid. Valves go into the Aquarine Steel chestplate and leggings, the Deep Sea Drain, the Thermal Vent Tap, the Oxygen Diffuser, the Pressure Hatch, the Cargo Hold Module and the Fusion Port.

***

<Row>
  <ItemImage id="burnt_coil"/>
  ### <Color id="aqua">Laser Channeling Coil</Color>
</Row>

Hold a Burnt Coil in a purity 1.5 beam for 10 seconds. Reach that purity with a Prismarine Crystal, a Bacterial Fuel Cell or a Focusing Lens, as [Item Transformation](item_transformation.md) explains. The coil goes into Aquarine Steel tools, the Charger, the Prismatic Battery and many machines.

***

<Row>
  <ItemImage id="aquatic_chip"/>
  ### <Color id="aqua">Aquatic Chip</Color>
</Row>

Craft a Damaged Aquatic Chip with Prismarine Shards. Aquatic Chips go into the Incubator, Bio Reactor and Bacterial Fuel Cell, the Pressure Forge, the Resonance Chamber, most Sea Scout modules and most crafted augments. Lucky zone treasure in the Bioluminescent Grove sometimes gives one ready made.

<Recipe id="nautec:aquatic_chip"/>

***

## <Color id="gold">Whisk</Color>

Craft a Broken Whisk with Cast Iron Nuggets. The Whisk is needed for the [Mixer](nautec:laser_chemistry/mixer.md). Broken Whisks come from Drowned, ocean ruin chests and lucky zone treasure.

<Recipe id="nautec:whisk"/>

***

## <Color id="gold">Making Them Yourself</Color>

Every part has a guaranteed route that opens up as you progress. Each one leads into the next:

1. **Gears**: hold a Cast Iron Block in a beam of purity 2.5 or higher for 8 seconds and it becomes four Gears. Only a <ItemLink id="prismarine_crystal"/> or a <ItemLink id="bacterial_fuel_cell"/> reaches 2.5; see [Item Transformation](item_transformation.md).
2. **Valves and Whisks**: craft them from Cast Iron, a Gear or Aquarine Steel, and a Prismarine Crystal Shard.
3. With a Valve and a Whisk you can build the [Deep Sea Drain](nautec:laser_chemistry/drain.md) and the [Mixer](nautec:laser_chemistry/mixer.md).
4. **Burnt Coils**: in the Mixer, 4 Copper Ingots, 2 Redstone, an Aquarine Steel Ingot and a Prismarine Crystal Shard with 1,000 mB of Salt Water make a Burnt Coil. Repair it in a purity 1.5 beam as above.
5. **Aquatic Chips**: in the Mixer, 2 Gold Ingots, 4 Redstone, 2 Prismarine Crystal Shards and a Laser Channeling Coil with 1,000 mB of Salt Water make two finished Aquatic Chips.

JEI shows the Mixer and beam recipes.

<Recipe id="nautec:valve_from_cast_iron"/>

<Recipe id="nautec:whisk_from_cast_iron"/>
