---
navigation:
  title: Colony Feeding
  icon: minecraft:bone_block
  position: 9
  parent: aquatic_biology/aquatic_biology-index.md
---

# <Color id="light_purple">Colony Feeding</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="minecraft:bone_block" scale="2"/>
  Nutrients in a reactor's nutrient slots keep its colonies from aging.
</Column>

This works the same in the [Bio Reactor](bio_reactor.md) and the [Industrial Bio Reactor](industrial_bio_reactor.md).

***

## <Color id="gold">The Nutrient Buffer</Color>

Every colony slot has a nutrient buffer, shown as the thin bar beside the colony. While the colony works it spends one tick of buffer per tick instead of aging. When the buffer is empty, the reactor takes one matching nutrient from its nutrient slots and adds that recipe's ticks to the buffer. Every shipped strain gets 1,200 ticks, one minute of work, from each item, except that a storage block gives nine times that.

So each working colony eats one nutrient a minute. The buffer only drains while the colony works: a reactor without enough power, or a colony whose output slot is full, spends nothing. A [Reactor Efficiency Upgrade](reactor_upgrades.md) makes each item last longer.

Hover the bar to see how many seconds are left. With an empty buffer and no matching nutrient the bar reads "No nutrients: the colony is aging", and the colony ages as described in [Bacteria Stats](bacteria_stats.md). A starving Senescent colony shrinks by 2% of its size every second it works, and a single nutrient stops that at once. Feeding never resets a colony's age; only the [Incubator](incubator.md) does that.

***

## <Color id="gold">Which Nutrient</Color>

Each strain has its own nutrient, and by default it is the same item that strain eats in the Incubator. JEI's Colony Feeding category lists every one: look up a strain to see its nutrient, or look up the uses of an item to see which strains it feeds. A few examples:

| Strain | Nutrient |
|---|---|
| Lithophiles | Stone |
| Silicophiles and Halotrophs | Sand |
| Lipophiles | Kelp Slurry |
| Calciophiles | Bone Block |
| Crimson Microbes | Crimson Nylium |
| Carbophages | any coal ore |
| Ferrophiles | any iron ore |
| Adamantophiles | any diamond ore |
| Plumbophiles | lead ingots |

Strains for other mods' metals and gems eat the ingot or gem they make, so you can send a small share of a reactor's output back into its nutrient slot.

On top of its own nutrient, every strain that has one also eats the item it makes and that item's storage block. Ferrophiles take Iron Ingots and Iron Blocks as well as iron ore, Rhizobacteria take Hay Bales as well as wheat, and a tin strain takes tin blocks. The item it makes feeds as long as its own nutrient, and a storage block nine times as long. This covers strains from other mods and ones made with `/nautec bacteria generate` too. JEI lists these alongside the rest.

Cyanobacteria, Halobacteria, Methanogens and Thermophiles have no nutrient, so they always age while they work.

***

## <Color id="gold">Nutrient Slots</Color>

The Bio Reactor has 2 nutrient slots and the Industrial Bio Reactor has 3. They only accept items that feed some strain. When a colony needs feeding, the reactor checks the slots in order and takes from the first one holding that colony's nutrient, so one stack feeds every colony of that strain.

Each slot holds one kind of item, so a Bio Reactor can feed at most two different nutrients at a time and the Industrial Bio Reactor three. Fill a reactor with strains that share nutrients, or with no more strains than it has nutrient slots, if every colony should stay fed. A nutrient that nothing in the reactor eats just takes up a slot.

***

## <Color id="gold">Automating Nutrients</Color>

Hoppers and pipes can insert nutrients:

* Bio Reactor: through the top of the Bio Reactor block, for example with a hopper sitting on it, or with a pipe into the underside of the base.
* Industrial Bio Reactor: through any outer face of any of its blocks, for example with a hopper on the roof.

Automation puts nutrients only into nutrient slots and upgrades only into upgrade slots, and never takes either back out. A chest of nutrients feeding in and the output being pulled out is enough to run a reactor indefinitely.

***

## <Color id="gold">Changing Feeding in a Pack</Color>

Feeding is data. Each rule is a recipe of type `nautec:colony_feeding`, and the shipped ones are at `data/nautec/recipe/colony_feeding/<strain>.json`, so a datapack can replace them or add more.

| Field | Meaning |
|---|---|
| `bacteria` | A strain id, a bacteria tag written with `#`, or left out to match every strain. |
| `ingredient` | An object holding the item `ingredient` and an optional `count` (default 1). The slot must hold at least that many, and one feeding takes them all. |
| `vitality_ticks` | Ticks of buffer one feeding adds. |

When more than one recipe accepts the same item for a colony, a recipe naming the strain wins over a tag, and a tag wins over a recipe for every strain. A written recipe always wins over the automatic product and storage block rule.

The storage block is found from the `c:storage_blocks/<material>` tag that matches the item's `c:ingots`, `c:gems` or `c:dusts` tag. Items without one, such as Wheat and Bone Meal, name their block in the `nautec:storage_blocks` item data map, which a datapack can add to. `bacteriaProductNutrients` in `config/nautec-common.toml` turns the rule off. `/nautec bacteria generate` writes a feeding recipe for each strain it makes, see [Custom Bacteria](custom_bacteria.md).
