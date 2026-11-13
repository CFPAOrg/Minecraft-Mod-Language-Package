---
navigation:
  title: 生物强化件
  icon: nautec:dolphin_fin
  position: 3
  parent: laser_augmentation/laser_augmentation-index.md
item_ids:
  - nautec:guardian_eye
  - nautec:dolphin_fin
  - nautec:drowned_lungs
  - nautec:eldritch_heart
---

# <Color id="light_purple">生物强化件</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="dolphin_fin" scale="2"/>
  掉落自原版海洋生物的四种强化件。
</Column>

所有器官都可在[强化站](augmentation_station.md)中直接植入，无需合成加工。

***

<Row>
  <ItemImage id="guardian_eye"/>
  ### <Color id="aqua">守卫者之眼</Color>
</Row>

槽位：眼。掉落自守卫者，概率约为四十分之一。

按住L可向视线经过的第一个活物发射守卫者激光，最远可至15格。激光会被遇到的第一个固体方块阻挡，攻击目标时需要能直接看见目标。水不会阻挡激光。每次攻击造成3点魔法伤害（可配置，`guardianAugmentDamage`），只要按住按键就可持续发射，无需冷却也不用消耗储能。

它和深渊之眼都要占用眼部槽位。

***

<Row>
  <ItemImage id="dolphin_fin"/>
  ### <Color id="aqua">海豚鳍</Color>
</Row>

槽位：躯干。掉落自海豚，概率约为五分之一。

头部在水下时给予海豚的恩惠 II，大幅加快游泳速度。它需占用躯干槽，和飞行强化件还有发光皮肤一样。

***

<Row>
  <ItemImage id="drowned_lungs"/>
  ### <Color id="aqua">溺尸之肺</Color>
</Row>

槽位：肺。掉落自溺尸，概率约为二十分之一。

身处水下时将氧气条补充至满，杜绝溺水。它是唯一要占用肺部槽位的强化件，因此不会与其他强化件冲突。

***

<Row>
  <ItemImage id="eldritch_heart"/>
  ### <Color id="aqua">邪能之心</Color>
</Row>

槽位：心。掉落自远古守卫者，每只有约五分之三的概率至少掉落一个。

身处水中时每秒治疗半颗心生命值。

强化站的合成也需要一个邪能之心，拿到的第一个建议保留给它使用。它和[可合成强化件](crafted_augments.md)辅助心室都需占用心脏槽位，后者会让你的最大生命值翻倍。
