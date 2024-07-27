---
navigation:
  parent: ae2-mechanics/ae2-mechanics-index.md
  title: 网络连接
  icon: fluix_glass_cable
---

# 网络连接

## “网络”是什么意思？

“网络”是一组可像[线缆](../items-blocks-machines/cables.md)一样传输[频道](../ae2-mechanics/channels.md)的连在一起的[设备](../ae2-mechanics/devices.md)或方块形态机器和[设备](../ae2-mechanics/devices.md)。（<ItemLink id="charger" />、<ItemLink id="interface" />、<ItemLink id="drive" />，等等。）单个线缆理论上也算是一个网络。

## 设备位置简述

对于有特殊网络功能的[设备](../ae2-mechanics/devices.md)（例如向[网络存储](../ae2-mechanics/import-export-storage.md)输入输出的<ItemLink id="interface" />，读取网络存储信息的<ItemLink id="level_emitter" />，作为网络存储的<ItemLink id="drive" />等。）来说，设备本身的物理位置不重要。

再提一遍，**设备的物理位置不重要**。重要之处在于设备连上了网络（以及连上了哪个网络）。

## 网络连接

可通过<ItemLink id="network_tool" />轻松检测网络中连接的事物。它会显示网络中的每个组件，如果看到不应该出现或者没看到本应该出现的东西，那就是碰上问题了。

例如，如下是2个独立的网络。

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/2_networks_1.snbt" />

  <BoxAnnotation color="#5CA7CD" min="0 0 0" max="1 2 2">
        网络1
  </BoxAnnotation>

<BoxAnnotation color="#5CA7CD" min="2 0 0" max="3 2 2">
        网络2
  </BoxAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

如下也是2个独立的网络，因为<ItemLink id="quartz_fiber" />只传输[能量](../ae2-mechanics/energy.md)而不提供网络连接。

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/2_networks_2.snbt" />

  <BoxAnnotation color="#915dcd" min="0 0 0" max="1 2 2">
        网络1
  </BoxAnnotation>

  <BoxAnnotation color="#915dcd" min="1.3 0 0" max="3 2 2">
        网络2
  </BoxAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

而如下则只有1个网络（不是2个）。[量子桥](../items-blocks-machines/quantum_bridge.md)类似无线的[致密线缆](../items-blocks-machines/cables.md#dense-cable)，因此其两端处于同一网络。

<GameScene zoom="4" background="transparent">
  <ImportStructure src="../assets/assemblies/actually_1_network.snbt" />

  <BoxAnnotation color="#915dcd" min="0 0 0" max="7 3 3">
        只有1个网络
  </BoxAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

如下也只有1个网络，因为[线缆](../items-blocks-machines/cables.md)颜色与网络连接无关而只会阻止不同色线缆连接。所有颜色的线缆都会与福鲁伊克斯色（或“未上色”）的线缆连接。

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/actually_1_network_2.snbt" />

  <BoxAnnotation color="#915dcd" min="0 0 0" max="4 2 2">
        只有1个网络
  </BoxAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 子网络中的连接

[子网络](../ae2-mechanics/subnetworks.md)通过控制网络连接（主要是**禁止**连接）来限制[设备](../ae2-mechanics/devices.md)对其他设备的访问权。

子网络本质上就是一个独立的网络。

以[自动时运矿石机](../example-setups/ore-fortuner.md)为例。此设施内有3个独立网络，且均用于完成特定任务。

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/ore_fortuner.snbt" />

  <BoxAnnotation color="#915dcd" min="0 0 2" max="3 1 3">
        网络1，相当于一个管道子网络，限制了输入总线的访问范围，使其只能通过成型面板“存储”矿石方块。
  </BoxAnnotation>

  <BoxAnnotation color="#5CA7CD" min="0 0 0" max="3 1 1">
        网络2，相当于另一个管道子网络，限制了破坏面板的访问范围，使其只会将时运所得的矿石小块存入木桶，而非存入子网络。这也说明它不会占用主网络中的频道。
  </BoxAnnotation>

  <BoxAnnotation color="#82CD5C" min="2 0 1" max="4 1 2">
        网络3，包含所有存储和物品的主网络。此处仅作能源，并且*未*与前两个子网络相连接。
  </BoxAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

## P2P通道中的连接

有一种[P2P通道](../items-blocks-machines/p2p_tunnels.md)传递的不是物品、流体、红石信号，而是[频道](channels.md)，有些人也因此不能理解它们。P2P通道所处于的网络和其所传递的网络之间没有任何联系。当然这两个网络*可以*是同一个，但一般不会这么做。

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/p2p_channels_network_connection.snbt" />

  <BoxAnnotation color="#915dcd" min="0 0 0" max="1.98 2 1">
        网络1，所传递的网络（通常是主网络）
  </BoxAnnotation>

  <BoxAnnotation color="#5CA7CD" min="2.02 0 0" max="3.98 1 1">
        网络2，P2P通道所处的网络（通常*不*是主网络）
  </BoxAnnotation>

  <BoxAnnotation color="#915dcd" min="4.02 0 0" max="6 1 1">
        网络1，所传递的网络（通常是主网络）
  </BoxAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 相对不直观的连接

这种情况下只有1个网络，因为方块形态的<ItemLink id="pattern_provider" />和线缆功能类似，<ItemLink id="inscriber" />也是一样。正因此，网络连接能跨供应器和压印器传输。

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/pattern_provider_network_connection_1.snbt" />

  <BoxAnnotation color="#915dcd" min="0 0 0" max="4 2 2">
        只有1个网络
  </BoxAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

为避免这种情况出现（在与[子网络](../ae2-mechanics/subnetworks.md)相关的自动化设施中相当有用），可手持<ItemLink id="certus_quartz_wrench" />右击供应器以将其变为方向型，它便不会在选中面传输频道。

<Row gap="40">
<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/pattern_provider_network_connection_2.snbt" />

  <BoxAnnotation color="#915dcd" min="0 0 0" max="1.98 2 2">
        网络1
  </BoxAnnotation>

  <BoxAnnotation color="#5CA7CD" min="2.02 0 0" max="4 2 2">
        网络2
  </BoxAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/pattern_provider_directional_connection.snbt" />

  <BoxAnnotation color="#ee3333" min="1 .3 .3" max="1.3 .7 .7">
        注意线缆并未连接
  </BoxAnnotation>

  <IsometricCamera yaw="255" pitch="30" />
</GameScene>
</Row>

其他不提供方向型网络连接的大多是[子部件](../ae2-mechanics/cable-subparts.md)[设备](../ae2-mechanics/devices.md)，例如<ItemLink id="import_bus" />、<ItemLink id="storage_bus" />，和<ItemLink id="cable_interface" />。

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/subpart_no_connection.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>