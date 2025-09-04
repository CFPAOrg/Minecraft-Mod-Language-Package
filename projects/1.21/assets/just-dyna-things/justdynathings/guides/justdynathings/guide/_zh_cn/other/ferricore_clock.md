---
navigation:
  title: 核源铁时钟
  icon: "justdynathings:ferricore_clock"
  position: 4
  parent: justdynathings:other.md
item_ids:
  - justdynathings:ferricore_clock
---

# 完全可配置的红石钟

# 核源铁时钟

*又名红石钟*

可配置为在特定游戏刻激活特定面红石元件的方块。

<BlockImage id="justdynathings:ferricore_clock" p:north="true" p:south="true" p:east="true" p:west="true" p:up="true" p:down="true" p:active="false" scale="4.0"/>

<BlockImage id="justdynathings:ferricore_clock" p:north="true" p:south="true" p:east="true" p:west="true" p:up="true" p:down="true" p:active="true" scale="4.0"/>

假如禁用核源铁时钟的NORTH和UP方向，它就不会激活这两个方向的元件。

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
