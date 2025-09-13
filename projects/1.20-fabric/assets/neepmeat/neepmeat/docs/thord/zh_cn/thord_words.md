\cat{utility}
# 实用

## . ( n1 -- )

打印栈顶元素。

## PC ( -- n1 )

将程序计数器（当前所执行指令的地址）的当前值压入栈顶。

\cat{words}
# 词

## : 

用于新起一项词的定义。`:`后方的字符串即是词名。

```
: aword 123 . ;
```

## :I

用于新起一项立即词的定义。`:I`后方的字符串即是词名。

```
:I aword 123 . ;
```

## ; 

用于结束多种结构体：

- 词的定义
- 立即词的定义
- 内联NEEPASM指令

## :NONAME

用于新起一项匿名词的定义。定义结束时向栈压入该词的地址。

```
:noname 123 . ;

execute
```

\cat{stack}
# 栈

## DUP ( n1 -- n1 n1 )

复制栈顶元素。与NEEPASM的`DUP`等价。

## 2DUP ( n1 n2 -- n1 n2 n1 n2 )

复制栈顶的两个元素。与`OVER OVER`等价。

## SWP ( n1 n2 -- n2 n1 )

交换栈顶两元素。与NEEPASM的`SWP`等价。

## 2SWP ( n1 n2 n3 n4 -- n3 n4 n1 n2 )

交换栈顶的两对元素。

## PICK ( x -- nx )

将栈顶往下第x个元素复制到栈顶。与NEEPASM的`PICK`等价。

## OVER ( n1 n2 -- n1 n2 n1 )

将栈顶往下第二元素复制到栈顶。与NEEPASM的`OVER`等价。

## 2OVER ( n1 n2 n3 n4 -- n1 n2 n3 n4 n1 n2 )

将栈顶往下第二对元素复制到栈顶。

## ROT ( n1 n2 n3 -- n2 n3 n1 )

将栈顶往下第三元素移动到栈顶。与NEEPASM的`ROT`等价。

## DROP ( n1 -- )

移除栈顶元素。与NEEPASM的`POP`等价。

## 2DROP ( n1 n2 -- )

移除栈顶的两个元素。

## BLANK ( -- )

\cat{return_stack}
# 返回栈

## >R ( n1 -- ) (R: -- n1 )

将栈顶元素移动到返回栈栈顶。

## 2>R ( n1 n2 -- ) (R: -- n1 n2 )

将栈顶的两个元素移动到返回栈栈顶。

## R> (-- n1 ) (R: n1 -- )

将返回栈栈顶元素移动到数据栈栈顶。

## 2R> (-- n1 n2 ) (R: n1 n2 -- )

将返回栈栈顶的两个元素移动到数据栈栈顶。

## R@ ( -- n1 ) (R: n1 -- n1 )

将返回栈栈顶元素复制到数据栈栈顶。

\cat{flow_control}
# 流程控制

## END ( -- )

发出用于终止执行的END指令。适合用作占位和回填。与NEEPASM的`END`等价。

## IF ( n1 -- )（立即词）

根据条件跳转到下一个`ELSE`或`THEN`。

```
1 if 
    say "yes"
else
    say "no"
endif
```

## ELSE ( -- )（立即词）

`IF`的参数为false时跳转的目的分支。

## ENDIF ( -- )（立即词）

结束if和if-then结构。

## THEN ( -- )（立即词）

与`ENDIF`相同。

## BEGIN ( -- )（立即词）

标记begin-until结构的起始。

```
begin
    say "loop forever" # [1]
1 until
```
 [1] "死循环"

## UNTIL ( n1 -- )（立即词）

标记begin-until结构的结束。会取走栈顶元素，若为true则跳转至上一个`BEGIN`。

## FOR ( n1 n2 -- )（立即词）

标记do-loop结构的起始。该结构以`LOOP`或`+LOOP`结束。

会检查n1与n2相等与否，若相等则跳转至循环结束处；否则将值移动至返回栈并进入循环。

下方代码段中的循环索引从n2起始，此后进入循环，并在索引达到n1时结束循环。

```
10 0 do i . loop
```

## LOOP ( -- )（立即词）

令循环索引递增，若运算结果小于上界则跳转至循环起始处。

## +LOOP ( n1 -- )（立即词）

将栈顶元素加至循环索引，若运算结果小于上界则跳转至循环起始处。

```
10 0 do i . 2 +loop
```

## I ( -- n1 )

将循环索引复制到数据栈。此实现中与`R@`功能一致。

\cat{arithmetic}
# 算术

## + ( n1 n2 -- 结果 )

求栈顶两元素的和。与NEEPASM的`ADD`等价。

## - ( n1 n2 -- 结果 )

求n1减去n2的差。与NEEPASM的`SUB`等价。

## * ( n1 n2 -- 结果 )

求n1与n2的积。与NEEPASM的`MUL`等价。

## / ( n1 n2 -- 结果 )

求n1除以n2的商。与NEEPASM的`DIV`等价。n2为0时所得结果会失常。

## NEG ( n1 -- 结果 )

求栈顶元素的相反数。

## INVERT ( n1 -- 结果 )

将栈顶元素各位取反。

\cat{comparison}
# 比较

## = ( n1 n2 -- 结果 )

检查n1与n2是否相等。判断为true返回-1，为false返回0。与NEEPASM的`EQ`等价。

## < ( n1 n2 -- 结果 )

检查n1是否小于n2。与NEEPASM的`LT`等价。

## < ( n1 n2 -- 结果 )

检查n1是否大于n2。与NEEPASM的`GT`等价。

## <= ( n1 n2 -- 结果 )

检查n1是否小于等于n2。与NEEPASM的`LTEQ`等价。

## >= ( n1 n2 -- 结果 )

检查n1是否大于等于n2。与NEEPASM的`GTEQ`等价。

\cat{memory}
# 内存

## VARIABLE ( "名称" -- )

分配一个新变量，并取该词后方的名称为变量名。

以变量名进行调用时会将其地址压栈。

```
variable v

# Store 123 [1]
123 v !

v ? # result: 123 [2]
```
 [1] 存储123
 [2] 结果：123

## ARRAY ( "名称" 大小 -- )

分配一个新数组，取后方的名称为数组名，大小为数组大小。

需注意，大小参数需在词后方，而不是前方。数组内所有元素初始化为0。

```
# Create an array of 6 elements [1]
array a 6

# Set the third element to 123 [2]
123 a 2 + !

# Print the third element [3]
a 2 + ?
```
 [1] 创建包含6个元素的数组
 [2] 将第三个元素设为123
 [3] 打印第三个元素

## ! ( n1 地址 -- )

将n1存入所给地址。

## @ ( 地址 -- n1 )

读取所给地址处的数据。

## ? ( 地址 -- )

打印给定地址处的数据。与`@ .`等价。

## ' ( "词" -- 地址 )

将本词后方的词的地址压栈。

```
: aword 1 + . ;

# Print the word's address [1]
' aword .
```
 [1] 打印词的地址

## EXECUTE ( 地址 -- )

跳转到给定地址处的指令。与NEEPASM的`CALL`等价。

\cat{compiler_words}
# 编译器词

## CPHEAD ( -- 头部 )

将已发出的指令数目压栈。返回值与下一次所发出指令的索引相同。

## CPJMP ( 偏移 跳转 -- )

在距当前头部位置n1偏移量处发出一个`JMP`指令。指令的参数为n2。

## CPBIF ( 偏移 跳转 -- )

在距当前头部位置n1偏移量处发出一个`BIF`指令。指令的参数为n2。

## CPBIT ( 偏移 跳转 -- )

在距当前头部位置n1偏移量处发出一个`BIT`指令。指令的参数为n2。
