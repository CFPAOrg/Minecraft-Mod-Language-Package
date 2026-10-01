---
navigation:
  parent: lua-api/index.md
  title: VariableHandle
  icon: variable
categories:
  - api_types
description: 对网络中<ItemLink id="variable" />的引用
---

# VariableHandle

`VariableHandle`（变量器句柄）是对网络中<ItemLink id="variable" />的引用，由[`network:get(name)`](network.md#get)（与卡片所用的访问端口相同）返回。handle会追踪变量器声明的类型。除去下文的通用核心API外，不同类型的变量还会获得相应的帮助方法。

<BlockImage scale="6" id="variable" />

> **注意：**&zwnj;所有修改操作均为原子操作。对同一个变量器调用的`:set`和`:cas`无法在中途退出。

## 属性

- **`.name`**
  - 变量器的别名（和终端侧边栏中的一致）

## 核心方法

### get / set

获取和设置变量器的当前值。

<LuaCode>
```lua
local myNumericVar = network:get("myNumericVar")
print(myNumericVar:get())
myNumericVar:set(1)
print(myNumericVar:get())
-- "0"
-- "1"
```
</LuaCode>

### cas

比较与交换（Compare-and-swap）。仅在变量器当前值等于`expected`时将其修改为`new`，否则保留当前值不变。成功交换返回`true`，若有其他来源修改了变量器则返回`false`。

每当需要**根据当前值**写入新值时，或会有多个脚本修改变量器时，都应使用此方法。`:set`不会对原值进行判断，相互竞争的两个脚本可能会破坏双方的运行过程。`:cas`只会在原值与预期一致时写入，其他情况均拒绝。

<LuaCode>
```lua
-- 竞标：第一个读到""的脚本获胜
if slot:cas("", "worker_A") then
  print("我抢到了")
else
  print("其他人抢到了")
end
```
</LuaCode>

典型的读取-修改-写入循环中途出现值变动：

<LuaCode>
```lua
-- 仅在>0时递减，遇到竞态条件时重试
while true do
  local current = counter:get()
  if current <= 0 then
    break -- 不需再递减
  end
  if counter:cas(current, current - 1) then
    break -- 成功递减
  end
  -- 其他脚本在:get和:cas之间修改了值，再试一遍
end
```
</LuaCode>

> **注意：**&zwnj;对于算术操作而言，[`increment和decrement`](variable-handle.md#increment--decrement)已经是原子操作了，而且它们更简洁。如果修改操作不只是加减一个数，应使用`:cas`。

### type

以字符串形式返回此`VariableHandle`的“类型”。

- **`NumberVariableHandle`**
  - `"number"`
- **`BoolVariableHandle`**
  - `"bool"`
- **`StringVariableHandle`**
  - `"string"`

<LuaCode>
```lua
local numberVar = network:get("numberVar")
local boolVar = network:get("boolVar")
local stringVar = network:get("stringVar")
print(numberVar:type())
print(boolVar:type())
print(stringVar:type())
-- "number"
-- "bool"
-- "string"
```
</LuaCode>

## BoolVariableHandle

指向声明`bool`（布尔值）变量的<ItemLink id="variable" />的[`VariableHandle`](./variable-handle.md)。追加了仅适用于布尔值变量的方法。

### toggle

翻转当前值（`true`变为`false`，`false`变为`true`）并返回新值。

<LuaCode>
```lua
local lights = network:get("lights")
print(lights:get())
lights:toggle()
print(lights:get())
-- "false"
-- "true"
```
</LuaCode>

> **注意：**&zwnj;可用作经由[`RedstoneCard:onChange`](./card-handle.md#onchange)接至红石按钮的“按下以切换”操作。

### tryLock / unlock

复用为互斥锁的布尔值变量。`:tryLock()`会将变量从`false`原子地改为`true`，成功时返回`true`。若变量已经是`true`（有其他脚本锁定），则返回`false`，**且不进行锁定**。`:unlock()`可将其改回`false`。

<LuaCode>
```lua
local mutex = network:get("job_mutex") -- 布尔值变量
if mutex:tryLock() then
  -- 干活
  mutex:unlock()
end
```
</LuaCode>

> **重要：**&zwnj;若互斥锁已所得，`:tryLock`不会进行等待，而是会立即返回`false`。后续行为——无论是间隔一段时间再尝试（[`scheduler:delay`](scheduler.md#delay)），或是直接跳过执行——都需由脚本本身实现。
>
> 成功执行的`:tryLock`须与`:unlock`配对。临界区应如上方示例由`pcall`包起，这样代码出错时便不会死锁。

## NumberVariableHandle

指向声明`number`（数）变量的<ItemLink id="variable" />的[`VariableHandle`](./variable-handle.md)。追加了仅适用于数变量的方法。

### increment / decrement

对变量当前值进行加法或减法。两方法均需接受一个量，且均会返回新值。

<LuaCode>
```lua
local counter = network:get("counter")
counter:set(0)
counter:increment(1) -- +1 -> 1
counter:increment(5) -- +5 -> 6
counter:decrement(2) -- -2 -> 4
```
</LuaCode>

### min / max

- `:min(n)`将变量设为当前值和`n`之间的较小值。
- `:max(n)`设为较大值。

两方法均会返回新值。

<LuaCode>
```lua
local best = network:get("best_score")
best:set(42)
best:max(50) -- 42 vs 50 -> 50（新较大值）
best:max(35) -- 50 vs 35 -> 50（不变）
best:min(10) -- 50 vs 10 -> 10（新较小值）
```
</LuaCode>

## StringVariableHandle

指向声明`string`（字符串）变量的<ItemLink id="variable" />的[`VariableHandle`](./variable-handle.md)。追加了仅适用于字符串变量的方法。

### append / length / clear

- `:append(str)`将`str`接到当前值后方，返回新字符串。
- `:length()`返回当前值中字符串的数量。
- `:clear()`清空变量（设为`""`）。

<LuaCode>
```lua
local log = network:get("log")
log:clear()
log:append("开头 ")
log:append("中间 ")
log:append("结尾")
print(log:get())
print(log:length())
-- "开头 中间 结尾"
-- 16
```
</LuaCode>