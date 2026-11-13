---
navigation:
  title: Current Conduits
  icon: nautec:current_conduit
  position: 12
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:current_conduit
  - nautec:aquarine_copper_ingot
  - nautec:aquarine_copper_compound
  - nautec:clay_gasket
  - nautec:eddy_upgrade
  - nautec:surge_upgrade
  - nautec:riptide_upgrade
  - nautec:maelstrom_upgrade
  - nautec:filter
  - nautec:intricate_filter
---

# <Color id="aqua">Current Conduits</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="current_conduit" scale="2"/>
  One pipe for items, fluids and FE. Plain conduit does nothing on its own; Conduit Taps do the moving.
</Column>

A line of <ItemLink id="current_conduit"/> joins every Conduit Tap it reaches into one network. Taps move resources straight to each other, so nothing travels inside the pipe and the conduit between taps never needs its chunk loaded. If part of the line is in an unloaded chunk, the network simply stops at that point until the chunk loads again.

Conduits work underwater and can be waterlogged.

***

## <Color id="gold">Making a Conduit Tap</Color>

1. Lay conduit next to the blocks you want to connect.
2. Sneak-use an <ItemLink id="aquarine_steel_wrench"/> on the conduit touching those blocks. It turns into a Conduit Tap.
3. A tap reaches every block it touches at once, up to five machines plus the conduit line.

Sneak-use the wrench on a tap to turn it back into plain conduit. You get the upgrade and filter back. Breaking a tap drops the conduit and anything inside it.

Using the wrench without sneaking switches one side off or back on. On a conduit that stops it joining the block next to it, which is how two lines can run side by side without merging. On a tap it switches that face off.

***

## <Color id="gold">Faces</Color>

Right-click a tap with an empty hand to open it. Pick a face on the left, then set each resource on the Setup page:

* **Insert:** the network puts this resource into the block.
* **Extract:** the network takes this resource out of the block. Generators and hoppers can also push into an Extract face.
* **Extract & Insert:** takes and gives, but never sends something back to the block it came from.
* **Off:** this face ignores the resource.

New taps start with every face on Insert, so set the source faces to Extract.

The connector on each block a tap touches shows how that face is set: orange when it only inserts, blue when it only extracts, purple when it does both, and plain copper when it does neither. Only resources the block can hold count, so a chest's connector ignores the energy setting.

**Priority** runs from -99 to 99. Higher priority destinations fill first. **Distribution** decides what happens between destinations of the same priority: Round Robin takes turns, Nearest First fills the closest, Random picks a different start each move. **Redstone** can make a face run only while the tap is powered, or only while it is not.

A <ItemLink id="configuration_card"/> copies every face of one tap onto another, along with its upgrade and filter. Pasting takes the upgrade and filter from your inventory and gives back the ones the target tap held.

***

## <Color id="gold">Speed</Color>

Each face moves on its own. Put one upgrade in the tap to raise the speed of all its faces:

| Upgrade | Items | Fluids | FE |
| --- | --- | --- | --- |
| None | 8 every 20 ticks | 1,000 mB/t | 5,000/t |
| <ItemLink id="eddy_upgrade"/> | 16 every 10 ticks | 5,000 mB/t | 25,000/t |
| <ItemLink id="surge_upgrade"/> | 32 every 5 ticks | 30,000 mB/t | 150,000/t |
| <ItemLink id="riptide_upgrade"/> | 64 every 2 ticks | 200,000 mB/t | 1,000,000/t |
| <ItemLink id="maelstrom_upgrade"/> | 256 every tick | 1,000,000 mB/t | 5,000,000/t |

***

## <Color id="gold">Filters</Color>

Put a <ItemLink id="filter"/> in the tap to open filters on every face: 9 item slots and 9 fluid slots on the Filter page. A <ItemLink id="intricate_filter"/> opens all 27 item slots.

* Click a slot with an item, bucket or tank, or drag one in from JEI. Right-click clears it.
* Shift-click an item slot to make it match components exactly, such as an enchanted book or a filled dish. A gold corner marks those slots.
* A Petri Dish holding a colony starts out matching its strain, at any colony size. Shift-click it to take any dish instead. An empty dish set to match exactly takes only empty dishes.
* **Whitelist** lets only the listed things through that face, **Blacklist** blocks them. A face with no filter set lets everything through.

Filters apply both ways: they limit what an Extract face sends out and what an Insert face accepts.

***

## <Color id="gold">Materials</Color>

Fire a laser beam of purity 2.1 or higher through dropped <ItemLink id="aquarine_copper_compound"/> to turn each one into 4 <ItemLink id="aquarine_copper_ingot"/>. The compound is crafted from copper, prismarine crystals and dried kelp, or made in bulk in the <ItemLink id="mixer"/> from 3 copper ingots, 1 <ItemLink id="kelp_slurry"/> and 500 mB of saltwater, which gives 6.

<RecipeFor id="aquarine_copper_compound"/>
<RecipeFor id="clay_gasket"/>
<RecipeFor id="current_conduit"/>
<RecipeFor id="eddy_upgrade"/>
<RecipeFor id="filter"/>
