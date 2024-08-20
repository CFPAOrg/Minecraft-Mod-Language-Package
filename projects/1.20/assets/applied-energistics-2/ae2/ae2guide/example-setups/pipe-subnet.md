---
navigation:
  parent: example-setups/example-setups-index.md
  title: 物品/流体“管道”子网络
  icon: storage_bus
---

# 物品/流体“管道”子网络

以下为通过AE2[设备](../ae2-mechanics/devices.md)模拟物品和流体管道的简单方式，适用于所有可用物品或流体管道的设计，自然也包括将合成产物送回<ItemLink id="pattern_provider" />的情况。

通常有两种方法达成这种效果：

## 输入总线 -> 存储总线

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/import_storage_pipe.snbt" />

<BoxAnnotation color="#dddddd" min="3.7 0 0" max="4 1 1">
        （1）输入总线：可过滤。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1 0 0" max="1.3 1 1">
        （2）存储总线：可过滤。此总线（以及其他要设为传输终点的存储总线）必须为网络中唯一的存储位置。
  </BoxAnnotation>

<DiamondAnnotation pos="4.5 0.5 0.5" color="#00ff00">
        起点
    </DiamondAnnotation>

<DiamondAnnotation pos="0.5 0.5 0.5" color="#00ff00">
        终点
    </DiamondAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

连接至起点容器的<ItemLink id="import_bus" />（1）会输入物品和流体，并尝试将其存入[网络存储](../ae2-mechanics/import-export-storage.md)。而网络中唯一的存储位置是<ItemLink id="storage_bus" />（2）（也说明了为什么此设施需是子网络而非主网络），物品和流体会存入终点容器，等效于传输。能量通过<ItemLink id="quartz_fiber" />供给。输入总线和存储总线均可设置过滤，不过在无过滤时此设施会传输所有其能访问的事物。此设施允许存在多个输入总线和多个存储总线。

## 存储总线 -> 输出总线

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/storage_export_pipe.snbt" />

<BoxAnnotation color="#dddddd" min="3.7 0 0" max="4 1 1">
        （1）存储总线：可过滤。此总线（以及其他要设为传输起点的存储总线）必须为网络中唯一的存储位置。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1 0 0" max="1.3 1 1">
        （2）输出总线：必须过滤。
  </BoxAnnotation>

<DiamondAnnotation pos="4.5 0.5 0.5" color="#00ff00">
        起点
    </DiamondAnnotation>

<DiamondAnnotation pos="0.5 0.5 0.5" color="#00ff00">
        终点
    </DiamondAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

连接至终点容器的<ItemLink id="export_bus" />会尝试从[网络存储](../ae2-mechanics/import-export-storage.md)中抽取被过滤的物品。而网络中唯一的存储位置是<ItemLink id="storage_bus" />（也说明了为什么此设施需是子网络而非主网络），物品和流体会从起点容器中被抽出，等效于传输。能量通过<ItemLink id="quartz_fiber" />供给。输出总线只会在其设有过滤时工作，因此此设施只会在输出总线有过滤时工作。此设施允许存在多个存储总线和多个输出总线。

## 无法运作的设计（输入总线 -> 输出总线）

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/import_export_pipe.snbt" />

<BoxAnnotation color="#dd3333" min="3.7 0 0" max="4 1 1">
        （1）输入总线：由于网络中没有存储空间，输入总线的输入目标不存在。
  </BoxAnnotation>

<BoxAnnotation color="#dd3333" min="1 0 0" max="1.3 1 1">
        （2）输出总线：由于网络中没有存储空间，输出总线的输出来源不存在。
  </BoxAnnotation>

<DiamondAnnotation pos="4.5 0.5 0.5" color="#ff0000">
        起点
    </DiamondAnnotation>

<DiamondAnnotation pos="0.5 0.5 0.5" color="#ff0000">
        终点
    </DiamondAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

只由输入总线和输出总线组成的设施不会运作。输入总线会尝试从起点容器中抽取物品和流体并存入网络存储。输出总线会尝试从网络存储中抽取物品和流体并输出至终点容器。但是此网络**没有存储位置**，输入总线无法输入，输出总线也无法输出，设施不会工作。

## 在同一面上输入输出

假如有机器能在单个面上同时接收输入和弹出输出（比如<ItemLink id="charger" />），则可综合2种管道子网络以在同一面上输入材料和抽出产物：

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/import_storage_export_pipe.snbt" />

<BoxAnnotation color="#dddddd" min="4 1 1" max="5 1.3 2">
        （1）输入总线：可过滤。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="2 1 1" max="3 1.3 2">
        （2）存储总线：可过滤。此存储总线（以及其他用于输入输出的存储总线）必须为网络中唯一的存储位置。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="2 0 1" max="3 1 2">
        （3）需要输入输出的设备：此处为充能器。
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="0 1 1" max="1 1.3 2">
        （4）输出总线：必须过滤。
  </BoxAnnotation>

<DiamondAnnotation pos="4.5 0.5 1.5" color="#00ff00">
        起点
    </DiamondAnnotation>

<DiamondAnnotation pos="0.5 0.5 1.5" color="#00ff00">
        终点
    </DiamondAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 接口

貌似除了输入总线和输出总线，还有其他[设备](../ae2-mechanics/devices.md)能将物品存入或取出[网络存储](../ae2-mechanics/import-export-storage.md)！此处提及的这种设备就是<ItemLink id="interface" />。如果接口接收到物品而又未设置存储该物品，则其会将该物品存入网络存储，类似于输入总线 -> 存储总线管道。将接口设置为存储物品，则其会从网络存储中抽取，类似于存储总线 -> 输出总线管道。如果需要，接口还可设置为存储某些物品而非其他物品，即可通过存储总线远程输入输出。

<GameScene zoom="6" background="transparent">
<ImportStructure src="../assets/assemblies/interface_pipes.snbt" />

<BoxAnnotation color="#dddddd" min="3.7 0 0" max="4 1 1">
        接口
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1 0 0" max="1.3 1 1">
        存储总线
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="3.7 0 2" max="4 1 3">
        存储总线
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="0 1 2" max="1 1.3 3">
        接口
  </BoxAnnotation>

<IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 一对多与多对一（以及多对多）

当然，<ItemLink id="import_bus" />、<ItemLink id="export_bus" />，以及<ItemLink id="storage_bus" />并非只能使用一个。

<GameScene zoom="3" background="transparent">
<ImportStructure src="../assets/assemblies/many_to_many_pipe.snbt" />

<IsometricCamera yaw="185" pitch="30" />
</GameScene>

## 向多处提供材料

综合上述设计，即可得出从单个<ItemLink id="pattern_provider" />面向多处运输材料的方式，适用于机器阵列，或是单台机器的多个面。

不采用输入 -> 存储管道以及存储 -> 输出管道，因为<ItemLink id="pattern_provider" />无法存储材料，而是会将材料*输出*至相邻容器。因此我们需要能输入物品的某种相邻容器。

而符合条件的设备……就是<ItemLink id="interface" />！并且供应器需为方向型或面板型，或接口为面板型，或两个条件均满足，以避免两者形成网络连接。

<GameScene zoom="6" background="transparent">
<ImportStructure src="../assets/assemblies/provider_interface_storage.snbt" />

<BoxAnnotation color="#dddddd" min="2.7 0 1" max="3 1 2">
        接口（必须为面板型，不能为方块型）
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="1 0 0" max="1.3 1 4">
        存储总线
  </BoxAnnotation>

<BoxAnnotation color="#dddddd" min="0 0 0" max="1 1 4">
        样板供应目的地（多台机器，或单台机器的多个面）
  </BoxAnnotation>

<IsometricCamera yaw="185" pitch="30" />
</GameScene>