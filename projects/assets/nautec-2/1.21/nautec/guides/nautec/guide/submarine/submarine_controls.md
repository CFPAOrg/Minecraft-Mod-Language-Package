---
navigation:
  title: Piloting
  icon: nautec:submarine
  position: 1
  parent: submarine/submarine-index.md
---

# <Color id="light_purple">Piloting</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="submarine" scale="2"/>
  Keys, steering and the readout.
</Column>

The pilot drives the Sea Scout with the normal movement keys and steers it by looking, and gets a power and hull readout plus a module bar in place of the hotbar.

***

## <Color id="gold">Keys</Color>

| Key (default) | What it does |
|---|---|
| W | Throttle forward |
| S | Reverse, at half thrust |
| Sprint (Ctrl) held with W or S | 60% more thrust |
| Mouse | Steer: the nose follows your view |
| Space | Rise |
| C | Dive |
| Hold right mouse (use) | Free look: look around without steering, and see through the hull in first person |
| 1 to 9, or mouse wheel | Select a module slot |
| Left mouse, or F | Fire the selected module |
| Ctrl + H | Move the readout |
| Sneak (Shift) | Climb out |

C, F and Ctrl + H are NauTec key bindings, listed in the Controls screen as Sea Scout Descend, Fire Sea Scout Module and Reposition Sea Scout HUD. Rebind them there. While you pilot, F only fires modules, so it does not swap your hands or toggle a Wave Jet light.

***

## <Color id="gold">Steering</Color>

There is no turn key. The hull turns to follow where you look, and under water it pitches up or down as far as 75 degrees. Let go of the right mouse button after free look and your view snaps back to the nose.

In first person the hull fades while you hold free look, so you can look straight down through the floor. Set how solid it stays with the client config option `submarineFreeLookHullOpacity`.

The hull only turns if it has room to. Look into rock and it holds its heading rather than clipping through, so back off or rise before turning in a tight cave. Its collision follows the real shape of the hull as it turns. It only collides with blocks: fish and other creatures in the way get shoved aside.

On the surface the hull stays level and the thrusters work at about a third of their strength, with rising and diving weaker too. Get under water before you expect speed.

With a [Flight Module](flight_module.md) installed, the hull flies instead: out of the water it steers and pitches just as it does under water, Space and C rise and dive at full strength, and it moves half again as fast.

Thrust needs power. With the cell empty the hull drifts.

The third person camera sits 10 blocks back while you ride, so you can see the whole hull. The distance is configurable (`submarineCameraDistance`).

***

## <Color id="gold">The Readout</Color>

Taking the pilot's seat puts a panel on screen with two rows, PWR for the cell and HULL for the hull, each with a percentage. The control scheme is listed under it.

* PWR flashes below 20% and reads CHG when the cell is empty.
* HULL turns red below 35% and flashes below 15%.

The panel replaces the vanilla vehicle hearts, the hotbar and the experience level while you pilot. The nine module slots take the hotbar's place at the bottom of the screen (see [Modules](submarine_modules.md)).

Press Ctrl + H at any time to open the positioning screen, drag the panel where you want it, and press Esc or Ctrl + H again to save. The position is kept in the client config.

The passenger in the back sees none of this and keeps their normal hotbar.
