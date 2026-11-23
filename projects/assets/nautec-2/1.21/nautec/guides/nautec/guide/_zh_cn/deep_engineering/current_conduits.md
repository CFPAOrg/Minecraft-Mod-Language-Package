---
navigation:
  title: 洋流导管
  icon: nautec:current_conduit
  position: 12
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:current_conduit
  - nautec:aquarine_copper_ingot
  - nautec:aquarine_copper_compound
  - nautec:clay_gasket
  - nautec:eddy_upgrade
  - nautec:surge_upgrade
  - nautec:riptide_upgrade
  - nautec:maelstrom_upgrade
  - nautec:filter
  - nautec:intricate_filter
---

# <Color id="aqua">洋流导管</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="current_conduit" scale="2"/>
  能传输物品、流体、FE的管道。导管单独存在时没有功用，实际的传输由导管接头实现。
</Column>

<ItemLink id="current_conduit"/>可将它触及的所有导管接头组成一个网络。接头可直接对接头传输资源，也即导管中不会有资源，也就不需要保持加载。网络会在管线卸载的位置终止，直至区块加载再恢复。

导管可在水下运作，可含水。

***

## <Color id="gold">形成导管接头</Color>

1. 在需要连接的方块旁放下导管。
2. 潜行对与方块相邻的导管使用<ItemLink id="aquarine_steel_wrench"/>。导管会变为导管接头。
3. 接头能同时触及所有相邻方块，最多五个（剩下的一个为导管管线）。

用扳手潜行右击接头可将其变回普通的导管。破坏接头会掉落导管和其中物品。

用扳手站直右击可切换相应面的开关。如此点击导管可阻止它与相邻方块连接，这也是保持相邻导管不连接的方法。如此点击接头可开关相应面。

***

## <Color id="gold">面</Color>

空手右击接头以打开。界面左侧选择当前面，再在“设置”标签页中为各类资源指定：

* **存入**：网络会将这类资源送入方块。
* **取出**：网络会从方块中抽取这类资源。发电器和漏斗也可向取出面发送。
* **双向**：可以输入输出，不会将抽取自方块的资源送回原方块。
* **关闭**：该面忽略资源传输。

接头初始时每一面均为存入，需要将供应面设为取出。

接头和方块之间的连接件会显示该面的设置：仅存入为橙色，仅取出为蓝色，双向为紫色，关闭为裸铜件。连接件只会统计方块能储存的资源，箱子的连接件颜色会忽略能量设置。

**优先级**可为-99到99。高优先级的目的地先拿到资源。**分配方式**规定了同优先级目的地的传输顺序：“轮询”轮转，“最近优先”先选择最近的，“随机”会在每次传输时随机选择。**红石**可让某一面仅在有红石信号或仅在无红石信号时运转。

<ItemLink id="configuration_card"/>可将每一面的配置复制到另一个接头，包括升级和筛选器。粘贴会从你的物品栏中取用升级和筛选器，同时返还接头中原本安装的。

***

## <Color id="gold">速度</Color>

各面的传输相互独立。在接头中放置一个升级就可提升所有面的速度：

| 升级                               | 物品       | 流体           | FE          |
| ---------------------------------- | ---------- | -------------- | ----------- |
| 无                                 | 8个每20刻  | 1,000 mB/t     | 5,000/t     |
| <ItemLink id="eddy_upgrade"/>      | 16个每10刻 | 5,000 mB/t     | 25,000/t    |
| <ItemLink id="surge_upgrade"/>     | 32个每5刻  | 30,000 mB/t    | 150,000/t   |
| <ItemLink id="riptide_upgrade"/>   | 64个每2刻  | 200,000 mB/t   | 1,000,000/t |
| <ItemLink id="maelstrom_upgrade"/> | 256个每刻  | 1,000,000 mB/t | 5,000,000/t |

***

## <Color id="gold">筛选器</Color>

向接头放入<ItemLink id="filter"/>可为所有面启用筛选功能：筛选器面板中的9个物品槽和9个流体槽。<ItemLink id="intricate_filter"/>可启用所有27个物品槽。

* 用物品、流体桶、储罐点击槽位，或从JEI中拖放。右击可清除。
* Shift点击物品槽可让其匹配组件，例如精确匹配附魔书或有菌落的培养皿。这类槽位会带有金色角标。
* 有菌落的培养皿默认匹配其品系，菌落大小不限。Shift点击可让该槽匹配任意培养皿。匹配组件的空培养皿只会匹配空培养皿。
* **白名单**只允许名单中的资源通过该面，**黑名单**则会阻挡它们。未设置筛选器的面允许所有资源通过。

筛选器对两个方向都生效：它们能启用取出面的筛选功能，也会启用存入面的筛选功能。

***

## <Color id="gold">材料</Color>

丢出<ItemLink id="aquarine_copper_compound"/>后向其发射纯度2.1及以上的激光，可将1份混合物转化为4个<ItemLink id="aquarine_copper_ingot"/>。混合物由铜、海晶砂粒、干海带制成，也可在<ItemLink id="mixer"/>中通过3个铜锭、1份<ItemLink id="kelp_slurry"/>和500 mB盐水制成6份混合物。

<RecipeFor id="aquarine_copper_compound"/>
<RecipeFor id="clay_gasket"/>
<RecipeFor id="current_conduit"/>
<RecipeFor id="eddy_upgrade"/>
<RecipeFor id="filter"/>
