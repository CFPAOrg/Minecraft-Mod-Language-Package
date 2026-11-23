---
navigation:
  title: 聚变反应堆
  icon: nautec:fusion_controller
  position: 8
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:fusion_controller
  - nautec:fusion_casing
  - nautec:aquamarine_structural_glass
  - nautec:laser_injector
  - nautec:fusion_collector
  - nautec:containment_coil
  - nautec:fusion_port
---

# <Color id="light_purple">聚变反应堆</Color>

<Column alignItems="center" fullWidth={true}>
  <Row>
    <ItemImage id="fusion_controller" scale="2"/>
    <ItemImage id="laser_injector" scale="2"/>
    <ItemImage id="containment_coil" scale="2"/>
  </Row>
  围绕人造海晶水晶搭建的激光聚变反应堆。它能燃烧盐水并产出Forge能量（FE）供其他模组的机器使用。
</Column>

激光注入器会向水晶的核心发射激光。水晶再将激光以等离子束的形式发射到两个聚变堆捕获器上，由等离子体将盐水聚变为FE。小号的反应仓可产出约20,000 FE/t，配齐约束线圈的大号反应仓则能输出300,000 FE/t，在仓室角落放置卫星水晶还可进一步增至最高700,000 FE/t。

***

## <Color id="gold">需求</Color>

* 人造海晶水晶，按[水晶培育](crystal_cultivation.md)所说的培育而来。中心水晶必须为人造水晶。
* 纯度2.0及以上的激光。纯度3.0为基础的50 FE/AP；最强大的反应堆需通过另一个水晶驱动。[细菌燃料单元](nautec:aquatic_biology/bacterial_fuel_cell.md)在最优情况下（2.5）可达到基础输出的六分之五。纯度高于3.0的光束可生产更多FE，见下方“运行”。
* 来自[深海排水口](nautec:laser_chemistry/drain.md)的稳定盐水供应。
* 下方提及的各部件。配方均可用JEI查看：制造它们需要深海钢衬板、海洋金、末影珍珠、无瑕的海晶水晶，控制器还需一颗下界之星。

***

## <Color id="gold">搭建反应仓</Color>

水晶应位于立方体外壳的中央，外壳需空心。内部区域高度和水晶一致（6格），宽与深可为3、5、7、9格。墙壁、底板、天花板为包裹该区域的一格厚外壳。

<GameScene zoom="2.5" background="#333333" interactive={true}>
  <Block id="nautec:fusion_casing" x="0" y="0" z="0"/>
  <Block id="nautec:fusion_casing" x="1" y="0" z="0"/>
  <Block id="nautec:fusion_casing" x="2" y="0" z="0"/>
  <Block id="nautec:fusion_casing" x="3" y="0" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="0" z="0"/>
  <Block id="nautec:fusion_casing" x="0" y="0" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="0" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="0" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="0" z="1"/>
  <Block id="nautec:fusion_casing" x="4" y="0" z="1"/>
  <Block id="nautec:fusion_casing" x="0" y="0" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="0" z="2"/>
  <Block id="nautec:fusion_collector" x="2" y="0" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="0" z="2"/>
  <Block id="nautec:fusion_casing" x="4" y="0" z="2"/>
  <Block id="nautec:fusion_casing" x="0" y="0" z="3"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="0" z="3"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="0" z="3"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="0" z="3"/>
  <Block id="nautec:fusion_casing" x="4" y="0" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="0" z="4"/>
  <Block id="nautec:fusion_casing" x="1" y="0" z="4"/>
  <Block id="nautec:fusion_casing" x="2" y="0" z="4"/>
  <Block id="nautec:fusion_casing" x="3" y="0" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="0" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="1" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="1" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="1" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="1" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="1" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="1" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="1" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="1" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="1" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="1" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="2" z="0"/>
  <Block id="nautec:containment_coil" x="1" y="2" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="2" z="0"/>
  <Block id="nautec:containment_coil" x="3" y="2" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="2" z="0"/>
  <Block id="nautec:fusion_port" x="0" y="2" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="2" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="2" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="2" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="2" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="3" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="3" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="3" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="3" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="3" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="3" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="3" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="3" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="3" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="3" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="4" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="4" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="4" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="4" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="4" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="4" z="1"/>
  <Block id="nautec:laser_injector" x="0" y="4" z="2" p:facing="east"/>
  <Block id="nautec:laser_injector" x="4" y="4" z="2" p:facing="west"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="4" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="4" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="4" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="5" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="5" z="0"/>
  <Block id="nautec:fusion_controller" x="2" y="5" z="0" p:facing="north"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="5" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="5" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="5" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="5" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="5" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="5" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="5" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="6" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="6" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="6" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="6" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="6" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="6" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="6" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="6" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="6" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="6" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="7" z="0"/>
  <Block id="nautec:fusion_casing" x="1" y="7" z="0"/>
  <Block id="nautec:fusion_casing" x="2" y="7" z="0"/>
  <Block id="nautec:fusion_casing" x="3" y="7" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="7" z="0"/>
  <Block id="nautec:fusion_casing" x="0" y="7" z="1"/>
  <Block id="nautec:fusion_casing" x="4" y="7" z="1"/>
  <Block id="nautec:fusion_casing" x="0" y="7" z="2"/>
  <Block id="nautec:fusion_collector" x="2" y="7" z="2"/>
  <Block id="nautec:fusion_casing" x="4" y="7" z="2"/>
  <Block id="nautec:fusion_casing" x="0" y="7" z="3"/>
  <Block id="nautec:fusion_casing" x="4" y="7" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="7" z="4"/>
  <Block id="nautec:fusion_casing" x="1" y="7" z="4"/>
  <Block id="nautec:fusion_casing" x="2" y="7" z="4"/>
  <Block id="nautec:fusion_casing" x="3" y="7" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="7" z="4"/>
  <BoxAnnotation min="2 1 2" max="3 7 3" color="#52e8ff" thickness="0.6">
    人造海晶水晶的位置，占满底板至天花板的空间。
  </BoxAnnotation>
  <BlockAnnotation x="2" y="5" z="0" color="#ffd86b">
    聚变堆控制器，嵌在侧壁中，朝外。
  </BlockAnnotation>
  <BlockAnnotation x="0" y="4" z="2" color="#52e8ff">
    激光注入器，在侧壁中央，高度与水晶核心齐平，需指向水晶。
  </BlockAnnotation>
  <BlockAnnotation x="2" y="0" z="2" color="#b8a6ff">
    聚变堆捕获器，在底板中央。天花板中央还可安装一个。
  </BlockAnnotation>
  <BlockAnnotation x="1" y="2" z="0" color="#ffd86b">
    约束线圈，墙壁、底板、天花板中的任意位置。
  </BlockAnnotation>
  <BlockAnnotation x="0" y="2" z="1" color="#8cc4f2">
    聚变堆端口，墙壁、底板、天花板中的任意位置。
  </BlockAnnotation>
  <IsometricCamera yaw="135" pitch="25"/>
</GameScene>

示意情景中留空了两面墙壁和天花板，以便查看内部。

* 外壳各棱需为<ItemLink id="fusion_casing"/>。
* 墙壁、底板、天花板的剩余位置可以是<ItemLink id="aquamarine_structural_glass"/>、聚变堆外壳、约束线圈或聚变堆端口。结构玻璃可作为观察等离子体的视窗。
* 底板和天花板的中央应为<ItemLink id="fusion_collector"/>，需与水晶对齐。
* 任意侧壁的中央可为<ItemLink id="laser_injector"/>，高度需与水晶核心平齐（基座开始向上第四格处）。放置时应看向仓室内部，让注入器指向水晶。最多可有四个，每面墙一个。
* 侧壁除棱外的任意位置需有<ItemLink id="fusion_controller"/>，朝外。它会搜索其后方2到5格内的水晶。
* 内部除中心水晶和角落的卫星水晶（见下方“卫星水晶”）外的位置需留空。空气和水均可，可在水下建造反应堆。

右击控制器或任意聚变堆端口打开其界面。仓室不完整时，界面最下方文本会指出第一个有误的方块。

***

## <Color id="gold">运行</Color>

1. **燃料。**&zwnj;向控制器或<ItemLink id="fusion_port"/>送入盐水。它们不接受其他输入。
2. **点火。**&zwnj;从外部向注入器的背面发射光束。过冷的反应堆会在点火前将5,000,000 AP吸收为热量，发送6,000 AP/t时需40秒，功率较低时可能需要几分钟。左侧条栏指示热量。
3. **功率。**&zwnj;热量条已满时，注入的每单位AP会变为50 FE。低纯度会降低转换率：在纯度2.4下，每单位AP变为40 FE。纯度高于3.0时，转换比的曲线会逐渐趋于平缓：纯度6时约为1.35倍，9时1.55倍，12时1.69倍。更纯净的光束来自富集水晶，参见[细菌富集催化机](bacterial_enrichment_catalyst.md)。
4. **燃烧。**&zwnj;每mB盐水变为2,000 FE。输出300,000 FE/t的反应堆每刻会燃烧150 mB，相当于六台深海排水口。
5. **输出。**&zwnj;控制器和所有聚变堆端口会向相邻的线缆和机器输出FE。

燃料断供或光束消失时，等离子体会逐渐冷却，反应堆会在20秒后过冷。只是短时间断供只会损失少量热量，光束可相对迅速地补足。

***

## <Color id="gold">输出上限</Color>

仓室能容纳的等离子体有上限。超过上限的光束功率会被浪费，界面中也会显示**已达上限**。

| 内部  | 上限         |
| ----- | ------------ |
| 3 x 3 | 20,000 FE/t  |
| 5 x 5 | 50,000 FE/t  |
| 7 x 7 | 100,000 FE/t |
| 9 x 9 | 200,000 FE/t |

外壳中每有一个<ItemLink id="containment_coil"/>追加4,000 FE/t，最多至300,000 FE/t。向9x9的仓室壁嵌入25个线圈可达到这个上限，需向其发射纯度3.0的6,000 AP/t光束。

***

## <Color id="gold">中心水晶纯度</Color>

中心水晶的纯度在3.0以上每增加1，都可追加10%的反应堆输出上限和最大输出：纯度6时+30%，12时+90%。抽选到更高纯度的人造水晶在此表现更佳，经过富集处理的则更优。

已成形反应堆中的水晶无法富集。应先在外界通过[细菌富集催化机](bacterial_enrichment_catalyst.md)处理，再用扳手搬到反应堆的中心位置。

***

## <Color id="gold">卫星水晶</Color>

7x7和9x9的仓室内能放下更多水晶。在仓室内的四角放置人造海晶水晶，需和中心水晶一样与底板和天花板相贴。每个卫星水晶会：

* 向上限追加100,000 FE/t，上限的上限（300,000 FE/t）也会相应升高
* 每注入1 AP额外产出10 FE，有一个卫星水晶时50会变为60，有四个时变为90

<GameScene zoom="2.5" background="#333333" interactive={true}>
  <ImportStructure src="fusion_plant_satellites.nbt" />
  <IsometricCamera yaw="225" pitch="30" />
  <BoxAnnotation min="3.97 0.97 3.97" max="5.03 7.03 5.03" color="#52e8ff" thickness="0.06" alwaysOnTop={true}>
    **中心水晶。**&zwnj;聚变反应堆的中心人造海晶水晶，与底板和天花板相贴。
  </BoxAnnotation>
  <BoxAnnotation min="0.97 0.97 0.97" max="2.03 7.03 2.03" color="#ff6ec7" thickness="0.06" alwaysOnTop={true}>
    **卫星水晶。**&zwnj;人造海晶水晶，与底板和天花板相贴。
  </BoxAnnotation>
  <BoxAnnotation min="6.97 0.97 0.97" max="8.03 7.03 2.03" color="#ff6ec7" thickness="0.06" alwaysOnTop={true}>
    **卫星水晶。**&zwnj;人造海晶水晶，与底板和天花板相贴。
  </BoxAnnotation>
  <BoxAnnotation min="0.97 0.97 6.97" max="2.03 7.03 8.03" color="#ff6ec7" thickness="0.06" alwaysOnTop={true}>
    **卫星水晶。**&zwnj;人造海晶水晶，与底板和天花板相贴。
  </BoxAnnotation>
  <BoxAnnotation min="6.97 0.97 6.97" max="8.03 7.03 8.03" color="#ff6ec7" thickness="0.06" alwaysOnTop={true}>
    **卫星水晶。**&zwnj;人造海晶水晶，与底板和天花板相贴。
  </BoxAnnotation>
  <BoxAnnotation min="3.97 4.97 -0.03" max="5.03 6.03 1.03" color="#ffd86b" thickness="0.06" alwaysOnTop={true}>
    **聚变堆控制器。**&zwnj;位于侧壁除棱外的位置，朝外。
  </BoxAnnotation>
  <BoxAnnotation min="3.97 3.97 -0.03" max="5.03 5.03 1.03" color="#52e8ff" thickness="0.06" alwaysOnTop={true}>
    **激光注入器。**&zwnj;位于侧壁的中央，与水晶核心平齐，指向水晶。该反应堆各侧面各有一个。
  </BoxAnnotation>
  <BoxAnnotation min="3.97 -0.03 3.97" max="5.03 1.03 5.03" color="#b8a6ff" thickness="0.06" alwaysOnTop={true}>
    **聚变堆捕获器。**&zwnj;底板和天花板中央各有一个。
  </BoxAnnotation>
  <BoxAnnotation min="7.97 1.97 0.97" max="9.03 3.03 2.03" color="#ffb74d" thickness="0.06" alwaysOnTop={true}>
    **约束线圈。**&zwnj;东侧墙壁嵌有两排。每个向输出上限追加4,000 FE/t。
  </BoxAnnotation>
  <BoxAnnotation min="-0.03 1.97 3.97" max="1.03 3.03 5.03" color="#8cc4f2" thickness="0.06" alwaysOnTop={true}>
    **聚变堆端口。**&zwnj;接受盐水，输出FE，和控制器类似。
  </BoxAnnotation>
</GameScene>

配齐四个卫星水晶的7x7反应堆：88个聚变堆外壳（棱上）、244个海蓝结构玻璃、14个约束线圈、4个激光注入器、2个聚变堆捕获器s、1个聚变堆端口和控制器，总计354个方块和5个水晶。水晶有它们自己的渲染器，情景中只会标记位置而不会显示它们。拖动情景可旋转视角。

| 人造卫星数 | 最大输出     | FE/AP | 纯度3.0时所需的AP/t |
| ---------- | ------------ | ----- | ------------------- |
| 0          | 300,000 FE/t | 50    | 6,000               |
| 1          | 400,000 FE/t | 60    | 6,667               |
| 2          | 500,000 FE/t | 70    | 7,143               |
| 3          | 600,000 FE/t | 80    | 7,500               |
| 4          | 700,000 FE/t | 90    | 7,778               |

所有卫星水晶也必须都是人造水晶，参见[水晶培育](crystal_cultivation.md)，每个在培育时又都需要消耗10,000,000 AP。1 mB盐水仍对应2,000 FE，输出700,000 FE/t的反应堆每刻需燃烧350 mB盐水，即14台深海排水口的输出。界面中的卫星行会显示仓室中卫星水晶的个数，在其他位置放置水晶会阻止成形。

相应数据分别对应`config/nautec-common.toml`中的`fusionSatelliteContainment`和`fusionSatelliteFePerAp`。

<Color id="gold">提示</Color>：[能量转换器](nautec:laser_chemistry/energy_converter.md)可将反应堆产出的部分FE转换回AP。转换器所输出光束的纯度为0，在使用前应先与另一个海晶水晶的光束汇合，提高纯度。
