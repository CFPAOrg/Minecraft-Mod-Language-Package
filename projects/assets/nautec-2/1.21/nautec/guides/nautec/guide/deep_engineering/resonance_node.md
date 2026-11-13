---
navigation:
  title: Resonance Node
  icon: nautec:resonance_node
  position: 11
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:resonance_node
---

# <Color id="aqua">Resonance Node</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="resonance_node" scale="2"/>
  Plugs any laser line or FE cable into a satellite network, with no dish and no open sky.
</Column>

A Resonance Node joins the same [Resonance Networks](resonance_network.md) as [Uplink Arrays](prism_satellite.md). Every uplink with a launched satellite pools its power for the whole network. A node puts power into that pool, or takes power out of it, from wherever you place it.

***

## <Color id="gold">Setting Up</Color>

1. Place the node on the face of any block. Its crystal points away from the face you clicked.
2. Right-click it with an empty hand and pick or create a network. Type a name and press **Create** for a new one, or use the arrows to pick one you already have.
3. Set it to **Input** or **Output** with the button in its screen.

The network needs at least one <ItemLink id="uplink_array"/> with a launched satellite and clear sky, in any dimension. Until it has one, the node shows **No core** and moves nothing.

***

## <Color id="gold">Input and Output</Color>

* **Input:** takes laser beams fired into any side and FE from cables, and sends both up to the network's uplinks. It sends to uplinks in its own dimension first. AP it sends to an uplink in another dimension loses 5% of its purity.
* **Output:** takes AP and FE from the network. It fires the AP out of its crystal's tip as a beam and pushes the FE into anything touching it.

Output nodes share the network's power with Resonance Charms, in priority order. 10% is lost on the way, and a node in a dimension with no uplink of its own gets its AP with 5% less purity.

***

## <Color id="gold">Buffers, Priority and Limits</Color>

A node holds up to 200,000 AP and 1,000,000 FE (`resonanceNodeApBuffer` and `resonanceNodeFeBuffer`). An input node holds what it takes in until the uplinks have room. An output node holds what it takes from the network and passes it on as fast as its limit allows.

The controls at the top of the screen set its priority, from -100 to 100, and its limit: the most AP, and separately FE, it moves each tick. Higher priorities are filled first. Click either number to reset it.

***

## <Color id="gold">Upgrades</Color>

On its own a node moves up to 100,000 AP and 100,000 FE per tick (`satelliteTransferLimit`). A conduit upgrade raises that, and its buffers grow to match:

| Upgrade | Moves per tick | FE buffer | AP buffer |
|---|---|---|---|
| None | 100,000 | 1,000,000 | 200,000 |
| <ItemLink id="eddy_upgrade"/> | 500,000 | 5,000,000 | 1,000,000 |
| <ItemLink id="surge_upgrade"/> | 2,500,000 | 25,000,000 | 5,000,000 |
| <ItemLink id="riptide_upgrade"/> | 10,000,000 | 100,000,000 | 20,000,000 |
| <ItemLink id="maelstrom_upgrade"/> | no limit | 1,000,000,000 | 1,000,000,000 |

Right-click the node with an upgrade to fit it; a fitted upgrade comes back to you when you swap it. Sneak and right-click with an empty hand to take it out. The screen shows the fitted upgrade under the mode button. `resonanceNodeUpgradeLimits` sets the per-tick limits.

Each <ItemLink id="uplink_array"/> holds 5,000,000 FE, so a network moving more than that each tick needs more than one uplink.

Turn on **Load** to keep the node's own chunk loaded, so it works while nobody is nearby.

A <ItemLink id="configuration_card"/> copies a node's network, mode, priority, limit, chunk loading and upgrade onto another node.

***

## <Color id="gold">Recipe</Color>

<RecipeFor id="resonance_node"/>
