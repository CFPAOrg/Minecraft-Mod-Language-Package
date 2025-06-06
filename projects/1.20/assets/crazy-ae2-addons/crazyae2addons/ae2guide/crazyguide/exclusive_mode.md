---
navigation:
  parent: crazyae2addons_index.md
  title: Exclusive Mode
  icon: crazyae2addons:crafting_guard
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:crafting_guard
---

# Exclusive Mode

<BlockImage id="crazyae2addons:crafting_guard" scale="4"></BlockImage>

The Crafting Guard is a special block that prevents multiple Pattern Providers from sending inputs to the same machine during the same tick. This helps avoid overlapping crafting jobs or inconsistent behavior with setting circuits on GT machines.

## How to Use

1. **Place a Crafting Guard Block**
    - Put it anywhere in your ME network. Only one Crafting Guard is allowed per network — placing a second one will destroy the new one automatically.

2. **Enable Exclusive Mode on Pattern Providers**
    - Open a Pattern Provider GUI.
    - Switch **Blocking Mode** to "Yes".
    - Then enable the new **Exclusive Mode** toggle that appears.
    - Now, this pattern provider will skip machines that have already received items during that same tick.

---

## How It Works

- When a Pattern Provider pushes items, the Crafting Guard records which machine was used.
- During the same server tick, other pattern providers in **exclusive mode** will skip that machine.
- This prevents race conditions when multiple jobs try to set circuit at the same GT machine at once.

---

## Notes

- **Only one Crafting Guard per network** is allowed.
- Requires Pattern Provider to be in both Blocking Mode and Exclusive Mode.
