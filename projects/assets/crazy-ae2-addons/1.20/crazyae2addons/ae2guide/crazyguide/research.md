---
navigation:
  parent: crazyae2addons_index.md
  title: Research System
  icon: crazyae2addons:research_station
categories:
   - Monitoring and Automation
item_ids:
   - crazyae2addons:research_station
   - crazyae2addons:recipe_fabricator
   - crazyae2addons:research_unit
   - crazyae2addons:research_cable
   - crazyae2addons:research_unit_frame
   - crazyae2addons:research_pedestal_bottom
   - crazyae2addons:research_pedestal_top
   - crazyae2addons:data_drive
   - crazyae2addons:research_fluid_bucket
---

# Research System

The **Research System** is your progression gate for late/advanced content. You perform **Research Recipes** using
a **Research Station** and nearby **Research Pedestals**, powered by **FE** and backed by **Research Units** 
that provide computation (and consume AE power + coolant).

**EACH PEDESTAL NEEDS ITS OWN RESEARCH UNIT MULTIBLOCK**

Completed research writes an **unlock key** to a **Data Drive**. Those keys are then checked by the **Recipe Fabricator**.

## [Video Tutorial](https://youtu.be/ERFPjABnArI&list=PLB8Rr5Xojkr5T1qoPr_4JdETiBkF4qF6r)

---

## Research Station

<GameScene zoom="2" interactive={true}>
  <ImportStructure src="../assets/research_setup.nbt" />
</GameScene>

The Research Station is the “orchestrator”:

* Has a small internal **FE buffer** (25k FE).
* Uses a single **Disk slot** for a **Data Drive** (keys are stored on the drive).
* Automatically scans nearby pedestals and starts research when the inputs match a recipe.

### Energy usage

Every tick while researching, the station drains energy from its internal FE buffer. If it can’t pay the cost, 
the research **hard-resets** (progress goes back to 0).

---

## Research Pedestals (inputs + computation routing)

Research inputs are not placed in the station GUI. Instead, the station reads items from nearby **Pedestal Tops**.

**Scan range and placement:**

* The station scans a **7×7 area** centered on itself (**radius 3 blocks**).
* It looks for **Pedestal Top** block entities at **Y + 1** (one block above the station’s level).
* The matching **Pedestal Bottom** must be directly **under** each top.

### How recipes bind to pedestals

For a recipe to be valid, each **Consumable** entry must be satisfied by **exactly one pedestal**:

* The pedestal top must hold the right **item**.
* That pedestal must contain enough items.
* That pedestal’s connected computation must be at least the amount required by that consumable.

That means you generally can’t "combine" multiple different consumables on one pedestal.

---

## Research Units (computation + coolant)

Research Units are multiblocks that provide the **computation** the pedestals/station rely on.

### Computation value

Computation is derived from the amount of AE2 crafting storage blocks inside the structure:

* 1k = 1/16
* 4k = 1/4
* 16k = 1
* 64k = 4
* 256k = 16

### Operating costs (per tick)

When a pedestal asks a unit to do work, the unit must successfully pay both costs:

* **AE power:** 64AE for each 1 computation unit (cu)
* **Coolant:** drains 1mb **Research Fluid** per 4cu. 

If either cost can’t be paid, the unit refuses work for that tick, and the research will **reset**.

### Coolant tank location

The unit looks for the sky stone tank at its top, and it accepts only **Research Fluid** as a valid coolant.

---

## Research process (what actually happens)

1. Place the required items onto pedestal tops around the station.
2. Insert a **Data Drive** into the station **Disk** slot.
3. Supply **FE** to the station.
4. Ensure your connected Research Units have:
    * AE power available
    * Research Fluid available in the external tank

### Progress speed

Progress increases by **total computation per tick** across all pedestals assigned to the active recipe.

So if you want faster research, increase computation available to the pedestals (more/bigger crafting storage in Research Units)

### Completion

When progress reaches the recipe’s duration:

* The station consumes the required item counts from the assigned pedestals.
* The station writes the recipe’s unlock to the inserted Data Drive.
* A small particle/sound effect plays.

---

## Data Drives and unlock keys

* Keys are stored directly on the drive and are **portable**.
* Research won't start if:
    * there’s no drive inserted, or
    * the drive already contains that recipe’s unlock key.

The drive is not consumed.

---

## Troubleshooting

* **Nothing starts:**

    * Make sure pedestals are within radius 3.
    * Make sure each consumable is on its own pedestal with enough item count.
    * Make sure computation per pedestal meets the recipe requirements.

* **It starts, but constantly resets:**

    * The station is running out of FE.
    * One of the pedestals can’t do work (no AE power / no coolant / unit not formed).
    * Someone moved/changed a pedestal stack mid-research.
