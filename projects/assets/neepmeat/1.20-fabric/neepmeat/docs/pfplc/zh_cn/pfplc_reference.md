\cat{utility}
# 实用

\cat{maths_operators}
# 数学运算符

## +-*/ 

加法、减法、乘法、除法运算符。遵守优先级。括号内的表达式优先求值。

```
(1 + 1) * 10 / (13 - 3)
```

## %

取模运算符。以第二参数除第一参数，返回所得余数。

结果的符号与除数保持一致。

```
13 % 10 -> 3
-13 % 10 -> 7
13 % -10 -> -7
-13 % -10 -> -3
```

## ==

检验两值是否相等。

```
4 == 4 -> true
```

## != 

检验两值是否不等。

## <

检验第一个值是否小于第二个值。

## >

检验第一个值是否大于第二个值。

## <=

检验第一个值是否小于等于第二个值。

## >=

检验第一个值是否大于等于第二个值。

\cat{logical_operators}
# 逻辑操作符

## and

检验两参数的值是否均为true。

```
true and true -> true
false and true -> false
```

## or

检验两参数的值中是否至少有一个为true。

```
true and true -> true
false and true -> true
false and false -> false
```

## !

将参数所对应的布尔值取反。

```
!true -> false
!false -> true
```

## bool(x)

求x的布尔值（0为false，-1为true）。

0对应false，所有不为0的数均对应true。

## unbool(x)

求x的布尔值，但随即会将false转换为-1，true转换为1。

可用于根据开关位置递增或递减计数器。

```
bool(123) -> 1
bool(0) -> 0
bool(-1) -> 1
```

\cat{special_functions}
# 特殊函数

## oneshot(x)

在上一次扫描周期至这一次之间，若变量x被NEEP总线输入写入，*且*x求值为true，则返回true。

x必须为变量名。

```
# Toggle the value of out0 each time in0 is triggered. [1]
out0 = oneshot(in0) and !out0 or !oneshot(in0) and out0
```
 [1] 每次in0触发时切换out0的值。

## trigger(x)

与oneshot类似，但不关心变量的值。无论变量的值如何，只要自上一次扫描周期以来该变量被外部源改变，即会返回true。

## rising_edge(x)

上一次扫描周期中x为false，这一次为true时，返回true。

# 特殊变量

## dt

特殊变量，其值为自上一次扫描周期至今的刻数。

## clk_int

PFPLC是否为内部时钟模式。更改此变量的值可动态切换时钟模式。

- true：时钟模式为INT
- false：时钟模式为EXT


\cat{maths_functions}
# 数学函数

## max(x, y)

返回两参数中的较大者。

## min(x, y)

返回两参数中的较小者。

## clamp(x, min, max)

将x夹断在min和max之间。与`min(max(x, min), max)`等价

## abs(x)

返回x的绝对值。

```
abs(-1) -> 1
abs(1) -> 1
```

## floor(x)

向下将x舍入至最近的整数。

```
floor(0.5) -> 0
```

## ceil(x)

向上将x舍入至最近的整数。

```
ceil(0.5) -> 1
```

## sin(t)

计算所给角的正弦值。单位为弧度。

```
sin(pi/2) -> 1
```

## cos(t)

计算所给角的余弦值。单位为弧度。

```
cos(pi/2) -> 0
```

## tan(t)

计算所给角的正切值。单位为弧度。

```
cos(pi/2) -> Infinity
```

## asin(x)

计算x的反正弦角。

## acos(x)

计算x的反余弦角。

## atan(x)

计算x的反正切角。

## atan2(x, y)

返回x轴与原点至(x, y)射线的夹角。大致与`atan(x / y)`等价。

在将笛卡尔坐标转换至极坐标时非常实用。

## rad(x)

将x从角度转换为弧度。

## deg(x)

将x从弧度转换为角度。

## pow(x, exponent)

求底数为x，指数为exponent的幂。

```
pow(2, 2) -> 2*2
pow(2, 3) -> 2*2*2
```

## log(x)

计算x的自然对数。

## log10(x)

计算x以10为底的对数。

## sqrt(x)

计算x的平方根。