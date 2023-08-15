---
navigation:
  parent: example-setups/example-setups-index.md
  title: “主网络”示例
  icon: controller
---

# “主网络”示例

许多其他设施都会提及“主网络”。你可能也在疑惑如何将所有[设备](../ae2-mechanics/devices.md)组成可运行的系统。示例见下：

<GameScene zoom="2.5" interactive={true}>
  <ImportStructure src="../assets/assemblies/treelike_network_structure.snbt" />

    <BoxAnnotation color="#dddddd" min="3.9 0 1.9" max="9.1 5 7.1" thickness="0.05">
        提供大量合成、切石机、锻造台样板槽位的一大堆样板供应器和装配室。
        棋盘格式的排布方式能让供应器并行使用多个装配室而保持设施的紧凑性。
        8个一组的设计避免了频道寻路出现错误。
    </BoxAnnotation>

    <BoxAnnotation color="#dddddd" min="3.9 0 9.9" max="5.1 3 12.1" thickness="0.05">
        一些机器，附带一个管道子网络以将产物送入供应器。
    </BoxAnnotation>

    <BoxAnnotation color="#dddddd" min="-0.1 0 8.9" max="1.1 3 13.1" thickness="0.05">
      一些终端和实用设施。（大概只用合成终端比较合适，而不是普通终端*和*合成终端一起用）
    </BoxAnnotation>

    <BoxAnnotation color="#dddddd" min="-0.1 0 -0.1" max="2.1 3 8.1" thickness="0.05">
      合成CPU阵列。较少大容量CPU再加较多小容量CPU。
      实际搭建时可再多加些并行CPU，这种情况下这些应当足够了。
    </BoxAnnotation>

    <BoxAnnotation color="#dddddd" min="5.9 0 13.9" max="7.1 1 15.1" thickness="0.05">
      控制器应当位于基地的中心，且应当比这个稍微大点。长条状就很不错。
    </BoxAnnotation>

    <BoxAnnotation color="#dddddd" min="11.9 0 7.9" max="13.1 4 13.1" thickness="0.05">
        多种存储手段，可用驱动器和存储总线。注意均为8个一组。
    </BoxAnnotation>

    <BoxAnnotation color="#dddddd" min="10.9 0 0.9" max="13.1 2 7.1" thickness="0.05">
        多种存储手段，可用驱动器和存储总线。注意均为8个一组。
    </BoxAnnotation>

  <IsometricCamera yaw="315" pitch="30" />
</GameScene>
