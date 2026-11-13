---
navigation:
  title: Aquarine Steel and Cast Iron
  icon: nautec:aquarine_steel_ingot
  position: 2
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:aquarine_steel_compound
  - nautec:aquarine_steel_ingot
  - nautec:aquarine_steel_block
  - nautec:cast_iron_compound
  - nautec:cast_iron_ingot
  - nautec:cast_iron_nugget
  - nautec:cast_iron_rod
  - nautec:cast_iron_block
  - nautec:laser_channeling_coil
  - nautec:whisk
  - nautec:broken_whisk
  - nautec:oil_barrel
---

# <Color id="light_purple">Aquarine Steel and Cast Iron</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="aquarine_steel_ingot" scale="2"/>
  The metals and parts most NauTec machines are built from.
</Column>

## <Color id="gold">Aquarine Steel</Color>

<Row>
  <ItemImage id="aquarine_steel_compound"/>
  ### <Color id="aqua">Aquarine Steel Compound</Color>
</Row>

Craft it by hand, or make it in the [Mixer](mixer.md) with Salt Water, which gives more compound for the same raw iron. JEI shows the Mixer recipe.

<Recipe id="nautec:aquarine_steel_compound"/>

<Row>
  <ItemImage id="aquarine_steel_ingot"/>
  ### <Color id="aqua">Aquarine Steel Ingot</Color>
</Row>

Drop the compound into any powered laser beam and it becomes an ingot after 5 seconds. Any purity works, so one Aquatic Catalyst is enough. A beam of purity 2.0 or more gives 2 ingots per compound in 4 seconds instead. See [Item Transformation](nautec:getting_started/item_transformation.md) for the setup.

<Row>
  <ItemImage id="aquarine_steel_block"/>
  ### <Color id="aqua">Aquarine Steel Block</Color>
</Row>

Storage for nine ingots.

<RecipeFor id="aquarine_steel_block"/>

***

## <Color id="gold">Cast Iron</Color>

<Row>
  <ItemImage id="cast_iron_compound"/>
  ### <Color id="aqua">Cast Iron Compound</Color>
</Row>

<Recipe id="nautec:cast_iron_compound"/>

<Row>
  <ItemImage id="cast_iron_ingot"/>
  ### <Color id="aqua">Cast Iron Ingot</Color>
</Row>

Smelt the compound in a Furnace, or twice as fast in a Blast Furnace.

<Recipe id="nautec:cast_iron_ingot_blasting"/>

Old iron from the sea floor blasts down too: an Anchor gives 11 ingots and an Oil Barrel gives 5.

<Recipe id="nautec:cast_iron_ingot_from_oil_barrel_blasting"/>

<Row>
  <ItemImage id="cast_iron_rod"/>
  ### <Color id="aqua">Cast Iron Rod</Color>
</Row>

Used in the Aquarine Steel tools, the Fishing Station, the Deep Sea Drain Wall, the Oil Barrel and the Whisk.

<Recipe id="nautec:cast_iron_rod"/>

<Row>
  <ItemImage id="cast_iron_nugget"/>
  ### <Color id="aqua">Cast Iron Nugget</Color>
</Row>

Nine to an ingot and back. Nuggets repair a Broken Whisk.

<Row>
  <ItemImage id="cast_iron_block"/>
  ### <Color id="aqua">Cast Iron Block</Color>
</Row>

Storage for nine ingots.

<Recipe id="nautec:cast_iron_block_from_ingots"/>

<Row>
  <ItemImage id="oil_barrel"/>
  ### <Color id="aqua">Oil Barrel</Color>
</Row>

A cast iron drum that holds up to 8,000 mB of oil, NauTec's or any other mod's (anything in the `c:oil` tag). Right-click it to open or close its lid; pipes can only reach the Oil while the lid is open. Blast it for Cast Iron Ingots. Mine it with a pickaxe to pick it up.

<Recipe id="nautec:oil_barrel"/>

***

## <Color id="gold">Machine Parts</Color>

<Row>
  <ItemImage id="laser_channeling_coil"/>
  ### <Color id="aqua">Laser Channeling Coil</Color>
</Row>

Made from a <ItemLink id="burnt_coil"/> by Item Transformation: 10 seconds in a beam of purity 1.5 or higher. An Aquatic Catalyst tops out at 1.2, so either fire the catalyst into a <ItemLink id="prismarine_crystal"/> and use the beam that comes out of it, or pass a crystal-shard beam straight through a <ItemLink id="focusing_lens"/>.

The coil goes into the Charger, the Prismatic Battery, most Aquarine Steel tools and many later machines.

<Row>
  <ItemImage id="broken_whisk"/>
  ### <Color id="aqua">Broken Whisk</Color>
</Row>

Drowned sometimes drop one, lucky fishing zones can turn one up as treasure, and ocean ruin and research outpost chests can hold one.

<Row>
  <ItemImage id="whisk"/>
  ### <Color id="aqua">Whisk</Color>
</Row>

The stirring part of the [Mixer](mixer.md). Repair a Broken Whisk with four Cast Iron Nuggets, or craft a new one from Cast Iron Rods, a Prismarine Crystal Shard and an Aquarine Steel Ingot.

<Recipe id="nautec:whisk"/>
<Recipe id="nautec:whisk_from_cast_iron"/>
