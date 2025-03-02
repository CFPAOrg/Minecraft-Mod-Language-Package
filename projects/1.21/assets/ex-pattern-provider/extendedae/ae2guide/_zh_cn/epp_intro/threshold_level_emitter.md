---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME阈值发信器
    icon: extendedae:threshold_level_emitter
categories:
- extended devices
item_ids:
- extendedae:threshold_level_emitter
---

# ME阈值发信器

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/cable_threshold_level_emitter.snbt"></ImportStructure>
</GameScene>

阈值发信器的机制与RS锁存器类似。网络中某物品的数量低于下限时，其会关闭红石信号；而在高于上限时，则会重新发出红石信号。

例如，某发信器的下限为100，上限为150。

初始时网络为空，发信器不激活。

物品增多到超出150个后，发信器即开始发出红石信号。

而当数量降至低于150时，发信器仍会发出信号。

最后在数量降到100以下后，发信器才会关闭。
