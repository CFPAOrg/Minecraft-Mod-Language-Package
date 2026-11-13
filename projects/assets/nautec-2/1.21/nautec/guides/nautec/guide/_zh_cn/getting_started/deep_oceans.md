---
navigation:
  title: 海洋深处
  icon: nautec:luminescent_algae
  position: 11
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:hydrothermal_vent
---

# <Color id="light_purple">海洋深处</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="luminescent_algae" scale="2"/>
  海蓝科技添加了四个海洋生物群系，每一个都有独特的植物和动物。
</Column>

在原版的海洋之外，海蓝科技还为游戏新添了四个海洋生物群系。它们只会生成于尚未生成的区块，因此在已有的世界中它们只会出现于已探索的区域之外。

这些生物群系均视作海洋。[深海排水口](nautec:laser_chemistry/drain.md)、幸运垂钓区、海蓝科技结构、原版海底废墟和沉船均能正常运作和出现，整合包启用`config/nautec-common.toml`中的`collectSaltWater`时也能在其中用铁桶舀起盐水。

海蓝科技还会增加海洋的深度。安装有Tectonic时，海洋深度由Tectonic决定。

| 生物群系   | 位置                               | 能见度  |
| ---------- | ---------------------------------- | ------- |
| 深渊海沟   | 距离陆地最远，寒冷气候区           | 约20格  |
| 生物荧光林 | 深海，温水气候区                   | 约130格 |
| 热液喷口区 | 深海，暖水气候区                   | 约50格  |
| 海晶珊瑚礁 | 海岸边的浅水地带，温水或暖水气候区 | 约145格 |

***

## <Color id="gold">深渊海沟</Color>

四个生物群系中最深最黑的，水体几近黑色，水中漂浮着各种粒状物。

* 溺尸的生成量远高于其他海洋，Y小于40的黑暗处还会生成深渊鮟鱇。
* 海床上长有深渊珊瑚。海洋中会出现弹砂鱼、鳕鱼、鱿鱼、发光鱿鱼。
* <ItemLink id="budding_prismarine"/>会在海床顶层生成。注意观察它发出的微光。
* 这里是放置[深渊压力锻造机](nautec:deep_engineering/pressure_forge.md)的最佳位置。这种机器需要处于足够深的水域、且上方柱状空间内有水。

***

## <Color id="gold">生物荧光林</Color>

清澈的鸭绿色水体，水中漂浮着会发光的孢子。

* 海床上长有深海海带、荧光海藻、海草、海泡菜，海床岩石的各面附着有大片的发光珊瑚虫。
* 会出现灯笼水母、弹砂鱼，以及大量发光鱿鱼。
* 和海沟一样，这里的海床顶层也会形成海晶母岩。

### 发光洞窟

完全被水填满的洞穴，出现于荧光林海床下方，可通过海床上的狭窄竖直孔道抵达。这里的墙壁被发光珊瑚虫覆盖，底部点缀着发光的荧光海藻和海泡菜；它们足够明亮，可在孔道中轻松辨识。

* 每一个洞窟的底部都有一个<ItemLink id="budding_prismarine"/>，其上通常已长有海晶簇。
* 大约每三个洞窟中会有一个的底部存在一个<ItemLink id="rusty_crate"/>，其中有可供回收的资源。
* 它们不会与干燥的洞穴联通，也即发光洞窟必然全部被水填满。

***

## <Color id="gold">热液喷口区</Color>

浑浊的棕色水体，海床中有玄武岩和岩浆块团，到处都是上浮的气泡。

* 海床上长有喷口管虫。
* 海床上有喷口爬蟹活动，它们会掉落甲壳板。
* 海床上裸露的岩浆块会形成气泡柱，可在此处为玻璃瓶填充压缩空气，以供[潜水套装](diving_gear.md)使用。

### 喷口地带

从海床上凸起的玄武岩-黑石烟囱群，由二到五根烟囱组成，最高者可达八格高。每根烟囱的顶部都有<ItemLink id="hydrothermal_vent"/>在向外喷出烟雾和气泡，烟囱的内部和下方则是岩浆块，烟囱基部汇聚有大量的喷口管虫。

* 烟囱壁中嵌有铜矿石、铁矿石、金矿石。
* 热液喷口会灼烧其上方的所有事物，和岩浆块类似。潜行可在其上安全行走。
* 用镐挖掘可将它带走。它上方的[喷口汇热器](nautec:getting_started/ocean_generators.md)会将其视作三个热源，相当于三个岩浆块。

***

## <Color id="gold">海晶珊瑚礁</Color>

明亮清澈的浅水区。

* 海床中会出现珊瑚、海泡菜以及海晶石团，其间生长着海晶长叶。
* 海床顶层和海晶石团中都会出现<ItemLink id="budding_prismarine"/>。这里也是最容易发现它们的地方。
* 热带鱼、弹砂鱼、鱿鱼、海豚。

***

## <Color id="gold">给整合包作者</Color>

`config/nautec-worldgen.toml`中的`enableBiomeInjection`可用于关闭本页中生物群系的生成。使用自定义主世界预设的整合包应将其加入`injectableWorldPresets`。安装有Lithostitched时，生物群系的放置转而来自`data/nautec/lithostitched/biome_injector`中的生物群系注入器文件，Terralith和Tectonic也已囊括在其中。

生物群系标签`nautec:has_budding_prismarine`下的非海蓝科技生物群系会在海床上生成孤立的海晶母岩，标签下默认有暖水海洋和温水深海。如需让其他模组的温暖海洋也生成，应将它们加入该标签。`nautec:budding_prismarine_grafting`则列出了可移植得到嗜岩石菌的地点，其中已包含前一标签。

植物和动物的内容参见[深海生命](deep_life.md)。
