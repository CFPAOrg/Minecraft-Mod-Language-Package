---
navigation:
  title: 统合终端
  icon: united_terminal
  parent: index.md
  position: 021
categories:
  - extendedterminal
item_ids:
  - united_terminal
  - wireless_united_terminal
---
# 统合终端
<ItemImage id="extendedterminal:united_terminal" scale={3}/>

<ItemLink id="extendedterminal:united_terminal" />能将拓展合成与拓展终端的工具组合为同一个终端。支持普通合成、锻造、切石、铁砧、拓展合成。

## 配方
<RecipeFor id="extendedterminal:united_terminal" />

<myotus:condition load="ae2wtlib" silent="true">
## 无线统合终端
<ItemLink id="extendedterminal:wireless_united_terminal" />是无线版本的<ItemLink id="extendedterminal:united_terminal" />。需要<ItemLink id="ae2:wireless_access_point"/>才可运作。

## 配方
<RecipeFor id="extendedterminal:wireless_united_terminal" />

### 无线通用终端
<ItemLink id="extendedterminal:wireless_united_terminal"/>也可组合至<ItemLink id="ae2wtlib:wireless_universal_terminal"/>。
<Row>
    <Recipe id="extendedterminal:ae2wtlib/united_etc" />
    <Recipe id="extendedterminal:ae2wtlib/united_etp" />
    <Recipe id="extendedterminal:ae2wtlib/upgrade_wireless_united_terminal" />
</Row>
</myotus:condition>
