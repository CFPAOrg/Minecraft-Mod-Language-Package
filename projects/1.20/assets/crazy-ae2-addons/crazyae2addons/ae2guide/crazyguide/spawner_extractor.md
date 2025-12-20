---
navigation:
  parent: crazyae2addons_index.md
  title: Spawner Extractor
  icon: crazyae2addons:spawner_extractor_controller
categories:
  - Mob Storage
item_ids:
   - crazyae2addons:spawner_extractor_wall
   - crazyae2addons:spawner_extractor_controller
---

# Spawner Extractor

<GameScene zoom="2" interactive={true}>
  <ImportStructure src="../assets/spawner_extractor.nbt" />
</GameScene>

The Spawner Extractor is a multiblock system that simulates mob spawning from real Spawner blocks and inserts mobs directly into your ME network. This lets you capture mobs automatically without lag or real entity spawns.

## [Video Tutorial](https://youtu.be/MUKyq0IDi3M&list=PLB8Rr5Xojkr5T1qoPr_4JdETiBkF4qF6r)

## How to Use

1. **Build the Multiblock Structure**
   - Use the block layout shown above. Make sure to build around a spawner. For the multiblock to assemble, place any corner of the build last.

2. **Power the Controller**
   - Connect it to an active ME network.

3. **Insert Upgrade Cards (Optional)**
   - Use Speed Cards to increase the mob generation rate.

---

## How It Works

- Once formed, the structure disables all spawners inside.
- Every 20 ticks, some mobs are inserted into the ME network.
- The controller reads the mob type.
- No real mob spawns - just clean, repeatable mob capture.

---

## Important Notes

- **Requires correct multiblock structure**: If broken, the controller will stop.
- **No real mobs spawned**: No lag, no danger.