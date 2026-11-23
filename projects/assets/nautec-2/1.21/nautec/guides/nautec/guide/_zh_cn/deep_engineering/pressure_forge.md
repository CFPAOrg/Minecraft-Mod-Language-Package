---
navigation:
  title: 深渊压力锻造机
  icon: nautec:pressure_forge
  position: 3
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:pressure_forge
  - nautec:pressure_synthesizer
  - nautec:atlantean_pressure_synthesizer
---

# <Color id="light_purple">深渊压力锻造机</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="pressure_forge" scale="2"/>
  在深水区域使用激光束和蚀刻酸锻压材料。
</Column>

深渊压力锻造机可用于制造无瑕的海晶水晶、海洋金锭和深海钢衬板。它只能在地下深处的柱状水体下方运作，应将其放置在海床上，或向较深的竖井注水。

***

## <Color id="gold">需求</Color>

下方所有需求必须全部满足。有任意需求失效后，当前锻压进度就会全部丢失。

* 深度：锻造机必须位于Y 0及以下（`pressureForgeDepth`）。各个配方都有自己的最大Y坐标，具体见下。
* 水深：锻造机上方的8个方块必须全部为水源（`pressureForgeWaterColumn`）。只有深度还不够，所在竖井太过干燥也不行。压力模拟器可抵消该需求，见下。
* 功率：至少40 AP/t的光束（`pressureForgePowerUsage`）。锻造机能从四个侧面和顶面接受光束。
* 纯度：光束的纯度要达到配方的需求。
* 蚀刻酸：储罐中至少有250 mB。每完成一次锻压消耗250 mB（`pressureForgeAcidUsage`）。储罐的容量为4,000 mB（`pressureForgeCapacity`）。

所有这些值都在`config/nautec-common.toml`中。

***

## <Color id="gold">配方</Color>

| 原材料   | 产物           | 纯度 | 最大Y坐标 | 耗时 |
| -------- | -------------- | ---- | --------- | ---- |
| 共鸣碎片 | 无瑕的海晶水晶 | 2.0  | -20       | 10秒 |
| 金块     | 2个海洋金锭    | 2.0  | -20       | 15秒 |
| 海蓝钢锭 | 深海钢衬板     | 2.5  | -40       | 15秒 |

这些配方也可在JEI中查看。各个产物的功用参见[深海材料](materials.md)。

***

## <Color id="gold">使用</Color>

空手右击打开锻造机界面。其中有输入槽、输出槽、蚀刻酸储罐和模拟器槽，输入输出间还有一个进度箭头。下方清单列出了所有需求，清单项会显示当前数据，可为绿色或红色：深度、水深、光束功率、配方光束纯度、蚀刻酸。将鼠标悬停在清单项上可显示需求。点击箭头可在JEI中查看锻造机的配方。

用可锻压物品右击可放入，用<ItemLink id="etching_acid_bucket"/>右击可向储罐注酸。

漏斗和管道可送入物品和蚀刻酸，也可抽出产物，默认可对所有面交互。[面配置](nautec:getting_started/utilities.md)能分别为各面指定物品和流体交互功能。由于顶面上方必须为水，你需要从侧面输入输出。锻造机每次锻压一个物品，且只会在输出槽有空间时完成锻压。

透过<ItemLink id="prism_monocle"/>观察可检查需求。如果设施正确，会显示“压力足够”、蚀刻酸储量和光束纯度；如果不正确，会显示它需要的深度和水深。

## <Color id="gold">压力模拟器</Color>

向锻造机安装模拟器可替代水深需求，可借此在更方便的位置放置锻造机。可以用模拟器右击锻造机，也可在锻造机界面中放到相应槽位里。从槽位里取出，或是空手潜行右击锻造机，均可取回模拟器。安装其他种类的模拟器时会返还原本安装的，破坏锻造器也会掉落模拟器。<ItemLink id="prism_monocle"/>可显示安装了哪一种。

<Row>
  <ItemImage id="pressure_synthesizer"/>
  <ItemImage id="atlantean_pressure_synthesizer"/>
</Row>

* <ItemLink id="pressure_synthesizer"/>：替代锻造机上方的水柱。锻造机仍要位于Y 0或以下，且仍需满足不同配方的最大Y坐标需求。由1枚无瑕的海晶水晶和8,000 mB盐水在[搅拌机](nautec:laser_chemistry/mixer.md)中制成。
* <ItemLink id="atlantean_pressure_synthesizer"/>：允许锻造机在任意位置、任意高度运作，上方无需水柱，并忽略配方的Y坐标需求。由1个压力模拟器、1颗海洋之心、1颗下界之星、4枚末影珍珠、8,000 mB盐水在搅拌机中制成。

你需要先在真正符合需求的位置让锻造机运转起来，无瑕的海晶水晶就产自锻造机。

<Color id="gold">提示</Color>：激光束能穿过水。<ItemLink id="bacterial_fuel_cell"/>的最高纯度（2.5）足够所有三个配方使用，<ItemLink id="prismarine_crystal"/>的（3.0）也可以。可用中继器传递，用[激光转接器](nautec:laser_chemistry/laser_manipulation.md)转向。

***

### <Color id="aqua">深渊压力锻造机的配方</Color>

<Recipe id="nautec:pressure_forge"/>

***

## <Color id="gold">更强大的光束</Color>

压力锻造机需要40 AP。更强大的光束可加快锻压：速度乘数为(光束功率 ÷ 40)的平方根。

| 光束   | 速度       |
| ------ | ---------- |
| 40 AP  | ×1（正常） |
| 160 AP | ×2         |
| 360 AP | ×3         |
| 640 AP | ×4         |

配方查看器中的耗时对应40 AP的光束。蚀刻酸消耗量不受激光影响。

加速规则和各个适用的机器参见[更强大的光束](nautec:getting_started/stronger_beams.md)。
