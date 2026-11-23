---
navigation:
  title: 门径
  icon: nautec:gateway
  position: 2
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:gateway
  - nautec:gateway_ring
---

# <Color id="light_purple">门径</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="gateway" scale="2"/>
  长宽13格的直立圆环。穿过它事件视界的任何事物都会从相应地址处的圆环飞出。
</Column>

圆环开口宽9格，即便是<ItemLink id="submarine"/>也能在每一面上留出三格间距。

圆环的底部宽2格，从地面出发搭建时，开口会离地两格。在水下可以直接游进去或者把潜水器开进去，地面上就需要楼梯或者斜坡辅助了。

***

## <Color id="gold">野外的门径</Color>

海床上的门径坐落在小型的海晶石平台上。每一座门径都有与之成对的另一座，两者地址一致，且都无需供能。

第一次有物体穿过野外门径时，另一端即会在大约1,500格外的海洋中成形，物体也会到达那里。此后，两座圆环就会形成固定的通路，无需事先探索或加载。

在这个改动实装之前，野外门径的地址各位均为青色；它们会在圆环重新成形时自动获得另一端的地址。

野外的门径可以和普通门径一样重定向。给它指定你所建造的门径的地址，它就会转而指向你的门径，不再指向原先的另一端。为其指定没有被任何门径使用的地址，下一次穿过它时即会生成使用该地址的另一端。

***

## <Color id="gold">合成与搬运门径</Color>

合成所得的门径已经完成打包，其中已有整座圆环。放置即可一次性建造面朝你的整个圆环结构。

用扳手（<ItemLink id="aquarine_steel_wrench"/>或其他模组的扳手）潜行右击已成形圆环的任意位置，可再次打包圆环，直接取回整座已打包的门径，并保留其地址，这样可以把野外的圆环搬回家而不影响其指向。

圆环会以门径方块为基准建造，需要13格高13格宽的区域。它能覆盖空气、水、海带、海草、珊瑚和其他可替换方块。如果有方块阻挡，放置后即会暂停在门径方块本身，并告诉你方块的位置。透过<ItemLink id="prism_monocle"/>观察门径可红色高亮显示所有阻挡方块。清理完后，圆环会在几秒内成形，也可用扳手右击门径让它立即再次尝试放置。

挖掘已成形的圆环没有掉落物。破坏任意部分的耗时都与手挖黑曜石相同，而且不会掉落任何东西，同时会让圆环的剩余部分回退至普通的<ItemLink id="gateway_ring"/>。建议使用扳手。

放回缺失的组件，再用扳手右击门径，可将其修复如初。

<GameScene zoom="2" background="#333333" interactive={true}>
  <Block id="nautec:gateway_ring" x="4" y="0" z="0"/>
  <Block id="nautec:gateway_ring" x="5" y="0" z="0"/>
  <Block id="nautec:gateway" x="6" y="0" z="0"/>
  <Block id="nautec:gateway_ring" x="7" y="0" z="0"/>
  <Block id="nautec:gateway_ring" x="8" y="0" z="0"/>
  <Block id="nautec:gateway_ring" x="2" y="1" z="0"/>
  <Block id="nautec:gateway_ring" x="3" y="1" z="0"/>
  <Block id="nautec:gateway_ring" x="4" y="1" z="0"/>
  <Block id="nautec:gateway_ring" x="5" y="1" z="0"/>
  <Block id="nautec:gateway_ring" x="6" y="1" z="0"/>
  <Block id="nautec:gateway_ring" x="7" y="1" z="0"/>
  <Block id="nautec:gateway_ring" x="8" y="1" z="0"/>
  <Block id="nautec:gateway_ring" x="9" y="1" z="0"/>
  <Block id="nautec:gateway_ring" x="10" y="1" z="0"/>
  <Block id="nautec:gateway_ring" x="1" y="2" z="0"/>
  <Block id="nautec:gateway_ring" x="2" y="2" z="0"/>
  <Block id="nautec:gateway_ring" x="3" y="2" z="0"/>
  <Block id="nautec:gateway_ring" x="9" y="2" z="0"/>
  <Block id="nautec:gateway_ring" x="10" y="2" z="0"/>
  <Block id="nautec:gateway_ring" x="11" y="2" z="0"/>
  <Block id="nautec:gateway_ring" x="1" y="3" z="0"/>
  <Block id="nautec:gateway_ring" x="2" y="3" z="0"/>
  <Block id="nautec:gateway_ring" x="10" y="3" z="0"/>
  <Block id="nautec:gateway_ring" x="11" y="3" z="0"/>
  <Block id="nautec:gateway_ring" x="0" y="4" z="0"/>
  <Block id="nautec:gateway_ring" x="1" y="4" z="0"/>
  <Block id="nautec:gateway_ring" x="11" y="4" z="0"/>
  <Block id="nautec:gateway_ring" x="12" y="4" z="0"/>
  <Block id="nautec:gateway_ring" x="0" y="5" z="0"/>
  <Block id="nautec:gateway_ring" x="1" y="5" z="0"/>
  <Block id="nautec:gateway_ring" x="11" y="5" z="0"/>
  <Block id="nautec:gateway_ring" x="12" y="5" z="0"/>
  <Block id="nautec:gateway_ring" x="0" y="6" z="0"/>
  <Block id="nautec:gateway_ring" x="1" y="6" z="0"/>
  <Block id="nautec:gateway_ring" x="11" y="6" z="0"/>
  <Block id="nautec:gateway_ring" x="12" y="6" z="0"/>
  <Block id="nautec:gateway_ring" x="0" y="7" z="0"/>
  <Block id="nautec:gateway_ring" x="1" y="7" z="0"/>
  <Block id="nautec:gateway_ring" x="11" y="7" z="0"/>
  <Block id="nautec:gateway_ring" x="12" y="7" z="0"/>
  <Block id="nautec:gateway_ring" x="0" y="8" z="0"/>
  <Block id="nautec:gateway_ring" x="1" y="8" z="0"/>
  <Block id="nautec:gateway_ring" x="11" y="8" z="0"/>
  <Block id="nautec:gateway_ring" x="12" y="8" z="0"/>
  <Block id="nautec:gateway_ring" x="1" y="9" z="0"/>
  <Block id="nautec:gateway_ring" x="2" y="9" z="0"/>
  <Block id="nautec:gateway_ring" x="10" y="9" z="0"/>
  <Block id="nautec:gateway_ring" x="11" y="9" z="0"/>
  <Block id="nautec:gateway_ring" x="1" y="10" z="0"/>
  <Block id="nautec:gateway_ring" x="2" y="10" z="0"/>
  <Block id="nautec:gateway_ring" x="3" y="10" z="0"/>
  <Block id="nautec:gateway_ring" x="9" y="10" z="0"/>
  <Block id="nautec:gateway_ring" x="10" y="10" z="0"/>
  <Block id="nautec:gateway_ring" x="11" y="10" z="0"/>
  <Block id="nautec:gateway_ring" x="2" y="11" z="0"/>
  <Block id="nautec:gateway_ring" x="3" y="11" z="0"/>
  <Block id="nautec:gateway_ring" x="4" y="11" z="0"/>
  <Block id="nautec:gateway_ring" x="5" y="11" z="0"/>
  <Block id="nautec:gateway_ring" x="6" y="11" z="0"/>
  <Block id="nautec:gateway_ring" x="7" y="11" z="0"/>
  <Block id="nautec:gateway_ring" x="8" y="11" z="0"/>
  <Block id="nautec:gateway_ring" x="9" y="11" z="0"/>
  <Block id="nautec:gateway_ring" x="10" y="11" z="0"/>
  <Block id="nautec:gateway_ring" x="4" y="12" z="0"/>
  <Block id="nautec:gateway_ring" x="5" y="12" z="0"/>
  <Block id="nautec:gateway_ring" x="6" y="12" z="0"/>
  <Block id="nautec:gateway_ring" x="7" y="12" z="0"/>
  <Block id="nautec:gateway_ring" x="8" y="12" z="0"/>
</GameScene>

***

## <Color id="gold">供能</Color>

野外门径无需供能。合成所得或搬运再放置的所有门径都需要AP：需向圆环底部的门径方块发射激光（参见[激光功率](nautec:getting_started/laser_power.md)）。它能容纳5,000 AP，开启之后每刻消耗100 AP。门径会在储有2,000 AP之后开启，直到储能耗尽才关闭。有人在附近时，提供100 AP/t的光束就能让门径一直开放。激光过弱时门径只能保持开启几秒，并间歇性关闭以等待储能恢复至2,000。

***

## <Color id="gold">开启</Color>

有玩家或潜水器在约12格内时，有相匹配目的地的圆环即会开启，以便直接把潜水器开进去。它会先发信确认：符文环先旋转，地址三角灯显示相应的颜色，随后再打开事件视界。门径会在所有人都离开周围的几秒后关闭。

向门径方块通入红石信号可保持门径关闭。

***

## <Color id="gold">地址</Color>

九个三角灯里的四个会显示地址：从前面看去的左上、右上、左下、右下。每一位可在八种颜色中选择，总计4,096个地址：

白色、淡蓝色、青色、蓝色、紫色、品红色、黄绿色、黑色。

更改地址没有消耗。有两种改地址的方法：

* 手持染料右击地址三角灯。距离最近的三角灯变为该颜色，并消耗染料。
* 空手右击圆环打开地址界面。1到4行分别对应左上、右上、左下、右下。指定好颜色后点击“设置”。

透过<ItemLink id="prism_monocle"/>观察门径的任意位置，可显示其地址、开启与否和储能。

***

## <Color id="gold">旅行</Color>

从任意一面穿过事件视界，均可传送至地址匹配圆环的前面，保留速率和相对圆环的位置，朝向变为背朝圆环。你的载具会跟随你，载具上的其他乘客也一样；潜水器会携带所有乘员一同传输。生物和物品实体也会被传送。

* 若另一端圆环的前面被阻挡，你会被传送至圆环后面。若两面均被阻挡，那么就不会进行传送，和圆环关闭的表现一样。
* 在进行一次传送之后的5秒内，门径无法再次传送（`config/nautec-common.toml`中的`gatewayCooldown`，100刻），以免你直接被送回去。
* 另一端的门径不需要被加载。传送后门径会自动加载。
* 你必定会抵达距离最近的匹配门径。若有多个圆环共用一个地址，建议重新为它们指定，以确保你能抵达想去的地方。

没有匹配圆环的门径不会亮起，也不会传送经过它的事物。

***

### <Color id="aqua">配方</Color>

<Recipe id="nautec:gateway"/>

<Recipe id="nautec:gateway_ring"/>
