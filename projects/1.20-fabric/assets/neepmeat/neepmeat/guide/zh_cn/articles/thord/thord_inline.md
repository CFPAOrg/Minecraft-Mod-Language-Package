---
id: thord_inline
---
# 内联NEEPASM

THORD的基础词并未包含所有PLC能执行的操作，因此THORD也可以执行NEEPASM的指令。

此特性可让PLC执行制造操作，如`COMBINE`、`IMPLANT`、`MOVE`等。

内联的操作必须位于行首，或必须加上`.`前缀。

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