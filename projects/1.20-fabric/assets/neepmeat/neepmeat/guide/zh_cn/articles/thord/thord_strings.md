---
id: thord_strings
---
# 字符串

字符串的压栈操作与整数类似：

```
"I am a string" .
# Prints 'I am a string' [1]
```
 [1] 打印'我是个字符串'

需要注意的是，栈中存储的并不是字符串本身，而是指向PLC随机存取存储器中字符串的指针。栈中所有引用均解除后，相应分配的内存空间会自动释放，因此字符串无需手动释放内存。

# 相关指令

某些指令能区分指针和普通的栈元素，从而改变自身行为。例如，NBWRITE可以发送栈中的整数，也可通过指针发送内存中的字符串，无需修改语法：

```
1234
nbwrite "the address" 

"I am a string"
nbwrite "the address"
```