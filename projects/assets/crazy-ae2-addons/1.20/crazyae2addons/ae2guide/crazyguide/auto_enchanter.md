---
navigation:
  parent: crazyae2addons_index.md
  title: Auto Enchanter
  icon: crazyae2addons:auto_enchanter
categories:
   - Monitoring and Automation
item_ids:
  - crazyae2addons:auto_enchanter
---

# Auto Enchanter

<BlockImage id="crazyae2addons:auto_enchanter" scale="4"></BlockImage>

The Auto Enchanter is a standalone enchanting machine that automatically enchants books and tools using XP Shards from your ME network. It mimics a vanilla/apotheosis enchanting. Must be placed exactly 2 blocks under a real enchanting table setup, and the enchantment power depends on the amount of books you have.

## How to Use

## [Video Tutorial](https://youtu.be/Zu213pe7Jeo&list=PLB8Rr5Xojkr5T1qoPr_4JdETiBkF4qF6r)

1. **Place the Auto Enchanter**
   - It must be placed under an Enchanting Table block (two blocks above).
   - Surround the table with bookshelves like in vanilla to improve enchantment power.

2. **Insert Items**
   - Input slot: place an item to enchant (tool, weapon, or a book).
   - Lapis slot: add lapis lazuli (required for enchanting).
   - Output slot: enchanted item will appear here.

3. **Power Requirements**
   - Requires XP Shards stored in your ME network.
   - XP cost is calculated based on bookshelfs.

4. **Select Enchantment Level**
   - In the GUI, choose between three enchantment levels (1–3).
   - Click the respective button to select an option.
   - GUI displays estimated XP cost.

5. **Automation**
   - Toggle **Auto Supply Lapis**: auto-refills lapis from the network.
   - Toggle **Auto Supply Books**: auto-refills books from the network.

## Apotheosis Support

If Apotheosis is installed:
- The Auto Enchanter will automatically scan all nearby shelves for bonus stats like Eterna, Quanta, Arcana, and Clues, including Treasure enchants.

## Behavior Summary

- Automatically pulls input and lapis if enabled.
- Spends XP Shards from your network (1 shard = 10 XP).
- Works only if a valid Enchanting Table is two blocks above.
- Produces enchanted books or items based on vanilla or Apotheosis logic.
- Optionally consumes items from network.