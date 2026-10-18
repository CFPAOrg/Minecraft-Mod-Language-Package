---
navigation:
  parent: example-setups/example-setups-index.md
  title: 自调控造石机
  icon: minecraft:cobblestone
---

# 自调控造石机

自动化造石机很简单，把<ItemLink id="annihilation_plane" />朝向一个标准原版手动造石机即可。然而这么做会导致网络被圆石塞满，因此需要一些调控。

鉴于破坏面板的工作方式（类似<ItemLink id="import_bus" />），不能直接把<ItemLink id="level_emitter" />面向装有<ItemLink id="redstone_card" />的<ItemLink id="export_bus" />（因为无法在没有中间存储的情况下直接输入输出）。需要稍微绕点路。

<ItemLink id="toggle_bus" />可受红石信号控制而连接或断开网络连接，但其触发会导致网络重启。对此有一个简单的解决方案：在[子网络](../ae2-mechanics/subnetworks.md)上放置触发总线。这么做只会重启子网络。

可以设计一个由<ItemLink id="annihilation_plane" />和<ItemLink id="storage_bus" />组成的独立[子网络](../ae2-mechanics/subnetworks.md)以将物品输入主网络的<ItemLink id="interface" />。触发总线则与<ItemLink id="quartz_fiber" />连接或断开，以此提供或切断能量供给。

<GameScene zoom="4" interactive={true}>
  <ImportStructure src="../assets/assemblies/regulated_cobble_gen.snbt" />

<BoxAnnotation color="#dddddd" min="3 2 2" max="7 2.3 3">
        （1）破坏面板：无可用GUI，可附有效率和耐久以减少能量消耗。
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="2 2 2" max="2.3 3 3">
        （2）存储总线：默认配置。
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="2.3 2.3 2" max="2.7 2.7 2.3">
        （3）触发总线：注意要放在子网络上，而非主网络。
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="2.3 3 2.3" max="2.7 3.3 2.7">
        （4）标准发信器：配置为所需数量的圆石，红石模式为“当数量小于设定数值时发出红石信号”。
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="1 2 3" max="2 3 2">
        （5）接口：默认配置。
  </BoxAnnotation>

<DiamondAnnotation pos="0 2.5 1.5" color="#00ff00">
        至主网络
    </DiamondAnnotation>

<DiamondAnnotation pos="5 1.5 3.5" color="#00ff00">
        含水楼梯，防止水流至熔岩处而将其变为黑曜石。
    </DiamondAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 配置

* <ItemLink id="annihilation_plane" />（1）无可用GUI，可附有效率和耐久以减少能量消耗。
* <ItemLink id="storage_bus" />（2）处于默认配置。
* <ItemLink id="toggle_bus" />（3）必须位于子网络且与石英纤维连接，而非主网络，否则主网络会在其触发时重启。
* <ItemLink id="level_emitter" />（4）设置为所需数量个所需物品，红石模式为“当数量小于设定数值时发出红石信号”。
* <ItemLink id="interface" />（5）处于默认配置。

## 工作原理

1. 造石机产生圆石。
2. <ItemLink id="annihilation_plane" />破坏圆石。
3. T<ItemLink id="storage_bus" />将圆石存入<ItemLink id="interface" />，并传输回主网络。
4. 当主网络中圆石的数量大于设定数量时，<ItemLink id="level_emitter" />停止发出红石信号，并关闭<ItemLink id="toggle_bus" />。
5. 子网络的能量供给被切断，从而关闭了破坏面板。
