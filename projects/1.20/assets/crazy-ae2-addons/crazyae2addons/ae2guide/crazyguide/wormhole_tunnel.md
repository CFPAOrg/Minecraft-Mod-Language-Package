---
navigation:
  parent: crazyae2addons_index.md
  title: Wormhole Tunnel
  icon: crazyae2addons:wormhole_tunnel
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:wormhole_tunnel
---

# Wormhole P2P Tunnel

The Wormhole P2P Tunnel is an advanced variant of AE2's P2P system that allows two-way communication, redstone propagation, and automatic capability routing across multiple linked tunnels.

Unlike regular P2P tunnels, Wormhole tunnels can form **bi-directional connections**, support **redstone transmission**, and **combine capabilities** when interacting with multiple outputs.

---

## Key Features

- **Two-Way Connectivity**
  - Wormholes create actual grid-level connections between input and outputs.
  - Energy, items, and fluids can flow both ways if needed.

- **Capability Combining**
  - Item, fluid, and energy capabilities from multiple outputs are merged into one access point.

- **Redstone Transmission**
  - Inputs can receive redstone signal and propagate it to all connected outputs.
  - Full support for weak and strong redstone.

---

## Examples

The possibilities are endless but here are some setups I did while testing.
- Storage bus through a tunnel: you can place a storage bus on the input side, and any item/fluid storage on the other sides, and the storage bus will see and be able to interact with them.
- Nested p2p tunnels: you can connect two parts of me network with this tunnel, and you can use p2p tunnels within those tunneled channels.
- Mek's heat transfer: and any other pipes from mek work through this tunnel.