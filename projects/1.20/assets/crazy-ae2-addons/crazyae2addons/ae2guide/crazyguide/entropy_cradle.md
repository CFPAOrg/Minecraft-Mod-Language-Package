---
navigation:
  parent: crazyae2addons_index.md
  title: Entropy Cradle Multiblock
  icon: crazyae2addons:entropy_cradle_controller
categories:
  - Crafting and Patterns
item_ids:
   - crazyae2addons:entropy_cradle_controller
   - crazyae2addons:entropy_cradle_capacitor
   - crazyae2addons:entropy_cradle
---

# Entropy Cradle

<GameScene zoom="1" interactive={true}>
  <ImportStructure src="../assets/entropy_cradle.nbt" />
</GameScene>

The **Entropy Cradle** is a massive energy accumulator and transmutation multiblock.  
It stores up to **600 million FE**, and performs powerful **block transmutations** when fully charged.

---

## How It Works

1. **Charge**:
    - Charging stops at 600M FE.
    - Six capacitor layers light up progressively.
    - Capacitors emit comparator signal when the energy storage is full.

2. **Transmutation**:
    - On redstone pulse at full charge:
        - Cradle discharges.
        - If a known recipe structure is inside of it, it is replaced with a powerful block (e.g., Penrose Frame, Energy Storage Component).

---

## Notes

- Requires AE2 power and channels.
- Can be charged only via AE energy.
- You can find available recipes in JEI/EMI.
- You can fully automate crafting with it using the builder.
