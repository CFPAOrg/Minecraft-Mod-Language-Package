---
navigation:
  title: 应用林业
  icon: appliedforestry:genetic_terminal
item_ids:
  - appliedforestry:genetic_terminal
  - appliedforestry:genetic_export_bus
  - appliedforestry:genetic_import_bus
  - appliedforestry:genetic_level_emitter
  - appliedforestry:genetic_cell_4k
  - appliedforestry:genetic_cell_16k
  - appliedforestry:genetic_cell_64k
  - appliedforestry:genetic_cell_256k
---

# 应用林业

应用林业为应用能源2添加了能识别林业资源的存储设备和自动化设施。各生物体仍按原本的ItemStack存储，本附属仅为它们的林业数据组件建立了可搜索的语义索引。

<ItemGrid>
  <ItemIcon id="appliedforestry:genetic_terminal" />
  <ItemIcon id="appliedforestry:genetic_export_bus" />
  <ItemIcon id="appliedforestry:genetic_import_bus" />
  <ItemIcon id="appliedforestry:genetic_level_emitter" />
  <ItemIcon id="appliedforestry:genetic_cell_4k" />
  <ItemIcon id="appliedforestry:genetic_cell_16k" />
  <ItemIcon id="appliedforestry:genetic_cell_64k" />
  <ItemIcon id="appliedforestry:genetic_cell_256k" />
</ItemGrid>

## ME基因终端

能按分类、品种、生命阶段、纯合/杂合为林业生物体分组的终端。打开分组可选择某一种基因组。终端的搜索栏接受常规文本和[筛选器参考](filters.md)中提及的基因谓词。

## 基因总线

基因输出总线和基因输入总线使用的是同一套谓词系统。输出总线可按组合语义维持库存量，无论语义所囊括各生物体的基因组是否完全相同。加速卡和红石卡的表现与在AE2同类总线中一致。

## 基因标准发信器

统计匹配单个语义筛选器的所有生物体，会在库存量高于或低于所设阈值时发出红石信号。

## 基因存储元件

4k、16k、64k、256k基因存储元件仅接受林业生物体，它们的通用存储能力不及同等级元件，但类型上限极高。数据组件、交配、分析状态等在存储时全部保留。可在元件工作台处设定精确分区和安装反相卡。

部件的筛选器设置可用AE2内存卡复制。

