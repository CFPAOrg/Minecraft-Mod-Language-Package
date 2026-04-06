---
navigation:
  parent: crazyae2addons_index.md
  title: 刷怪笼提取器
  icon: crazyae2addons:spawner_extractor_controller
categories:
  - Mob Storage
item_ids:
   - crazyae2addons:spawner_extractor_wall
   - crazyae2addons:spawner_extractor_controller
---

# 刷怪笼提取器

<GameScene zoom="2" interactive={true}>
  <ImportStructure src="../assets/spawner_extractor.nbt" />
</GameScene>

刷怪笼提取器是一个多方块系统，可通过真实存在的刷怪笼方块，模拟生物生成并将其直接存入ME网络。此法无需实际生成实体即可自动捕获生物，有效避免卡顿。

## 使用方法

1. **搭建多方块结构**
   - 按照上述布局搭建多方块。注意要在刷怪笼周围搭建。为确保结构正确成形，角落的方块应最后放置。

2. **为提取器供能**
   - 将刷怪笼提取器接至启动的ME网络。

3. **安装升级卡（可选）**
   - 可用速度卡加快生物的生成速度。

---

## 工作原理

- 结构成形之后，其内部的刷怪笼即会被禁用。
- 刷怪笼每20刻会向ME网络存入一些生物。
- 控制器会读取生物类型。
- 全程无实体生成，只有利落、可重复进行的生物捕捉。

---

## 重要注意事项

- **需要正确搭建多方块结构**：刷怪笼结构缺损即停工。
- **不会真正生成生物**：没有卡顿，万事大吉。