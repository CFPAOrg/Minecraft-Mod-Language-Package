---
navigation:
  title: 潮涌核心信标
  icon: nautec:conduit_beacon
  position: 19
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:conduit_beacon
---

# <Color id="light_purple">潮涌核心信标</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="conduit_beacon" scale="2"/>
  由激光驱动的潮涌核心，也能阻止你基地周围刷怪。
</Column>

按原版潮涌核心的需求搭建：信标需要浸在水中，周围3x3x3区域均需充水，并用由海晶石、海晶石砖、暗海晶石、海晶灯组成的框架包裹。需要至少有16个框架方块，完整的框架有42个方块。

它运行时有两个功能：

* 给予水中或雨中的玩家以潮涌能量，和使用相同框架的普通潮涌核心一样。框架含16个方块时范围为32格，框架完整时为96格。
* 水平方向128格内（垂直方向无限制）不会自然生成敌对、友好、环境生物。刷怪笼、刷怪蛋、繁殖、袭击、鱼和鱿鱼等水生生物不受影响。

***

## <Color id="gold">供能</Color>

向信标发射激光。经过框架位置的激光视作框架的一部分，所以可以给光束留出空隙：这些光束的位置算作有框架方块，只填满其他位置也能达到96格的范围。

信标最多能储存5,000 AP。传输功率可补充能量，信标运转时每刻消耗其中的50 AP，也即撤去光束后还可运转约5秒。光束纯度不限。

向信标本身或任意框架方块通入红石信号可暂停信标。而由于信标周围必然都是水，建议在框架方块上放置拉杆或铺设红石线。

透过<ItemLink id="prism_monocle"/>观察，可查看它的状态、框架尺寸、影响范围和储能。

储能消耗速率、能量储量、生成抑制半径分别对应`config/nautec-common.toml`中的`conduitBeaconPowerUsage`、`conduitBeaconBuffer`、`conduitBeaconSpawnRadius`。

<RecipeFor id="conduit_beacon"/>
