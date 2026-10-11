```json
{
  "title": "Quaternions",
  "icon": "minecraft:firework_rocket",
  "category": "trickster-math-tricks:math-tricks"
}
```

The following patterns regard quaternion operations.

;;;;;

<|glyph@trickster-math-tricks:templates|trick-id=trickster-math-tricks:quat_from_axis,title=Rotating Distortion|>

vector, number -> quaternion

---

Creates a quaternion from an axis and an angle (radians).

;;;;;

<|glyph@trickster-math-tricks:templates|trick-id=trickster-math-tricks:quat_from_comp,title=Quaternary Absorption Distortion|>

number, number, number, number -> quaternion

---

Creates a quaternion from XYZW components.

;;;;;

<|glyph@trickster-math-tricks:templates|trick-id=trickster-math-tricks:quat_euler,title=Quaternary Angle Distortion|>

quaternion -> vector

---

Calculates euler angles (radians) from quaternion.