---
navigation:
  title: 强化站
  icon: nautec:augmentation_station
  position: 1
  parent: laser_augmentation/laser_augmentation-index.md
item_ids:
  - nautec:augmentation_station
  - nautec:augmentation_station_extension
  - nautec:claw_robot_arm
---

# <Color id="light_purple">强化站</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="augmentation_station" scale="2"/>
  强化站是用于向你的身体植入强化件的多方块结构。
</Column>

站在中间的方块上，向周围的四个扩展单元装填部件，再通过单元上的机械臂植入。

***

## <Color id="gold">建造</Color>

结构只有1格高，占地面积5x5，四角留空：

* 中央为强化站。
* 正北、正南、正东、正西方向各一个磨制海晶石。
* 四个对角方向各一个海蓝钢块。
* 各侧面向外两格处各一个强化站扩展单元。

<GameScene zoom="4" background="#333333" interactive={true}>
  <Block id="nautec:augmentation_station_extension" x="2" y="0" z="0"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="1"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="0" z="1"/>
  <Block id="nautec:augmentation_station_extension" x="0" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="2"/>
  <Block id="nautec:augmentation_station" x="2" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="2"/>
  <Block id="nautec:augmentation_station_extension" x="4" y="0" z="2"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="3"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="0" z="3"/>
  <Block id="nautec:augmentation_station_extension" x="2" y="0" z="4"/>
  <IsometricCamera yaw="225" pitch="30"/>
</GameScene>

用<ItemLink id="aquarine_steel_wrench"/>站直右击中央的强化站方块以成形。即便只用到了一个扩展单元，也不得缺漏四个单元中的任意一个。破坏已成形强化站的任意方块会解除成形，需要再次放置后重新成形才可恢复。

***

## <Color id="gold">装填扩展单元</Color>

右击已成形的扩展单元以打开。其中有两个槽位，每个槽位容纳一个物品：

* 上方槽位放置<ItemLink id="claw_robot_arm"/>。没有它，植入操作就无法执行。
* 下方槽位放置你想植入的部件。

按强化件的需求向扩展单元装填部件。几乎所有强化件都只需要一个部件，此时向一个单元放部件，其他单元留空即可。喷口外甲壳是例外：它需要在四个扩展单元中都有甲壳板。强化站只会在各个已装填扩展单元精确匹配配方时识别，因此额外再装填扩展单元会阻止植入。

***

## <Color id="gold">供能</Color>

所有持部件的扩展件都需要下方射来至少25 AP的激光。植入时只会检查功率，不消耗，但需要在整个植入过程中保持在25 AP及以上。无部件的扩展单元不需要光束。

由于光束需要从下方射入，应在地板内放置朝上的催化器或中继器。光束的发射参见[激光功率](nautec:getting_started/laser_power.md)。

25 AP的阈值可配置（`augmentationPowerRequirement`）。

***

## <Color id="gold">使用</Color>

站在中央方块上，大约等待半秒后会打开强化站的界面。它保持实时更新，无需关闭界面就可装填部件和修复光束：

* 顶部的状态条会显示强化站就绪与否；若未就绪，给出相应的原因。鼠标悬停可显示完整理由。
* 强化件面板会给出所装填部件对应什么强化件，以及该强化件的功能。
* 四个扩展单元列显示各单元的部件，若没有爪式机械臂会显示红色边框；列中还会显示单元收到的光束。功率数据在25 AP及以上时显示为绿色，以下时为红色。将鼠标悬停在列上可显示详情。
* 左侧为你的模型，将鼠标悬停在其上可显示你拥有的强化件。

在界面底部选择一个身体槽，点击“应用”。若该槽位中已经有强化件，“应用”按钮会变红，并在提示文本中给出要被替换的强化件。关闭界面后，后退一步再返回即可重新打开。站在未成形的强化站上会在你的快捷栏上方显示提示。

在植入开始后的四秒内，你会被锚定在原地，等待机械臂完成植入；屏幕顶端的条栏会显示进度。走出强化站范围、光束功率降至25 AP以下、取出部件，都会取消植入且不消耗物品。植入完成后会消耗部件，爪式机械臂不会被消耗，强化件则会被植入你选择的槽位。

若需移除强化件，可取出扩展单元中的所有部件。此时，底部的按钮会给出所有植入了强化件的槽位，“应用”也会变为“移除”。选择槽位并点击“移除”后，你会被锚定四秒；结束后强化件会被取出，相应的部件则返还至你的物品栏。移除强化件不需要光束。

[玩家强化](augmentation.md)列出了各个槽位接受的强化件，以及替换和移除强化件的操作方法。

***

## <Color id="gold">配方</Color>

<Recipe id="nautec:augmentation_station"/>

<Recipe id="nautec:augmentation_station_extension"/>

<Recipe id="nautec:claw_robot_arm"/>

***

## <Color id="gold">更强大的光束</Color>

每个扩展单元都需要25 AP。强激光可加快植入：速度乘数为(光束功率 ÷ 25)的平方根。植入操作的速度以所用最慢的扩展单元为准，务必均等供能。

| 光束   | 速度       |
| ------ | ---------- |
| 25 AP  | ×1（正常） |
| 100 AP | ×2         |
| 225 AP | ×3         |
| 400 AP | ×4         |

上文的四秒为所有扩展单元均在25 AP时的耗时。

加速规则和各个适用的机器参见[更强大的光束](nautec:getting_started/stronger_beams.md)。
