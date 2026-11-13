---
navigation:
  title: 激光合成矩阵
  icon: nautec:laser_crafting_matrix
  position: 2
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:laser_crafting_matrix
---

# <Color id="light_purple">激光合成矩阵</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="laser_crafting_matrix" scale="2"/>
  在机器内运行激光转化配方，以便自动化。
</Column>

所有[物品转化](item_transformation.md)配方都可在矩阵中执行，每次执行一个配方，物品和流体可用管道输入输出，不再需要丢到地上转化了。

## <Color id="gold">搭建设施</Color>

矩阵只接受**上方**射来的激光，需要让中继器或催化器向下指。侧面和下面射来的光束会被忽略。

配方需要光束的AP和纯度均足够。有一项不足，矩阵即会等待并保留进度。提供强于配方所需的光束可加快转化，和其他机器类似（参见[更强大的光束](stronger_beams.md)）。

空手右击打开。

* 箭头左侧有三个输入槽，右侧有三个输出槽。
* 最左侧有两个输入储罐，最右侧有两个输出储罐，每个储罐的容量都是16,000 mB（可配置）。
* 不同输入槽接受不同物品，不同储罐接受不同流体，管道不会把物品分散到所有槽位里。
* 用流体桶右击可注入流体，空铁桶右击则能取出，优先取输出储罐。
* 漏斗和流体会向输入位置送原材料，并从输出位置取产物。[面配置](utilities.md)能为每一面单独设置物品和流体行为。

面板中会显示当前配方所需的AP和纯度，符合标准时为绿色，不符合为红色。将鼠标悬停在箭头上可显示精确数据。Jade也能显示这些数据，还会显示配方产物和矩阵暂停的原因。

运转时，矩阵中间的条带会开始旋转，透镜也会搏动。

***

## <Color id="gold">配方</Color>

JEI会将所有配方显示在激光合成分类下。

| 输入                             | 输出                                         | AP  | 纯度 | 耗时 |
| -------------------------------- | -------------------------------------------- | --- | ---- | ---- |
| 海蓝钢混合物                     | 海蓝钢锭                                     | 10  | 任意 | 1 s  |
| 海蓝钢混合物                     | 2个海蓝钢锭                                  | 20  | 2.0  | 1 s  |
| <ItemLink id="burnt_coil"/>      | 激光传导线圈                                 | 20  | 1.5  | 5 s  |
| 海晶砂粒                         | 2个<ItemLink id="prismarine_crystal_shard"/> | 20  | 2.0  | 2 s  |
| <ItemLink id="cast_iron_block"/> | 4个<ItemLink id="gear"/>                     | 40  | 2.5  | 4 s  |

有多个配方匹配时，矩阵会尽可能使用高纯度的配方。

模组包和数据包可自行添加`nautec:laser_crafting`配方，最多可有三种物品输入、两种流体输入、三种物品输出、两种流体输出。

<RecipeFor id="laser_crafting_matrix"/>
