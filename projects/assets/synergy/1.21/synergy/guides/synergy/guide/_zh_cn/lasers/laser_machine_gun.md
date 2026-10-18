---
navigation:
  title: 激光发射器
  icon: "synergy:laser_machine_gun"
  parent: lasers.md
  position: 1
categories:
  - lasers
item_ids:
  - synergy:laser_machine_gun
---

# 激光发射器

供能后传入红石信号，发射器即会产生一道激光轨迹。

使用染料右击可修改激光颜色。

右击可旋转方块。

# 激光轨迹

### 任意激光轨迹都有几项特定属性：

- 击中激光发射器会产生爆炸。

- 固体方块面和实体会阻断激光。

<GameScene zoom="4" interactive={true}>

  <Block z="-1" x="0" id="synergy:solar_panel" p:north="false" p:south="false" p:east="false" p:west="false" p:enabled="true"/>

  <Block z="-1" x="2" id="synergy:solar_panel" p:north="false" p:south="false" p:east="false" p:west="false" p:enabled="true"/>

  <Block x="0" id="synergy:laser_machine_gun" p:facing="south" p:enabled="true"/>

  <Block x="2" id="synergy:laser_machine_gun" p:facing="south" p:enabled="true"/>

  <Block x="1" id="minecraft:lever" p:face="floor" p:powered="true"/>
  <Block x="0" z="2" id="minecraft:stone"/>

  <BoxAnnotation color="#FF0000" min="0.5 0.25 1" max="0.5 0.25 2">
       激光轨迹被固体方块面阻挡
  </BoxAnnotation>

  <BoxAnnotation color="#FF0000" min="2.5 0.25 1" max="2.5 0.25 3">
       激光轨迹未受阻挡
  </BoxAnnotation>
</GameScene>

<RecipeFor id="synergy:laser_machine_gun" />
