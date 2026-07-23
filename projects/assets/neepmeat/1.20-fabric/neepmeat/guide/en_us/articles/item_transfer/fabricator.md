---
id: fabricator
lookup: neepmeat:fabricator
---

# Fabricator

\columns[fit=second]{The Fabricator enables automatic crafting. It can be used standalone or as part of a recursive crafting system with a routing network. 
}{\item_render{neepmeat:fabricator}}

## Usage

### Recipes

Recipes can be entered by clicking the template slots with items, or by dragging items in from EMI.

Recipes viewed in EMI can be quickly entered by clicking the + icon. [NOTE: Due to issues with the way EMI works, you will have to close and reopen the GUI after setting a recipe this way]

### Crafting

By default, a Fabricator will use items inside its internal inventory as ingredients. If the 'Use external' checkbox, is enabled, the Fabricator will also use items from adjacent inventories.

When anything attempts to extract an item from a Fabricator's front or bottom faces, crafting will be triggered. For example, one could continuously pipe logs into a Fabricator and extract planks from the bottom with a hopper.

When powered by a motor, a Fabricator will continuously craft the output item 

## Requests and Routing

In a routing network, Fabricators can fulfil item requests. On receiving a request for the item it provides, a Fabricator will submit new requests for all the required ingredients. Once the ingredients arrive at the Fabricator, the result will be crafted. 

Crafting can be recursive - One Fabricator can request ingredients from other Fabricators, and those Fabricators can request more ingredients.

\columns[fit=first]{\item_render[height=18]{neepmeat:pipe_driver}}{As with all item routing, a Pipe Driver must be part of the pipe network to enable this functionality.}
