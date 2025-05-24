---
navigation:
    parent: ae2:items-blocks-machines/items-blocks-machines-index.md
    title: 样板P2P通道
    icon: mae2:pattern_p2p_tunnel
categories:
 - devices
item_ids:
- mae2:pattern_p2p_tunnel
---

# 样板通道

<GameScene zoom="4" background="transparent">
    <ImportStructure src="mae2:assets/assemblies/p2p/single_pattern.snbt" />
    <IsometricCamera yaw="15" pitch="30"/>
</GameScene>

样板P2P通道是一类[P2P通道](ae2:items-blocks-machines/p2p_tunnels.md)，能传递[样板供应器](ae2:items-blocks-machines/pattern_provider.md)送出的[样板](ae2:items-blocks-machines/patterns.md)。输入端的供应器可以向输出端的任意机器发送样板。而且，为设计方便，还可让机器把产物送回输出端；通道会将其传递到样板供应器处。

样板若通过P2P通道送出，其表现会与在通道输出端处直接使用样板供应器发送一致。换言之，阻挡模式对各输出端的机器独立生效，样板不会分到多个输出端中去。而且，直送子网络或与[分子装配室](ae2:items-blocks-machines/molecular_assembler.md)协同等特殊样板交互表现不变。


