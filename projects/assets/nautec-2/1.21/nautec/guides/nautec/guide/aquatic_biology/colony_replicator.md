---
navigation:
  title: Colony Replicator
  icon: nautec:colony_replicator
  position: 15
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:colony_replicator
---

# <Color id="light_purple">Colony Replicator</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="colony_replicator" scale="2"/>
  Turns spare colonies of a strain into copies of your best one.
</Column>

Breeding a strong colony takes a long chain of [mutations](mutator.md), and every mutation changes the strain. The Replicator lets you breed a colony up once and then make more of it from cheap colonies of the same strain, such as fresh grafts.

***

## <Color id="gold">Replicate</Color>

* Template (top left): your best colony. It must be [analyzed](bacterial_analyzer.md). It is copied and never used up.
* Fodder (middle): any colony of the template's strain, whatever its stats. It is broken down into biomass as soon as it goes in. A colony of another strain stays in the slot and the machine waits.
* Fodder items (above the fodder colony): the item the template's strain makes, or that item's storage block. Each one is broken down into biomass, so a reactor's own output can pay for copies.
* Output (right): the new colony.

Each new colony uses 20,000 biomass. A fodder colony gives its size: ten colonies of 2,000 work as well as one of 20,000. A fodder item gives 100 divided by the strain's [Strain Yield](production_rates.md), and a storage block nine times that, so rare items are worth more:

| Item | Biomass | For one copy |
|---|---|---|
| Stone (Strain Yield 1) | 100 | 200 stone |
| Iron Ingot (0.6) | 167 | 120 ingots, or 14 Iron Blocks |
| Diamond (0.12) | 833 | 25 diamonds, or 3 Diamond Blocks |

The bar beside the fodder slot shows how much is stored, up to 200,000. Fodder that would take the store past 200,000 is still used up, and the extra is lost. Biomass belongs to one strain, so changing the template to another strain throws away what is stored.

The new colony has the template's stats, comes out analyzed, and starts at a size of 10,000, half the biomass it cost, so it is ready to work or to top up in the [Incubator](incubator.md).

### Copy Errors

A copy can come out slightly worse than the template. Each stat has its own chance of an error, and an error takes up to a tenth off that stat. A copy is never better than the template.

Mutation Resistance decides how faithful the copy is. With no resistance, each stat has a 50% chance of an error. The chance and the size of the error both shrink as resistance rises, and at the resistance cap every copy is perfect. Breed resistance up first if you want a line of identical colonies.

***

## <Color id="gold">Splice</Color>

Press the mode button to switch to Splice. Put a second analyzed colony of the same strain in the partner slot (bottom left). Neither parent is used up.

The child takes each of its four stats from one parent, and for each stat it has a 70% chance of taking the better value. Splicing a colony with a high Production Rate and one with a long Lifespan can give you both. The child can never beat the better parent on any stat, and it is then copied with a copy error chance set by its own Mutation Resistance, as above.

Splicing uses the same biomass as replicating.

***

## <Color id="gold">Power</Color>

It needs a laser beam of at least 80 AP at purity 2.0 or higher, into any face except the front. It takes 30 seconds per colony. With a weaker beam it pauses and keeps its progress.

***

## <Color id="gold">Automation</Color>

The three slots at the bottom left are the Dish Port: a dish goes in on the left, finished copies come out of the middle slot and empty dishes come out on the right. A Petri Dish holding a colony of the template's strain loads it into the fodder slot. An empty dish takes each finished colony out of the output slot. The port only accepts a dish it can use right then: no fodder before a template is set, no fodder of another strain, and no empty dish until a copy is waiting. Hoppers and pipes can fill the port and pull dishes out, so a row of grafting machines can keep it fed.

The power, purity, time, biomass cost and storage, biomass per item, copy size, copy error chance and splice chance are all in `config/nautec-common.toml`.

***

## <Color id="gold">Stronger Beams</Color>

The Colony Replicator needs 80 AP. A stronger beam copies colonies faster: its speed is the square root of (beam ÷ 80).

| Beam | Speed |
|---|---|
| 80 AP | ×1 (normal) |
| 320 AP | ×2 |
| 720 AP | ×3 |
| 1,280 AP | ×4 |

It still needs purity 2.0 or higher, and purity does not speed it up. The 30 seconds per colony is on an 80 AP beam.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.

<RecipeFor id="colony_replicator"/>
