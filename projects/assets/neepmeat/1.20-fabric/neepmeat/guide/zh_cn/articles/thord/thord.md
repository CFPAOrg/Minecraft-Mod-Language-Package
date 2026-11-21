---
id: thord
---

# THORD

THORD是适用于IMC的编程语言，相对于NEEPASM来说较接近高级语言，但仍可使用所有NEEPASM指令。THORD的语法更为简练，且具有循环和条件语句等结构。

# 栈

THORD的栈操作比NEEPASM更简单。

若需将数压栈，可直接以文本打出。THORD不会区分换行和表达式分隔符，因此同一行内可压入多个数。

来看下面的程序：

```
# Push the numbers 1, 2, 3 and 4 to the stack, [1]
# Add them all together and print [2]
1 2 3 4 + + + .
```
 [1] 将数1、2、3、4压入栈顶，
 [2] 求总和并打印

# 词

词是THORD的函数，其中包含可重用的操作序列。

词的定义以`:`起始，后方跟随词名。词的定义以`;`结束。

```
# Adds one to the previous stack entry and prints it. [1]
: aword 1 + . ;

# Invoke the word [2]
1 aword
```
 [1] 将栈顶元素加1并打印
 [2] 调用词

# 内联NEEPASM

THORD接受内联NEEPASM指令，也即所有IMC的制造指令均可使用。这些指令不是常规词，需要前接“.”。在行首时该符号可省略。

```
# Valid THORD [1]
1 1 + .
combine @(1 2 3 U) @(4 5 6 D)
.combine @(2 2 3 U) @(4 5 6 D)
```
 [1] 合法的THORD
