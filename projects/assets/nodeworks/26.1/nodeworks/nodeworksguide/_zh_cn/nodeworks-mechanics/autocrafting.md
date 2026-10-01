---
navigation:
  parent: nodeworks-mechanics/index.md
  title: 自动合成
  icon: crafting_core
categories:
  - mechanic
---

# 自动合成

自动合成是能将“我想要64个铁镐”转化成64个真正的铁镐的系统。你需要告诉网络哪些配方可用，网络会暂存原材料，并让<ItemLink id="crafting_core" />进行自动合成。

<GameScene zoom="2" interactive={true} paddingTop="5" paddingLeft="30" paddingRight="30">
  <IsometricCamera yaw="160" pitch="20" />
  <ImportStructure src="../assets/assemblies/autocrafting_example.snbt" />
</GameScene>

## 让它跑起来

你需要同一网络中有四样东西：

1. **一个CPU。**&zwnj;放下一个<ItemLink id="crafting_core" />，紧贴它放置一个<ItemLink id="crafting_storage" />，并将核心接至<ItemLink id="node" />。缓存器、冷却器、载件等额外组件的信息，参见[合成CPU](../items-blocks/crafting_cpu.md)。
2. **配方。**&zwnj;将各配方编码到<ItemLink id="instruction_set" />（原版3×3合成）或<ItemLink id="processing_set" />（其余）中，再把它们放到<ItemLink id="instruction_storage" />或<ItemLink id="processing_storage" />中，并接入网络。
3. **原材料。**&zwnj;所需原材料必须位于[网络存储](./network-storage.md)之中。所有通过<ItemLink id="storage_card" />接入的箱子均可。
4. **提出请求的方法。**&zwnj;可以在<ItemLink id="inventory_terminal" />中点选，或者通过<ItemLink id="terminal" />中脚本调用`network:craft(...)`。

四样备齐之后，网络能制作的物品便会出现在物品栏终端内（可通过筛选器显示，也可按住左Alt显示加号），而`network:craft("...")`也会返回一个builder而非nil。

## 请求合成

### 通过物品栏终端

打开终端，找到物品，对其`Alt点击`。输入数量并确认。终端顶部的**合成队列**会显示所有排队的物品。合成完成时，产物会附带上一个标记，此时即可取出产物。不过下一次再次打开终端时，这些产物就将与其他资源汇合。

按住`Alt`可高亮网络知晓制作方式的所有可自动合成物品，即便库存量为0也会显示。

### 通过脚本

脚本可通过`network:craft`排队合成作业，并决定产物的去向：

<LuaCode>
```lua
-- 产物会在制作完成后自动存入网络存储
network:craft("minecraft:door")
```
</LuaCode>

或也可链式通过`:connect(fn)`在合成完成时执行自定义代码

<LuaCode>
```lua
local furnace = network:get("someFurnaceCard")
network:craft("minecraft:charcoal"):connect(function(item: ItemsHandle?)
  if item then
    furnace:insert(item)
  end
end)
```
</LuaCode>

完整的API参见[network:craft](../lua-api/network.md#craft)和[CraftBuilder](../lua-api/craft-builder.md)。

## 取消合成

右击<ItemLink id="crafting_core" />打开其GUI。**“取消”**&zwnj;按钮会在当前有合成作业时出现。点击可终止合成作业，将缓存的所有资源退还至网络存储，并释放CPU。

## 处理集需要handler

<ItemLink id="instruction_set" />配方仅凭自身即可工作。原版的3x3合成无需外部依赖，CPU清楚如何处理它们。

<ItemLink id="processing_set" />配方则不然。处理集只是*声明*了配方（“8个粗铁会变成8个铁锭”），但并不会提及这种转化**如何**发生。需要有东西来把粗铁放进熔炉，再把锭拿回来，这个东西就是**handler**。

handler有两种注册方式：

### 通过处理操作器

<GameScene zoom="5" interactive={true}>
  <IsometricCamera yaw="200" pitch="20" />
  <ImportStructure src="../assets/assemblies/basic_processing_handler.snbt" />
  <BoxAnnotation min="0 2 0" max="1 2.25 1" color="#3C44AA">
    指向熔炉顶面的蓝色频道存储卡
  </BoxAnnotation>
  <BoxAnnotation min="0 0.75 0" max="1 1 1" color="#B02E26">
    指向熔炉底面的红色频道存储卡
  </BoxAnnotation>
</GameScene>

放置<ItemLink id="processing_handler" />并在其GUI中为其绑定配方。将其后部接至主网络，并从其前部出发将子网接至具体的机器。CPU会管理操作器，无需编写脚本。这也是基本上所有“一侧进原料，另一侧出产物”机器的恰当操作方法。

### 通过脚本handler

对于需要控制时序、条件路由、多步流程的配方，可以在<ItemLink id="terminal" />中编写一个Lua handler：

<LuaCode>
```lua
local furnace = network:get("someFurnaceCard")
network:handle("...", function(job: Job, inputs: InputItems)
  -- 把粗铁送至熔炉顶面（类似于熔炉上接漏斗）
  furnace:face("top"):insert(inputs.rawIron)
  -- 等待产物，完成时从熔炉底面抽出（也和漏斗类似）
  job:pull(furnace:face("bottom"))
end)
```
</LuaCode>

若试图自动合成需要处理集又未注册handler的资源，那么合成会失败，并告知哪个配方缺少handler。

完整样例参见[network:handle](../lua-api/network.md#handle)、[Job](../lua-api/job.md)、[InputItems](../lua-api/input-items.md)。

## 出错时怎么做

合成失败时，<ItemLink id="crafting_core" />会在其周围间歇性产生红色的红石粉粒子云。直至打开核心的GUI解除错误，或是发起能成功的新合成作业后，粒子云才会消失。排障时首先找红色粉状粒子，检查核心是最快获知CPU错误的方式。

![](../assets/images/crafting_cpu_erroring.png)

CPU回报的具体消息：

| 消息                                                                                | 意义                                                                                                   |
| ----------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------ |
| (x, y, z)处的CPU未形成                                                              | 核心未接触<ItemLink id="crafting_storage" />，或核心未接至网络。                                       |
| 缺少原材料：N× 某物品……没有可用配方且库存不足。                                     | 网络无法找到这些物品，也没有可以制作它们的配方。向接入网络的箱子补货，或是编写配方。                   |
| 未注册handler：X。在相连终端的脚本内添加`network:handle("recipe", ...)`调用。       | X是缺少Lua handler驱动的处理集配方。参见上文[处理集需要handler](./autocrafting.md#处理集需要handler)。 |
| 合成需要使用N种物品，而CPU仅能存下M种。请追加缓存器或升级。                         | CPU的<ItemLink id="crafting_storage" />数量不足以容纳合成中间步骤的所有物品种类。追加缓存器。          |
| 合成需要在缓存器内暂存至少N个某种物品，而CPU仅能存下M个。请为缓存器升级或进行追加。 | 问题相同但方向不同：合成作业中某一步超出了缓存器单类型的容量。                                         |
