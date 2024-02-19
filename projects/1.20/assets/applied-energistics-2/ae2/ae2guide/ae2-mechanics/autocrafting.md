---
navigation:
  parent: ae2-mechanics/ae2-mechanics-index.md
  title: 自动合成
  icon: pattern_provider
---

# 自动合成

### 来个大的

<GameScene zoom="4" interactive={true}>
  <ImportStructure src="../assets/assemblies/autocraft_setup_greebles.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

自动合成是AE2的基础功能之一。不需再像某些*平民*一样疲于手工合成正确数量的子材料，你可以让ME系统为你合成。或是自动合成并输出到其他地方。或是通过智能的涌现行为在库存中自动维持一定数量的物品。它对流体也有效，并且假如安装有某些兼容更多材料类型（例如Mekanism的气体）的附属，则也对那些类型有效。确实非常不错。

这个话题相当复杂，所以闲话少说，马上开始学习吧。

自动合成设施由3部分组成：
- 发送合成请求的事物
- 合成CPU
- <ItemLink id="pattern_provider" />

具体过程如下：

1.  某物发出一份合成请求。可以是你在终端中点击某些可自动合成的事物，也可以是装有合成卡的输出总线或接口请求其设定输出或存储的物品。

*   （**重要：**使用绑定在“选取方块”（通常是鼠标中键）的按键以请求合成库存中已有的事物，可能与物品栏整理模组冲突）

2.  ME系统计算请求所需的材料和前置合成步骤，并将材料存储在所选合成CPU中。

3.  装有相关[样板](../items-blocks-machines/patterns.md)的<ItemLink id="pattern_provider" />将样板中需求的材料输出至任意相邻容器。
    如果是工作台配方（“合成配方”），输出目标是<ItemLink id="molecular_assembler" />。
    如果不是工作台配方（“处理配方”），输出目标是其他方块、机器，或是复杂的红石控制设施。

4.  所得产物通过某种方式送回系统，可以是输入总线、接口，或将产物输入样板供应器。
    **注意必须发生一次“物品输入系统”事件，不能只将产物输入接有<ItemLink id="storage_bus" />的箱子。**

5.  如果该合成过程是请求内另一合成过程的前置，则产物会存入该CPU并供后续使用。

## 递归配方

<ItemImage id="minecraft:netherite_upgrade_smithing_template" scale="4" />

自动合成算法*无法*处理的事情之一是递归配方。例如，将红石投入Botania魔力池所致的，类似“1x 红石粉 = 2x 红石粉”的复制配方。又例如原版的锻造模板。不过，确实[有方法处理这些配方](../example-setups/recursive-crafting-setup.md)。

# 样板

<ItemImage id="crafting_pattern" scale="4" />

样板是在<ItemLink id="pattern_encoding_terminal" />中以空白样板制作而得的。

有若干种不同的样板，分别为不同处理方式设计：

*   <ItemLink id="crafting_pattern" />能编码工作台的配方。可将此类样板直接放入<ItemLink id="molecular_assembler" />以令其在收到材料时自动合成，但是它们的主要用途则是放在与分子装配室相邻的<ItemLink id="pattern_provider" />中。样板供应器在此情况下有特殊行为，会将相关样板和材料输入相邻装配室。因为装配室会将产物自动弹出到相邻容器，相邻放置的装配室和样板供应器就是自动化合成样板所需的一切了。

***

*   <ItemLink id="smithing_table_pattern" />与合成样板非常相似，但编码的是锻造台配方。它们也可通过样板供应器和分子装配室自动化，工作流程也完全一致。实际上，合成、锻造台、切石机样板所需的设施均完全一致。

***

*   <ItemLink id="stonecutting_pattern" />与合成样板非常相似，但编码的是切石机配方。它们也可通过样板供应器和分子装配室自动化，工作流程也完全一致。实际上，合成、锻造台、切石机样板所需的设施均完全一致。

***

*   <ItemLink id="processing_pattern" />则是自动合成的灵活性所在。它们是最通用的样板类型，简单来说，“如果样板供应器将这些材料输出到相邻容器，则ME系统会在未来某时间点收到这些物品”。它们是配合几乎所有其他模组机器（或者说熔炉类的机器）自动合成的方式。原因在于它们非常通用，且完全不关心输出材料和输入产物间发生的任何事。你大可做些非常古怪的事，比如将材料输入一整条复杂工厂产线进行分拣，再从无限生产的农场中运出其他材料，打印出一整篇《蜜蜂总动员》的剧本，只要ME系统能拿到样板指明的产物，它就完全不会关心这些。实际上，它甚至不会关心材料和产物之间有没有联系。你可以告诉系统“1x 樱花木板 = 1x 下界之星”，然后让凋灵农场每接收到一个樱花木板时杀一只凋灵即可，完全不会出任何问题。

多个拥有相同样板的<ItemLink id="pattern_provider" />会并行工作；并且，还可以设置诸如“8x 圆石 = 8x 石头”的配方而非“1x 圆石 = 1x 石头”，这样，样板供应器每次运行都会向烧炼设施输入8个圆石而非每次1个。

## 最为通用的“样板”

还有一种比处理样板更为“通用”的“样板”种类。装有合成卡的<ItemLink id="level_emitter" />可设置为发出红石信号以合成物品。这种“样板”不会定义也不会关心合成材料。换言之，“如果在此标准发信器发出红石信号，则ME系统会在未来某时间点收到这些物品”。其通常用于启用或禁用不需要输入材料的无限农场，或是启用处理递归配方（标准自动合成无法处理）的系统，例如“1x 圆石 = 2x 圆石”，如果有一台能复制圆石的机器的话。

# 合成CPU

<GameScene zoom="4" background="transparent">
  <ImportStructure src="../assets/assemblies/crafting_cpus.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

合成CPU管理合成请求与合成任务。它们会在执行多步骤合成任务时将中间产物存于自身，并影响合成任务的大小上限，某种程度上也会影响这些任务的完成速度。它们是多方块结构，必须是长方体，且必须包含至少1个合成存储器。

合成CPU的构成如下：

*   （必需）[合成存储器](../items-blocks-machines/crafting_cpu_multiblock.md)，支持所有标准元件大小（1k、4k、16k、64k、256k）；它们会将与合成相关的材料和中间材料存于自身，因此处理所需材料更多的合成任务需要更大的或更多个合成存储器
*   （可选）<ItemLink id="crafting_accelerator" />，它们能让系统从单个样板供应器更迅速地发送材料批次；例如，这将会使样板供应器同时将材料送至相邻的六个装配室，而非一次一个
*   （可选）<ItemLink id="crafting_monitor" />，它们会显示CPU当前正在处理的任务；可用<ItemLink id="color_applicator" />染色
*   （可选）<ItemLink id="crafting_unit" />，它们仅用于填上空隙以使得CPU的形状为长方体

每个合成CPU能处理1个合成请求或任务，因此如果需要同时合成运算处理器和256个平滑石头，就需要有2个CPU多方块结构。

它们可设置为仅接受玩家请求、仅接受自动化系统（输出总线与接口）请求，或两者均接受。

# 样板供应器

<Row>
<BlockImage id="pattern_provider" scale="4" />

<BlockImage id="pattern_provider" p:push_direction="up" scale="4" />

<GameScene zoom="4" background="transparent">
  <ImportStructure src="../assets/blocks/cable_pattern_provider.snbt" />
</GameScene>
</Row>

<ItemLink id="pattern_provider" />是自动合成系统与世界交互的基础方式。它们会将[样板](../items-blocks-machines/patterns.md)指明的材料输出至相邻容器，并且也可向其输入物品以输入网络。通常可将机器的产物传输给附近的样板供应器（通常就是输出材料的那个）以节省频道，而非让<ItemLink id="import_bus" />提取产物。

需要注意，它们会直接从合成CPU中的[合成存储器](../items-blocks-machines/crafting_cpu_multiblock.md#crafting-storage)中输出物品；因此，模板供应器本身并不储存物品，也就不能直接从此抽取物品：需要将物品输出至另一个容器（比如木桶），再从那里抽取才行。

此外，供应器会同时输出整份材料，不会输出半份。这一特性是很有用的。

样板供应器和接口有一特殊交互效果——[子网络](../ae2-mechanics/subnetworks.md)：如果接口未经修改（请求槽内无内容），则供应器会跳过接口，直接输出到该子网络的[存储模块](../ae2-mechanics/import-export-storage.md)，而非输出到接口的存储槽；更重要的是，只要对应的存储模块没有足够的空间，下一批物品就不会输出。

允许存在多个拥有相同样板的样板供应器，它们会并行工作。

样板供应器会尝试在其所有面轮询材料批次，从而并行使用所有相邻的机器。

## 变种

样板供应器有3种变种：普通、方向、面板。这会影响各面输出材料，接收物品，提供网络连接的能力。

*   普通型样板供应器会向各面输出材料，会从各面接收物品，且和大多数AE2机器一样向各面提供网络连接，类似线缆。

*   方向型样板供应器可由在普通样板供应器上使用<ItemLink id="certus_quartz_wrench" />产生。它们只会向选中面输出材料，会从各面接收物品，并且仅不向选中面提供网络连接。这使得它们能向AE2机器输出物品而不连接网络，在构建子网络上非常有用。

*   面板型样板供应器是[线缆子部件](../ae2-mechanics/cable-subparts.md)，因此可在同一线缆上放置多个该种供应器，便于设计紧凑设施。它们和方向型供应器选中面功能类似，输出样板材料，接收物品，且不提供网络连接。

样板供应器的普通和面板形态可在合成方格中转换。

## 设置

样板供应器有多种模式：

*   **阻挡模式**能在机器中已有材料时阻止供应器输出新批次
*   **锁定合成**能在多种红石信号状况下锁定供应器，也可在前一批材料的合成产物未返回该供应器前将其锁定
*   供应器可在<ItemLink id="pattern_access_terminal" />上显示或隐藏

## 优先级

可点击GUI右上角扳手以设置优先级。在多个[样板](../items-blocks-machines/patterns.md)对应同一物品时，在高优先级供应器中的样板会先于低优先级供应器中样板使用，除非网络无法供给高优先级样板所需材料。

# 分子装配室

<BlockImage id="molecular_assembler" scale="4" />

<ItemLink id="molecular_assembler" />会接收输入其中的物品并执行相邻<ItemLink id="pattern_provider" />设定的操作，或执行其中<ItemLink id="crafting_pattern" />、<ItemLink id="smithing_table_pattern" />，以及<ItemLink id="stonecutting_pattern" />设定的操作，并将产物输出到相邻容器。

它们的主要用途是放在<ItemLink id="pattern_provider" />的相邻位置。样板供应器在此情况下有特殊行为，会将相关样板和材料输入相邻装配室。因为装配室会将产物自动弹出到相邻容器（也即弹出到样板供应器的返回栏内），相邻放置的装配室和样板供应器就是自动化合成样板所需的一切了。

<GameScene zoom="4" background="transparent">
<ImportStructure src="../assets/assemblies/assembler_tower.snbt" />
<IsometricCamera yaw="195" pitch="30" />
</GameScene>