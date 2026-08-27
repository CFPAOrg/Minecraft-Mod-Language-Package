---
navigation:
  parent: items-blocks/index.md
  icon: variable
  title: 变量器
categories:
  - device
description: 网络范围内共享的变量
item_ids:
- nodeworks:variable
---

# 变量器

变量器用于容纳整个网络共享的值。

<BlockImage scale="6" id="variable" />

## 配置

将变量器接至网络后，可选择其**类型**，并为其**命名**。这两者在<ItemLink id="terminal" />中寻找变量器时都非常有用。

![](../assets/images/variable_gui_count.png)

此情况下，保存的是名为`count`的**number**。

打开同网络的任意<ItemLink id="terminal" />时，侧边栏即会显示该变量，以供引用。

![](../assets/images/variable_in_terminal.png)

### 类型

- **number**（数）
  - 数值（整数或小数）
- **string**（字符串）
  - 任意最长256字符的文本
- **boolean**（布尔值）
  - `true`或`false`

## 频道

变量器GUI中有名称和频道的设定器。有关频道限制脚本能否访问设备的详情，参见[选择频道](../lua-api/channel.md#选择频道)。

## 脚本

脚本API参见[VariableHandle](../lua-api/variable-handle.md)页面。

## 配方

<RecipeFor id="variable" />