---
id: phage_ray
lookup: neepmeat:phage_ray, neepmeat:extractor
---

# 吞噬射线炮

\columns[fit=second]{吞噬射线炮能释放出破坏力巨大的光束，可以此迅速摧毁大多数方块。
}{\item_render{neepmeat:phage_ray}}

## 使用方法

吞噬射线炮是一种活体机器组件，因此需要与机器控制器相连才可运作。结构判定有效后，需通过脉管网络提供100eJ/t [注意：可能会更改]。

右击可手动控制射线炮。潜行点击基座可调整范围与NEEP总线配置。

若不附加组件，则射线炮会完全摧毁方块。安装采集提取机可将掉落物送入相连的物品输出端口。安装精准提取机可精准采集方块。

必需组件：

- 吞噬射线炮

可选组件：

\columns[fit=first]{\item_render[height=18]{neepmeat:extractor}}{采集提取机}
\columns[fit=first]{\item_render[height=18]{neepmeat:silky_extractor}}{精准提取机}
\columns[fit=first]{\item_render[height=18]{neepmeat:item_output_port}}{物品输出端口}

# NEEP总线

\columns[fit=second]{吞噬射线炮的瞄准方向和发射状态可通过NEEP总线控制。分别有对应俯仰角、偏航角、发射状态、目标位置的输入端口。
}{\item_render[height=30]{neepmeat:data_cable}}

俯仰角（Pitch）和偏航角（Yaw）端口接受数，单位为角度，分别对应目标角度。

偏航角：0°为北，90°为西，-90°为东。
俯仰角：0°为水平，-90°为垂直向上，90°为垂直向下。

通常而言，相较于手动设置俯仰角和偏航角，使用目标位置（`Target pos`）端口会更便捷。该端口接受包含形式为`@(X Y Z)`坐标的字符串，也即和PLC使用的格式相同。收到数据时，射线炮即会瞄准该位置。

\columns[fit=second]{通过PLC和`AREA3`指令，可让吞噬射线炮自动挖掘大片区域。
}{\item_render[height=30]{neepmeat:plc}}

## 采石场示例

```
# Callback that sends each block position to the phage ray [1]
:noname "target pos" .nbwrite ; ;

# Bounding coordinates [2]
@(1 0 0) @(100 100 100)

# Fire the beam [3]
-1 "fire" .nbwrite

# Run the callback for each block in the region [4]
area3

# Swich off the beam [5]
0 "fire" .nbwrite
```
 [1] 向吞噬射线炮发送方块位置的回调函数
 [2] 角点坐标
 [3] 发射射线
 [4] 对区域内所有方块运行回调函数
 [5] 关闭射线

# 肉质武器模块

吞噬射线炮还有手持式变种。它发射出的光束破坏力较小，可以采集方块，且采集速度可用钻具速度强化器加快。此模块消耗能量弹药。
\columns{\item_render[height=30]{meatweapons:short_phage_ray}}{\item_render[height=30]{meatweapons:phage_ray_speed_modifier}}
