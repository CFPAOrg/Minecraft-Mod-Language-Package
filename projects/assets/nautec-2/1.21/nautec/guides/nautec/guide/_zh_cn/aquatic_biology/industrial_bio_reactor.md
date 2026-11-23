---
navigation:
  title: 工业生物反应机
  icon: nautec:industrial_bio_reactor
  position: 12
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:industrial_bio_reactor
---

# <Color id="light_purple">工业生物反应机</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="industrial_bio_reactor" scale="2"/>
  5x5x4的反应机，有九个菌落槽和四个升级槽。
</Column>

它和[生物反应机](bio_reactor.md)一样：[产量公式](production_rates.md)和基础速度相同，[喂食](colony_feeding.md)方式相同，老化与衰老的处理方式相同，接受的[升级](reactor_upgrades.md)也相同。它的优势在于容量：9个菌落槽、9个输出槽，3个营养物质槽、4个升级槽。

***

## <Color id="gold">建造</Color>

共有四层，每层5x5：

* 第一层（底板）：四角为暗海晶石柱，其余位置为磨制海晶石。
* 第二、第三层：四角为暗海晶石柱，边为细菌密封罩，中间3x3留空。工业生物反应机方块可替代第二层的任意中央位置密封罩。
* 第四层（顶板）：四角为暗海晶石柱，其余位置为海蓝钢块。

<GameScene zoom="3" background="#333333" interactive={true}>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="0" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="4" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="0" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="4" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="0" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="4" y="0" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="0" z="4"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="4"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="4"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="0" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="1" z="0"/>
  <Block id="nautec:industrial_bio_reactor" x="2" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="1" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="1" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="1" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="3"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="1" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="1" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="1" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="1" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="1" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="1" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="2" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="2" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="2" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="2" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="2" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="2" z="3"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="2" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="2" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="2" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="2" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="2" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="2" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="3" z="0"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="3" z="0"/>
  <Block id="nautec:aquarine_steel_block" x="2" y="3" z="0"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="3" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="3" z="0"/>
  <Block id="nautec:aquarine_steel_block" x="0" y="3" z="1"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="3" z="1"/>
  <Block id="nautec:aquarine_steel_block" x="2" y="3" z="1"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="3" z="1"/>
  <Block id="nautec:aquarine_steel_block" x="4" y="3" z="1"/>
  <Block id="nautec:aquarine_steel_block" x="0" y="3" z="2"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="3" z="2"/>
  <Block id="nautec:aquarine_steel_block" x="2" y="3" z="2"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="3" z="2"/>
  <Block id="nautec:aquarine_steel_block" x="4" y="3" z="2"/>
  <Block id="nautec:aquarine_steel_block" x="0" y="3" z="3"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="3" z="3"/>
  <Block id="nautec:aquarine_steel_block" x="2" y="3" z="3"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="3" z="3"/>
  <Block id="nautec:aquarine_steel_block" x="4" y="3" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="3" z="4"/>
  <Block id="nautec:aquarine_steel_block" x="1" y="3" z="4"/>
  <Block id="nautec:aquarine_steel_block" x="2" y="3" z="4"/>
  <Block id="nautec:aquarine_steel_block" x="3" y="3" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="3" z="4"/>
  <IsometricCamera yaw="225" pitch="30"/>
</GameScene>

工业生物反应机可放在四面侧壁中任意一面的中央位置，可以先建框架，再把反应机方块嵌进朝向你的那一面。示意情景中显示的是北面侧壁。中心的3x3x2腔室必须为空气，不得有水或方块。去掉顶板后反应机多方块长这样：

<GameScene zoom="3" background="#333333" interactive={true}>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="0" z="0"/>
  <Block id="nautec:polished_prismarine" x="0" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="4" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="0" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="4" y="0" z="2"/>
  <Block id="nautec:polished_prismarine" x="0" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="3"/>
  <Block id="nautec:polished_prismarine" x="4" y="0" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="0" z="4"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="4"/>
  <Block id="nautec:polished_prismarine" x="2" y="0" z="4"/>
  <Block id="nautec:polished_prismarine" x="3" y="0" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="0" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="1" z="0"/>
  <Block id="nautec:industrial_bio_reactor" x="2" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="1" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="1" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="1" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="3"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="1" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="1" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="1" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="1" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="1" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="1" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="2" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="2" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="2" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="2" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="2" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="2" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="2" z="3"/>
  <Block id="nautec:bacterial_containment_shield" x="4" y="2" z="3"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="2" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="2" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="2" z="4"/>
  <Block id="nautec:bacterial_containment_shield" x="3" y="2" z="4"/>
  <Block id="nautec:dark_prismarine_pillar" x="4" y="2" z="4"/>
  <IsometricCamera yaw="225" pitch="30"/>
</GameScene>

用旋转模式的<ItemLink id="aquarine_steel_wrench"/>站直右击工业生物反应机以成形。有方块出错时会在聊天栏中给出其位置、该处实际存在的方块和该处应有的方块。破坏已成形反应机中的任意方块都会解除成形。

成形后不用扳手右击任意方块以打开。

***

## <Color id="gold">供能</Color>

机器需要100 AP，每有一个填充的菌落槽追加50 AP：在升级倍增之前，一个菌落为150 AP，九个为550 AP。和生物反应机类似，这里的功率也只是最低需求。功率不足会让反应机停工并重置进度，强激光则会加快反应机（见下方“更强大的光束”）。

光束需从顶板的激光端口射入。用扳手右击已成形反应机中海蓝钢块的位置，可打开激光端口；再次右击则恢复原样。此功能在物品面模式下不可用，该模式只会设置反应机的面配置。端口接受上方发来的光束，顶板棱上的端口也接受侧面的光束。激光端口数量不限，所有光束的功率求和汇总。也可以向工业生物反应机方块的前面发射光束。

它需要的功率已经远超催化器的能力极限。无升级的[能量转换器](nautec:laser_chemistry/energy_converter.md)每刻最多输出150 AP；反应机无升级时，四个转换器对四个激光端口即可支持九个菌落。可在光束抵达端口前用<ItemLink id="laser_junction"/>汇合。

***

## <Color id="gold">界面</Color>

* 左侧的3x3方格为菌落槽。各槽右侧的细条栏为营养物质缓存，其下方的条栏为进度。
* 右侧的3x3方格为输出槽，按位置与菌落槽一一对应。
* 底部左侧为三个营养物质槽，右侧为四个升级槽。
* 界面中间的箭头为平均进度。将鼠标悬停在其上可查看当前功率和所需功率，以及升级的功效。

九个菌落只能使用三个营养物质槽，务必不要用到超过三种营养物质。详见[菌落喂食](colony_feeding.md)。

***

## <Color id="gold">自动化</Color>

* 所有方块的外表面都能输入输出物品：顶板上方或指向侧壁的漏斗可送入营养物质和升级，底板下方的可抽出产物，管道则能与任意面交互。
* [面配置](nautec:getting_started/utilities.md)可用于设置结构各面的交互行为。可在界面右侧面板处调整，也可对反应机的任意方块使用物品面模式的扳手。设置作用于外表面的整个面：前面为工业生物反应机的所在面，左面和右面为站在外部朝向前面时左手和右手方向的面。例如，将顶板设为输入，底板设为输出，这样接至顶板的管道就无法抽出产物，底板下方的管道也绝不会输入。

可通过培养皿端口装入和取出菌落。培养皿会进入两方格间上方的槽位，有菌落的培养皿会从方块间下方的槽位输出；空培养皿会从底板营养物质和升级之间的槽位输出。有菌落的培养皿会将菌落装入第一个能完整接收的菌落槽。所有菌落槽都已满时，再送入有菌落的培养皿会替换衰老菌落：取出最先出现的衰老菌落，放入其中菌落，再用腾空的培养皿容纳衰老菌落并输出，不会留下空培养皿。无衰老菌落时，培养皿会在端口中等待；培养皿输出槽已满时，替换用的培养皿也会等待。空培养皿会取出最先出现的衰老菌落，无衰老菌落时则等待。端口不接受衰老菌落，因此一个箱子可同时用作取出和补充的缓存。如需取出未衰老的菌落，应用空培养皿点击相应槽位。自动化设施若能在某一面上访问到其他槽位，就能在该面访问培养皿端口。

自动化设施只能向营养物质槽、升级槽、培养皿端口槽存入，只能从输出槽和培养皿端口抽取。激光端口上不应放置漏斗：激光会被方块阻挡。

简单设施示例如下：顶板一个角落处使用箱子和漏斗送入营养物质，顶板剩余位置开激光端口，底板下方使用漏斗向存储设备输出。方方面面都达到上限的菌落能在约10秒内填满其输出槽，菌落生产速度较快时应使用多个漏斗抽取。

***

## <Color id="gold">配方</Color>

<RecipeFor id="industrial_bio_reactor"/>

***

## <Color id="gold">更强大的光束</Color>

工业生物反应机会首先根据菌落数和升级计算出所需AP。强激光可在速度升级之上继续加快生产：速度乘数为(光束功率 ÷ 所需功率)的平方根。

| 光束，以所需功率倍数计 | 速度       |
| ---------------------- | ---------- |
| 1×                     | ×1（正常） |
| 4×                     | ×2         |
| 9×                     | ×3         |
| 16×                    | ×4         |

两者会乘算。反应机在速度升级作用下以1.5倍速运转时，向其提供四倍功率，它就将以3倍速运转。营养物质按工作刻数消耗，强激光可使用相同量的营养物质产出更多物品。将鼠标悬停在进度箭头上，可查看光束速度和升级后的总速度；Jade也会显示光束速度。

加速规则和各个适用的机器参见[更强大的光束](nautec:getting_started/stronger_beams.md)。
