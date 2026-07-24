---
navigation:
  parent: crazyae2addons_index.md
  title: Wireless Notification Terminal
  icon: crazyae2addons:wireless_notification_terminal
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:wireless_notification_terminal
---

# Wireless Notification Terminal

The **Wireless Notification Terminal** monitors selected resources in your ME network and shows their current amount on the HUD.
Each configured entry compares the current network amount with a threshold and displays the result directly on screen.

---

## Universal Wireless Terminal capable

You can join it with the wireless universal terminal.

---

## Monitored resources

The terminal has configurable monitor slots.

Place any resource into a slot to select what should be watched.

Each slot has its own threshold. A threshold of 0, or an empty threshold field, disables that monitor entry.

---

## Threshold values

Thresholds define the amount that should be treated as the target level.

Thresholds cannot be negative.

Simple math expressions can be used for large values (see the [Math Parser](./math_parser.md))

Invalid values are highlighted and are not applied.

---

## HUD display

The HUD shows each active entry as an icon with current amount and threshold.

Entries above the threshold are shown in green and entries below the threshold are shown in red.

---

## HUD position and scale

The HUD X and HUD Y fields control where the notification list appears on screen.

Both values are percentages from 0 to 100, HUD Scale controls the size of the overlay, also from 0 to 100.

Setting scale to 0 hides the HUD.

---

## Updates and range

The terminal updates the HUD once per second while it is in the player's inventory and linked to a valid ME network.

If the terminal is out of wireless range, unlinked, or cannot access the network, it will stop sending HUD updates.

The HUD is not updated while the terminal GUI is open.

---
