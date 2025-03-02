---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME阈值输出总线
    icon: extendedae:threshold_export_bus
categories:
- extended devices
item_ids:
- extendedae:threshold_export_bus
---

# ME阈值输出总线

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/cable_threshold_export_bus.snbt"></ImportStructure>
</GameScene>

只有在ME网络中某物品的数量高于/低于阈值时，ME阈值输出总线才会运作。

## 示例

![界面](../pic/thr_bus_gui1.png)

铜的阈值设为128，所以只会在网络中的铜多于128个时输出。

![界面](../pic/thr_bus_gui2.png)

同上，将模式设为“低于阈值时工作”，此时网络中的铜会在少于128个时输出。
