---
navigation:
  parent: crazyae2addons_index.md
  title: Wormhole
  icon: crazyae2addons:wormhole
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:wormhole
---

# Wormhole

The **Wormhole** is a universal P2P tunnel. Instead of carrying one resource type it hands the block on one
side over to the other side whole, with whatever capabilities that block has.

---

## Pairing

Pairing works like any AE2 P2P tunnel. Right-click the input with a Memory Card, then right-click every
output with the same card. Both sides need to be on the same network.

The card only accepts Wormhole settings. A card holding a normal P2P configuration is refused, and a Wormhole
card does nothing on a normal tunnel.

---

## Capability proxy

Whatever block sits in front of one Wormhole becomes visible through the tunnel on the other end. Pipes,
cables, and machines connected to the near side talk to the far block as if it were standing right there.

This works both ways. The input serves what the outputs face, and each output serves what the input faces.

Which capability types pass through is a config choice. By default items, fluids, Forge Energy, GregTech EU,
and other Forge capabilities such as Mekanism heat all go through, and each of those can be turned off on its
own.

---

## Multiple outputs

An input can have several outputs, and by default it merges them. Several inventories look like one big
inventory, several tanks look like one tank, several energy buffers look like one buffer.

The tunnel never splits one insertion between outputs. It fills what it can reach in order, and it merges
freely in the other direction, from many outputs back into the input.

With merged proxying turned off in the config, the input stops merging and simply serves the first output
that offers the capability.

---

## Remote interactions

Right-clicking a paired Wormhole runs that click on the block the far side faces, with whatever you are
holding. That opens remote GUIs, and it flips buttons, levers, doors, and machines. A Memory Card and an
Ender Pearl are the two exceptions, since those do their own thing on a Wormhole.

While a remote GUI is open, the distance check follows the far block instead of you, so the screen stays open
even if you walk away or step into another dimension. It closes when you close it.

The far side has to be in a ticking chunk. Nothing happens if it is not loaded.

This can be turned off in the config.

---

## Teleportation

Right-clicking a paired Wormhole while holding an Ender Pearl puts you at the block the other side faces,
looking away from it.

The pearl is consumed unless you are in Creative. Other dimensions are fine, again as long as the target
chunk is loaded and ticking.

This can be turned off in the config.

---

## Nested tunnels

Routing other P2P tunnels through a Wormhole is turned off by default.

While it is off the Wormhole refuses to carry another tunnel's channels, the same way a vanilla ME P2P tunnel
does. Turning it on lifts that restriction, so tunnels can run through the Wormhole. The Wormhole needs one
channel either way.
