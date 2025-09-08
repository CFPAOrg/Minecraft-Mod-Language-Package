---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME无线连接器
    icon: extendedae:wireless_connect
categories:
- extended devices
item_ids:
- extendedae:wireless_connect
- extendedae:wireless_tool
---

# ME无线连接器

<Row gap="20">
<BlockImage id="extendedae:wireless_connect" scale="6"></BlockImage>
<ItemImage id="extendedae:wireless_tool" scale="6"></ItemImage>
</Row>

ME无线连接器能和<ItemLink id="ae2:quantum_link" />一样连接两个网络，但距离有限，也不可跨维度连接。ME无线连接器仅支持一对一的连接，如需建立多对多连接，应使用<ItemLink id="extendedae:wireless_hub" />。

## 连接无线连接器

用ME无线连接工具右击需连接的两个无线连接器，即可进行连接。

潜行点击可清除ME无线连接工具当前的设置。

连接建立后，ME无线连接器的纹理会发生变化。

未连接的ME无线连接器：

<GameScene zoom="5" background="transparent">
  <ImportStructure src="../structure/wireless_connector_off.snbt"></ImportStructure>
</GameScene>

已连接的ME无线连接器：

<GameScene zoom="5" background="transparent">
  <ImportStructure src="../structure/wireless_connector_on.snbt"></ImportStructure>
</GameScene>

## 颜色

无线连接器可像线缆一样染色，此后其便只会与同色的线缆和无线连接器相连。

染色需要使用<ItemLink id="ae2:color_applicator" />。

正因此，无线连接器可以这样摆放：

<GameScene zoom="3" background="transparent" interactive={true}>
  <ImportStructure src="../structure/wireless_connector_setup.snbt"></ImportStructure>
</GameScene>

## 能量使用

相连的ME无线连接器距离越远，其能量消耗就越高。这两个数据并不呈线性关系，也即，距离过远时能量消耗会极其大。

可以使用<ItemLink id="ae2:energy_card" />来节省能量，每张卡降低10%的能量消耗。

