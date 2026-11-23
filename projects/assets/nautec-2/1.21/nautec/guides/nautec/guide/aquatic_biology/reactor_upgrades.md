---
navigation:
  title: Reactor Upgrades
  icon: nautec:reactor_speed_upgrade
  position: 11
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:reactor_speed_upgrade
  - nautec:reactor_yield_upgrade
  - nautec:reactor_efficiency_upgrade
  - nautec:reactor_fusion_upgrade
---

# <Color id="light_purple">Reactor Upgrades</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="reactor_speed_upgrade" scale="2"/>
  Upgrades make a reactor produce more or eat less, in exchange for a higher power draw.
</Column>

The [Bio Reactor](bio_reactor.md) has 2 upgrade slots and the [Industrial Bio Reactor](industrial_bio_reactor.md) has 4. Each slot holds one upgrade, you can mix types freely, and two of the same type count twice. Upgrades affect every colony in the reactor. Hoppers and pipes can insert them too; they only ever go into upgrade slots.

Each upgrade's tooltip shows its effect and power multiplier with the current config values.

***

## <Color id="gold">The Upgrades</Color>

<Row>
  <ItemImage id="reactor_speed_upgrade"/>
  ### <Color id="aqua">Reactor Speed Upgrade</Color>
</Row>

Adds 50% production speed per upgrade: one gives 1.5 times the speed, two give 2 times, four give 3 times. Multiplies the power draw by 1.6.

<Row>
  <ItemImage id="reactor_yield_upgrade"/>
  ### <Color id="aqua">Reactor Yield Upgrade</Color>
</Row>

Adds one item to every completed cycle: one upgrade gives 2 items per cycle, two give 3, four give 5. Multiplies the power draw by 1.8. The colony's output slot needs room for the whole batch before a cycle can finish.

<Row>
  <ItemImage id="reactor_efficiency_upgrade"/>
  ### <Color id="aqua">Reactor Efficiency Upgrade</Color>
</Row>

Each colony spends 25% less of its [nutrient buffer](colony_feeding.md) per tick for each upgrade, and the reductions multiply: one leaves 75%, two 56%, three 42%, four 32%. A nutrient worth 1,200 ticks then lasts 80 seconds of work with one upgrade, 107 with two and 190 with four. It never goes below the floor of 25% (configurable), which four upgrades at the default values do not reach. Multiplies the power draw by 1.2. It changes nothing about how fast items come out.

Speed and Yield Upgrades both cut the nutrients spent per item, because nutrients are spent per tick of work, not per item. For output per AP, a Yield Upgrade (twice the items for 1.8 times the power) beats a Speed Upgrade (1.5 times the items for 1.6 times the power).

<Row>
  <ItemImage id="reactor_fusion_upgrade"/>
  ### <Color id="aqua">Reactor Fusion Upgrade</Color>
</Row>

Made from one of each of the other three. It counts as one Speed, one Yield and one Efficiency Upgrade, all in a single slot, and stacks with them and with other Fusion Upgrades. Multiplies the power draw by 2.5, less than the 3.46 the three separate upgrades would cost together.

It is for a reactor whose slots are already full. Four Fusion Upgrades in an Industrial Bio Reactor give 3 times the speed, 5 items per cycle and 32% nutrient use, for about 39 times the base power.

***

## <Color id="gold">Power Math</Color>

AP needed = (base + per colony x filled colony slots) x 1.6 per Speed Upgrade x 1.8 per Yield Upgrade x 1.2 per Efficiency Upgrade x 2.5 per Fusion Upgrade, rounded up

Every upgrade multiplies the whole total again, so the cost climbs fast. The base and per-colony values are on the [Production Rates](production_rates.md) page.

A Bio Reactor with 3 colonies:

| Upgrades | AP needed |
|---|---|
| none | 50 |
| 1 Speed | 80 |
| 2 Speed | 128 |
| 1 Yield | 90 |
| 2 Yield | 162 |
| 1 Speed, 1 Yield | 144 |
| 1 Yield, 1 Efficiency | 108 |
| 2 Efficiency | 72 |
| 1 Fusion | 125 |
| 1 Fusion, 1 Yield | 225 |
| 2 Fusion | 313 |

An Industrial Bio Reactor with 9 colonies:

| Upgrades | AP needed |
|---|---|
| none | 550 |
| 4 Efficiency | 1,141 |
| 2 Yield, 2 Efficiency | 2,567 |
| 4 Speed | 3,605 |
| 2 Speed, 2 Yield | 4,562 |
| 4 Yield | 5,774 |
| 1 Fusion | 1,375 |
| 2 Fusion | 3,438 |
| 2 Fusion, 2 Yield | 11,138 |
| 4 Fusion | 21,485 |

Every bonus and multiplier on this page is configurable.

***

## <Color id="gold">Recipes</Color>

The ingredients are covered on the [Deep Materials](nautec:deep_engineering/materials.md) page.

***

## <Color id="gold">Stronger Beams</Color>

A stronger beam than a reactor needs speeds it up on top of its Speed Upgrades, and the two multiply. Every upgrade that raises the power draw also raises the beam a reactor needs before it speeds up, so the beam speed is always measured against the reactor as upgraded.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.

<RecipeFor id="reactor_speed_upgrade"/>

<RecipeFor id="reactor_yield_upgrade"/>

<RecipeFor id="reactor_efficiency_upgrade"/>

<RecipeFor id="reactor_fusion_upgrade"/>
