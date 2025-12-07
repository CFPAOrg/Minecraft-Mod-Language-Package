---
navigation:
  parent: crazyae2addons_index.md
  title: 样板管理单元
  icon: crazyae2addons:pattern_management_unit
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:pattern_management_unit
  - crazyae2addons:pattern_management_unit_frame
  - crazyae2addons:pattern_management_unit_wall
  - crazyae2addons:pattern_management_unit_controller
---

# 样板管理单元控制器

<GameScene zoom="2" interactive={true}>
  <ImportStructure src="../assets/unit.nbt" />
</GameScene>

**样板管理单元控制器**能够在同一位置中存储大量**已编码的合成样板**，且可让全网络都使用它们。

## 工作原理

* 同网络内的**所有样板供应器**都可访问放入单元的**已编码合成样板**。
* 管理单元只接受**合成样板**，不接受处理样板。
* 无需再为各个供应器复制样板或搬运样板了；只要样板处于管理单元内，所有供应器便都可用它们来自动合成。
* 合成操作可在所有样板供应器间并行发出。

## 使用管理单元

* 打开控制器以查看样板存储方格。
* 放入和取出已编码的合成样板，操作和在普通的样板供应器中一样。
* 如果样板多到超出了屏幕，可以使用**滚动条**。
* **预览按钮**可以打开和关闭预览模式。

## 优点

* 在单个位置统一管理样板。
* 可借此扩展合成系统，而无需把样板供应器塞得满满当当。
* 可轻松管理成百上千个样板，同时保持网络的整洁。
* 可轻松并行执行自动合成任务。

## 注意事项

* 管理单元中只可放入**已编码的合成样板**。不接受其他物品。
* 如果管理单元未能形成有效的多方块结构，网络便无法访问到其中的样板。
