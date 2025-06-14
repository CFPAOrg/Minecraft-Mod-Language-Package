---
navigation:
  parent: crazyae2addons_index.md
  title: FE抽取P2P通道
  icon: crazyae2addons:extracting_fe_p2p_tunnel
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:extracting_fe_p2p_tunnel
---

# FE抽取P2P通道

FE抽取P2P通道是标准能源P2P通道的变种。它在链接、频率等方面与标准通道一致，但两者间有一项重要特性不同：

> FE抽取P2P通道不要求外部主动输入能量，而是通道自身会主动从面对的方块抽取，并送至链接的输出端。

---

## 工作原理

- 链接和能量传输寻路的方式与普通的能源P2P通道一致、
- FE抽取P2P通道每刻会检查输出端能够接受多少能量。
- 然后，如可行，它会从输入方块处抽出对应量的能量。
- 并自动将能量分发至输出端。

---

## 使用样例

- **标准的能源通道**：
    - 需要将能量弹出或主动输出到通道。
- **FE抽取P2P通道**：
    - 对着电池、机器、FE供应器直接放下即可——它会自动抽取能量。