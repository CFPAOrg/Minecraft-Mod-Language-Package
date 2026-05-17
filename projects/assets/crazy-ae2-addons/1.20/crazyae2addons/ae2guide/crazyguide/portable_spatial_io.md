---
navigation:
  parent: crazyae2addons_index.md
  title: Portable Spatial Storage
  icon: crazyae2addons:portable_spatial_storage
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:portable_spatial_storage
---

# Portable Spatial Storage

<ItemImage id="crazyae2addons:portable_spatial_storage" scale="4"></ItemImage>

The **Portable Spatial Storage** is a handheld structure gadget that lets you **cut** and **paste** entire builds.

Unlike the AutoBuilder, this tool physically **removes** blocks during **CUT**, stores the structure as a program, and then **rebuilds** it elsewhere on **PASTE**.

## [Video Tutorial](https://youtu.be/2cKivPmxZ0w&list=PLB8Rr5Xojkr5T1qoPr_4JdETiBkF4qF6r)

---

## Controls

* **Shift + Right-click (on blocks):** select corners for the cut region.
* **Right-click (in air):**
   * If you have corners selected → **starts CUT**.
   * If a structure is stored → raytraces up to **50 blocks** and **pastes** onto the targeted face.
* **Right-click (on a block face):** **pastes** relative to that face (when a structure is stored).
* **Shift + Right-click (in air):** opens the **GUI** with 3D preview + transform tools.

---

## Cutting a structure

1. **Select corner 1**: Shift + right-click a block.
2. **Select corner 2**: Shift + right-click the opposite corner.
   * The **second click** also becomes the **origin** and stores the **facing** of the structure.
3. **Start CUT**: right-click **in air** (not sneaking).

What happens:

* The gadget calculates a program from all **non-air** blocks in the region.
* The operation is scheduled over time (so big cuts won’t happen in a single tick).
* After the cut finishes, the gadget stores the structure.

---

## Pasting a structure

* If the gadget has a stored structure, **right-click** to paste.

   * Clicking a **block face** pastes relative to that face.
   * Right-clicking **in air** raytraces up to **50 blocks** to find a target.

Safety checks:

* Before it starts, it checks every target position. If any position cannot be replaced, the paste is blocked.

Important behavior:

* After energy is paid, the gadget **clears its stored structure immediately** and then performs the paste over time.

---

## Orientation and transforms

* The paste orientation is based on the structure’s stored **source facing**, plus any transforms you apply in the **GUI**:
   * **Flip Horizontal**
   * **Flip Vertical**
   * **Rotate**

---

## Energy and upgrades

* **Base capacity:** 200,000 (shown as an energy bar / tooltip)
* **Upgrade slots:** 4
* **Energy Cards:** increase max capacity 

### Energy cost

Energy cost scales with **distance from the origin** for each copied block:

* per-block cost: distance(origin, block) * cost (default 5)
* total cost: sum of all per-block costs for all non-air blocks in the region

(Exact multiplier is configurable)

