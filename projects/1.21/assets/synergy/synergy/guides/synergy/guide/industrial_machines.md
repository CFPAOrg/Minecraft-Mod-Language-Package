---
navigation:
  title: Industrial Machines
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

# Industrial Machines

Functional blocks that use Energy to process items and fluids

All machines can be upgraded with some upgrades , can be automated using any pipe and allow to craft some resources more easily

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

Other info

<CategoryIndex category="machines"></CategoryIndex>
