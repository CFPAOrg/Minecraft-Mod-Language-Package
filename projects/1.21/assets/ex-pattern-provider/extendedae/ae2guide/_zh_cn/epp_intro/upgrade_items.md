---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME设备升级组件
    icon: extendedae:pattern_provider_upgrade
categories:
- extended items
item_ids:
- extendedae:pattern_provider_upgrade
- extendedae:interface_upgrade
- extendedae:io_bus_upgrade
- extendedae:pattern_terminal_upgrade
- extendedae:drive_upgrade
---

# ME设备升级组件

这些升级组件能将普通的ME设备替换成扩展版本，而无需破坏后再放置。

<Row>
<ItemImage id="extendedae:pattern_provider_upgrade" scale="4"></ItemImage>
<ItemImage id="extendedae:interface_upgrade" scale="4"></ItemImage>
<ItemImage id="extendedae:io_bus_upgrade" scale="4"></ItemImage>
<ItemImage id="extendedae:pattern_terminal_upgrade" scale="4"></ItemImage>
<ItemImage id="extendedae:drive_upgrade" scale="4"></ItemImage>
</Row>

持上述升级潜行右击设备，即可将它们升级为对应的扩展设备。设备的设置和其中物品会保留。

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../structure/upgrade_show_1.snbt"></ImportStructure>
  <BoxAnnotation color="#ffffff" min="1 0 0" max="4 1 1">
        普通的样板供应器。可用样板供应器升级进行升级。
        <ItemImage id="extendedae:pattern_provider_upgrade" scale="2"></ItemImage>
  </BoxAnnotation>
</GameScene>
<GameScene zoom="6" background="transparent">
  <ImportStructure src="../structure/upgrade_show_2.snbt"></ImportStructure>
  <BoxAnnotation color="#ffffff" min="1 0 0" max="4 1 1">
        扩展样板供应器会保留原有供应器的全部设置和样板。
  </BoxAnnotation>
</GameScene>

## 升级列表

|                                  升级组件                                  |                              普通设备                              |                                  扩展设备                                  |
| :------------------------------------------------------------------------: | :----------------------------------------------------------------: | :------------------------------------------------------------------------: |
| <ItemImage id="extendedae:pattern_provider_upgrade" scale="3"></ItemImage> |    <ItemImage id="ae2:pattern_provider" scale="3"></ItemImage>     |   <ItemImage id="extendedae:ex_pattern_provider" scale="3"></ItemImage>    |
| <ItemImage id="extendedae:pattern_provider_upgrade" scale="3"></ItemImage> | <ItemImage id="ae2:cable_pattern_provider" scale="3"></ItemImage>  | <ItemImage id="extendedae:ex_pattern_provider_part" scale="3"></ItemImage> |
|    <ItemImage id="extendedae:interface_upgrade" scale="3"></ItemImage>     |        <ItemImage id="ae2:interface" scale="3"></ItemImage>        |       <ItemImage id="extendedae:ex_interface" scale="3"></ItemImage>       |
|    <ItemImage id="extendedae:interface_upgrade" scale="3"></ItemImage>     |     <ItemImage id="ae2:cable_interface" scale="3"></ItemImage>     |    <ItemImage id="extendedae:ex_interface_part" scale="3"></ItemImage>     |
|      <ItemImage id="extendedae:io_bus_upgrade" scale="3"></ItemImage>      |       <ItemImage id="ae2:import_bus" scale="3"></ItemImage>        |    <ItemImage id="extendedae:ex_import_bus_part" scale="3"></ItemImage>    |
|      <ItemImage id="extendedae:io_bus_upgrade" scale="3"></ItemImage>      |       <ItemImage id="ae2:export_bus" scale="3"></ItemImage>        |    <ItemImage id="extendedae:ex_export_bus_part" scale="3"></ItemImage>    |
| <ItemImage id="extendedae:pattern_terminal_upgrade" scale="3"></ItemImage> | <ItemImage id="ae2:pattern_access_terminal" scale="3"></ItemImage> |  <ItemImage id="extendedae:ex_pattern_access_part" scale="3"></ItemImage>  |
|      <ItemImage id="extendedae:drive_upgrade" scale="3"></ItemImage>       |          <ItemImage id="ae2:drive" scale="3"></ItemImage>          |         <ItemImage id="extendedae:ex_drive" scale="3"></ItemImage>         |
