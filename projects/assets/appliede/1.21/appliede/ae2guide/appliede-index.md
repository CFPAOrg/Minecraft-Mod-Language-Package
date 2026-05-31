---
navigation:
  title: "Add-on: AppliedE"
  position: 150
---

# AppliedE

<GameScene zoom="4" background="transparent">
  <ImportStructure src="assemblies/appliede.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

A Minecraft mod made as an add-on to both
[*Applied Energistics 2*](https://github.com/AppliedEnergistics/Applied-Energistics-2) and
[*ProjectE*](https://www.curseforge.com/minecraft/mc-mods/projecte) providing more tightly-coupled integration between
the two mods. Unlike conventional add-ons integrating the two together, AppliedE works by turning ProjectE's *EMC* into
a distinct resource able to be displayed, reported and manipulated by an ME network and converted into items upon
request via AE2's auto-crafting facilities and various new devices that harness an alchemist's power directly.

To get started, you will need to make yourself the <ItemLink id="emc_module" /> and place it down anywhere on your ME
network. This will unlock the ability for your network to harness your alchemical knowledge and EMC through dedicated
storage, both via auto-crafting and the whole host of dedicated [transmutation devices](transmutation_devices.md)
offered by AppliedE.
