---
navigation:
  title: Life in the Deep
  icon: nautec:luminous_membrane
  position: 12
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:deep_kelp
  - nautec:luminescent_algae
  - nautec:glow_polyp
  - nautec:prismarine_frond
  - nautec:vent_tubeworm
  - nautec:abyssal_coral
  - nautec:silt_skipper
  - nautec:silt_skipper_bucket
  - nautec:silt_skipper_spawn_egg
  - nautec:lantern_jelly_spawn_egg
  - nautec:vent_crawler_spawn_egg
  - nautec:abyssal_maw_spawn_egg
---

# <Color id="light_purple">Life in the Deep</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="luminous_membrane" scale="2"/>
  The six plants and four creatures of the NauTec oceans.
</Column>

## <Color id="gold">Plants</Color>

Collect all six with Shears; any other tool breaks them for nothing. Every one of them can be grafted for bacteria with the <ItemLink id="grafting_tool"/>; [Bacteria Grafting](nautec:aquatic_biology/bacteria_grafting.md) lists which.

| Plant | Biome | Light |
|---|---|---|
| <ItemLink id="deep_kelp"/> | Bioluminescent Grove | none |
| <ItemLink id="luminescent_algae"/> | Bioluminescent Grove | 9 |
| <ItemLink id="glow_polyp"/> | Bioluminescent Grove | 7 |
| <ItemLink id="prismarine_frond"/> | Prismarine Reef | none |
| <ItemLink id="vent_tubeworm"/> | Hydrothermal Vents | 3 |
| <ItemLink id="abyssal_coral"/> | Abyssal Trench | none |

Deep Kelp grows upward in water like kelp, up to 40 blocks tall (`kelpHeight` in `config/nautec-common.toml`). Only the top block of a strand drops, so shear the tip. Glow Polyp clings to any face of a block the way glow lichen does, and Bone Meal spreads it. The other four are single underwater plants.

Lucky fishing zones in each biome also turn up that biome's plants. See [Fishing](fishing.md).

***

## <Color id="gold">Silt Skipper</Color>

<GameScene zoom="3.2" background="#333333" interactive={true}>
  <Entity id="nautec:silt_skipper"/>
</GameScene>

A small passive fish that swims in schools of up to eight, in the Abyssal Trench, the Bioluminescent Grove and the Prismarine Reef.

* Kill it for a <ItemLink id="silt_skipper"/> item, which you can eat.
* Right-click one with a Water Bucket to scoop it into a <ItemLink id="silt_skipper_bucket"/>, and empty the bucket to release it again.

***

## <Color id="gold">Lantern Jelly</Color>

<GameScene zoom="2.4" background="#333333" interactive={true}>
  <Entity id="nautec:lantern_jelly"/>
</GameScene>

A slow, glowing jellyfish that drifts through the Bioluminescent Grove. It is passive and has little health.

Drops 1 to 2 <ItemLink id="luminous_membrane"/> (more with Looting), used for the Photophore Skin augment.

***

## <Color id="gold">Vent Crawler</Color>

<GameScene zoom="2.4" background="#333333" interactive={true}>
  <Entity id="nautec:vent_crawler"/>
</GameScene>

An armoured creature that walks the Hydrothermal Vents floor. It flees when hurt instead of fighting back, shrugs off half of any knockback, and takes no fire damage.

Drops 1 to 3 <ItemLink id="chitin_plate"/> (more with Looting). Four plates make the Vent Carapace augment.

***

## <Color id="gold">Abyssal Maw</Color>

<GameScene zoom="1.8" background="#333333" interactive={true}>
  <Entity id="nautec:abyssal_maw"/>
</GameScene>

A hostile predator of the Abyssal Trench. It only spawns in dark water below y 40, attacks players on sight from up to 24 blocks away, and chases you through the water. It has 24 health and bites for 6.

Drops one <ItemLink id="abyssal_organ"/> (more with Looting), used for the Abyssal Eyes augment.

***

## <Color id="gold">Augments</Color>

The three creature drops each make an augment: see [Deep Fauna Augments](nautec:laser_augmentation/deep_fauna_augments.md). Spawn eggs for all four creatures are in the creative menu.
