---
navigation:
  parent: lua-api/index.md
  title: Job
  icon: minecraft:paper
categories:
  - api_types
description: "[network:handle回调函数](network.md#handle)需接受的第一个参数，代表实际的处理作业，handler需负责为其产出产物"
---

# Job

`Job`（作业）是[`network:handle`](network.md#handle)需接受的第一个参数。每一次网络需要运行处理集配方时，它都会调用handler，并传入新建的`Job`和从网络存储中取出的[物品](input-items.md)。handler会将物品送入机器，并调用`job:pull(card)`告诉网络产物将抵达的位置。

## pull

告诉网络产物将抵达的位置。传入任意多个[CardHandle](card-handle.md)，网络便会监测它们，直到完整的产物到达。

若输出已经在其中一张卡片处（瞬时配方、无序合成），则合成作业会在同一刻结束。其他情况下，网络会每刻检查，并拿取卡片处已有的产物。对一次只产出一个锭的熔炉发送大批量作业也不会产生问题。

<LuaCode>
```lua
local furnace = network:get("furnace")
network:handle("...", function(job: Job, items: InputItems)
  furnace:face("top"):insert(items.rawIron)
  -- 在烧炼完成时从底面抽取
  job:pull(furnace:face("bottom"))
end)
```
</LuaCode>

### 多张来源卡片

若产物可能抵达多个位置，可传入多张卡片。网络会按序检查每张卡片，并抽出已有的物品。若产线下游有管道或漏斗根据物品分拣到不同箱子，可以使用此特性。

<LuaCode>
```lua
local furnace = network:get("furnace")
local outboxA = network:get("outbox_a")
local outboxB = network:get("outbox_b")
network:handle("...", function(job: Job, items: InputItems)
  furnace:face("top"):insert(items.rawIron)
  -- 所得锭被分拣到两箱子中的一个，从任意一个抽取
  job:pull(outboxA, outboxB)
end)
```
</LuaCode>

### 先放入物品

`:pull`只会处理输出。你仍需要亲自把[InputItems](input-items.md)送入机器。若在handler返回时仍有资源留在`items.<slot>`内，则该合成作业会被判定为未完成，网络会重新发起。

### 超时

若产物没能抵达输出位置，合成作业最终会超时，输入会被返还至网络存储。各处理集都有自身设定的超时时限（刻），可在GUI中调整，默认为15秒。在处理大批量烧炼、耗时较长的模组配方机器时，可延长时限。

> **注意：**&zwnj;handler内部的错误只会停止*该合成作业*，不会导致脚本崩溃。若合成作业因未知原因挂起，可检查终端的日志，错误信息会输出到那里。
