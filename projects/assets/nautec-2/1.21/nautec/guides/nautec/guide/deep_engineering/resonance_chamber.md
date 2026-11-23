---
navigation:
  title: Resonance Chamber
  icon: nautec:resonance_chamber
  position: 1
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:resonance_chamber
---

# <Color id="light_purple">Resonance Chamber</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="resonance_chamber" scale="2"/>
  Stores up a laser beam as charge and crafts when the charge reaches a critical level.
</Column>

The Resonance Chamber turns <ItemLink id="prismarine_crystal_shard"/>s into Resonant Shards, and awakens a Dormant Crystal Seed into a Prismarine Crystal Seed for [Crystal Cultivation](crystal_cultivation.md). It needs a beam of purity 3.0 or higher. It takes beams on its four sides and its top.

***

## <Color id="gold">Charge and Ceiling</Color>

While the incoming beam carries at least 20 AP per tick (`resonancePowerUsage`), the Chamber adds the beam's full power to its charge every tick. Below that, the charge drains away.

The ceiling is how much charge the Chamber can safely hold. It is 2,000 x (1 + purity), so a purity 3.0 beam gives a ceiling of 8,000. The base of 2,000 is `resonanceBaseCeiling` in `config/nautec-common.toml`.

| Charge | What happens |
|---|---|
| Below 90% of the ceiling | Keeps charging |
| 90% to 110% (critical) | Crafts one item if it can, then drops to zero charge |
| Above 110% | Vents |

At a purity of 3.0, critical runs from 7,200 to 8,800 charge. A 40 AP beam gets there in 180 ticks (9 seconds).

***

## <Color id="gold">Crafting</Color>

Put the Prismarine Crystal Shards in before the charge reaches critical. Each time it goes critical, the Chamber uses one shard, puts a Resonant Shard in its output and starts charging again from zero, so a full stack works through on its own.

Right-click with a shard to load it. It only takes items it can craft with, by hand or by automation. Right-click with an empty hand to take the output, or the input when the output is empty. Hoppers and pipes can insert shards and pull Resonant Shards out, for example with a hopper underneath. Every face allows both by default; [Side Configuration](nautec:getting_started/utilities.md) changes that.

Look at it through a <ItemLink id="prism_monocle"/> to see the charge as a percentage of the ceiling, the ceiling itself and the beam purity. The charge turns gold while it is critical.

***

## <Color id="gold">Venting</Color>

If the charge passes 110% of the ceiling, the Chamber vents. Every living thing within 4 blocks takes 8 damage, and the Chamber is cracked for 10 seconds, with no charge and no crafting. It does not break.

It vents when it reaches critical and cannot craft, which happens when:

* the input slot is empty
* the beam purity is below 3.0
* the output slot is full

Keep the output emptied, or put a hopper under it, and switch the beam off when you run out of shards. Beam strength is safe: charge rising from below 90% stops at 100% of the ceiling on the tick it enters the critical window, however strong the beam.

Vent damage, radius and cooldown are `resonanceVentDamage`, `resonanceVentRadius` and `resonanceVentCooldown` in `config/nautec-common.toml`.

***

## <Color id="gold">Getting Purity 3.0</Color>

A <ItemLink id="prismarine_crystal"/> hit from the side emits 3.0. Point it straight at the Chamber, or carry the beam there through Prismarine Laser Relays and Laser Junctions, which keep purity unchanged. A [Focusing Lens](beam_optics.md) only raises purity up to 2.0, so it does not help here.

***

### <Color id="aqua">Resonance Chamber Recipe</Color>

<Recipe id="nautec:resonance_chamber"/>

***

## <Color id="gold">Stronger Beams</Color>

The Resonance Chamber already adds the beam's full power to its charge every tick, so a stronger beam charges it faster in direct proportion: twice the beam, twice as fast. It does not use the square root rule the other machines follow.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.
