---
navigation:
  title: MEGA自动合成
  icon: 256m_crafting_storage
  parent: index.md
  position: 020
categories:
  - megacells
item_ids:
  - mega_crafting_unit
  - 1m_crafting_storage
  - 4m_crafting_storage
  - 16m_crafting_storage
  - 64m_crafting_storage
  - 256m_crafting_storage
  - mega_crafting_accelerator
  - mega_crafting_monitor
  - mega_pattern_provider
  - cable_mega_pattern_provider
---

# MEGA元件：自动合成

<GameScene zoom="6" background="transparent">
  <ImportStructure src="assets/assemblies/crafting_cpu.snbt" />
  <IsometricCamera yaw="195" pitch="10" />
</GameScene>

## MEGA[合成CPU](ae2:items-blocks-machines/crafting_cpu_multiblock.md)

<Row>
  <BlockImage id="mega_crafting_unit" scale="4" />
  <BlockImage id="1m_crafting_storage" scale="4" />
  <BlockImage id="4m_crafting_storage" scale="4" />
  <BlockImage id="16m_crafting_storage" scale="4" />
  <BlockImage id="64m_crafting_storage" scale="4" />
  <BlockImage id="256m_crafting_storage" scale="4" />
</Row>

与存储元件一样，MEGA还提供了可供合成CPU使用的高等级存储方案。不过，这些方案需要专用版本的<ItemLink id="ae2:crafting_unit" />，以协调它们强大的能力。它们能凭借更大的存储空间轻松处理极大的合成任务，漆黑的外观更是*酷到爆炸*。

<RecipeFor id="mega_crafting_unit" />
<RecipeFor id="1m_crafting_storage" />
<RecipeFor id="4m_crafting_storage" />
<RecipeFor id="16m_crafting_storage" />
<RecipeFor id="64m_crafting_storage" />
<RecipeFor id="256m_crafting_storage" />

作为附赠，MEGA提供了MEGA版本的<ItemLink id="ae2:crafting_accelerator" />。每个并行处理单元带来的新并行线程不只一个，而是足足*四*个。

<BlockImage id="mega_crafting_accelerator" scale="4" />
<RecipeFor id="mega_crafting_accelerator" />

而也是为了补齐全套，MEGA同样提供了MEGA版本的<ItemLink id="ae2:crafting_monitor" />。它的功能和标准的监控器没有区别，不过它确实可以作为先前所提元件的补充，能保证外观风格一致——整个CPU多方块都是时髦的漆黑。

<BlockImage id="mega_crafting_monitor" scale="4" />
<RecipeFor id="mega_crafting_monitor" />

## MEGA样板供应器

<Row>
  <BlockImage id="mega_pattern_provider" scale="4" />
  <GameScene zoom="4" background="transparent">
    <ImportStructure src="assets/assemblies/cable_mega_pattern_provider.snbt" />
  </GameScene>
</Row>

**MEGA样板供应器**可协同<ItemLink id="ae2:pattern_provider" />运作；同时，为顺应提供大容量好用AE2设备的潮流，它的样板容量是标准供应器的两倍，也即可存储并处理18个样板。然而，它也因此进行了取舍——它只接受[**处理样板**](ae2:items-blocks-machines/patterns.md)，也就是说，它不太能和<ItemLink id="ae2:molecular_assembler" />一起运作。

<Row>
  <RecipeFor id="mega_pattern_provider" />
  <RecipeFor id="cable_mega_pattern_provider" />
</Row>
