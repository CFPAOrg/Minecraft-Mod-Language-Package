---
navigation:
  parent: crazyae2addons_index.md
  title: 显示屏数据库
  icon: crazyae2addons:me_display_database
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:me_display_database
---


# ME显示屏数据库

**ME显示屏数据库**能存储文本值及其名称，以供显示屏使用。

同一ME网络下的所有数据库共享值，在显示屏中使用简单的组件符即可调用，如&status、&fuel_name、&storage_pct等。

---

## 使用方法

将方块连接至ME网络，右击打开数据库GUI。

在其中添加键值对：

| 键          | 值       |
| ----------- | -------- |
| status      | 正在运作 |
| fuel_name   | 柴油     |
| storage_pct | 82.50    |

在键前加上&，即可在显示屏中显示其值：

状态：&status
燃料：&fuel_name
存量：&storage_pct%

---

## 网络行为

同一个ME网络共享其中所有的数据库。

网络合并时，两者数据库的值也会合并。若后续连入了较老的数据库，合并过程中即有可能返回其中的值。

若网络中没有ME显示屏数据库，数据库组件符便不会解析。

---

## ComputerCraft

安装有CC:Tweaked时，此方块也可用作外设：

local db = peripheral.find("crazyae2addons:me_display_database")
db.add("status", "Running")
db.add("fuel_name", "Diesel")
print(db.list().status)
db.remove("status")

方法：

| 方法            | 描述           |
| --------------- | -------------- |
| add(key, value) | 新增或更新值。 |
| remove(key)     | 移除一个值。   |
| list()          | 返回所有值。   |

---

## 配置

此特性可在通用配置中禁用。

禁用后，数据库的GUI便无法打开，数据库组件符也不会进行解析，且ComputerCraft方法会失效。

---

## 提示

若有值无法使用常规的显示屏组件符读取，如ComputerCraft状态文本、所选燃料名称、计算得到的存量耗尽用时、控制器状态等，可选择使用数据库

常规的ME物品/流体存量可使用库存量组件符。变化率可使用差值组件符。
