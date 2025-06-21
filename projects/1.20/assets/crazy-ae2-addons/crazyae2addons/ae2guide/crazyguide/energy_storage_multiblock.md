---
navigation:
  parent: crazyae2addons_index.md
  title: Energy Storage Multiblock
  icon: crazyae2addons:energy_storage_controller
categories:
  - Energy and Item Transfer
item_ids:
   - crazyae2addons:energy_storage_controller
   - crazyae2addons:energy_storage_frame
   - crazyae2addons:energy_storage_1k
   - crazyae2addons:energy_storage_4k
   - crazyae2addons:energy_storage_16k
   - crazyae2addons:energy_storage_64k
   - crazyae2addons:energy_storage_256k
   - crazyae2addons:dense_energy_storage_1k
   - crazyae2addons:dense_energy_storage_4k
   - crazyae2addons:dense_energy_storage_16k
   - crazyae2addons:dense_energy_storage_64k
   - crazyae2addons:dense_energy_storage_256k
---

# Energy Storage Controller

<Row>
   <BlockImage id="crazyae2addons:energy_storage_controller" scale="4"></BlockImage>
   <BlockImage id="crazyae2addons:energy_storage_frame" scale="4"></BlockImage>
   <BlockImage id="crazyae2addons:energy_storage_16k" scale="4"></BlockImage>
   <BlockImage id="crazyae2addons:dense_energy_storage_64k" scale="4"></BlockImage>
</Row>

## The storage blocks are only used by the controller to project the energy onto something, but all power is stored inside. If you break the controller, you will loose all that stored bilions of AE power units forever!

The Energy Storage is a multiblock power battery for your ME network. It provides massive AE storage by assembling a structure out of controller, storage, and frame blocks.

Once active, it integrates as a proper AE2 power storage, supplying or accepting energy like any AE2-compatible battery.

---

## How to Build

Construct a 7x7x7 cube with specific block types:

- **F** – Energy Storage Frame Block
- **G** – Vibrant Quartz Glass
- **O** – Energy Storage Blocks (from 1k up to 256k, or Dense variants)
- **C** – Energy Storage Controller (only one)

### Layer 1 (Bottom):
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F C F F F

### Layers 2–6:
Each layer follows this same layout:
F G G G G G F<br/>
G O O O O O G<br/>
G O O O O O G<br/>
G O O O O O G<br/>
G O O O O O G<br/>
G O O O O O G<br/>
F G G G G G F

### Layer 7 (Top):
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F

---

## How It Works

- The structure activates once complete.
- Storage capacity depends on the type and count of storage blocks inside:
- Dense variants are scaled to billions of FE
- You can use **Ampere Meter** or other mods to monitor throughput.

The controller integrates with AE2’s internal energy grid and behaves just like a battery — but with insane capacity.

---

## Notes

- Only one controller is allowed per structure.
- If the structure (not controller) is broken, the energy is still in the controller but inaccessible until the structure is built again.