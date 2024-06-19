---
navigation:
  parent: example-setups/example-setups-index.md
  title: 多种存储方式及网络的整洁性
  icon: drive
---

# 多种存储方式及保持网络的整洁性

过滤、[分区](../items-blocks-machines/cell_workbench.md)、[存储优先级](../ae2-mechanics/import-export-storage.md#storage-priority)，这些都能助你构建可供多种事物使用的多层级存储。

大部分存储可分为：
* 通用存储，适用于数量大致为几千的各类事物。实现主要使用小型[存储元件](../items-blocks-machines/storage_cells.md)，比如4k和16k存储元件。
* 大宗存储，适用于数量超出几千范围的各类事物，例如圆石和铁锭。实现主要使用256k存储元件等大型存储元件，也可使用MEGACells附属中的元件。
* 位于农场的本地存储，参见[专用本地存储](specialized-local-storage.md)以及各类赛特斯石英农场（见[简易](simple-certus-farm.md)、[半自动](semiauto-certus-farm.md)、以及[进阶](advanced-certus-farm.md)）。

在物品进入主网络时，优先级使得主网络首先会尝试将其存入专用的大宗存储或本地存储。若是由于过滤和分区设置无法做到，则存入通用存储。这也说明物品**不会主动**在存储间转移，但会在离开或进入网络时“迁移”。若要主动移动物品，可以使用<ItemLink id="io_port" />。

<GameScene zoom="3" interactive={true}>
  <ImportStructure src="../assets/assemblies/network_storage_types.snbt" />

    <BoxAnnotation color="#33dd33" min="11 0 1" max="12 1.3 2" thickness="0.05">
        大宗存储。此处为面对抽屉等大容量存储的带过滤存储总线。该存储总线过滤煤炭。存储总线的优先级高，因此煤炭进入主网络时会首先进入该存储总线，离开主网络时则会优先从*其他*存储位置输出，也即煤炭会“迁移”至该抽屉。

        需要注意：抽屉这类经过优化的大容器性能表现不错，但巨型箱子等拥有大量槽位的、*未*经优化的大容器和存储总线放在一起时会对性能有严重影响。
    </BoxAnnotation>

    <BoxAnnotation color="#33dd33" min="11 0 3" max="12 1 4" thickness="0.05">
        大宗存储。此处为高优先级驱动器中的经分区的256k存储元件。这些存储元件分区为圆石和铁，且装有均分卡，因此铁的位置不会被圆石填满。驱动器的优先级高，因此圆石和铁进入主网络时会首先进入该驱动器，离开主网络时则会优先从*其他*存储位置输出，也即它们会“迁移”至此处。
    </BoxAnnotation>

    <BoxAnnotation color="#33dddd" min="11 0 5" max="12 1 6" thickness="0.05">
        通用存储。此处为装满16k存储元件的驱动器。这些存储元件未经分区。驱动器的优先级中等（此处为0），因此物品等进入网络时会优先进入专用的大宗和本地存储，离开网络时则会优先从该存储输出，也即有对应专用存储的事物会“迁移”出通用存储。
    </BoxAnnotation>

    <BoxAnnotation color="#88ff88" min="11 0 8" max="12 1 9" thickness="0.05">
        此IO端口是整理网络的重要组件。由于存储优先级并不会使得物品*主动*转移，所以应当定时“整理”通用存储中的存储元件，以此将物品移动到对应的专用存储中去。这相当于对存储进行“碎片重组”，以免同种物品被存储在多个位置。
    </BoxAnnotation>

    <BoxAnnotation color="#dd3333" min="14 0 11" max="15 1 12" thickness="0.05">
        位于生物农场的本地存储。此驱动器装有分区为所需掉落物（如骨头和箭）的存储元件。驱动器本身未设置优先级，这是因为主网络处访问该子网络的存储总线才是真正决定优先级的设备。其中的存储元件均装有均分卡和溢出销毁卡。
    </BoxAnnotation>

    <BoxAnnotation color="#dd3333" min="14 1 10" max="15 2.3 11" thickness="0.05">
        位于生物农场的本地存储。此处的存储总线-接口设施允许主网络访问此子网络的存储。存储总线具有较高的优先级，且过滤为子网络中元件所存储的事物。

        需要注意：由于该子网络中带有垃圾处理设施，对应的存储总线必须过滤，否则*所有进入网络的物品流体等*都会被销毁！
    </BoxAnnotation>

    <BoxAnnotation color="#dd3333" min="14 0 9" max="15 1.3 10" thickness="0.05">
        位于生物农场的本地存储。此处面对物质聚合器的存储总线的优先级低于驱动器。那些无法存入驱动器内元件的掉落物会溢出至此，并加以后续处理。这一部分能避免子网络被大量快坏的弓塞满的问题，是十分重要的设施。
    </BoxAnnotation>

    <BoxAnnotation color="#dd33dd" min="8 1 11.7" max="9 2.3 13" thickness="0.05">
        位于西瓜农场的本地存储。该设施的设计与各类赛特斯石英农场示例类似。位于子网络的存储总线会将农作物存入木桶。位于主网络的高优先级存储总线过滤西瓜片，使得主网络能访问收获得来的农作物。
    </BoxAnnotation>

  <IsometricCamera yaw="270" pitch="30" />
</GameScene>