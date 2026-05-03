---
navigation:
  parent: crazyae2addons_index.md
  title: Portable Spatial Tools
  icon: crazyae2addons:portable_spatial_storage
categories:
  - Portable Spatial Tools
item_ids:
  - crazyae2addons:portable_spatial_storage
  - crazyae2addons:portable_spatial_cloner
---

# Portable Spatial Tools

**Portable Spatial Storage** and **Portable Spatial Cloner** are hand-held tools for storing structures from the world and placing them somewhere else.

Portable Spatial Storage cuts the selected region out of the world.

Portable Spatial Cloner copies the selected region and leaves the original untouched.

Both tools support transforms, positional offset and ghost preview.

---

## Mod compatibility

Portable Spatial Tools use extension hooks for special block capture and paste behavior.

Built-in integrations preserve AE2 cable buses and parts.

Built-in integrations also preserve GTCEu machine configuration.

Built-in integrations also preserve framed blocks configuration.

Blocks without a special extension use normal block clone behavior and may not preserve all block entity data.

---

## Selection 

Both tools use a two-corner selection.

Shift-right-clicking blocks cycles the selection state:

* first selected block becomes Corner A
* second selected block becomes Corner B
* selecting again resets the selection

You can preview the selection live in world.

Corner B is also used as the energy origin for cost calculation.

---

## Air selection

After Corner A is selected, right-clicking in the air can select Corner B by raycast.

The raycast checks up to 50 blocks in the direction the player is looking.

If no block is found, the selection is not completed.

---

## Capture invariant

Capturing stores only blocks. Entities are not captured and air is stripped from the stored structure.

The structure is saved in server data and the item stores a reference to it. 

---

## Storage vs Cloner capture

Portable Spatial Storage removes the captured blocks from the world after the structure is saved.

Portable Spatial Cloner does not remove the original blocks.

---

## Energy cost

Capture and paste both cost energy. Blocks farther from Corner B cost more energy.

---

## Ghost preview

After a structure is stored, you will see a ghost preview of the structure.

---

## Portable Spatial Storage paste invariant

Portable Spatial Storage pastes all-or-nothing.

Before placing anything, it checks the full target region for collisions.

Air and replaceable blocks are allowed.

Any other collision cancels the entire paste.

When paste is canceled, nothing is placed and no energy is consumed.

On successful paste, the stored structure is removed from server storage and the item becomes empty again.

Cloning the item will not clone the structure!

---

## Portable Spatial Cloner paste invariant

Portable Spatial Cloner pastes best-effort.

Each block is placed independently.

A block can be skipped if the target position is blocked or a required material is missing.

After paste, the HUD shows how many blocks were placed and how many were skipped.

If no blocks are placed, the paste is treated as failed.

---

## Material requirements

Portable Spatial Cloner tracks the items required to paste the stored structure.

The GUI shows required count and available count.

Availability checks the player inventory and, if linked, ME storage.

Creative mode skips material consumption.

---

## Crafting Card

Portable Spatial Cloner can use a Crafting Card.

With the card installed, craftable materials in the GUI get a craft button.

The button opens the normal AE2 crafting amount screen for that item.

The Crafting Card does not autocraft during paste. It only enables manual crafting from the material list.

---

## Transforms

The GUI can rotate and mirror the stored structure.

Shift clicking buttons keep the origin fixed, otherwise it transform the structure in place.

---

## Energy Cards

Both tools accept up to 4 Energy Cards.

Energy Cards increase internal energy capacity and charging speed.

---
