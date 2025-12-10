---
navigation:
  title: 回响母岩
  icon: "justdynathings:echoing_budding_amethyst"
  position: 1
item_ids:
  - justdynathings:echoing_budding_allthemodium
  - justdynathings:echoing_budding_aluminum
  - justdynathings:echoing_budding_amethyst
  - justdynathings:echoing_budding_ancient_debris
  - justdynathings:echoing_budding_black_quartz
  - justdynathings:echoing_budding_certus
  - justdynathings:echoing_budding_coal
  - justdynathings:echoing_budding_copper
  - justdynathings:echoing_budding_diamond
  - justdynathings:echoing_budding_emerald
  - justdynathings:echoing_budding_entro
  - justdynathings:echoing_budding_gold
  - justdynathings:echoing_budding_iron
  - justdynathings:echoing_budding_lapis
  - justdynathings:echoing_budding_lead
  - justdynathings:echoing_budding_monazite
  - justdynathings:echoing_budding_nickel
  - justdynathings:echoing_budding_osmium
  - justdynathings:echoing_budding_phasorite
  - justdynathings:echoing_budding_platinum
  - justdynathings:echoing_budding_quartz
  - justdynathings:echoing_budding_redstone
  - justdynathings:echoing_budding_ruby
  - justdynathings:echoing_budding_sapphire
  - justdynathings:echoing_budding_silver
  - justdynathings:echoing_budding_time
  - justdynathings:echoing_budding_tin
  - justdynathings:echoing_budding_topaz
  - justdynathings:echoing_budding_tungsten
  - justdynathings:echoing_budding_unobtainium
  - justdynathings:echoing_budding_uraninite
  - justdynathings:echoing_budding_uranium
  - justdynathings:echoing_budding_vibranium
  - justdynathings:echoing_budding_zinc
---

# 生成母岩相关资源的新方法

这些母岩需要**时间流体**（100mB/次）和**能量**（100FE/次）来长出晶簇。

<GameScene zoom="2" interactive={true}>
  <Block id="justdynathings:echoing_budding_time" p:alive="true"/>
  <Block x="1" id="justdynathings:echoing_budding_time" p:alive="true"/>
  <Block x="2" id="justdynathings:echoing_budding_time" p:alive="true"/>
  <Block x="3" id="justdynathings:echoing_budding_time" p:alive="true"/>
  <Block x="-1" id="justdynathings:echoing_budding_time" p:alive="false"/>

  <Block y="1" id="justdirethings:time_crystal_cluster_small" />
  <Block x="1" y="1" id="justdirethings:time_crystal_cluster_medium" />
  <Block x="2" y="1" id="justdirethings:time_crystal_cluster_large" />
  <Block x="3" y="1" id="justdirethings:time_crystal_cluster" />
</GameScene>

基础支持：

- <ItemLink id="justdynathings:echoing_budding_amethyst"/>（Minecraft）
- <ItemLink id="justdynathings:echoing_budding_time"/>（JustDireThings）

各项模组支持：

- <ItemLink id="justdynathings:echoing_budding_certus"/>（[Applied Energistics 2](https://legacy.curseforge.com/minecraft/mc-mods/applied-energistics-2)，应用能源2）
- <ItemLink id="justdynathings:echoing_budding_entro"/>（[Extended AE](https://legacy.curseforge.com/minecraft/mc-mods/ex-pattern-provider)，AE2扩展）
- <ItemLink id="justdynathings:echoing_budding_phasorite"/>（[Phasorite Networks](https://legacy.curseforge.com/minecraft/mc-mods/phasorite-networks)，相能网络）
- _所有[GeOre](https://legacy.curseforge.com/minecraft/mc-mods/geore)（矿石晶洞）母岩_
