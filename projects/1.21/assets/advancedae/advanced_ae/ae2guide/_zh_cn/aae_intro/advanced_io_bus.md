---
navigation:
  parent: aae_intro/aae_intro-index.md
  title: 高级IO总线
  icon: advanced_ae:advanced_io_bus_part
categories:
  - advanced items
item_ids:
  - advanced_ae:advanced_io_bus_part
---

# 高级IO总线

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/cable_advanced_io_bus.snbt"></ImportStructure>
</GameScene>

高级IO总线由<ItemLink id="advanced_ae:import_export_bus_part"/>和<ItemLink id="advanced_ae:stock_export_bus_part"/>融合而成，是与外部容器交互的强大工具。它继承了两者的功能，并且高级IO总线的基础速度是<ItemLink id="ae2:export_bus"/>的8倍。它启动时要花时间积攒速度，但完全升级后的运转速度堪比闪电。

## 输出

高级IO总线会根据过滤器输出指定量的事物，达到该指定量后即不再输出。界面左侧有调控库存行为的配置选项。

## 输入

高级IO总线会输入所有未过滤为输出的物品。输入和输出操作相互分离，因此总线不会被其中一种操作堵死而无法执行另一种。总线配置为调控时，其会优先输入超出设定量的物品。在没有物品超出各自的设定量后，才会开始输入未设置过滤的事物。

<RecipeFor id="advanced_ae:advanced_io_bus_part"/>