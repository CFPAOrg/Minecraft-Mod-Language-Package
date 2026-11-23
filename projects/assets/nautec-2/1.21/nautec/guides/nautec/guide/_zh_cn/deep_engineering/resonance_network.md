---
navigation:
  title: 共鸣网络
  icon: nautec:resonance_node
  position: 9
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:prismatic_emitter
  - nautec:tuning_fork
  - nautec:resonance_charm
---

# <Color id="light_purple">共鸣网络</Color>

<Column alignItems="center" fullWidth={true}>
  <Row>
    <ItemImage id="uplink_array" scale="2"/>
    <ItemImage id="resonance_node" scale="2"/>
  </Row>
  在基地间不借助线缆传输激光功率（AP）和Forge能量（FE）的有名称网络。
</Column>

共鸣网络由<ItemLink id="uplink_array"/>、[共鸣节点](resonance_node.md)、共鸣护符链接而成，无论各部分相隔多远都能保留链接。网络的核心是已发射人造卫星的上行链路阵列：输入节点和线缆可向它发送AP和FE，它则会向输出节点和护符发送。网络的核心参见[海棱人造卫星](prism_satellite.md)，能量与功率的输入输出参见[共鸣节点](resonance_node.md)。

***

## <Color id="gold">搭建设施</Color>

1. 放置<ItemLink id="resonance_node"/>或<ItemLink id="uplink_array"/>，空手右击打开。
2. 在输入框中输入名称再点击**创建**。网络归你所有，你可以让方块加入该网络。
3. 打开任意位置的其他节点或阵列，使用箭头按钮选择网络。

节点和阵列只会在区块加载时运作。在方块界面中启用**加载**，可保持它所在的区块加载，以此保证长距离的链接在你离开时正常传输，除非服务端关闭了加载功能（`resonanceChunkLoading`）。

***

## <Color id="gold">谁能使用网络</Color>

只有网络的所有者及其信任的玩家可以将方块链接至网络和打开网络中的方块。其他玩家则只会收到消息，给出网络的名称和所有者。

所有者可在网络中的节点和阵列处管理访问权限：

* **信任**：输入在线玩家的名称后点击“信任”。该玩家即可向网络链接方块。可通过玩家名称旁的红叉移除玩家。
* **团队**：安装有FTB Teams时，启用该项可让所有者所在团队所有成员使用网络，无需一一信任。
* **删除**：移除网络，断开所有方块与它的链接。需要再次点击确认。

每个玩家最多拥有16个网络。

***

<Row>
  <ItemImage id="prismatic_emitter"/>
  ### <Color id="aqua">海晶送电器</Color>
</Row>

能无线为附近的机器供能。使用线缆向送电器供应FE，或也可在它旁边放置输出共鸣节点；这之后，链接送电器与机器。送电器会向所有用电器发出一条水晶弦，对它们供应总计10,000 FE/t。输送没有损耗。

1. 手持<ItemLink id="tuning_fork"/>右击送电器，将音叉调谐至它。
2. 右击需要链接的各个机器。再次右击已链接的机器可断开链接。

音叉调谐后可用同种方式链接其他送电器，接力转送能量，抵达距离更远的机器。送电链无法与上游节点产生回环。若需将音叉调谐至其他送电器，应先潜行右击空气。破坏已链接的机器或送电器都会移除送电弦。

送电器可为最远64格处的机器供能（`emitterRange`），最多能链接16台。只有放置送电器的玩家可将音叉调谐至它。用音叉潜行右击送电器可断开所有链接，潜行右击空气则会清空音叉。

***

<Row>
  <ItemImage id="resonance_charm"/>
  ### <Color id="aqua">共鸣护符</Color>
</Row>

无论身在何处，它都会使用网络为你身上的物品供能。

用护符右击共鸣节点或上行链路阵列，可将护符绑定至该网络；绑定需要访问权限。再将护符佩戴在护符槽。每半秒，护符都会从网络任意维度中的[上行链路阵列](prism_satellite.md)抽取FE，并为你物品栏、盔甲槽、饰品槽中的物品补充FE，也会为<ItemLink id="atlantean_rifle"/>、<ItemLink id="prismatic_battery"/>等依赖于激光能量的海蓝科技物品充能。它最多能传输2,000 FE/t，且会和输出节点一样损失10%。

护符里的水晶也具有<ItemLink id="prism_monocle"/>的功能：佩戴后可以查看激光方块的功率和纯度读数，也会和佩戴单片镜一样让水下的视野变得更清晰。

若网络的所有者不再信任你，护符会停止运作，直至信任设置恢复。用护符右击空气可打开其界面。界面中会显示它绑定的网络、网络所有者、网络中上行链路和输出节点的数量、上行链路中有多少FE。界面中可设置护符的优先级：高优先级的护符会在输出节点和低优先级护符之前充能。用它潜行右击空气以解绑。

### <Color id="aqua">共鸣强化件</Color>

若需要腾出护符槽，可以将护符植入为强化件。和其他强化件一样，把它放到[强化站](nautec:laser_augmentation/augmentation_station.md)中，它会被植入你的头部槽位。强化件会保留护符的网络和优先级，充能方式和佩戴护符一致，也包括单片镜的读数功能。共鸣强化件会在死亡时保留。

若需调谐至其他网络，可空手潜行右击共鸣节点或上行链路阵列。若需查看网络和更改优先级，可打开强化件界面（默认为B）再点击头部行。如果同时佩戴了已绑定的护符，会使用该护符而非强化件。
