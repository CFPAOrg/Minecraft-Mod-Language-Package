---
navigation:
  title: 渗透滤水机
  icon: nautec:osmosis_filter
  position: 5
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:osmosis_filter
---

# <Color id="light_purple">渗透滤水机</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="osmosis_filter" scale="2"/>
  产出水，无需燃料、原材料、光束等外物辅助。
</Column>

## <Color id="gold">使用</Color>

将它放在任意位置，它即会每秒向内部储罐补充1,000 mB（1桶）水。储罐内有16,000 mB（16桶，可配置）后即停工，滤水时机器前部的面板会亮起。

* 用空铁桶右击可取出1,000 mB。也可使用其他流体容器。
* 可用管道从任意面泵出水。滤水机不接受输入。
* 每一面默认都能输出水。[面配置](nautec:getting_started/utilities.md)可单独关闭某面的交互。

空手右击可查看内部储罐、每秒产水量和收到的AP。Jade也能显示储罐和速率。

向装有盐的[搅拌机](mixer.md)注入水可制造盐水，也可将水送入[燃烧发电机](nautec:getting_started/combustion_dynamo.md)。

***

## <Color id="gold">更强大的光束</Color>

渗透滤水机不需要光束，不过向任意面发射光束可加快它的运转速度：每追加40 AP可令输出翻倍，最多每秒1,024,000 mB（两者均可配置）。

| 光束   | 每秒制水量   |
| ------ | ------------ |
| 无     | 1,000 mB     |
| 40 AP  | 2,000 mB     |
| 80 AP  | 4,000 mB     |
| 160 AP | 16,000 mB    |
| 320 AP | 256,000 mB   |
| 400 AP | 1,024,000 mB |

当光束将每秒产量提升至16,000 mB以上时，储罐的容量会相应变为一秒的输出量，避免抽取过程中停滞。光束减弱后，已有的水均会保留，但机器会等到腾出空间后再继续运转。

所有会被强激光加速的机器参见[更强大的光束](nautec:getting_started/stronger_beams.md)。

<RecipeFor id="osmosis_filter"/>
