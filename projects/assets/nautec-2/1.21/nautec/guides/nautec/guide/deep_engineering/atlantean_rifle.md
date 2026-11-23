---
navigation:
  title: Atlantean Rifle
  icon: nautec:atlantean_rifle
  position: 5
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:atlantean_rifle
---

# <Color id="light_purple">Atlantean Rifle</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="atlantean_rifle" scale="2"/>
  A powered weapon that fires a continuous particle beam while you hold use.
</Column>

Hold use to spin the rifle up for half a second, then it fires a beam at whatever you are aiming at. The beam hits every 2 ticks for as long as you hold, and gets stronger the longer you keep firing. It runs on stored AP and does nothing while empty.

***

## <Color id="gold">Damage and Power</Color>

Over the first 10 seconds of continuous fire, the damage and the power drain both climb from their starting values to their maximum. Letting go resets both.

| | At first | After 10 seconds |
|---|---|---|
| Damage per hit | 4 | 20 |
| Damage per second | 40 | 200 |
| AP per hit | 125 | 625 |
| AP per second | 1,250 | 6,250 |

* Each hit ignores the target's damage cooldown, so every hit counts.
* The beam reaches 128 blocks. It passes through water, stops at the first solid block, and hits the first creature in its line.
* A full rifle lasts about 164 seconds (2 minutes 45) of continuous fire. Short bursts stay at the cheap end of the ramp and last longer overall.
* If the rifle does not have enough AP for the first hit, it shows "The Atlantean Rifle has no charge" and does not fire. It stops firing when it runs out.

Every value in this table, the spin-up time and the range are in `config/nautec-common.toml` (`rifleBaseDamage`, `rifleMaxDamage`, `rifleBaseDrain`, `rifleMaxDrain`, `rifleRampTicks`, `rifleChargeTicks`, `rifleRange`).

***

## <Color id="gold">Charging</Color>

The rifle holds 1,000,000 AP (`riflePowerCapacity`) and comes out of the crafting table empty. The bar under it shows its charge, and the tooltip shows the exact amount.

* A <ItemLink id="charger"/> charges it with whatever power its beam delivers each tick, up to 20,000 AP per tick (`rifleMaxInput`). A stronger beam into the Charger fills it faster.
* A <ItemLink id="prismatic_battery"/> worn in its Curios slot with its ability switched on feeds it from the battery's own store, up to 100 AP per tick.

***

## <Color id="gold">Enchantments</Color>

The rifle takes Infinity and curses, nothing else. Infinity halves the power drain, so a full rifle lasts about 324 seconds (5 and a half minutes) of continuous fire. Its enchantability is very low, so use a book on an anvil rather than an enchanting table.

With Apotheosis installed, the rifle counts as a bow for affixes and gems, and the bow stats apply to the beam:

* Draw speed shortens the charge before the beam fires. +50% draw speed charges it in two thirds of the time.
* Arrow velocity and arrow damage multiply the beam's damage. +50% arrow velocity is 1.5 times the damage.
* Protection pierce and shred ignore some of the target's Protection, and armor pierce and shred ignore some of its armor, scaling with the gem.
* Critical strike chance and damage apply to the beam as they do to any attack.

***

## <Color id="gold">Getting One</Color>

The recipe uses materials from the [Abyssal Pressure Forge](pressure_forge.md), so get one running first. See [Deep Materials](materials.md).

<Recipe id="nautec:atlantean_rifle"/>
