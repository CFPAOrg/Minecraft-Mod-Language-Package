```json
{
  "title": "布尔逻辑",
  "icon": "minecraft:comparator",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "决策之谋略",
    "对抵之谋略",
    "失抵之谋略",
    "无例外之谋略",
    "通常态之谋略",
    "缺失态之谋略",
    "较小之曲变",
    "较大之曲变"
  ]
}
```

本节的戏法能够执行布尔逻辑运算。


虽然此处要求向戏法传入布尔值，但仍应注意：如有需求，任何法术片段都会自动强制转换为布尔值。

;;;;;

强制转换的方法如下：

- 片段是{#4400aa}Void{}，转换为false。
- 片段是{#444444}##Zalgo##{}，转换为false。
- 片段是{#aa3355}False{}，转换为false。
- 其余情况下，转换为true。

;;;;;

<|trick@trickster:templates|trick-id=trickster:if_else|>

此戏法可让法术根据特定判据使用不同的片段，甚至可以用来选择不同的分支。

;;;;;

决策之谋略会接受一个或多个布尔值和任意值的组合，并返回首个为true的布尔值对应的值。如果所有的布尔值都是false，则返回在末尾指定的备用值。备用值*不得缺省*。


例如：


向此戏法传入{#33ab89}True{}, {#ddaa00}1{}, {#ddaa00}2{}，则其会返回{#ddaa00}1{}，因为布尔值为{#33ab89}True{}，且其和{#ddaa00}1{}组成了组合。

;;;;;

又如：


也可以向决策之谋略传入{#aa3355}False{}, {#ddaa00}1{}, {#aa3355}False{}, {#ddaa00}2{}, {#ddaa00}3{}，此时它会返回备用值，即{#ddaa00}3{}。


而因为所有片段都可视作布尔值，传入{#4400aa}Void{}, {#ddaa00}1{}, {#ddaa00}2{}, {#ddaa00}3{}, {#ddaa00}4{}会返回{#ddaa00}3{}。因为{#ddaa00}2{}和{#ddaa00}3{}组成了组合，且{#ddaa00}2{}被强制转换成了true。

;;;;;

<|trick@trickster:templates|trick-id=trickster:equals|>

检查各输入是否相等。只有全部输入都相等，才返回true。

;;;;;

<|trick@trickster:templates|trick-id=trickster:not_equals|>

检查各输入是否不等。若有至少两个输入相等，返回false。

;;;;;

<|trick@trickster:templates|trick-id=trickster:all|>

若所有输入为true，返回true。

;;;;;

<|trick@trickster:templates|trick-id=trickster:any|>

若任意输入为true，返回true。

;;;;;

<|trick@trickster:templates|trick-id=trickster:none|>

若没有输入为true，返回true。

;;;;;

<|trick@trickster:templates|trick-id=trickster:lesser_than|>

检查第一个数是否小于第二个数。

;;;;;

<|trick@trickster:templates|trick-id=trickster:greater_than|>

检查第一个数是否大于第二个数。
