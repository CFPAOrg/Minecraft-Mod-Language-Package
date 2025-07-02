---
navigation:
  parent: crazyae2addons_index.md
  title: Penrose Sphere
  icon: crazyae2addons:penrose_controller
categories:
  - Energy and Item Transfer
item_ids:
   - crazyae2addons:penrose_controller
   - crazyae2addons:penrose_frame
   - crazyae2addons:penrose_coil
   - crazyae2addons:penrose_port
---

# Penrose Sphere

<GameScene zoom="0.5" interactive={true}>
  <ImportStructure src="../assets/penrose_sphere.nbt" />
</GameScene>

The Penrose Sphere is a late-game multiblock power generator that filled with **Super Singularities** converts **matter** into Forge Energy (FE). It is a very scalable power source.

---

## How It Works

1. **Insert Storage Cell**
   - Only accepts **1k Storage Cells** containing only Super Singularities.
   - Insert into the left slot (disk slot).

2. **Insert Super Singularities**
   - Place Super Singularities into the right slot (input) and click the arrow button to store/extract singularities from/to the cell.
   - The more super singularities are inside the cell, the more power multiblock will generate.

3. **Set Target Resource**
   - Use the config slot to choose a target item (e.g., Cobblestone, Singularity or Matter Ball).
   - This determines how much energy is produced. 

4. **Automatic Power Generation**
   - Every tick, the controller consumes the target item from your ME network.
   - Generates FE based on the amount of Super Singularities in the disk.
   - Power is accessible from any Penrose Frame block.
   - All Power Ports are actively exporting the power to adjacent blocks.

5. **Upgrades**
   - It has 4 tiers, each next tier adds +1 storage cell slot, meaning you can insert more singularities, and make more power.
   - Each tier additionally boosts the power gen by x2.

---

## Power Output

- Minimum is close to 0, with 1 super singularity and with "normal" item as input.
- Matter Balls and Singularities increase output:
  - **+8x** if Matter Ball is selected
  - **+64x** if AE2 Singularity is selected
- Max power: ~1'000MFE/t (4x mek fusion) (with a full 4 cells and singularities as fuel)

---

## Notes

- Multiblock must be complete to function.
- Controller stores power internally.
- Energy can be extracted from any Penrose Frame block.
- Energy is being actively exported from any Penrose Port block.
- Compatible with any FE-based system.
- Can charge your ME network as well as anything that accepts FE.
