---
navigation:
  parent: crazyae2addons_index.md
  title: Samsung Galaxy S6
  icon: crazyae2addons:samsung_galaxy_s6
categories:
   - Monitoring and Automation
item_ids:
   - crazyae2addons:samsung_galaxy_s6
---

# Samsung Galaxy S6 – Structure Gadget

<ItemImage id="crazyae2addons:samsung_galaxy_s6" scale="4"></ItemImage>

The **Samsung Galaxy S6** is a handheld structure gadget that lets you **copy** and **paste** entire builds in the world.  
It works similarly to a builder’s wand, but fully integrates with AE2 energy cards, crafting cards and can autocraft missing materials.

---

## How It Works

1. **Connect to ME system**
    - Place the gadget inside a wireless access point on your network.

2. **Select Corners**
    - Right-click two opposite corners of a region with the Samsung Galaxy S6.
    - The second click also sets the **origin** and facing of the structure.

3. **Copy Structure**
    - Once corners are set, the gadget calculates the full program.
    - It consumes **FE upfront** based on block distance and size.
    - Blocks inside the region are copied and stored as a **program** on the gadget.

4. **Paste Structure**
    - Sneak + Right-click on a block face to paste the stored structure relative to that position.
    - Orientation is adjusted based on the player’s facing.
    - Requires enough FE to paste; otherwise, the action won’t start.
    - Requires all the required blocks being available in the connected ME system.
    - If it's upgraded with crafting card, it will try to craft all the required blocks if missing. 

5. **Preview & Menu**
    - Sneak + Right-click in air opens the gadget’s **GUI**.
    - Inside you can see a **3D preview** of the stored structure, flip, rotate, or mirror it.
    - Uses the same macro/programming backend as the AutoBuilder.

---

## Energy System

- **Base Capacity:** 200,000 FE
- **Upgrade Slots:** 4 (Energy Cards)
- **Bonus per Card:** +200,000 FE
- **Input Rate:** up to 25,000 FE/t
- Energy is stored directly in the item and shown on a green durability bar.

---

## Key Features

- **COPY & PASTE** entire builds with preview
- **Relative orientation** to player direction
- **3D preview in GUI** with flip/rotate tools
- **Safe placement:** detects collisions before pasting

---

## Tips

- Always check FE before copying large structures.
- The bigger the block distance, the higher the FE cost (`distance³ / 25`).
