---
navigation:
  parent: crazyae2addons_index.md
  title: Mob Farm
  icon: crazyae2addons:mob_farm_controller
categories:
  - Mob Storage
item_ids:
   - crazyae2addons:mob_farm_wall
   - crazyae2addons:mob_farm_input
   - crazyae2addons:mob_farm_collector
   - crazyae2addons:mob_farm_damage
   - crazyae2addons:mob_farm_controller
---

<GameScene zoom="2" interactive={true}>
  <ImportStructure src="../assets/mob_farm.nbt" />
</GameScene>

# Mob Farm Controller

The Mob Farm Controller is the heart of an automatic, multi-block mob farming system. It simulates killing mobs stored in your ME network and generates drops and experience shards, and stores them directly into the system, **excluding** any **NBT** or **unstackable** items.

## [Video Tutorial](https://youtu.be/MUKyq0IDi3M&list=PLB8Rr5Xojkr5T1qoPr_4JdETiBkF4qF6r)

## How to Use

1. **Build the Multiblock Structure**
    - Arrange blocks in a 5x5x6 cube in a pattern described above.

2. **Power the Controller**
    - Connect the Mob Farm Controller to an active ME network.

3. **Setup in GUI**
    - Configure which mobs should be processed.
    - Optional: Set the item that will be used to kill the mobs.

4. **Insert Upgrade Cards (Optional)**
    - Install Looting/Experience/Acceleration Upgrade Cards.

---

## How It Works

- The farm "consumes" mobs taken from the ME Storage.
- Calculates drops based on the mob's loot table, and deletes all nbt items or unstackables.
- Generates experience shards.
- Drops and XP shards are inserted back into the ME network.
- More Damage Modules = faster kill speed.
- Speed Cards further boost the processing rate. (Max 64 mobs/s)

---

## Important Notes

- **Requires correct multiblock structure**: If broken, the farm will stop.
- **Only processes mobs**: You must first catch mobs using a Mob Annihilation Plane or a [Spawner Extractor](spawner_extractor.md).
- **No real mobs spawned**: No lag, no danger.
- **Looting Supported**: Enhance your drops easily.