---
navigation:
  parent: crazyae2addons_index.md
  title: Circuited Pattern Provider
  icon: ae2:pattern_provider
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:circuit_upgrade_card
---

# Circuited Pattern Provider

# Available only when GregTech is also on the mod list.

# **The block itself has been deleted from the mod, as its function is now held by all other pattern providers!**

The Circuited Pattern Provider is a drop-in replacement for the standard AE2 Pattern Provider. It adds one extra feature: when you use a pattern that carries a "circuit" tag (set with the Crazy Pattern Modifier), the provider will automatically load that circuit into every connected GregTech machine before crafting.

- Works through interface + storage bus combo (storage bus must be upgraded with the circuit upgrade card).
- Works through pattern P2P's from modern AE2 additions.
- Works also through the combo of the pattern P2P + interface + storage bus.

## How to Use

1. **Place the block**: Attach the Circuited Pattern Provider to your ME network just like a normal Pattern Provider.
2. **Prepare patterns**: Use the Crazy Pattern Modifier on any processing pattern to assign a circuit ID (1–32).
3. **Open the interface**: Right-click the Circuited Pattern Provider to insert and manage your encoded patterns.
4. **Crafting**: When you request a craft, before the provider pushes the pattern to the connected machines, it sets each machine’s circuit inventory to the one encoded in the currently used pattern.
5. **Enjoy**: No manual circuit cards needed, any GregTech machines hooked up will automatically pick up the correct circuit every time.