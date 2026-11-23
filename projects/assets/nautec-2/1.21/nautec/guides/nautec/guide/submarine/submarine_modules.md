---
navigation:
  title: Modules
  icon: nautec:aquatic_chip
  position: 6
  parent: submarine/submarine-index.md
---

# <Color id="light_purple">Modules</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="aquatic_chip" scale="2"/>
  Nine slots of upgrades.
</Column>

Modules are items you install in the Sea Scout's module bay to give it new abilities, fired from a bar that replaces your hotbar while you pilot.

***

## <Color id="gold">The Module Bay</Color>

Stand outside the hull, without sneaking, and right-click it with an <ItemLink id="aquarine_steel_wrench"/> (any wrench works) to open the bay: nine slots, one module in each. Only modules go in. Sneak and right-click picks the hull up instead.

Modules stay installed when you pick the hull up, and the item's tooltip lists them.

***

## <Color id="gold">Firing</Color>

While you pilot, the nine bay slots appear at the bottom of the screen in place of your hotbar, with the selected module's name above them. Pick a slot with the number keys or the mouse wheel, then left-click or press F to fire it.

* A passive module shows a pale strip along the bottom of its slot and works from any slot without being fired.
* A Booster or Stealth Module that is running shows a bright strip along the bottom of its slot.
* A module that is recharging fills its slot with a dark sweep that shrinks as it gets ready.

If a module cannot fire, the reason appears above the bar: "That module is still cycling", "Not enough power for that module", or a teleport message. A refused module costs nothing.

Cooldowns belong to the module type and start when you fire. Firing one copy of a module puts every copy of it in the bay on cooldown, so a second Booster does not give you a second boost. A hull picked up mid-cooldown keeps the time it had left, and the count carries on once you launch it again. Passive modules do not stack: a second Solar, Armour or Flight Module adds nothing.

***

## <Color id="gold">All Modules</Color>

| Module | Kind | Power | Cooldown |
|---|---|---|---|
| [Solar](solar_module.md) | Passive | Generates 2,000 every 5 s | None |
| [Armour](armor_module.md) | Passive | None | None |
| [Booster](booster_module.md) | 10 s of speed | 20,000 | 13 s |
| [Stealth](stealth_module.md) | 2 min of stealth | 50,000 | 130 s |
| [Sonar](sonar_module.md) | One ping | 30,000 | 45 s |
| [Shield](shield_module.md) | Passive soak and a discharge | 10,000 per heart soaked, 25,000 per discharge | 5 s |
| [Impulse Laser](impulse_laser_module.md) | Fires while held | 400 a tick, rising to 1,400 a tick | None |
| [Teleport](teleport_module.md) | Jump to an anchor | 200,000 | 30 s |
| [Flight](flight_module.md) | Passive | 4 per tick while airborne | None |
| [Cargo Hold](cargo_module.md) | Opens the hold | None | None |

For the Booster and Stealth Modules the cooldown includes the time the effect runs. Each module's tooltip shows its power per use and its cooldown, and every figure here is configurable.
