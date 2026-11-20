---
navigation:
  title: Overview
  position: 0
item_ids:
- nodeworks:nodeworks_book
---

# Nodeworks

A programmable logistics and automation network.

<GameScene zoom="3" interactive={false} paddingTop="30" paddingRight="30" paddingLeft="10">
  <ImportStructure src="assets/assemblies/subnet.snbt" />
  <IsometricCamera yaw="200" pitch="20" />
  <RemoveBlocks id="minecraft:sandstone" />
</GameScene>

## Sections

- [Getting Started](./getting-started.md)
- [Scripting Reference](./lua-api/index.md)
- [Nodeworks Mechanics](./nodeworks-mechanics/index.md)
- [Items/Blocks](./items-blocks/index.md)
- [Example Setups](./example-setups/index.md)

The Scripting Terminal's editor hovers any documented identifier with its signature and
short description, pressing <Color id="green">[ <KeyBind id="key.nodeworks.open_docs" /> ]</Color> while hovering opens the relevant page here.

See [docs/authoring.md](https://github.com/damienfamed75/nodeworks/blob/main/docs/authoring.md)
for how to add to these docs.
