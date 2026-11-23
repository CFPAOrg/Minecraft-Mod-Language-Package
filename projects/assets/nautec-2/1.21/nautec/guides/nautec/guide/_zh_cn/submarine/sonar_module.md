---
navigation:
  title: 声呐模块
  icon: nautec:sonar_module
  position: 11
  parent: submarine/submarine-index.md
item_ids:
  - nautec:sonar_module
---

# <Color id="light_purple">声呐模块</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="sonar_module" scale="2"/>
  透过岩石看见矿石和敌对生物。
</Column>

声呐模块可穿过岩石探测并标记48格内的所有矿脉以及32格内的所有敌对生物，同时给予乘员夜视。

***

## <Color id="gold">使用</Color>

|              | 默认   |
| ------------ | ------ |
| 每次探测能耗 | 30,000 |
| 矿石范围     | 48格   |
| 敌对生物范围 | 32格   |
| 冷却         | 45秒   |

激活后船壳会发出扫描声波，以环形扫过环境。声呐会给所有矿脉加上高亮轮廓，颜色按矿石种类选取，保留45秒，将结束时淡出。在常规矿石标签中的所有方块都会亮起，也包括其他模组的矿石。

探测起点32格内的敌对生物会以红色轮廓高亮45秒，高亮跟随生物；同时还会给予这些生物15秒的发光。

乘员获得45秒夜视，在光线昏暗的深水区相当必要。

两个探测都以激活时潜水器的位置为中心，要探测其他位置可在移动后重新激活。能耗、敌对生物范围、冷却均可配置。

***

### <Color id="aqua">声呐模块的配方</Color>

<Recipe id="nautec:sonar_module"/>
