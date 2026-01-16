---
navigation:
   parent: crazyae2addons_index.md
   title: 无线通知终端
   icon: crazyae2addons:wireless_notification_terminal
categories:
   - Monitoring and Automation
item_ids:
   - crazyae2addons:wireless_notification_terminal
---

# 无线通知终端

无线通知终端是用于监控ME库存的无线终端，其会在所选物品、流体等资源越过所配置的库存阈值时发送弹窗通知。

为简单的“库存量超过或低于X”警报而设计。

## [视频教程](https://youtu.be/l7OcgG5FD_s&list=PLB8Rr5Xojkr5T1qoPr_4JdETiBkF4qF6r)

---

## 需求

* 终端必须连接至AE网络（和其他无线终端一样）。

---

## 快速入门

1. 打开终端GUI。
2. 在第一行的过滤槽输入需监控的物品或流体。
3. 在旁边的输入框输入阈值。
4. 对其他行重复以上操作（最多32行）。

当库存量改变且越过阈值时，你会收到一条弹窗：

* 超过阈值（库存量变为大于等于阈值）
* 低于阈值（库存量变为小于阈值）

每秒进行一次检查和更新。

## 注意事项

* 通知只会在状态切换时触发（低于至超过，超过至低于）。
* 更改过滤物品或编辑阈值会重置该行的库存量状态（也即不会立即弹窗，而是要等到再次越过阈值）。
* 在GUI关闭时也会运作，只要求终端物品在物品栏中（服务端每秒检查一次）。
* 可与无线通用终端配合。
