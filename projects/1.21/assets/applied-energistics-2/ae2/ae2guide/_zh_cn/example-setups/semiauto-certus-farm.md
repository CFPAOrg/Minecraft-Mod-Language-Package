---
navigation:
  parent: example-setups/example-setups-index.md
  title: 半自动赛特斯石英农场
  icon: certus_quartz_crystal
  position: 115
---

# 半自动赛特斯石英农场

不幸的是，[简单赛特斯石英农场](simple-certus-farm.md)需要<ItemLink id="flawless_budding_quartz" />才能完全自动化。而这又需要[空间IO](../ae2-mechanics/spatial-io.md)或是直接在[陨石](../ae2-mechanics/meteorites.md)处搭建农场。

不过，AE2能够放置和破坏方块，所以它也许有那么一些可能能让农场*帮你替换赛特斯石英母岩*。（你仍需要周期性往输入木桶中放<ItemLink id="flawed_budding_quartz" />，并从枯竭母岩木桶中取出<ItemLink id="quartz_block" />。）

此设施的完全自动化参见[进阶赛特斯石英农场](advanced-certus-farm.md)。

这个农场相较[简单赛特斯石英农场](simple-certus-farm.md)来说复杂许多，原因在于它实际上是3个独立设施堆起来的。

生长速度估计值见[赛特斯石英的生长](../ae2-mechanics/certus-growth.md)。

**这是个有遮挡关系的复杂建筑，可以旋转视角从各向观察**

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/semiauto_certus_farm.snbt" />

  <BoxAnnotation color="#ddaaaa" min="3.7 2 1" max="4 3 2">
        （1）破坏面板#1：无可用GUI，但可附有时运。
  </BoxAnnotation>

  <BoxAnnotation color="#ddaaaa" min="2 2 1" max="2.3 3 2">
        （2）存储总线#1：过滤赛特斯石英水晶。
        <ItemImage id="certus_quartz_crystal" scale="2" />
  </BoxAnnotation>

  <DiamondAnnotation pos="3 2.5 1.5" color="#ff0000">
    石英簇破坏器子网络
  </DiamondAnnotation>

  <BoxAnnotation color="#aaddaa" min="3.7 1 1" max="4 2 2">
        （3）破坏面板#2：无可用GUI，附有精准采集。
  </BoxAnnotation>

  <BoxAnnotation color="#aaddaa" min="2 1 1" max="2.3 2 2">
        （4）存储总线#2：过滤赛特斯石英块。
        <BlockImage id="quartz_block" scale="2" />
  </BoxAnnotation>

  <DiamondAnnotation pos="3 1.5 1.5" color="#00ff00">
    赛特斯石英块破坏器子网络
  </DiamondAnnotation>

  <BoxAnnotation color="#ffddaa" min="4 0.7 1" max="5 1 2">
        （5）成型面板：默认配置。
  </BoxAnnotation>

  <BoxAnnotation color="#ffddaa" min="2 0 1" max="2.3 1 2">
        （6）输入总线：默认配置。
  </BoxAnnotation>

  <DiamondAnnotation pos="3 0.5 1.5" color="#ddcc00">
    母岩放置器子网络
  </DiamondAnnotation>

  <BoxAnnotation color="#aaaadd" min="0.7 2 1" max="1 3 2">
        （7）存储总线#3：过滤赛特斯石英水晶。优先级高于主网络。
        <ItemImage id="certus_quartz_crystal" scale="2" />
  </BoxAnnotation>

    <DiamondAnnotation pos="1.5 0.5 1.5" color="#00ff00">
        手动放入有瑕的赛特斯石英母岩。
        <BlockImage id="flawed_budding_quartz" scale="2" />
    </DiamondAnnotation>

    <DiamondAnnotation pos="1.5 1.5 1.5" color="#00ff00">
        手动拿出赛特斯石英块。
        <BlockImage id="quartz_block" scale="2" />
    </DiamondAnnotation>

<DiamondAnnotation pos="0.5 0.5 0" color="#00ff00">
        至主网络
    </DiamondAnnotation>

  <IsometricCamera yaw="165" pitch="5" />
</GameScene>

## 设置

### 石英簇破坏器：

* 第一个<ItemLink id="annihilation_plane" />（1）没有GUI且无法配置，可附有时运。
* 第一个<ItemLink id="storage_bus" />（2）设置为过滤<ItemLink id="certus_quartz_crystal" />。

### 赛特斯石英块破坏器：

* 第二个<ItemLink id="annihilation_plane" />（3）没有GUI且无法配置，但必须附有精准采集。
* 第二个<ItemLink id="storage_bus" />（4）设置为过滤<ItemLink id="quartz_block" />。

### 母岩放置器：

* <ItemLink id="formation_plane" />（5）处于默认配置。
* <ItemLink id="import_bus" />（6）处于默认配置。

### 主网络：

* 第三个<ItemLink id="storage_bus" />（7）设置为过滤<ItemLink id="certus_quartz_crystal" />，且其[优先级](../ae2-mechanics/import-export-storage.md#存储优先级)高于主网络存储。

## 工作原理

### 石英簇破坏器：

石英簇破坏器子网络和[简单赛特斯石英农场](simple-certus-farm.md)中的子网络功能非常类似。

1. <ItemLink id="annihilation_plane" />尝试破坏其前方的事物，但由于子网络中存储位置仅有过滤<ItemLink id="certus_quartz_crystal" />的<ItemLink id="storage_bus" />，其只会破坏<ItemLink id="quartz_cluster" />。
2. <ItemLink id="storage_bus" />将赛特斯石英水晶存入木桶。

### 赛特斯石英块破坏器：

赛特斯石英块破坏器的功能是在母岩枯竭而变为<ItemLink id="quartz_block" />时将其破坏。此设施和石英簇破坏器原理类似。

1. <ItemLink id="annihilation_plane" />尝试破坏其前方的事物，但由于子网络中存储位置仅有过滤<ItemLink id="quartz_block" />的<ItemLink id="storage_bus" />，其只会破坏<ItemLink id="quartz_block" />。此面板需附有精准采集，避免破坏母岩的行为本身导致的降级。
2. <ItemLink id="storage_bus" />将赛特斯石英块存入用于存储枯竭母岩的木桶，你需要手动将其和<ItemLink id="charged_certus_quartz_crystal" />投入水中以升级。

### 母岩放置器：

母岩放置器的功能是在破坏器子网络破坏已枯竭的母岩时放置新的<ItemLink id="flawed_budding_quartz" />。

1. <ItemLink id="import_bus" />从输入木桶中抽取母岩。
2. 子网络中的存储位置仅有<ItemLink id="formation_plane" />，其会放置母岩。

### 主网络：

* <ItemLink id="storage_bus" />使得主网络（以及[充能器自动化](charger-automation.md)设施）能够访问木桶中的赛特斯石英水晶。其[优先级](../ae2-mechanics/import-export-storage.md#存储优先级)较高，因此赛特斯石英水晶会优先进入木桶而非主网络存储。