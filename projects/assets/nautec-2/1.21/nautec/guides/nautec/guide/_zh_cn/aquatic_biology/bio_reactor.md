---
navigation:
  title: 生物反应机
  icon: nautec:bio_reactor
  position: 8
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:bio_reactor
  - nautec:bacterial_containment_shield
---

# <Color id="light_purple">生物反应机</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="bio_reactor" scale="2"/>
  生物反应机可让三个菌落工作以生产物品。
</Column>

只要反应机有供能，菌落就可以产出品系对应的产物，一次一个。生产物品不会消耗菌落，反应机中营养物质充足时菌落也不会老化。[工业生物反应机](industrial_bio_reactor.md)是能容纳九个菌落的大型反应机。

***

## <Color id="gold">建造</Color>

3x3x2结构：

* 底层：角落为暗海晶石柱，边为细菌密封罩，中央为磨制海晶石。
* 顶层：角落为暗海晶石柱，边为细菌密封罩，中央为生物反应机。

<GameScene zoom="4" background="#333333" interactive={true}>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="1" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="2" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="1"/>
  <Block id="nautec:bio_reactor" x="1" y="1" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="1" z="1"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="1" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="1" z="2"/>
  <Block id="nautec:dark_prismarine_pillar" x="2" y="1" z="2"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="0" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="0" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="2" y="0" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="0" z="1"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="0" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="0" z="2"/>
  <Block id="nautec:dark_prismarine_pillar" x="2" y="0" z="2"/>
  <IsometricCamera yaw="225" pitch="30"/>
</GameScene>

用旋转模式的<ItemLink id="aquarine_steel_wrench"/>站直右击生物反应机以成形。有方块出错时会在聊天栏中给出其位置、该处实际存在的方块和该处应有的方块。破坏已成形反应机中的任意方块都会解除成形。

成形后右击生物反应机以打开。

***

## <Color id="gold">界面</Color>

* 三个菌落槽接受来自培养皿的菌落，详见[细菌导论](bacteria_introduction.md)。
* 各菌落旁的细条栏为其营养物质缓存。鼠标悬停可查看当前余量的秒数。
* 每个菌落都在右侧有对应的输出槽。
* 最左侧的两个槽位为营养物质槽。所接受的物品参见[菌落喂食](colony_feeding.md)。
* 最右侧的两个槽位接受[反应机升级](reactor_upgrades.md)，每个槽位一个。
* 将鼠标悬停在进度箭头上，可查看当前功率和所需功率。
* 菌落上的黄色或红色“!”代表需要关注：营养物质槽中没有营养物质，菌落在老化，或菌落已衰老。鼠标悬停以查看详情和对应的营养物质。

***

## <Color id="gold">供能与激光端口</Color>

反应机通过端口接收功率。用扳手右击顶层的细菌密封罩可将其变为激光端口（再次点击以恢复原样），再从上方向其发射光束。此功能在物品面模式下不可用，该模式只会设置反应机的面配置。可以打开多个激光端口，所有光束的功率求和汇总。

| 菌落数 | 所需AP |
| ------ | ------ |
| 1      | 20     |
| 2      | 35     |
| 3      | 50     |

也即反应机本身需要5 AP，每有一个填充的菌落槽追加15 AP，两者均可配置。升级会对总量乘算，参见[反应机升级](reactor_upgrades.md)。功率只是阈值，不是消耗量。功率不足会让反应机停工并重置进度，强激光则会加快反应机（见下方“更强大的光束”）。

燃烧海晶碎片的<ItemLink id="aquatic_catalyst"/>输出12 AP，在两个激光端口处放两个可供应一个菌落，三个催化器对应两个菌落。有三个菌落时，可在催化器上贴放<ItemLink id="budding_prismarine"/>以增强，并加入第四个激光端口，或也可在光束抵达端口前用<ItemLink id="laser_junction"/>汇合。[细菌燃料单元](bacterial_fuel_cell.md)最多可提供一条48 AP的光束。

***

## <Color id="gold">生产速度</Color>

速度为生产率与大小因数的积。微型菌落的因数为0.5，达到大小上限时因数为1，两者再乘以品系产量即为最终值。对于品系产量为1的品系（如嗜岩石菌）而言：

| 菌落                  | 每物品耗时 |
| --------------------- | ---------- |
| 生产率 0.3，大小 400  | 约2秒      |
| 生产率 1，大小 20,000 | 约0.4秒    |
| 生产率 2，大小 40,000 | 约0.15秒   |

高价值的品系速度较慢：钻石菌落的耗时略超过上表的八倍。[生产率](production_rates.md)中给出了完整公式，以及所有品系的品系产量。

各个菌落都有相应的输出槽。输出槽被填满后，菌落会在其腾出空间前等待：不产出、不进食、不老化、不缩小。

***

## <Color id="gold">自动化</Color>

* 已成形反应机的所有外表面都能输入输出物品：在底层下方的漏斗可抽出产物，在生物反应机方块上方的漏斗可供应营养物质，管道则能与侧面交互。
* [面配置](nautec:getting_started/utilities.md)可用于设置结构各面的交互行为。可在界面右侧面板处调整，也可对反应机的任意方块使用物品面模式的扳手。设置作用于外表面的整个面，“底面输出”代表整个底面都只能被抽取。反应机视北面为前面。
* 可通过培养皿端口装入和取出菌落。培养皿会进入左下角槽位，有菌落的培养皿会从旁边的槽位输出；空培养皿会从升级下方的槽位输出。有菌落的培养皿会将菌落装入第一个能完整接收的菌落槽。所有菌落槽都已满时，再送入有菌落的培养皿会替换衰老菌落：取出最先出现的衰老菌落，放入其中菌落，再用腾空的培养皿容纳衰老菌落并输出，不会留下空培养皿。无衰老菌落时，培养皿会在端口中等待；培养皿输出槽已满时，替换用的培养皿也会等待。空培养皿会取出最先出现的衰老菌落，无衰老菌落时则等待。端口不接受衰老菌落，因此一个箱子可同时用作取出和补充的缓存。如需取出未衰老的菌落，应用空培养皿点击相应槽位。自动化设施若能在某一面上访问到其他槽位，就能在该面访问培养皿端口。

自动化设施只能向营养物质槽、升级槽、培养皿端口槽存入，只能从输出槽和培养皿端口抽取。只要保证营养物质有供应和产物有去向，反应机就能无限期地运转下去。

***

## <Color id="gold">老化与衰老</Color>

工作中的菌落会消耗其缓存中的营养物质而不老化。缓存耗尽时，反应机会从营养物质槽中取出下一个匹配的营养物质为其补充。只有不存在匹配的营养物质时，菌落才会老化，每工作一刻老化一刻。此时条栏会给出“无营养物质：菌落会逐渐老化”的提示。

老化程度超过寿命的菌落会衰老。无营养物质的衰老菌落每工作1秒损失2%的大小（至少损失1点），在35秒后就将损失一半。速率可配置。

喂食会立即阻止损失，但无法让菌落重回青春：衰老的菌落会停留在衰老状态，营养物质耗尽即立刻开始缩小。在[培养机](incubator.md)中处理一周期可重置其老化程度。

***

## <Color id="gold">配方</Color>

<Recipe id="nautec:bio_reactor"/>

<RecipesFor id="bacterial_containment_shield"/>

***

## <Color id="gold">更强大的光束</Color>

生物反应机会首先根据菌落数和升级计算出所需AP。强激光可在速度升级之上继续加快生产：速度乘数为(光束功率 ÷ 所需功率)的平方根。

| 光束，以所需功率倍数计 | 速度       |
| ---------------------- | ---------- |
| 1×                     | ×1（正常） |
| 4×                     | ×2         |
| 9×                     | ×3         |
| 16×                    | ×4         |

两者会乘算。反应机在速度升级作用下以1.5倍速运转时，向其提供四倍功率，它就将以3倍速运转。营养物质按工作刻数消耗，强激光可使用相同量的营养物质产出更多物品。将鼠标悬停在进度箭头上，可查看光束速度和升级后的总速度；Jade也会显示光束速度。

加速规则和各个适用的机器参见[更强大的光束](nautec:getting_started/stronger_beams.md)。

<RecipeFor id="polished_prismarine"/>

<RecipeFor id="dark_prismarine_pillar"/>
