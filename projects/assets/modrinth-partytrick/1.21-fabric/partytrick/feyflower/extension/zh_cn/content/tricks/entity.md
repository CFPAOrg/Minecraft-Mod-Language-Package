```json
{
  "title": "实体派对戏法",
  "icon": "minecraft:pig_spawn_egg"
}
```

与实体有关的新戏法，由派对戏法（Party Tricks）添加。

;;;;;

#<trickster:trick id="partytrick:get_vehicle" />

返回给定实体的坐骑，未在骑乘状态则返回void。

;;;;;

#<trickster:trick id="partytrick:ride_entity" cost="20G + 1.35G^距离" />

令第一个实体骑乘到第二个实体上，返回骑手实体。计算公式中所用的距离，是指两实体间的距离。

;;;;;

#<trickster:trick id="partytrick:dismount_entity" cost="1G * 距离^2" />

使得给定实体离开其坐骑，部分实体会在离座时保留动量。

;;;;;

#<trickster:trick id="partytrick:get_breeding_age" />

返回给定动物的繁殖时限，以刻计。繁殖时限小于0代表动物未成年，大于0则代表在冷却状态。

;;;;;

#<trickster:trick id="partytrick:add_breeding_age" cost="1G * 增量^2" />

向给定动物的繁殖时限加上给定数刻。消耗的叠加方式与[动能之技巧](*trickster:tricks/ploys/entity@trick&trickster:add_velocity)一致。

;;;;;

#<trickster:trick id="partytrick:summon_spit" cost="20G + 1G * 距离 ^ (距离 / 3)" />

若可行，从给定生物或从施法者口中抽出唾沫。计算公式中所用的距离，是指唾沫来源和给定位置间的距离。

;;;;;

#<trickster:trick id="partytrick:get_cooldown" />

检查所给玩家是否暂时无法使用给定物品。