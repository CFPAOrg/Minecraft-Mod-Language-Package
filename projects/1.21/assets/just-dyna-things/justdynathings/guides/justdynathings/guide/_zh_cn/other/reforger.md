---
navigation:
  title: 再造器
  icon: "justdynathings:reforger"
  position: 2
  parent: justdynathings:other.md
item_ids:
  - justdynathings:reforger
---

# 再造器


一台强大的机器，可消耗*催化剂*将放置于*红色面*的输入方块变成*输出方块*。

<BlockImage id="justdynathings:reforger" p:facing="up" p:active="true" scale="4.0"/>

<Recipe id="justdynathings:reforger" />

## 默认配方

| 催化剂                                     | 输入方块                                        | 输出方块                                        | 消耗概率 |
| ------------------------------------------ | ----------------------------------------------- | ----------------------------------------------- | -------- |
| <ItemLink id="minecraft:diamond"/>         | <ItemLink id="minecraft:stone"/>                | `c:ores_in_ground/stone`                        | 95%      |
| <ItemLink id="justdirethings:celestigem"/> | <ItemLink id="minecraft:stone"/>                | `c:ores_in_ground/stone`                        | 50%      |
| <ItemLink id="justdirethings:coal_t1"/>    | `c:storage_blocks/charcoal`                     | <ItemLink id="justdirethings:raw_coal_t1_ore"/> | 25%      |
| <ItemLink id="justdirethings:coal_t2"/>    | <ItemLink id="justdirethings:raw_coal_t1_ore"/> | <ItemLink id="justdirethings:raw_coal_t2_ore"/> | 50%      |
| <ItemLink id="justdirethings:coal_t3"/>    | <ItemLink id="justdirethings:raw_coal_t2_ore"/> | <ItemLink id="justdirethings:raw_coal_t3_ore"/> | 75%      |
| <ItemLink id="justdirethings:coal_t4"/>    | <ItemLink id="justdirethings:raw_coal_t3_ore"/> | <ItemLink id="justdirethings:raw_coal_t4_ore"/> | 100%     |
