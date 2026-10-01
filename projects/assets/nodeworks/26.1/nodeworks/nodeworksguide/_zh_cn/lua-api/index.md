---
navigation:
  title: 节点工程脚本API
  position: 40
---

# 节点工程脚本API

<BlockImage scale="6" id="terminal" float="left" />

节点工程使用[Lua](https://www.lua.org/docs.html)作为脚本语言，脚本编辑器还为脚本的编写引入了若干种QoL扩展：

- **类型标注：**&zwnj;（`local x: CardHandle`、`function(xs: { CardHandle }): ItemsHandle`等）
  - 告诉编辑器变量、参数、返回值的类型。如此便可获得准确的悬停提示、更好的自动补全，以及for循环内部的元素类型推断。

## 内置

<CategoryIndexDescriptions category="api_builtin" />

- [clock()]()：脚本开始运行至今的时间，单位为秒的几分之一。
- [print(...)]()：输出至终端输出。
- [require(name)]()：按名称从同一终端的另一个脚本标签页加载脚本。

## 预设

声明式的builder，能将常见的scheduler循环包装成单行的链式调用。通用模式参见[预设](presets.md)。

<CategoryIndexDescriptions category="api_preset" />

## 类型

<CategoryIndexDescriptions category="api_types" />
