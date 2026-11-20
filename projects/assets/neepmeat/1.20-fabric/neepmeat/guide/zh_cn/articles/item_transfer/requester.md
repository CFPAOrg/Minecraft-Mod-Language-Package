---
id: requester
lookup: neepmeat:requester
---

# 请求器

\columns[fit=second]{请求器具有可配置的物品过滤器，可以从管道网络中请求多种匹配的物品。这些物品会被路由至请求器，并从前面主动输出。
}{\item_render{neepmeat:requester}}

## 使用方法

右击请求器可打开其GUI。其中可用标签或物品类型设置过滤器，右侧则可设置请求数量。

如需请求器正常运作，其后面应连接至包含管道驱动器的管道网络。触发请求时，管道驱动器会搜索所有可路由管道（如存储驱动器），并尝试满足该请求。发来的物品会从请求器的前面主动输出。

\columns{\item_render[height=30]{neepmeat:pipe_driver}}{\item_render[height=30]{neepmeat:storage_bus}}

## 控制

请求器可由红石信号触发，也可向其输入端口发送任意信息触发。

NEEP总线输入可通过GUI中的“打开NEEP总线配置”按钮配置。