---
navigation:
  parent: crazyae2addons_index.md
  title: 轮询物品P2P
  icon: crazyae2addons:round_robin_item_p2p_tunnel
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:round_robin_item_p2p_tunnel
---
# 轮询物品P2P通道

轮询物品P2P通道可保证将输入的物品均分到各输出端，就算是多次输入物品也一样。此通道和标准的物品P2P通道不同：后者会优先向距离最近的输出端发送，而前者会记录过往的发送历史，并将输入批次送至最长时间未收到物品的输出端。
