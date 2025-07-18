---
navigation:
  title: Reforger
  icon: "justdynathings:reforger"
  position: 2
  parent: justdynathings:other.md
item_ids:
  - justdynathings:reforger
---

# Reforger

A powerful machine that allow to convert an input block placed to the _red face_ into an _output Block_ at the cost of a _catalyst_

<BlockImage id="justdynathings:reforger" p:facing="up" p:active="true" scale="4.0"/>

<Recipe id="justdynathings:reforger" />

## Default Recipes

| Catalyst                                   | Input Block                                     | Output Block                                    | Chance to consume |
| ------------------------------------------ | ----------------------------------------------- | ----------------------------------------------- | ----------------- |
| <ItemLink id="minecraft:diamond"/>         | <ItemLink id="minecraft:stone"/>                | `c:ores_in_ground/stone`                        | 95%               |
| <ItemLink id="justdirethings:celestigem"/> | <ItemLink id="minecraft:stone"/>                | `c:ores_in_ground/stone`                        | 50%               |
| <ItemLink id="justdirethings:coal_t1"/>    | `c:storage_blocks/charcoal`                     | <ItemLink id="justdirethings:raw_coal_t1_ore"/> | 25%               |
| <ItemLink id="justdirethings:coal_t2"/>    | <ItemLink id="justdirethings:raw_coal_t1_ore"/> | <ItemLink id="justdirethings:raw_coal_t2_ore"/> | 50%               |
| <ItemLink id="justdirethings:coal_t3"/>    | <ItemLink id="justdirethings:raw_coal_t2_ore"/> | <ItemLink id="justdirethings:raw_coal_t3_ore"/> | 75%               |
| <ItemLink id="justdirethings:coal_t4"/>    | <ItemLink id="justdirethings:raw_coal_t3_ore"/> | <ItemLink id="justdirethings:raw_coal_t4_ore"/> | 100%              |
