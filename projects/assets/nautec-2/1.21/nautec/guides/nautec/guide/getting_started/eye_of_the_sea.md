---
navigation:
  title: Eye of the Sea
  icon: nautec:eye_of_the_sea
  position: 15
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:eye_of_the_sea
---

# <Color id="light_purple">Eye of the Sea</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="eye_of_the_sea" scale="2"/>
  An ocean Eye of Ender that you keep. Throw it and it flies toward the nearest structure it is seeking.
</Column>

***

## <Color id="gold">Throwing It</Color>

Right-click to throw the eye. It hums for a moment while it searches (a message above your hotbar says so, and you cannot throw it again until the search ends), then it rises and flies toward the nearest matching structure, the same way an Eye of Ender does, then bursts into bubbles after about four seconds. It never drops and is never used up, so you can throw it as often as you like, with a two second wait between throws.

If nothing matching is within about 1,600 blocks (3,200 blocks for a biome), the eye stays in your hand and a message says so.

Crystal Geodes are buried under the ocean floor, so when the eye starts circling or dropping, the middle of the geode is under you. Dig straight down from there.

***

## <Color id="gold">Changing the Target</Color>

Sneak and right-click to switch what the eye seeks. The tooltip and a message above your hotbar show the current target. In order:

| Target | Finds |
|---|---|
| Crystal Geodes | the stone and deepslate geodes holding a <ItemLink id="prismarine_crystal"/> |
| NauTec Ruins | the dark prismarine arches with an <ItemLink id="aquatic_catalyst"/> |
| Research Outposts | the sunken research stations, see [Structures](structures.md) |
| Gateways | the Underwater Gateway platforms, see [Gateway](nautec:deep_engineering/gateway.md) |
| Ocean Ruins | vanilla cold and warm ocean ruins |
| Ocean Monuments | vanilla ocean monuments |
| Prismarine Reefs | the nearest Prismarine Reef biome, the best place for <ItemLink id="budding_prismarine"/> |
| Abyssal Trenches | the nearest Abyssal Trench biome |
| Bioluminescent Groves | the nearest Bioluminescent Grove biome |
| Hydrothermal Vents | the nearest Hydrothermal Vents biome |

A new eye starts on Crystal Geodes, and each eye remembers its own target. Gateways you build yourself are not targets. A biome target flies to the edge of the nearest patch of that biome. See [Structures](structures.md) for what each one holds.

***

## <Color id="gold">Luck on the Water</Color>

Every throw that finds a target also stirs up the water around you. For the next 5 minutes, [lucky fishing zones](fishing.md) form near you twice as often. Throwing again restarts the 5 minutes.

***

## <Color id="gold">Crafting</Color>

An Ender Pearl and a Prismarine Shard, crafted together in any arrangement.

<Recipe id="nautec:eye_of_the_sea"/>

The search range, the wait between throws, and the length and strength of the fishing boost are in `config/nautec-common.toml`.
