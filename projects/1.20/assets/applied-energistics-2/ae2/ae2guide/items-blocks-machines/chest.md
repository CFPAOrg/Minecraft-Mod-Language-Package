---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: ME箱子
  icon: chest
  position: 210
categories:
- devices
item_ids:
- ae2:chest
---

# ME箱子

<GameScene zoom="8" background="transparent">
<ImportStructure src="../assets/blocks/chest.snbt" />
</GameScene>

ME箱子类似于带有<ItemLink id="terminal" />、<ItemLink id="drive" />，以及<ItemLink id="energy_acceptor" />的微缩网络。可将其用作小型网络存储，但其仅能装下单个[存储元件](../items-blocks-machines/storage_cells.md)的容量则限制了其功能性。

它在与其中元件单独交互方面非常有用。集成其中的终端只能访问箱子内的元件，而普通网络中的[设备](../ae2-mechanics/devices.md)则能访问任何[网络存储](../ae2-mechanics/import-export-storage.md)位置，包括ME箱子。

其有2个GUI，且对面敏感。与顶面的终端交互会打开终端界面，物流系统仅可向其输入，而不能从中抽取物品。与其他面交互则会打开放置存储元件和优先级设置的GUI。物品物流系统仅可通过带有元件槽的面输出输出元件。

可被<ItemLink id="certus_quartz_wrench" />旋转。

其只有一小型AE能量缓存，因此若不配备[能源元件](../items-blocks-machines/energy_cells.md)，对其同时输入输出过多物品可能会导致能量耗尽。

终端可用<ItemLink id="color_applicator" />染色。

<GameScene zoom="6" background="transparent">
<ImportStructure src="../assets/assemblies/chest_color.snbt" />
<IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 设置

ME箱子的设置与<ItemLink id="terminal" />和<ItemLink id="crafting_terminal" />的相同，但不支持<ItemLink id="view_cell" />。

## 元件状态LED

驱动器中的元件可通过其LED表明其状态：

| 颜色 | 状态                                                          |
| :--- | :------------------------------------------------------------ |
| 绿色 | 空                                                            |
| 蓝色 | 装有事物                                                      |
| 橙色 | [类型](../ae2-mechanics/bytes-and-types.md)已满，不可新增类型 |
| 红色 | [字节](../ae2-mechanics/bytes-and-types.md)已满，不可新增物品 |
| 黑色 | 无能量或驱动器缺少[频道](../ae2-mechanics/channels.md)        |

## 优先级

可点击GUI右上角扳手以设置优先级。输入网络的物品会优先进入最高优先级的存储位置，如果有两个优先级相同的存储位置，则会优先选择已经存有该物品的那个。经过[分区](cell_workbench.md)的元件在同优先级情况下视作已经存有该物品。从存储中输出的物品会优先从最低优先级的位置输出。这一优先级系统使得在输入输出物品的过程中，高优先级的存储位置会被填满，而低优先级的会被搬空。

## 配方

<RecipeFor id="chest" />
