---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 空间元件
  icon: spatial_storage_cell_128
  position: 410
categories:
- tools
item_ids:
- ae2:spatial_storage_cell_2
- ae2:spatial_storage_cell_16
- ae2:spatial_storage_cell_128
- ae2:spatial_cell_component_2
- ae2:spatial_cell_component_16
- ae2:spatial_cell_component_128
---

# 空间存储元件

  <Row>
    <ItemImage id="spatial_storage_cell_2" scale="4" />

    <ItemImage id="spatial_storage_cell_16" scale="4" />

    <ItemImage id="spatial_storage_cell_128" scale="4" />
  </Row>

空间存储元件可用于[存储物理空间中的某一区域](../ae2-mechanics/spatial-io.md)。可用于<ItemLink id="spatial_io_port" />。

和[存储元件](../items-blocks-machines/storage_cells.md)不同，空间元件不可重新格式化。

**空间元件使用后便无法重置，重新格式化，或是重设大小。**如果需要更改所定义区域大小，应新制作元件。


## 配方

  <Row>
    <Recipe id="network/cells/spatial_storage_cell_2_cubed_storage" />

    <Recipe id="network/cells/spatial_storage_cell_16_cubed_storage" />

    <Recipe id="network/cells/spatial_storage_cell_128_cubed_storage" />
  </Row>

# 外壳

元件可由空间组件和外壳合成，也可在外壳配方中央放入空间组件：

<Row>
  <Recipe id="network/cells/spatial_storage_cell_2_cubed" />

  <Recipe id="network/cells/spatial_storage_cell_2_cubed_storage" />
</Row>

外壳自身的配方如下：

  <RecipeFor id="item_cell_housing" />

# 空间组件

空间组件是空间存储元件的核心。每级组件容量的边长是前一级组件的8倍。

  <Row>
    <RecipeFor id="spatial_cell_component_2" />

    <RecipeFor id="spatial_cell_component_16" />

    <RecipeFor id="spatial_cell_component_128" />
  </Row>