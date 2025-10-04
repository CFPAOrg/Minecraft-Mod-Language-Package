---
navigation:
  parent: crazyae2addons_index.md
  title: Pattern Management Unit
  icon: crazyae2addons:pattern_management_unit
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:pattern_management_unit
  - crazyae2addons:pattern_management_unit_frame
  - crazyae2addons:pattern_management_unit_wall
  - crazyae2addons:pattern_management_unit_controller
---

# Pattern Management Unit Controller

<GameScene zoom="2" interactive={true}>
  <ImportStructure src="../assets/unit.nbt" />
</GameScene>

The **Pattern Management Unit Controller** is a special block that stores large numbers of
**Encoded Crafting Patterns** in one place and shares them with your network.

## How it works

* Any **Encoded Crafting Pattern** placed inside the Unit is automatically made available to **all Pattern Providers** connected to the same ME Network.
* It only works with **Crafting Patterns** - processing patterns are not supported.
* You don’t need to copy or move patterns between Providers: as long as they are in the Unit, every Provider can use them for autocrafting.
* Parallelizes all your pattern providers for crafting operations.

## Using the Interface

* Open the Controller to see its pattern storage grid.
* Insert or remove Encoded Crafting Patterns just like in a normal Pattern Provider.
* Use the **scrollbar** to move through rows when you have more patterns than fit on the screen.
* A **Preview button** lets you toggle preview mode.

## Benefits

* Centralize your patterns in one storage block.
* Expand your crafting system without cluttering each Pattern Provider.
* Easily manage hundreds of patterns while keeping your network clean.
* Parallelize your auto crafting easily.

## Notes

* Only **Encoded Crafting Patterns** can be placed inside. Other items are not accepted.
* If the Unit is not part of a valid multiblock structure, its patterns will not be available to the network.
