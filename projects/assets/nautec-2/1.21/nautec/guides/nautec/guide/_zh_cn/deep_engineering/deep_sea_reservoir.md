---
navigation:
  title: 深海贮液仓
  icon: nautec:deep_sea_reservoir
  position: 15
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:deep_sea_reservoir
  - nautec:reservoir_upgrade_2
  - nautec:reservoir_upgrade_3
  - nautec:reservoir_upgrade_4
---

# <Color id="light_purple">深海贮液仓</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="deep_sea_reservoir" scale="2"/>
  3x3x3的储罐，能容纳单种流体，容量远超所有其他流体储罐。
</Column>

## <Color id="gold">放置</Color>

贮液仓物品放置后会占据3x3x3的区域。将其放在方块上，它会填充上方的3x3x3区域，自身为底面中心；贮液仓的仪表会朝向你。区域内所有方块必须为空（空气、水、可以替换的植物），因此可在海床上直接放置。

水会和平常一样流入未含水贮液仓的框架：侧面和顶面都可流入，底面不会自动吸入下方的水。

破坏任意部位会让整座贮液仓掉落为单个物品。该物品会保留等级和内容流体，可借此将整座贮液仓搬走。

***

## <Color id="gold">填充与抽空</Color>

* 3x3x3的所有外表面都访问同一个储罐，只需要相邻摆放管道就能连接。
* 用铁桶或其他流体容器右击以填充和抽空。
* 空手右击打开。鼠标拿起流体容器点击界面中的仪表，也可填充和抽空。
* 方块前部的玻璃视窗可显示其中流体的类型，且会按当前储量填充。
* 比较器可读取填充程度。

它只能同时容纳一种流体，全部抽空之后才能注入另一种。

***

## <Color id="gold">等级</Color>

| 等级 | 容量             | 升级                                 |
| ---- | ---------------- | ------------------------------------ |
| I    | 500,000,000桶    | 基础贮液仓                           |
| II   | 2,000,000,000桶  | <ItemLink id="reservoir_upgrade_2"/> |
| III  | 10,000,000,000桶 | <ItemLink id="reservoir_upgrade_3"/> |
| IV   | 50,000,000,000桶 | <ItemLink id="reservoir_upgrade_4"/> |

贮液仓各级的外观不同：II级为钢框架和镶铆箍，III级为铜箍、管道和阀门旋钮，IV级饰有发光的海晶水晶纹路。

升级需要依次安装。用下一级的升级右击贮液仓，或在界面中把它放入升级槽，均可立即让贮液仓升级。

界面中的**移除升级**会取出最高等级的升级并返还给你，并让贮液仓降一级。若其中流体无法被低一级的贮液仓完全容纳，按钮会请求再次点击，并给出无法容纳的量。所有超出低等级贮液仓容量的流体均会被清除。

***

## <Color id="gold">合成</Color>

<Recipe id="nautec:deep_sea_reservoir"/>

<Recipe id="nautec:reservoir_upgrade_2"/>

<Recipe id="nautec:reservoir_upgrade_3"/>

<Recipe id="nautec:reservoir_upgrade_4"/>

各等级的容量均在`config/nautec-common.toml`中。
