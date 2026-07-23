---
item_ids: [logisticsnetworks:big_filter]
navigation:
  title: 大型过滤器
  parent: filters/index.md
  icon: logisticsnetworks:big_filter
  position: 3
---

# 大型过滤器

最大号的精确匹配过滤器。行为与[小型过滤器](small.md)一致，仅槽位扩展到**27个**。

## 匹配对象

所有物品ID或流体ID在过滤器列表之内的资源。进行精确匹配。

## 条目槽

- **27个槽位**（在过滤器菜单中为3x9方格，相当于一整个箱子）。
- 手持过滤器右击可打开菜单。
- 忽略空条目槽。

每个条目都有隐藏的**详情**页面，其中有仅作用于该槽位的规则，参见[高级过滤](advanced-filtering.md)。

## 白名单与黑名单

- **白名单**：仅传输列出的资源。
- **黑名单**：仅不传输列出的资源。

## 用例

- 大型的显式白名单，为建筑材料箱指定所需所有建筑方块。
- 需要一一列出许多种合成原料的单个频道。

## 合成配方

<RecipeFor id="logisticsnetworks:big_filter" />
