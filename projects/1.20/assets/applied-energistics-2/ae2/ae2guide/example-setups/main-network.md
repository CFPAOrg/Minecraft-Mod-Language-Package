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
  <ImportStructure src="../assets/assemblies/small_base_network.snbt" />

    <BoxAnnotation color="#dddddd" min="3.9 0 1.9" max="9.1 5 7.1" thickness="0.05">
    <BoxAnnotation color="#33dd33" min="5 1 10" max="9 7 14" thickness="0.05">
        一大堆样板供应器和装配室，提供大量合成、切石、锻造样板空间。
        棋盘格式的排布方式能让供应器并行使用多个装配室，同时保持设计紧凑。
        8个一组的设计避免了频道寻路出现错误。
    </BoxAnnotation>

    <BoxAnnotation color="#dddddd" min="3.9 0 9.9" max="5.1 3 12.1" thickness="0.05">
        一些机器，附带一个管道子网络以将产物送入供应器。
    <BoxAnnotation color="#33dd33" min="13 10 12" max="14 11 14" thickness="0.05">
        你其实不需要那么大的控制器，你在其他人基地里看到的那些庞大的环状和立方体状的设计，主要还是为了好看。
    </BoxAnnotation>

    <BoxAnnotation color="#dddddd" min="-0.1 0 8.9" max="1.1 3 13.1" thickness="0.05">
      一些终端和实用设施。（大概只用合成终端比较合适，而不是普通终端_和_合成终端一起用）
    <BoxAnnotation color="#33dd33" min="13 12 13" max="14 13 14" thickness="0.05">
        能量单元是好网络的标配，它能提升每游戏刻的能量输入，还能减少能量波动的影响。
    </BoxAnnotation>

    <BoxAnnotation color="#33dd33" min="2 1 10" max="4 4 13" thickness="0.05">
        推荐使用其他模组的能量源，反应堆、太阳能板、发电机，这些都行。谐振仓也够用，但AE2是为整合包设计的，最好使用基地的主能源。
    </BoxAnnotation>

    <BoxAnnotation color="#33dd33" min="15 1 9" max="16 3 14" thickness="0.05">
        伪装板能把事物藏在墙后。
    </BoxAnnotation>
    <BoxAnnotation color="#33dd33" min="15 3 12" max="16 10 14" thickness="0.05">
        伪装板能把事物藏在墙后。
    </BoxAnnotation>

    <BoxAnnotation color="#33dd33" min="13 9 7" max="14 10 9" thickness="0.05">
        其实不需要为通用存储准备这么多驱动器槽和存储单元，能装满2到4个驱动器的4k或16k存储单元就已足够。
    </BoxAnnotation>

    <BoxAnnotation color="#33dd33" min="13 9 10" max="14 11 11" thickness="0.05">
        过滤为特定物品的大型存储单元最适合大批量存储，需放置在单独的高优先级驱动器组中。
    </BoxAnnotation>

    <BoxAnnotation color="#33dd33" min="10 9 13" max="11.7 13 14" thickness="0.05">
        基于接口的自动维持物品量。
    </BoxAnnotation>

    <BoxAnnotation color="#33dd33" min="6 10 12" max="9 12 15" thickness="0.05">
        充能器自动化设施的逻辑扩展，包含多个充能器。
    </BoxAnnotation>

    <BoxAnnotation color="#33dd33" min="2 10 12" max="5 11 15" thickness="0.05">
        另一种自动化处理器的方式，这是由于1.20中的压印器能够自动弹出产物。
    </BoxAnnotation>

    <BoxAnnotation color="#33dd33" min="3 10 10" max="4 12 11" thickness="0.05">
        另一种自动化处理器的方式，这是由于1.20中的压印器能够自动弹出产物。
    </BoxAnnotation>

    <BoxAnnotation color="#33dd33" min="7.2 9.2 8.2" max="7.8 10 8.8" thickness="0.05">
        无线访问点位于中央，是由其球状范围所致。
    </BoxAnnotation>

    <BoxAnnotation color="#dddddd" min="-0.1 0 -0.1" max="2.1 3 8.1" thickness="0.05">
      合成CPU阵列。较少大容量CPU再加较多小容量CPU。
      实际搭建时可再多加些并行CPU，这种情况下这些应当足够了。
    <BoxAnnotation color="#33dd33" min="14 1 2" max="16 5 7" thickness="0.05">
        通常来说，1到2个大容量合成CPU用于大型任务，再来些稍小的CPU在大容量CPU工作时处理次要任务。
    </BoxAnnotation>

    <BoxAnnotation color="#dddddd" min="5.9 0 13.9" max="7.1 1 15.1" thickness="0.05">
      控制器应当位于基地的中心，且应当比这个稍微大点。长条状就很不错。
    <BoxAnnotation color="#33dd33" min="5 3 6" max="6 4 7" thickness="0.05">
        有些时候子网络需要超过8台设备（比如分发至超过8个位置），此时它们需要独立的控制器。
    </BoxAnnotation>

    <BoxAnnotation color="#dddddd" min="11.9 0 7.9" max="13.1 4 13.1" thickness="0.05">
        多种存储手段，可用驱动器和存储总线。注意均为8个一组。
    <BoxAnnotation color="#33dd33" min="7.3 1 3.3" max="9.7 4 6" thickness="0.05">
        赛特斯石英农场。
    </BoxAnnotation>

    <BoxAnnotation color="#dddddd" min="10.9 0 0.9" max="13.1 2 7.1" thickness="0.05">
        多种存储手段，可用驱动器和存储总线。注意均为8个一组。
    <BoxAnnotation color="#33dd33" min="10.3 1 2.3" max="12.7 3.7 5" thickness="0.05">
        投水自动化。
    </BoxAnnotation>

  <IsometricCamera yaw="315" pitch="30" />
  <IsometricCamera yaw="135" pitch="15" />
</GameScene>
