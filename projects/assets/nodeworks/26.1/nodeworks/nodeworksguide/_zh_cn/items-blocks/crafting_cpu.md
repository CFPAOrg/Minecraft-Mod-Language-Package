---
navigation:
  parent: items-blocks/index.md
  icon: crafting_core
  title: 合成CPU
categories:
  - autocrafting
description: 网络内自动合成系统的大脑
item_ids:
- nodeworks:crafting_core
- nodeworks:crafting_storage
- nodeworks:substrate
- nodeworks:stabilizer
- nodeworks:co_processor
---

# 合成CPU

合成CPU是自动合成系统的大脑。它会从[存储器](./storage_blocks.md)（本地网络，广播子网的处理集）中读取配方，从网络内抽取原材料，执行合成，并将产物送回。具体如何*使用*搭建完成的CPU，参见[自动合成](../nodeworks-mechanics/autocrafting.md)。

## 搭建CPU

CPU永远都只包含一个<ItemLink id="crafting_core" />。不过仅靠核心还不够，CPU还需要至少有一个<ItemLink id="crafting_storage" />（即“缓存单元”）与之相贴。没有缓存器的CPU无法在合成中途暂存资源，也因此不会亮起。

CPU的放置相对自由。不需要扳手，也没有外形要求。放下核心，在任意一面放下一个缓存器，将核心接到节点上，它就会亮起。

<GameScene zoom="5" interactive={true} paddingLeft="50" paddingRight="60">
  <ImportStructure src="../assets/assemblies/basic_crafting_cpu.snbt" />
  <BlockAnnotation x="1" y="0" z="0">
    会产热，应当配2个冷却器
  </BlockAnnotation>
</GameScene>

> **提示：**&zwnj;开始时，建议合成CPU中放置两个<ItemLink id="stabilizer" />与<ItemLink id="crafting_storage" />相连，以确保**效率**至少为100%。

## 扩展CPU

其他CPU方块可增大或加快CPU：

- <ItemLink id="crafting_storage" />（**合成缓存器**）：至少一个。缓存器越多，运行合成时容纳原材料和中间产物的空间就越多。每个缓存器产生**2点热量**。
- <ItemLink id="co_processor" />（**合成协处理器**）：每个追加一条并行合成上限。每个协处理器产生**3点热量**。
- <ItemLink id="stabilizer" />（**合成冷却器**）：抵消热量。孤立的冷却器产出**1点制冷**，每有一个冷却器与之相贴则**额外产出1点**。周围有四个冷却器相贴的冷却器能产出**5点制冷**，可见冷却器集群要远强于孤立的冷却器。
- <ItemLink id="substrate" />（**合成载件**）：速度拉杆。缓存器或协处理器每有一面与载件相贴，均能为CPU增速**10%**，上限为**4倍（400%）速度**。与核心、冷却器、其他载件相贴的面没有效用，可见在缓存器和协处理器之间放置载件效果最佳。

这些组件只需与核心相贴或通过已属于CPU的方块与核心相连。无需扳手交互，也无需GUI操作。放下方块，CPU就将在下一刻更新。

### 热量、制冷、速度

所有缓存器和协处理器都会产热，冷却器的任务就是从相贴的热源中吸走热量。组件的排布方式和数量都很重要：

- 热源之间**每有一面**相贴**追加1点热量**，原有的热量不变。紧凑的缓存器和协处理器长方体产的热要远高于分散放置。
- 每个冷却器集群产出一个总制冷值（孤立为1点，集群后点数更多）。该制冷值**在与冷却器相贴的各热源间均分**。夹在两个缓存器之间的冷却器会向两者各输出一半的制冷效力，而处在六个热源之中的冷却器几乎无法充分冷却任意一个。
- CPU的总制冷无法抵消总热量时，其速度会成比例地**下降**，最低可至**25%**。CPU不会停止运作，只会不停地挣扎。
- 冷却器只能抵消热量，它不会将速度增加到100%以上。唯一能做到这点的方块是载件，最高可为4×。

<GameScene zoom="5" interactive={false} paddingLeft="60" paddingRight="60">
  <IsometricCamera yaw="180" roll="0" pitch="0" />
  <ImportStructure src="../assets/assemblies/overheating_crafting_cpu.snbt" />

  <LineAnnotation from="2.5 0 0" to="4.5 3 0" color="#ff0000" thickness="0.05" />
  <LineAnnotation from="2.5 3 0" to="4.5 0 0" color="#ff0000" thickness="0.05" />

  <LineAnnotation from="1 0 0" to="2.5 1.25 0" color="#00ff00" thickness="0.05" />
  <LineAnnotation from="1.02 0 0" to="-0.8 3 0" color="#00ff00" thickness="0.05" />
</GameScene>

> **提示：**&zwnj;方块过热时会有相应的视觉效果——颜色发黄/发橙/发红，冒烟。

实用建议：不要把大量的缓存器和协处理器堆到一起再在周围放冷却器。可以把冷却器搭成专门的墙面或鳍板（让冷却器相贴），再安放热源，尽量保证每个冷却器只与一到两个热源相贴。最后在剩下的缓存器/协处理器面上放置载件增速。

## 配方

<Row>
    <RecipeFor id="nodeworks:crafting_core" />
    <RecipeFor id="nodeworks:crafting_storage" />
    <RecipeFor id="nodeworks:substrate" />
    <RecipeFor id="nodeworks:stabilizer" />
    <RecipeFor id="nodeworks:co_processor" />
</Row>
