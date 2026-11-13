---
navigation:
  title: 化工流体
  icon: nautec:eas_bucket
  position: 3
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:eas_bucket
  - nautec:saltwater_bucket
  - nautec:oil_bucket
  - nautec:glass_vial
  - nautec:eas_vial
  - nautec:salt
---

# <Color id="light_purple">化工流体</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="eas_bucket" scale="2"/>
  海蓝科技机器制造和使用的流体。
</Column>

盐水是几乎所有[搅拌机](mixer.md)配方的基液。搅拌机可将其加工为电解藻类浆液（Electrolyte Algae Serum，EAS）和蚀刻酸。

***

<Row>
  <ItemImage id="saltwater_bucket"/>
  ### <Color id="aqua">盐水</Color>
</Row>

盐水产自[深海排水口](drain.md)，每秒其储罐中会新增500 mB。可用铁桶或管道取出。

也可以在[搅拌机](mixer.md)中制造：1,000 mB水和一份盐搅拌5秒可制成1,000 mB盐水。

铁桶盛装的海水默认为淡水。整合包作者可将`config/nautec-common.toml`中的`collectSaltWater`设为true，这样在海洋生物群系中用铁桶舀到的就是盐水。

***

<Row>
  <ItemImage id="eas_bucket"/>
  ### <Color id="aqua">电解藻类浆液（Electrolyte Algae Serum，EAS）</Color>
</Row>

由盐水在[搅拌机](mixer.md)中制成。EAS是[海蓝钢工具](tools.md)能力的前置需求。

将EAS倒出为流体源，向其中投入工具，可为工具注能。注能需等待约7.5秒，完毕后会消耗EAS源；也即一桶流体可为一个工具注能。

***

<Row>
  <ItemImage id="etching_acid_bucket"/>
  ### <Color id="aqua">蚀刻酸</Color>
</Row>

能清理板条箱和老旧部件上的锈迹。可在[搅拌机](mixer.md)中制造，也可直接合成。参见[板条箱与物品蚀刻](nautec:getting_started/etching.md)。

***

<Row>
  <ItemImage id="oil_bucket"/>
  ### <Color id="aqua">原油</Color>
</Row>

出现于<ItemLink id="oil_barrel"/>中的黏稠流体。

***

## <Color id="gold">试管与盐</Color>

<Row>
  <ItemImage id="glass_vial"/>
  ### <Color id="aqua">玻璃试管</Color>
</Row>

<Recipe id="nautec:glass_vial"/>

<Row>
  <ItemImage id="eas_vial"/>
  ### <Color id="aqua">电解藻类浆液（EAS）试管</Color>
</Row>

一个EAS桶和三个玻璃试管可合成为三个EAS试管，并返还空铁桶。玻璃试管和EAS试管可用于装填<ItemLink id="syringe_robot_arm"/>。

<Recipe id="nautec:eas_vial"/>

<Row>
  <ItemImage id="salt"/>
  ### <Color id="aqua">盐</Color>
</Row>

盐是幸运垂钓区的渔获，参见[垂钓](nautec:getting_started/fishing.md)。[喷口汇热器](nautec:getting_started/ocean_generators.md)也会在每蒸干1,000 mB盐水后产出一份盐。盐和水可在[搅拌机](mixer.md)中加工为盐水。
