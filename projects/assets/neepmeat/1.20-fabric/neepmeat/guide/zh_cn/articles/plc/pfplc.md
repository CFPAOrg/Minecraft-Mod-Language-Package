---
id: pfplc
lookup: neepmeat:pfplc
---

# PFPLC

\centering{*可编程浮点逻辑控制器*}
\centering{*Programmable Floating Point Logic Controller*}

\columns[fit=second]{PFPLC会通过NEEP总线的输入输出执行逻辑和浮点算术。与PLC不同，PFPLC能实时响应输入，却不具备与制造系统直接交互的能力。
它能替换大量红石逻辑元件，也可用于执行复杂的计算。
}{\item_render{neepmeat:pfplc}}

## 语言

PFPLC使用的编程语言相对简单。该语言具备所有基础数学运算符（+ - /）、布尔操作符（and、or、not），也有若干实用的数学函数（min、max、sin、cos、tan）。该语言写就的程序由*语句*——根据其他变量改变某变量值的操作——组成。

```
out0 = 4 * 8
out1 = out1 + 1
```

PFPLC接受中缀表达式，即操作符位于操作数之间。如果你的脑子更习惯Forth，也可使用后缀表达式（即操作符位于操作数之后）。`out0 = min(in0, in1)`合法，`out0 in0 in1 min() =`也合法。

## 变量

PFPLC支持用户自定义的变量，也有用于接受输入和发送输出的特殊变量。

- 开头为`in`的特殊变量（`in0`和`in1`）与PFPLC的NEEP总线输入端口直接相连。

- 开头为`out`的特殊变量（`out0`和`out1`）与PFPLC的输出端口直接相连。在每次扫描周期结束时，输出端口会向NEEP总线网络写出它们的新值。

为变量赋值即是创建新变量。例如，
```
my_var = 1
``` 
会新建一个名为`my_var`的变量，并将其赋为1。

## 扫描周期

在PFPLC程序运行时，输入变量会首先使用NEEP总线端口进行更新，随后会求程序内各语句的值，最后再由输出端口写出新值。这三步合称“扫描周期”。

扫描周期可每隔一定时间开始（若时钟模式设为INT），也可在NEEP总线输入有写入时才开始（若时钟模式设为EXT）。

PFPLC的代码由语句组成。每一条语句都可为*一个*变量赋值。

例如，下方语句会改变`out0`的值。

```
out0 = 2 * in0 + 1
```

## 布尔值

和PLC中的-1不同，PFPLC中“true”的标准值为1。

不过PLC中的规则也部分使用。所有不为0的值均视作“true”，0视作“false”。

数可用`bool`函数转换为相应的布尔值。

```
bool(1234) -> 1
bool(-1) -> 1
bool(0) -> 0
bool(true) -> 1
bool(false) -> 0
```

# 示例

### 求两输入的积

```
out0 = in0 * in1
```

### 计数器

每次扫描周期令out0递增

```
out0 = out0 + 1
```

按下连接至in0的按钮时，令out0递增

```
out0 = out0 + oneshot(in0) * 1

# Reset out0 when another button is pressed [1]
out0 = out0 * !oneshot(in1)
```
 [1] 按下另一个按钮时重置out0

每次in0触发时令out0递增，in1触发时令其递减

```
out0 = out0 + oneshot(in0) - oneshot(in1)
```

### 切换开关

in0触发时切换out0的值。

```
out0 = oneshot(in0) and !out0 or !oneshot(in0) and out0
```

### 正弦波

每次扫描周期中`ctr`都会递增。可用`rad`函数将其转换为弧度值，并用作`sin`的参数。乘以8代表让波的频率变为8倍。
在时钟模式为INT时效果最佳。可通过量表查看输出值。

```
ctr = ctr + 1
out0 = 10 * cos( 8 * rad(ctr))
```
注意，在`ctr`变得非常大时，正弦波会失真。
加入一行

```
ctr = ctr % 360
```
即可让变量在360度后返回0度，从而能让程序持续运行下去，且不损失精度。
