---
navigation:
  title: Crystal Cultivation
  icon: nautec:prismarine_crystal_seed
  position: 7
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:dormant_crystal_seed
  - nautec:prismarine_crystal_seed
  - nautec:crystal_cradle
---

# <Color id="light_purple">Crystal Cultivation</Color>

<Column alignItems="center" fullWidth={true}>
  <Row>
    <ItemImage id="prismarine_crystal_seed" scale="2"/>
    <ItemImage id="crystal_cradle" scale="2"/>
  </Row>
  Grow a Prismarine Crystal of your own, one you can pick up and move.
</Column>

A <ItemLink id="prismarine_crystal"/> turns any beam into a purity 3.0 beam, but the wild ones in Crystal Geodes are rooted where they grew. A **Cultivated Prismarine Crystal** rolls a purity between **3.00 and 6.00** when it finishes growing, rewarding cultivation with a chance of purer beams. It can also be lifted with a wrench and set down anywhere. Growing one takes a seed, a cradle, and ten million AP of high-purity laser power.

***

## <Color id="gold">1. Find a Wild Crystal</Color>

Awakening a seed needs a purity 3.0 beam, and only a Prismarine Crystal makes one. Find one in a Crystal Geode under the ocean floor (see [Structures](nautec:getting_started/structures.md)) and fire a beam into it, as described on [Laser Power](nautec:getting_started/laser_power.md). You need it once: your first cultivated crystal can awaken every seed after it.

***

## <Color id="gold">2. Craft a Dormant Crystal Seed</Color>

A Flawless Prismarine Crystal ringed with Resonant Shards and Prismarine Crystal Shards makes a <ItemLink id="dormant_crystal_seed"/>. It does nothing yet.

<RecipeFor id="dormant_crystal_seed"/>

***

## <Color id="gold">3. Awaken It</Color>

<Row>
  <ItemImage id="dormant_crystal_seed" scale="2"/>
  <ItemImage id="prismarine_crystal_seed" scale="2"/>
</Row>

Load the Dormant Crystal Seed into a [Resonance Chamber](resonance_chamber.md) fed by the purity 3.0 beam. When the chamber goes critical it crafts the seed into a glowing <ItemLink id="prismarine_crystal_seed"/>: one dormant seed in, one awakened seed out. JEI shows this recipe under the Resonance Chamber.

***

## <Color id="gold">4. Set It in a Cradle</Color>

Place a <ItemLink id="crystal_cradle"/> where you want the crystal to stand, with **six free blocks above it**. Air or water both count, so the cradle works underwater. Right-click the cradle with the awakened seed to set it; a tiny crystal appears on top.

<RecipeFor id="crystal_cradle"/>

You can take the seed back out with an empty hand until it starts growing. Hoppers and pipes can also put seeds in.

***

## <Color id="gold">5. Feed It Ten Million AP</Color>

Aim laser beams into any of the cradle's four sides. Every tick, the cradle adds the full power of its beams to the seed's growth, but **only while the beam purity is 2.0 or higher**. A purity 2.0 beam comes from:

* a <ItemLink id="bacterial_fuel_cell"/> (up to 2.5)
* a [Focusing Lens](beam_optics.md) on an existing beam (raises it up to 2.0)
* another Prismarine Crystal (3.0)

When several beams feed the cradle their power adds up and their purity stays close to the purest one, losing a quarter of the gap to their average. A weak beam still pulls the purity down a little, so a 2.1 beam joined by a 0 beam drops under 2.0.

The seed grows into a full crystal after **10,000,000 AP** (`crystalGrowthPower` in `config/nautec-common.toml`; the purity floor is `crystalGrowthPurity`). More power grows it faster:

| Beam power | Time to grow |
|---|---|
| 100 AP/t | about 83 minutes |
| 250 AP/t | about 33 minutes |
| 500 AP/t | about 17 minutes |
| 1,000 AP/t | about 8 minutes |

The crystal above the cradle grows taller as it fills. Growth never drains: if the beam stops, the seed waits until it comes back, so you can build up the ten million over several sessions.

Look at the cradle with Jade to see its progress, the power and purity arriving, the time left at the current power, and what is holding it back if it stops (no seed, no room above, no power, or purity too low).

<Color id="gold">Moving a growing seed</Color>: break the cradle with any tool. It drops with the seed and all of its growth stored, and its tooltip shows how far along it is. Place it again and growth carries on.

***

## <Color id="gold">6. The Cultivated Crystal</Color>

At ten million AP the seed becomes a full Cultivated Prismarine Crystal standing on the cradle. Its purity is randomly set between **3.00 and 6.00**, in steps of 0.01, when growth completes (it can be raised later, see the end of this page). Fire a beam into its side, and the top and bottom emit beams at that crystal's purity, sharing the incoming power (see [Laser Power](nautec:getting_started/laser_power.md)). The cradle is empty again and ready for another seed.

**To move it**, sneak and right-click any part of it with a wrench. Any mod's wrench works, as long as it is in the `c:tools/wrench` tag, including the <ItemLink id="aquarine_steel_wrench"/>. You get the crystal back as an item, and placing it needs six free blocks of height again. Its rolled purity is preserved when moved or reloaded; moving it does not reroll the value. Check the item tooltip to see its purity.

Wild crystals stay rooted, and the Aquarine Steel Pickaxe's shattering ability only works on wild crystals, so a cultivated one never breaks by accident. Jade marks every crystal as Cultivated or Natural.

The 6.00 is only where a crystal starts. A [Bacterial Enrichment Catalyst](bacterial_enrichment_catalyst.md) can raise a cultivated crystal's purity further, up to 12.

A cultivated crystal is also the heart of a [Fusion Plant](fusion_plant.md), NauTec's largest generator.
