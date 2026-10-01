---
navigation:
  parent: lua-api/index.md
  title: 预设
  icon: terminal
categories:
  - api_builtin
description: 声明式的builder（importer、stocker），是常见物品移动和补货操作的样板
---

# 预设

预设是声明式的builder，适用于两种经常出现的脚本样板：**将物品从A移动到B**和**补充库存水平**。这两种预设都是链式方法调用，从左往右可直接按照自然语言读出，并用`:start()`结尾以启动。

预设基于现有的脚本API存在。它们也是Lua脚本，也按同样的方式使用卡片和筛选器，也同样会在脚本停止时停止。区别在于，1行预设就相当于大约15行的手动状态追踪scheduler循环。

<LuaCode>
```lua
-- 将农场箱子中的圆石移动到网络存储，每秒一次
importer:from("mobFarm"):filter("$item:cobblestone"):to(network):start()
-- 保证发射器中有64根箭，缺少时自动合成。
stocker:ensure("minecraft:arrow"):to("dispenser"):keep(64):start()
```
</LuaCode>

## 现有预设

* [Importer](importer.md)（导入器）会将物品从任意多个来源移动至任意多个目标。默认模式为填充（填满目标后再继续到下一个）。调用`:roundrobin()`可在目标间轮询。
* [Stocker](stocker.md)（补货器）会按照`:keep(n)`水位线保证目标的库存量，可通过从网络存储中抽取、合成以达成，或两种方法均使用。达到水位线后不再抽取。

## 来源与目标的引用

预设接受三种形式的来源和目标：

1. **string**（字符串）卡片别名：`"bufferChest"`。
2. 来自`network:get(...)`的**CardHandle**。
3. **`network`**&zwnj;全局变量本身，代表“整个网络存储”。

<LuaCode>
```lua
-- 可以混用这三种形式。
importer:from("farm", network:get("secondary"), network)
  :to("output")
  :start()
```
</LuaCode>

卡片解析会在每次网络拓扑改变时进行，因此卡片被取出或同名替换时不会重启预设。预设会静默跳过缺失的卡片，直到它们返回为止。

## 通用方法

所有`ImporterBuilder`和`StockerBuilder`都使用同一种生命周期和控制方法。

### every

<LuaCode>
```lua
ImporterBuilder:every(ticks: number): ImporterBuilder
StockerBuilder:every(ticks: number): StockerBuilder
```
</LuaCode>

设置预设重新运行的频率。默认为20刻（每秒一次）。运行中途改变频率会取消当前的scheduler任务，并按新间隔重新注册，所以`imp:every(5)`会立即生效。

### start / stop / isRunning

<LuaCode>
```lua
ImporterBuilder:start()
ImporterBuilder:stop()
ImporterBuilder:isRunning(): boolean
```
</LuaCode>

`:start()`会注册链式调用并开始计刻。若builder已在运行则相当于无操作，因此重复调用能保证安全。`:stop()`会停止计刻，但能保留所有配置；后续再次使用`:start()`即可恢复同一个链式调用，其中也包括所有轮询目的位置。

<LuaCode>
```lua
local imp = importer:from("src"):to("dst")
scheduler:second(function()
  if someCondition() and not imp:isRunning() then
    imp:start()
  elseif imp:isRunning() and not someCondition() then
    imp:stop()
  end
end)
```
</LuaCode>

## 脚本停止时清理

脚本终端停止时（手动或断开网络），脚本生命周期内注册的所有预设也会自动停止。悬空的builder（即创建后从未`:start()`）也会被清理。再次启动脚本会从头重建所有预设，因此无需在运行间隙更改链式代码时担心垃圾残余。
