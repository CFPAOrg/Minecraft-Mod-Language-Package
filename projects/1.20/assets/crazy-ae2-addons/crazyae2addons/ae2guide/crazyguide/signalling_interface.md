---
navigation:
  parent: crazyae2addons_index.md
  title: Signalling Interface
  icon: crazyae2addons:signalling_interface
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:signalling_interface
---

# Signalling Interface

<BlockImage id="crazyae2addons:signalling_interface" scale="4"></BlockImage>

The best companion of the [Impulsed Pattern Provider](impulsed_pattern_provider.md)

The Signalling Interface is a smart block that emits a redstone pulse whenever selected items change in quantity. It’s perfect for creating automatic alerts, gating systems, or triggering other redstone-based machines when materials arrive or leave your storage.

## How to Use

1. **Place the block**: Attach the Signalling Interface to any ME cable.
2. **Open its GUI**: Right click to access the configuration screen.
3. **Configure watch items**:
    - The top rows are your *config slots*. Place the items you want to monitor into these slots.
    - Use the wrench icon buttons next to each slot to set the exact count threshold you care about (for example, trigger when you gain 64 of an item). It also works like a normal interface, so it will supply those items to those slots from your ME network.
4. **Connect redstone**: Run redstone dust or wire from any side of the block. Each time the tracked item count crosses your configured threshold (or changes by at least that amount), the block will emit a short redstone pulse.

## Upgrades

- **Redstone Card**: Enables the interface to emit output pulses when thresholds are crossed.
- **Inverter Card**: Flips the trigger, so you get pulses on removals or when counts go below thresholds instead of on additions.
- **Fuzzy Card**: Allows wildcard NBT matching for items, useful for monitoring enchanted or custom-tagged items.
