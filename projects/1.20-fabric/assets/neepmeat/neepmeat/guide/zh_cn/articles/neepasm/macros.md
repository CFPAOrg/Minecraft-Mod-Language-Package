---
id: macros
---
# 宏

宏是可作为单条指令插入程序的代码段。宏与函数不同；在引用宏时，对应的整段指令会扩展嵌入程序。宏也可接受任意数量的参数，在扩展时用于替换。

宏由`%macro`和`%end`伪指令包起指令段声明：

```
%macro a_macro
    say "This is a macro" # [1]
%end
a_macro  # Expand the macro [2]
```
 [1] "这是一个宏"
 [2] 扩展宏

参数可由宏名后方以空格分隔的列表定义。宏内部可在参量名前加`%`前缀引用其值：

```
%macro a_macro message something_else
    say "The message: %message"  # Replace %message [1]
    say "%something_else"
%end
a_macro Hello there, Something else
```
 [1] 替换`%message`

如上所示，扩展宏时提供的参数需用逗号`,`分隔。如此便可在参量中加入空格。任何文本都可用作宏参数，包括别名。

上方示例的输出如下：
```
The message: Hello there.
Something else
```

## 更复杂的示例

此示例会检查两熔炉输入槽中物品数量是否少于8个。若有其一确实少于，则从输入容器中取出8个物品送至该熔炉。

```
%alias input = @(1 2 1 U)
%alias furn1 = @(1 2 3 U)
%alias furn2 = @(1 2 4 U)
%macro check_furnace furnace
    count %furnace
    push 8; gteq
    bit continue f
    move $input %furnace 8
    continue:
%end
check_furnace $furn1
check_furnace $furn2
restart
```