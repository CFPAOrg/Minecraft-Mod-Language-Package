---
navigation:
  parent: crazyae2addons_index.md
  title: Chunky Fluid P2P
  icon: crazyae2addons:chunky_fluid_p2p_tunnel
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:chunky_fluid_p2p_tunnel
---

# Chunky Fluid P2P Tunnel

The Chunky Fluid P2P Tunnel part lets you send fluids in fixed-size chunks. It waits until it has collected enough fluid to meet the configured chunk size (in millibuckets), then moves exactly that amount to the connected output, cycling through them to keep distribution balanced.

## How to Use

1. **Attach the part**: Place the Chunky Fluid P2P Tunnel on any side of an ME cable or Fluid Interface that is connected to a tank or fluid machine.
2. **Configure chunk size**: Right click the part with an empty hand to open its settings. Enter the desired chunk size in mB (for example, `1000` for one full bucket) and click Save.
3. **Link**: Use memory card to link input with outputs.
4. **Fill and transfer**: When fluid enters the tunnel, if its amount is at least the chunk size, it sends exactly that amount to the next output in line. If the amount is less than the chunk size, nothing will happen.