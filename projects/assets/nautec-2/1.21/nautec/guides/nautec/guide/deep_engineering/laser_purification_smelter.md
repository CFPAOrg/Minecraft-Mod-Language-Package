---
navigation:
  title: Laser Purification Smelter
  icon: nautec:laser_purification_smelter
  position: 13
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:laser_purification_smelter
---

# <Color id="light_purple">Laser Purification Smelter</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="laser_purification_smelter" scale="2"/>
  Smelts up to nine stacks side by side on a laser beam instead of fuel.
</Column>

The Laser Purification Smelter cooks anything a vanilla furnace can, and its input slots only take items that a furnace can smelt. It has nine input slots, each paired with its own output slot, and a slot for a conduit upgrade. The upgrade decides how many slots are open and how fast the whole smelter works. A purer beam makes it cheaper to run.

***

## <Color id="gold">Power</Color>

The smelter takes beams on its top and on the three sides that are not its front. It needs no fuel.

Each tick it is working, it needs this much AP:

**busy slots × the upgrade's AP per slot ÷ the beam's purity**, rounded up.

A busy slot is an open slot holding something it can smelt, with room in its output. Empty slots, locked slots and slots with a full output cost nothing, and an idle smelter needs no beam at all.

* A beam weaker than the cost stops it. It holds its place and carries on when the beam is strong enough again.
* A beam stronger than the cost does not make it any faster. Only the upgrade sets the speed.
* Purity above 1.0 divides the cost. A purity 2.0 beam halves it. Purity is never required, and a beam below 1.0 is treated as 1.0, so it gives no discount and costs no extra.

***

## <Color id="gold">Upgrades and Speed</Color>

Put one <ItemLink id="eddy_upgrade"/>, <ItemLink id="surge_upgrade"/>, <ItemLink id="riptide_upgrade"/> or <ItemLink id="maelstrom_upgrade"/> in the upgrade slot. These are the same upgrades a [Current Conduit](current_conduits.md) tap uses.

| Upgrade | Open slots | Smelts | AP per busy slot |
|---|---|---|---|
| None | 1 | 8 items every 20 ticks | 1 |
| Eddy | 3 | 16 items every 10 ticks | 2 |
| Surge | 5 | 32 items every 5 ticks | 4 |
| Riptide | 7 | 64 items every 2 ticks | 8 |
| Maelstrom | 9 | 64 items every tick | 16 |

The speed is for the whole smelter, not for each slot. At the end of each interval it smelts one item from each busy slot in turn, then goes round again, until it has smelted that many items or runs out of work. So a Maelstrom smelter with all nine slots busy smelts about 7 items from each slot every tick, on 144 AP at purity 1.0 or 72 AP at purity 2.0.

Each item goes to the output slot paired with its input slot. An output only takes more of the same item, and only when the whole result fits, so a full output stops just its own slot.

***

## <Color id="gold">Locked Slots</Color>

Slots past the number the upgrade opens are locked and drawn with a padlock. Hover one to see which upgrade opens it. A locked input slot takes nothing from you or from automation.

If you take out an upgrade while locked slots hold items, the items stay where they are. They are not smelted until the slot opens again, but you can still take them out.

***

## <Color id="gold">Auto-Distribute</Color>

The Auto button between the two grids turns auto-distribute on and off. When it is on, the smelter spreads its input items evenly over the open input slots every half second, so every slot smelts at once.

* One kind of item is split as evenly as it can be. 10 Cobblestone over 3 open slots becomes 4, 3 and 3.
* Several kinds share the open slots in proportion to how many of each there are. Every kind keeps at least one slot, and each kind is then spread evenly over its own slots.
* Nothing is ever lost or added, and no slot goes over its stack size. Items in locked slots are left alone.

It is off on a new smelter. A <ItemLink id="configuration_card"/> copies the setting, along with the fitted upgrade, onto another smelter.

***

## <Color id="gold">Using It</Color>

Right-click it with an empty hand to open it. The input grid is on the left and the output grid on the right, with a progress arrow between them showing how far it is through the current interval. The panel below shows:

* the beam it is getting against what it needs right now
* the beam's purity and the discount it gives
* how many items it smelts per interval with the fitted upgrade
* how many slots are open

Its status is shown beside the Inventory label: Smelting, Waiting for beam, Outputs full or Idle. Hover a line in the panel for more detail. Click the arrow to see every smelting recipe in JEI.

Hoppers and pipes can put items into the input slots and take them from the output slots, through any face by default. [Side Configuration](nautec:getting_started/utilities.md) sets each face separately. Automation never reaches the upgrade slot. Breaking the smelter drops everything inside it, upgrade included.

The smelter does not give experience.

***

## <Color id="gold">For Pack Makers</Color>

In `config/nautec-common.toml`, `smelterSlots` lists the open slots for no upgrade, Eddy, Surge, Riptide and Maelstrom (default 1, 3, 5, 7, 9), and `smelterApMultipliers` lists the AP per busy slot in the same order (default 1, 2, 4, 8, 16). The speed follows the Conduit Tap item settings (`conduitItemIntervalBase` to `conduitItemIntervalMaelstrom` and `conduitItemsPerOpBase` to `conduitItemsPerOpMaelstrom`), so changing those changes both.

***

### <Color id="aqua">Laser Purification Smelter Recipe</Color>

<Recipe id="nautec:laser_purification_smelter"/>
