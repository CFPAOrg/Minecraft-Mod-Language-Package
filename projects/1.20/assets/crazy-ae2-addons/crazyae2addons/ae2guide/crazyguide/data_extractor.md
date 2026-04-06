---
navigation:
  parent: crazyae2addons_index.md
  title: Data Extractor
  icon: crazyae2addons:data_extractor
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:data_extractor
  - crazyae2addons:player_data_extractor
---

# Data Extractor & Player Data Extractor Guide

This guide explains how to use the **Data Extractor** and **Player Data Extractor** 
parts in your AE2 network. These components allow you to read external data and feed it
into your **ME Data Controller**, where it becomes available as variables for automation or logic setups.

---

## Data Extractor

The **Data Extractor** is designed to read information from blocks or block entities directly adjacent to it.

### What it can read:

* **Item handler data**

    * `percentFilled` – Percentage of filled inventory slots.
* **Fluid handler data**

    * `fluidPercentFilled` – How full the fluid tank is.
    * `fluidAmount` – Current fluid amount.
    * `fluidCapacity` – Tank capacity.
* **Energy handler data**

    * `storedEnergy` – Current stored FE.
    * `energyCapacity` – Maximum FE storage.
* **Block state data**

    * `blockName` – Name of the block.
    * `isAir` – Whether the block is air.
    * `isSolid` – Whether the block is solid.
    * `redstonePower` – Neighbor redstone signal strength.
    * `blockLight` / `skyLight` – Light levels at the block.
    * `blockHardness` – Destroy time.
    * `blockExplosionResistance` – Explosion resistance.
    * `blockState:property` – Any block state property (e.g., orientation).

* **Much more when ComputerCraft tweaked is also installed**
  * it acts like a CC computer and is able to read info from peripherals.

### How to use:

1. **Place the part** facing the block you want to read from.
2. **Right-click** it to open the GUI.
3. Press **Fetch** to detect all possible variables from the target.
4. Browse available variables using the arrow buttons.
5. Select one and assign it a **Variable Name**.
6. Set a **Delay** (ticks between updates).
7. The chosen value will be provided to your **ME Data Controller** under the selected name.

---

## Player Data Extractor

The **Player Data Extractor** works similarly, but it reads data from players instead of blocks.

### What it can read:

* `playerName` – The player’s name.
* `playerHealth` / `playerMaxHealth` – Current and max health.
* `playerDistance` – Distance to the extractor.
* `playerIsSneaking` – Whether the player is crouching.
* `playerIsSprinting` – Whether the player is sprinting.
* `playerYaw` – Player’s horizontal rotation.
* `playerPitch` – Player’s vertical rotation.

### How to use:

1. **Place the part** in your network.
2. On placement, it will automatically target the placing player.
3. Open the GUI to view available variables.
4. Press **Fetch** to refresh the list.
5. Select a variable and give it a **Variable Name**.
6. Configure the **Delay** to control update frequency.
7. The selected data will be sent to the **ME Data Controller**.

By default, the extractor looks for the **nearest player**. With **Player Mode**, it can target a specific UUID (the player who placed it).

---

## GUI Controls (Both Extractors)

* **Fetch** – Refresh available variables.
* **Arrows (< >)** – Scroll through pages of variables.
* **Buttons (0–3)** – Select one of the listed variables.
* **Selected** – Shows which variable is currently chosen.
* **Variable Name** – Text field to name the variable (must be ASCII, will be uppercased).
* **Delay** – Interval in ticks between updates.
* **Save (+)** – Saves your settings.

---

## Practical Example

* Place a **Data Extractor** facing a tank.
* Fetch variables and select `fluidAmount`.
* Set variable name to `&WATER_LEVEL`.
* Now, in your **ME Data Controller**, you can use `&WATER_LEVEL` for automation.

---

Both extractors are powerful tools for bridging the AE2 network with **real-time world or player data**,
enabling advanced automation, monitoring, and custom logic setups.
