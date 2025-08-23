---
navigation:
  parent: crazyae2addons_index.md
  title: 抽取式P2P通道
  icon: crazyae2addons:extracting_fe_p2p_tunnel
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:extracting_fe_p2p_tunnel
  - crazyae2addons:extracting_item_p2p_tunnel
  - crazyae2addons:extracting_fluid_p2p_tunnel
---

# 抽取式P2P通道

这些通道是标准P2P通道的变种，能够主动工作。无需向其输入物品、流体或能量，这类通道会自动从所连接的方块中**抽取**内容，并将其送至输出端。

---

## 可用类型

- **物品抽取P2P通道**
  - 自动从所面对的容器中抽取物品送至链接的输出端，最多每刻64个物品。

- **流体抽取P2P通道**
  - 从所面对的流体容器中抽取流体在各输出端间均分，最多每刻64桶。

- **FE抽取P2P通道**
  - 从所面对的能量容器中抽取Forge能量（Forge Energy，FE）送至各输出端，最多可达整型上限。
  - 会根据输出端目标能接受的能量进行分流。

---

## 使用方法

1. **放置通道**
  - 将通道放置在需抽取的位置。

2. **开始链接**
  - 使用内存卡分配频率（先右击频率源，再右击目标）。

3. **链接输出端**
  - 将抽取式通道与各输出端相连。