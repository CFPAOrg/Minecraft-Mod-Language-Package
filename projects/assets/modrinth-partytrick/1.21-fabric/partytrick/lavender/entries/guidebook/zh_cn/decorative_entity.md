```json
{
  "title": "装饰性实体",
  "icon": "minecraft:armor_stand",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "匹诺曹之辑流",
    "Cleo之技巧",
    "木偶之技巧"
    ]
}
```

用于操纵盔甲架、物品展示框、画等装饰性实体的戏法，由派对戏法（Party Trick）添加。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:move_decorative_entity,cost=距离^2 * 0.5G|>

按照所给向量移动所给装饰性实体。消耗的计算方式与[动能之技巧](^trickster:ploys/entity#3)一致。试图移动非装饰性实体会导致失策。

;;;;;

<|page-title@lavender:book_components|title=笔记：属性|>装饰性实体的部分属性可以直接修改。所有属性都与图案相对应，组合使用图案即可一次性按列表序修改多个属性。


向量为欧拉角，旋转单位为弧度，尺寸缩放所受的限制要强于[居形之技巧](^trickster:ploys/entity#5)。

;;;;;

<|pattern@partytrick:templates|pattern=41|>  {#aa7711}头部{}
<|pattern@partytrick:templates|pattern=47|>  {#aa7711}躯干{}
<|pattern@partytrick:templates|pattern=40|>  {#aa7711}左臂{}
<|pattern@partytrick:templates|pattern=42|>  {#aa7711}右臂{}
<|pattern@partytrick:templates|pattern=76|>  {#aa7711}左腿{}
<|pattern@partytrick:templates|pattern=78|>  {#aa7711}右腿{}
<|pattern@partytrick:templates|pattern=63452|>  {#ddaa00}朝向{}
<|pattern@partytrick:templates|pattern=072|>  {#ddaa00}尺寸{}
<|pattern@partytrick:templates|pattern=375|>  {#aa3355}是否为小型盔甲架{}
<|pattern@partytrick:templates|pattern=06482|>  {#aa3355}是否有手臂{}
<|pattern@partytrick:templates|pattern=68|>  {#aa3355}是否有底座{}
<|pattern@partytrick:templates|pattern=3273|>  {#aa3355}是否可见{}
<|pattern@partytrick:templates|pattern=610218|>  {#aa3355}是否受重力{}
<|pattern@partytrick:templates|pattern=6301258|>  {#aa3355}是否受保护{}
<|pattern@partytrick:templates|pattern=05830|>  {#aa3355}是否显示名称{}

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_decorative_entity_property|>

根据所给属性图案返回所给装饰性实体的属性值。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:set_decorative_entity_property,cost=1G|>

根据所给属性图案和输入改变所给装饰性实体的属性。
