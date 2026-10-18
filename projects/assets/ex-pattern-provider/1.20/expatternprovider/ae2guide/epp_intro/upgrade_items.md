---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME设备升级组件
    icon: expatternprovider:pattern_provider_upgrade
categories:
- extended items
item_ids:
- expatternprovider:pattern_provider_upgrade
- expatternprovider:interface_upgrade
- expatternprovider:io_bus_upgrade
- expatternprovider:pattern_terminal_upgrade
- expatternprovider:drive_upgrade
---

# ME设备升级组件

这些升级允许你用扩展的ME设备替换普通的ME设备，而不必破坏它们。

<Row>
<ItemImage id="expatternprovider:pattern_provider_upgrade" scale="4"></ItemImage>
<ItemImage id="expatternprovider:interface_upgrade" scale="4"></ItemImage>
<ItemImage id="expatternprovider:io_bus_upgrade" scale="4"></ItemImage>
<ItemImage id="expatternprovider:pattern_terminal_upgrade" scale="4"></ItemImage>
<ItemImage id="expatternprovider:drive_upgrade" scale="4"></ItemImage>
</Row>

对普通ME设备潜行右击，会将其替换为相应的扩展版本。
设备内的设置和物品将会保留。

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../structure/upgrade_show_1.snbt"></ImportStructure>
  <BoxAnnotation color="#ffffff" min="1 0 0" max="4 1 1">
        正常模式的样板供应器，你可以使用样板供应器升级来升级它们。
        <ItemImage id="expatternprovider:pattern_provider_upgrade" scale="2"></ItemImage>
  </BoxAnnotation>
</GameScene>
<GameScene zoom="6" background="transparent">
  <ImportStructure src="../structure/upgrade_show_2.snbt"></ImportStructure>
  <BoxAnnotation color="#ffffff" min="1 0 0" max="4 1 1">
        扩展样板供应器将保留原始样板供应器的所有设置和样板。
  </BoxAnnotation>
</GameScene>

## 升级列表

|                                      升级组件                                      |                              普通设备                              |                                      扩展设备                                      |
|:---------------------------------------------------------------------------------:|:------------------------------------------------------------------:|:---------------------------------------------------------------------------------:|
| <ItemImage id="expatternprovider:pattern_provider_upgrade" scale="3"></ItemImage> |    <ItemImage id="ae2:pattern_provider" scale="3"></ItemImage>     |   <ItemImage id="expatternprovider:ex_pattern_provider" scale="3"></ItemImage>    |
| <ItemImage id="expatternprovider:pattern_provider_upgrade" scale="3"></ItemImage> | <ItemImage id="ae2:cable_pattern_provider" scale="3"></ItemImage>  | <ItemImage id="expatternprovider:ex_pattern_provider_part" scale="3"></ItemImage> |
|    <ItemImage id="expatternprovider:interface_upgrade" scale="3"></ItemImage>     |        <ItemImage id="ae2:interface" scale="3"></ItemImage>        |       <ItemImage id="expatternprovider:ex_interface" scale="3"></ItemImage>       |
|    <ItemImage id="expatternprovider:interface_upgrade" scale="3"></ItemImage>     |     <ItemImage id="ae2:cable_interface" scale="3"></ItemImage>     |    <ItemImage id="expatternprovider:ex_interface_part" scale="3"></ItemImage>     |
|      <ItemImage id="expatternprovider:io_bus_upgrade" scale="3"></ItemImage>      |       <ItemImage id="ae2:import_bus" scale="3"></ItemImage>        |    <ItemImage id="expatternprovider:ex_import_bus_part" scale="3"></ItemImage>    |
|      <ItemImage id="expatternprovider:io_bus_upgrade" scale="3"></ItemImage>      |       <ItemImage id="ae2:export_bus" scale="3"></ItemImage>        |    <ItemImage id="expatternprovider:ex_export_bus_part" scale="3"></ItemImage>    |
| <ItemImage id="expatternprovider:pattern_terminal_upgrade" scale="3"></ItemImage> | <ItemImage id="ae2:pattern_access_terminal" scale="3"></ItemImage> |  <ItemImage id="expatternprovider:ex_pattern_access_part" scale="3"></ItemImage>  |
|      <ItemImage id="expatternprovider:drive_upgrade" scale="3"></ItemImage>       |          <ItemImage id="ae2:drive" scale="3"></ItemImage>          |         <ItemImage id="expatternprovider:ex_drive" scale="3"></ItemImage>         |
