---
id: meatgun
lookup: meatweapons:basic_pistol, meatweapons:meatgun_pistol
---

# Meatgun

*What do you call a gun that is a gun but also primarily consists of or relates to meat?*

Meatgun is a modular tool and weapon system. 

Creating a Meatgun starts by taking a base module and installing other moules using a Tinker Table. Each module has a number of slots that can accept further modules. Modules have a complexity requirement.

# Keybinds

Meatguns have two triggers: Primary and Secondary. These can be rebound in settings. Unlike normal key binds, these can be bound to the same keys as Use and Attack and still function normally.

If one of the trigger keybinds is bound to the Use key, the currently held Meatgun will override the Use action. Pressing R will trigger the normal Use action.

Holding sneak allows aiming down sights. This only works when the Meatgun is held in the main hand.

## Dual Wielding

When a Meatgun is present in both hands, the Secondary trigger will be redirected to the item in the offhand, rather than the main hand.

## Ammunition

There are three main types of ammunition:

- Ballistic
- Energy
- Metabolic

Modules that use ammunition can also store a quantity of it, but can also use ammunition of the same type stored in other modules. 

For example, a pistol has a capacity of 80 ballistic units. A Meatgun with two pistols will have the  160 ballistic units.

# Base Modules

## Raw Gun

Made from scavenged meats. Similar to a pistol base, but supports only half the complexity. Comes with a pistol module preattached, so no tinker table is needed. The Raw Gun also contains a Bullet Fabricator, which allows it to passively produce ammunition from food it is fed.

## Pistol Base

A lightweight base module with a pistol grip.

## Staff

*A wizard's staff as a knob on the end.* 

Best used with melee modules such as the Halberd or Shock Staff.

### Drill Chassis

The only base module that can support drill heads.

# Core Implants

Meatguns can have implants as well as modules. These work in the same way as other entity or item implants. They can be installed with a PLC using the `COMBINE` instruction.

## Ammunition Fabricator

Gradually consumes metabolic substrate to produce ammunition. Every 2s, the organ consumes 1 unit of metabolic substrate and produces 1 unit of an ammunition type that the item supports.

Meatgun items can be filled with metabolic substrate by right-clicking (pressing R) on a tank, or clicking the item with a food item in an inventory.

The accepted metabolic substrates are the same as those used by the Tool Organism:

- Animal Feed
- Meat
- Liquid Food (amount depends on hunger)

The Raw Gun contains this implant by default, but it can be extracted with the Tinker Table or an Implant Manager.