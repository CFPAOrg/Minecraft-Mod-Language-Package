---
navigation:
  title: Dryable Bricks
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

# Dryable Bricks

A new mechanic to process bricks

<GameScene zoom="2" interactive={true}>
  <Block x="0" z="0" id="synergy:clay_brick_block" p:facing="north" p:wet="false" p:dried="false" p:stage="0"/>
  <Block x="0" z="1" id="synergy:clay_brick_block" p:facing="north" p:wet="false" p:dried="true" p:stage="5"/>
  <Block x="1" z="0" id="synergy:packed_mud_brick_block" p:facing="north" p:wet="false" p:dried="false" p:stage="0"/>
  <Block x="1" z="1" id="synergy:packed_mud_brick_block" p:facing="north" p:wet="false" p:dried="true" p:stage="5"/>
</GameScene>

### How it work

When placed , if it isn't wet will dry until be fully dried

When fully dried can be broken or right-clicked to be collected

When is wet and not fully dried will decay the stage of drying

Require to see the sky to dry but if start to rain it require a cover!

Require a dry biome to dry


<Recipe id="synergy:dryable_bricks/packed_mud_brick" />
<Recipe id="synergy:dryable_bricks/brick" />
