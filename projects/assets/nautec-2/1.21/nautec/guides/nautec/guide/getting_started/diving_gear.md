---
navigation:
  title: Diving Suit and Oxygen
  icon: nautec:diving_helmet
  position: 10
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:brown_polymer
  - nautec:diving_chestplate
  - nautec:diving_helmet
  - nautec:diving_leggings
  - nautec:diving_boots
  - nautec:air_bottle
---

# <Color id="light_purple">Diving Suit and Oxygen</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="diving_helmet" scale="2"/>
  A four piece suit that carries up to ten minutes of air.
</Column>

Wear all four pieces and the chestplate's air tank keeps your breath full under water. Each second you are submerged it spends one second of air and tops your air bar back up. When the tank runs out, your air drains as normal.

With all four pieces on you also mine under water as fast as on dry land, even while swimming or floating: the suit cancels both the underwater slowdown and the slowdown for not standing on the ground.

The suit's armor is close to a full set of iron, and it repairs with Copper Ingots on an anvil.

***

## <Color id="gold">The Pieces</Color>

<Row>
  <ItemImage id="diving_helmet"/>
  ### <Color id="aqua">Diving Helmet</Color>
</Row>

Clears the underwater fog so you can see much further. This works on its own, without the rest of the suit.

<Recipe id="nautec:diving_helmet"/>

<Row>
  <ItemImage id="diving_chestplate"/>
  ### <Color id="aqua">Diving Chestplate</Color>
</Row>

Holds the air tank, up to 10 minutes. A new chestplate comes with a full tank. Its tooltip shows how much is left, and under water the tank shows as a row of bubbles over your hotbar. When the tank runs dry, that row turns to empty bubbles as a warning to refill it.

<Recipe id="nautec:diving_chestplate"/>

<Row>
  <ItemImage id="diving_leggings"/>
  ### <Color id="aqua">Diving Leggings and Boots</Color>
</Row>

Needed to complete the set. The tank only works with all four pieces on.

<Recipe id="nautec:diving_leggings"/>

<Recipe id="nautec:diving_boots"/>

***

## <Color id="gold">Filling the Tank</Color>

<Row>
  <ItemImage id="air_bottle"/>
  ### <Color id="aqua">Pressurized Air Bottle</Color>
</Row>

Right-click a bubble column with an empty Glass Bottle to fill it with pressurized air. Any bubble column works, from soul sand or from magma. Geode barrels also hold a few.

To fill the tank, craft the chestplate surrounded by eight bottles. That gives a full ten minute tank and hands back the empty bottles. The chestplate comes out as a new item, so enchantments on the old one are lost. To keep an enchanted chestplate, drink bottles instead.

<Recipe id="nautec:diving_chestplate_oxygen"/>

You can also drink a bottle while wearing the chestplate. Each bottle adds 2 minutes of air whenever the tank is not full, up to the full 10 minutes, so five bottles fill an empty tank. Drinking also makes you float upward for 10 seconds.

### <Color id="aqua">Oxygen Fluid</Color>

The chestplate also takes oxygen fluid from other mods, such as Stellaris oxygen. Put it in any machine or tank slot that fills items with fluid. Each mB of oxygen adds one second of air, so 600 mB fills an empty tank.

***

<Row>
  <ItemImage id="brown_polymer"/>
  ### <Color id="aqua">Brown Polymer</Color>
</Row>

The material the suit is made of. Craft it from Dried Kelp and Brown Dye, or find it in crates and geode barrels. Spare polymer also crafts into books, beds, banners and item frames.

<Recipe id="nautec:brown_polymer"/>

***

## <Color id="gold">With Stellaris</Color>

If Stellaris is installed, the full Diving Suit also keeps you alive on planets with no air. The tank spends one second of air for each second you spend outside a breathable area, and the bubble row shows over your hotbar there too. Inside an Oxygen Distributor's area the tank is left alone.

Drinking an Air Bottle while wearing a Stellaris space suit helmet with an oxygen module adds 120 mB of oxygen to the helmet, the same 2 minutes of air it gives the diving tank.

***

## <Color id="gold">Other Ways to Breathe</Color>

* The [Sea Scout](nautec:submarine/submarine.md) keeps everyone inside breathing while it has power.
* Holding thrust on the [Wave Jet](nautec:submarine/wave_jet.md) stops your air bar draining.
* A full Stellaris space suit lets you breathe under water while its helmet has oxygen.
* The Drowned Lungs augment keeps your air full whenever you are under water: see [Mob Augments](nautec:laser_augmentation/mob_augments.md).
