---
navigation:
  title: 拓展终端
  icon: et_terminal
  parent: index.md
  position: 1
categories:
  - extendedterminal
item_ids:
  - et_terminal
  - wireless_et_terminal
---

# 拓展终端

<ItemImage id="extendedterminal:et_terminal" scale={3}/>

<ItemLink id="extendedterminal:et_terminal" />是融合成、锻造、切石机、铁砧为一体的多合一终端。

## 配方
<RecipeFor id="extendedterminal:et_terminal" />

<et:condition load="AE2WTLib" silent="true">
# 无线终端
<ItemLink id="extendedterminal:wireless_et_terminal" />是<ItemLink id="extendedterminal:et_terminal" />的无线版本，需要<ItemLink id="ae2:wireless_access_point"/>才能运作。
## 配方
<RecipeFor id="extendedterminal:wireless_et_terminal" />

### 通用无线终端
和其他终端类似，<ItemLink id="extendedterminal:wireless_et_terminal"/>也可与<ItemLink id="ae2wtlib:wireless_universal_terminal"/>合并。
<Row>
    <Recipe id="ae2wtlib/etc" />
    <Recipe id="ae2wtlib/etp" />
    <Recipe id="ae2wtlib/upgrade_wireless_et_terminal" />
</Row>

</et:condition>