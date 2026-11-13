---
navigation:
  title: Crates and Etching
  icon: nautec:rusty_crate
  position: 6
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:etching_acid_bucket
  - nautec:crate
  - nautec:rusty_crate
---

# <Color id="light_purple">Crates and Etching</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="rusty_crate" scale="2"/>
  Open Crates like a chest, and clean rusty ones in Etching Acid first.
</Column>

***

<Row>
  <ItemImage id="crate"/>
  ### <Color id="aqua">Crate</Color>
</Row>

A 27 slot container found in geodes and in vanilla shipwreck and ruin loot. Right-click it to open it like a chest. Hoppers can move items in and out of it too.

Breaking a crate drops the crate itself with its contents still inside, opened or not, so you can carry a find home before opening it.

***

<Row>
  <ItemImage id="rusty_crate"/>
  ### <Color id="aqua">Rusty Crate</Color>
</Row>

A crate rusted shut, found in ruins. It will not open, and hoppers cannot reach its contents, until you etch it: drop it in Etching Acid and it turns into an ordinary Crate with the same loot. Its tooltip and the message you get when you try to open it say the same, and JEI shows the conversion under Item Etching.

Rusty Crates hold better salvage than plain ones. Break one to carry it; it keeps its loot the same way a Crate does.

***

## <Color id="gold">Etching</Color>

Drop an item into Etching Acid and it comes out cleaned after the recipe time, 8 to 10 seconds. The whole dropped stack converts at once.

| Input | Output | Time |
|---|---|---|
| Rusty Crate | Crate, loot kept | 10 s |
| <ItemLink id="rusty_gear"/> | <ItemLink id="gear"/> | 8 s |
| <ItemLink id="ancient_valve"/> | <ItemLink id="valve"/> | 10 s |

JEI lists these under Item Etching.

One etching in three uses up the Etching Acid source block the item is in. Flowing acid is never used up, and neither is the block under the pool. A single acid source in a one block deep pit is enough, as long as you keep a spare bucket to refill it.

***

<Row>
  <ItemImage id="etching_acid_bucket"/>
  ### <Color id="aqua">Etching Acid</Color>
</Row>

<RecipeFor id="etching_acid_bucket"/>

The [Mixer](nautec:laser_chemistry/mixer.md) makes it from Salt Water once you have one. Etching Acid is thick: you sink in it and wade slowly, and mobs path around it. The [Abyssal Pressure Forge](nautec:deep_engineering/pressure_forge.md) also runs on it.
