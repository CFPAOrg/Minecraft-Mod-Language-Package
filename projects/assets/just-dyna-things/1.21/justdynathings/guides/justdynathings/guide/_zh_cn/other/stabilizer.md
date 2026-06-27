---
navigation:
  title: 稳定器
  icon: "justdynathings:stabilizer"
  position: 3
  parent: justdynathings:other.md
item_ids:
  - justdynathings:stabilizer
---

# 稳定器

能够消耗Forge能量（Forge Energy，FE）来重新激活其上方的凝胶。

<BlockImage id="justdynathings:stabilizer" scale="4.0" p:active="false" p:facing="down" p:goo_found="false"/>

示例：复苏的烈焰蕾凝胶下方有一供能充足的稳定器

<GameScene zoom="4" interactive={true}>
  <Block id="justdynathings:stabilizer" p:active="true" p:facing="down" p:goo_found="true"/>
  <Block y="1" id="justdirethings:gooblock_tier2" p:alive="true"/>
</GameScene>

激活后也可用于让悖论混合器保持在激活状态（会消耗时间流体）。

<GameScene zoom="4" interactive={true}>
  <Block id="justdynathings:stabilizer" p:active="true" p:facing="down" p:goo_found="true" p:energized="true"/>
  <Block y="1" id="justdynathings:paradox_mixer" p:alive="true"/>
</GameScene>

<Recipe id="justdynathings:stabilizer" />
