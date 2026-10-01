---
lookup: neepmeat:storage_bus, neepmeat:pipe_driver, neepmeat:item_requester
id: item_pipe_routing
---

# 高级路由

\columns[fit=second]{管道网络的高级路由功能由管道驱动器提供。该机器会处理管道内物品的寻路，也能管理被延后的物品请求。

同一网络内仅允许存在一台管道驱动器。
}{\item_render{neepmeat:pipe_driver}}

高级路由通常通过*请求*实现。请求由三项信息组成：

- 被请求的物品类型。
- 请求的物品数量。
- 物品的发送目的管道。

部分方块能发出请求，如请求器和PLC（有多种适用指令）。

\columns{\item_render[height=30]{neepmeat:requester}}{\item_render[height=30]{neepmeat:plc}}

## 存储驱动器

\columns[fit=first]{\item_render[height=50]{neepmeat:storage_bus}}{存储驱动器会向网络公开相邻的容器，从而允许远程通过请求抽取其中物品。}

如需容器可被请求访问，就必须令其连接至存储驱动器。

## 手动请求器

手动请求器会在GUI内显示网络中所有可用的物品，也能发起请求将它们发送至自身位置。点击物品会请求一组，Shift点击则会请求一个。

手动请求器还有一个返回槽，它会请求管道驱动器将其中物品存至相连容器中的空位。

\image[width=854,height=480,scale=0.6]{neepmeat:guide/images/pipe_routing_network.png}
上方是一个简单的路由网络，允许对两个容器请求和返回物品。左侧为金属桶，右侧为变容筒仓；两者都通过存储驱动器与网络相连，也即左下角的管道驱动器可以访问它们。

手动请求器（右下）能访问金属桶和变容筒仓的物品栏。收到请求后，管道驱动器会规划从容器到手动请求器的路径，并派发物品。
