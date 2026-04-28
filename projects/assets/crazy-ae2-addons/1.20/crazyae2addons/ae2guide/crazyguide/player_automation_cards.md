---
navigation:
  parent: crazyae2addons_index.md
  title: Player/Automation Cards
  icon: crazyae2addons:player_upgrade_card
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:player_upgrade_card
  - crazyae2addons:automation_upgrade_card
---

# Pattern Provider Upgrade Cards

These two upgrade cards are used in the Crazy Pattern Provider to control who is allowed to use its patterns for autocrafting.

They do not change the recipe itself. They only filter whether the Pattern Provider is considered a valid source of patterns for a given crafting request.

---

## Cards

### Player Upgrade Card

When installed, patterns in this Pattern Provider can be used only by player-started crafting requests, for example crafting started from a terminal.

### Automation Upgrade Card

When installed, patterns in this Pattern Provider can be used only by automation or machine-started crafting requests, for example crafting started by AE2 blocks or other automation systems on the network.

---

## How to use

1. Place a CrazyAE2Addons Pattern Provider on your AE2 network.
2. Open its upgrades.
3. Insert either:
    * Player Upgrade Card, or
    * Automation Upgrade Card.
4. Put your patterns into that provider as usual.

---

## Notes and tips

* Filtering is applied both during crafting calculation (pattern search) and during crafting execution (provider selection), so jobs stay consistent.

