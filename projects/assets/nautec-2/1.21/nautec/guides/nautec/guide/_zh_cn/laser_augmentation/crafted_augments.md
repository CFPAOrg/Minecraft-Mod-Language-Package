---
navigation:
  title: 可合成强化件
  icon: nautec:magnetic_coil_arm
  position: 4
  parent: laser_augmentation/laser_augmentation-index.md
item_ids:
  - nautec:hydraulic_leg
  - nautec:servo_knee
  - nautec:shock_absorber
  - nautec:tendon_weave
  - nautec:magnetic_coil_arm
  - nautec:ender_coil_arm
  - nautec:hydro_drill_arm
  - nautec:syringe_robot_arm
  - nautec:trident_launcher_arm
  - nautec:volley_trident_arm
  - nautec:buoyancy_tank
  - nautec:auxiliary_ventricle
---

# <Color id="light_purple">可合成强化件</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="magnetic_coil_arm" scale="2"/>
  不产自生物，而需在工作台合成的十二种强化件。
</Column>

在[强化站](augmentation_station.md)处的植入方式和其他部件一样。

***

## <Color id="gold">腿部</Color>

共有四种强化件竞争左腿和右腿槽位。

<Row>
  <ItemImage id="hydraulic_leg"/>
  ### <Color id="aqua">液压腿</Color>
</Row>

强化件：突进。站在地上时按下左Alt，可向你的视线方向弹射自身。向上看可垂直跳起。它的冷却略超过1秒。

<Recipe id="nautec:hydraulic_leg"/>

<Row>
  <ItemImage id="servo_knee"/>
  ### <Color id="aqua">伺服膝盖</Color>
</Row>

强化件：步伐辅助。可不进行跳跃直接走上完整的方块。

<Recipe id="nautec:servo_knee"/>

<Row>
  <ItemImage id="shock_absorber"/>
  ### <Color id="aqua">冲击缓冲器</Color>
</Row>

强化件：免疫摔落伤害。从任意高度下落都不会受到摔落伤害。和液压腿配合良好。

<Recipe id="nautec:shock_absorber"/>

<Row>
  <ItemImage id="tendon_weave"/>
  ### <Color id="aqua">肌腱编合件</Color>
</Row>

强化件：行走速度。将你的基础行走速度加快到正常的二点五倍。

<Recipe id="nautec:tendon_weave"/>

***

## <Color id="gold">实用臂部</Color>

共有六种部件竞争左臂和右臂槽位。这三种植入后无需外物辅助。

<Row>
  <ItemImage id="magnetic_coil_arm"/>
  ### <Color id="aqua">磁力线圈臂</Color>
</Row>

强化件：磁引。将5格内的掉落物品拉向你。潜行可暂停磁引，比如可以在想把东西丢远时使用。如需暂停至你手动恢复，可在控制菜单中给“开关磁引强化件”设置按键。

<Recipe id="nautec:magnetic_coil_arm"/>

<Row>
  <ItemImage id="ender_coil_arm"/>
  ### <Color id="aqua">末影线圈臂</Color>
</Row>

强化件：末影磁引。将5格内的掉落物品直接传送到你的物品栏。装不下的物品会留在原地。潜行可暂停磁引，或也可用“开关磁引强化件”按键关闭磁引。

<Recipe id="nautec:ender_coil_arm"/>

<Row>
  <ItemImage id="hydro_drill_arm"/>
  ### <Color id="aqua">水能钻具臂</Color>
</Row>

强化件：水下挖掘速度。移除头部在水下时产生的挖掘减缓，就像不依赖于头盔的水下速掘。离地时的挖掘速度仍较慢，建议站在海床上。

<Recipe id="nautec:hydro_drill_arm"/>

***

## <Color id="gold">投掷用臂部</Color>

这三种会在按下按键后发射，随即进入一秒冷却。它们不消耗弹药，投出的投掷物则无法捡起。

<Row>
  <ItemImage id="trident_launcher_arm"/>
  ### <Color id="aqua">三叉戟投掷臂</Color>
</Row>

强化件：弹跳三叉戟，键位为Y。投掷出一把三叉戟，这种三叉戟会从它击中的首个方块上弹开并继续飞行。击中生物会结束弹跳。

<Recipe id="nautec:trident_launcher_arm"/>

<Row>
  <ItemImage id="volley_trident_arm"/>
  ### <Color id="aqua">齐射三叉戟投掷臂</Color>
</Row>

强化件：散射三叉戟，键位为U。投掷出一把三叉戟，这种三叉戟会在击中方块后分裂为三把，从命中点向外散射。可向地面或一群生物附近的墙投掷。

<Recipe id="nautec:volley_trident_arm"/>

<Row>
  <ItemImage id="syringe_robot_arm"/>
  ### <Color id="aqua">注射器机械臂</Color>
</Row>

强化件：投掷随机药水，键位为G。投出一个喷溅型药水，在治疗、伤害、再生、迅捷、缓慢中随机挑选。五种里有两种会伤害或拖慢目标，别直接往脚下丢。

<Recipe id="nautec:syringe_robot_arm"/>

***

## <Color id="gold">躯干与心脏</Color>

<Row>
  <ItemImage id="buoyancy_tank"/>
  ### <Color id="aqua">浮力气罐</Color>
</Row>

强化件：创造飞行，需占用躯干槽。可和在创造模式中一样飞行：无论是否在水中，双击跳跃键都可起飞。它会占用躯干槽位，因此会替代海豚鳍和光合皮肤。

<Recipe id="nautec:buoyancy_tank"/>

<Row>
  <ItemImage id="auxiliary_ventricle"/>
  ### <Color id="aqua">辅助心室</Color>
</Row>

强化件：额外红心，需占用心脏槽。令你的最大生命值翻倍，从10升至20。它和<ItemLink id="eldritch_heart"/>强化件都要占用心脏槽位，因此更多生命值和在水中自愈之间只能二选一。

<Recipe id="nautec:auxiliary_ventricle"/>
