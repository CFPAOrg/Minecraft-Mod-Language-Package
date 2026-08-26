---
id: thord_data_types
---

# THORD中的数据类型

PLC的栈能存储多种类型的数据。部分类型的数据可在特殊词的作用下转换为其他类型。

## INT

代表一个整数，如0、1、-1。该类型也用于表示布尔值，其中-1为TRUE，0为FALSE。

转换词：

- `>STR`（转换为字符串）

常用操作符：

```
# Add and subtract [1]
1 1 + # Gives 2 [2]
1 1 - # Gives 0 [3]

# Multiply and divide [4]
2 10 * # Gives 20 [5]
10 5 / # Gives 2 [6]
```
 [1] 加法和减法
 [2] 返回2
 [3] 返回0
 [4] 乘法和除法
 [5] 返回20
 [6] 返回2

## STRING

表示一个字符序列，如“hello”或“how are you”。

转换词：

- `>INT`（转换为整型，字符串若和整数不够相似则会产生错误）

数学操作符：

```
# Add (concatenate) [1]
"Hello " "there." + # Gives "Hello there." [2]
```
 [1] 加法（拼接）
 [2] 返回"Hello there."

## WORLD_TARGET

表示一个世界目标，由位置坐标和方向组成。

部分指令（如`BPLACE`和`BBREAK`）可从栈中取出世界目标，其他大多数与世界交互的指令则不会。

转换词：

- `>STR`（转换为字符串）

数学操作符：

```
# Multiply and divide by integer [1]
@(1 2 3) 10 * # Gives @(10 20 30) [2]

# Add and subtract [3]
@(1 2 3) @(10 10 10) + # Gives @(11 12 13) [4]
```
 [1] 乘以或除以整数
 [2] 返回@(10 20 30)
 [3] 加法和减法
 [4] 返回@(11 12 13)

## ADDRESS

转换词：

- `>STR`（转换为字符串）


数学操作符：

- 与INT一致。