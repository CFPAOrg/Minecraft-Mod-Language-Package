---
id: word_definition
---
# THORD词的定义

THORD中的词相当于其他语言的函数。大多数字符序列均是有效的词名。

词的定义以“:”起始，后方跟随词名。词的定义以“;”结束。

```
# Adds one to the previous stack entry and prints it.
: aword 1 + . ;

# Definitions can span multiple lines
: another
  2
  +
  .
;

# Invoke the word
1 aword
1 another
```

词会从栈中获取参数，且可以直接通过压栈的方式返回多个值：

```
: dupadd1 ( n1 -- n1 n2 ) 
    dup 1 + 
;

123 dupadd1 . .
# 123 124
```

词名后还可附带以圆括号（“()”）包起的注释，以标记词对栈的操作效果。

格式为：“( 取自栈的元素 -- 压入栈的元素 )”。

有多个栈元素参与的情况下，右侧为栈顶方向：

( n1 n2 n3 -- )
 n1 n2 n3 <- 栈顶

```
# Takes two elements and returns one
: sum ( n1 n2 -- sum )
    +
;

1 2 sum .
```

# 立即词

立即词可用来修改编译器的状态，也可用作宏。编译器在遇到立即词时会立刻进行调用。

立即词的定义以“:i”起始，以“;”结束。

```
# This will push 123 to the COMPILER'S data stack.
:i imm1 123  . ;

: word1 imm1 ; 

# Does nothing as imm was invoked during compilation
word1
```

# 延迟（POSTPONE）

延迟（POSTPONE）指令需在立即词内使用，代表其后续的词序列应在运行时编译执行，而非在编译时即执行。

延迟的作用范围自它自身起始，并在其后第一个“;”前结束。

可借此编写宏，以规避普通词的（微量）运行时开销。

```
# This will push 123 to the PLC'S data stack.
:i imm2 postpone 123 ; ;

: word2 imm2 ;

# Pushes 123 and prints it at runtime
word2
```