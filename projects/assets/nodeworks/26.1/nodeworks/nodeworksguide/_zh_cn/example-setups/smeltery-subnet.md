---
navigation:
  parent: example-setups/index.md
  icon: minecraft:furnace
  title: 烧炼子网
categories:
  - example
---

# 烧炼子网

特化子网是委任网络功能和重用配方的好方法。

<GameScene zoom="3" interactive={true} paddingLeft="30" paddingRight="30" paddingTop="20">
  <ImportStructure src="../assets/assemblies/roundrobin_smeltery_subnet.snbt" />
  <IsometricCamera yaw="200" pitch="20" />
  <BoxAnnotation min="0 0.75 0" max="3 1 1" color="#B02E26">
    <ItemImage id="storage_card"/>红色存储卡，从熔炉中抽取产物
  </BoxAnnotation>
  <BoxAnnotation min="1 3 1" max="2 3.25 2" color="#3C44AA">
    <ItemImage id="storage_card"/>蓝色存储卡，管理处理操作器发来的输入
  </BoxAnnotation>
  <BoxAnnotation min="0 2 0" max="3 2.25 1" color="#80C71F">
    <ItemImage id="storage_card"/>黄绿色存储卡，接受导入箱的轮询
  </BoxAnnotation>
  <BlockAnnotation x="1" y="2" z="1">
    启用轮询

    频道设为<Color id="green">黄绿色</Color>
  </BlockAnnotation>
</GameScene>

上方的**烧炼**子网示例正接受<ItemLink id="broadcast_antenna" />广播的<ItemLink id="processing_storage" />。该配方网络可用<ItemLink id="link_crystal" />链接，以便其他网络使用其中配方。

示例中还有三台<ItemLink id="processing_handler" />分别绑定至网络中的三个处理集，且均会将输入物品为送至<ItemLink id="import_chest" />。导入箱设为轮询至指向熔炉顶面的存储卡所在的频道。红色的存储卡则均指向熔炉的底面。

详情参见[自动合成](../nodeworks-mechanics/autocrafting.md)页面。