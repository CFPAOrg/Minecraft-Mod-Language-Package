---
navigation:
  title: Replication
  icon: replication:replicator
item_ids:
  - replication:replicator
  - replication:matter_network_pipe
  - replication:identification_chamber
  - replication:disintegrator
  - replication:matter_tank
  - replication:replication_terminal
  - replication:chip_storage
  - replication:replicator_enclosure
  - replication:replicator_motor
---

# Replication

**Replication**是可以复制类型相似的资源的科技模组。比如说可以将泥土变成石头，但没法把泥土变成钻石。

## 重要概念

**物质管道**可以连接Replication的各机器，且具有以下功能：

* 传输**能量**：和各种能量管道类似
* 传输**物质**：会将物质从**分解器**传输至**物质储罐**，以及从**物质储罐**至**其他需要物质的机器**

**鉴定室**会扫描物品，以获取其物质值信息，并将其存入存储芯片。这些**芯片**可放入**芯片存储器**，此后即可在网络中使用。

**复制器**可以切换至“无限模式”，也即不断复制某资源，直至填满资源存储空间或耗尽物质为止。可在GUI中配置模式。若在鉴定室上方放置芯片存储器，则扫描得到的信息会直接送入芯片存储器，无需在鉴定室内放置芯片。

## 工作原理

转化物品时，首先要用**分解器**将其拆分成物质；这种机器可将有物质值的物品变成物质。在扫描完毕、信息存入芯片之后，即可使用**复制终端**请求复制物品。发出请求后，**复制器**会使用储罐中的物质直接变出对应的物品，并将它们送回终端。

<GameScene zoom="4" interactive={true}>
  <ImportStructure src="setup.snbt" />
  <IsometricCamera  yaw="30" pitch="30" />
</GameScene>

## 加速

* 复制器外罩：使用外罩潜行右击复制器可为其附加外罩。外罩将令复制速度加快20%，但同时会增加10%的能量消耗。
* 复制器马达：使用马达潜行右击复制器可为其附加马达。之后，即可在复制器处配置耗时倍率，默认为100%，最快为20%。速度越快，复制失败的概率就越高。复制失败后，复制器需要重新进行复制，但不会额外消耗物质。如需合成马达，应先合成马达的复制蓝图，再对芯片存储器使用蓝图，然后复制即可。

## 物质百科

物质百科是记录了物品与物质及其含量的对应关系的列表，可搜索。复制终端界面搜索栏左侧的按钮可以访问物质百科，也可点击界面右侧的物质图标以访问。

物质百科的搜索栏接受：

* 任意物质名称：会显示所有包含该物质的物品
* `大地>10`：会显示所有含有多于10点大地物质的物品
* `下界=20`：会显示所有恰好含有20点下界物质的物品
* `量子<6`：会显示所有含有少于6点量子物质的物品
* `!大地`：会显示所有不含大地物质的物品
* `*金属`：会显示所有仅含金属物质的物品