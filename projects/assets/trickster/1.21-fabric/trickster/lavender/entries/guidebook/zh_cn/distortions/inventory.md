```json
{
  "title": "容器与槽位",
  "icon": "minecraft:barrel",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "物仓之曲变",
    "液仓之曲变",
    "饰品之曲变",
    "侵入之曲变",
    "辨别之曲变"
  ]
}
```

能直接构造或修改$$dev.enjarai.trickster.spell.fragment.storage.StorageFragment$$的戏法。


这些戏法都是曲变术，它们不会保证创建的$$dev.enjarai.trickster.spell.fragment.storage.StorageFragment$$有效。无效的$$dev.enjarai.trickster.spell.fragment.storage.StorageFragment$$会在使用时导致失策。

;;;;;

掉落的物品、矿车、驴等许多实体都可当作$$trickster:container$$交互。玩家则不可。


牢记：创建$$dev.enjarai.trickster.spell.fragment.storage.StorageFragment$$无需消耗魔力。不过，若在使用此类引用时移动了槽位内的物品，则需消耗(距离 * 数量 * 0.5G)的魔力。**移动的消耗与各技巧术给出的消耗相独立。**

;;;;;

<|trick@trickster:templates|trick-id=trickster:create_item_container|>

;;;;;

使用所给片段构建物品容器，或使用施法者构建物品容器。


若容器是方块，还可额外给定一个向量作为交互面。

;;;;;

<|trick@trickster:templates|trick-id=trickster:create_fluid_container|>

使用所给片段构建流体容器。

;;;;;

<|trick@trickster:templates|trick-id=trickster:create_accessories_container|>

构建一个容器，其中包含施法者拥有的、能容纳所给类型的所有饰品槽。

;;;;;

<|trick@trickster:templates|trick-id=trickster:create_slot|>

使用容器和所给索引构造槽位。

;;;;;

<|trick@trickster:templates|trick-id=trickster:filter_container|>

使用所给资源类型筛选容器。需注意此曲变术返回的容器**不**支持槽位。
