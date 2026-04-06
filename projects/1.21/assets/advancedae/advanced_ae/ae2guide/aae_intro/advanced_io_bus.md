---
navigation:
  parent: aae_intro/aae_intro-index.md
  title: Advanced IO Bus
  icon: advanced_ae:advanced_io_bus_part
categories:
  - advanced items
item_ids:
  - advanced_ae:advanced_io_bus_part
---

# Advanced IO Bus

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/cable_advanced_io_bus.snbt"></ImportStructure>
</GameScene>

The Advanced IO Bus is a very powerful tool to interact with external inventories. It's created by fusing together an
<ItemLink id="advanced_ae:import_export_bus_part"/> and a <ItemLink id="advanced_ae:stock_export_bus_part"/>. It inherits
the functions of both of its parents. Additionally, the base speed of the Advanced IO Bus is 8 times higher than the base
speed of an <ItemLink id="ae2:export_bus"/>. It will take some time to ramp up to speed but will be blazingly fast
when fully upgraded.

## Exporting

The Advanced IO Bus will export according to its filter, up to a fixed amount and stop there. On the left side of the UI
there's also a config that allows the user to choose to regulate the stock of items.

## Importing

The Advanced IO Bus will also import anything that isn't filtered to be exported. Import and Export operations are
counted separately, so the Bus will not get stuck doing one or the other. When the bus is configured to regulate, it will
prioritize importing anything that is over the set amount. If any operation is left, it will import what's not filtered.

<RecipeFor id="advanced_ae:advanced_io_bus_part"/>