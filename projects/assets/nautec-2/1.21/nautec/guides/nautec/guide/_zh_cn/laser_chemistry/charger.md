---
navigation:
  title: 充能器
  icon: nautec:charger
  position: 6
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:charger
---

# <Color id="light_purple">充能器</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="charger" scale="2"/>
  使用激光为能储存AP的物品补充AP。
</Column>

## <Color id="gold">使用</Color>

用物品右击充能器以放入，空手右击以取回。它只能容纳一个物品。

向任意面发射光束。充能器是低矮方块，但侧面射来的光束仍能和上面射来的一样击中它。充能器充能时会发出火花，物品充满即停止。

物品每刻都会按光束的功率充能，最高速率为物品本身的输入上限。光束越强，充能速率越快，最快为上限。

充能器可为所有储存AP的物品充能，包括[海蓝钢工具](tools.md)和[盔甲](nautec:laser_augmentation/aquarine_steel_armor.md)、[海晶电池](prismatic_battery.md)、<ItemLink id="wave_jet"/>、<ItemLink id="atlantean_rifle"/>。

| 物品                 | 容量      | 每刻上限 |
| -------------------- | --------- | -------- |
| 海蓝钢镐、斧、锹、剑 | 1,200 AP  | 128 AP   |
| 海蓝钢锄             | 700 AP    | 128 AP   |
| 海晶电池             | 10,000 AP | 128 AP   |

***

### <Color id="aqua">充能器的配方</Color>

<RecipeFor id="charger"/>
