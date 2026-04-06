---
navigation:
  parent: aae_intro/aae_intro-index.md
  title: ME吞吐量监控器
  icon: advanced_ae:throughput_monitor
categories:
  - advanced items
item_ids:
  - advanced_ae:throughput_monitor
  - advanced_ae:throughput_monitor_configurator
---

# ME吞吐量监控器

<GameScene zoom="8" background="transparent">
<ImportStructure src="../structure/throughput_monitors.snbt"></ImportStructure>
<IsometricCamera yaw="195" pitch="30" />
</GameScene>

吞吐量监控器是监控器的一种。它具有<ItemLink id="ae2:storage_monitor" />的功能，还附带一个吞吐量计量表。它可以监控单种物品或流体的变化率，并以每秒变化量为单位呈现出来。

它*不需要*占用频道。

## 键位绑定

*   手持物品右击，或手持流体容器右键双击，可将监控器设置为该物品/流体。
*   空手右击以清空设置。
*   空手Shift右击以锁定监控器。

## 吞吐量监控配置器

<ItemImage id="advanced_ae:throughput_monitor_configurator" scale="4"></ItemImage>

吞吐量监控配置器是用于调控数据呈现形式的工具。手持之右击监控器可在以下三种选项间循环切换：

* 每刻物品
* 每秒物品
* 每分钟物品

注意，改变模式后可能需要一段时间才能让数值稳定下来，不要盲信初始值！