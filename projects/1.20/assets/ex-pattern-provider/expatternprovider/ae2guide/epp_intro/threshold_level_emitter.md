---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME阈值发信器
    icon: expatternprovider:threshold_level_emitter
categories:
- extended devices
item_ids:
- expatternprovider:threshold_level_emitter
---

# ME阈值发信器

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/cable_threshold_level_emitter.snbt"></ImportStructure>
</GameScene>

它的工作模式类似于RS锁存器。当网络中物品的数量高于上限阈值时会一直输出红石信号，直到数量低于下限阈值时才会重新停止输出。

例如，将下限阈值设为100，上限阈值设为150。

起初网络是空的，所以发信器不会被激活。

当物品的数量增加到150个以上时，发信器会发出红石信号。

当数量下降到100-150之间时，发信器仍发出信号。

直到数量低于100时，发信器停止输出信号。