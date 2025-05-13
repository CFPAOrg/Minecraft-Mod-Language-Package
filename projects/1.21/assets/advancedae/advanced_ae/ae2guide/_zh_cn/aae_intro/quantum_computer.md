---
navigation:
  parent: aae_intro/aae_intro-index.md
  title: 量子计算机
  icon: advanced_ae:quantum_core
categories:
  - advanced devices
item_ids:
  - advanced_ae:quantum_unit
  - advanced_ae:quantum_core
  - advanced_ae:quantum_structure
  - advanced_ae:quantum_accelerator
  - advanced_ae:quantum_multi_threader
  - advanced_ae:quantum_storage_128
  - advanced_ae:quantum_storage_256
  - advanced_ae:data_entangler
---

# 量子计算机

量子计算机是一种特殊的合成CPU。只要合成存储空间足够，它就可以执行无限多的合成请求。

<GameScene zoom="2" background="transparent">
  <ImportStructure src="../structure/quantum_computer_multiblock.snbt"></ImportStructure>
</GameScene>

## 量子计算机核心

<BlockImage id="advanced_ae:quantum_core" p:powered="true" p:formed="true" scale="4"></BlockImage>

量子计算机核心是量子计算机的心脏。它自身就拥有256M的合成存储空间和8个并行处理线程。只有它可仅凭自身构成一台量子计算机，同时还具有量子计算机的一切优势。不过，把它放到多方块结构中，造出的计算机还会更加强力。单独使用时必须从顶面或底面的能量接口供能。

## 量子计算机存储器

<Row gap="20">
<BlockImage id="advanced_ae:quantum_storage_128" scale="4"></BlockImage>
<BlockImage id="advanced_ae:quantum_storage_256" scale="4"></BlockImage>
</Row>

这些方块能加大量子计算机核心的合成存储空间，也相当于增加量子计算机并行任务的数量上限。此类方块有两种变种，容量分别为128M和256M。

## 量子数据纠缠器

<BlockImage id="advanced_ae:data_entangler" scale="4"></BlockImage>

数据纠缠器是一种特殊方块，会影响多方块结构中的所有存储方块。它可让数据存储于多个维度，相当于让存储空间变成了原来的4倍。每个量子计算机多方块结构中只能存在一个此方块。

## 量子计算机加速器

<BlockImage id="advanced_ae:quantum_accelerator" scale="4"></BlockImage>

量子计算机加速器可为量子计算机多方块增加8个并行处理线程。需注意，量子计算机执行的所有样板共享所有并行线程，最好多准备些这种方块。

## 量子计算机多线程处理器

<BlockImage id="advanced_ae:quantum_multi_threader" scale="4"></BlockImage>

多线程处理器和数据纠缠器类似，它能在多个维度执行新线程，相当于让并行处理能力变为原先的4倍。每个量子计算机多方块中只能存在一个此方块。

## 量子计算机结构方块

<Row gap="20">
<BlockImage id="advanced_ae:quantum_structure" scale="4"></BlockImage>
<BlockImage id="advanced_ae:quantum_structure" p:formed="true" scale="4"></BlockImage>
<BlockImage id="advanced_ae:quantum_structure" p:formed="true" p:powered="true" scale="4"></BlockImage>
</Row>

这些方块构成了量子计算机的框架。它们可用来搭建量子计算机和连接各组件。

## 多方块结构

量子计算机多方块结构需遵守如下规则：
- 最大尺寸为7x7x7（外部尺寸）
- 结构内部不允许存在空腔，可用<ItemLink id="advanced_ae:quantum_unit" />填补，但这么做不会增强计算机的性能
- 有且仅有一个<ItemLink id="advanced_ae:quantum_core" />
- 至多一个<ItemLink id="advanced_ae:data_entangler" />
- 至多一个<ItemLink id="advanced_ae:quantum_multi_threader" />
- 最外层的方块必须均为<ItemLink id="advanced_ae:quantum_structure" />
- 内部的方块不允许为<ItemLink id="advanced_ae:quantum_structure" />

## 服务端配置

部分值可在服务端配置中微调，如：
- 多方块最大尺寸
- 每个量子计算机加速器的并行线程数
- 多线程处理器的最大允许数目
- 多线程处理器的线程数乘数
- 数据纠缠器的最大允许数目
- 数据纠缠器的容量乘数

你所使用的版本可在物品的提示文本处查看。