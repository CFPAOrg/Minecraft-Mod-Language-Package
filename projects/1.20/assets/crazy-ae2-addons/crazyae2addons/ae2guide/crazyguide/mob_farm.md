---
navigation:
  parent: crazyae2addons_index.md
  title: Mob Farm
  icon: crazyae2addons:mob_farm_wall
categories:
  - Mob Storage
item_ids:
   - crazyae2addons:mob_farm_wall
   - crazyae2addons:mob_farm_input
   - crazyae2addons:mob_farm_collector
   - crazyae2addons:mob_farm_damage_module
---

<Row>
    <BlockImage id="crazyae2addons:mob_farm_wall" scale="4"></BlockImage>
    <BlockImage id="crazyae2addons:mob_farm_damage_module" scale="4"></BlockImage>
    <BlockImage id="crazyae2addons:mob_farm_input" scale="4"></BlockImage>
    <BlockImage id="crazyae2addons:mob_farm_collector" scale="4"></BlockImage>
</Row>

# Mob Farm Controller

The Mob Farm Controller is the heart of an automatic, multi-block mob farming system. It simulates killing mobs stored in your ME network and generates drops and experience shards, and stores them directly into the system, **excluding** any **NBT** or **unstackable** items.

- **W – Mob Farm Wall Block**
- **L – Mob Farm Collector Block**
- **I – Mob Farm Input Block**
- **D – Mob Farm Damage Module Block or Mob Farm Wall Block** (machine speed depends on the amount of the damage blocks used)

#### Layer 1:
W W W W W <br/>
W W W W W <br/>
W W W W W <br/>
W W W W W <br/>
W W W W W 

#### Layer 2:
W W W W W <br/>
W L L L W <br/>
W L L L W <br/>
W L L L W <br/>
W W W W W 

#### Layer 3:
W W W W W <br/>
W D D D W <br/>
W D I D W <br/>
W D D D W <br/>
W W W W W

#### Layer 4:
W W W W W <br/>
W D D D W <br/>
W D I D W <br/>
W D D D W <br/>
W W W W W

#### Layer 5:
W W W W W <br/>
W L L L W <br/>
W L L L W <br/>
W L L L W <br/>
W W W W W

#### Layer 6:
W W W W W <br/>
W W W W W <br/>
W W W W W <br/>
W W W W W <br/>
W W W W W

## How to Use

1. **Build the Multiblock Structure**
    - Arrange blocks in a 5x5x5 cube in a pattern described above.

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
- **Only processes mobs**: You must first catch mobs using a Mob Annihilation Plane or a [Spawner Controller](spawner_controller.md).
- **No real mobs spawned**: No lag, no danger.
- **Looting Supported**: Enhance your drops easily.