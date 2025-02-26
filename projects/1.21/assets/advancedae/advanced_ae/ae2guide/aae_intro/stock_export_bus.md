---
navigation:
  parent: aae_intro/aae_intro-index.md
  title: Stock Export Bus
  icon: advanced_ae:stock_export_bus_part
categories:
  - advanced items
item_ids:
  - advanced_ae:stock_export_bus_part
---

# Stock Export Bus

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/cable_stock_export_bus.snbt"></ImportStructure>
</GameScene>

The Stock Export Bus can be configured to export an exact amount of the filtered stacks. It keeps track of the amount
currently present in the target inventory and doesn't insert above that number. To configure it, you open the GUI, drag
the desired item into the filter slot and, using a middle click, you can configure the amount. Note that it will not
regulate the output, meaning it won't extract extra items/fluids from the inventory if they go over the configured
amount.