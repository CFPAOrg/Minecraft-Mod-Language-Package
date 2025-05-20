---
navigation:
    parent: ae2:items-blocks-machines/items-blocks-machines-index.md
    title: Pattern P2P Tunnels
    icon: mae2:pattern_p2p_tunnel
categories:
 - devices
item_ids:
- mae2:pattern_p2p_tunnel
---

# Pattern Tunneling

<GameScene zoom="4" background="transparent">
    <ImportStructure src="mae2:assets/assemblies/p2p/single_pattern.snbt" />
    <IsometricCamera yaw="15" pitch="30"/>
</GameScene>

Pattern P2P Tunnels are [P2P Tunnels](ae2:items-blocks-machines/p2p_tunnels.md)
that tunnel the [patterns](ae2:items-blocks-machines/patterns.md) pushed by [Pattern
Providers](ae2:items-blocks-machines/pattern_provider.md). Providers on the
input of a tunnel will be able to push patterns to any machine on the output of
that tunnel. Additionally machines can output into the output of the tunnel to
send it back into the pattern provider for convenience.

Patterns sent through the P2P Tunnel will act just like the Pattern Provider is
right there at the output of the tunnel. This means blocking mode works per
machine and patterns will never be split up across multiple outputs. Also
special Pattern interactions such as pushing directly into subnets or utlizing
[Molecular Assemblers](ae2:items-blocks-machines/molecular_assembler.md) work
fine.


