---
id: builder
lookup: neepmeat:builder
---

# 建造机器人

建造机器人是能放置和破坏方块的机器人，可受PLC控制。建造机器人需搭载在基站处，基站能访问机器人的物品栏，且会显示其当前选择的槽位。

## 使用方法

可用多种指令控制建造机器人：

- BPLACE
- BBREAK
- SELSLOT
- SELITEM

## 物品栏

建造机器人所破坏方块掉落的物品会直接进入机器人的物品栏。

而在放置方块前，机器人需要知道它应当放置什么方块。

可以用`SELSLOT`和`SELITEM`指令为机器人指定物品栏槽位或特定的物品。

`SELSLOT`接受一个整型值，并让机器人将所选槽位设为该值对应的槽位。

`SELITEM`接受一个字符串，并让机器人仅使用ID匹配该字符串的物品。

## 示例一

此示例中用到了`BPLACE`、`BBREAK`、`SELSLOT`、`SELITEM`。

```
# Select the Builder at coordinates (1, 2, 3) [1]
robot @(1 2 3) 

# Select the first slot [2]
0 selslot

# Place a block [3]
@(2, 2, 3) .bplace

# Break a block [4]
@(2, 2, 3) .bbreak

# Select an item [5]
selitem "minecraft:dirt"

# The pattern string can also be read from the stack: [6]
"minecraft:dirt" .selitem -

# Place a dirt block [7]
@(2, 2, 3) .bplace
```
 [1] 选择坐标(1, 2, 3)处的建造机器人
 [2] 选择第一个槽位
 [3] 放置一个方块
 [4] 破坏一个方块
 [5] 选择一个物品
 [6] 也可从栈中读取匹配模式字符串：
 [7] 放置一个泥土方块

## 示例二

此示例程序会为长方体区域填充泥土。其中，遍历长方体区域用到了`AREA3`指令。

`AREA3`指令会对两角落位置之间的每个方块调用执行地址处的程序。第一个参数为执行地址。第二、第三个参数为角落位置。

```
selitem "minecraft:dirt"

# Create a callback word [1]
# It consumes a world target, and returns nothing. [2]
: callback ( pos -- )
    bplace
    # Discard the result of BPLACE [3]
    drop
;

# Grab the execution address of callback [4]
"callback" '

# First corner [5]
@(0 0 0)

# Second corner [6]
@(10 10 10)
area3
```
 [1] 创建一个回调词（`callback`）
 [2] 它会弹出一个世界目标，且不返回任何东西。
 [3] 丢弃`BPLACE`的返回值
 [4] 获取回调词（即`callback`）的执行地址
 [5] 第一个角落
 [6] 第二个角落