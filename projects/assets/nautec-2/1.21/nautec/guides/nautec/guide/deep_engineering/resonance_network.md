---
navigation:
  title: Resonance Network
  icon: nautec:resonance_node
  position: 9
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:prismatic_emitter
  - nautec:tuning_fork
  - nautec:resonance_charm
---

# <Color id="light_purple">Resonance Network</Color>

<Column alignItems="center" fullWidth={true}>
  <Row>
    <ItemImage id="uplink_array" scale="2"/>
    <ItemImage id="resonance_node" scale="2"/>
  </Row>
  A named network that carries laser power (AP) and Forge Energy (FE) between your bases without cables.
</Column>

A Resonance Network links <ItemLink id="uplink_array"/>s, [Resonance Nodes](resonance_node.md) and Resonance Charms, however far apart they are and in any dimension. An Uplink Array with a launched satellite is the network's core: input nodes and cables feed it, and it sends AP and FE on to output nodes and charms. See [Prism Satellite](prism_satellite.md) for the core and [Resonance Node](resonance_node.md) for getting power in and out.

***

## <Color id="gold">Setting Up</Color>

1. Place a <ItemLink id="resonance_node"/> or an <ItemLink id="uplink_array"/> and right-click it with an empty hand.
2. Type a name in the box and press **Create**. The network is yours, and the block joins it.
3. Open the next node or array, wherever it is, and use the arrows to pick the same network.

Nodes and arrays only work while their chunk is loaded. Turn on **Load** in a block's screen and it keeps its own chunk loaded, so a long link keeps running while you are away, unless the server has turned that off (`resonanceChunkLoading`).

***

## <Color id="gold">Who Can Use It</Color>

Only the owner and the players they trust can link a block to a network or open a block that is already on it. Anyone else gets a message naming the network and its owner.

The owner manages access from any node or array on the network:

* **Trust**: type the name of an online player and press Trust. They can now link blocks to the network. Remove them with the red x beside their name.
* **Team**: with FTB Teams installed, turning this on lets everyone in the owner's team use the network without trusting each of them.
* **Delete**: removes the network and unlinks every block on it. Click it twice.

Each player can own up to 16 networks.

***

<Row>
  <ItemImage id="prismatic_emitter"/>
  ### <Color id="aqua">Prismatic Emitter</Color>
</Row>

Powers nearby machines without cables. Feed it FE from a cable, or from an output Resonance Node placed against it, then link the machines it should power. It fires a crystal tether to each one and shares up to 10,000 FE/t between them, with nothing lost on the way.

1. Hold a <ItemLink id="tuning_fork"/> and right-click the emitter to tune the fork to it.
2. Right-click each machine to link it. Right-click a linked machine again to unlink it.

A tuned fork links another emitter the same way, so power can hop from emitter to emitter to reach machines further away. A chain cannot loop back to an emitter it started from. To tune the fork to a different emitter, sneak-right-click the air first. Breaking a linked machine or emitter removes its tether.

An emitter reaches machines up to 64 blocks away (`emitterRange`) and can feed 16 of them. Only the player who placed it can tune a fork to it. Sneak-right-click the emitter with the fork to unlink everything, or sneak-right-click the air to clear the fork.

***

<Row>
  <ItemImage id="resonance_charm"/>
  ### <Color id="aqua">Resonance Charm</Color>
</Row>

Charges the items you carry from a network, wherever you are.

Right-click a Resonance Node or Uplink Array with the charm to bind it to that network; you need access to the network. Then wear it in a charm slot. Every half second it draws FE from the network's [Uplink Arrays](prism_satellite.md), in any dimension, and charges the FE items in your inventory, armour and curio slots, along with NauTec items that run on laser power, such as the <ItemLink id="atlantean_rifle"/> and the <ItemLink id="prismatic_battery"/>. It moves up to 2,000 FE/t, and 10% is lost on the way, as with an output node.

Its crystal also does the work of a <ItemLink id="prism_monocle"/>: while it is equipped you see power and purity readouts on laser blocks and the clearer underwater view without wearing a monocle.

If the owner stops trusting you, the charm stops working until you are trusted again. Right-click the air with it to open its screen. The screen shows the network it is bound to, its owner, how many uplinks and output nodes the network has, and how much FE the uplinks hold. It also sets the charm's priority: a charm with a higher priority charges before output nodes and charms with a lower one. Sneak-right-click the air with it to unbind it.

### <Color id="aqua">Resonance Augment</Color>

To free up the charm slot, install the charm as an augment instead. Load it into an [Augmentation Station](nautec:laser_augmentation/augmentation_station.md) like any other part and fit it in your Head slot. The augment keeps the charm's network and priority and charges your items exactly as the worn charm does, including the monocle readouts. It is kept when you die.

To tune it to a different network, sneak-right-click a Resonance Node or Uplink Array with an empty hand. To see its network or change its priority, open the Augmentation Screen (B by default) and click the Head row. If you wear a bound charm as well, the charm is used and the augment waits.
