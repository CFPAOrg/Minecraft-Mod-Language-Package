# TIS-3D 参考手册
“Tessellated Intelligence System(嵌合智能系统，TIS)是一 个大规模并行计算机架构，由非均匀的互联异构节点构成。TIS系统对于那些需要处理复杂数据流的应用来说十分合适，如自动金融贸易、大数据收集、以及公民行为分析。”
—— *TIS-100参考手册*

TIS-3D是对TIS系统设计在三维上的重新展现。它的目的 是控制Minecraft世界中各种原本需要复杂红石才能操纵的机器和机制。或者仅是作为一个有趣的挑战！

## 计算机详述
可借助TIS-3D构建强大的模块化计算机。一台计算机包 括一台[控制器](block/controller.md)和最多16个[外壳](block/casing.md)。[外壳](block/casing.md)与控制器共面连接 。注意，与[控制器](block/controller.md)的连接是可传递的：也就是说，若[外壳](block/casing.md)`C1`连接到了一台[控制器](block/controller.md)上，[外壳](block/casing.md)`C2`连接到了[外壳](block/casing.md)`C1`上，那`C2`也会自动与这个[控制器](block/controller.md)相连。

计算机有且只能有一台[控制器](block/controller.md)。如果多个[控制器](block/controller.md)直接或间接连接，计算机就无法启动。一台计算机如果有超过十六个[外壳](block/casing.md)也无法启动。

给[控制器](block/controller.md)的任何面提供红石信号都可以给计算机供能，计算机的运行速度由红石信号强度决定。同时为[控制器](block/controller.md)提供多个红石信号是未定义行为。请联系[控制器](block/controller.md)制造商以获取整套行为规范，因为提供多个红石信号的行为可能会导致保修失效。提供最弱的红石信号将暂停计算机。关闭计算机将完全重置其状态。

## 模块详述
[外壳](block/casing.md)提供了安装六个[模块](item/index.md)的空间，六个模块需安装在[外壳](block/casing.md)的六个面上。 每个[模块](item/index.md)有四个端口，分别为：`UP`、`RIGHT`、`DOWN`、`LEFT`，即上右下左。这些端口使得[模块](item/index.md)可以通过读取和写入值来进行通信。

读写操作是阻塞操作。[模块](item/index.md)通常在执行操作时加锁， 直到操作完成后才会释锁。*可能存在供应方指定的例 外情况*
两个[模块](item/index.md)在共同端口上同时进行读取操作，会导致它们陷入死锁。如果[模块](item/index.md)写入一个没有连接其他[模块](item/index.md)的端 口，它自己也会死锁。解除死锁需重启计算机。对[模块](item/index.md)进行热插拔在技术上是可行的，但通常会导致不可预知的结果。
