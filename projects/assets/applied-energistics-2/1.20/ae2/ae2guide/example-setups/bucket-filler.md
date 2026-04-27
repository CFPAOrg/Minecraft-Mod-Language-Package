---
navigation:
  parent: example-setups/example-setups-index.md
  title: 铁桶填充器
  icon: minecraft:water_bucket
---

# 铁桶填充器

参阅[铁桶清空器](bucket-emptier.md)。

需注意，此设施使用了<ItemLink id="pattern_provider" />，也即需与你的[自动合成](../ae2-mechanics/autocrafting.md)设施配合使用。

生活总有不顺心时，有些时候你需要桶装的流体而非流体本身。有些时候会有一种机器帮你完成这些任务（比如Thermal Expansion里的流体转置机），但这种模组并不一定一直都有。好在原版也有一种稍微不那么方便的处理方式，那就是<ItemLink id="minecraft:dispenser" />。

**需注意，这一设施通常并非必要，[样板编码终端](../items-blocks-machines/terminals.md#pattern-encoding-terminal)中的流体替换选项允许你在合成配方中使用流体本身，而非桶装流体。**

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/bucket_filler.snbt" />

<BoxAnnotation color="#dddddd" min="2 1 0" max="3 2 1">
        （1）样板供应器：设置为“有红石信号时”锁定合成，装有相应处理样板。

        <Row>
        ![填充样板](../assets/diagrams/water_fill_pattern_small.png)
        ![填充样板](../assets/diagrams/lava_fill_pattern_small.png)
        </Row>
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="3 1.1 0.1" max="3.2 1.9 0.9">
        （2）接口：默认配置。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="3.1 1.1 0.8" max="3.9 1.9 1">
        （3）存储总线#1：默认配置。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="4.05 1.05 0.8" max="4.95 1.95 1">
        （4）成型面板：通过反相卡设置为排除铁桶。
        <Row><ItemImage id="minecraft:bucket" scale="2" /><ItemImage id="inverter_card" scale="2" /></Row>
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="3.2 2 1.2" max="3.8 2.2 1.8">
        （5）输入总线：通过反相卡设置为排除铁桶。
        <Row><ItemImage id="minecraft:bucket" scale="2" /><ItemImage id="inverter_card" scale="2" /></Row>
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="2.1 2 0.1" max="2.9 2.2 0.9">
        （6）存储总线#2：默认配置。
  </BoxAnnotation>

<DiamondAnnotation pos="0 1.5 0.5" color="#00ff00">
        至主网络
    </DiamondAnnotation>

  <IsometricCamera yaw="225" pitch="45" />
</GameScene>

## 配置

* <ItemLink id="pattern_provider" />（1）设置为“有红石信号时”锁定合成，装有相应<ItemLink id="processing_pattern" />。

    ![充能器样板](../assets/diagrams/water_fill_pattern.png)
    ![充能器样板](../assets/diagrams/lava_fill_pattern.png)

* <ItemLink id="interface" />（2）处于默认配置。
* 第一个<ItemLink id="storage_bus" />（3）处于默认配置。
* <ItemLink id="formation_plane" />（4）通过反相卡设置为排除铁桶。
  <Row><ItemImage id="minecraft:bucket" scale="2" /><ItemImage id="inverter_card" scale="2" /></Row>
* <ItemLink id="import_bus" />（5）通过反相卡设置为排除铁桶。
  <Row><ItemImage id="minecraft:bucket" scale="2" /><ItemImage id="inverter_card" scale="2" /></Row>
* 第二个<ItemLink id="storage_bus" />（6）处于默认配置。

## 工作原理

1. <ItemLink id="pattern_provider" />将材料送入<ItemLink id="interface" />。
   （作为优化，实际上其会直接向存储总线输出，这些存储总线类似于供应器自身的输出面。物品并不会真正进入接口。）
2. 经过[管道子网络](pipe-subnet.md#providing-to-multiple-places)中所述的设施，铁桶会抵达<ItemLink id="minecraft:dispenser" />，流体则使用成型面板放置。
3. <ItemLink id="minecraft:comparator" />检测发射器中的铁桶，并由此同时激活发射器和锁定the <ItemLink id="pattern_provider" />。
4. 发射器用铁桶装起流体，此时发射器内为装有流体的桶。
5. <ItemLink id="import_bus" />将发射器中的空桶抽出，通过<ItemLink id="storage_bus" />存入样板供应器，并返回至主网络。
6. 比较器发现发射器已空，从而解锁供应器。