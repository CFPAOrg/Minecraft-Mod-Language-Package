---
navigation:
  title: Biome Tanks
  icon: nautec:biome_tank
  position: 20
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:biome_tank
---

# <Color id="light_purple">Biome Tanks</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="biome_tank" scale="2"/>
  A sealed glass tank holding a small piece of a biome.
</Column>

A Biome Tank grows one plant on its own, with no power, water or light, so you can farm plants from biomes you are not in.

***

## <Color id="gold">Seeding a Tank</Color>

Right-click the tank with a plant to seed it. That uses one of the plant, and the tank grows that plant from then on. Right-click it with a different plant to switch: anything it has already grown comes back to you first.

A tank you break keeps its plant, so you can pick it up and move it without seeding it again.

<RecipeFor id="biome_tank"/>

***

## <Color id="gold">Growing</Color>

A seeded tank grows one of its plant every 30 seconds (`biomeTankTicks` in `config/nautec-common.toml`) and holds up to a stack. Right-click it with an empty hand to take what it has grown, or pull it out with a hopper or pipe from any face. Nothing can be put in. When the stack is full the tank stops until you empty it.

***

## <Color id="gold">Plants</Color>

| Plant | Found in |
|---|---|
| <ItemImage id="nautec:glow_polyp" scale="0.5"/> Glow Polyp | Bioluminescent Grove |
| <ItemImage id="nautec:luminescent_algae" scale="0.5"/> Luminescent Algae | Bioluminescent Grove |
| <ItemImage id="nautec:deep_kelp" scale="0.5"/> Deep Kelp | Bioluminescent Grove |
| <ItemImage id="nautec:prismarine_frond" scale="0.5"/> Prismarine Frond | Prismarine Reef |
| <ItemImage id="nautec:abyssal_coral" scale="0.5"/> Abyssal Coral | Abyssal Trench |
| <ItemImage id="nautec:vent_tubeworm" scale="0.5"/> Vent Tubeworm | Hydrothermal Vents |
| <ItemImage id="minecraft:kelp" scale="0.5"/> Kelp | Ocean |
| <ItemImage id="minecraft:seagrass" scale="0.5"/> Seagrass | Ocean |
| <ItemImage id="minecraft:sea_pickle" scale="0.5"/> Sea Pickle | Warm Ocean |
| <ItemImage id="minecraft:tube_coral" scale="0.5"/> Tube Coral | Warm Ocean |
| <ItemImage id="minecraft:brain_coral" scale="0.5"/> Brain Coral | Warm Ocean |
| <ItemImage id="minecraft:bubble_coral" scale="0.5"/> Bubble Coral | Warm Ocean |
| <ItemImage id="minecraft:fire_coral" scale="0.5"/> Fire Coral | Warm Ocean |
| <ItemImage id="minecraft:horn_coral" scale="0.5"/> Horn Coral | Warm Ocean |
| <ItemImage id="minecraft:cactus" scale="0.5"/> Cactus | Desert |
| <ItemImage id="minecraft:sugar_cane" scale="0.5"/> Sugar Cane | Riverbanks |
| <ItemImage id="minecraft:bamboo" scale="0.5"/> Bamboo | Jungle |
| <ItemImage id="minecraft:sweet_berries" scale="0.5"/> Sweet Berries | Taiga |
| <ItemImage id="minecraft:glow_berries" scale="0.5"/> Glow Berries | Lush Caves |
| <ItemImage id="minecraft:red_mushroom" scale="0.5"/> Red Mushroom | Mushroom Fields |
| <ItemImage id="minecraft:brown_mushroom" scale="0.5"/> Brown Mushroom | Mushroom Fields |
| <ItemImage id="minecraft:crimson_fungus" scale="0.5"/> Crimson Fungus | Crimson Forest |
| <ItemImage id="minecraft:warped_fungus" scale="0.5"/> Warped Fungus | Warped Forest |
| <ItemImage id="minecraft:chorus_fruit" scale="0.5"/> Chorus Fruit | The End |
| <ItemImage id="minecraft:cocoa_beans" scale="0.5"/> Cocoa Beans | Jungle |

***

## <Color id="gold">For Pack Makers</Color>

The plants a tank accepts are the `nautec:biome_tank_plants` item tag. Add any item to it, from any mod, with a datapack or KubeJS, and tanks will grow it. A tank shows its plant inside the glass using the plant's own item model, so modded plants need no extra textures. Taking a plant out of the tag stops tanks that already grow it.
