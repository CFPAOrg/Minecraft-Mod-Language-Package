---
navigation:
  title: "大型模拟室"
  icon: "hostile_neural_industrialization:large_simulation_chamber"
  position: 0
  parent: hostile_neural_industrialization:multiblock.md
item_ids:
  - hostile_neural_industrialization:large_simulation_chamber
---

# 大型模拟室

###### *量产型预测机器。等等，这说法不对吧……是吗？呃，两种理解都说得通*

<GameScene zoom="2" interactive={true} fullWidth={true}>
    <MultiblockShape controller="hostile_neural_industrialization:large_simulation_chamber" />
</GameScene>

除了具备[电动模拟室](../single_block/electric_sim_chamber.md)的所有特性外，它还引入了一些新特性：

§2§l+ §r§a预测序列成功时，会一次性产出§l4§r§a个预测产物

§2§l+ §r§a每次序列为数据模型收集§l2§r§a点数据

§4§l- §r§c每次序列消耗§l8§r§c个预测矩阵

本质上，这意味着它每次序列能提取更多预测产物。建议使用§d§l超级§r或更高等级的数据模型，否则就算消耗大量能量和预测矩阵，收获却甚微。


<Recipe id="hostile_neural_industrialization:machine/large_simulation_chamber" />