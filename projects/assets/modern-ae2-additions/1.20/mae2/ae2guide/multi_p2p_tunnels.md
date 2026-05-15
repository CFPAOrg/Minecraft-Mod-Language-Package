---
navigation:
    parent: ae2:items-blocks-machines/items-blocks-machines-index.md
    title: Multi P2P Tunnels
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

# Point To Point Tunnels
Multi P2P Tunnels act exactly like their [singular counterparts](ae2:items-blocks-machines/p2p_tunnels.md), but allow
multiple inputs! More inputs can be set be using a <ItemLink
id="ae2:memory_card" /> in the offhand on a Multi P2P.

For example these 3 hoppers will all push to the 3 outputs

<GameScene zoom="3" background="transparent">
    <ImportStructure src="mae2:assets/assemblies/p2p/multi_item.snbt" />
    <IsometricCamera yaw="100" pitch="30" />
</GameScene>

or these 3 Redstone Multi P2Ps acting like an OR gate for the input repeaters
<GameScene zoom="3" background="transparent">
    <ImportStructure src="mae2:assets/assemblies/p2p/multi_redstone.snbt" />
    <IsometricCamera yaw="15" pitch="30" />
</GameScene>

or these 3 Pattern Multi P2Ps will share the molecular assemblers amongst
themselves
<GameScene zoom="3" background="transparent">
    <ImportStructure src="mae2:assets/assemblies/p2p/multi_pattern.snbt" />
    <IsometricCamera yaw="15" pitch="30" />
</GameScene>

## Note
If you're interested in the lack of ME Multi P2P Tunnels, it's because the <ItemLink id="ae2:me_p2p_tunnel" />
already blurs the line between inputs and outputs. Since
[channels](ae2:ae2-mechanics/channels.md) aren't directional, multiple inputs
could just as easily be replaced with more outputs. And, no Light Multi P2P
Tunnels are because I can't see why anyone would want them and didn't want waste
time coding them.
