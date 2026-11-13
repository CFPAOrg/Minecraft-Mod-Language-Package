---
navigation:
  title: Wave Jet
  icon: nautec:wave_jet
  position: 5
  parent: submarine/submarine-index.md
item_ids:
  - nautec:wave_jet
---

# <Color id="light_purple">Wave Jet</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="wave_jet" scale="2"/>
  A handheld underwater thruster.
</Column>

The Wave Jet pulls you through water wherever you look while you hold use, and carries a spotlight.

***

## <Color id="gold">Driving It</Color>

Get into water, hold the Wave Jet and hold use (right mouse). It pulls you along in a swimming pose toward wherever you are looking, and within a second settles at about twice your swimming speed. Let go to stop. The thrust and top speed are configurable (`waveJetThrust`, `waveJetMaxSpeed`).

It works anywhere you are in water. Leave the water or run the cell dry and it stops pulling, and you carry on swimming or walking as normal.

***

## <Color id="gold">Surface Skimming</Color>

With your head above the surface, the jet only pushes level or downward. Look ahead and it runs you along the top of the water instead of launching you out of it. Look down to dive, and once you are under it pushes in every direction again.

***

## <Color id="gold">Both Hands</Color>

The Wave Jet has two grips, so the other hand has to stay empty. It works from either hand. Put anything in your free hand and the Wave Jet moves to an empty slot in your inventory, or drops at your feet if there is no room, with the message "The Wave Jet takes both hands".

***

## <Color id="gold">Holding Your Breath</Color>

While you are thrusting, your air bar stops draining. It picks up again the moment you let go. It keeps the air you have rather than refilling it, so set off with a full bar. For long dives, wear a [Diving Suit](nautec:getting_started/diving_gear.md).

***

## <Color id="gold">The Spotlight</Color>

Press F while holding it to switch the lamps on or off. They throw a cone of light up to 12 blocks ahead of wherever you look and light the block they reach with light level 14, so the area really is lit, not only the beam. The spotlight works in or out of water, goes out when you put the Wave Jet away, and comes back on when you hold it again.

F is its own key binding, Toggle Wave Jet Spotlight. While you hold the Wave Jet it replaces the vanilla hand swap on F. Rebind the spotlight to another key to keep hand swapping. Range, brightness and power use are configurable, and a brightness of 0 keeps the visible cone without lighting the world.

***

## <Color id="gold">Power</Color>

| | Power per tick | A full cell lasts |
|---|---|---|
| Thrusting | 2 | 2.5 minutes |
| Spotlight lit | 1 | 5 minutes |

The cell holds 6,000. The bar under the item shows what is left, and the spotlight switches itself off when the cell is empty. Charge it in a <ItemLink id="charger"/>. It takes whatever the Charger's beam delivers, up to 128 AP per tick, so a 12 AP beam fills it from empty in about 25 seconds and a stronger one in a few. Players in creative mode use no power.

***

### <Color id="aqua">Wave Jet Recipe</Color>

<Recipe id="nautec:wave_jet"/>
