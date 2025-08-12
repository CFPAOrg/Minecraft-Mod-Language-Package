---
navigation:
  parent: crazyae2addons_index.md
  title: 能量接口
  icon: crazyae2addons:energy_interface
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:energy_interface
---

# 能量接口

**能量接口**是能将ME网络所存AE能量暴露为Forge能量（Forge Energy，FE）的被动线缆子部件。

---

## 工作原理

- 从FE系统看来，它相当于一个电池。
- 可抽取的能量取决于ME网络当前的能量水平。
- 抽取限制为：
   - 不多于AE总容量的**30%**。
   - 不多于500MFE，取两者中较小者。
- 能量抽取会经过**2 FE = 1 AE**换算。
- 也可向其**送入**能量，换算方法同样为FE至AE为2:1。

---

