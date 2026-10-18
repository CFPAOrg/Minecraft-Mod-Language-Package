---
navigation:
  parent: example-setups/example-setups-index.md
  title: 充能器自动化
  icon: charger
---

# 充能器自动化

需注意，此设施使用了<ItemLink id="pattern_provider" />，也即需与你的[自动合成](../ae2-mechanics/autocrafting.md)设施配合使用。如需独立自动化<ItemLink id="charger" />，则应使用漏斗，箱子等。

自动化<ItemLink id="charger" />相对简单。<ItemLink id="pattern_provider" />将材料送入充能器，再由[管道子网络](pipe-subnet.md)或其他物品管道将产物送回供应器即可。

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/charger_automation.snbt" />

<BoxAnnotation color="#dddddd" min="1 0 0" max="2 1 1">
        （1）样板供应器：默认配置，装有相应样板。同时提供能量。

        ![充能器样板](../assets/diagrams/charger_pattern_small.png)
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="0 1 0" max="1 1.3 1">
        （2）输入总线：默认配置。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1 1 0" max="2 1.3 1">
        （3）存储总线：默认配置。
  </BoxAnnotation>

<DiamondAnnotation pos="4 0.5 0.5" color="#00ff00">
        至主网络
    </DiamondAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 配置

* <ItemLink id="pattern_provider" />（1）处于默认配置并装有相应<ItemLink id="processing_pattern" />。其也同时为<ItemLink id="charger" />提供[能量](../ae2-mechanics/energy.md)，类似[线缆](../items-blocks-machines/cables.md)。
  
    ![充能器样板](../assets/diagrams/charger_pattern.png)

* <ItemLink id="import_bus" />（2）处于默认配置。
* <ItemLink id="storage_bus" />（3）处于默认配置。

## 工作原理

1. <ItemLink id="pattern_provider" />将材料送入<ItemLink id="charger" />。
2. 充能器完成充能。
3. 绿色子网络上的<ItemLink id="import_bus" />将充能产物抽出并尝试存入[网络存储](../ae2-mechanics/import-export-storage.md)。
4. 绿色子网络上的存储位置仅有<ItemLink id="storage_bus" />，其会将产物送入样板供应器并返回至主网络。
