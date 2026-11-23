---
navigation:
  title: 细菌富集催化机
  icon: nautec:bacterial_enrichment_catalyst
  position: 17
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:bacterial_enrichment_catalyst
---

# <Color id="light_purple">细菌富集催化机</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="bacterial_enrichment_catalyst" scale="2"/>
  将人造海晶水晶的纯度提升至6.00的抽选上限以上，最高至12。
</Column>

当水晶在[育晶仪](crystal_cultivation.md)中长成时，其会在3.00和6.00之间抽选纯度。催化机每处理一段时间可少量增加纯度。催化机的运转以周期为单位，每个周期都需消耗来自第二个水晶的激光能量，以及嗜海晶菌菌落中的部分细菌。

***

## <Color id="gold">搭建</Color>

共需要两个水晶。**目标**为需要富集的水晶。**来源**为第二个水晶，其纯度决定了目标的纯度可以升高到什么地方。

<GameScene zoom="4" background="#333333" interactive={true}>
  <ImportStructure src="bacterial_enrichment_catalyst.nbt" />
  <IsometricCamera yaw="225" pitch="30" />
  <BoxAnnotation min="0.97 0.97 0.97" max="2.03 7.03 2.03" color="#ff6ec7" thickness="0.06" alwaysOnTop={true}>
    **目标水晶。**&zwnj;纯度4.0及以上的人造海晶水晶，六格高。
  </BoxAnnotation>
  <BoxAnnotation min="1.97 1.97 0.97" max="3.03 8.03 2.03" color="#52e8ff" thickness="0.06" alwaysOnTop={true}>
    **来源水晶。**&zwnj;直接放在催化机正上/正下方。底部尖端向催化机发射激光。
  </BoxAnnotation>
  <BoxAnnotation min="1.97 0.97 0.97" max="3.03 2.03 2.03" color="#ffd86b" thickness="0.06" alwaysOnTop={true}>
    **细菌富集催化机。**&zwnj;在来源水晶下方贴着目标水晶放置，框住目标水晶。
  </BoxAnnotation>
  <BoxAnnotation min="0.97 -0.03 0.97" max="2.03 1.03 2.03" color="#9aa5b1" thickness="0.06" alwaysOnTop={true}>
    **育晶仪。**&zwnj;长成后原地富集的水晶下方会是育晶仪。搬走再富集的不需要此方块。
  </BoxAnnotation>
  <BoxAnnotation min="2.97 3.97 0.97" max="4.03 5.03 2.03" color="#52e8ff" thickness="0.06" alwaysOnTop={true}>
    **激光。**&zwnj;指向来源水晶的侧面。
  </BoxAnnotation>
  <BoxAnnotation min="1.97 3.97 1.97" max="3.03 5.03 3.03" color="#52e8ff" thickness="0.06" alwaysOnTop={true}>
    **激光。**&zwnj;指向来源水晶的侧面。
  </BoxAnnotation>
</GameScene>

两个有色方框对应水晶的位置。将鼠标悬停在方框上以查看是哪一个水晶，拖动情景可旋转视角。

1. 放下纯度在4.0及以上的人造海晶水晶作为目标。
2. 贴着目标水晶放置<ItemLink id="bacterial_enrichment_catalyst"/>，框住水晶。
3. 在催化机正上方或正下方放置来源水晶，将水晶的尖端和机器顶面或底面对齐。催化机不接受其他来源的光束：激光、中继器、透镜、节点，目标水晶尖端发射的也不行。
4. 向来源水晶的侧面发射激光。水晶会转发收到的所有功率，纯度改为水晶的纯度；也即，机器收到的纯度为来源水晶的纯度，所有激光的总AP则决定了富集速度。
5. 通过<ItemLink id="petri_dish"/>装入嗜海晶菌。有菌落的培养皿会装入菌落，空培养皿可取出菌落。
6. 打开催化机界面，设置目标纯度。通入红石信号可暂停富集。

同一时间一个水晶只接受一个催化机。催化机需要来源水晶发出至少**500 AP**。

***

## <Color id="gold">周期与消耗</Color>

催化机的运转以周期为单位。对于纯度6的水晶，一个周期消耗1,000,000 AP；每提高1点纯度，消耗都翻倍一次。机器会完整接受光束功率，按刻积累能量，功率翻倍可让耗时减半。

| 水晶纯度 | 每周期AP   | 每周期菌落消耗 | 1,000 AP/t下的耗时 |
| -------- | ---------- | -------------- | ------------------ |
| 4        | 250,000    | 约50           | 12.5秒             |
| 6        | 1,000,000  | 100            | 50秒               |
| 8        | 4,000,000  | 约200          | 3分20秒            |
| 10       | 16,000,000 | 约400          | 13分钟             |
| 12       | 64,000,000 | 约800          | 53分钟             |

周期结束时，水晶的纯度会提升**0.10**或回退**0.20**。回退不会导致纯度降至4.0以下。被富集的水晶会持续发出光束，用扳手搬走可保持纯度。

***

## <Color id="gold">风险与逐步升级</Color>

回退概率取决于目标与来源的纯度差：

| 目标相对来源          | 回退概率 |
| --------------------- | -------- |
| 来源纯度多出1.0或更多 | 2%       |
| 相等                  | 10%      |
| 目标纯度多出1.5       | 30%      |

目标纯度比来源高1.5时，催化机会停工，纯度6.0的来源最多能富集出纯度7.5的目标。目标水晶可再用作下一步的来源，升至9.0，如此往复。也可让两个水晶来回接力互相富集。

来源越纯净，富集就越安全，菌落消耗的细菌量也越少（见下方“菌落”）。可通过水晶提示文本读出纯度，也可透过<ItemLink id="prism_monocle"/>观察。

***

## <Color id="gold">目标纯度与暂停</Color>

可在催化机界面中设置目标纯度。水晶达到指定纯度后，催化机即停工，直至继续升高目标纯度再继续。水晶纯度最高可为12。红石信号会暂停催化机并保留进度，撤走信号即恢复运转。

已成形[聚变反应堆](fusion_plant.md)中的水晶无法富集。应先在外部富集，再用扳手搬到中心位置。

***

## <Color id="gold">菌落</Color>

催化机的运转需要**嗜海晶菌**。它们由嗜绿宝石菌在[诱变机](nautec:aquatic_biology/mutator.md)中以<ItemLink id="atlantic_gold_ingot"/>为诱变剂突变而来，概率为5%。这种菌落在生物反应机中没有产物。可在[培养机](nautec:aquatic_biology/incubator.md)中用<ItemLink id="prismarine_crystal_shard"/>喂食和令其增长，再在诱变机中使用海晶水晶碎片优化改造统计数据（25%基础概率）。参见[品系树](nautec:aquatic_biology/strain_tree.md)。

每个周期都会消耗菌落的大小：纯度6时100点，纯度每增加1点，消耗量变为约1.41倍（纯度12附近时约800点）。目标纯度高于来源时，每高出1点，消耗量追加基值量；即高出1.0点时消耗量变为两倍。菌落的突变抗性达到上限时消耗量减半。菌落的大小至少需达到一个周期的消耗，否则机器便等待。

***

## <Color id="gold">为何停工</Color>

界面顶部文本会指出催化机发现的问题，顺序如下。

| 状态         | 该做什么                                                                       |
| ------------ | ------------------------------------------------------------------------------ |
| 无水晶       | 催化机未框住水晶。在机器的框中放置水晶。                                       |
| 天然水晶     | 天然水晶无法富集。在育晶仪中培育一个。                                         |
| 水晶已被占用 | 该水晶已被另一个催化机占用。去掉多余的催化机。                                 |
| 水晶纯度过低 | 水晶的纯度不足4.0。需使用抽选到4.0及以上纯度的水晶。                           |
| 纯度已达上限 | 水晶纯度已达到12，无法再提升了。                                               |
| 已达目标     | 在界面中上调目标纯度。                                                         |
| 暂停         | 撤走红石信号。                                                                 |
| 无来源光束   | 在催化机正上/正下方放置水晶，向其侧面发射激光。                                |
| 光束过弱     | 机器需要500 AP。增强来源水晶接收的激光。                                       |
| 来源过弱     | 水晶的纯度高出来源1.5点或更多。需使用更纯净的水晶。                            |
| 无菌落       | 通过培养皿装入嗜海晶菌。                                                       |
| 菌落过小     | 菌落大小不足以支撑一个周期的消耗。让它重新增长，或使用更纯净的来源以降低消耗。 |
| 富集中       | 什么都不用做，机器在正常运转。数字为当前周期的进度。                           |

***

## <Color id="gold">纯度的功用</Color>

* [晶体培植器](nautec:laser_chemistry/crystal_cultivator.md)：纯度在6以上每增加1点，追加一级时运；纯度9时为时运 VIII，纯度12时为时运 IX。
* [激光纯化烧炼机](laser_purification_smelter.md)：减少烧炼的消耗。
* [共鸣室](resonance_chamber.md)：提高上限。
* [聚变反应堆](fusion_plant.md)：纯度在3.0以上时增加注入器光束的FE/AP，中心水晶的纯度可提高输出上限。

***

## <Color id="gold">合成</Color>

<RecipeFor id="bacterial_enrichment_catalyst"/>

AP、纯度、风险、所需菌落数据均在`config/nautec-common.toml`中的`enrichment`设置处。
