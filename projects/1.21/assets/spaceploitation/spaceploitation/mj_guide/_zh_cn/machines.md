---
navigation:
  title: 机器
  icon: spaceploitation:planet_simulator_controller
  position: 3
item_ids:
  - spaceploitation:planet_simulator_controller
  - spaceploitation:planet_simulator_frame
  - spaceploitation:planet_simulator_casing
  - spaceploitation:compressor
---

# 机器

## 行星模拟器

进行航天任务以采集资源的7x7x3多方块。

### 结构

<GameScene zoom="3" interactive={true} fullWidth={true}>
  <MultiblockShape multiblock="spaceploitation:planet_simulator" formed={true} unformed={true} direction="east"> </MultiblockShape>
</GameScene>

**组件：**
- <ItemLink id="spaceploitation:planet_simulator_controller" />（1x）
- <ItemLink id="spaceploitation:planet_simulator_frame" />（结构的外部框架）
- <ItemLink id="spaceploitation:planet_simulator_casing" />（结构外墙，可用总线替代）
- 输入/输出总线（见**总线**页面）

### 工作原理

1. 插入一张已激活的<ItemLink id="spaceploitation:planet_card" />
2. 通过<ItemLink id="spaceploitation:item_input_bus" />送入所需物品
3. 通过<ItemLink id="spaceploitation:energy_input_bus" />接入供能网络
4. 在<ItemLink id="spaceploitation:item_output_bus" />或<ItemLink id="spaceploitation:energy_output_bus" />处取出产物

不同行星接受的输入也不同，相应配方请查阅JEI。

### 升级

可以安装升级提升机器的性能：
- <ItemLink id="spaceploitation:upgrade_speed" /> - 加快处理速度
- <ItemLink id="spaceploitation:upgrade_energy" /> - 降低能量消耗
- <ItemLink id="spaceploitation:upgrade_luck" /> - 额外产出概率

---

## 压缩器

将铸锭压缩为全新的材料。

<ItemImage id="spaceploitation:compressor" />

接入能量，放入<ItemLink id="spaceploitation:tantalum_ingot" />，即可产出<ItemLink id="spaceploitation:tantalum_sheet" />。

<Recipe id="spaceploitation:tantalum_plate_compressing" />

升级系统与行星模拟器相同。
