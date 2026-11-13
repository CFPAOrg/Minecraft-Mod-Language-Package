---
navigation:
  title: 共鸣节点
  icon: nautec:resonance_node
  position: 11
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:resonance_node
---

# <Color id="aqua">共鸣节点</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="resonance_node" scale="2"/>
  将激光和FE线缆接入卫星网络，不用接收锅，也不用露天。
</Column>

共鸣节点可以加入[上行链路阵列](prism_satellite.md)所在的[共鸣网络](resonance_network.md)。所有已发射人造卫星的上行链路都能为整个网络缓存能量。节点能在任何地方向它存入能量，也可从中抽取能量。

***

## <Color id="gold">搭建设施</Color>

1. 将节点放在任意方块的任意面上。节点的水晶会背朝所点击的方块面。
2. 空手右击并选择或创建网络。输入名称后点击**创建**可创建新网络，或用箭头按钮选择你已有的网络。
3. 在界面的按钮处将节点设为**输入**或**输出**。

网络中需要至少有一个已发送卫星且露天的<ItemLink id="uplink_array"/>，维度不限。若没有，节点会显示**无核心**，且不会传输资源。

***

## <Color id="gold">输入与输出</Color>

* **输入**：接收任意面发来的激光和线缆送来的FE，并将两者都送至网络的上行链路。它会优先发送至本维度的上行链路。送至其他维度上行链路的AP会损失5%的纯度。
* **输出**：接收网络的AP和FE。节点会从其水晶的尖端以光束的形式输出AP，并向相邻方块输出FE。

输出节点和共鸣护符共享网络的能量和功率，按优先级排序。传输时会损失10%，若节点所在维度没有上行链路还会损失AP的5%纯度。

***

## <Color id="gold">缓存、优先级、上限</Color>

节点最多能容纳200,000 AP和1,000,000 FE（`resonanceNodeApBuffer`和`resonanceNodeFeBuffer`）。在上行链路腾出空间前，输入节点会暂存它收到的能量和功率。输出节点则会暂存它从网络中收到的资源并向外输送，最快可为上限规定的速率。

界面顶部的按键可设置节点优先级（-100到100）和上限：每刻的AP和FE最大传输量，AP、FE相互独立。高优先级的节点优先填充。点击数字可重置。

***

## <Color id="gold">升级</Color>

节点不加升级时每刻最多能传输100,000 AP和100,000 FE（`satelliteTransferLimit`）。导管升级可提高上限，缓存容量也会相应增加：

| 升级                               | 每刻传输量 | FE缓存容量    | AP缓存容量    |
| ---------------------------------- | ---------- | ------------- | ------------- |
| 无                                 | 100,000    | 1,000,000     | 200,000       |
| <ItemLink id="eddy_upgrade"/>      | 500,000    | 5,000,000     | 1,000,000     |
| <ItemLink id="surge_upgrade"/>     | 2,500,000  | 25,000,000    | 5,000,000     |
| <ItemLink id="riptide_upgrade"/>   | 10,000,000 | 100,000,000   | 20,000,000    |
| <ItemLink id="maelstrom_upgrade"/> | 无上限     | 1,000,000,000 | 1,000,000,000 |

用升级右击节点以安装；替换安装时原有的升级会返还。空手潜行右击可取出升级。界面中，升级会显示在模式按钮下方。可用`resonanceNodeUpgradeLimits`设置每刻的上限。

单个<ItemLink id="uplink_array"/>可容纳5,000,000 FE，每刻若要传输超出该数的FE，应放置多个上行链路。

启用**加载**，可保持节点所在区块加载，以便在周围无人时运转。

<ItemLink id="configuration_card"/>可将节点的网络、模式、优先级、上限、区块加载设置和升级复制给其他节点。

***

## <Color id="gold">配方</Color>

<RecipeFor id="resonance_node"/>
