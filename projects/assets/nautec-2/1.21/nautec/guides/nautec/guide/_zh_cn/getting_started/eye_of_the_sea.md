---
navigation:
  title: 海洋之眼
  icon: nautec:eye_of_the_sea
  position: 15
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:eye_of_the_sea
---

# <Color id="light_purple">海洋之眼</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="eye_of_the_sea" scale="2"/>
  海洋版的末影之眼。投出它，它就会飞向最近的所搜寻结构。
</Column>

***

## <Color id="gold">投掷</Color>

右击投出海洋之眼。它会先进行搜索并发出嗡鸣（快捷栏上方会显示相应消息，搜索结束前不可再次投掷），随后会和末影之眼一样飞起并飞向最近的匹配结构。大约四秒后，它会变为气泡破裂消失。海洋之眼飞行后不会掉落，但也不会消耗；你可以随心投掷它们，多频繁都没关系，只需要在两次投掷间等待两秒。

若大约1,600格（搜索生物群系时为3,200格）内没有匹配的目标，则海洋之眼会留在你的手中，并发出相应消息。

水晶晶洞位于海床下方。如果海洋之眼开始转圈或下坠，那么晶洞的中央就在你的下方。从那里向下挖吧。

***

## <Color id="gold">更改目标</Color>

潜行右击可切换搜索目标。提示文本和快捷栏上方的消息会显示当前目标。按顺序为：

| 目标         | 指向                                                                          |
| ------------ | ----------------------------------------------------------------------------- |
| 水晶晶洞     | 内有<ItemLink id="prismarine_crystal"/>的石头晶洞和深板岩晶洞                 |
| 海蓝科技废墟 | 嵌有<ItemLink id="aquatic_catalyst"/>的暗海晶石石拱                           |
| 研究前哨站   | 沉没的研究站，参见[结构](structures.md)                                       |
| 门径         | 水下门径平台，参见[门径](nautec:deep_engineering/gateway.md)                  |
| 海底废墟     | 原版的冷水和暖水海底废墟                                                      |
| 海底神殿     | 原版的海底神殿                                                                |
| 海晶珊瑚礁   | 最近的海晶珊瑚礁生物群系，是寻找<ItemLink id="budding_prismarine"/>最好的地方 |
| 深渊海沟     | 最近的深渊海沟生物群系                                                        |
| 生物荧光林   | 最近的生物荧光林生物群系                                                      |
| 热液喷口区   | 最近的热液喷口区生物群系                                                      |

新制成的海洋之眼默认搜索水晶晶洞，每颗海洋之眼可独立指定目标。你自己搭建的门径不视作目标。以生物群系为目标时，海洋之眼会飞向该生物群系距离最近的边界。各目标的资源参见[结构](structures.md)。

***

## <Color id="gold">水之眷顾</Color>

每次找到目标的投掷都会搅动你周围的水域。在接下来的5分钟内，你周围[幸运垂钓区](fishing.md)的形成频率翻倍。再次投掷可重置5分钟倒计时。

***

## <Color id="gold">合成</Color>

一枚末影珍珠和一片海晶碎片，无序合成。

<Recipe id="nautec:eye_of_the_sea"/>

搜索范围、投掷冷却时间、垂钓增益的持续时间和强度均可在`config/nautec-common.toml`中配置。
