---
navigation:
  parent: crazyae2addons_index.md
  title: Extracting P2P Tunnels
  icon: crazyae2addons:extracting_fe_p2p_tunnel
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:extracting_fe_p2p_tunnel
  - crazyae2addons:extracting_item_p2p_tunnel
  - crazyae2addons:extracting_fluid_p2p_tunnel
---

# Extracting P2P Tunnels

These are variants of standard AE2 P2P tunnels that are actively working, instead of needing 
items, fluids, or energy to be inserted into the tunnel, they automatically **pull** 
from the block they are attached to and push into the linked outputs.

## [Video Tutorial](https://youtu.be/fcd3xHpsXnE&list=PLB8Rr5Xojkr5T1qoPr_4JdETiBkF4qF6r)

---

## Available Types

- **Extracting Item P2P Tunnel**
  - Automatically pulls up to 64 items/tick from the attached inventory and sends them to the linked outputs.

- **Extracting Fluid P2P Tunnel**
  - Drains up to 64 buckets per tick from the fluid handler it's attached to and distributes it across outputs.

- **Extracting FE P2P Tunnel**
  - Pulls up to max int of Forge Energy (FE) from the source and pushes it to all linked outputs.
  - Distribution is proportional to how much each target can receive.

---

## How to Use

1. **Place the Tunnel**
  - Attach it to the block you want to pull from.

2. **Link as Output**
  - Use memory card to assign frequency (right-click source, then targets).

3. **Connect Outputs**
  - Attach another extracting tunnel parts of the same type to the output targets.
