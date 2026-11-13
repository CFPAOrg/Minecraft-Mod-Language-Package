---
navigation:
  title: 生物群系箱
  icon: nautec:biome_tank
  position: 20
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:biome_tank
---

# <Color id="light_purple">生物群系箱</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="biome_tank" scale="2"/>
  封死的玻璃箱，内部有一小片生物群系。
</Column>

生物群系箱可仅凭自身培养植物，无需提供能量、水或光照。可借此种植其他生物群系的植物。

***

## <Color id="gold">为生物群系箱播种</Color>

用植物右击生物群系箱可播种。此操作会消耗一份植物，之后生物群系箱就会产出它。用另一种植物右击可切换，并返还已长成的植物。

破坏生物群系箱会保留其中植物，搬走后无需再次播种。

<RecipeFor id="biome_tank"/>

***

## <Color id="gold">种植</Color>

已播种的生物群系箱每30秒会产出一份植物（`config/nautec-common.toml`中的`biomeTankTicks`），最多暂存一组。空手右击可取出长成的产物，也可用漏斗和管道从任意面抽出。它不接受输入。暂存满时生物群系箱会停止产出，直到腾出空间再继续。

***

## <Color id="gold">植物</Color>

| 植物                                                            | 出现于     |
| --------------------------------------------------------------- | ---------- |
| <ItemImage id="nautec:glow_polyp" scale="0.5"/> 发光珊瑚虫      | 生物荧光林 |
| <ItemImage id="nautec:luminescent_algae" scale="0.5"/> 荧光海藻 | 生物荧光林 |
| <ItemImage id="nautec:deep_kelp" scale="0.5"/> 深海海带         | 生物荧光林 |
| <ItemImage id="nautec:prismarine_frond" scale="0.5"/> 海晶长叶  | 海晶珊瑚礁 |
| <ItemImage id="nautec:abyssal_coral" scale="0.5"/> 深渊珊瑚     | 深渊海沟   |
| <ItemImage id="nautec:vent_tubeworm" scale="0.5"/> 喷口管虫     | 热液喷口区 |
| <ItemImage id="minecraft:kelp" scale="0.5"/> 海带               | 海洋       |
| <ItemImage id="minecraft:seagrass" scale="0.5"/> 海草           | 海洋       |
| <ItemImage id="minecraft:sea_pickle" scale="0.5"/> 海泡菜       | 暖水海洋   |
| <ItemImage id="minecraft:tube_coral" scale="0.5"/> 管珊瑚       | 暖水海洋   |
| <ItemImage id="minecraft:brain_coral" scale="0.5"/> 脑纹珊瑚    | 暖水海洋   |
| <ItemImage id="minecraft:bubble_coral" scale="0.5"/> 气泡珊瑚   | 暖水海洋   |
| <ItemImage id="minecraft:fire_coral" scale="0.5"/> 火珊瑚       | 暖水海洋   |
| <ItemImage id="minecraft:horn_coral" scale="0.5"/> 鹿角珊瑚     | 暖水海洋   |
| <ItemImage id="minecraft:cactus" scale="0.5"/> 仙人掌           | 沙漠       |
| <ItemImage id="minecraft:sugar_cane" scale="0.5"/> 甘蔗         | 河岸       |
| <ItemImage id="minecraft:bamboo" scale="0.5"/> 竹子             | 丛林       |
| <ItemImage id="minecraft:sweet_berries" scale="0.5"/> 甜浆果    | 针叶林     |
| <ItemImage id="minecraft:glow_berries" scale="0.5"/> 发光浆果   | 繁茂洞穴   |
| <ItemImage id="minecraft:red_mushroom" scale="0.5"/> 红色蘑菇   | 蘑菇岛     |
| <ItemImage id="minecraft:brown_mushroom" scale="0.5"/> 棕色蘑菇 | 蘑菇岛     |
| <ItemImage id="minecraft:crimson_fungus" scale="0.5"/> 绯红菌   | 绯红森林   |
| <ItemImage id="minecraft:warped_fungus" scale="0.5"/> 诡异菌    | 诡异森林   |
| <ItemImage id="minecraft:chorus_fruit" scale="0.5"/> 紫颂果     | 末地       |
| <ItemImage id="minecraft:cocoa_beans" scale="0.5"/> 可可豆      | 丛林       |

***

## <Color id="gold">给整合包作者</Color>

生物群系箱接受`nautec:biome_tank_plants`物品标签下的植物。可通过数据包或KubeJS向其中加入物品，加入后生物群系箱即可种植它。箱中的植物使用植物自己的物品模型，模组植物无需额外纹理。从标签中删去植物会截停已在种植它的生物群系箱。
