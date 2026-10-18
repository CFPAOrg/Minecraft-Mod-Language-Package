---
navigation:
  title: Ferricore Clock
  icon: "justdynathings:ferricore_clock"
  position: 4
  parent: justdynathings:other.md
item_ids:
  - justdynathings:ferricore_clock
---

# A fully configurable redstone clocks

# Ferricore Clock

_aka Redstone Clock_

A block that can be programmed to power redstone components with any side configurable with a specific gametick

<BlockImage id="justdynathings:ferricore_clock" p:north="true" p:south="true" p:east="true" p:west="true" p:up="true" p:down="true" p:active="false" scale="4.0"/>

<BlockImage id="justdynathings:ferricore_clock" p:north="true" p:south="true" p:east="true" p:west="true" p:up="true" p:down="true" p:active="true" scale="4.0"/>

Ferricore Clock with direction NORTH and UP disabled to prevent to power not wanted stuff

<GameScene zoom="4" interactive={true}>

  <Block id="justdynathings:ferricore_clock" p:north="false" p:south="false" p:east="true" p:west="true" p:up="false" p:down="true" p:active="true"/>

  <Block y="1" id="minecraft:redstone_torch" p:lit="true"/>

  <Block y="-1" id="minecraft:redstone_lamp" p:lit="true"/>

  <Block x="1" id="minecraft:repeater" p:powered="true" p:locked="false" p:delay="1" p:facing="west"/>

  <Block z="1" id="minecraft:repeater" p:powered="false" p:locked="false" p:delay="1" p:facing="north"/>

  <Block z="-1" id="minecraft:repeater" p:powered="false" p:locked="false" p:delay="1" p:facing="south"/>

  <Block x="-1" id="minecraft:repeater" p:powered="true" p:locked="false" p:delay="1" p:facing="east"/>

</GameScene>

<Recipe id="justdynathings:ferricore_clock" />
