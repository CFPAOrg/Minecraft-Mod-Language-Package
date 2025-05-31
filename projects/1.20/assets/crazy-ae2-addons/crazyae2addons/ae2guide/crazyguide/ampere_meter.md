---
navigation:
  parent: crazyae2addons_index.md
  title: Ampere Meter
  icon: crazyae2addons:ampere_meter
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:ampere_meter
---

# Ampere Meter

<BlockImage id="crazyae2addons:ampere_meter" scale="4"></BlockImage>

Ampere Meter is a simple block that shows how much energy flows from one side to the other. To use it, just place it touching two energy-using blocks. Right-click the block to configure it.

On the screen you’ll see an arrow button in the center. Clicking that arrow swaps which side of the block is treated as the energy input and which side is the output. You can experiment by flipping the arrow and watching how the numbers change. The main number you’ll see is an average rate calculated over a few ticks, shown in a short format like `10k FE/t` for Forge Energy or `4A (LuV)` when measuring GregTech's energy. It also works like a diode, blocking any current flowing in the opposite direction.

## Compatibility

- Works with any Forge Energy machine.
- If GregTech is installed, it also measures EU current and voltage.