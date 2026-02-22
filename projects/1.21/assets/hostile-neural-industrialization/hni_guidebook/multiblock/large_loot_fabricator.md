---
navigation:
  title: "Large Loot Fabricator"
  icon: "hostile_neural_industrialization:large_loot_fabricator"
  position: 1
  parent: hostile_neural_industrialization:multiblock.md
item_ids:
  - hostile_neural_industrialization:large_loot_fabricator
---

# Large Loot Fabricator
###### *The ultimate Loot Fabricator*


<GameScene zoom="2" interactive={true} fullWidth={true}>
    <MultiblockShape controller="hostile_neural_industrialization:large_loot_fabricator" />
</GameScene>

Unlike its previous forms, it'll consume a few predictions, even just a single one depending on the model, and generate a batch of all possible loot at once.

<Recipe id="hostile_neural_industrialization:machine/large_loot_fabricator" />

Note that some predictions, like Sheep's, have a large amount of possible outcomes, meaning you'll need multiple output hatches to fabricate loot from them. Remember that, like any other multiblock machine, LLFs will halt if there aren't enough hatch slots for the whole output!




