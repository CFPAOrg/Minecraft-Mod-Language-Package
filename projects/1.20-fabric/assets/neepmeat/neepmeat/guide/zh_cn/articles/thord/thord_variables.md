---
id: thord_variables
---
# 变量

变量可使用`VARIABLE`词创建。

引用变量的名称会将其地址压栈。任意词均可将此地址用作参数。

- `!`可将栈顶往下第二元素的值存入栈顶变量。
- `@`可获取变量的值。
- `?`可打印变量的值。
- `+!`可将栈顶往下第二元素的值加至变量。

示例

```
# Create the variable [1]
variable count

# Print the variable's address [2]
count .

# Assign 123 to the variable [3]
123 count !

# Add 1 to the variable [4]
1 count +!

# Print the variable's value [5]
count @ .

# Shorthand for @ . [6]
count ?
```
 [1] 创建变量
 [2] 打印变量的地址
 [3] 将123赋值给变量
 [4] 向变量加1
 [5] 打印变量的值
 [6] `@ .`的简写

# 数组

数组由词`ARRAY`创建。

引用数组的名称会将其首元素的地址压栈。后继各元素的值可由地址递增接`@`获取。

```
# Create an array with 5 elements [1]
array a 5

# Value to put in the array [2]
123

# Get the address of the second element [3]
a 1 + 

# Store it [4]
!
```
 [1] 创建包含5个元素的数组
 [2] 要存入数组的值
 [3] 获取数组第二个元素的地址
 [4] 存储操作

数组和匿名词有许多有意思的功用。下方的程序向数组存入了三个匿名词的地址，而后即遍历各元素并执行各词。

```
# Create an array of three elements [1]
array a 3

# Count represents the current element of the array to fill [2]
variable count

# Create a noname word [3]
:noname 
  .say "Look at me" ; 
; 

# Stored it using a word we defined [4]
sto

# More compact syntax for the same thing [5]
:noname .say "I'm a word" ; ; sto
:noname .say "Boiled in oil" ; ; sto

# Values of i: 0 1 2 [6]
3 0 for 
  # Get the value at i [7]
  i at execute
loop 

# Stores top stack entry in the array and increments count. [8]
: sto ( addr -- )
  count @ a + ! 
  1 count +!
;

# Retrieves the element at idx [9]
: at ( idx -- addr ) 
  a + @ 
;
```
 [1] 创建包含3个元素的数组
 [2] `count`代表当前应操作数组的哪个元素
 [3] 创建一个匿名词
 [4] 用自定义的词进行存储
 [5] 功能相同，而语法更紧凑的写法
 [6] `i`的值分别为：0、1、2
 [7] 获取`i`处的值
 [8] 将栈顶元素存入数组，并递增`count`
 [9] 读取索引为`idx`的元素