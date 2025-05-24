---
navigation:
  parent: crazyae2addons_index.md
  title: Impulsed Pattern Provider
  icon: crazyae2addons:impulsed_pattern_provider
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:impulsed_pattern_provider
---

# AE2 way of dealing with chanced recipes

# Impulsed Pattern Provider

<BlockImage id="crazyae2addons:impulsed_pattern_provider" scale="4"></BlockImage>

The Impulsed Pattern Provider is a specialized crafting block that sends the last used pattern when triggered by a redstone signal.

## How to Use

1. **Place the block**: Attach the Impulsed Pattern Provider to your ME network like a normal Pattern Provider.
2. **Open its GUI**: Right click the block to access its interface.
3. **Insert patterns**: Add any processing patterns into the grid slots as usual.
4. **Trigger crafting**: Apply a redstone pulse to the block. Each rising edge will push the last used pattern into the connected machine again.

This way you can automate recipes with **chanced outputs**. The most basic setup would work like this. When the machine fails to produce your desired thing, detect that (for example using the [Signalling Interface](signalling_interface.md)) and send redstone pulse to the provider. It will push the pattern again.  