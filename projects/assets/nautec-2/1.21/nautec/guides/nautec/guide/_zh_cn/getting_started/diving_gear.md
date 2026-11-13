---
navigation:
  title: 潜水套装与氧气
  icon: nautec:diving_helmet
  position: 10
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:brown_polymer
  - nautec:diving_chestplate
  - nautec:diving_helmet
  - nautec:diving_leggings
  - nautec:diving_boots
  - nautec:air_bottle
---

# <Color id="light_purple">潜水套装与氧气</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="diving_helmet" scale="2"/>
  由四件装备组成的套装，最多能容纳足够呼吸十分钟的空气。
</Column>

穿上所有四件装备，胸甲的空气罐即能在水下保证你氧气充足。身处水下每过一秒，它都会消耗相应量的空气来补充你的氧气条。空气罐耗尽时，你的氧气条会和平常一样消耗。

穿上所有四件装备后，你还能用身在地面上时的挖掘速度在水下挖掘，即便是在游泳或是没有站在海床上也一样：套装能抵消水下挖掘减速，也能抵消未站在地面上的挖掘减速。

潜水套装的护甲值和全套铁盔甲相近，在铁砧中则使用铜锭修复。

***

## <Color id="gold">各个套件</Color>

<Row>
  <ItemImage id="diving_helmet"/>
  ### <Color id="aqua">潜水头盔</Color>
</Row>

清除水下迷雾，大幅拓展你的视野。此功能与其他套件相独立，在未穿戴剩余套件时也会生效。

<Recipe id="nautec:diving_helmet"/>

<Row>
  <ItemImage id="diving_chestplate"/>
  ### <Color id="aqua">潜水胸甲</Color>
</Row>

空气罐所在处，能容纳10分钟的空气。新合成的盔甲自带充满的储罐。空气剩余量会显示在提示文本处，在水下时储罐余量则显示为快捷栏上方的气泡条。储罐耗空时，气泡条会变为空泡泡以警告你需要补充空气。

<Recipe id="nautec:diving_chestplate"/>

<Row>
  <ItemImage id="diving_leggings"/>
  ### <Color id="aqua">潜水护腿和潜水靴子</Color>
</Row>

套组的必须套件。空气罐只在穿戴所有四件盔甲时可用。

<Recipe id="nautec:diving_leggings"/>

<Recipe id="nautec:diving_boots"/>

***

## <Color id="gold">填充储罐</Color>

<Row>
  <ItemImage id="air_bottle"/>
  ### <Color id="aqua">压缩空气瓶</Color>
</Row>

用空玻璃瓶右击气泡柱可装入压缩空气。灵魂沙气泡柱和岩浆块气泡柱均有效。晶洞的木桶里也能找到几个这种瓶子。

用八个空气瓶包围胸甲合成，可向储罐填充空气。如此可将储罐补满至十分钟，同时会返还空玻璃瓶。胸甲会作为新物品返还，因此会丢失原有的魔咒。若需保留魔咒，可直接饮用空气瓶。

<Recipe id="nautec:diving_chestplate_oxygen"/>

穿有胸甲时还可饮用空气瓶。每个空气瓶能向未满的储罐补充2分钟的空气，最多补充至10分钟，也即五瓶即可补满。饮用空气瓶还会让你向上漂浮10秒。

### <Color id="aqua">氧气流体</Color>

胸甲也接受其他模组的氧气流体，如群星（Stellaris）的氧气等。把胸甲放进能灌入流体的机器或储罐槽即可。每1 mB的氧气对应1秒空气，600 mB可填满空储罐。

***

<Row>
  <ItemImage id="brown_polymer"/>
  ### <Color id="aqua">棕色聚合物</Color>
</Row>

套装的原材料。可用干海带和棕色染料合成，也能在板条箱和晶洞木桶中找到。多余的聚合物可用去制造书、床、旗帜和物品展示框。

<Recipe id="nautec:brown_polymer"/>

***

## <Color id="gold">配合群星</Color>

安装有群星时，完整的潜水套装能在没有空气的星球上维持你的生命。在可呼吸区域之外每停留1秒，即会消耗储罐中相应量的空气；快捷栏上方的气泡条会在这些区域中显示。在氧气释放机的范围内，储罐不会消耗空气。

穿有群星航天服头盔、且头盔中有氧气模块时，饮用空气瓶可补充120 mB的氧气，和向潜水套装空气罐补充的量相同——2分钟。

***

## <Color id="gold">其他在水下呼吸的方法</Color>

* [海洋斥候](nautec:submarine/submarine.md)有能量时可保障其中所有人安全呼吸。
* 持有[驭浪推进器](nautec:submarine/wave_jet.md)时按住推进键可停止消耗空气条。
* 穿有完整的群星航天服套装时，只要头盔中有氧气，即可在水下呼吸。
* 溺尸之肺可让你在水下随时都有满条空气：参见[生物强化件](nautec:laser_augmentation/mob_augments.md)。
