---
navigation:
  parent: items-blocks/index.md
  icon: observer_card
  title: Observer Card
categories:
  - card
description: reads the block at the installed node face, id, properties, and change events
item_ids:
- nodeworks:observer_card
---

# Observer Card

Reads the block at the installed face. Exposes the block id, every state
property the block has (growth `age`, `facing`, `waterlogged`, `lit`, ...),
and a change callback so scripts can react the instant a block transitions
to the state you care about.

<ItemImage scale="6" id="observer_card" />

## What it's for

Stage-gated farms are the headline use case. A piston wired to a vanilla
observer fires on every growth transition, so it'll break a small bud for
1 shard instead of waiting for the full cluster's 4. With an Observer Card
the script can read the actual stage and only pulse the breaker when the
block becomes the final form.

It's also the right tool for reads that aren't redstone signals: trapdoor
open / closed, door state, beehive honey level, dripstone fill, daylight
sensor reading, sweet berry / kelp / sugar cane growth, ice / snow forming
under a block, anything with a `BlockState` property you can compare against.

## Installing and Scripting

Installs in a Node face the same way an <ItemLink id="io_card" /> does.
See [IO Card installation](./io_card.md#installing) for the walkthrough.
The card reads the block in front of *that face*.

See the [ObserverCard Scripting API](../lua-api/card-handle.md#observer-card)
for the methods it exposes.

## Channel

The Observer Card has a channel picker in its GUI. See
[Choosing a Channel](../lua-api/channel.md#choosing-a-channel) for how channels
scope which scripts can address this card.

## Recipe

<RecipeFor id="observer_card" />
