---
item_ids: 
- schematicenergistics:cannon_interface
- schematicenergistics:cannon_interface_part
---

# 蓝图加农炮接口

蓝图加农炮接口是可让机械动力（Create）的蓝图加农炮访问应用能源2（Applied Energistics 2，AE2）的存储与自动合成系统的方块。

<GameScene zoom="2" background="transparent" interactive={false}>
    <Block id="schematicenergistics:cannon_interface" />
</GameScene>

## 用途
将蓝图加农炮接口与蓝图加农炮相邻放置，再为接口接通AE2网络，加农炮即可访问网络中的物品。同一时刻，蓝图加农炮只可连接一个蓝图加农炮接口。

<GameScene zoom="2" background="transparent" interactive={true}>
  <ImportStructure src="./structure/example.nbt"></ImportStructure>
</GameScene>

蓝图加农炮**永远**会优先使用其他容器内的物品，然后才会访问AE2网络。也就是说，箱子、木桶等容器中的物品会被优先使用。

如果蓝图加农炮接口连接到了AE2网络，它还会从网络向蓝图加农炮输出火药。

右击可打开GUI。可在其中控制物品与火药的输送和合成请求，也可查看相连蓝图加农炮的状态。

## 配方

<Recipe id="cannon_interface" />
<Recipe id="cannon_interface_to_part" />
