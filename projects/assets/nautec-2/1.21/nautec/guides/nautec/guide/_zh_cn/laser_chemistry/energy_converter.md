---
navigation:
  title: 能量转换器
  icon: nautec:energy_converter
  position: 1
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:energy_converter
  - nautec:creative_power_source
  - nautec:creative_energy_source
  - nautec:energy_conversion_upgrade
  - nautec:advanced_energy_conversion_upgrade
  - nautec:ultimate_energy_conversion_upgrade
---

# <Color id="light_purple">能量转换器</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="energy_converter" scale="2"/>
  将来自其他模组的Forge能量（Forge Energy，FE）转换为激光束。
</Column>

转换器的转换是单向的：输入FE，输出AP。

***

## <Color id="gold">使用</Color>

使用其他模组的管道或发电器向它输送FE。转换器的容量上限为4,000,000 FE（`config/nautec-common.toml`中的`energyConverterFeCapacity`）。

每10 FE转换为1 AP（`energyConverterFePerAp`）。只要有接收端，转换器的六面就都可以射出激光，最远至16格。AP会在各个接收端间均分，向下取整。150 AP分给两个接收端，每个接收端收到75 AP；分给四个接收端，每个收到37 AP。它只会在有接收端时消耗FE，没有传输目标的转换器会保留缓存。

右击可设置传输速率：每刻传输的AP量。按钮的步长为1或10，按住Shift为10或100，按住Ctrl为100或1,000。界面中还会显示所设速率对应的FE/t；发电器供应不足时，可以降低传输速率，避免缓存不足导致光束中断。速率填0可关闭转换器。

***

## <Color id="gold">升级</Color>

没有升级的转换器最多输出150 AP/t。屏幕中共有三个升级槽，每个等级各一个，每个槽位能容纳最多8个相应升级：

| 升级                                                | 每个升级追加量 | 8个升级总追加量 |
| --------------------------------------------------- | -------------- | --------------- |
| <ItemLink id="energy_conversion_upgrade"/>          | 150 AP/t       | 1,200 AP/t      |
| <ItemLink id="advanced_energy_conversion_upgrade"/> | 500 AP/t       | 4,000 AP/t      |
| <ItemLink id="ultimate_energy_conversion_upgrade"/> | 1,500 AP/t     | 12,000 AP/t     |

三个槽位全装满后上限为17,350 AP/t，也即消耗173,500 FE/t。取出升级会将速率限制到较低的上限。

<Recipe id="nautec:energy_conversion_upgrade"/>
<Recipe id="nautec:advanced_energy_conversion_upgrade"/>
<Recipe id="nautec:ultimate_energy_conversion_upgrade"/>

***

## <Color id="gold">纯度</Color>

它发出的光束纯度为0，足够[搅拌机](mixer.md)、[深海排水口](drain.md)、[充能器](charger.md)和所有不要求纯度的物品转化使用。由于聚焦透镜对原本纯度为0的光束无效，透镜也无法提高它的纯度。

若只是需要FE来获取激光功率，可以将转换器光束和其他高纯度光束汇合起来，例如在[激光转接器](laser_manipulation.md)处汇合。合并后，光束的纯度会接近各来源中最纯净的：来自海晶水晶的纯度3.0光束与转换器光束合并，所得光束的纯度大约是2.6。高纯度光束源参见[激光光学](nautec:deep_engineering/beam_optics.md)。

<Recipe id="nautec:energy_converter"/>

***

<Row>
  <ItemImage id="creative_power_source"/>
  ### <Color id="aqua">创造功率源</Color>
</Row>

供测试使用的创造模式独占激光源。它会发出纯度为0、功率为100 AP/t的光束，不需要燃料；功率会在各个正方向上的接收端间均分。它可在海蓝科技的创造标签页中找到。

***

<Row>
  <ItemImage id="creative_energy_source"/>
  ### <Color id="aqua">创造能量源</Color>
</Row>

无尽的FE供应源，可用于测试能量转换器。它不会向外送出能量，因此需要用能抽取能量的线缆连接。它可在海蓝科技的创造标签页中找到。
