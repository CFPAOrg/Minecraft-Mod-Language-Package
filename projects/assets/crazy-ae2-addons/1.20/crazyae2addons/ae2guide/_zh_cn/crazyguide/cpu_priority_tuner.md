---
navigation:
  parent: crazyae2addons_index.md
  title: CPU优先级调整器
  icon: crazyae2addons:cpu_priority_tuner
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:cpu_priority_tuner
---

# CPU优先级调整器

**CPU优先级调整器**可为AE2合成CPU设置优先级数值。

优先级决定了有效CPU的选取顺序。

AE2向CPU派发任务时，高优先级的CPU会首先被选中。换言之，高优先级的CPU会首先获得机器的使用权，也会首先收到产物。

推荐将玩家请求CPU的优先级保持在最高级别。

---

## 自动选择

CPU选择器处于自动模式时，网络会按照优先级从高到低选取有效的空闲CPU。

CPU需满足AE2本身的要求，如具备任务所需的存储空间。

优先级只会影响有效CPU的选择顺序。

---

## 合成状态界面

合成状态界面下，各CPU会按照优先级进行排序。

高优先级的CPU会显示在上方。

CPU的提示文本中也会指明其优先级。

---