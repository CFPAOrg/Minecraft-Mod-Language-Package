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
---

# Penrose Sphere

<Row>
   <BlockImage id="crazyae2addons:penrose_controller" scale="4"></BlockImage>
   <BlockImage id="crazyae2addons:penrose_frame" scale="4"></BlockImage>
   <BlockImage id="crazyae2addons:penrose_coil" scale="4"></BlockImage>
</Row>

The Penrose Sphere is a late-game multiblock power generator that filled with **Super Singularities** converts **matter** into Forge Energy (FE). It is a very scalable power source.

---

## Structure Overview

The structure is a 7x7x3 multiblock. It includes Penrose Frames, Penrose Coils, and mandatory air gaps.

- **F** – Penrose Frame Block
- **E** – Penrose Coil Block
- **C** – Penrose Controller Block
- **A** – Air 

#### Layer 1:
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F C F F F

#### Layer 2:
F E E E E E F<br/>
E A A A A A E<br/>
E A A A A A E<br/>
E A A F A A E<br/>
E A A A A A E<br/>
E A A A A A E<br/>
F E E E E E F

#### Layer 3:
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F

Once built, the frame blocks will visually indicate if the structure is complete.

---

## How It Works

1. **Insert Storage Cell**
   - Only accepts **4k Storage Cells** containing only Super Singularities.
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

---

## Power Output

- Minimum is 1024FE/t with 1 super singularity and with "normal" item as input.
- Matter Balls and Singularities increase output:
  - **+8x** if Matter Ball is selected
  - **+64x** if AE2 Singularity is selected
- Max power: ~1'000MFE/t (4x mek fusion) (with a full Cell and singularities as fuel)

---

## Notes

- Multiblock must be complete to function.
- Controller stores power internally.
- Energy can be extracted from any Penrose Frame block.
- Compatible with any FE-based system.
