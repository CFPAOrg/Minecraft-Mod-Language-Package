---
navigation:
  parent: items-blocks/index.md
  icon: processing_handler
  title: Processing Handler
categories:
  - autocrafting
description: registers a processing set handler using a micro-network
item_ids:
- nodeworks:processing_handler
---

# Processing Handler

A block-based handler for
[Processing Set](./recipe_sets.md#processing-set) recipes. Drop one on
the network, bind it to a recipe, and the
[Crafting CPU](./crafting_cpu.md) will route the recipe's ingredients
into your machine and pull the outputs back without you writing any Lua.

<GameScene zoom="5" interactive={true} paddingLeft="30" paddingRight="30">
  <IsometricCamera yaw="160" roll="0" pitch="10" />
  <ImportStructure src="../assets/assemblies/basic_processing_handler.snbt" />
  <BoxAnnotation min="0 2 0" max="1 2.25 1" color="#3C44AA">
    Blue channel Storage Card pointing at the top of the furnace
  </BoxAnnotation>
  <BoxAnnotation min="0 0.75 0" max="1 1 1" color="#B02E26">
    Red channel Storage Card pointing at the bottom of the furnace
  </BoxAnnotation>
</GameScene>

## Two sides

The Handler has a front face and a back face:

- **Back face**: joins the parent network where your
  <ItemLink id="crafting_core" /> and
  <ItemLink id="processing_storage" /> live.
- **Front face**: anchors its own **micro-network** of pipes, nodes, and
  storage cards. The Handler acts as the controller for this side, so
  no <ItemLink id="network_controller" /> is needed (or allowed) on the
  front.

Wire the back into your main network and run a small pipe loop off the
front to whatever machine actually carries out the recipe.

## Binding a recipe

Right-click the Handler to open its GUI and pick a
<ItemLink id="processing_set" /> from the parent network's Processing
Storage. Each ingredient in the Set gets its own row in the GUI with a
channel colour, plus one channel colour for the recipe's outputs.

## Channel routing

The Handler uses channels to decide which
<ItemLink id="storage_card" /> on the micro-network gets each item:

- **Input channels** (one per ingredient, default blue). When the CPU
  starts a craft, each input is pushed to a storage card on the
  micro-network whose channel matches that ingredient's colour.
    - *Input items also respect Storage Card filters if you need custom routing by
    an expression, data on the item, or stackability*
- **Output channel** (one shared colour, default red). The Handler
  watches storage cards on the micro-network with this channel and
  pulls finished outputs back into the parent network.

For the furnace example in the scene above: a blue storage card on top
of the furnace receives the raw input, the furnace processes it, and a
red storage card on the bottom collects the result.

Different ingredients can use different colours when a single machine
needs them in different slots, like fuel on one side and input on
another.

## Compared to a scripted handler

A Processing Handler is the no-script equivalent of
[`network:handle(...)`](../lua-api/network.md#handle). Use the Handler when the recipe is "push inputs
in, pull outputs out." Use a scripted handler when you need custom
timing, or multi-step flows.

## Recipe

<RecipeFor id="processing_handler" />
