---
navigation:
  title: Mutator
  icon: nautec:mutator
  position: 6
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:mutator
---

# <Color id="light_purple">Mutator</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="mutator" scale="2"/>
  Change a colony's strain or refine its stats.
</Column>

**Trying to raise Production Rate?** Keep your best colony, refine copies, and keep only the improvements. A successful attempt can still lower stats. Start with [Stat Breeding](mutator.md#stat-breeding) below.

Put the colony in the left bacteria slot and the catalyst in the item slot. Every 12 seconds the Mutator makes one attempt, and keeps making attempts until one succeeds. The right bacteria slot must be empty before it starts, so take each new colony out as soon as it appears.

The catalyst is not used up, so one item covers every attempt. Hoppers and pipes can insert it, through any face by default ([Side Configuration](nautec:getting_started/utilities.md)).

The two slots at the bottom left are the Dish Port: a dish goes in on the left and new mutations come out on the right. A Petri Dish holding a colony loads it into the left bacteria slot when that slot is free and the catalyst in the Mutator works on that strain. The emptied dish stays in the port, and as soon as the mutation appears in the right bacteria slot it takes it out and moves it to the output slot. That frees the port for the next colony, so a pipe feeding colony dishes in and another pulling mutations out keeps the Mutator working with no empty dishes to handle. The port only accepts a dish it can use right then, so put the catalyst in first, and a pipe keeps hold of anything else instead of jamming the machine.

JEI's Bacteria Mutations category lists the catalyst and base chance for every mutation, and [Strain Tree](strain_tree.md) shows them all as a tree.

Hover the empty catalyst slot with a colony loaded to see every strain it can become, with the catalyst and its chance for that colony. Hover the progress arrow to see what the Mutator is waiting for, the power it is getting, the real chance per try after size, Mutation Resistance and the booster, what a failure costs, and how many tries have failed so far.

***

## <Color id="gold">Power</Color>

It needs a beam of at least 10 AP entering its top or bottom face. Beams into both faces add together. Below 10 AP it pauses. The time (240 ticks) and the power are configurable.

***

## <Color id="gold">Success</Color>

The chance shown in JEI is the best case. Two things lower it:

* Mutation Resistance: at the resistance cap the chance is halved.
* Size: at the size cap the chance is a quarter lower.

A 25% mutation on a fresh colony of 400 with 0.05 resistance succeeds about 24% of the time. The same mutation on a full 40,000 colony drops to about 18%.

On a success the whole input colony is used up and the new strain appears in the right slot. It starts at its own starting size, whatever size the parent was. It inherits the parent's four stats with a small random shift, starts at full Vitality, and comes out unanalyzed.

***

## <Color id="gold">Failure</Color>

A failed attempt kills a quarter of the colony, reduced by its Mutation Resistance: a colony at the resistance cap loses nothing. A failure never takes the last of a colony, so the Mutator always keeps trying. A filled [booster](mutator.md#booster) slot stops failures from costing anything.

Since the new colony's size does not depend on the parent, mutate colonies while they are small. Growing a colony first only lowers the chance and gives failures more to eat.

***

## <Color id="gold">Stat Breeding</Color>

A successful mutation or refinement is a new stat roll, not a guaranteed improvement. Growth Rate, Production Rate and Lifespan can go down as well as up. Repeatedly refining your only colony can undo the gains you already made.

### Keep the best, refine the copies

1. Analyze your colony in the [Bacterial Analyzer](bacterial_analyzer.md) and keep your best one as a template.
2. Make spare colonies in the [Colony Replicator](colony_replicator.md). Copies can lose stats too, so compare each result against the original template.
3. Refine a spare in the Mutator, then analyze the result. Keep a better result as your new template; keep the old template when the result is worse.
4. Repeat until the stats you care about reach their caps. Grow the finished colony in the [Incubator](incubator.md) for production.

You do not have to change strain to breed stats. Use the storage block of the item a colony makes as the catalyst (Iron Blocks for Ferrophiles, Hay Bales for Rhizobacteria), or the item itself if it has no storage block. JEI lists each refinement as a strain turning into itself.

A refinement has a 25% base success chance, reduced by colony size and Mutation Resistance. A success keeps the strain and colony size while rolling the stats. A failed attempt follows the normal colony-loss rules.

### What the numbers mean

Every strain shares the same Production Rate cap: **2.0 by default**. A strain's starting stat range only decides its initial roll; it does not limit how far you can breed it.

**Strain Yield is separate.** The reactor multiplies Production Rate by Strain Yield, colony size and the machine's speed factors. A strain with 0.12 Strain Yield can still reach 2.0 Production Rate, but produces 12% as fast as a yield-1 strain with the same colony stats and reactor setup. See [Production Rates](production_rates.md) for the full calculation.

Without serum protection, Production Rate rolls equally toward an increase or a decrease, by up to roughly 10% divided by (1 + Mutation Resistance) each time. Higher resistance makes those changes smaller. It also makes replication more faithful, reaching perfect copies at the resistance cap, but lowers the Mutator's success chance.

The Colony Replicator's splicing mode can combine good stats from two parents. It cannot raise a stat above the better parent's value, so use mutation or refinement to reach new highs.

***

## <Color id="gold">Booster</Color>

The slot to the right of the catalyst takes Electrolyte Algae Serum Vials. While it holds one, every attempt is three times as likely to succeed, whether it mutates or refines, and a failed attempt does not shrink the colony. A vial is only used up when an attempt succeeds, so each new colony costs one vial however many tries it took. Hoppers and pipes can fill it.

On a successful boosted mutation or refinement, serum also gives **each stat that would decrease a separate 50% chance to keep its parent's value**. Improvements are kept as rolled. Protection does not guarantee an improvement or protect every stat together, so keep a backup template.

Set `mutatorBoostedStatProtectionChance` in `config/nautec-common.toml` to a percentage from 0 to 100. At 0, serum does not protect stats; at 100, a successful boosted result cannot lose stats. This protection does not apply to Colony Replicator copy errors.

***

## <Color id="gold">Recipe</Color>

<Recipe id="nautec:mutator"/>

***

## <Color id="gold">Stronger Beams</Color>

The Mutator needs 10 AP. A stronger beam makes its attempts faster: its speed is the square root of (beam ÷ 10).

| Beam | Speed |
|---|---|
| 10 AP | ×1 (normal) |
| 40 AP | ×2 |
| 90 AP | ×3 |
| 160 AP | ×4 |

Each attempt has the same chance as before, so a faster Mutator simply gets more tries per minute. The 12 seconds per attempt is on a 10 AP beam.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.
