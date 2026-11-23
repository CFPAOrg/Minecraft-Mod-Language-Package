---
navigation:
  title: 深海动物强化件
  icon: nautec:abyssal_organ
  position: 5
  parent: laser_augmentation/laser_augmentation-index.md
item_ids:
  - nautec:abyssal_organ
  - nautec:luminous_membrane
  - nautec:chitin_plate
---

# <Color id="light_purple">深海动物强化件</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="abyssal_organ" scale="2"/>
  来自海蓝科技海洋生物群系中生物的三种强化件。
</Column>

这些生物必定掉落相应部件，抢夺可增加掉落量。每种生物的生成位置参见[深海生命](nautec:getting_started/deep_life.md)。所有三种部件都是幸运垂钓区的战利品（参见[垂钓](nautec:getting_started/fishing.md)）。

***

<Row>
  <ItemImage id="abyssal_organ"/>
  ### <Color id="aqua">深渊之眼</Color>
</Row>

部件：深渊器官，每只深渊鮟鱇掉落一个。深渊鮟鱇出没于深渊海沟Y 40以下的位置。

槽位：眼。在Y 45以下时（可配置，`abyssalEyesDepth`）给予你夜视。在该高度之上没有功用，效果会在离开生效范围的十秒后消退。

它和<ItemLink id="guardian_eye"/>一样需占用眼部槽位。

***

<Row>
  <ItemImage id="luminous_membrane"/>
  ### <Color id="aqua">发光皮肤</Color>
</Row>

部件：发光膜，生物荧光林中的灯笼水母每只掉落一到两个。

槽位：躯干。处于水中时，距你12格以内（可配置，`photophoreSkinRadius`）的所有活物都会发光，发光轮廓可透过方块看见。离开水体即失效。

它占用躯干槽位，和飞行强化件还有海豚鳍一样。

***

<Row>
  <ItemImage id="chitin_plate"/>
  ### <Color id="aqua">喷口外甲壳</Color>
</Row>

部件：四个甲壳板，每个扩展单元一个。热液喷口区中的喷口爬蟹每只掉落一到三个。所有持有甲壳板的扩展单元都需要一个爪式机械臂和25 AP的光束（参见[强化站](augmentation_station.md)）。

槽位：头或躯干。增加4点护甲值和50%击退抗性，着火时间减半。可植入头部槽位以腾出躯干。植入第二个外甲壳没有额外增益。
