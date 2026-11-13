---
navigation:
  title: 燃烧发电机
  icon: nautec:combustion_dynamo
  position: 16
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:combustion_dynamo
  - nautec:kelp_slurry
  - nautec:algal_lipid
  - nautec:fiery_crystal
  - nautec:crystalline_combustion_booster
  - nautec:stellar_combustion_booster
---

# <Color id="light_purple">燃烧发电机</Color>

<Column alignItems="center" fullWidth={true}>
  <Row>
    <ItemImage id="combustion_dynamo" scale="2"/>
  </Row>
  燃烧原油和水产出Forge能量（FE）的引擎。
</Column>

有原油和水供应时，燃烧发电机能产出320 FE/t，且能向相邻的线缆和机器弹出。原油来自能将海带转换为脂质的细菌，因此搭配海带农场和生物反应机即可让发电机一直运转下去。

***

## <Color id="gold">让发电机运转</Color>

* **原油。**&zwnj;`c:oil`标签下的任意原油均可，无论是来自海蓝科技还是其他模组。每10刻燃烧1 mB，一桶原油可燃烧8分钟。
* **水。**&zwnj;每刻消耗1 mB水，即每秒20 mB。
* **储罐。**&zwnj;发电机内为两种流体各准备了8,000 mB的储罐。可从任意面注入流体：原油只会进入原油储罐，水只会进入水储罐，可以用一条管道供应两者。
* **添加剂。**&zwnj;向槽位中放入增强剂可提高输出。只有在引擎燃烧时才会计算燃烧时间；原油耗尽、水耗尽，或是堵塞都会暂停机器燃烧。

| 增强剂         | FE/t  | 原油和水消耗量 | 有效时间 |
| -------------- | ----- | -------------- | -------- |
| 红石粉         | 480   | 1.1倍基础消耗  | 1分钟    |
| 烈焰粉         | 640   | 1.5倍基础消耗  | 2分钟    |
| 火热水晶       | 960   | 2倍基础消耗    | 5分钟    |
| 水晶燃烧增强剂 | 1,600 | 3倍基础消耗    | 10分钟   |
| 星辰燃烧增强剂 | 3,200 | 5倍基础消耗    | 1小时    |

可用海晶水晶碎片和四份烈焰粉制造火热水晶。两枚火热水晶、两枚共鸣水晶、一枚无瑕的海晶水晶可制成水晶级增强剂。四份水晶增强剂、四片深海钢衬板、一枚下界之星可制成星辰级增强剂。JEI给出了各增强剂的合成配方和增强效力。

<RecipeFor id="fiery_crystal"/>
<RecipeFor id="crystalline_combustion_booster"/>
<RecipeFor id="stellar_combustion_booster"/>

界面中会显示输出、引擎缺少的原材料、剩余多少增益。Jade可在界面外显示相同指标。

***

## <Color id="gold">制造原油</Color>

<Row>
  <ItemImage id="kelp_slurry"/>
  ### <Color id="aqua">海带浆</Color>
</Row>

在[搅拌机](nautec:laser_chemistry/mixer.md)中混合4个海带和1,000 mB盐水，制成2份海带浆。

<Row>
  <ItemImage id="algal_lipid"/>
  ### <Color id="aqua">嗜脂质菌和藻类脂质</Color>
</Row>

嗜脂质菌是能生产藻类脂质的细菌，可在[诱变机](nautec:aquatic_biology/mutator.md)中自盐养菌以海带浆为诱变剂突变而来（每次10%概率）。随后和其他品系的细菌一样，使用海带浆培养它们即可。将这种细菌的菌落放入[生物反应机](nautec:aquatic_biology/bio_reactor.md)，即可稳定产出藻类脂质。

### <Color id="aqua">原油</Color>

在搅拌机中混合1个藻类脂质和250 mB盐水，可制成1,000 mB的原油。

<RecipeFor id="combustion_dynamo"/>
