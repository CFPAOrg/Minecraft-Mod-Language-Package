---
id: thord_macros
---
# THORD中的宏

宏与普通词和立即词不同，其会在解析前就展开。宏可用来替换任意文本，且不产生运行时开销。

宏的定义以`%:`起始，后方跟随宏名。宏的定义以`%;`结束。

```
%: macro1 r1
    1 2 3 %r1 + + +
%;

macro1 4
.
# 1+2+3+4
```

## 参数

参数可由宏名后以空格分隔的列表定义。宏内部可在参量名前加`%`前缀引用参数。

扩展宏时提供的参数需为逗号分隔的列表。参数中允许出现空格。

```
:% macro1 arg1 arg2
    say %arg1
    %arg2
%;

# Any text can be passed as an argument.  [1]
macro1 "something to say", 123 .
```
 [1] 任何文本都可作为参数

## 扩展

扩展宏，即是直接将宏嵌入到源代码中。

```
%: macro1
    1 + .
%;

1
macro1
```

等价于：

```
1
1 + .
```

## 复杂示例

此示例会保证所有目标方块均各有多于8个物品。

```
%: check side 
  count %side
  8 <
  if
    move @(-28 -60 -20 U) %side 8
  endif
%;

robot @(-27 -60 -18 U)

begin
  check @(-28 -60 -16 N)
  check @(-27 -60 -16 N)
  check @(-26 -60 -16 N)
  
  delay 20
-1 until
```