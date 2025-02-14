---
id: memory
---
# 内存

```
# Put 123 on the variable stack [1]
push 123 

dup; say # 123

# Store the top stack value in memory. [2]
# The address of the stored entry is put on the stack. [3]
store

dup; say # > 1

# Retrieve the value at the address and put it onto the stack. [4]
dup
fetch
swp
free # Free the memory [5]

dup; say # > 123
```
 [1] 将123压入变量栈
 [2] 将栈顶元素存入内存
 [3] 并返回存入位置的地址，压入栈顶
 [4] 取出给定地址处的值，压入栈顶
 [5] 释放内存