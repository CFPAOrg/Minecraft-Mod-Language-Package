---
navigation:
  parent: crazyae2addons_index.md
  title: 生物农场
  icon: crazyae2addons:mob_farm_controller
categories:
  - Mob Storage
item_ids:
   - crazyae2addons:mob_farm_wall
   - crazyae2addons:mob_farm_input
   - crazyae2addons:mob_farm_collector
   - crazyae2addons:mob_farm_damage
   - crazyae2addons:mob_farm_controller
---

<GameScene zoom="2" interactive={true}>
  <ImportStructure src="../assets/mob_farm.nbt" />
</GameScene>

# 生物农场控制器

生物农场控制器是多方块自动生物农场系统的核心组件。它会模拟击杀ME网络中所存生物的过程，并生成掉落物和经验碎片，直接存入ME系统，同时**排除**携带**NBT**或**不可堆叠**的物品。

## 使用方法

1. **搭建多方块结构**
    - 按照上述模式搭建5x6x5的结构。

2. **为控制器供能**
    - 将生物农场控制器接至启动的ME网络。

3. **在GUI中配置**
    - 设置应处理何种生物。
    - 可选：设置用于击杀生物的物品。

4. **安装升级卡（可选）**
    - 安装抢夺/经验/加速卡。

---

## 工作原理

- 农场会从ME网络中“消耗”生物。
- 根据生物的战利品表生成掉落物，并删除所有带有NBT或不可堆叠的物品。
- 生成经验碎片。
- 将掉落物和经验碎片送回ME网络。
- 伤害模块越多，击杀速度就越快。
- 速度卡可进一步加快处理速度。（最多每秒64个生物）

---

## 重要注意事项

- **需要正确搭建多方块结构**：生物农场结构缺损即停工。
- **只会处理生物**：必须先使用生物破坏面板或[刷怪笼提取器](spawner_extractor.md)捕捉生物。
- **不会真正生成生物**：没有卡顿，万事大吉。
- **支持抢夺**：轻松增多掉落物。