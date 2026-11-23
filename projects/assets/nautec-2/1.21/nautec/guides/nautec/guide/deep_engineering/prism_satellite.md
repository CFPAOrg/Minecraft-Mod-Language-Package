---
navigation:
  title: Prism Satellite
  icon: nautec:prism_satellite
  position: 10
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:prism_satellite
  - nautec:uplink_array
---

# <Color id="aqua">Prism Satellite</Color>

<Column alignItems="center" fullWidth={true}>
  <Row>
    <ItemImage id="uplink_array" scale="2"/>
    <ItemImage id="prism_satellite" scale="2"/>
  </Row>
  Carries laser power (AP) and FE anywhere on a network, with no relay chain.
</Column>

An <ItemLink id="uplink_array"/> takes AP from your lasers and FE from your cables and beams them up to a satellite in orbit above it. The satellite beams them back down to every output [Resonance Node](resonance_node.md) and Resonance Charm on the same network, however far away they are.

***

## <Color id="gold">Setting Up</Color>

1. Place an <ItemLink id="uplink_array"/>. It is two blocks tall.
2. Right-click it with an empty hand and pick or create a network, the same way as on a <ItemLink id="resonance_node"/>. Arrays and nodes share networks and their trusted players.
3. Right-click the uplink with a <ItemLink id="prism_satellite"/> to launch it. The satellite climbs into orbit and stays there until the uplink is broken, which drops it back.
4. Fire lasers into the uplink's sides or underside, and pipe FE into it from any side.
5. Place a <ItemLink id="resonance_node"/> where the power is needed, put it on the same network and set it to **Output**.

***

## <Color id="gold">Rules</Color>

* **Sky:** the uplink needs open sky above the dish. Only solid blocks get in the way. Water, glass and leaves count as open, so an uplink on the sea floor or under a glass roof works. Resonance Nodes need no sky.
* **Dimension:** every uplink with a launched satellite feeds one pool for the whole network, in every dimension. An output node in a dimension with no uplink of its own still gets power, but its AP arrives with 5% less purity (`satelliteCrossDimensionPurityLoss`). Build an uplink in that dimension to avoid the loss.
* **Sharing:** output nodes and charms with the highest priority are filled first, and those with the same priority split evenly. 10% is lost on the way. Purity carries through unchanged within a dimension that has an uplink.
* **Several uplinks:** every uplink on a network adds to the same pool, whatever dimension it is in. Their beams merge, so the pool's purity stays close to the purest uplink's.
* **Loaded chunks:** an uplink only works while its chunk is loaded. Turn on **Load** in its screen and it keeps its own chunk loaded, unless the server has turned that off (`resonanceChunkLoading`).

The screen shows whether the uplink is online and, if not, what it is waiting for, along with how much AP and FE it holds.

***

## <Color id="gold">Buffers</Color>

Each uplink holds up to 5,000,000 AP and 5,000,000 FE (`satelliteApBuffer` and `satelliteFeBuffer`). It stores the AP beamed into it, along with its purity, and the FE pushed into it, and keeps both until output nodes or charms on the network want them, so an uplink can fill up before its outputs are built.

Priority and per-tick limits are set on each output node; see [Resonance Node](resonance_node.md).
