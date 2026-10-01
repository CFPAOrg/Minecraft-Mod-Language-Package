---
navigation:
  parent: nodeworks-mechanics/index.md
  title: 子网
  icon: broadcast_antenna
categories:
  - networking
  - mechanic
---

# 子网

子网本质上是独立的网络，只是会把自身的部分功能无线向其他网络公开。每一个子网都有其<ItemLink id="network_controller" />、存储空间、合成设施。它们通过配对的<ItemLink id="broadcast_antenna" />和<ItemLink id="receiver_antenna" />与主网交流。

<GameScene zoom="3" interactive={true} paddingTop="30" paddingLeft="50" paddingRight="50">
  <ImportStructure src="../assets/assemblies/subnet.snbt" />
</GameScene>

## 为何要拆分网络

对于小型基地来说，单一网络就已足够；但随着机器和配方的不断加入，拆分就变成了很好的网络组织方式：

- **特化**。使用专用于烧炼、酿造、矿物处理的子网，可将原本散落在基地各处的有关配方和机器汇总在一起。
- **重用**。只需搭建一次烧炼子网，之后把所有配方和它配对即可。
- **隔离**。子网的崩溃、卡顿、合成阻塞不会影响外部。每个网络都有自身的CPU、网络存储、脚本。
- **整洁**。主网络只能看见子网广播的配方，从而将管道和机器隐藏起来。

## 公开处理配方

最常见的子网设施如下：子网内有一<ItemLink id="processing_storage" />方块集群，其中有一系列<ItemLink id="processing_set" />配方；广播即可让其他网络在自动合成时取用它们。

1. 在子网中，搭建<ItemLink id="processing_storage" />集群，放入子网应公开的各<ItemLink id="processing_set" />。
2. 直接在集群内任意<ItemLink id="processing_storage" />的上方放置<ItemLink id="broadcast_antenna" />。
3. 在天线的GUI内使用<ItemLink id="link_crystal" />进行配对。
4. 在接收网络中，向网络接入<ItemLink id="receiver_antenna" />，并在其GUI中放入同一块<ItemLink id="link_crystal" />。

如此，接收网络即能看见子网处理存储器集群中的所有配方，如同网络在本地拥有这些配方一样。需用到这些配方的合成作业和其他自动合成的行为一致。

机器和原材料依然归子网所有。接收网络需要请求产物，并静待子网发来。

## 无线物品传输

在<ItemLink id="export_chest" />与<ItemLink id="import_chest" />上方的<ItemLink id="receiver_antenna" />配对后，子网还可通过该导出箱直接交换物品。配对方式参见导出箱和接收天线页面。

## 范围

天线的默认范围为128格。范围升级可将其扩展至跨更多区块和跨维度，所以子网不必紧邻主网搭建。常见的用法有：

- 下界的烧炼子网向主世界的主基地供应产物。
- 生物农场将掉落物广播至别处的分拣基地。
- 共享式“图书馆”子网，提供通用配方给服务端内其他所有基地使用。
