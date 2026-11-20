---
navigation:
  parent: items-blocks/index.md
  icon: multi_processing_handler
  title: Multi-Processing Handler
categories:
  - autocrafting
  - requires_controller
description: one handler for many processing set recipes
item_ids:
- nodeworks:multi_processing_handler
---

# Multi-Processing Handler

A <ItemLink id="processing_handler" /> that handles many
[Processing Set](./recipe_sets.md#processing-set) recipes at once. Bind
multiple ore recipe to one Handler in front of a bank of furnaces and the
[Crafting CPU](./crafting_cpu.md) routes each craft through it, no Lua
and no Handler per recipe.

> Requires a <ItemLink id="network_controller" /> to use

<GameScene zoom="3" interactive={true} paddingLeft="50" paddingRight="50" paddingTop="30">
  <IsometricCamera yaw="160" roll="0" pitch="10" />
  <ImportStructure src="../assets/assemblies/multi_processor_handler.snbt" />
  <BoxAnnotation min="0 2 0" max="1 2.25 1" color="#3C44AA">
    <ItemImage id="storage_card" /> Blue channel Storage Card
  </BoxAnnotation>
  <BoxAnnotation min="0 0.75 0" max="1 1 1" color="#B02E26">
    <ItemImage id="storage_card" /> Red channel Storage Card
  </BoxAnnotation>
  <BlockAnnotation x="2" y="1">
    Configured for multiple smelting recipes.
  </BlockAnnotation>
</GameScene>

## Two sides

The same shape as the Processing Handler: the **back face** joins the
parent network, the **front face** anchors its own micro-network of
pipes, nodes and storage cards around the machines. See
[Two sides](./processing_handler.md#two-sides) for the layout.

## Choosing recipes

Right-click the Handler to open its GUI. It lists every Processing Set on
the parent network with a checkbox. Tick the ones this Handler should
take. Ticked recipes sort to the top, and the search box narrows the list by recipe or item name.

The counter in the corner shows how many are ticked out of the limit. A
recipe a script or another Handler already owns is greyed out, and so is
everything else once the limit is reached.

A ticked recipe that is later removed from Processing Storage stays in the
list marked as missing, so you can untick it. It comes back to life if the
Set returns.

## Channels

One input channel and one output channel, shared by every recipe.
Ingredients of any ticked recipe go to <ItemLink id="storage_card" />s on
the micro-network with the input color, finished outputs are pulled from
cards with the output color. For a furnace bank that is one blue card on
top of each furnace and one red card underneath.

Every ingredient arrives on the same channel, so the sorting happens on the
cards. Give each Storage Card a [filter](./storage_card.md#filters) and only
matching items land in its block: a card on the side of each furnace that
allows `#c:coal` takes the fuel, the card on top that denies it takes the
ore, both on the blue channel.

![](../assets/images/in_out_channels.png)

## Parallel Mode

By default the Handler runs one craft at a time, so two recipes from the same crafting tree queue up instead of fighting over the same furnaces, and a co-processor waiting on it goes to work on something else.
If you want to change this you can press the **Parallel** toggle switch which lets crafts run in parallel.

![](../assets/images/parallel_toggle.png)

## Compared to the Processing Handler

Use a <ItemLink id="processing_handler" /> when one recipe wants its own
machine or its own channel per ingredient. Use the Multi-Processing
Handler when many recipes share one machine bank and all route the same
way.

## Recipe

<RecipeFor id="multi_processing_handler" />
