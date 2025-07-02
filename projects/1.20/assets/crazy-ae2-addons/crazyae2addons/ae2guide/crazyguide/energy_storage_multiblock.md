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
   - crazyae2addons:energy_storage_port
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

<GameScene zoom="1" interactive={true}>
  <ImportStructure src="../assets/energy_storage.nbt" />
</GameScene>

## The storage blocks are only used by the controller to project the energy onto something, but all power is stored inside. If you break the controller, you will loose all that stored bilions of AE power units forever!

The Energy Storage is a multiblock power battery for your ME network. It provides massive AE storage by assembling a structure out of controller, storage, and frame blocks.

Once active, it integrates as a proper AE2 power storage, supplying or accepting energy like any AE2-compatible battery.
It also has 3 Energy Ports, you can use each of them to connect this multiblock directly to FE to both power it, or extract energy from it.

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