---
navigation:
  parent: crazyae2addons_index.md
  title: 批次流体P2P
  icon: crazyae2addons:chunky_fluid_p2p_tunnel
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:chunky_fluid_p2p_tunnel
---

# 批次流体P2P通道

批次流体P2P通道是一类线缆子部件，能按固定体积的批次发送流体。在积攒到所配置批次大小（以毫桶计）前，此通道不会进行发送。积攒足量流体之后，它会向链接的输出端发送所配置数量的流体，且会向各个输出端依次输出，保证各端均衡。

## 使用方法

1. **放置子部件**：将批次流体P2P通道放置在ME线缆上，也可朝向连接至储罐或流体机器的接口。
2. **配置批次大小**：空手右击通道以打开其设置。输入需发送的批次大小（以毫桶计，例如`1000`为1桶），并点击“保存”/“Save”。
3. **进行链接**：使用内存卡链接输出端。
4. **填充后发送**：流体进入通道后，如果体积满足批次设置，通道即会向队列中的下一个输出端发送单批次的流体。如果体积不足，则什么都不会发生。