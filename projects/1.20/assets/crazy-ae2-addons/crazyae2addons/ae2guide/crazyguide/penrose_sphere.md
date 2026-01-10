---
navigation:
  parent: crazyae2addons_index.md
  title: Penrose Sphere
  icon: crazyae2addons:penrose_controller
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:penrose_controller
  - crazyae2addons:penrose_frame
  - crazyae2addons:penrose_coil
  - crazyae2addons:penrose_port
  - crazyae2addons:penrose_injection_port
  - crazyae2addons:penrose_heat_vent
  - crazyae2addons:penrose_hawking_vent
  - crazyae2addons:penrose_mass_emitter
  - crazyae2addons:penrose_heat_emitter
---

# Penrose Sphere

<GameScene zoom="1" interactive={true}>
  <ImportStructure src="../assets/penrose_sphere.nbt" />
</GameScene>

Any frame is a valid ComputerCraft peripheral.

## [Video Tutorial](https://youtu.be/StXovPP4rk0&list=PLB8Rr5Xojkr5T1qoPr_4JdETiBkF4qF6r)

The **Penrose Sphere** is a late-game multiblock generator built around a contained black hole. By feeding it **Singularities**, it builds an **accretion disk** that converts mass into **Forge Energy (FE)**.

You manage a **stable operating point** by balancing:

* **Injection** (feeding Singularities)
* **Cooling** (Heat Vents)
* **Evaporation** (Hawking Vents)
* **Output** (Power Ports)

---

## Requirements

* The multiblock **must be formed**.
* The controller **requires an AE2 channel** and draws **2 AE/t** idle power.
* The controller has a **Disk Slot** that only accepts an **AE2 4k Storage Cell** dedicated to **Super Singularities**.
* The cell must contain **only Super Singularities**.
---

## Startup

1. **Insert a 4k Storage Cell** into the controller’s **Disk Slot**.
2. Fill the cell with enough **Super Singularities** to pay the **startup cost** (configurable, default: full 4k item cell).
3. In the controller GUI click, **Start the Black Hole**.

   * The controller consumes the startup cost from the cell.
   * The black hole begins at a configurable **initial mass**.

> If the structure isn’t formed, the black hole cannot be started.

---

## How power generation works now

### Accretion disk (the “smoothing buffer”)

Singularities you inject do **not** become black-hole mass instantly. They enter the **accretion disk** first and then “fall in” over time.

* The disk keeps a rolling history of about **120 seconds**.
* The effective **orbit delay** (smoothing time) is about **60 seconds**.

This means power ramps up and ramps down smoothly instead of instantly.

### Heat and efficiency

The disk generates **heat** (internal unit: **MK**). Heat is not just a danger value - it also affects efficiency.

* At **low heat**, efficiency is close to **0** (almost no power).
* Efficiency rises until the **peak heat** (default: **50,000 MK**).
* Above the peak, efficiency falls again.
* If heat reaches the **max heat** (default: **100,000 MK**), the sphere **melts down**.

To stay productive *and* safe, you generally want to hold heat **near the peak** using **Heat Vents**.

### Black hole mass (“sweet spot”)

Power output is multiplied by a **mass factor** based on how close the black hole mass is to a configured **sweet spot** (middle of the allowed mass window).

* At the edges of the window, mass factor is **1.0**.
* At the sweet spot, mass factor reaches **MassFactorMax** (default: **2.0**).

Mass factor boosts both **power** and **heating**, so running at the sweet spot is stronger but needs better cooling.

If black hole mass reaches the configured **max mass**, the sphere **melts down**.

---

## Feeding, cooling, and mass control

### Injection (feeding Super Singularities)

Injection is handled via the multiblock’s injection components (e.g. Injection Ports). Internally, the controller has a hard cap of **MaxFeedPerTick** (default: **4096**).

You don't want to get anywhere close to this value though. Everything above 20 singularities/t is almost guaranteed meltdown, or at least lower net gain in power.

Important behavior:

* Injection can be **temporarily blocked** while the system is venting / evaporating (see Hawking Vents).
* Over-injecting without enough cooling will spike heat and can cause a meltdown.

### Heat Vents (cooling)

Heat Vents can remove heat when powered (redstone signal).

**THERE CAN BE ONLY 1 VENT PER MULTIBLOCK** and the cooling cost rises exponentially.

* Cooling costs **FE**.
* The controller will try to pay vent costs in this order:
   1. From power generated this tick
   2. From the controller’s stored FE buffer
   3. From the vent’s internal FE buffer
* If you can only pay part of the cost, you get **partial cooling**. So better connect them to your power spine.

### Hawking Vents (evaporation)

Hawking Vents reduce black hole mass (Hawking evaporation) when powered.

**THERE CAN BE ONLY 1 VENT PER MULTIBLOCK** and the venting cost rises exponentially.

* Evaporation costs **FE** (usually expensive).
* Evaporation is applied proportionally to how much of the cost you manage to pay.
* While Hawking Vents are active, the controller **stops all injection ports**.
* The black hole mass cannot be evaporated below the configured **initial mass**.

---

## FE output

* The controller stores generated energy in an effectively unbounded internal buffer.
* **Power Ports** actively export FE to adjacent blocks.
* The controller itself exposes an FE capability and can be drained by FE cables/pipes.
* The capability is also shared by all Penrose Frames in the multiblock.

The GUI also shows:

* **Last Generated FE/t (gross)** - what the disk produced before paying vent costs
* **Last Consumed FE/t** - what vents consumed
* **Stored FE** - what remains in the controller buffer
* **Energy in Disk** - an estimate of potential disk energy.

---

## Output math (for balancing / configs)

Gross generation per tick is based on disk flow, heat efficiency, and mass factor:

FE/t (gross) ≈ DutyCompensation * BaseFEPerFlow * DiskFlow * HeatEfficiency * MassFactor

With defaults at peak heat and sweet-spot mass, each **~1 “flow” (≈ 1 singu/t steady-state)** is roughly:

* ~**179,000,000 FE/t gross** (before vent costs)

Your real output will be lower if vents are running, or if heat is far from the peak, or if mass is far from the sweet spot.

---

## Safety and meltdowns

A meltdown triggers when either:

* **Heat ≥ MaxHeat**, or
* **Black hole mass ≥ MaxMass**

On meltdown, it can cause catastrophic black hole sized explosion (if not disabled via config).

**Do not** run unattended without:

* reliable cooling,
* mass control,
* and some form of monitoring.

---

## Practical tips

* Treat it like a reactor:
  * **Injection** increases output, heat, and mass.
  * **Heat Vents** stabilize heat around the peak.
  * **Hawking Vents** keep mass from drifting into the danger zone.
* If heat is climbing, and you can’t afford cooling, **stop injection** immediately.
* If mass is trending upward over time, plan periodic evaporation to stay near the sweet spot.
