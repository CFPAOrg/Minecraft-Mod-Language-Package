---
navigation:
  title: Combustion Dynamo
  icon: nautec:combustion_dynamo
  position: 16
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:combustion_dynamo
  - nautec:kelp_slurry
  - nautec:algal_lipid
  - nautec:biodiesel_bucket
  - nautec:crude_glycerin
  - nautec:fiery_crystal
  - nautec:crystalline_combustion_booster
  - nautec:stellar_combustion_booster
---

# <Color id="light_purple">Combustion Dynamo</Color>

<Column alignItems="center" fullWidth={true}>
  <Row>
    <ItemImage id="combustion_dynamo" scale="2"/>
  </Row>
  An engine that burns oil or biodiesel with water into Forge Energy (FE).
</Column>

The Combustion Dynamo makes 320 FE/t on oil, or 640 FE/t on biodiesel, while it has fuel and water, and pushes it into any cable or machine touching it. Oil comes from a bacteria strain that turns kelp into lipids, so a kelp farm and a Bio Reactor keep it running forever. Refining that oil into biodiesel roughly doubles what the same kelp gives you.

***

## <Color id="gold">Running It</Color>

* **Fuel.** Any oil in the `c:oil` tag works, NauTec's own and other mods'. It burns 1 mB every 10 ticks, so one bucket lasts over 8 minutes and makes 3.2 million FE. Biodiesel, or anything in the `c:biodiesel` tag, burns 1 mB every 12 ticks at 640 FE/t, so a bucket lasts 10 minutes and makes about 7.7 million FE.
* **Fuel values.** Output and burn time for each fuel come from the `nautec:combustion_fuels` data map, so a datapack can change them or add other fluids. JEI lists every fuel the engine accepts.
* **Water.** It also uses 1 mB of water every tick, 20 mB a second.
* **Tanks.** It has a separate 8,000 mB tank for each. Pipe both fluids into any side: fuel only goes into the fuel tank and water only into the water tank, so one pipe can carry both. The fuel tank holds one fuel at a time, so let it run dry before switching from oil to biodiesel.
* **Additive.** Put a booster in the item slot to increase output. Its timer only runs while the engine burns; running out of fuel, water, or output space pauses it.

| Booster | FE/t on oil | Fuel and water use | Active time |
|---|---|---|---|
| Redstone Dust | 480 | 1.1 times base | 1 minute |
| Blaze Powder | 640 | 1.5 times base | 2 minutes |
| Fiery Crystal | 960 | 2 times base | 5 minutes |
| Crystalline Combustion Booster | 1,600 | 3 times base | 10 minutes |
| Stellar Combustion Booster | 3,200 | 5 times base | 1 hour |

On biodiesel each booster multiplies 640 FE/t instead of 320.

Craft a Fiery Crystal from a Prismarine Crystal Shard and four Blaze Powder. Combine two Fiery Crystals, two Resonant Shards and a Flawless Prismarine Crystal for the crystalline tier. The stellar tier combines four crystalline boosters, four Deep Steel Plating and a Nether Star. JEI shows each boost and its crafting recipe.

<RecipeFor id="fiery_crystal"/>
<RecipeFor id="crystalline_combustion_booster"/>
<RecipeFor id="stellar_combustion_booster"/>

The screen shows the output, what the engine is missing, and how much boost is left. Jade shows the same from outside.

***

## <Color id="gold">Making Oil</Color>

<Row>
  <ItemImage id="kelp_slurry"/>
  ### <Color id="aqua">Kelp Slurry</Color>
</Row>

Mix 4 Kelp with 1,000 mB of Salt Water in the [Mixer](nautec:laser_chemistry/mixer.md) to make 2 Kelp Slurry.

<Row>
  <ItemImage id="algal_lipid"/>
  ### <Color id="aqua">Lipophiles and Algal Lipid</Color>
</Row>

Lipophiles are a bacteria strain that makes Algal Lipid. Mutate them from Halotrophs in the [Mutator](nautec:aquatic_biology/mutator.md) with Kelp Slurry as the catalyst (10% a try), then grow and feed them on Kelp Slurry like any other strain. A colony in a [Bio Reactor](nautec:aquatic_biology/bio_reactor.md) turns out a steady flow of Algal Lipid.

### <Color id="aqua">Oil</Color>

Mix 1 Algal Lipid with 250 mB of Salt Water in the Mixer to make 1,000 mB of oil.

***

## <Color id="gold">Refining Biodiesel</Color>

<Row>
  <ItemImage id="biodiesel_bucket"/>
  ### <Color id="aqua">Biodiesel</Color>
</Row>

Mix 1,000 mB of oil with 1 <ItemLink id="salt"/> in the [Mixer](nautec:laser_chemistry/mixer.md) to make 750 mB of Biodiesel and 1 Crude Glycerin. Those 750 mB make about 5.8 million FE in the dynamo, against 3.2 million from burning the oil as it is.

<Row>
  <ItemImage id="crude_glycerin"/>
  ### <Color id="aqua">Crude Glycerin</Color>
</Row>

Mix 2 Crude Glycerin and 1 Bone Meal with 1,000 mB of Salt Water to make 1,000 mB of [Etching Acid](nautec:getting_started/etching.md). A biodiesel line makes the acid for the [Abyssal Pressure Forge](nautec:deep_engineering/pressure_forge.md) along the way, with no pufferfish needed.

<RecipeFor id="combustion_dynamo"/>
