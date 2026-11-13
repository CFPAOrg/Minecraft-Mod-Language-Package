---
navigation:
  title: 工具与实用物品
  icon: nautec:aquarine_steel_wrench
  position: 7
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:aquarine_steel_wrench
  - nautec:configuration_card
---

# <Color id="light_purple">工具与实用物品</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="aquarine_steel_wrench" scale="2"/>
  扳手可用于搭建和旋转海蓝科技方块，也能设置漏斗和管道可访问机器的哪一面。
</Column>

***

<Row>
  <ItemImage id="aquarine_steel_wrench"/>
  ### <Color id="aqua">海蓝钢扳手</Color>
</Row>

扳手有四个模式，潜行右击空气以切换；提示文本和快捷栏上方的消息会显示当前模式。

* 旋转：右击<ItemLink id="aquatic_catalyst"/>、中继器、机器等有朝向的方块，可将它改至下一个朝向。继续点击可遍历所有朝向。
* 物品面和流体面：右击机器面可改变漏斗和管道在该面的行为，潜行右击可反向切换。在物品面模式下，点击已成形生物反应机和工业生物反应机的任意方块，可调整整台反应机的相应面。参见下方“面配置”。
* 链接：通过两次点击让两个激光方块相对。右击<ItemLink id="prismarine_laser_relay"/>、<ItemLink id="laser_junction"/>、<ItemLink id="aquatic_catalyst"/>等发出光束的方块，将其保存为起始端，再右击另一个中继器、机器等目标方块即可。扳手会旋转起始端，让它朝向第二个方块；同时也会旋转第二个方块，让它能接受激光。对于转接器，扳手则只会开放相应的输入和输出面。所选的两方块必须在正方向上对齐，且间距不超过激光的极限；中间被阻挡时快捷栏上方会显示相应的消息。链接之后，扳手的起始端会被清除，方便建立其他链接。右击空气，或右击不发射也不接受激光的方块，均会清除保存的起始端。已保存起始端的扳手会在提示文本中显示其位置。此模式下的扳手无需打开机器界面即可调整朝向。中继器会从后面接受激光，并从其前面射出，因此调整链接朝向会导致中继器无法再收到激光；此时会有消息警告，如需让激光转向可使用<ItemLink id="laser_junction"/>。

以下功能在所有模式都可用：

* 站直时点击未成形强化站、生物反应机、工业生物反应机、深海排水口的控制器方块，可令其成形。
* 点击<ItemLink id="gateway"/>可令其圆环成形。潜行右击已成形的圆环，可让整个圆环掉落为一个物品。参见[门径](nautec:deep_engineering/gateway.md)。
* 潜行右击你种出的海晶水晶，可拾取整个水晶。天然的水晶无法移动。参见[水晶培育](nautec:deep_engineering/crystal_cultivation.md)。
* 右击海洋斥候可打开其模块界面。参见[海洋斥候](nautec:submarine/submarine.md)。
* 右击<ItemLink id="laser_junction"/>面可将其设为输入，潜行右击则设为输出。以相同方式再次点击可关闭该面。
* 点击已成形[生物反应机](nautec:aquatic_biology/bio_reactor.md)的顶层棱，已成形[工业生物反应机](nautec:aquatic_biology/industrial_bio_reactor.md)的顶板，已成形[深海排水口](nautec:laser_chemistry/drain.md)外壁中央方块的外面，可在点击处开放激光端口，以从该处接收激光功率。在排水口中，端口只会向所点击面开放，因此应点击侧面而非顶面或底面。再次点击反应机端口可闭合。对于反应机来说，该功能的按键在物品面模式下已被面配置功能占用，在该模式下也就不可用。

<Recipe id="nautec:aquarine_wrench"/>

***

## <Color id="gold">面配置</Color>

所有能容纳物品和流体的海蓝科技机器都可按面分别选择自动化设施的交互行为。物品和流体行为相互独立。各面可为如下四种模式之一：

* 双向（绿色）：漏斗和管道可送入输入槽，也可从输出槽中抽取。这是所有面的初始行为。
* 输入（蓝色）：漏斗和管道可送入，但无法抽取。
* 输出（橙色）：漏斗和管道可抽取，但无法送入。
* 关闭（灰色）：漏斗和管道无法与该面交互。

无论面配置如何，机器只会将收到的原材料置入输入槽，且只会将输出槽中的产物送给输出，因此管道不会将送入的原材料抽出来。

面配置可通过物品面/流体面模式的扳手更改，也可打开机器界面并调整右侧的小面板。面板中有六面的配置表：前、后、左、右、上、下，以你看向机器前面时各面的名称命名。左击面可切换至下一模式，右击至上一模式。能同时容纳物品和流体的机器会在上方显示物品和流体按钮。没有朝向、或朝向正上正下方的机器会将北面视作前面。

生物反应机和工业生物反应机按结构整体看待，每面只有一个物品面设置：界面中的面指的是多方块该方向上的所有方块面，以北方为前面。深海排水口、聚变反应堆等其他多方块有自己的规则，详见它们各自的页面。

***

<Row>
  <ItemImage id="configuration_card"/>
  ### <Color id="aqua">配置卡</Color>
</Row>

在方块间复制设置。潜行右击机器，可将其配置复制到卡上，再右击其他方块可粘贴。潜行右击空气可清空配置卡。提示文本中会显示设置的来源和作用范围。用配置卡右击必定会进行粘贴，即便是有界面的方块也一样。

* 面配置会向所有可配置面的机器粘贴，可借此用一张卡以相同方块设置一整排的各种机器。
* 方块自身的设置只会粘贴至同种方块：
  * <ItemLink id="confined_spawner"/>的筛选器和白名单模式
  * <ItemLink id="resonance_node"/>的所属网络、输入输出模式、优先级、上限、区块加载设置
  * <ItemLink id="uplink_array"/>的所属网络和区块加载设置
  * <ItemLink id="laser_junction"/>的输入输出面
  * 导管接头的面
  * <ItemLink id="laser_purification_smelter"/>的自动分配设置
* 升级和筛选器也会被复制，且会粘贴至同种方块：导管接头的升级和筛选器、<ItemLink id="energy_converter"/>的升级、生物反应机的升级、激光纯化烧炼机的导管升级。粘贴会从物品栏中取用物品，且会返还目标相应槽中的升级。如果物品不足，那么就不会进行粘贴，同时告诉你还缺什么。

和在界面中选择一样，粘贴共鸣网络时也会检查你有无使用权限。

<Recipe id="nautec:configuration_card"/>
