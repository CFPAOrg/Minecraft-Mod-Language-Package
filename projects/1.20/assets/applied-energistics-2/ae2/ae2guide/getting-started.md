---
navigation:
  title: 开始与入门（1.20+）
  position: 10
---

<div class="notification is-info">
  以下信息仅适用于Minecraft 1.20或更新版本的应用能源2。
</div>

# 开始与入门

## 获取起始材料

<GameScene zoom="4" background="transparent">
  <ImportStructure src="assets/assemblies/meteor_interior.snbt" />
</GameScene>

应用能源2开始于寻找[陨石](ae2-mechanics/meteorites.md)。陨石比较常见，且通常会在地形上留下巨大的坑洞，所以你可能已经在旅程中撞见过了。
如果还没有遇到过，可以合成一个<ItemLink id="meteorite_compass" />，它会指向最近的<ItemLink id="mysterious_cube" />。

发现陨石后便要向其中心挖掘。在那里能找到赛特斯石英簇、赛特斯石英芽、各种类型的[赛特斯石英母岩](items-blocks-machines/budding_certus.md)，以及一个神秘方块。

挖下所有找到的赛特斯石英簇和赛特斯石英块。也可以采集赛特斯石英母岩，但在没有精准采集时会降一级。

不要破坏任何无瑕的赛特斯石英母岩，在有精准采集的情况下它们也会降级为有瑕的赛特斯石英母岩，并且不可能将其修复回去。

并且也要挖下中间的神秘方块，以获得所有4种压印模板。

## 培养赛特斯石英

<GameScene zoom="4" background="transparent">
<ImportStructure src="assets/assemblies/budding_certus_1.snbt" />
</GameScene>

赛特斯石英芽会从[赛特斯石英母岩](items-blocks-machines/budding_certus.md)中生长出来，与紫水晶类似。如果破坏未完全生长的石英芽，则会掉落一个<ItemLink id="certus_quartz_dust" />，不受时运影响。如果破坏长成的石英簇，则会掉落四个<ItemLink id="certus_quartz_crystal" />，且会受时运影响而增加掉落量。

共有4种等级的赛特斯石英母岩：无瑕、有瑕、开裂、破损。

<GameScene zoom="4" background="transparent">
<ImportStructure src="assets/assemblies/budding_blocks.snbt" />
<IsometricCamera yaw="195" pitch="30" />
</GameScene>

每次石英芽生长时，母岩都有可能降一级，并最终变为普通的赛特斯石英块。将赛特斯石英母岩或者赛特斯石英块以及若干个<ItemLink id="charged_certus_quartz_crystal" />一起投入水中，就能将其修复并产生新的母岩。

<RecipeFor id="damaged_budding_quartz" />

无瑕的赛特斯石英母岩不会降级，因而能无限产生赛特斯石英。但是它们无法合成，也无法被镐完好地挖下搬运，就算有精准采集也不行。（不过它们*可以*被[空间存储](ae2-mechanics/spatial-io.md)移动。）

赛特斯石英母岩自身的生长非常缓慢。幸运的是，在母岩旁放置<ItemLink id="growth_accelerator" />能大幅加速这一过程。你的第一要务便是制造一些此方块。

<GameScene zoom="4" background="transparent">
<ImportStructure src="assets/assemblies/budding_certus_2.snbt" />
<IsometricCamera yaw="195" pitch="30" />
</GameScene>

假如没有足够石英制造<ItemLink id="energy_acceptor" />或是<ItemLink id="vibration_chamber" />，可以制造一个<ItemLink id="crank" />并安到催生器上。

自动采集赛特斯石英的设计[见此](example-setups/simple-certus-farm.md)。

## 福鲁伊克斯简述

另一种所需材料是福鲁伊克斯，你应该已经在制造晶体催生器的过程中见过它了。将充能赛特斯石英水晶、红石、下界石英投入水中就能制成福鲁伊克斯。这一流程的自动化则“[留给读者作为习题](example-setups/processor-automation.md)”。

<ItemLink id="charger" />则是生产<ItemLink id="charged_certus_quartz_crystal" />的必备之物。若还未制造还请尽快。

## 压印一些处理器

陨石战利品中有破坏神秘方块而得的四种压印模板。这些可用在<ItemLink id="inscriber" />中以制造三种处理器。

<ItemGrid>
  <ItemIcon id="silicon_press" />

  <ItemIcon id="logic_processor_press" />

  <ItemIcon id="calculation_processor_press" />

  <ItemIcon id="engineering_processor_press" />
</ItemGrid>

压印器是一个面敏感的机器，与原版熔炉类似。从顶面或底面输入物品会相应放入顶部或底部的槽位，从侧面或背面输入则会插入中间的槽位。产物可从侧面或背面抽取。

如果需以漏斗进行自动化（也许也是为了减少线缆缠绕），可用<ItemLink id="certus_quartz_wrench" />旋转压印器。

生产各种处理器若干个以准备下一步——搭建一个非常基础的ME系统。处理器的自动化则“留给读者作为习题”。

## 物质能量科技：ME网络与存储

### ME存储是什么？

念法是Emm-Eee，意义是物质能量。

物质能量是应用能源2的主要组件，类似于疯狂科学家版的多方块箱子，并能彻底改变你的存储境况。ME和其他Minecraft的存储系统极为不同，且可能需要一点跳出定式的思维才能习惯。但在入门之后，在极小的空间内大批量存储，多个管理终端之类都只是可能性的冰山一角。

### 需要知道什么才能入门？

首先，ME将物品存储在其他物品之内，这类物品称作[存储元件](items-blocks-machines/storage_cells.md)，共有5级，存储量依次增加。存储元件必须放置于<ItemLink id="chest" />或<ItemLink id="drive" />中才可使用。

<ItemLink id="chest" />会在放入元件后立刻显示其存储内容，可向其中放入或从中取出物品，和<ItemLink id="minecraft:chest" />类似。两者的区别在于，物品实际存储于存储元件，而非<ItemLink id="chest" />本身。

<ItemLink id="chest" />的用途相对不稳定且有局限，真正使用AE2还需要搭建一个[ME网络](ae2-mechanics/me-network-connections.md)。

## 你的第一个ME系统

现在，应用能源2的基础材料和机器都已准备完善，就可以着手搭建你的第一个ME（物质能量）系统了。这个系统非常基础，没有自动合成，没有物流，只有简单好用的可搜索存储。

<GameScene zoom="6" interactive={true}>
<ImportStructure src="assets/assemblies/tiny_me_system.snbt" />

</GameScene>

*   材料列表：
    * 1x <ItemLink id="drive" />
    * 1x <ItemLink id="terminal" />或<ItemLink id="crafting_terminal" />
    * 1x <ItemLink id="energy_acceptor" />
    * 若干[线缆](items-blocks-machines/cables.md)，玻璃、包层、智能均可，致密则不可
    * 若干[存储元件](items-blocks-machines/storage_cells.md)，推荐使用4k以在容量和类型间保持均衡（4k和1k混合使用更方便[分区](items-blocks-machines/cell_workbench.md)，但这些知识相对复杂，暂不详述）
---
1.  放下驱动器。
2.  能源接收器（以及若干其他AE2[设备](ae2-mechanics/devices.md)）有2种形态，方块形态和面板形态。两种形态可在合成方格中转换。如果你的能源接收器是方块，紧贴驱动器放置。如果是一个方形面板，在驱动器上放置线缆并在其上放置接收器。
3.  给能源接收器接上能量，用你最喜欢的产能模组中的线缆/管道/导管即可。
4.  在驱动器上方（或眼部高度）放置线缆，并在其上放置终端或合成终端。
5.  将存储元件放入驱动器。
6.  开用。
7.  随意调调终端的设置。
8.  沐浴在你超强能力的光辉中。
9.  意识到在宏观层面上，这个网络有点太小了。

### 扩展你的网络

你现在有了基础存储已经访问存储内容的能力，起步很好，但你可能还会想要自动化某些流程。

绝佳示例之一便是在熔炉顶面放置<ItemLink id="export_bus" />以输入矿石，再在熔炉底面放置<ItemLink id="import_bus" />以提取烧炼过的矿石。

<ItemLink id="export_bus" />能从网络中输出物品至相贴合的容器中，而<ItemLink id="import_bus" />则能从相贴合的容器中提出物品输入网络。

### 超越极限

此时你可能已经快放下8个[设备](ae2-mechanics/devices.md)了，而一旦放下9个设备，就要开始管理[频道](ae2-mechanics/channels.md)了。许多设备（并非全部）需要占用一个频道才能工作。

默认情况下，一个网络能支持8个频道，突破这个限制后就需要向网络中加入<ItemLink id="controller" />。其能大幅扩展你的网络。[智能线缆](items-blocks-machines/cables.md)则能让你看见频道在网络中如何分布。在开始学习频道行为时请广泛使用，或者有大量红石和荧石也可广泛使用。
