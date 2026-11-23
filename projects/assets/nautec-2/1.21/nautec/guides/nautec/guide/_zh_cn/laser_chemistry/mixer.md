---
navigation:
  title: 搅拌机
  icon: nautec:mixer
  position: 4
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:mixer
---

# <Color id="light_purple">搅拌机</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="mixer" scale="2"/>
  将物品与盐水混合，制造化工流体、海蓝钢混合物和机器部件。
</Column>

## <Color id="gold">搭建设施</Color>

搅拌机能在任意面上接受激光，且会在至少收到10 AP/t时开始运转（可配置）。一台燃烧海晶碎片或海晶水晶碎片的<ItemLink id="aquatic_catalyst"/>就已足够。燃烧海晶砂粒的则不足，此时需要用[激光转接器](laser_manipulation.md)合并激光。

空手右击以打开。它有四个原材料槽、一个输出槽、一个输入储罐和一个输出储罐，每个储罐的容量均是64,000 mB（64桶，可配置）。

* 用<ItemLink id="saltwater_bucket"/>右击以填充输入储罐。盐水产自[深海排水口](drain.md)，或也可在搅拌机中混合水和盐制成。
* 用空铁桶右击可取出输出储罐中的流体。
* 可用漏斗和管道输入原材料、提供输入流体和抽取输出流体。
* 物品产物可从输出槽取出。
* 默认情况下，每一面都可进行上述所有交互。[面配置](nautec:getting_started/utilities.md)可分别为各面指定物品和流体交互能力。

机器运转时搅拌器会旋转。<ItemLink id="prism_monocle"/>可显示收到的功率，Jade则还会显示各储罐、搅拌进度，以及在同时运行多少个配方作业。

***

## <Color id="gold">可用配方</Color>

JEI已在搅拌分类下列出了原材料。

| 产物                                               | 所用流体                             | 耗时  |
| -------------------------------------------------- | ------------------------------------ | ----- |
| 1,000 mB盐水                                       | 1,000 mB水和1份<ItemLink id="salt"/> | 5秒   |
| 1,000 mB电解藻类浆液                               | 1,000 mB盐水                         | 10秒  |
| 1,000 mB蚀刻酸                                     | 1,000 mB盐水                         | 7.5秒 |
| 5个海蓝钢混合物                                    | 1,000 mB盐水                         | 5秒   |
| 1个<ItemLink id="burnt_coil"/>                     | 1,000 mB盐水                         | 10秒  |
| 2个<ItemLink id="aquatic_chip"/>                   | 1,000 mB盐水                         | 10秒  |
| 1个<ItemLink id="pressure_synthesizer"/>           | 8,000 mB盐水                         | 20秒  |
| 1个<ItemLink id="atlantean_pressure_synthesizer"/> | 8,000 mB盐水                         | 30秒  |

配方只会在输出缓存能装下产物时开始处理，大批量制造时需要及时清空输出槽和输出储罐。功率不足只会暂停搅拌，不会重置进度。

<Color id="gold">提示</Color>：输出储罐有流体时，用铁桶和流体桶右击会对输出储罐交互，因此此时无法用盐水桶注盐水。需要先清空输出。

各流体的功用参见[化工流体](chemistry_introduction.md)。

***

### <Color id="aqua">搅拌机的配方</Color>

<ItemLink id="whisk"/>由破损的搅拌器修复而来，也可用铸铁棒、海晶水晶水晶、海蓝钢锭合成。

***

## <Color id="gold">更强大的光束</Color>

搅拌机需要10 AP。强激光首先会增加并行作业数：每10 AP为每个周期追加一条并行作业，最多64条（可配置）。周期结束后，机器会按照输入储罐余量和输出缓存空间尽可能取原材料，提供640 AP，放入一组盐和64,000 mB水，即可在一次5秒的周期内制造64,000 mB盐水。

在64条作业之上继续增加AP，会转而加快周期：速度乘数为(光束 ÷ (作业数 × 10))的平方根。弱于640 AP的光束如停在两个10 AP之间，则只会提供少量加速。

| 光束      | 每周期作业数 | 速度       |
| --------- | ------------ | ---------- |
| 10 AP     | 1            | ×1（正常） |
| 40 AP     | 4            | ×1         |
| 640 AP    | 64           | ×1         |
| 2,560 AP  | 64           | ×2         |
| 5,760 AP  | 64           | ×3         |
| 10,240 AP | 64           | ×4         |

配方查看器中的耗时对应1倍速、1条作业。

加速规则和各个适用的机器参见[更强大的光束](nautec:getting_started/stronger_beams.md)。

<RecipeFor id="mixer"/>
