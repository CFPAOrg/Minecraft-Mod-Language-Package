---
navigation:
  title: Eclipse Alloy Anvil
  icon: "justdynathings:eclipse_alloy_anvil"
  position: 4
  parent: justdynathings:anvils.md
item_ids:
  - justdynathings:eclipse_alloy_anvil
---

# Eclipse Alloy Anvil

An anvil that repair items using Forge Energy (FE) like <ItemLink id="justdynathings:celestigem_anvil"/>
Also when added a [coolant](https://github.com/DevDyna/JustDynaThings/blob/main/src/generated/resources/data/justdynathings/data_maps/fluid/anvils/eclipsealloy_repair.json) , it will repair it based on `coolant-efficiency / 100 x total-damage` that item can recieve more that 1000 foreach tick or will completly repair

<BlockImage id="justdynathings:eclipse_alloy_anvil" scale="4.0"/>

<RecipeFor id="justdynathings:eclipse_alloy_anvil" />

## Default Coolants

| Item                                                                 | Registry ID                      | Efficiency |
| -------------------------------------------------------------------- | -------------------------------- | ---------- |
| <ItemImage id= "justdirethings:time_fluid_bucket"    scale="0.75" /> | justdirethings:time_fluid_source | 10.0x      |
