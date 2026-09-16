---
navigation:
  title: MEGA Auto-Crafting
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

# MEGA Cells: Auto-Crafting

<GameScene zoom="6" background="transparent">
  <ImportStructure src="assets/assemblies/crafting_cpu.snbt" />
  <IsometricCamera yaw="195" pitch="10" />
</GameScene>

## MEGA [Crafting CPUs](ae2:items-blocks-machines/crafting_cpu_multiblock.md)

<Row>
  <BlockImage id="mega_crafting_unit" scale="4" />
  <BlockImage id="1m_crafting_storage" scale="4" />
  <BlockImage id="4m_crafting_storage" scale="4" />
  <BlockImage id="16m_crafting_storage" scale="4" />
  <BlockImage id="64m_crafting_storage" scale="4" />
  <BlockImage id="256m_crafting_storage" scale="4" />
</Row>

As with storage cells, MEGA also provides its larger tiers of storage for crafting CPUs. Although these, too, require
their own dedicated version of the <ItemLink id="ae2:crafting_unit" /> to accommodate for their increase in power, they
will still handle even the biggest crafting jobs easily with more memory, while also looking *pretty damn cool* in
black.

<RecipeFor id="mega_crafting_unit" />
<RecipeFor id="1m_crafting_storage" />
<RecipeFor id="4m_crafting_storage" />
<RecipeFor id="16m_crafting_storage" />
<RecipeFor id="64m_crafting_storage" />
<RecipeFor id="256m_crafting_storage" />

As an added bonus, MEGA also provides its own equivalent to the <ItemLink id="ae2:crafting_accelerator" />, though with
the advantage of providing not one, but *FOUR* coprocessing threads in the space of each single added coprocessor block.

<BlockImage id="mega_crafting_accelerator" scale="4" />
<RecipeFor id="mega_crafting_accelerator" />

And just for the sake of a full package, there is also a MEGA equivalent to the <ItemLink id="ae2:crafting_monitor" />.
This one doesn't actually function any differently to the regular monitor at all, but it does serve as a complement to
the aforementioned units for users looking to maintain some aesthetic consistency and retain the same sleek, dark
look across their whole CPU multiblock.

<BlockImage id="mega_crafting_monitor" scale="4" />
<RecipeFor id="mega_crafting_monitor" />

## MEGA Pattern Provider

<Row>
  <BlockImage id="mega_pattern_provider" scale="4" />
  <GameScene zoom="4" background="transparent">
    <ImportStructure src="assets/assemblies/cable_mega_pattern_provider.snbt" />
  </GameScene>
</Row>

Serving as a companion to the <ItemLink id="ae2:pattern_provider" />, the **MEGA Pattern Provider** maintains the
trend of providing larger variants of appropriate AE2 devices by doubling the pattern capacity, allowing for a total of
18 patterns to be held within and handled by it. This does, however, come with the trade-off of only being able to hold
[**processing patterns**](ae2:items-blocks-machines/patterns.md), so it will not quite work with the
<ItemLink id="ae2:molecular_assembler" />.

<Row>
  <RecipeFor id="mega_pattern_provider" />
  <RecipeFor id="cable_mega_pattern_provider" />
</Row>
