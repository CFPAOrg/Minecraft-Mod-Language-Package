---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 样板供应器
  icon: pattern_provider
  position: 210
categories:
- devices
item_ids:
- ae2:pattern_provider
- ae2:cable_pattern_provider
---

# 样板供应器

<Row gap="20">
<BlockImage id="pattern_provider" scale="8" />
<BlockImage id="pattern_provider" p:push_direction="up" scale="8" />
<GameScene zoom="8" background="transparent">
  <ImportStructure src="../assets/blocks/cable_pattern_provider.snbt" />
</GameScene>
</Row>

样板供应器是自动合成系统与世界交互的基础方式。它们会将[样板](../items-blocks-machines/patterns.md)指明的材料输出至相邻容器，并且也可向其输入物品以输入网络。通常可将机器的产物传输给附近的样板供应器（通常就是输出材料的那个）以节省频道，而非让<ItemLink id="import_bus" />提取产物。

需要注意，它们会直接从合成CPU中的[合成存储器](../items-blocks-machines/crafting_cpu_multiblock.md#crafting-storage)中输出物品；因此，模板供应器本身并不储存物品，也就不能直接从此抽取物品：需要将物品输出至另一个容器（比如木桶），再从那里抽取才行。

此外，供应器会同时输出整份材料，不会输出半份。这一特性是很有用的。

样板供应器和接口有一特殊交互效果——[子网络](../ae2-mechanics/subnetworks.md)：如果接口未经修改（请求槽内无内容），则供应器会跳过接口，直接输出到该子网络的[存储模块](../ae2-mechanics/import-export-storage.md)，而非输出到接口的存储槽；更重要的是，只要对应的机器没有足够的空间，下一批物品就不会输出。阻挡模式下此功能才可正常运作，供应器会监测机器中的材料槽，而非接口中的槽位。

例如，下方设施会将需烧炼的事物和燃料直接送入熔炉对应的槽位中。可利用此特性向机器的多个面或多个机器供应样板。

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/furnace_automation.snbt" />

<BoxAnnotation color="#dddddd" min="1 0 0" max="2 1 1">
        （1）样板供应器：以赛特斯石英扳手改为方向型，装有相应样板。

        ![铁样板](../assets/diagrams/furnace_pattern_small.png)
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1 1 0" max="2 1.3 1">
        （2）接口：默认配置。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1 1 0" max="1.3 2 1">
        （3）存储总线#1：过滤煤炭。
        <ItemImage id="minecraft:coal" scale="2" />
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="0 2 0" max="1 2.3 1">
        （4）存储总线#2：通过反相卡设置为排除煤炭。
        <Row><ItemImage id="minecraft:coal" scale="2" /><ItemImage id="inverter_card" scale="2" /></Row>
  </BoxAnnotation>

<DiamondAnnotation pos="4 0.5 0.5" color="#00ff00">
        至主网络
    </DiamondAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

如下是为多台机器提供材料的通用设施示例

<GameScene zoom="6" background="transparent">
<ImportStructure src="../assets/assemblies/provider_interface_storage.snbt" />

<BoxAnnotation color="#dddddd" min="2.7 0 1" max="3 1 2">
        接口（必须为面板型，不能为方块型）
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1 0 0" max="1.3 1 4">
        存储总线
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="0 0 0" max="1 1 4">
        样板供应目的地
  </BoxAnnotation>

<IsometricCamera yaw="185" pitch="30" />
</GameScene>

允许存在多个拥有相同样板的样板供应器，它们会并行工作。

样板供应器会尝试在其所有面轮询材料批次，从而并行使用所有相邻的机器。

## 变种

样板供应器有3种变种：普通、方向、面板。这会影响各面输出材料，接收物品，提供网络连接的能力。

* 普通型样板供应器会向各面输出材料，会从各面接收物品，且和大多数AE2机器一样向各面提供[网络连接](../ae2-mechanics/me-network-connections.md)，类似线缆。

* 方向型样板供应器可由在普通样板供应器上使用<ItemLink id="certus_quartz_wrench" />产生。它们只会向选中面输出材料，会从各面接收物品，并且仅不向选中面提供[网络连接](../ae2-mechanics/me-network-connections.md)。这使得它们能向AE2机器输出物品而不连接网络，在构建子网络上非常有用。

* 面板型样板供应器是[线缆子部件](../ae2-mechanics/cable-subparts.md)，因此可在同一线缆上放置多个该种供应器，便于设计紧凑设施。它们和方向型供应器选中面功能类似，输出样板材料，接收物品，且**不**提供[网络连接](../ae2-mechanics/me-network-connections.md)。

样板供应器的普通和面板形态可在合成方格中转换。

## 设置

样板供应器有多种模式：

*   **阻挡模式**能在机器中已有材料时阻止供应器输出新批次
*   **锁定合成**能在多种红石信号状况下锁定供应器，也可在前一批材料的合成产物未返回该供应器前将其锁定
*   供应器可在<ItemLink id="pattern_access_terminal" />上显示或隐藏

## 优先级

可点击GUI右上角扳手以设置优先级。在多个[样板](../items-blocks-machines/patterns.md)对应同一物品时，在高优先级供应器中的样板会先于低优先级供应器中样板使用，除非网络无法供给高优先级样板所需材料。

## 常见误解

人们似乎总是会这么想，我不理解为什么，不过希望这一节能帮上忙。（也许人们只是理解错了，认为只有<ItemLink id="export_bus" />才能将物品输出网络，而没意识到样板供应器也能输出。）

如下设置不会如期望运作。正如[线缆](cables.md)中所提，线缆不是物品管道，它们没有内部容器，供应器无法向线缆输出。

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../assets/assemblies/provider_misconception_1.snbt" />

  <BoxAnnotation color="#dddddd" min="1 0 3" max="2 1 4">
        不是高炉
  </BoxAnnotation>

  <IsometricCamera yaw="95" pitch="5" />
</GameScene>

因为供应器没有输出的目的地，它不会运作。此处供应器仅作为将<ItemLink id="export_bus" />连接至网络的线缆存在。

供应器同样不会告诉<ItemLink id="export_bus" />要输出什么，输出总线只会输出其过滤槽中的事物。

我们实际搭建的设施如下：

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../assets/assemblies/provider_misconception_2.snbt" />

  <BoxAnnotation color="#dddddd" min="1 0 3" max="2 1 4">
        不是高炉
  </BoxAnnotation>

  <IsometricCamera yaw="95" pitch="5" />
</GameScene>

你可能想搭建的是这个，此处的样板供应器能将样板所需的材料输出至相邻机器：

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../assets/assemblies/provider_misconception_3.snbt" />

  <BoxAnnotation color="#dddddd" min="1 0 3" max="2 1 4">
        不是高炉
  </BoxAnnotation>

  <IsometricCamera yaw="95" pitch="5" />
</GameScene>

## 配方

<RecipeFor id="pattern_provider" />

<RecipeFor id="cable_pattern_provider" />
