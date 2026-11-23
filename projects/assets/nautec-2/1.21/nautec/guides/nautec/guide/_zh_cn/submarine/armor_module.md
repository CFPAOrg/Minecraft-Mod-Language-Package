---
navigation:
  title: 护甲模块
  icon: nautec:armor_module
  position: 8
  parent: submarine/submarine-index.md
item_ids:
  - nautec:armor_module
---

# <Color id="light_purple">护甲模块</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="armor_module" scale="2"/>
  潜水器的重型装甲。
</Column>

护甲模块可增加船壳的盔甲韧性，也可避免它被攻击击退。

***

## <Color id="gold">改动</Color>

|          | 未安装    | 安装           |
| -------- | --------- | -------------- |
| 护甲值   | 20        | 20             |
| 盔甲韧性 | 8（钻石） | 12（下界合金） |
| 击退     | 正常      | 无             |

韧性会削减高数值伤害的穿甲量，该模块对防御高攻击力单位很关键。它还会抵消击退，受击也能保持航线稳定。

该模块是被动模块，可在任意槽位中运作，且无需耗能。取出模块后潜水器的数值会回到默认状态。安装一个护甲模块就足够了，第二个不会带来任何增益。它带来的盔甲韧性量可编辑（`submarineArmorModuleToughness`）。

配合[盾御模块](shield_module.md)使用，可以进一步吸收护甲未能抵挡的伤害。船壳防御功能的剩余细节参见[船壳及其修复](submarine_hull.md)。

***

### <Color id="aqua">护甲模块的配方</Color>

<Recipe id="nautec:armor_module"/>
