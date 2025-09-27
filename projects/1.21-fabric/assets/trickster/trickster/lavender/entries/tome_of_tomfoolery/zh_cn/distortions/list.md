```json
{
  "title": "列表",
  "icon": "minecraft:string",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "目录之错觉",
    "计量之曲变",
    "扩展之谋略",
    "集合之谋略",
    "孤立之曲变",
    "计数之曲变",
    "膨胀之谋略",
    "提取之曲变",
    "定目之曲变",
    "驱散之谋略",
    "放逐之谋略",
    "间奏之曲变"
  ]
}
```

法术中可以创建列表。列表中能容纳任意个片段，整体又被视为单个值。


列表索引自0起始。

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_create|>

新建一个空列表。

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_size|>

返回所给列表中元素的数目。

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_add|>

将任意个元素接到给定列表末尾。

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_add_range|>

创建一个新列表，其中包含所有给定列表中的元素。

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_take_range|>

取出列表中索引自第一个数起始、在第二个数前结束的元素，将它们组成子列表并返回。

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_reverse|>

倒置所给列表。

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_insert|>

在给定列表中给定位置处插入任意个元素。

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_get|>

查询并返回给定列表中给定索引处的元素。

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_index_of|>

查询并返回给定元素在给定列表中的索引，若列表中不存在该元素，返回void。

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_remove|>

根据索引移除给定列表中任意个元素。移除过程中索引不会变化。

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_remove_element|>

检查给定列表中元素是否与所给参数一致，若一致则移除。

;;;;;

<|trick@trickster:templates|trick-id=trickster:create_number_range|>

返回一个列表，其中包含自第一个数起始、在第二个数前结束的所有整数。
