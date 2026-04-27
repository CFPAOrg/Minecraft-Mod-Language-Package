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

It one extra feature: when you use a pattern that carries a "circuit" tag (set with the Crazy Pattern Modifier),
*almost* any pattern provider will automatically load that circuit into every connected GregTech machine before crafting.

- Works through interface + storage bus combo (storage bus must be upgraded with the circuit upgrade card).
- Works through pattern P2P's from modern AE2 additions.
- Works also through the combo of the pattern P2P + interface + storage bus.

## [Video Tutorial](https://youtu.be/xhu6xvmIjI0&list=PLB8Rr5Xojkr5T1qoPr_4JdETiBkF4qF6r)

## How to Use

1. **Place the block**: Attach the Pattern Provider to your network.
2. **Prepare patterns**: Use the Crazy Pattern Modifier on any processing pattern to assign a circuit ID (1–32).
3. **Open the interface**: Right-click the Pattern Provider to insert and manage your encoded patterns.
4. **Crafting**: When you request a craft, before the provider pushes the pattern to the connected machines, it sets each machine’s circuit inventory to the one encoded in the currently used pattern.
5. **Enjoy**: No manual circuit cards needed, any GregTech machines hooked up will automatically pick up the correct circuit every time.