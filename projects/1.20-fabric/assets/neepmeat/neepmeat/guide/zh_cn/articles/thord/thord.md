---
id: thord
---
# Thord

# 栈

THORD的栈操作相较NEEPASM更为简练。

若需将数压栈，直接以文本打出即可。THORD会忽略换行和表达式分隔符，因此同一行内可压入多个数。

来看下面的程序：

```
# Push the numbers 1, 2, 3 and 4 to the stack,
# Add them all together and print
1 2 3 4 + + + .
```

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
# Adds one to the previous stack entry and prints it.
: aword 1 + . ;

# Invoke the word
1 aword
```

# 内联NEEPASM

THORD程序接受内联NEEPASM操作。内联的操作必须位于行首，也可加上`.`前缀。

```
label l

.jmp l ; # valid

jmp l # also valid
```

内联NEEPASM操作参数的读取方法与THORD词不同：遇到行尾或`;`才会结束参数解析。

```
# Inline NEEPASM
robot @(-10 -60 11 U)

# Thord while loop
begin
  # Thord words can be referenced like NEEPASM labels.
  ihandler @(-12 -60 14 U) request
  iwait
-1 # Push -1 (true) to loop endlessly 
until 

# Define the word 'request'
: request
  route @(-12 -60 12 W) @(-10 -60 13 E) "*:stone"  
  .
;
```