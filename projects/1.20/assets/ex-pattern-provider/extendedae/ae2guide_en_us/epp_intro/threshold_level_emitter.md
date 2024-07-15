---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME Threshold Level Emitter
    icon: extendedae:threshold_level_emitter
categories:
- extended devices
item_ids:
- extendedae:threshold_level_emitter
---

# ME Threshold Level Emitter

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/cable_threshold_level_emitter.snbt"></ImportStructure>
</GameScene>

It works like Reset-Set Latch. It turns off redstone signal when the quantity of an item in network is less than
the lower threshold and turn on when the quantity is greater than the upper threshold.

For example, given lower threshold is set 100 and upper threshold is set 150.

At first the network is empty, so the emitter won't be active.

As the quantity of the item growing up and over 150, the emitter will send redstone signal.

When the quantity declining and less than 150, the emitter still sends signal.

At last the quantity is less than 100, the emitter will be turned off.
