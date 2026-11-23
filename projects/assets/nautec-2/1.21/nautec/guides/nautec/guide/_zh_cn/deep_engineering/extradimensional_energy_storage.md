---
navigation:
  title: 超维度能量仓库
  icon: nautec:extradimensional_energy_storage
  position: 14
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:extradimensional_energy_storage
  - nautec:rift_containment_frame
  - nautec:void_containment_frame
  - nautec:abyssal_containment_frame
  - nautec:event_horizon_containment_frame
---

# <Color id="light_purple">超维度能量仓库</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="extradimensional_energy_storage" scale="2"/>
  被约束场约束的奇点，能在奇点背后的空间中贮存FE。可从单个方块升级至9x9的平台。
</Column>

它只能储存FE。仓库本身相当于1级存储设备。每搭建一个框架环都会让它升级，增加它的容量和FE传输速率，奇点也会跟随升级而变大。

***

## <Color id="gold">等级</Color>

| 等级 | 尺寸 | 所需框架环                                           | 容量                     | 各端口每刻传输量 |
| ---- | ---- | ---------------------------------------------------- | ------------------------ | ---------------- |
| 1    | 1x1  | 无                                                   | 10,000,000 FE            | 50,000 FE        |
| 2    | 3x3  | 8个<ItemLink id="rift_containment_frame"/>           | 1,000,000,000 FE         | 500,000 FE       |
| 3    | 5x5  | 16个<ItemLink id="void_containment_frame"/>          | 100,000,000,000 FE       | 5,000,000 FE     |
| 4    | 7x7  | 24个<ItemLink id="abyssal_containment_frame"/>       | 10,000,000,000,000 FE    | 50,000,000 FE    |
| 5    | 9x9  | 32个<ItemLink id="event_horizon_containment_frame"/> | 1,000,000,000,000,000 FE | 2,147,483,647 FE |

每一个框架环都紧贴在前一环之外，与仓库本身齐平：先围上一圈裂隙框架，再是虚空框架，以此类推。只有种类正确的完整框架环才会生效。平台会在放置最后一个框架后自动在一秒内成形，各个方块的外观会合并显示为同一座机器。破坏任意框架后，仓库会降至前一个框架环完整的等级；其中的FE不会丢失，但储量超过容量时无法继续输入。

右击仓库本身或任意成形的框架可打开界面。

***

## <Color id="gold">端口</Color>

仓库各面各有一个端口。仅有仓库本身时，它的四个侧面即是端口。有框架环时，端口位于各边的中央方块处，FE只能从该方块朝外的一面输入输出。

界面上方的四个按钮可将各端口设为**输入**、**输出**或**关闭**。输入端口可接收线缆和机器的FE。输出端口则能向相邻的事物输送FE，也允许线缆抽取。端口默认为输入。

***

## <Color id="gold">共鸣网络</Color>

可在界面中选择和创建网络，操作方法和在[共鸣节点](resonance_node.md)中一致。此后，该仓库即成为网络的储能设备，无需设置模式：

* 由网络输入节点发来、但被所有输出节点拒收的FE，会进入仓库而非送至上行链路。
* 输出节点或共鸣护符需要的超过输入节点供应量时，仓库会补足差距。

它与网络的交流速率最高可为各个方向的端口传输速率，每刻传输。网络的10%损耗仅作用于输出量，不会影响储存的FE。网络中需要存在已发射人造卫星的<ItemLink id="uplink_array"/>，维度不限；若没有，仓库会显示**无核心**。**加载**可保持所在区块加载。

***

## <Color id="gold">移动</Color>

破坏仓库会保留其中的FE，再次放置即恢复；已装满的仓库也可以直接搬到新基地去。框架掉落它们自身。需要使用钻石镐或更高级的镐。

<ItemLink id="configuration_card"/>可复制其网络、端口设置、区块加载设置。

***

## <Color id="gold">配方</Color>

<RecipeFor id="extradimensional_energy_storage"/>
<RecipeFor id="rift_containment_frame"/>
<RecipeFor id="void_containment_frame"/>
<RecipeFor id="abyssal_containment_frame"/>
<RecipeFor id="event_horizon_containment_frame"/>
