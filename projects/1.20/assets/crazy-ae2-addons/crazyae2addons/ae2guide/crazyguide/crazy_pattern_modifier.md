---
navigation:
  parent: crazyae2addons_index.md
  title: Crazy Pattern Modifier
  icon: crazyae2addons:crazy_pattern_modifier
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:crazy_pattern_modifier
---

# Crazy Pattern Modifier

<ItemImage id="crazyae2addons:crazy_pattern_modifier" scale="4"></ItemImage>

The Crazy Pattern Modifier is a versatile item that lets you tweak your AE2 processing patterns.

You can choose to ignore NBT data, so patterns that normally require specific enchantments or item tags will accept any matching item.

You can also encode a specific circuit ID onto a pattern for use with Circuited Pattern Provider + GregTech's machines.

## How to Use

Hold the Crazy Pattern Modifier in your hand and right-click to open its interface. You’ll see a single slot where you place your processing pattern item. Two buttons let you change settings:

- **Ignore NBT**: Click the NBT button to toggle whether the pattern ignores NBT tags. When on, you can craft items like enchanted books without specifying exact enchantments.
- **Set Circuit**: If GregTech is installed, enter a number (1–32) in the text field and click confirm to assign that circuit to the pattern. If the pattern is then used with Circuited Pattern Provider, it will set this circuit to all machines it’s connected to.

As you make changes, the screen shows messages indicating the current mode (for example, "Current: ignore NBT" or "Selected circuit 5").