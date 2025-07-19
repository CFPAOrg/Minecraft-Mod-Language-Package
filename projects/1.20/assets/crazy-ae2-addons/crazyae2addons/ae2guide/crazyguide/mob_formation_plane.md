---
navigation:
  parent: crazyae2addons_index.md
  title: Mob Formation Plane
  icon: crazyae2addons:mob_formation_plane
categories:
  - Mob Storage
item_ids:
  - crazyae2addons:mob_formation_plane
---
# Mob Formation Plane

The Mob Formation Plane is a special ME part that places mobs directly into the world. It works like a traditional Formation Plane, but specifically for spawning captured mobs. Its something like export only storage bus but for mobs.

## How to Use

1. **Place the Plane**
   - Attach it to any ME cable, with the output side facing an empty block where mobs should appear.

2. **Configure Mob Filters**
   - Right-click the plane to open its GUI.
   - Place MobKeys into the config slots to whitelist which mobs are allowed.
   - If an **Inverter Card** is installed, the list becomes a blacklist instead.

3. **Add Upgrade Cards** *(Optional)*
   - Use **Capacity Cards** to unlock more filter slots.

4. **Spawn Conditions**
   - The block in front **and above** must be air.
   - Spawning fails if either is blocked.

---

## How It Works

- Every time a matching MobKey is inserted into the ME network:
   - The Mob Formation Plane checks if it's in the filter and if the priority is high enough.
   - If valid and the position is clear, the mob is spawned into the world.
   - Up to 24 mobs can be spawned in one action.