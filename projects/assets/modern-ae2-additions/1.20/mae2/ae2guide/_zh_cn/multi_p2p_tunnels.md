---
navigation:
    parent: ae2:items-blocks-machines/items-blocks-machines-index.md
    title: 多端P2P通道
    icon: mae2:pattern_multi_p2p_tunnel
    position: 210
categories:
 - devices
item_ids:
- mae2:redstone_multi_p2p_tunnel
- mae2:item_multi_p2p_tunnel
- mae2:fluid_multi_p2p_tunnel
- mae2:fe_multi_p2p_tunnel
- mae2:eu_multi_p2p_tunnel
- mae2:pattern_multi_p2p_tunnel
---

# 点对点通道
多端P2P通道和[单端的通道](ae2:items-blocks-machines/p2p_tunnels.md)表现类似，但前者能接受多个输入端！副手持<ItemLink id="ae2:memory_card" />对多端P2P使用即可设置多个输入端。

比如说，下方的3个漏斗均会向3个输出端输出

<GameScene zoom="3" background="transparent">
    <ImportStructure src="mae2:assets/assemblies/p2p/multi_item.snbt" />
    <IsometricCamera yaw="100" pitch="30" />
</GameScene>

又比如，这3个红石多端P2P通道的对输入端的中继器表现为或门
<GameScene zoom="3" background="transparent">
    <ImportStructure src="mae2:assets/assemblies/p2p/multi_redstone.snbt" />
    <IsometricCamera yaw="15" pitch="30" />
</GameScene>

再比如，这3个样板多端P2P通道会共享分子装配室
<GameScene zoom="3" background="transparent">
    <ImportStructure src="mae2:assets/assemblies/p2p/multi_pattern.snbt" />
    <IsometricCamera yaw="15" pitch="30" />
</GameScene>

## 注意事项
如果你对模组内不存在ME多端P2P通道有所疑问——那是因为<ItemLink id="ae2:me_p2p_tunnel" />已经不会明确区分输入和输出端。而由于[频道](ae2:ae2-mechanics/channels.md)没有方向性，如果需要多个输入端，简单换成再加更多输出端也能达成同样的功能。没有光多端P2P通道则是因为我不认为会有人有此类需求，也不想把时间浪费在编写有关代码上。
