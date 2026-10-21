---
id: distributor_receiver
lookup: neepmeat:distributor_point
---

# 派送接收机

\columns[fit=second]{派送接收机会召唤派送生物体向同频道的其他接收机运输物品和流体。只要发送端处于加载状态，就可以向未加载的区块运输，也可跨维度运输。

派送接收机是活体机器系统的一部分。
}{\item_render{neepmeat:distributor_point}}


## 使用方法

同一活体机器中只可存在1台派送接收机。接收机可配置为发送资源、接收资源，或同时具有两种功能。发送模式下需要机器中包含物品输入端口或流体输入端口，接收模式则要求存在输出端口。

右击接收机可打开配置项GUI：

- 频道：同频道下的接收机可在彼此间收发资源。
- 模式：发送、接收，或同时具有两种功能。
- 冷却：两次收发操作间的等候时间。
- 自动发送：在获得资源时自动发送，或等待NEEP总线信号再发送。

运输时需发送端所处区块处于加载状态。

发送端会检查接收端有无足够容纳物资的空闲空间。

## 必需组件

\columns[fit=first]{\item_render[height=18]{neepmeat:distributor_point}}{派送接收机}
\columns[fit=first]{\item_render[height=18]{neepmeat:fluid_input_port}}{流体输入端口（可选）}
\columns[fit=first]{\item_render[height=18]{neepmeat:item_input_port}}{物品输入端口（可选）}
\columns[fit=first]{\item_render[height=18]{neepmeat:fluid_output_port}}{流体输出端口（可选）}
\columns[fit=first]{\item_render[height=18]{neepmeat:item_output_port}}{物品输出端口（可选）}

# NEEP总线支持

NEEP总线可设置接收机的频道，也可用于触发发送。