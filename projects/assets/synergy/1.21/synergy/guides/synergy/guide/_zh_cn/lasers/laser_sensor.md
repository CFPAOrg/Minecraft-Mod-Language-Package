---
navigation:
  title: 激光传感器
  icon: "synergy:laser_sensor"
  parent: lasers.md
  position: 4
categories:
  - lasers
item_ids:
  - synergy:laser_sensor
---

# 激光传感器

探测当前位置有无激光轨迹，并返回红石信号作为输出。

右击可旋转方块。

<GameScene zoom="4" interactive={true}>

  <Block z="-1" x="0" id="synergy:solar_panel" p:north="false" p:south="false" p:east="false" p:west="false" p:enabled="true"/>

  <Block x="0" id="synergy:laser_machine_gun" p:facing="south" p:enabled="true"/>

  <Block x="1" id="minecraft:lever" p:face="floor" p:powered="true"/>

  <Block x="0" z="2" id="synergy:laser_sensor" p:enabled="true" p:inverted="false"/>
  <Block x="1" z="2" id="minecraft:redstone_wire" p:power="15" p:north="none" p:south="none" p:east="side" p:west="side"/>

  <BoxAnnotation color="#FF0000" min="0.5 0.25 1" max="0.5 0.25 3">
  </BoxAnnotation>

</GameScene>

<RecipeFor id="synergy:laser_sensor" />
