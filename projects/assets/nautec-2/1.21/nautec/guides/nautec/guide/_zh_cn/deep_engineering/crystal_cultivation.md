---
navigation:
  title: 水晶培育
  icon: nautec:prismarine_crystal_seed
  position: 7
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:dormant_crystal_seed
  - nautec:prismarine_crystal_seed
  - nautec:crystal_cradle
---

# <Color id="light_purple">水晶培育</Color>

<Column alignItems="center" fullWidth={true}>
  <Row>
    <ItemImage id="prismarine_crystal_seed" scale="2"/>
    <ItemImage id="crystal_cradle" scale="2"/>
  </Row>
  培育出你自己的海晶水晶——能搬走放到其他地方的水晶。
</Column>

<ItemLink id="prismarine_crystal"/>可将任意光束的纯度变成3.0，但水晶晶洞里天然的水晶没法搬走。**人造海晶水晶**会在完全长成时从**3.00到6.00**之间随机抽选一个纯度，即有概率获得更纯净的光束。人造水晶还可用扳手搬走放置到任意位置。培育需要一颗种子、一台育晶仪，以及总能量一千万AP的高纯度激光。

***

## <Color id="gold">1. 找到天然水晶</Color>

唤醒种子需要纯度3.0的光束，只有海晶水晶能达到。可在海床下方的水晶晶洞中找到一座（参见[结构](nautec:getting_started/structures.md)），找到后按[激光功率](nautec:getting_started/laser_power.md)所说向其发射光束。你只需要这样操作一次：培育出的第一枚水晶就足够唤醒其他所有种子。

***

## <Color id="gold">2. 合成一颗惰性水晶种子</Color>

用共鸣碎片和海晶水晶碎片围绕无瑕的海晶水晶，可制成<ItemLink id="dormant_crystal_seed"/>。到这一步它还没有功用。

<RecipeFor id="dormant_crystal_seed"/>

***

## <Color id="gold">3. 唤醒</Color>

<Row>
  <ItemImage id="dormant_crystal_seed" scale="2"/>
  <ItemImage id="prismarine_crystal_seed" scale="2"/>
</Row>

将惰性水晶种子放入[共鸣室](resonance_chamber.md)，再向其发射纯度3.0的光束。共鸣室进入临界区间后，惰性种子就会变成发着光的<ItemLink id="prismarine_crystal_seed"/>：一颗惰性种子产出一颗唤醒的种子。JEI中该配方在共鸣室分类下。

***

## <Color id="gold">4. 将种子放入育晶仪</Color>

在目的位置放置<ItemLink id="crystal_cradle"/>，上方**留出六个方块的空间**。留出空气或留出水均可，因此育晶仪可在水下运转。用唤醒的种子右击育晶仪以放入；育晶仪上方会出现一小枚水晶。

<RecipeFor id="crystal_cradle"/>

在种子开始生长前，空手可取回种子。也可用漏斗和管道送入种子。

***

## <Color id="gold">5. 传入一千万AP</Color>

向育晶仪四个侧面中任意一面发射激光。育晶仪每刻都会完整接收激光的功率以催生水晶，但**只有纯度2.0及以上的光束有效**。纯度2.0的光束可来自：

* <ItemLink id="bacterial_fuel_cell"/>（最高2.5）
* 在已有光束中放置[聚焦透镜](beam_optics.md)（最高至2.0）
* 另一个海晶水晶（3.0）

有多个光束抵达育晶仪时，最终功率是所有光束的和，最终纯度接近于其中最纯净的，但会损失最高纯度与平均纯度差值的四分之一。弱激光会导致纯度略微下降，因此纯度2.1的光束与纯度0的汇合，所得纯度会降至2.0以下。

种子会在总共接收到**10,000,000 AP**（`config/nautec-common.toml`中的`crystalGrowthPower`；纯度下限为`crystalGrowthPurity`）后完全长成。功率越高生长得越快：

| 光束       | 生长耗时 |
| ---------- | -------- |
| 100 AP/t   | 约83分钟 |
| 250 AP/t   | 约33分钟 |
| 500 AP/t   | 约17分钟 |
| 1,000 AP/t | 约8分钟  |

育晶仪上方的水晶会随着能量蓄积逐渐长高。生长进度不会回退：撤去光束后，种子会进入等待状态，重新发射光束即可继续，不需要一次性发完一千万。

用Jade观察育晶仪可查看其进度、收到的功率和纯度、当前功率水平下的剩余时间，以及是什么阻碍了水晶生长（没有种子、上方没有空间、功率不足、纯度过低）。

<Color id="gold">搬运生长中的种子</Color>：用任意工具破坏育晶仪会保留种子及其进度。可在种子的提示文本中查看生长进度。再次放置即可继续培育。

***

## <Color id="gold">6. 人工培育的水晶</Color>

收到一千万AP之后，种子会变成育晶仪上方完全长成的人造海晶水晶。长成时，它会在**3.00到6.00**之间随机抽选自身的纯度，最小单位为0.01（后续可以再提升，见本页末尾）。向水晶的侧面发射光束，其顶面和底面即会发射出纯度与水晶相等的光束，两者共享输入功率（参见[激光功率](nautec:getting_started/laser_power.md)）。这之后，育晶仪会回到初始状态，可以培育其他种子了。

**要移动水晶**，可用扳手潜行右击水晶的任意部位。所有模组中拥有`c:tools/wrench`标签的扳手均可用，也包括<ItemLink id="aquarine_steel_wrench"/>。水晶会变为物品，再次放置要求有六个方块高的空间。搬动或重新加载后水晶的纯度不会变化，长成时是什么纯度，搬完还是什么纯度。物品的提示文本中会显示其纯度。

天然水晶无法被搬动。海蓝钢镐的凿取能力只对天然水晶有效，不会误毁人造水晶。Jade会显示水晶是天然的还是人造的。

6.00只是水晶的起始值。[细菌富集催化机](bacterial_enrichment_catalyst.md)可以进一步提高人造水晶的纯度，最高至12。

人造水晶也是[聚变反应堆](fusion_plant.md)——海蓝科技中最大的发电器——的核心部件。
