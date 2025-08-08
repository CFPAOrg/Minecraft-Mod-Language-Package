---
item_ids: 
- schematicenergistics:cannon_interface
- schematicenergistics:cannon_interface_part
---

# 蓝图大炮接口

蓝图大炮接口是可让机械动力（Create）的蓝图大炮访问应用能源2（Applied Energistics 2，AE2）的存储与自动合成系统的方块。

<GameScene zoom="2" background="transparent" interactive={false}>
    <Block id="schematicenergistics:cannon_interface" />
</GameScene>

## 用途
将蓝图大炮接口与蓝图大炮相邻放置，再为接口接通AE2网络，大炮即可访问网络中的物品。同一时刻，蓝图大炮只可连接一个蓝图大炮接口。

<GameScene zoom="2" background="transparent" interactive={true}>
  <ImportStructure src="./structure/example.snbt"></ImportStructure>
</GameScene>

蓝图大炮**永远**会优先使用其他容器内的物品，然后才会访问AE2网络。也就是说，箱子、木桶等容器中的物品会被优先使用。

如果蓝图大炮接口连接到了AE2网络，它还会从网络向蓝图大炮输出火药。

## 配方

<Recipe id="cannon_interface" />
<Recipe id="cannon_interface_to_part" />
