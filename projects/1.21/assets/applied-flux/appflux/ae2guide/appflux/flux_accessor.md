---
navigation:
  parent: appflux/appflux-index.md
  title: Flux Accessor
  icon: appflux:flux_accessor
categories:
- flux accessor
item_ids:
- appflux:flux_accessor
- appflux:part_flux_accessor
---

# Flux Accessor

<Row>
<BlockImage id="appflux:flux_accessor" scale="8"></BlockImage>
<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/flux_accessor.snbt"></ImportStructure>
</GameScene>
</Row>

Flux Accessor can input/output energy stored in your ME network. They don't have I/O limitations by default, which can be 
changed in Appflux config.

They have fast and normal mode. In fast mode, it outputs energy in every tick, which may cause lag if it is heavily used.
In normal mode, it outputs energy depends on target's stored energy, which won't cause lag issues.

* Notice: The "energy" mentioned here is FE stored in your [FE Storage Cells](./flux_cells.md), not the energy in
[Energy Cells](ae2:items-blocks-machines/energy_cells.md).

