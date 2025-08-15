---
id: thord_constructs
---
# 程序结构

## IF-ELSE-THEN

THORD中的条件操作较NEEPASM来说更加集成简练。

`IF`会弹出栈顶元素。若为true（非0），则继续执行；否则便会跳转到后方`ELSE`或`ENDIF`第一次出现的位置。

if结构必须以`ENDIF`或`THEN`结束。

```
-1 # -1 is true [1]
if
    say "yes"
endif
```
 [1] -1为true

`ELSE`可用来构建条件为false时执行的分支。

```
0
if
    say "yes"
else
    say "no"
endif

```

## BEGIN-UNTIL（while循环）

begin-until结构类似于C系语言中的while循环：它会在条件为true时重复执行代码段。

```
begin
    say "loop"
# -1 means true [1]
-1 until
```
 [1] -1为true

## DO-LOOP（for循环）

do-loop结构近似于C系语言的for循环：它会执行代码段若干次。

`DO`需要两个参数：循环的次数、循环索引的初值。这两者会存储在控制栈中，而非数据栈。

词`I`会将循环索引复制到栈顶。

`LOOP`会让循环索引增加1；若循环索引小于循环次数，还会让程序跳转到循环段的开始处。

```
10 0 do i . loop
# prints 0 1 2 3 4 5 6 7 8 9 [1]
```
 [1] 打印“0 1 2 3 4 5 6 7 8 9”

`LOOP`处也可换用`+LOOP`，此时循环索引的递增步长为栈顶元素。

```
10 0 do i . 2 +loop
# prints 0 2 4 6 8 [1]
```
 [1] 打印“0 2 4 6 8”