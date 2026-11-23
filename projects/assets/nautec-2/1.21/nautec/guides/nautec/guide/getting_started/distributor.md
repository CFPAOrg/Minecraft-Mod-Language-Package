---
navigation:
  title: Nautechnical Distributor
  icon: nautec:nautechnical_distributor
  position: 8
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:nautechnical_distributor
---

# <Color id="light_purple">Nautechnical Distributor</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="nautechnical_distributor" scale="2"/>
  Collects outputs from machines all over your base and keeps them supplied, with no pipes.
</Column>

The Distributor links to blocks up to 256 blocks away in the same dimension. Every few ticks it collects their outputs and puts them into the chests and tanks next to it, and keeps their inputs stocked with what they ask for. It moves as much as fits each time, with no rate limit. It works with items and fluids, and with machines from any mod.

***

## <Color id="gold">Linking</Color>

1. Sneak and right-click the Distributor with an empty hand.
2. Sneak and right-click each block you want to link, also with an empty hand. The face you click is the face the Distributor uses, just like the side a pipe connects to.
3. Sneak and right-click the Distributor again when you are done.

Sneak and right-clicking a linked block again unlinks it. Linking ends by itself after a minute with no new link. You can also unlink blocks from the Distributor's screen. One Distributor holds up to 64 links.

For machines from other mods the face matters: pick the face that gives out results, such as the bottom of a furnace. NauTec machines follow their [Side Configuration](utilities.md), so only their outputs are ever collected.

***

## <Color id="gold">Collecting Outputs</Color>

The Distributor takes everything it can pull through each link's face and puts it into the inventories and tanks on its own six sides. It only takes what it can place, so a full chest makes it wait instead of losing anything. Linked blocks are never treated as one of its neighbours.

***

## <Color id="gold">Supplying Inputs</Color>

There are two ways to ask for inputs.

On a NauTec machine, open its screen, hold Sneak and click an empty input slot with an item, or drag the item onto the slot from JEI. The slot now shows that item faintly: it is a ghost input. The Distributor keeps that slot as full as it can, and the slot only accepts that item. A ghost input or a request matches the exact item, enchantments and other data included. Petri Dishes are matched by what they hold: a ghost of an empty dish only takes empty dishes, and a ghost of a dish holding a colony takes any colony of that strain, whatever its size or stats. The Bacterial Analyzers are the exception: a ghost of an empty dish there takes any colony that still needs analysis. Sneak and click it with an empty hand to clear it. Hover over an input slot for a reminder.

For any linked block, NauTec or not, select it in the Distributor's screen and set requests on the right: up to nine items and three fluids, each with an amount to keep in the block. Click a request slot with an item or a filled bucket, or drag one in from JEI. Scroll over a request to change its amount (hold Shift to change items by 16 and fluids by 10,000 mB) and right-click it to clear it. This is also how you supply NauTec machines that have no screen, such as Etching Acid for the Abyssal Pressure Forge.

Inputs come first from other linked machines' outputs, then from the chests and tanks next to the Distributor, then from a storage network next to it (see below). So one machine's product can feed the next machine directly, and only what is left over is exported. Anything a link requests is never collected back out of it.

***

## <Color id="gold">Storage Networks</Color>

Place an Applied Energistics 2 ME Interface or a Refined Storage Interface against the Distributor, and it pulls the ghost inputs and requests its links ask for straight out of that whole network, items and fluids alike. An ME Interface part on a cable works too, as long as it faces the Distributor. The interface needs a channel and power, as it would for anything else.

It only takes what the machine has room for, and only after checking the machine will accept it, so nothing is lost or copied if the machine fills up. A machine that is still waiting on an item checks less often, up to every 5 seconds, so a network that does not hold it costs almost nothing.

Outputs the Distributor collects still go into the interface like into any other neighbour, which puts them into the network. `distributorStorageNetworks` in `config/nautec-common.toml` turns the network pull off.

***

## <Color id="gold">Settings</Color>

The range, the number of links and how often it moves (every 4 ticks) are in `config/nautec-common.toml`.

<RecipeFor id="nautechnical_distributor"/>
