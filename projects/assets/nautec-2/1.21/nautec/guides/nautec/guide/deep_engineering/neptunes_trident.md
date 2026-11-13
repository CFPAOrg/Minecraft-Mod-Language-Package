---
navigation:
  title: Neptune's Trident
  icon: nautec:neptunes_trident
  position: 6
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:neptunes_trident
---

# <Color id="light_purple">Neptune's Trident</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="neptunes_trident" scale="2"/>
  An unbreakable trident that returns to you and releases a tidal shockwave where it hits.
</Column>

Neptune's Trident works like a vanilla trident with higher damage. It never breaks, and it always flies back to you at the speed of Loyalty III. Hold use and let go to throw it; attack with it to use it in melee.

***

## <Color id="gold">Damage</Color>

| Attack | Damage |
|---|---|
| Thrown | 18 |
| Melee | 19 (attack speed 1.2) |
| Riptide spin | 18 |

Melee swings sweep like a sword, hitting creatures next to your target.

***

## <Color id="gold">Tidal Shockwave</Color>

The first thing a thrown trident hits, a creature or a block, releases a tidal shockwave there. A lightning strike shows where it went off; that strike is only visual and starts no fires.

* It hits everything within 5 blocks for 14 damage at the centre, falling to 7 at the edge, and knocks them away from the centre.
* Each level of Sharpness adds 3 damage. Each level of Knockback adds to the push.
* It does not hit you, your tamed pets, your teammates, or players in creative or spectator mode.
* After a shockwave, the trident needs 3 seconds before it can release another. You can keep throwing it during that time; those throws just hit without a shockwave. The trident's inventory slot shows the time left.

Radius, damage, the per-level bonuses and the cooldown are in `config/nautec-common.toml` (`tridentShockwaveRadius`, `tridentShockwaveDamage`, `tridentShockwaveDamagePerSharpness`, `tridentShockwaveKnockback`, `tridentShockwaveKnockbackPerLevel`, `tridentShockwaveCooldown`).

***

## <Color id="gold">Enchantments</Color>

It takes the trident enchantments and the sword ones:

* Impaling, Riptide and Channeling
* Sharpness, Smite, Bane of Arthropods, Knockback, Fire Aspect, Looting and Sweeping Edge
* Curse of Vanishing

Loyalty is already built in, and it never needs Unbreaking or Mending. As on any trident, only one of Sharpness, Smite, Bane of Arthropods and Impaling can go on it. Sharpness is the one that also raises shockwave damage. Riptide and Channeling cannot go on together.

With Riptide, using it in water or rain launches you instead of throwing it, so a Riptide trident releases no shockwave. Channeling calls a real lightning bolt on a target under open sky during a thunderstorm, the same as a vanilla trident.

Its enchantability is very low, so use books on an anvil rather than an enchanting table.

***

## <Color id="gold">Getting One</Color>

The recipe uses materials from the [Resonance Chamber](resonance_chamber.md) and the [Abyssal Pressure Forge](pressure_forge.md), so get both running first. See [Deep Materials](materials.md).

<Recipe id="nautec:neptunes_trident"/>
