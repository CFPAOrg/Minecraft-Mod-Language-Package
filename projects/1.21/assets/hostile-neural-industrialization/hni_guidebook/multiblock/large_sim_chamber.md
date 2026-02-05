---
navigation:
  title: "Large Simulation Chamber"
  icon: "hostile_neural_industrialization:large_simulation_chamber"
  position: 0
  parent: hostile_neural_industrialization:multiblock.md
item_ids:
  - hostile_neural_industrialization:large_simulation_chamber
---

# Large Simulation Chamber

###### *The mass production prediction machine. Wait, that's not right... is it? eh, it could go either way*

<GameScene zoom="2" interactive={true} fullWidth={true}>
    <MultiblockShape controller="hostile_neural_industrialization:large_simulation_chamber" />
</GameScene>

Alongside all of [Electric Simulation Chamber](../single_block/electric_sim_chamber.md)'s quirks, it also brings some new ones:

§2§l+ §r§aWhen prediction sequences are successful, it'll generate §l4 §r§apredictions at once

§2§l+ §r§aCollects §l2 §r§adata for the model per sequence

§4§l- §r§cConsumes §l8 §r§cprediction matrixes per sequence

Which essentially boils down to it being able to extract more predictions per sequence. It's advisable to simulate at §d§lSuperior §rtier or higher, since you'll waste lots of energy and Prediction Matrixes for little reward otherwise.


<Recipe id="hostile_neural_industrialization:machine/large_simulation_chamber" />