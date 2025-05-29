---
navigation:
  parent: crazyae2addons_index.md
  title: Spawner Controller
  icon: crazyae2addons:spawner_controller_wall
categories:
  - Mob Storage
item_ids:
   - crazyae2addons:spawner_controller_wall
---

<BlockImage id="crazyae2addons:spawner_controller_wall" scale="4"></BlockImage>

# Spawner Controller

The Spawner Controller is a multiblock system that simulates mob spawning from real Spawner blocks and inserts mobs directly into your ME network. This lets you capture mobs automatically without lag or real entity spawns.

- **W** – Spawner Controller Wall Block
- **G** – Vibrant Quartz Glass
- **A** – Air 
- **S** – Minecraft Spawner Block

#### Layer 1:
W W W W W <br/>
W W W W W <br/>
W W W W W <br/>
W W W W W <br/>
W W W W W 

#### Layer 2:
W G G G W <br/>
G A A A G <br/>
G A A A G <br/>
G A A A G <br/>
W G G G W

#### Layer 3:
W G G G W <br/>
G A A A G <br/>
G A S A G <br/>
G A A A G <br/>
W G G G W

#### Layer 4:
W G G G W <br/>
G A A A G <br/>
G A A A G <br/>
G A A A G <br/>
W G G G W

#### Layer 5:
W W W W W <br/>
W W W W W <br/>
W W W W W <br/>
W W W W W <br/>
W W W W W



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