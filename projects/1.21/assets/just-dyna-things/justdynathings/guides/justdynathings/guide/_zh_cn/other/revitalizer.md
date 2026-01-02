---
navigation:
  title: 复苏器
  icon: "justdynathings:revitalizer"
  position: 3
  parent: justdynathings:other.md
item_ids:
  - justdynathings:revitalizer
---

# 复苏器

能够消耗Forge能量（Forge Energy，FE）来重新激活其上方的凝胶。

<BlockImage id="justdynathings:revitalizer" scale="4.0" p:active="false" p:facing="down" p:goo_found="false"/>

示例：复苏的烈焰蕾凝胶下方有一供能充足的复苏器

<GameScene zoom="4" interactive={true}>
  <Block id="justdynathings:revitalizer" p:active="true" p:facing="down" p:goo_found="true"/>
  <Block y="1" id="justdirethings:gooblock_tier2" p:alive="true"/>
</GameScene>

<Recipe id="justdynathings:revitalizer" />
