---
id: item_pipe
lookup: neepmeat:storage_driver, neepmeat:merge_item_pipe, neepmeat:item_pipe, neepmeat:speed_item_pipe
---

# 物品管道

物品管道能在方块间便捷地运输物品堆叠。

## 使用方法

这些管道无法通过常规手段送入物品，而是必须通过物品泵或弹出器送入。

颚式破碎机、物品输出端口等部分方块则能主动向管道输出。管道可向任意有效方块存入物品，若末端敞开，则也能让物品掉落为物品实体。

空手右击管道连接处可切换该处是否连接。

# 简单路由

通过常规手段送入的物品会在交叉处随机选择去向，直至抵达有效容器或敞开的管道。遇到死路的物品会返回网络。

大多数能主动输出物品的方块都会在输出前检查有效目的地存在与否。不过，此方式送入的物品依然会在交叉处随机选向。

此随机行为有一例外。若交叉段直接与容器（或过滤类管道）相连，则物品会优先进入该容器，而后才在其他方向中选择。

\image[width=854,height=480,scale=0.6]{neepmeat:guide/images/pipe_junction_priority.png}
\centering{上图：有两处交叉段的管道网络，其一连接至过滤物品管道，其二连接至木桶。弹出器发出的物品会先尝试进入过滤管道，而后才选择其他方向。抵达第二个交叉段时它们也会先尝试进入木桶。}

\image[width=854,height=480,scale=0.6]{neepmeat:guide/images/pipe_storage_line.png}
\centering{上图：受交叉段优先级影响，物品会从左到右依次填充木桶。}
