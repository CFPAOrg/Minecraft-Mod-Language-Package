---
id: implanter
---
# 植入器

植入器用于为植入对象嵌装植入物。

植入器接受手动控制，也可由PLC自动控制。

手动控制时，植入器无需特殊配套设施。而由PLC控制时，目标实体必须站在手术站上。

## 手动控制

与植入器交互可直接进行操作。可通过正常按键移动植入头。

嵌装时植入头需处于正确的位置。

植入头面向实体时，该实体会被高亮显示，且植入的部位会以十字标记。十字处于植入头摄像头的中央时，即可通过“APPLY”进行嵌装。

\image[width=854,height=480,scale=0.6]{neepmeat:guide/images/implanter_manual.png}
\centering{手动模式下植入器的摄像头界面。}

## PLC自动控制

`IMPLANT`指令专用于自动控制植入器。该指令有两个参数：

1. 取用植入物的物品容器。
2. 目标实体身处的手术台。

示例：

```
# Using aliases for readability [1]
%a input = @(2 3 4) # Input inventory [2]
%a platform = @(3 3 4) # Platform [3]

robot @(1 2 3) # Implanter's position [4]
implant $input $platform
```
 [1] 为可读性考虑，此处使用别名
 [2] 输入容器
 [3] 手术台
 [4] 植入器的位置

\image[width=854,height=480,scale=0.6]{neepmeat:guide/images/implanter.png}
\centering{正在控制植入器的PLC。玩家身处的手术站旁配备了植入物管理器。}
