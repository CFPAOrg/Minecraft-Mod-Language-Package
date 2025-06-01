---
navigation:
  parent: crazyae2addons_index.md
  title: 显示监视器
  icon: crazyae2addons:display_monitor
categories:
  - Data Variables
item_ids:
  - crazyae2addons:display_monitor
---

# 显示监视器

显示监视器是一类线缆子部件，可放置在ME线缆上，用于展示文本或网络中的变量。它会在变量的值改变时动态更新。

## 使用方法

1. **放置子部件**：将显示监视器放置在ME线缆上。
2. **配置文本**：右击监视器打开其界面，并输入希望展示的文本。
    - 使用`&NAME`引用变量的值。
    - 使用`&nl`换行。
3. **变量链接**：
    - 引用`&NAME`时，显示监视器会自动追踪ME数据控制器中的该变量。
    - 当该变量的值变动时，监视器也会立即更新。
4. **渲染**：显示监视器会缩放字号，以填充空余空间。

显示监视器可用来制造仪表板和数据监视站，也可用动态生成的文本显示信息和装饰ME网络。