---
navigation:
  title: Fishing
  icon: nautec:nautec_fishing_rod
  position: 13
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:nautec_fishing_rod
---

# <Color id="light_purple">Fishing</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="nautec_fishing_rod" scale="2"/>
  Lucky zones and the Prismatic Fishing Rod add extra loot to your catches.
</Column>

Two separate systems, and they stack. Lucky zones change where you cast, with any rod. The Prismatic Fishing Rod adds a bonus roll to every catch and a minigame when something bites. Both add to your normal catch rather than replacing it.

***

## <Color id="gold">Lucky Zones</Color>

Patches of open water that form on the surface near you while you are on an ocean or a river. Glowing spores drift over a zone and bubbles rise from it, so you can spot one from a distance.

* A zone forms within about 32 blocks of you, at most one about every 45 seconds, and never within 48 blocks of another zone.
* Its radius is 2 to 6 blocks, and it only forms where every block in that radius is open water. Expect them away from the shore.
* It lasts 5 minutes, and the first catch from it uses it up.

Cast your bobber into one. The bobber holds still inside the zone, fish bite twice as fast, and each catch gets an extra roll on the zone's loot on top of your normal catch. Any fishing rod works, including rods from other mods.

Throwing an <ItemLink id="eye_of_the_sea"/> makes zones form near you twice as often for the next 5 minutes. See [Eye of the Sea](eye_of_the_sea.md).

All of these numbers are in `config/nautec-common.toml`, along with `luckyZonesEnabled` to turn zones off.

***

## <Color id="gold">Zone Loot</Color>

Each extra roll is an ordinary catch most of the time and a treasure catch about one time in seven. Both change with the water you fish in.

| Water | Catch | Treasure |
|---|---|---|
| Anywhere | cod, salmon, Silt Skippers, Salt, Prismarine Crystal Shards | Rusty Gears, Ancient Valves, Broken Whisks, Prismarine Lenses, Crates filled with loot |
| Rivers | clay, lily pads | |
| Any ocean | tropical fish, kelp | Nautilus Shells, Atlantic Gold Nuggets |
| Abyssal Trench | Abyssal Coral, Damaged Aquatic Chips, ink sacs | Abyssal Organs, Budding Prismarine, live squid |
| Bioluminescent Grove | Luminous Membrane, Luminescent Algae, Deep Kelp, live Silt Skippers | Glow Polyps, Aquatic Chips, live Lantern Jellies |
| Hydrothermal Vents | Chitin Plates, Vent Tubeworms, magma blocks | Laser Channeling Coils, blaze powder |
| Prismarine Reef | Prismarine Fronds, prismarine shards, pufferfish, live tropical fish | Prismarine Crystal Shards, Heart of the Sea |

A live catch is a creature instead of an item: when a zone roll gives one, reeling in releases the animal at your bobber. Live cod can come up anywhere.

***

<Row>
  <ItemImage id="nautec_fishing_rod"/>
  ### <Color id="aqua">Prismatic Fishing Rod</Color>
</Row>

Casts like any rod, and adds a roll on the lucky zone loot above to every catch you reel in, wherever you fish. Inside a lucky zone you get that roll on top of the zone's own.

When something bites, a catch bar opens at the bottom of the screen for 3 seconds. Strike with Space, Enter or the left mouse button. Input in the first moment after the bar appears is ignored. The bar only opens when no other screen is open.

<Recipe id="nautec:nautec_fishing_rod"/>

***

## <Color id="gold">The Three Bars</Color>

Which bar you get is random, and it names itself at the top.

* Something is biting: one green window. Strike once while the marker is inside it.
* It is fighting you: three short windows. Strike once in each, in order.
* It is running with the line: one longer window. Press as the marker enters the green, hold, and let go before it leaves.

The panel turns green while the marker is inside a window. "Hooked it" means you won. "It slipped the hook" means you missed, and the bar stays up in red until it runs out.

The fish stays on the line while the bar runs and for 2 seconds after it closes, whether you won or missed. Reel in with right-click once the bar is gone.

***

## <Color id="gold">Rewards</Color>

* Missed or ignored: your normal catch plus the rod's one bonus roll.
* Won: your normal catch, a bonus catch roll and a bonus treasure roll, plus some experience.
* Won on a lucky treasure bite (about one time in seven): two treasure rolls and a catch roll instead.

Missing never costs you anything compared with an ordinary rod.
