---
navigation:
  parent: crazyae2addons_index.md
  title: Auto Builder
  icon: crazyae2addons:auto_builder
categories:
   - Monitoring and Automation
item_ids:
   - crazyae2addons:auto_builder
---

# AutoBuilder

# [How to program it](auto_builder_language.md)

<BlockImage id="crazyae2addons:auto_builder" scale="4"></BlockImage>

The AutoBuilder is a programmable building robot powered by AE2. 
It reads a special **Builder Pattern Item** and places or removes blocks in the world based on its instructions.

---

## How It Works

1. **Create a Pattern**
   - Use the Builder Pattern Item to select two corners in the world (r-click to select first corner, shift r-click to select another).
   - Right click air to copy the structure and save it to the item.
   - All blocks inside will be scanned and converted into a build pattern.

2. **Edit the Pattern (Optional)**
   - Shift Right-click the Builder Pattern Item to open a text editor GUI.
   - You can adjust delay, add commands like resets, removals, loops, or macros.
   - The number on the right is the delay added in between all commands in ticks (default 20 ticks or 1 sec), set to 0 for it to work the fastest.

3. **Insert Pattern**
   - Place the pattern item into the **AutoBuilder** block.
   - Only one pattern can be inserted at a time.
   - You can use automation to insert/extract patterns out of the block.

4. **Provide Power and Items**
   - Connect the AutoBuilder to an ME network.
   - Make sure the required building materials are available in storage.
   - Supports crafting card.

5. **Trigger Building**
   - Use a redstone signal from the top to start the program.
   - The builder will move step by step and build according to the pattern.
   - When finished, it emits a short redstone pulse on its sides.
   - Acceleration cards make it work much faster.

---

## Key Features

- **Builds complex structures from patterns**
- **Full AE2 storage and power integration**
- **Redstone-controlled execution**
- **Block replacement with recycling** (old block is put back into storage)
- **Real-time ghost block preview** of building position