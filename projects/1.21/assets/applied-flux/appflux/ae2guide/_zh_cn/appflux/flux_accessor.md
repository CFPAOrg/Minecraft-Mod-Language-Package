---
navigation:
  parent: appflux/appflux-index.md
  title: 通量访问点
  icon: appflux:flux_accessor
categories:
- flux accessor
item_ids:
- appflux:flux_accessor
- appflux:part_flux_accessor
---

# 通量访问点

<Row>
<BlockImage id="appflux:flux_accessor" scale="8"></BlockImage>
<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/flux_accessor.snbt"></ImportStructure>
</GameScene>
</Row>

通量访问点可向ME网络中输入或从中输出能量。默认情况下的访问点没有输入输出限制，这一点可在模组配置中修改。

访问点有快速和普通两种模式。快速模式下的访问点每刻都会输出能量，若大面积使用可能会造成卡顿。普通模式的访问点会根据目标的能量水平调整输出，不会产生性能问题。

* 注意，此处所提的“能量”指的是[FE存储元件](flux_cells.md)中存储的能量，而非[能源元件](ae2:items-blocks-machines/energy_cells.md)中的。

