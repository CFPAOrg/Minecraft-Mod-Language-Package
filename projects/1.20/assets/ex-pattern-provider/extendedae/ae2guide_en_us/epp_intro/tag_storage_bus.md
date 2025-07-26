---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME Tag Storage Bus
    icon: extendedae:tag_storage_bus
categories:
- extended devices
item_ids:
- extendedae:tag_storage_bus
---

# ME Tag Storage Bus

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/cable_tag_storage_bus.snbt"></ImportStructure>
</GameScene>

ME Tag Storage Bus is a <ItemLink id="ae2:storage_bus" /> that can be filtered by item or fluid tags and supports some basic logic operator.

Here are some examples:

- Only accept raw ore

forge:raw_materials/*

- Accept all ingots and gems

forge:ingots/* | forge:gems/*

