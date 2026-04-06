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
---

# Research System

The **Research System** unlocks advanced content and fabrication recipes by consuming items, energy, and special structures.  
It centers around the **Research Station** block and integrates with JEI/EMI for full recipe browsing.

---

## Research Station

<GameScene zoom="2" interactive={true}>
  <ImportStructure src="../assets/research_station.nbt" />
</GameScene>

- Multiblock-powered machine that runs **Research Recipes**.
- Takes **consumable items**, a **Structure Gadget (Nokia 3310)** with the correct stored structure, and optionally a **Data Drive**.
- Consumes **FE** and **Research Fluid** over time.
- Produces an **unlock key** written to the inserted Data Drive, enabling further crafting in the **Recipe Fabricator**.

---

## Research Recipes

- All research steps are defined as special recipes (research type).
- Recipes are fully visible in **JEI/EMI** with requirements, costs, and unlocks.
- Each recipe may include:
    - **Duration** (ticks to complete)
    - **Energy per tick** and **fluid per tick**
    - **Consumables** (items that are consumed)
    - **Required Structure** checked against the structure on the Nokia 3310
    - **Unlock key + label** (written to Data Drive after success)
    - **Stabilizer requirement** (for some advanced research)

---

## Workflow

1. **Prepare the Gadget**
    - Use the Nokia 3310 to cut and store the correct structure.
    - Insert it into the Research Station when required.

2. **Provide Inputs**
    - Place required consumables in input slots.
    - Insert a Data Drive.

3. **Provide Resources**
    - Provide external tank with **Research Fluid**.
    - Provide **FE** power (up to 25,000 FE buffer).

4. **Run Research**
    - The process automatically starts when inputs match a recipe.
    - Progress can be previewed in the GUI.
    - On success, the structure and consumables are consumed and the unlock key is written to the drive.

---

## Unlock Keys & Data Drives

- Keys are stored inside Data Drives.
- The Research Station writes them automatically.
- Drives can be duplicated: inserting a source drive with keys into inputs, and a target drive into the disk slot will **copy all missing keys** (costing some time, fluid, and energy).

---

## Integration with Fabrication

- Recipes in the **Recipe Fabricator** require specific unlock keys.
- Without the correct key stored on the drive, those recipes won’t start.
- This makes research progression a prerequisite for advanced crafting.

---

## Key Features

- **JEI/EMI integration** – all research/fabrication recipes are visible in the recipe viewer.
- **Structure validation** – ensures you really scanned the correct multiblock.
- **Energy & fluid drain over time** – research requires infrastructure.
- **Drive-based unlock system** – progression is portable across machines.
- **Disk-to-disk copying** – merge unlocks between drives.  
