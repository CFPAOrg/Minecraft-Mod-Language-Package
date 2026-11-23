---
navigation:
  title: Teleport Module
  icon: nautec:teleport_module
  position: 14
  parent: submarine/submarine-index.md
item_ids:
  - nautec:teleport_module
---

# <Color id="light_purple">Teleport Module</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="teleport_module" scale="2"/>
  Jump the hull to a saved spot.
</Column>

The Teleport Module jumps the hull and its crew to an anchor point you saved on the module, in any dimension.

***

## <Color id="gold">Binding an Anchor</Color>

Hold the module, stand in water, and sneak-right-click. It saves the block you are in, the dimension, and the direction you are facing, and confirms with "Anchor bound to" and the coordinates. The hull arrives facing that way. Binding again replaces the old anchor.

The tooltip shows the anchor and its dimension, and when you select the module in the pilot's bar its coordinates appear above its name. Each Teleport Module holds its own anchor, so two modules in two slots give you two destinations. They share one cooldown: after a jump, every Teleport Module in the bay waits the full 30 seconds.

Pick an anchor in open water with plenty of room around it. The hull is large, and it needs water at the anchor block and space for the whole hull there.

***

## <Color id="gold">Jumping</Color>

| | Default |
|---|---|
| Power per jump | 200,000 |
| Stored power needed to start | 200,000 (a fifth of the cell) |
| Charge time | 2.5 seconds |
| Cooldown | 30 seconds |

Fire it from the pilot's seat. The hull is drawn forward into a portal that opens ahead of the nose, and after 2.5 seconds it comes out at the anchor with the crew still aboard and drifts forward a little. Steering and the other modules are locked while it charges.

The jump is refused, at no cost, with a message if the module has no anchor ("That teleport module has no anchor bound"), if the cell holds less than 200,000, or if the anchor is out of water or too cramped for the hull ("The anchor is blocked or dry"). The anchor is checked again at the end of the charge. If something has filled it in the meantime the jump is cancelled with the same message, the power comes back to the cell and no cooldown starts, so you can try again straight away.

It is the most expensive thing the hull can do. Top up before relying on it to get home. All the figures are configurable.

***

### <Color id="aqua">Teleport Module Recipe</Color>

<Recipe id="nautec:teleport_module"/>
