---
navigation:
  title: ComputerCraft
  parent: integrations/index.md
  position: 1
---

# ComputerCraft

安装有[CC: Tweaked](https://modrinth.com/mod/cc-tweaked)时，电脑会成为外设。脚本能读取电脑界面中的所有内容——网络、频道、节点、节点表、实时I/O遥测数据，并能在显示器上显示。

## 连接

在电脑旁放置CC计算机，或也可用有线调制解调器链接。外设类型为`logistics_computer`：

```lua
local lc = peripheral.find("logistics_computer")
```

## 所有权

电脑属于放置它的玩家。脚本只会看见该玩家能看见的网络，受服务端的节点访问规则和FTB Teams影响。所有人都可通过与该电脑建立连接的CC计算机读取这些网络，务必保证安全。

在相关特性加入前放置的电脑没有所有者。若需与ComputerCraft协作，应先破坏后再次放置。

## 方法

`net`代表网络ID或其全名。频道列表按界面顺序排列，列表各元素的`index`即为[I/O监视器](../computer/io-monitor.md)中显示的`CH`数，从0起始。也即，CH0对应`channels[1]`。图边（下表edges）下的`channels`中也为CH数。

| 方法               | 返回值                                                                                                              |
| ------------------ | ------------------------------------------------------------------------------------------------------------------- |
| `listNetworks()`   | `{ {id, name, nodeCount, starred, color, createdAt}, ... }`                                                         |
| `getChannels(net)` | `{ {index, name, type, nodeCount}, ... }`：频道下没有启用的节点时`type`为nil                                        |
| `getNodes(net)`    | `{ {id, label, block, pos, attachedPos, dimension, visible, highlighted}, ... }`：仅包含加载的节点                  |
| `getGraph(net)`    | `{ name, totalNodes, vertices, edges }`：vertices下有`key, label, x, y, nodes`；edges下有`from, to, type, channels` |
| `watch(net)`       | 开始记录该电脑的遥测数据                                                                                            |
| `unwatch(net)`     | 停止记录                                                                                                            |
| `getFlow(net)`     | 上一次遥测采样数据，在第一秒前调用返回nil；网络未被监测则报错                                                       |

类型可为`item`、`fluid`、`energy`、`chemical`、`source`。

## 实时遥测数据

在`watch`后，每秒都会有`logistics_flow`事件到达：

```lua
local _, side, networkId, sample = os.pullEvent("logistics_flow")
-- sample.channels[1].total, sample.channels[1].resources[1].displayName
```

每一个频道都有其`index`、`type`、`total`（该秒内传输的量，单位与I/O监视器一致），以及`resources`（前16种物品、流体、化学品，均有其`kind`、`name`、`displayName`、`amount`）。能量和魔源频道的resouces列表为空。

计算机重启或断连时监测即会结束，因此需在`startup`脚本中调用`watch`。所有者失去网络访问权，或网络被删除时，监测也会结束，且不会报错。

## 示例

在相连的显示器上显示所有频道的实时速率：

```lua
local lc = peripheral.find("logistics_computer")
local mon = peripheral.find("monitor")
local net = "Main Base"

mon.setTextScale(0.5)
lc.watch(net)
while true do
  local _, _, _, sample = os.pullEvent("logistics_flow")
  mon.clear()
  for i, ch in ipairs(sample.channels) do
    mon.setCursorPos(1, i)
    mon.write(("CH%d %-8s %d/s"):format(ch.index, ch.type or "-", ch.total))
  end
end
```
