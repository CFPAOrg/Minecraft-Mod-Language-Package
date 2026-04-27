---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 触发总线
  icon: toggle_bus
  position: 110
categories:
- network infrastructure
item_ids:
- ae2:toggle_bus
- ae2:inverted_toggle_bus
---

# 触发总线

<GameScene zoom="8" background="transparent">
<ImportStructure src="../assets/assemblies/toggle_bus.snbt" />
<IsometricCamera yaw="195" pitch="30" />
</GameScene>

触发总线是与<ItemLink id="fluix_glass_cable" />和其他线缆功能类似的总线，区别在于其连接状态会受红石信号调控。可用其连通或切断[ME网络](../ae2-mechanics/me-network-connections.md)的连接。

触发总线会在收到红石信号时连通连接，<ItemLink id="inverted_toggle_bus" />则行为相反，会在收到红石信号时断开连接。

需要注意，切换连接状态会导致网络重启并重新统计所连的设备。

它们是[线缆子部件](../ae2-mechanics/cable-subparts.md)。

## 配方

<RecipeFor id="toggle_bus" />

<RecipeFor id="inverted_toggle_bus" />
