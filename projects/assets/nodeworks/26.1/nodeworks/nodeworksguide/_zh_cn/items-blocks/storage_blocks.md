---
navigation:
  parent: items-blocks/index.md
  icon: instruction_storage
  title: 配方存储器
categories:
  - autocrafting
description: 用于存储配方集，以供合成CPU查看
item_ids:
- nodeworks:instruction_storage
- nodeworks:processing_storage
---

# 配方存储器

存储器是用于存放已编写完毕的[配方集](./recipe_sets.md)的地方，随后即可被读取供<ItemLink id="crafting_core" />使用。右击打开，在槽位里放入配方集，这样就可以了。

每种配方集都有相应的存储器。

- **指令存储器：**&zwnj;存放指令集
- **处理存储器：**&zwnj;存放处理集

## 工作方式

将存储器接至节点，其中存放的所有配方集便都可被CPU查看。

<GameScene zoom="3.5" interactive={true} paddingTop="20" paddingLeft="50" paddingRight="60">
  <ImportStructure src="../assets/assemblies/processing_storage_cluster.snbt" />
  <BoxAnnotation min="0 0 0" max="3 1 1">
    **相连**的多个处理存储器会形成集群，其中的处理集均会导出
  </BoxAnnotation>
</GameScene>

相邻放置的存储器会形成集群。只需为**其中一个**方块接线，剩下的可通过相贴的面一同加入网络。破坏连通两半的关键方块会拆分集群，每一个分别判断还能否连接至网络。方块的发光纹理会与所属网络的颜色保持一致，方便查看。

## 集群化配方存储器

若有一台配方存储器连接至网络，则与其相连的所有配方存储器会形成集群，并全部连接至网络。

## 配方

<Row>
    <RecipeFor id="instruction_storage" />
    <RecipeFor id="processing_storage" />
</Row>