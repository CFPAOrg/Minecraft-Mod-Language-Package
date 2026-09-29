---
navigation:
  title: Paradox Mixer
  icon: "justdynathings:paradox_mixer"
  position: 7
  parent: justdynathings:other.md
item_ids:
  - justdynathings:paradox_mixer
---

# Paradox Mixer

An _unstable_ block that allow to mass-craft fluid drop recipes

<BlockImage id="justdynathings:paradox_mixer" scale="4.0" p:alive="false"/>
<BlockImage id="justdynathings:paradox_mixer" scale="4.0" p:alive="true"/>

It require at least one Stabilizer energized to stay alive

<GameScene zoom="4" interactive={true}>
  <Block id="justdynathings:stabilizer" p:active="true" p:facing="down" p:goo_found="true" p:energized="true"/>
  <Block y="1" id="justdynathings:paradox_mixer" p:alive="true"/>
</GameScene>

<Recipe id="justdynathings:paradox_mixer" />
