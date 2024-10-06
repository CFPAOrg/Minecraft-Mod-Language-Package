---
navigation:
  parent: example-setups/example-setups-index.md
  title: 熔炉自动化
  icon: minecraft:furnace
---

# 熔炉自动化

需注意，此设施使用了<ItemLink id="pattern_provider" />，也即需与你的[自动合成](../ae2-mechanics/autocrafting.md)设施配合使用。如需独立自动化熔炉，则应使用漏斗，箱子等。

自动化<ItemLink id="minecraft:furnace" />相较自动化[充能器](../example-setups/charger-automation.md)之类更为简单的机器来说略显复杂。熔炉需从两个不同面输入，并需从第三个面输出。需烧炼的物品必须从顶面输入，燃料必须从侧面输入，产物必须从底面输出。

这可通过在顶面放置<ItemLink id="pattern_provider" />，在侧面放置<ItemLink id="export_bus" />以不断输入燃料，在底面放置<ItemLink id="import_bus" />以返回产物至网络解决。然而，这么做需要占用3个[频道](../ae2-mechanics/channels.md)。

如下是仅需占用1个频道的方法：

<GameScene zoom="6" interactive={true}>
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

## 配置

* <ItemLink id="pattern_provider" />（1）处于默认配置，装有相应<ItemLink id="processing_pattern" />。已被<ItemLink id="certus_quartz_wrench" />改为方向型。

  ![铁样板](../assets/diagrams/furnace_pattern.png)

* <ItemLink id="interface" />（2）处于默认配置。
* 第一个<ItemLink id="storage_bus" />（3）设置为过滤煤炭或其他燃料。
* 第二个<ItemLink id="storage_bus" />（4）以<ItemLink id="inverter_card" />通过反相卡设置为排除所用燃料。

## 工作原理

1. <ItemLink id="pattern_provider" />将材料送入<ItemLink id="interface" />。
   （实际上其会直接向存储总线输出，这些存储总线类似于供应器自身的输出面。物品并不会真正进入接口。）
2. 接口设置为不存储任何事物，因此其会尝试将材料送入[网络存储](../ae2-mechanics/import-export-storage.md)。
3. 绿色子网络上的存储位置仅有<ItemLink id="storage_bus" />。过滤煤炭的总线能将煤炭通过熔炉侧面送入燃料槽。过滤非煤炭的总线则将需烧炼的物品通过顶面送入材料槽。
4. 熔炉干完本职工作。
5. 漏斗将产物从熔炉底面导出并放入供应器的返回栏，从而将其返回至主网络。
