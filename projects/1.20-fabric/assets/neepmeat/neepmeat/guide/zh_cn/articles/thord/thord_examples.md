---
id: thord_examples
---
# 通用

## 变量

```
variable v

# Assign [1]
123 v !

# Get and print [2]
v @ .
```
 [1] 赋值
 [2] 读取并打印

## 斐波那契数列

```
: fibonacci
  0
  0 1
  2swp
  
  do
    dup
    rot
    add
    dup .
  loop

  2drop
;

100 fibonacci
```

# 物流

## 等待某容器中的10个骨头

```
begin
    delay 10
    count @(1 2 3 U) "minecraft:bone"
    10 <= invert 
until
    say "done"
```

## 等待某容器中一定数量的某物品的宏

```
%: wait_item container item amount
begin
    count %container %item
    %amount <= invert
until
%;

wait_item @(1 2 3 U), "minecraft:bone", 10
;
```

# 编译时词

## 定义if-else

THORD的编译时执行功能可用于自定义流程控制结构。

下方的程序展示了THORD中if-else-then结构的实现方法。

```
:i pcphead
  postpone cphead ;
;

:i if1
  postpone cphead blank ; # bif placeholder [1]
;

:i endif1
  dup -1 = .bif ifend ; # -1 indicates else [2]
  label ifelse
    drop # get rid of -1 [3]
    postpone cphead ; 
    - dup neg 
    postpone cpjmp ;
    .jmp end f ;
  label ifend
    postpone cphead ; 
    - dup neg 
    postpone cpbif ;
  label end 
;

:i else1
  postpone cphead ;
  - dup neg .inc ; 
  postpone cpbif ; # backpatch bif [4]
  postpone cphead blank ; # jmp placeholder [5]
  -1 # tell then to backpatch jmp [6]
;

# Test the words [7]
1
if1
  .say "yes" ; 
else1
  .say "no" ;
endif1
```
 [1] `bif`占位
 [2] -1代表跳转到else
 [3] 删除-1
 [4] 回填`bif`
 [5] `jmp`占位
 [6] 让then部分回填`jmp`
 [7] 测试词