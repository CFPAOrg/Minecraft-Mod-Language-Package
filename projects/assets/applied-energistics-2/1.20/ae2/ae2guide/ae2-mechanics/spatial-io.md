---
navigation:
  parent: ae2-mechanics/ae2-mechanics-index.md
  title: 空间IO
  icon: spatial_storage_cell_2
---

# 空间IO

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/spatial_storage_1x1x1.snbt" />

  <BoxAnnotation color="#33dd33" min="1 1 1" max="2 2 2">
        会被移动的区域
  </BoxAnnotation>

  <IsometricCamera yaw="195" pitch="30" />

</GameScene>

空间IO是剪切粘贴世界中某一区域的方式。可用其移动<ItemLink id="flawless_budding_quartz" />，或是在基地中造出可更改内设的多功能房间，甚至还能搬动末地传送门！

其工作方式是将所定义的区域与封闭空间维度内同等大小区域进行*交换*，将空间塔阵列中的所有事物送入封闭空间，并将封闭空间中的事物送入空间塔阵列。

如果你有维度间旅行方式的话（空间IO*可*用于制造传送装置，但会相当复杂，不算好用，也超出了指南的讨论范围），就可将空间IO用作大小可调的压缩空间或是口袋维度。

# 多方块设施

空间IO需要将其组件以特定方式排列才能正常工作和定义需剪切粘贴的区域。

所有组件需处于统一[网络](me-network-connections.md)才可正常工作，且同一网络中只能存在一个空间IO设施。因此推荐使用[子网络](subnetworks.md)。

## 空间IO端口

<BlockImage id="spatial_io_port" p:powered="true" scale="4" />

<ItemLink id="spatial_io_port" />控制空间IO的运作。它能显示多方块设施的数据，也是放置[空间元件](../items-blocks-machines/spatial_cells.md)的地方。

其能显示：
- 网络中已存储的[能量](energy.md)和能量容量上限
- 执行操作所需的能量；可能会很大且会瞬时消耗，需确保有足够的[能源元件](../items-blocks-machines/energy_cells.md)
- 空间塔阵列的效率
- 所定义区域的尺寸

执行空间IO操作需要在其中放入空间存储元件并给予空间IO端口红石脉冲。之后便会*交换*空间塔内和封闭空间内的区域。也即如果将某些方块存入封闭空间，*然后在空间塔内放入另外一些方块*，再把元件放入输入槽，然后再次触发空间IO端口，此时第二组方块会消失，而第一组则会重新出现。

**需万分注意，所定义区域中的任何实体，包括你，都会一起被搬走。如果没有出来的方式，就相当于被禁锢在封闭空间维度，困在一个毫无特点的漆黑盒子里。**用这个去整蛊朋友吧！

## 空间塔

<BlockImage id="spatial_pylon" p:powered_on="true" scale="4" />

<ItemLink id="spatial_pylon" />是空间IO设施的主要部分，定义了会被影响的区域的尺寸。

所有空间塔的外接长方体在所有方向中收缩1格所得区域即为所定义区域。

需遵循如下规则：
- 外接长方体至少为3x3x3（也即定义1x1x1的区域）
- 所有空间塔需在外接长方体内部
- 所有空间塔需处于统一网络
- 所有空间塔需至少2格长

例如，如果要定义3x3x3的区域，则根据规则2，所有空间塔应放在需定义区域周围5x5x5的长方体壳层内。这是唯一要求——只要满足此要求，可以任意放置空间塔。

<GameScene zoom="4" interactive={true}>
<ImportStructure src="../assets/assemblies/spatial_storage_3x3x3_pylon_demonstration.snbt" />

<BoxAnnotation color="#33dd33" min="1 1 1" max="4 4 4">
        会被移动的区域
  </BoxAnnotation>

<BoxAnnotation color="#3333ff" min="5 5 0" max="0 0 5">
  </BoxAnnotation>

<IsometricCamera yaw="195" pitch="30" />
</GameScene>

更合理的设施见下：

<GameScene zoom="4" interactive={true}>
<ImportStructure src="../assets/assemblies/better_spatial_storage_3x3x3.snbt" />

<BoxAnnotation color="#33dd33" min="1 1 1" max="4 4 4">
        会被移动的区域
  </BoxAnnotation>

<BoxAnnotation color="#3333ff" min="5 5 0" max="0 0 5">
  </BoxAnnotation>

<IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 效率

空间塔阵列的效率由外壳填充量决定。用简单的设施定义大体积相当低效，还可能消耗*数以亿计*的AE。

## 元件维度

[空间元件](../items-blocks-machines/spatial_cells.md)在使用后会与某固定的尺寸设置（如3x4x2）和封闭空间维度内某部分区域绑定。**空间元件使用后便无法重置，重新格式化，或是重设大小。**如果需要更改所定义区域大小，应新制作元件。

这些大小和元件名称中指明的大小不同，16³空间元件指的是能存储*最大*16x16x16的区域。

需注意此区域是方向敏感且不可旋转的。尽管2x2x3区域和3x2x2区域大小相等，两者仍视作不相同。

如果元件的区域设置与空间塔定义的区域不符（见空间IO端口段落），则端口不会运作。