---
navigation:
  parent: ae2-mechanics/ae2-mechanics-index.md
  title: 能量
  icon: energy_cell
---

# 能量

网络需要能量才能运作。网络中有一个能量库，[设备](../ae2-mechanics/devices.md)能直接从中获取能量，<ItemLink id="vibration_chamber" />、<ItemLink id="energy_acceptor" />（和<ItemLink id="controller" />）则能向其中输入能量。手持<ItemLink id="network_tool" />右击网络任意一处或右击网络的控制器即可查看能量统计。这种以网络为范围的存储和分布意味着能量传输速度没有上限，设备可以消耗任意多的能量，能源接收器能以近乎无限的速度接收能量，唯一的限制便是能量存储的容量。

## 接收能量

<Row>
  <BlockImage id="energy_acceptor" scale="4" />

  <GameScene zoom="4" background="transparent">
  <ImportStructure src="../assets/blocks/cable_energy_acceptor.snbt" />
  </GameScene>

  <BlockImage id="controller" p:state="online" scale="4" />

  <BlockImage id="vibration_chamber" p:active="true" scale="4" />
</Row>

AE2内部并不使用Forge Energy（Forge端）或是TechReborn Energy（Fabric端），而是将它们转换为自带的单位，AE。这种转换是单向的。能量转换可经由<ItemLink id="energy_acceptor" />和<ItemLink id="controller" />进行，不过控制器各面用于提供[频道](../ae2-mechanics/channels.md)更佳。也可用<ItemLink id="vibration_chamber" />生产能量，但是AE2还是与有更强产能能力的科技模组协同工作效果更好。

这表明在铺设基地能源基础设施时，更推荐将AE2网络看做一整个多方块结构。

Forge Energy与Techreborn Energy的转换比为：

*   2 FE = 1 AE（Forge）
*   1 E  = 2 AE（Fabric）

## 能量存储

<Row>
  <BlockImage id="energy_cell" scale="4" p:fullness="4" />

  <BlockImage id="dense_energy_cell" scale="4" p:fullness="4" />

  <BlockImage id="creative_energy_cell" scale="4" />
</Row>

由于一些显而易见的原因，网络无法在单游戏刻内消耗或接收超过其能量容量的能量。如果一个网络只能存储800AE，则在每游戏刻内，其各[设备](../ae2-mechanics/devices.md)无法使用超过800AE的能量（即便能量已满），能源接收器也无法接收超过800AE的能量（即便能量为空）。

这也解释了网络的一些奇怪行为。例如，有人搭建了一个只有能源接收器、驱动器、终端，和某些设备的小型网络，然后往里放进一整个物品栏的圆石。在单个游戏刻内同时放入所有圆石所需要的能量超过了网络能量容量，因此只能存入一部分圆石，网络也会耗尽能量并重启。

**可以加入能源元件以解决上述问题。**

网络中每个线缆、设备，以及部件均自带25AE的能量缓存。

<ItemLink id="controller" />有少量能量缓存：8000AE。

<ItemLink id="energy_cell" />可存储200kAE，这能轻松应对普通网络的能量尖峰；通常，每个网络中放一个就够了。

<ItemLink id="dense_energy_cell" />可存储1.6MAE，适用于脱离能量供应运行网络的情况和处理大型[空间存储](spatial-io.md)的巨量瞬时能量消耗。

<ItemLink id="creative_energy_cell" />是用于测试的创造模式物品，能提供无！限！能！量！
