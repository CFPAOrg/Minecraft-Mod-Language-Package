---
navigation:
  title: Extradimensional Energy Storage
  icon: nautec:extradimensional_energy_storage
  position: 14
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:extradimensional_energy_storage
  - nautec:rift_containment_frame
  - nautec:void_containment_frame
  - nautec:abyssal_containment_frame
  - nautec:event_horizon_containment_frame
---

# <Color id="light_purple">Extradimensional Energy Storage</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="extradimensional_energy_storage" scale="2"/>
  A singularity held in a containment yoke, storing FE in the space behind it. It grows from one block into a 9x9 pad.
</Column>

It stores FE only. Place the storage block and it works straight away as a tier 1 store. Each ring of frames you build around it raises its tier, its capacity and how fast it moves FE, and the singularity above it grows to match.

***

## <Color id="gold">Tiers</Color>

| Tier | Size | Ring to add | Holds | Each port per tick |
|---|---|---|---|---|
| 1 | 1x1 | none | 10,000,000 FE | 50,000 FE |
| 2 | 3x3 | 8 <ItemLink id="rift_containment_frame"/> | 1,000,000,000 FE | 500,000 FE |
| 3 | 5x5 | 16 <ItemLink id="void_containment_frame"/> | 100,000,000,000 FE | 5,000,000 FE |
| 4 | 7x7 | 24 <ItemLink id="abyssal_containment_frame"/> | 10,000,000,000,000 FE | 50,000,000 FE |
| 5 | 9x9 | 32 <ItemLink id="event_horizon_containment_frame"/> | 1,000,000,000,000,000 FE | 2,147,483,647 FE |

Each ring sits directly around the last, on the same level as the storage block: Rift frames touching it, then Void frames around those, and so on. A ring only counts when it is complete and made of the right frame. The pad forms by itself within a second of the last frame going down, and every block of it changes to show it is part of one machine. Break any frame and the storage drops back to the last complete tier; nothing it holds is lost, but while it holds more than its new capacity it takes nothing in.

Right-click the storage block, or any formed frame, to open its screen.

***

## <Color id="gold">Ports</Color>

The storage has one port on each side. On a lone storage block the four sides of the block are the ports. Once it has rings, each port is the middle block of that edge of the pad, and FE goes in and out through its outer face.

The four buttons at the top of the screen set each port to **Input**, **Output** or **Off**. An input port takes FE from cables and machines. An output port pushes FE into whatever its face touches, and lets cables pull from it. Ports start as inputs.

***

## <Color id="gold">Resonance Networks</Color>

Pick or create a network in its screen, the same way as on a [Resonance Node](resonance_node.md). The storage then acts as the network's battery, with no mode to set:

* FE the network's input nodes send up that no output node wants goes into the storage instead of filling the uplinks.
* When output nodes or Resonance Charms want more than the input nodes are sending, the storage covers the difference.

It trades with the network at up to its port rate in each direction, every tick. The usual 10% network loss applies to what it hands out, not to what it stores. The network needs an <ItemLink id="uplink_array"/> with a launched satellite, in any dimension; until then the storage shows **No core**. **Load** keeps its chunk loaded.

***

## <Color id="gold">Moving It</Color>

Breaking the storage block keeps its FE in the item, and placing it again restores it, so a full storage can be carried to a new base. The frames drop as themselves. It needs a diamond pickaxe or better.

A <ItemLink id="configuration_card"/> copies its network, port settings and chunk loading.

***

## <Color id="gold">Recipes</Color>

<RecipeFor id="extradimensional_energy_storage"/>
<RecipeFor id="rift_containment_frame"/>
<RecipeFor id="void_containment_frame"/>
<RecipeFor id="abyssal_containment_frame"/>
<RecipeFor id="event_horizon_containment_frame"/>
