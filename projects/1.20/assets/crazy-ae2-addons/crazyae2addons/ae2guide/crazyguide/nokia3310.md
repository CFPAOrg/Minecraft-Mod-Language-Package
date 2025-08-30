---
navigation:
  parent: crazyae2addons_index.md
  title: Nokia 3310
  icon: crazyae2addons:nokia_3310
categories:
   - Monitoring and Automation
item_ids:
   - crazyae2addons:nokia_3310
---

# Nokia 3310 – Structure Gadget

<ItemImage id="crazyae2addons:nokia_3310" scale="4"></ItemImage>

The **Nokia 3310** is a handheld structure gadget that lets you **cut** and **paste** entire builds in the world.  
It works similarly to a builder’s wand, but fully integrates with AE2 energy cards, program storage, and preview rendering.

---

## How It Works

1. **Select Corners**
    - Right-click two opposite corners of a region with the Nokia 3310.
    - The second click also sets the **origin** and facing of the structure.

2. **Cut Structure**
    - Once corners are set, the gadget calculates the full program.
    - It consumes **FE upfront** based on block distance and size.
    - Blocks inside the region are removed and stored as a **program** on the gadget.

3. **Paste Structure**
    - Sneak + Right-click on a block face to paste the stored structure relative to that position.
    - Orientation is adjusted based on the player’s facing.
    - Requires enough FE to paste; otherwise, the action won’t start.

4. **Preview & Menu**
    - Sneak + Right-click in air opens the gadget’s **GUI**.
    - Inside you can see a **3D preview** of the stored structure, flip, rotate, or mirror it.
    - Uses the same macro/programming backend as the AutoBuilder.

---

## Research Integration

- The Nokia 3310 is a required item in certain **Research Recipes**.
- To be valid, it must already contain the correct **copied structure**.
- Insert it into a **Research Station** to unlock recipes tied to that structure.

---

## Energy System

- **Base Capacity:** 200,000 FE
- **Upgrade Slots:** 4 (Energy Cards)
- **Bonus per Card:** +200,000 FE
- **Input Rate:** up to 25,000 FE/t
- Energy is stored directly in the item and shown on a green durability bar.

---

## Key Features

- **CUT & PASTE** entire builds with preview
- **Relative orientation** to player direction
- **Research integration:** required for unlocking certain recipes
- **3D preview in GUI** with flip/rotate tools
- **Safe placement:** detects collisions before pasting

---

## Tips

- Always check FE before cutting large structures.
- The bigger the block distance, the higher the FE cost (`distance³ / 25`).
- If storage is empty, you must cut again before pasting.
