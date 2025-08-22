---
navigation:
  parent: aae_intro/aae_intro-index.md
  title: Quantum Computer
  icon: advanced_ae:quantum_core
categories:
  - advanced devices
item_ids:
  - advanced_ae:quantum_unit
  - advanced_ae:quantum_core
  - advanced_ae:quantum_structure
  - advanced_ae:quantum_accelerator
  - advanced_ae:quantum_multi_threader
  - advanced_ae:quantum_storage_128
  - advanced_ae:quantum_storage_256
  - advanced_ae:data_entangler
---

# Quantum Computer

The quantum computer is a special kind of crafting computer. It is capable of running an unlimited amount of crafting
requests, as long as it has enough crafting storage.

<GameScene zoom="2" background="transparent">
  <ImportStructure src="../structure/quantum_computer_multiblock.snbt"></ImportStructure>
</GameScene>

## Quantum Core

<BlockImage id="advanced_ae:quantum_core" p:powered="true" p:formed="true" scale="4"></BlockImage>

The Quantum core is the heart of the Quantum Computer. It has 256M of crafting storage and 8 co-processor threads by
itself. It's the only block that can create a formed quantum computer by itself and provide all the benefits of a
quantum computer. However, if used to create a multiblock, a much more powerful computer can be created. When used as a
standalone computer, power must be provided through the Up or Down sides, where the connectors are.

## Quantum Storages

<Row gap="20">
<BlockImage id="advanced_ae:quantum_storage_128" scale="4"></BlockImage>
<BlockImage id="advanced_ae:quantum_storage_256" scale="4"></BlockImage>
</Row>

These blocks expand the crafting storage of the quantum core. They effectively increase the amount of concurrent tasks
the quantum computer is able to run. There are two variations, with 128M and 256M of capacity.

## Quantum Data Entangler

<BlockImage id="advanced_ae:data_entangler" scale="4"></BlockImage>

Data Entanglers are a special block that affect all storage blocks present in the multi-block. They enable storage
blocks to store data in several dimensions, effectively multiplying their storage by 4. Only one of these can be placed
in each quantum computer multiblock.

## Quantum Accelerator

<BlockImage id="advanced_ae:quantum_accelerator" scale="4"></BlockImage>

Quantum accelerators add 8 co-processors to the Quantum Computer multiblock. It's important to note that all crafting
patterns being run by the quantum computer are able to share all co-processors, so it's probably a good idea to invest
in a great amount of these.

## Quantum Multi-threader

<BlockImage id="advanced_ae:quantum_multi_threader" scale="4"></BlockImage>

Similarly to the Data Entanglers, multi-threaders enable accelerators to run extra threads in separate dimensions,
multiplying their co-processing power by 4. Only one of these can be placed in each quantum computer multiblock.

## Quantum Structure

<Row gap="20">
<BlockImage id="advanced_ae:quantum_structure" scale="4"></BlockImage>
<BlockImage id="advanced_ae:quantum_structure" p:formed="true" scale="4"></BlockImage>
<BlockImage id="advanced_ae:quantum_structure" p:formed="true" p:powered="true" scale="4"></BlockImage>
</Row>

These blocks provide the framing of the quantum computer. They are used as a building block for the quantum computer and
connect everything together.

## The multiblock

To create a multiblock quantum computer, some rules must be followed:
- The maximum size is 7x7x7 (external dimensions);
- No empty spaces can be present inside the multiblock. They can be filled with <ItemLink id="advanced_ae:quantum_unit" />
for no additional benefits;
- Exactly one <ItemLink id="advanced_ae:quantum_core" />;
- At most one <ItemLink id="advanced_ae:data_entangler" />;
- At most one <ItemLink id="advanced_ae:quantum_multi_threader" />;
- All blocks on the outside layer must be <ItemLink id="advanced_ae:quantum_structure" />;
- No block on the inside can be <ItemLink id="advanced_ae:quantum_structure" />.

## Server Configs

Several values can be tweak by server configs. Such as:
- Maximum multiblock size;
- Co-processors in each Quantum Accelerator;
- Maximum amount of Quantum Multi-Threaders;
- Multi-Threader thread multiplication value;
- Maximum amount of Data Entanglers;
- Data Entangler storage multiplication value;

The limits for your instance can be checked using the item's tooltips.