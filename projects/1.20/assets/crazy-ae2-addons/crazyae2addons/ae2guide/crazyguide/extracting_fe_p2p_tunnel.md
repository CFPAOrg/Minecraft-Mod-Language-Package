---
navigation:
  parent: crazyae2addons_index.md
  title: Extracting FE P2P Tunnel
  icon: crazyae2addons:extracting_fe_p2p_tunnel
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:extracting_fe_p2p_tunnel
---

# Extracting FE P2P Tunnel

The Extracting FE P2P Tunnel is a variant of the standard Forge Energy (FE) P2P tunnel.
It behaves identically in terms of linking, frequency etc. with one key difference:

> Instead of needing energy to be exported into the tunnel, it actively pulls FE from the block it is facing and sends it to the outputs.

---

## How It Works

- Behaves like a normal FE P2P tunnel in terms of linking and energy routing.
- Every tick, it checks how much energy the outputs can accept.
- Then it pulls that amount from the input block (if possible).
- Distributes energy to outputs automatically.

---

## Use Case Example

- **Standard FE Tunnel**:
    - Needs energy being pushed (exported) to the tunnel.
- **Extracting FE Tunnel**:
    - Just place it directly on a battery, machine, or any FE provider — it pulls energy from it automatically.