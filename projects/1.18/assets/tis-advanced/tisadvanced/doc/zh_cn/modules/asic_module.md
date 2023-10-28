# ASIC模块

![我还要更多数学！](item:tisadvanced:asic_module)

专用集成电路（Application Specific Integrated Circuit ，缩写为ASIC）模块支持进行一些手动实现太复杂的高级数学运算操作。可用的功能如下所示：

- SIN：正弦（sin）
- COS：余弦（cos）
- TAN：正切（tan）
- SQRT：开平方根
- CBRT：开立方根
- EXP：次方运算
- LN：自然对数（ln）
- HYPT：斜边计算
- ASIN：反正弦（arcsin）
- ACOS：反余弦（arccos）
- ATAN：反正切（arctan）
- SINH：双曲正弦（sinh）
- COSH：双曲余弦（cosh）
- TANH：双曲正切（tanh）

手持此物品并右击可以循环选中下一个功能，潜行右击可以循环选中上一个功能。

若要计算这些功能的输出值，则需要把输入数据写入模块，此时模块会向所有四个端口写入输出数据。一个输出值只会被传输到一个端口。**所有的输入输出值均为IEEE-754半精度浮点数。**

所有的三角函数计算均以角度而不是弧度进行。

对于多参数的功能，例如斜边计算，在所有参数依序写入模块后才可对输出进行读取。
