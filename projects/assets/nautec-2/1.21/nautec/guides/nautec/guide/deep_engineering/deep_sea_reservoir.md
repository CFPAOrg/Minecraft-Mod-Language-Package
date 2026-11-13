---
navigation:
  title: Deep Sea Reservoir
  icon: nautec:deep_sea_reservoir
  position: 15
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:deep_sea_reservoir
  - nautec:reservoir_upgrade_2
  - nautec:reservoir_upgrade_3
  - nautec:reservoir_upgrade_4
---

# <Color id="light_purple">Deep Sea Reservoir</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="deep_sea_reservoir" scale="2"/>
  A 3x3x3 tank that holds one fluid in quantities no other tank comes close to.
</Column>

## <Color id="gold">Placing It</Color>

The Reservoir is one item that fills a 3x3x3 space. Place it on a block and it builds itself in the 3x3x3 above that block, centered on it, with its gauge facing you. Every block in that space has to be empty first (air, water, or plants you could build over), so it works on the sea floor too.

If water reaches a Reservoir that was built dry, it floods through the frame the way water flows: across from the sides and down from above, never up from below.

Breaking any part of it takes the whole Reservoir down as a single item. That item keeps its tier and every drop of fluid inside, so you can move a full Reservoir anywhere.

***

## <Color id="gold">Filling and Emptying</Color>

* Every outside face of every block in the 3x3x3 reaches the same tank, so pipes can connect wherever they touch it.
* Right-click with a bucket or other fluid container to fill or empty it.
* Right-click with an empty hand to open it. Clicking the gauge in the screen with a fluid container on your cursor fills or empties it too.
* The glass strip on the front shows the fluid inside, filled to its current level.
* A Comparator reads how full it is.

It holds one fluid at a time. Once it is completely empty, it takes any fluid again.

***

## <Color id="gold">Tiers</Color>

| Tier | Holds | Upgrade |
|---|---|---|
| I | 500,000,000 buckets | the base Reservoir |
| II | 2,000,000,000 buckets | <ItemLink id="reservoir_upgrade_2"/> |
| III | 10,000,000,000 buckets | <ItemLink id="reservoir_upgrade_3"/> |
| IV | 50,000,000,000 buckets | <ItemLink id="reservoir_upgrade_4"/> |

Each tier changes the Reservoir's look: a steel frame and riveted bands at II, copper bands, pipes and a valve wheel at III, and glowing prismarine crystal trim at IV.

Upgrades go on in order. Right-click the Reservoir with the next one, or put it in the upgrade slot in the screen, and it applies straight away.

**Remove Upgrade** in the screen takes the top upgrade back out and gives it to you, dropping the Reservoir one tier. If the fluid inside would not fit the lower tier, the button asks you to click a second time and says how much will be lost. Anything over the lower tier's capacity is voided.

***

## <Color id="gold">Crafting</Color>

<Recipe id="nautec:deep_sea_reservoir"/>

<Recipe id="nautec:reservoir_upgrade_2"/>

<Recipe id="nautec:reservoir_upgrade_3"/>

<Recipe id="nautec:reservoir_upgrade_4"/>

The capacity of each tier is in `config/nautec-common.toml`.
