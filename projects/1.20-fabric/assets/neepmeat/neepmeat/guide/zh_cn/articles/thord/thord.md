---
id: thord
---
# THORD

THORD是适用于PLC的编程语言，相对于NEEPASM来说较接近高级语言。THORD的语法更为简练，且具有循环和条件语句等结构。

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

NEEPASM中同样功能的程序长成这样：

```
push 1
push 2
push 3
push 4
add
add
add
say
```

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

THORD程序接受内联NEEPASM操作。内联的操作必须位于行首，也可加上`.`前缀。

```
label l

.jmp l ; # valid [1]

jmp l # also valid [2]
```
 [1] 有效
 [2] 同样有效

内联NEEPASM操作参数的读取方法与THORD词不同：遇到行尾或`;`才会结束参数解析。

```
# Inline NEEPASM [1]
robot @(-10 -60 11 U)

# Thord while loop [2]
begin
  # Thord words can be referenced like NEEPASM labels. [3]
  ihandler @(-12 -60 14 U) request
  iwait
-1 # Push -1 (true) to loop endlessly [4]
until 

# Define the word 'request' [5]
: request
  route @(-12 -60 12 W) @(-10 -60 13 E) "*:stone"  
  .
;
```
 [1] 内联NEEPASM
 [2] THORD的while循环
 [3] THORD词可像NEEPASM标签一样引用
 [4] 压入-1（true）以无限循环
 [5] 定义词`request`