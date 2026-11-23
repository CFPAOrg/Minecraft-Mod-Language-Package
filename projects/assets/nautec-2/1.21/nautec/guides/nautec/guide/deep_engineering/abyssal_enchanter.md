---
navigation:
  title: Abyssal Enchanter
  icon: nautec:abyssal_enchanter
  position: 16
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:abyssal_enchanter
---

# <Color id="light_purple">Abyssal Enchanter</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="abyssal_enchanter" scale="2"/>
  Enchants books and items to the exact enchantment you pick, paid for with a reagent, liquid experience and a laser beam.
</Column>

## <Color id="gold">Placing It</Color>

The Enchanter is one item that fills a 3x3 space two blocks tall, centered on the block you place it in. Every block in that space has to be empty first, so it can be built underwater too. Breaking any part of it takes the whole Enchanter down as a single item, along with whatever is inside.

While it works, the ring of broken stone around it lifts and turns, the core in its pillar lights up and a column of light rises over the pedestal.

***

## <Color id="gold">Enchanting</Color>

1. Put a book, or any item that can take the enchantment, in the top slot.
2. Put the reagent in the slot below it. The reagent decides the enchantment: quartz for Sharpness, redstone for Efficiency, obsidian for Unbreaking and so on. JEI lists every one under **Laser Enchanting**.
3. Pick the level with the arrows in the screen. It starts at the highest level.
4. Fill the tank with liquid experience, then aim a beam at any outside face of any block of the Enchanter.

Each level needs one set of reagent, so Sharpness V takes five times the quartz of Sharpness I. When it finishes, the book or item goes to the output slot. An item that already has the enchantment at a lower level is raised to the new level.

If more than one enchantment uses the same reagent, the **»** button switches between them.

***

## <Color id="gold">Overenchanting</Color>

The Enchanter can go up to five levels past an enchantment's normal max, so Sharpness can reach X. Raise the level past the max with the arrows and the level shows in gold.

Each level past the max costs four times the total AP and liquid experience of the level before it: Sharpness VI costs 4x, Sharpness VII 16x and Sharpness X 1,024x. The beam it needs keeps rising on its usual curve, and the reagent stays at the amount for the normal max.

Only items can be overenchanted. With a book in the top slot the level stops at the normal max, so put the sword, pickaxe or armor piece itself in the Enchanter.

***

## <Color id="gold">Liquid Experience</Color>

The tank takes any liquid experience (the `c:experience` fluid tag), including Experience Algae and the experience fluids of other mods, and nothing else. It holds about 2.1 million buckets, and pipes can pull it back out if you put in too much. 20 mB counts as one experience point.

***

## <Color id="gold">Beam Power</Color>

An enchantment has two costs in AP:

* The **beam** it needs before it starts at all.
* The **total** it has to take in before it finishes. A stronger beam than the minimum finishes sooner.

Both rise steeply with the level and with how rare the enchantment is. Sharpness I needs a 10 AP beam, Sharpness V a 250 AP beam and 250,000 AP in total, and Thorns III a 720 AP beam. Treasure enchantments such as Mending cost double. The screen and JEI show the exact figures.

***

## <Color id="gold">Purity</Color>

At a beam purity of **3.0** or more, you always get exactly the enchantment and level you picked. Below that the result can change, more often the lower the purity:

* The level can drift, usually down by one and sometimes up by one.
* It can become a different enchantment that fits the same item.
* It can give you the enchantment you picked plus a random extra one at level I.

Below purity **0.5** there is also a chance of a curse being added on top. The book or item is never destroyed, and the screen shows how stable the current beam is.

***

## <Color id="gold">Crafting</Color>

<Recipe id="nautec:abyssal_enchanter"/>

The power, experience, purity, curse and overenchanting settings are in `config/nautec-common.toml`. Pack makers can add their own reagents with `nautec:laser_enchanting` recipes.

To keep an enchantment out of the Enchanter, list its id in `abyssalEnchanterBlacklist` in that config (`modid:*` blocks a whole mod), or add it to the `nautec:abyssal_enchanter_blacklist` enchantment tag. A blocked enchantment can't be made, never comes out of a low purity result and is hidden from JEI. Ars Elemental's Soulbound is blocked by default.
