---
navigation:
  title: 深海排水口
  icon: nautec:deep_sea_drain
  position: 5
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:deep_sea_drain
  - nautec:deep_sea_drain_wall
---

# <Color id="light_purple">深海排水口</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="deep_sea_drain" scale="2"/>
  3x3多方块结构，能从海洋中泵出盐水。
</Column>

## <Color id="gold">建造</Color>

按3x3范围水平放置：中央为深海排水口，周围放置八个深海排水口壁。用<ItemLink id="aquarine_steel_wrench"/>右击深海排水口以成形。

<GameScene zoom="4" background="#333333" interactive={true}>
  <Block id="nautec:deep_sea_drain_wall" x="0" y="0" z="0"/>
  <Block id="nautec:deep_sea_drain_wall" x="1" y="0" z="0"/>
  <Block id="nautec:deep_sea_drain_wall" x="2" y="0" z="0"/>
  <Block id="nautec:deep_sea_drain_wall" x="0" y="0" z="1"/>
  <Block id="nautec:deep_sea_drain" x="1" y="0" z="1"/>
  <Block id="nautec:deep_sea_drain_wall" x="2" y="0" z="1"/>
  <Block id="nautec:deep_sea_drain_wall" x="0" y="0" z="2"/>
  <Block id="nautec:deep_sea_drain_wall" x="1" y="0" z="2"/>
  <Block id="nautec:deep_sea_drain_wall" x="2" y="0" z="2"/>
  <IsometricCamera yaw="225" pitch="30"/>
</GameScene>

它会在处于海洋生物群系内、且正上方所有九个方块均为水时运转。直接在海床上搭建就能满足这两个条件。标签为海洋的所有生物群系均可，也包括模组添加的。排水口只需要其本身或正上方九格水均在生物群系内，因此世界生成模组中洞穴和海沟生物群系的海床也有效。

***

## <Color id="gold">供能</Color>

排水口需要至少20 AP/t（可配置）。<ItemLink id="aquatic_catalyst"/>可发出：

| 燃料         | AP/t |
| ------------ | ---- |
| 海晶砂粒     | 6    |
| 海晶碎片     | 12   |
| 海晶水晶碎片 | 20   |

用[激光转接器](laser_manipulation.md)汇合两个燃烧碎片的催化器，可得到24 AP/t的光束，足够驱动排水口了。若使用海晶砂粒，则需要四台催化器。转接器会在各输出间均分功率，建议仅开放一个指向排水口的输出。

光束需要射入激光端口。手持扳手右击四边中央（不是角落）的排水口壁可打开端口。点击任意面均可：端口必然面朝外界背朝排水口，开放成功还会发出消息确认。需要向该面发射激光。排水口同一时间只会有一个端口，因此点击其他中央排水口壁只会转移端口的位置，再次点击排水口壁可让其恢复原样。

***

## <Color id="gold">运行</Color>

主副手均为空时Shift右击可打开排水口。只要功率足够即可打开。如此操作会旋动阀门，经过几秒后会打开排水口盖。再次Shift右击以关闭。

要是排水口没有打开，会有消息说明它需要的和实际收到的功率。而要是打开后受其他原因影响停止了泵水，例如缺水或生物群系不对，消息中也会提及。

排水口盖打开且功率足够时，它会不断向128,000 mB的内部储罐泵入盐水。仅略微超过20 AP的光束可让它每秒泵送500 mB，更强大的光束则能按正比增加泵送量，没有上限：每1 AP每秒追加25 mB，四倍功率的光束等于四倍泵送量。

| 光束        | 每秒盐水量 |
| ----------- | ---------- |
| 略超过20 AP | 约500 mB   |
| 80 AP       | 2,000 mB   |
| 320 AP      | 8,000 mB   |
| 2,000 AP    | 50,000 mB  |
| 20,000 AP   | 500,000 mB |

Jade会显示排水口当前的速率。基础速率、所需功率、速率随功率增长速度（`drainPowerScaling`）、储罐容量均可配置。它可为[搅拌机](mixer.md)稳定供应盐水；除非整合包启用了`config/nautec-common.toml`中的`collectSaltWater`，不然对海水使用空铁桶只会舀起普通的水。

* 从中心方块底面通过管道取出盐水。
* 或也可用铁桶或其他流体容器右击排水口任意位置。铁桶只会在排水口内有至少1,000 mB时盛装。

透过<ItemLink id="prism_monocle"/>观察排水口壁，可检查其中的流体储量。通过Jade观察排水口任意位置都能显示其状态（关闭、正在打开、正在泵送盐水、功率不足、上方无水、不在海洋中、储罐已满）和收到的功率。

<Color id="gold">注意</Color>：功率足够且敞开的排水口会用下行气泡柱拖拽上方的所有事物。被拖入排水口的事物会受到溺水伤害，对掉落的物品也有效。要游过它之前建议先关上排水口壁。

***

### <Color id="aqua">配方</Color>

***

## <Color id="gold">更强大的光束</Color>

收到的光束越强，深海排水口泵送的盐水越多；泵送量与功率成正比，而非和其他机器一样与功率平方根成正比：四倍功率相当于四倍泵送量。上方的表格已经给出了速率。整合包可通过`config/nautec-common.toml`中的`drainPowerScaling`调整该行为；0.5为与平方根成正比。

加速规则和各个适用的机器参见[更强大的光束](nautec:getting_started/stronger_beams.md)。

<RecipeFor id="deep_sea_drain"/>

<RecipeFor id="deep_sea_drain_wall"/>
