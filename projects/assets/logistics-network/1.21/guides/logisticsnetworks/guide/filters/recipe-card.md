---
item_ids: [logisticsnetworks:recipe_card]
navigation:
  title: Recipe Card
  parent: filters/index.md
  position: 1
---

# Recipe Card

A Recipe Card makes an item channel send whole recipe sets instead of loose items. With a card for 3 iron + 2 sticks, receivers only ever get 3 iron and 2 sticks together, never 3 iron on their own.

## Writing a recipe

Craft paper, redstone and an iron nugget for a blank card. Right-click a card to open it. With JEI or EMI, open any recipe and press **+** to copy its ingredients onto the card. You can also click a cell while holding an item, type the amount, and press **#** to switch between the exact item and its tags. Right-click a cell to remove it. A card holds up to 12 different ingredients.

Craft a written card on its own to wipe it, or together with blank cards to copy it onto them.

## Using it in a filter

A card is an entry in an item filter, like any other item. Hold it and click a cell in the filter, or click a node's filter slot to add it to that slot's filter. The filter gets a copy and you keep the card. The cell cycles through the card's ingredients, and its name shows what the recipe makes.

Hold **Modifier Key 2** (Ctrl by default) and click the cell to edit that copy. Close the editor to go back to the filter. Click the cell with an empty hand to clear it. Cards work in whitelist and blacklist filters, in the wrench clipboard, and they copy with labels. A card in an import channel's filter does nothing. Cards can't be edited from the computer graph or from a filter item held in your hand.

Each operation sends as many whole sets as the batch size allows (at least one set). The distribution mode decides who gets them:

- **Priority / Nearest / Farthest**: fill the first receiver, then the next.
- **Priority Robin**: one receiver per operation, rotating.
- **Equal Distribution**: sets are split evenly; leftovers go to the first receivers.

If a receiver can't fit a whole set, it gets nothing. Every ingredient has to go in through the one side the receiving node is on, so machines that take their second input on a different side can't be fed a multi-ingredient card from one node.

## Blocking

Turn on **Blocking** to send only to receivers that hold none of this channel's recipe ingredients. Machines that take several recipes then never get two recipes mixed.

## Mixing with normal filters

A filter can hold cards and normal entries together. Recipe sets go first, then the normal entries move loose items with the rest of the batch. A channel whose filters hold only cards sends nothing else.
