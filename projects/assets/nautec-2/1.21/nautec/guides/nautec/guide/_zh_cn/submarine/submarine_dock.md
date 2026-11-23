---
navigation:
  title: 海洋斥候停靠坞
  icon: nautec:submarine_dock
  position: 4
  parent: submarine/submarine-index.md
item_ids:
  - nautec:submarine_dock
---

# <Color id="light_purple">海洋斥候停靠坞</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="submarine_dock" scale="2"/>
  能给所停靠潜水器充能的平台。
</Column>

海洋斥候停靠坞可向停靠的海洋斥候充能，能固定无人的潜水器，还能保证乘员空气充足。

***

## <Color id="gold">搭建设施</Color>

停靠坞是可放置在水下的低矮平台。向它的任意面发射至少20 AP的激光（参见[激光功率](nautec:getting_started/laser_power.md)）。只需有光束即可：停靠坞不会消耗功率，潜水器可完整接收光束的功率。

将潜水器停在平台上。与平台上方3x3高3格区域有重叠即视作已停靠。有潜水器停靠时，停靠坞会固定它，并在潜水器驶离或光束降至20 AP以下时释放。透过<ItemLink id="prism_monocle"/>观察可显示是否有海洋斥候停靠。

***

## <Color id="gold">功能</Color>

* 在仅需20 AP光束的情况下，为潜水器每刻补充40点储能，从空至满约需21分钟，不需要拾取潜水器。更强大的光束可加快充能速率（见下）。速率可配置。
* 固定无人的潜水器；停靠后离开再回来，潜水器仍会待在原位。潜航员的操作优先于平台的固定，因此上船后可以直接驶离。
* 借助接收的功率保证乘员空气充足，即便潜水器能量库耗空也一样。

***

### <Color id="aqua">海洋斥候停靠坞的配方</Color>

<Recipe id="nautec:submarine_dock"/>

***

## <Color id="gold">更强大的光束</Color>

潜水器停靠坞需要20 AP。更强大的光束可加快潜水器的充能速度：速度乘数为(光束功率 ÷ 20)的平方根。

| 光束   | 速度       |
| ------ | ---------- |
| 20 AP  | ×1（正常） |
| 80 AP  | ×2         |
| 180 AP | ×3         |
| 320 AP | ×4         |

20 AP的光束每刻补充40点储能，80 AP的光束每刻80点，以此类推。

加速规则和各个适用的机器参见[更强大的光束](nautec:getting_started/stronger_beams.md)。
