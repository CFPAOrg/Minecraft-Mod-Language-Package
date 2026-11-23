---
navigation:
  title: 深海生命
  icon: nautec:luminous_membrane
  position: 12
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:deep_kelp
  - nautec:luminescent_algae
  - nautec:glow_polyp
  - nautec:prismarine_frond
  - nautec:vent_tubeworm
  - nautec:abyssal_coral
  - nautec:silt_skipper
  - nautec:silt_skipper_bucket
  - nautec:silt_skipper_spawn_egg
  - nautec:lantern_jelly_spawn_egg
  - nautec:vent_crawler_spawn_egg
  - nautec:abyssal_maw_spawn_egg
---

# <Color id="light_purple">深海生命</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="luminous_membrane" scale="2"/>
  海蓝科技海洋中出现的六种植物和四种动物。
</Column>

## <Color id="gold">植物</Color>

可用剪刀采集所有六种植物，其他工具则只会破坏而不产生掉落物。<ItemLink id="grafting_tool"/>能从所有这些植物上移植得到细菌，类别列表参见[细菌移植](nautec:aquatic_biology/bacteria_grafting.md)。

| 植物                               | 生物群系   | 光照强度 |
| ---------------------------------- | ---------- | -------- |
| <ItemLink id="deep_kelp"/>         | 生物荧光林 | 无       |
| <ItemLink id="luminescent_algae"/> | 生物荧光林 | 9        |
| <ItemLink id="glow_polyp"/>        | 生物荧光林 | 7        |
| <ItemLink id="prismarine_frond"/>  | 海晶珊瑚礁 | 无       |
| <ItemLink id="vent_tubeworm"/>     | 热液喷口区 | 3        |
| <ItemLink id="abyssal_coral"/>     | 深渊海沟   | 无       |

深海海带会在水下和海带一样向上生长，最高可达40格（`config/nautec-common.toml`下的`kelpHeight`）。只有最顶部的方块有掉落物，因此需要修剪其顶部。发光珊瑚虫能和发光地衣一样附着在方块的任意面上，施加骨粉可令其蔓延。其余四种均只是独立的水下植物。

各生物群系的幸运垂钓区内能钓起该群系的植物。参见[垂钓](fishing.md)。

***

## <Color id="gold">弹砂鱼</Color>

<GameScene zoom="3.2" background="#333333" interactive={true}>
  <Entity id="nautec:silt_skipper"/>
</GameScene>

友好的小型鱼类，会以最多八只一群的形式出现，可在深渊海沟、生物荧光林、海晶珊瑚礁中发现。

* 击杀时掉落可食用的<ItemLink id="silt_skipper"/>物品。
* 用水桶右击可将其舀起为<ItemLink id="silt_skipper_bucket"/>，倒空铁桶可将其放出。

***

## <Color id="gold">灯笼水母</Color>

<GameScene zoom="2.4" background="#333333" interactive={true}>
  <Entity id="nautec:lantern_jelly"/>
</GameScene>

移动缓慢的发光水母，在生物荧光林中四处漂动。它对玩家友好，生命值不高。

掉落1到2个<ItemLink id="luminous_membrane"/>（随抢夺增加），用于制造发光皮肤强化件。

***

## <Color id="gold">喷口爬蟹</Color>

<GameScene zoom="2.4" background="#333333" interactive={true}>
  <Entity id="nautec:vent_crawler"/>
</GameScene>

出没于热液喷口区海床的着甲生物。受伤时会逃走而不会反抗，能抵消所受所有击退的一半，并且免疫火焰伤害。

掉落1到3个<ItemLink id="chitin_plate"/>（随抢夺增加）。四块板可制成喷口外甲壳强化件。

***

## <Color id="gold">深渊鮟鱇</Color>

<GameScene zoom="1.8" background="#333333" interactive={true}>
  <Entity id="nautec:abyssal_maw"/>
</GameScene>

出没于深渊海沟的敌对捕食者。它只会生成于Y小于40的黑暗水体中，且会不断追击最远24格外的玩家。它的生命值为24，啃咬攻击力为6。

掉落1个<ItemLink id="abyssal_organ"/>（随抢夺增加），用于制造深渊之眼强化件。

***

## <Color id="gold">强化件</Color>

其中有三种动物的掉落物可用于制造强化件：参见[深海动物强化件](nautec:laser_augmentation/deep_fauna_augments.md)。创造模式菜单中有所有四种动物的刷怪蛋。
