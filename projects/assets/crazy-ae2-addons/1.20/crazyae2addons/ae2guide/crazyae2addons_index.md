---
navigation:
  title: Crazy AE2 Addons
  position: 120
---

# Crazy AE2 Addons

Crazy AE2 Addons expands Applied Energistics 2
with advanced automation, monitoring, redstone control, crafting utilities,
network tools, and portable spatial storage devices.

Most blocks and parts are designed to work as part of an existing ME network.

---

## Need help?

Join the [Discord server](https://discord.com/invite/mWy8AVRtwz)

---

## Feature Index

--- 

### Portable Spatial Tools

Portable tools for copying, moving, previewing, and placing structures directly
in the world.

- [Portable Spatial Storage](crazyguide/portable_spatial_devices.md)  
  An item that cuts a rectangular block area from the world, stores it, and
  places it elsewhere with support for rotations, transformations and ghost preview.

- [Portable Spatial Cloner](crazyguide/portable_spatial_devices.md)  
  A variant of Portable Spatial Storage that copies structures without removing
  the original. It can show required materials and craft missing items from its
  GUI.

---

### Monitoring, Displays and Alerts

Tools for visualizing ME network data, tracking stock levels, and showing alerts in the world or HUD.

- [Display](crazyguide/display.md)  
  A cable mounted part for showing text, images, and AE2 network data. Supports
  tokens, colors, and merge mode for building large screens.

- [Wireless Notification Terminal](crazyguide/notification_terminal.md)  
  A wireless terminal that monitors up to 16 items (configurable) and displays colored HUD
  alerts when their stored amount goes below/above the configured threshold.

---

### Emitters and Redstone Control

Parts, and terminals for controlling redstone signals from ME network
state, item levels, tag expressions, or manual remote toggles.

- [Emitter Terminal](crazyguide/emitter_terminal.md)  
  A terminal for managing all standard ME Level Emitters in a network from one place,
  including threshold and filter editing.

- [Wireless Emitter Terminal](crazyguide/emitter_terminal.md)  
  A wireless version of the Emitter Terminal.

- [Multi Level Emitter](crazyguide/multi_level_emitter.md)  
  A Storage Level Emitter that monitors up to 16 resources (configurable) 
  at once, with AND/OR logic, crafting/fuzzy card capable.

- [Tag Level Emitter](crazyguide/tag_level_emitter.md)  
  A Storage Level Emitter that uses boolean tag expressions instead of specific
  items.

- [Analog Card](crazyguide/analog_card.md)  
  An upgrade for ME Level Emitters and Tag Level Emitters that outputs an analog
  redstone signal proportional to item amount, using either linear or logarithmic
  scaling.

- [Redstone Emitter](crazyguide/redstone_emitter.md)  
  A simple redstone-emitting part controlled remotely by a Redstone Terminal.

- [Redstone Terminal](crazyguide/redstone_terminal.md)  
  A terminal for toggling all Redstone Emitters in the network from one place.

- [Wireless Redstone Terminal](crazyguide/redstone_terminal.md)  
  A wireless version of the Redstone Terminal.

---

### P2P, Transfer and Network Tunnels

Advanced tunnel tools for moving items, fluids, interactions, capabilities, and
even entities across locations or dimensions.

- [Wormhole](crazyguide/wormhole.md)  
  A universal P2P tunnel that transfers capabilities, block interactions, and
  allows teleportation through the tunnel, including across dimensions.

- [Round Robin Item P2P Tunnel](crazyguide/rr_p2p.md)  
  A P2P tunnel that distributes items evenly between all outputs.

- [Round Robin Fluid P2P Tunnel](crazyguide/rr_p2p.md)  
  A P2P tunnel that distributes fluids evenly between all outputs.

---

### Crafting, Patterns and Providers

Utilities for improving autocrafting workflows, modifying encoded patterns, and
expanding pattern storage.

- [CPU Priority Tuner](crazyguide/cpu_priority_tuner.md)  
  An item used to set Crafting CPU priority, controlling which CPUs perform
  crafting jobs first.

- [Pattern Multiplier](crazyguide/pattern_multiplier.md)  
  An item that multiplies encoded pattern inputs and outputs by a chosen factor.
  Can multiply patterns inside of containers too.

- [Crazy Pattern Provider](crazyguide/crazy_pattern_provider.md)  
  An expandable Pattern Provider available as a block or part, starts with 72
  pattern slots and allows upgrade-based expansion.

- [Ejector](crazyguide/ejector.md)  
  A block that automatically crafts configured items and ejects them into an
  adjacent inventory.

---

### Tag Filtering

Tools for filtering terminals and automation logic using tag expressions instead
of individual item selections.

- [Tag View Cell](crazyguide/tag_view_cell.md)  
  A View Cell that filters ME Terminal contents using boolean tag expressions.

---

### Fabrication

Custom processing machines for recipes that do not fit standard crafting or
processing patterns.

- [Recipe Fabricator](crazyguide/recipe_fabricator.md)  
  A block that processes ingredients using custom fabrication recipes, with
  optional fluid input/output and automatic product ejecting.

---