---
navigation:
  title: 可干燥的砖
  icon: "minecraft:brick"
  parent: survival.md
  position: 2
categories:
  - survival
item_ids:
  - minecraft:brick
  - minecraft:clay_ball
  - synergy:packed_mud_ball
  - synergy:packed_mud_brick
---

# 可干燥的砖

制造砖的新机制。

<GameScene zoom="2" interactive={true}>
  <Block x="0" z="0" id="synergy:clay_brick_block" p:facing="north" p:wet="false" p:dried="false" p:stage="0"/>
  <Block x="0" z="1" id="synergy:clay_brick_block" p:facing="north" p:wet="false" p:dried="true" p:stage="5"/>
  <Block x="1" z="0" id="synergy:packed_mud_brick_block" p:facing="north" p:wet="false" p:dried="false" p:stage="0"/>
  <Block x="1" z="1" id="synergy:packed_mud_brick_block" p:facing="north" p:wet="false" p:dried="true" p:stage="5"/>
</GameScene>

### 工作原理

放置后，若环境不处于潮湿状态，则砖会风干至完全干燥。

破坏或右击完全干燥的砖可收回。

若环境潮湿，且砖尚未完全干燥，那么干燥进度会回退。

干燥操作需要露天，但开始降雨后则需要挡雨！

干燥操作需在干燥的生物群系中进行。


<Recipe id="synergy:dryable_bricks/packed_mud_brick" />
<Recipe id="synergy:dryable_bricks/brick" />
