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

The Wireless Notification Terminal is a wireless terminal that watches your ME storage and
shows toast notifications when selected items or fluids or other resources cross a configured stock threshold.

It is meant for simple “stock went above or below X” alerts.

## [Video Tutorial](https://youtu.be/l7OcgG5FD_s&list=PLB8Rr5Xojkr5T1qoPr_4JdETiBkF4qF6r)

---

## Requirements

* The terminal must be linked to an AE network (same as other wireless terminals).

---

## Quick Start

1. Open the terminal GUI.
2. In the first row, put the item or fluid you want to monitor into the filter slot.
3. Enter a threshold value in the field next to it.
4. Repeat for more rows (up to 32).

When the stored amount changes and crosses the threshold, you will receive a toast:

* Above threshold (amount becomes greater than or equal to the threshold)
* Below threshold (amount becomes less than the threshold)

Checks and updates happen once per second.

## Notes

* Notifications only trigger when the state flips (below to above, or above to below).
* Changing a filter item or editing the threshold resets the stored state for that row (so it will not instantly notify until it crosses again).
* It works even while the GUI is closed, as long as the terminal item is in your inventory (server-side check once per second).
* Works with Wireless Universal Terminal (WUT) as well.
