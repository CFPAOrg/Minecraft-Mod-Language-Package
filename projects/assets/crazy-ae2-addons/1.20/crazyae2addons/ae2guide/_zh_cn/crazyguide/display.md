---
navigation:
  parent: crazyae2addons_index.md
  title: 显示屏
  icon: crazyae2addons:display
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:display
---

# 显示屏

**显示屏**是能显示文本、图片、物品/流体图标、ME网络实时数据的线缆子部件，放在总线上即可运作。

它可以用作标记、存储计数器、机器状态面板、产线监测器，以及横跨整面墙的大型仪表板。相邻的显示屏可以合并成同一块大屏。

---

## 放置

将显示屏放在AE2线缆的任意一面上。

如需在显示屏中显示网络实时数据，应为其预留一个ME网络频道。无频道时，文本和图片依然可以正常渲染，但库存量和差值均会显示为0。

放在地板和天花板上时，显示屏的朝向会跟随玩家放置时的朝向。

---

## 交互

右击显示屏可打开其GUI。

合并模式启用时，右击可编辑整块合并显示屏。

Shift+右击则可仅打开所选显示屏部件的GUI。

---

## 文本

显示屏支持多行文本和基础格式。

示例：

# 标题

**粗体**

*斜体*

__下划线__

~~删除线~~

可用GUI中的等宽格式按钮渲染等宽文本。

还可用十六进制格式为文本上色：

&cFF0000Red text

Normal &c00FF00(green word) normal

---

## ME实时数据

可用组件符在显示屏中显示ME网络的实时数据。

通常来说，不需要直接打出组件符——用显示屏GUI中的组件符构造器插入即可。

组件符构造器可以插入：

- 库存量统计
- 产出/消耗速率统计
- 物品和流体图标

示例：

&i^item:minecraft:diamond Diamonds: &s^minecraft:diamond

Iron/min: &d^minecraft:iron_ingot%1m@5m

库存量组件符以&s^起始。

差值/速率组件符以&d^起始。

图标组件符以&i^起始。

---

## 图片

可以用显示屏GUI中的图片按钮打开图片菜单。

可在其中上传PNG，并在显示屏中设定它们的位置和尺寸。

图片的渲染图层在文本之下，也即，可将图片作为背景、徽标、图标，或者只单纯用作装饰。

---

## 合并模式

合并模式启用后，位于同一平面、朝向相同的相邻显示屏会自动合并为一整块大屏。

右击可编辑整块合并显示屏。

Shift+右击可仅编辑所选的显示屏部件。

无缺角和突出部的长方形合并显示屏显示效果最好。

如需让显示屏保持独立，无论它是否与其他显示屏接触，则可以禁用其合并模式。

---

## 示例

### 简易库存量统计

&i^item:minecraft:diamond 钻石：&s^minecraft:diamond

&i^item:minecraft:iron_ingot 铁：&s^minecraft:iron_ingot

### 产量统计

# 工厂加工线A

铁/min：&d^minecraft:iron_ingot%1m@5m

铜/min：&d^minecraft:copper_ingot%1m@5m

### 库存量仪表板

# 库存状态

| 资源                            | 库存量                  |
| ------------------------------- | ----------------------- |
| &i^item:minecraft:diamond 钻石  | &s^minecraft:diamond    |
| &i^item:minecraft:iron_ingot 铁 | &s^minecraft:iron_ingot |
| &i^fluid:minecraft:lava 熔岩    | &s^fluid:minecraft:lava |

---

## 提示

- 优先使用组件符构造器，不推荐手动打出。
- 状态仪表大屏需启用合并模式。
- 如只需编辑一块显示屏，应使用Shift+右键。
- 实时值如显示0，需检查该显示屏是否有频道可用。