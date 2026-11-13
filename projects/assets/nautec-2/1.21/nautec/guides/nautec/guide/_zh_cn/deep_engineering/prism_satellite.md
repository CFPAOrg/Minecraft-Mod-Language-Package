---
navigation:
  title: 海棱人造卫星
  icon: nautec:prism_satellite
  position: 10
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:prism_satellite
  - nautec:uplink_array
---

# <Color id="aqua">海棱人造卫星</Color>

<Column alignItems="center" fullWidth={true}>
  <Row>
    <ItemImage id="uplink_array" scale="2"/>
    <ItemImage id="prism_satellite" scale="2"/>
  </Row>
  将激光功率（AP）和FE送到接入网络的任何地方，无需使用中继器。
</Column>

<ItemLink id="uplink_array"/>可接收激光发来的AP和线缆送来的FE，并将两者发射至上方在轨的人造卫星。卫星随后会将它们送至同网络中的所有输出[共鸣节点](resonance_node.md)和共鸣护符，无视距离。

***

## <Color id="gold">搭建设施</Color>

1. 放置<ItemLink id="uplink_array"/>。阵列高两格。
2. 空手右击以选择或创建网络。操作方法和在<ItemLink id="resonance_node"/>中一致。阵列和节点会共用网络和信任的玩家。
3. 用<ItemLink id="prism_satellite"/>右击上行链路以发射。卫星会上升入轨，并在上行链路被破坏之前保持在轨；破坏时会掉落人造卫星。
4. 向上行链路的侧面或底面发射激光，从任意一面送入FE。
5. 在需要能量或激光的位置放置<ItemLink id="resonance_node"/>，将其加入上行链路的网络，并设为**输出**。

***

## <Color id="gold">规则</Color>

* **露天**：上行链路的接收锅需要露天。只有固体方块视作遮挡，水、玻璃、树叶均不会遮挡，在海床上和在玻璃屋顶下的上行链路也能运转。共鸣节点不需要露天。
* **维度**：已发射卫星的上行链路相当于一个共享缓存，可供任意维度的同网络方块使用。所在维度没有上行链路的输出节点仍能收到能量和功率，但AP会损失5%的纯度（`satelliteCrossDimensionPurityLoss`）。可在该维度搭建上行链路以避免纯度损耗。
* **共享**：高优先级的输出节点和护符会被优先填充，同优先级的相互均分。传输过程会损失10%的能量和功率。只要维度中有上行链路，就不会损失纯度。
* **多个上行链路**：每一个上行链路都会追加网络的共享缓存，无论处于哪个维度。各条光束会汇合，因此缓存中的纯度会接近于各上行链路所接收光束中纯度最高的。
* **区块加载**：上行链路只会在所处区块加载时运转。在界面中启用**加载**可保持所在区块加载，除非服务端关闭了加载功能（`resonanceChunkLoading`）。

界面中会显示上行链路是否在线，不在线时还会显示原因，以及其中存有的AP和FE。

***

## <Color id="gold">缓存</Color>

每个上行链路可容纳最多5,000,000 AP和5,000,000 FE（`satelliteApBuffer`和`satelliteFeBuffer`）。它会储存光束送来的AP，记录其纯度，也会储存收到的FE；在有输出节点或护符需求前，上行链路会暂存资源，因此在设置输出之前上行链路会逐渐存满。

优先级和每刻上限在各个输出节点处分别设置，参见[共鸣节点](resonance_node.md)。
