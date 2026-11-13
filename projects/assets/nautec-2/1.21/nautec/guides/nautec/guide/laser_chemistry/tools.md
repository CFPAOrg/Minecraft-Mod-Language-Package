---
navigation:
  title: Aquarine Steel Tools
  icon: nautec:aquarine_steel_axe
  position: 8
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:aquarine_steel_sword
  - nautec:aquarine_steel_pickaxe
  - nautec:aquarine_steel_axe
  - nautec:aquarine_steel_shovel
  - nautec:aquarine_steel_hoe
---

# <Color id="light_purple">Aquarine Steel Tools</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="aquarine_steel_axe" scale="2"/>
  Tools that run on AP instead of durability, each with an ability you unlock with EAS.
</Column>

## <Color id="gold">Power</Color>

These tools never break. They spend AP instead: most blocks mined or mobs hit cost 1 AP. The bar under the icon shows the charge, and the tooltip gives the exact amount.

With no AP left a tool will not mine, attack or be used on blocks, so keep it topped up on a [Charger](charger.md) or with a [Prismatic Battery](prismatic_battery.md). The Hoe holds 700 AP; the others hold 1,200.

***

## <Color id="gold">Unlocking Abilities</Color>

A new tool has its ability locked. Pour a source block of [Electrolyte Algae Serum](chemistry_introduction.md) and drop the tool into it. After about 7.5 seconds the tool is infused for good and the EAS is used up.

Once infused, hold the tool and shift-right-click to switch its ability on or off. The tool glints while the ability is on.

***

<Row>
  <ItemImage id="aquarine_steel_pickaxe"/>
  ### <Color id="aqua">Pickaxe</Color>
</Row>

Mines a 3x3 square of stone and other pickaxe blocks on the face you break, at 2 AP a block. It skips blocks that hold a block entity, such as chests and machines.

Blocks broken by an ability drop as if mined with a plain tool, so switch the ability off when you want Fortune or Silk Touch to count. This goes for the Axe and Shovel too.

With the ability on, it is also how you harvest a <ItemLink id="prismarine_crystal"/>: see [Prismarine Crystal Shards](crystal_shards.md).

<RecipeFor id="aquarine_steel_pickaxe"/>

***

<Row>
  <ItemImage id="aquarine_steel_axe"/>
  ### <Color id="aqua">Axe</Color>
</Row>

Breaking one log fells every log connected to it, at 2 AP a log, until the tree is down or the axe runs out.

<RecipeFor id="aquarine_steel_axe"/>

***

<Row>
  <ItemImage id="aquarine_steel_shovel"/>
  ### <Color id="aqua">Shovel</Color>
</Row>

Each block it mines costs 1 AP. With the ability on it digs a 3x3 square of dirt, sand, gravel and anything else a shovel mines, on the face you break, at 2 AP for each extra block. It skips blocks that hold a block entity.

<RecipeFor id="aquarine_steel_shovel"/>

***

<Row>
  <ItemImage id="aquarine_steel_hoe"/>
  ### <Color id="aqua">Hoe</Color>
</Row>

Tills a 3x3 patch of dirt or grass into farmland in one use, at 2 AP a block.

<RecipeFor id="aquarine_steel_hoe"/>

***

<Row>
  <ItemImage id="aquarine_steel_sword"/>
  ### <Color id="aqua">Sword</Color>
</Row>

With the ability on it deals 70% more damage while it has AP, and calls lightning down on whatever it hits. Each hit then costs 10 AP.

<Color id="gold">Careful</Color>: the lightning also strikes anything within a few blocks of the target, you included, and can start fires.

<RecipeFor id="aquarine_steel_sword"/>
