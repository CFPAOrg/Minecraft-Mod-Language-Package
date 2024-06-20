---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME 阈值发信器
    icon: expatternprovider:threshold_level_emitter
categories:
- extended devices
item_ids:
- expatternprovider:threshold_level_emitter
---

# ME 阈值发信器

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/cable_threshold_level_emitter.snbt"></ImportStructure>
</GameScene>

它的工作原理类似于RS锁存器。当网络中的物品数量少于下限阈值时，关闭红石信号，当数量大于上限阈值时输出红石信号。

例如，将下限阈值设为100，上限阈值设为150。

起初网络是空的，所以发信器不会被激活。

当物品的数量增加到150个以上时，发信器会发出红石信号。

当数量下降且小于150时，发信器仍发出信号。

最后数量少于100，发信器停止输出信号。