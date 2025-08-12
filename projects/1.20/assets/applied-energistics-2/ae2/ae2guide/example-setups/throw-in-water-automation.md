---
navigation:
  parent: example-setups/example-setups-index.md
  title: 投水自动化
  icon: fluix_crystal
---

# 自动化投水配方

需注意，此设施使用了<ItemLink id="pattern_provider" />，也即需与你的[自动合成](../ae2-mechanics/autocrafting.md)设施配合使用。

某些配方可能要求将物品投入水中（不过同种设施也可用于处理其他物品投入某处的要求）。可用<ItemLink id="formation_plane" />、<ItemLink id="annihilation_plane" />，以及辅助基础设施（也即2个经调整的[管道子网络](pipe-subnet.md)）自动化这类配方。

此设施应与[充能器自动化](charger-automation.md)配合使用以生产<ItemLink id="charged_certus_quartz_crystal" />。

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/throw_in_water.snbt" />

<BoxAnnotation color="#dddddd" min="2 0 1" max="3 1 2">
        （1）样板供应器：默认配置，装有相应处理样板。

        ![福鲁伊克斯样板](../assets/diagrams/fluix_pattern_small.png) ![有瑕母岩样板](../assets/diagrams/flawed_budding_pattern_small.png)
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1.7 0 1" max="2 1 2">
        （2）接口：默认配置。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1 .7 1" max="2 1 2">
        （3）成型面板：设置为以物品形式掉落。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1 2 1" max="2 2.3 2">
        （4）破坏面板：无可用GUI。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="2 1 1" max="3 1.3 2">
        （5）存储总线：过滤样板输出。
        <Row><ItemImage id="fluix_crystal" scale="2" /><BlockImage id="flawless_budding_quartz" scale="2" /></Row>
  </BoxAnnotation>

<DiamondAnnotation pos="3.9 0.5 1.5" color="#00ff00">
        至主网络或充能器自动化设施
        <GameScene zoom="3" background="transparent">
          <ImportStructure src="../assets/assemblies/charger_automation.snbt" />
          <IsometricCamera yaw="195" pitch="30" />
        </GameScene>
    </DiamondAnnotation>

  <IsometricCamera yaw="180" pitch="0" />
</GameScene>

## 配置与样板

* <ItemLink id="pattern_provider" />（1）处于默认配置，装有相关<ItemLink id="processing_pattern" />。
  * 对于<ItemLink id="fluix_crystal" />，JEI/REI的默认配方就可以了：

    ![福鲁伊克斯样板](../assets/diagrams/fluix_pattern.png)

  * 对于<ItemLink id="flawed_budding_quartz" />，直接用<ItemLink id="quartz_block" />制造更佳，否则输入输出的物品可能重叠，不利于配置过滤：

    ![有瑕母岩样板](../assets/diagrams/flawed_budding_pattern.png)

* <ItemLink id="interface" />（2）处于默认配置。
* <ItemLink id="formation_plane" />（3）设置为以物品形式掉落。
* <ItemLink id="annihilation_plane" />（4）没有GUI且无法配置。
* <ItemLink id="storage_bus" />（5）设置为过滤样板产物。

## 工作原理

1.  <ItemLink id="pattern_provider" />将材料送入相邻的<ItemLink id="interface" />（位于绿色子网络）。
2.  接口（默认设置为不存储任何物品）尝试将其中事物送入[网络存储](../ae2-mechanics/import-export-storage.md)。
3.  绿色子网络上的存储位置仅有<ItemLink id="formation_plane" />，其会将接收到的物品投入水中。
4.  橙色子网络上的<ItemLink id="annihilation_plane" />会尝试捡起刚投入的物品，但由于样板供应器上的<ItemLink id="storage_bus" />（也即橙色子网络唯一的存储位置）设置为过滤合成产物，该面板不会捡起配方材料。
5.  物品在世界中发生变化。
6.  由于存储总线可以存储产物，破坏面板此时能捡起其前方的物品。
7.  存储总线将产物存入样板供应器，并返回至主网络。
