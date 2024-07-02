---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME无线连接器
    icon: expatternprovider:wireless_connect
categories:
- extended devices
item_ids:
- expatternprovider:wireless_connect
- expatternprovider:wireless_tool
---

# ME无线连接器

<Row gap="20">
<BlockImage id="expatternprovider:wireless_connect" scale="6"></BlockImage>
<ItemImage id="expatternprovider:wireless_tool" scale="6"></ItemImage>
</Row>

ME无线连接器可以像<ItemLink id="ae2:quantum_link" />一样连接两个网络，但距离有限，且不能跨维度。

## 连接无线连接器

使用ME无线连接工具分别右键单击两个无线接口，然后就可以将它们连接在一起了。

潜行+点击清除ME无线连接工具的当前设置。

成功建立链接后，无线连接器的外观会发生变化。

未连接的ME无线连接器：

<GameScene zoom="5" background="transparent">
  <ImportStructure src="../structure/wireless_connector_off.snbt"></ImportStructure>
</GameScene>

成功连接的ME无线连接器：

<GameScene zoom="5" background="transparent">
  <ImportStructure src="../structure/wireless_connector_on.snbt"></ImportStructure>
</GameScene>

## 颜色

无线连接器可以像电缆一样着色，并且只能连接颜色相同的电缆/无线连接器。
你需要一个<ItemLink id="ae2:color_applicator" />给连接器上色。

因此，可以像这样设置无线连接器:

<GameScene zoom="3" background="transparent" interactive={true}>
  <ImportStructure src="../structure/wireless_connector_setup.snbt"></ImportStructure>
</GameScene>

## 能源消耗

当它们相距较远时，ME无线连接器将会消耗更多的能源。
它的能源消耗与距离的关系不是线性的，因此如果它们相距太远，能源需求可能会非常高。

你可以使用<ItemLink id="ae2:energy_card" />来节省电力，每张能源卡可以减少10%的能源消耗。