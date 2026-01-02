```json
{
  "title": "实体派对戏法",
  "icon": "minecraft:pig_spawn_egg",
  "category": "trickster:tricks",
  "additional_search_terms": [
    ]
}
```

与实体有关的新戏法，由派对戏法（Party Tricks）添加。

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_vehicle|>

返回给定实体的坐骑，未在骑乘状态则返回void。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:ride_entity,cost=20G + 1.35G^距离|>

令第一个实体骑乘到第二个实体上。魔力的消耗计算使用两实体间的距离。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:dismount_entity,cost=距离^2 * 1G|>

使得给定实体离开其坐骑。部分实体会在离座时保留动量。

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_breeding_age|>

返回给定动物距离的繁殖时限，以刻计。繁殖时限小于0代表动物未成年，大于0则代表在冷却状态。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:add_breeding_age,cost=增量^2 * 1G|>

向给定动物的繁殖时限加上给定数刻。消耗的计算方式与[动能之技巧](^trickster:ploys/entity#3)一致。