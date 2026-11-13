---
navigation:
  title: Chemistry Fluids
  icon: nautec:eas_bucket
  position: 3
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:eas_bucket
  - nautec:saltwater_bucket
  - nautec:oil_bucket
  - nautec:glass_vial
  - nautec:eas_vial
  - nautec:salt
---

# <Color id="light_purple">Chemistry Fluids</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="eas_bucket" scale="2"/>
  The fluids NauTec machines use and make.
</Column>

Salt Water is the base of almost every [Mixer](mixer.md) recipe. The Mixer turns it into Electrolyte Algae Serum (EAS) and Etching Acid.

***

<Row>
  <ItemImage id="saltwater_bucket"/>
  ### <Color id="aqua">Salt Water</Color>
</Row>

Salt Water comes from the [Deep Sea Drain](drain.md), which pumps 500 mB every second into its tank. Draw it off with a Bucket or a pipe.

You can also make it in the [Mixer](mixer.md): 1,000 mB of plain Water and one Salt give 1,000 mB of Salt Water in 5 seconds.

Ocean water in a Bucket stays plain water by default. Pack makers can set `collectSaltWater` to true in `config/nautec-common.toml` so that filling a Bucket from any water source in an ocean biome gives a Salt Water Bucket.

***

<Row>
  <ItemImage id="eas_bucket"/>
  ### <Color id="aqua">Electrolyte Algae Serum (EAS)</Color>
</Row>

Made in the [Mixer](mixer.md) from Salt Water. EAS unlocks the abilities of the [Aquarine Steel tools](tools.md).

To infuse a tool, pour the EAS out as a source block and drop the tool into it. After about 7.5 seconds the tool is infused for good and the EAS source is used up, so one bucket infuses one tool.

***

<Row>
  <ItemImage id="etching_acid_bucket"/>
  ### <Color id="aqua">Etching Acid</Color>
</Row>

Cleans rust off crates and old parts. Make it in the [Mixer](mixer.md) or by crafting. See [Crate & Item Etching](nautec:getting_started/etching.md).

***

<Row>
  <ItemImage id="oil_bucket"/>
  ### <Color id="aqua">Oil</Color>
</Row>

A thick fluid found in <ItemLink id="oil_barrel"/>s.

***

## <Color id="gold">Vials and Salt</Color>

<Row>
  <ItemImage id="glass_vial"/>
  ### <Color id="aqua">Glass Vial</Color>
</Row>

<Recipe id="nautec:glass_vial"/>

<Row>
  <ItemImage id="eas_vial"/>
  ### <Color id="aqua">Electrolyte Algae Serum (EAS) Vial</Color>
</Row>

An EAS Bucket and three Glass Vials craft three EAS Vials, and you get the empty Bucket back. Glass Vials and an EAS Vial go into the <ItemLink id="syringe_robot_arm"/>.

<Recipe id="nautec:eas_vial"/>

<Row>
  <ItemImage id="salt"/>
  ### <Color id="aqua">Salt</Color>
</Row>

Turns up as a catch in lucky fishing zones. See [Fishing](nautec:getting_started/fishing.md). A [Thermal Vent Tap](nautec:getting_started/ocean_generators.md) also leaves one Salt behind for every 1,000 mB of Salt Water it boils. Salt and Water make Salt Water in the [Mixer](mixer.md).
