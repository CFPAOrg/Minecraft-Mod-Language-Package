---
navigation:
  parent: crazyae2addons_index.md
  title: Energy Exporter
  icon: crazyae2addons:energy_exporter
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:energy_exporter
---

# Energy Exporter

The Energy Exporter is a part that allows your ME network to send Forge Energy (FE)
or GregTech Energy (EU) into adjacent machines or storage blocks. 
It extracts power from your network and provides it outward.

## How to Use

1. **Place the part**: Attach the Energy Exporter to an ME cable facing a block that accepts energy.
2. **Open the GUI**: Right-click the part to open its settings screen.
3. **Install upgrades**:
    - **Speed Cards**: Increase the rate of FE transfer exponentially.
    - Staring from 1FE/t (no upgrades) up to about max int FE/t (6 upgrades).
4. **GregTech support**:
    - Insert a battery into the slot if you want to switch to GregTech EU mode.
    - The voltage used depends on the inserted battery tier (e.g., LV, MV, HV, etc.).
    - The battery must be a lithium one, if available.
5. **Monitor output**:
    - The screen shows current transfer rate.
    - In GregTech mode, it additionally shows configured voltage and amperage.

The Energy Exporter automatically adapts to whether it is providing FE or EU,
based on the inserted battery and the target machine's capabilities. 
It handles power conversion rates and protects your network from overdrawing, 
turning of when the power left in your network falls bellow 33%.