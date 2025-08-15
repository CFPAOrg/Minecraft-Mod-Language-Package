---
navigation:
  parent: crazyae2addons_index.md
  title: 熵演摇篮多方块
  icon: crazyae2addons:entropy_cradle_controller
categories:
  - Crafting and Patterns
item_ids:
   - crazyae2addons:entropy_cradle_controller
   - crazyae2addons:entropy_cradle_capacitor
   - crazyae2addons:entropy_cradle
---

# 熵演摇篮

<GameScene zoom="1" interactive={true}>
  <ImportStructure src="../assets/entropy_cradle.nbt" />
</GameScene>

**熵演摇篮**是容量极大的能量积累和转化多方块结构。它最多可存储**6亿FE**，完全充满后还可进行高级**方块转化**。

---

## 工作原理

1. **充能**：
    - 充能水平会在600MFE处停止。
    - 六处电容器会随充能水平增长而逐级点亮。
    - 充满能量后，电容器会发出比较器信号。

2. **转化**：
    - 充满时收到红石脉冲：
        - 进行放电。
        - 如果内部有已知的结构配方，则将其替换为功能强大的方块（如彭罗斯框架、能源仓库组件等）。

---

## 注意事项

- 需要应用能源2（AE2）能量，且需占用频道。
- 只接受AE能量充能。
- 可用配方请参见JEI。
- 可用建筑机自动化其配方。