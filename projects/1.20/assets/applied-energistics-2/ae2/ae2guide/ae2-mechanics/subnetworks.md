---
navigation:
  parent: ae2-mechanics/ae2-mechanics-index.md
  title: 子网络
---

# 子网络

<GameScene zoom="4" interactive={true}>
<ImportStructure src="../assets/assemblies/subnet_demonstration.snbt" />

<DiamondAnnotation pos="6.5 2.5 0.5" color="#00ff00">
        物品管道子网络
    </DiamondAnnotation>

<DiamondAnnotation pos="5.5 2.5 0.5" color="#00ff00">
        流体管道子网络
    </DiamondAnnotation>

<DiamondAnnotation pos="4.5 2.5 0.5" color="#00ff00">
        带过滤的破坏面板
    </DiamondAnnotation>

<DiamondAnnotation pos="3.5 2.5 0.5" color="#00ff00">
        成型面板子网络
    </DiamondAnnotation>

<DiamondAnnotation pos="2.5 2.5 0.5" color="#00ff00">
        使用端口与存储总线交互作为主网络可访问的本地子存储网络
    </DiamondAnnotation>

<DiamondAnnotation pos="1.5 1.5 0.5" color="#00ff00">
        又一个物品管道子网络，可将充能的物品返还至样板供应器
    </DiamondAnnotation>

<IsometricCamera yaw="195" pitch="30" />
</GameScene>

“子网络”是个定义不算严格的术语，可认为是任何辅助主网络或完成小任务的网络。这些网络通常很小，所以不需要控制器。子网络通常有2个用途：

* 限制各[设备](../ae2-mechanics/devices.md)所能访问的存储位置（你肯定不希望“管道”子网络上的输入总线能访问主网络存储，也不希望其将物品直接放入存储元件而非目标容器）
* 节省主网络的频道；例如，若将样板供应器和接着若干带存储总线的机器的接口相邻放置，只会占用1个频道；如果每台机器都放一个样板供应器，则会占用多个频道

构建子网络中极为重要的一点便是追踪[网络连接](../ae2-mechanics/me-network-connections.md)。人们通常会把很多接口、总线之类的东西堆在一起，然后想着这些设备能组成子网络，但实际上它们仍通过各种方块型设备与主网络保持连接。

不同色的线缆与子网络的创建没有关系，这么做仅是为避免线缆连接。

子网络可以是

* 替代垃圾桶和虚空升级的AE2网络设施，用于决定如何以最优方案处理垃圾。它会根据物品库存和需求，将物品智能分入堆肥桶阵列或者其他模组的回收器。
* 抽象层。处理子网络中复杂合成过程的所有细节，从主网络视角看来，一整座工厂就如同一台机器。
* 并行层。将一台运行速度慢的机器换成10台这种机器。从主网络视角看来两者完全没有区别，这么做也没有占用更多频道。
* 可在容器间传输物品或流体的输入总线和存储总线，类似物品或流体管道。
* 破坏面板和存储总线，其中破坏面板仅能将破坏下的事物送入存储总线；可以通过这种方式为破坏面板设置过滤。
* 接口和成型面板，其中输入接口的事物会送入成型面板，从而被放置或投掷。
* 自动采集赛特斯石英的设施，受主网络的<ItemLink id="level_emitter" />调节控制。
* 主网络可访问的专用存储系统，由存储总线与接口构造；可以存储大量农场输出，同时避免主存储过载。
* 等等。

<ItemLink id="quartz_fiber" />在搭建子网络中非常有用。它能在网络间传输能量而不提供连接，如此就可向子网络传输能量，而不用到处摆能源接收器和供能线缆了。
