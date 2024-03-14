---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 控制器
  icon: controller
  position: 110
categories:
- network infrastructure
item_ids:
- ae2:controller
---

# 控制器

<BlockImage id="controller" p:state="online" scale="8" />

控制器是[ME网络](../ae2-mechanics/me-network-connections.md)的寻路中心。若没有控制器，则网络是“自组织”网络，且最多只能包含8台占用频道的[设备](../ae2-mechanics/devices.md)。

不允许在同一个[ME网络](../ae2-mechanics/me-network-connections.md)中存在多组控制器。

控制器每面提供32个[频道](../ae2-mechanics/channels.md)。

每个控制器方块需要消耗6AE/t才可正常工作。每个控制器方块可存储8000AE，更大的网络可能需要额外的能量存储容量。详细信息参见[能量](../ae2-mechanics/energy.md)。

多方块控制器的结构相对自由。

<GameScene zoom="2" background="transparent">
  <ImportStructure src="../assets/assemblies/controllers.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

不过，仍有几条需要遵守的规则：

1.  同一个[ME网络](../ae2-mechanics/me-network-connections.md)的所有控制器方块必须相邻，否则所有方块都会变红。
2.  控制器的大小需小于等于7x7x7，否则会变红。
3.  控制器中方块最多只能在1个轴向方向上有2个相邻方块，若有方块违反此规则，控制器会失效并变红。

<GameScene zoom="2" background="transparent">
  <ImportStructure src="../assets/assemblies/controller_rules.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

在遵守所有规则且供给能量的情况下，控制器会发光并循环显示颜色。

右击控制器可打开和<ItemLink id="network_tool" />相同的GUI。

## 配方

<RecipeFor id="controller" />
