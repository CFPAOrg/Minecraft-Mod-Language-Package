---
navigation:
  title: 工业机器
  icon: "synergy:macerator"
  position: 2
categories:
  - main
item_ids:
  - synergy:macerator
  - synergy:compressor
  - synergy:electric_furnace
  - synergy:electric_melter
  - synergy:casting_factory
  - synergy:alloy_smelter
---

# 工业机器

使用能量加工物品和流体的功能方块。

所有机器都接受升级，也都可用各类管道自动化。它们能大大简化部分资源的制造过程。

<GameScene zoom="2" interactive={true}>
  <Block x="-2" y="0" z="0" id="synergy:macerator" p:enabled="false" p:facing="north"/>
  <Block x="-2" y="1" z="0" id="synergy:macerator" p:enabled="true" p:facing="north"/>

  <Block x="-1" y="0" z="0" id="synergy:compressor" p:enabled="false" p:facing="north"/>
  <Block x="-1" y="1" z="0" id="synergy:compressor" p:enabled="true" p:facing="north"/>

  <Block x="0" y="0" z="0" id="synergy:electric_furnace" p:enabled="false" p:facing="north"/>
  <Block x="0" y="1" z="0" id="synergy:electric_furnace" p:enabled="true" p:facing="north"/>

  <Block x="1" y="0" z="0" id="synergy:electric_melter" p:enabled="false" p:facing="north"/>
  <Block x="1" y="1" z="0" id="synergy:electric_melter" p:enabled="true" p:facing="north"/>

  <Block x="2" y="0" z="0" id="synergy:casting_factory" p:enabled="false" p:facing="north"/>
  <Block x="2" y="1" z="0" id="synergy:casting_factory" p:enabled="true" p:facing="north"/>

  <Block x="3" y="0" z="0" id="synergy:alloy_smelter" p:enabled="false" p:facing="north"/>
  <Block x="3" y="1" z="0" id="synergy:alloy_smelter" p:enabled="true" p:facing="north"/>
</GameScene>

其他信息：

<CategoryIndex category="machines"></CategoryIndex>
