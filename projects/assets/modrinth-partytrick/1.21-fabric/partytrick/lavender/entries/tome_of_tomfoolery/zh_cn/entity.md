```json
{
  "title": "实体派对戏法",
  "icon": "minecraft:pig_spawn_egg",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "同伴之辑流",
    "激策之技巧",
    "离座之技巧",
    "纪岁之辑流",
    "时岁之技巧",
    "匹诺曹之辑流",
    "Cleo之技巧",
    "木偶之技巧"
    ]
}
```

与实体有关的新戏法，由派对戏法（Party Tricks）添加。

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_vehicle|>

返回给定实体的坐骑，未在骑乘状态则返回void。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:ride_entity,cost=20G + 1.35G^距离|>

令第一个实体骑乘到第二个实体上，返回骑手实体。魔力消耗的计算使用两实体间的距离。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:dismount_entity,cost=1G * 距离^2|>

使得给定实体离开其坐骑，部分实体会在离座时保留动量。

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_breeding_age|>

返回给定动物距离的繁殖时限，以刻计。繁殖时限小于0代表动物未成年，大于0则代表在冷却状态。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:add_breeding_age,cost=1G * 增量^2|>

向给定动物的繁殖时限加上给定数刻。消耗的计算方式与[动能之技巧](^trickster:ploys/entity#3)一致。

;;;;;

<|page-title@lavender:book_components|title=笔记：盔甲架|>向盔甲架注入魔力，即可改变它们的属性，可改变的属性及其编号见后页。向量参数为欧拉角，旋转单位为度，尺寸缩放所受的限制要强于[居形之技巧](^trickster:ploys/entity#5)。


也可以通过魔法控制物品展示框的物品朝向、展示框隐形与否，以及展示框是否受保护。朝向为0到7的数。

;;;;;


0. {#aa7711}头部{}
1. {#aa7711}躯干{}
2. {#aa7711}左臂{}
3. {#aa7711}右臂{}
4. {#aa7711}左腿{}
5. {#aa7711}右腿{}
6. {#ddaa00}朝向{}
7. {#ddaa00}尺寸{}
8. {#aa3355}无重力{} 
9. {#aa3355}无底座{}
10. {#aa3355}隐形{}
11. {#aa3355}是否显示手臂{}
12. {#aa3355}是否为小型盔甲架{}
13. {#aa3355}显示名称{}
14. {#aa3355}是否受保护{}

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_armor_stand_state|>

返回所给盔甲架在给定编号下属性的值。


后方的技巧术则会设置属性值 →

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:set_armor_stand_state,cost=1G|>

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:move_armor_stand,cost=距离^2 * 1G|>

按照所给向量移动给定盔甲架或其他装饰性实体。试图移动无效实体会导致失策。