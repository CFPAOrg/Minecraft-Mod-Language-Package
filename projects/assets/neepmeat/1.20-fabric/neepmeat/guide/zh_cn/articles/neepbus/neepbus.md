---
id: neepbus
lookup: neepmeat:data_cable, neepmeat:slider, neepmeat:slanted_slider, neepmeat:vertical_gauge, neepmeat:single_button, neepmeat:redstone_transducer
---

# NEEP总线

NEEP总线是一种多控制器串行总线，通过数据线缆连接数个机器即可构成此总线。

总线网络中的机器可根据地址交换整型值，地址需由拉丁字母和数字组成。

NEEP总线可发送数值和字符串信息。

## 描述

数据可在端口间传送，而单个机器可有多个端口。

- 每个端口都有其独属的地址，由拉丁字母和数字组成。
- 输出端口会向地址对应的输入端口传送数据。
- 不同输入端口的地址可以相同，这些端口收到的数据也一致。

机器可有输入端口和输出端口。

- 输入端口可以写入（接收数据）。
- 输出端口可以向输入端口写出（发送数据），也可被读取。

## 读写

与红石不同，NEEP总线中如要传送数据，必须进行读写操作。

比如，玩家更改滑动拉杆的值时，其会向对应目标地址写数据。当网络中新加入同地址端口时，滑动拉杆则不会进行写操作。

# 示例

## 滑动拉杆 -> 红石信号

\image[scale=0.5]{neepmeat:guide/images/neepbus_slider_redstone.png}

此示例中，斜板滑动拉杆在向红石接口发送其值。滑动拉杆会在值变动时向换能器发出消息，换能器随后根据接收的数发出红石信号。

\columns{\item_render[height=30]{neepmeat:slanted_slider}}{\item_render[height=30]{neepmeat:redstone_transducer}}

滑动拉杆的最大值已在其GUI中设为15，其“输出”（Output）地址设为红石换能器“红石写”（Redstone Write）中所设地址。

\image[scale=0.9,width=253,height=58]{neepmeat:guide/images/neepbus_ex1_slider.png}

\image[scale=0.9,width=253,height=58]{neepmeat:guide/images/neepbus_ex1_redstone.png}

\centering{上图：斜板滑动拉杆和红石换能器的地址配置。两方均设为“redstone”。}
