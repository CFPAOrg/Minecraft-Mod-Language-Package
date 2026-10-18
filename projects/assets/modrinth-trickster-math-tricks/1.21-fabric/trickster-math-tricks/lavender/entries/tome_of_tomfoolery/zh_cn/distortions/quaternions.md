```json
{
  "title": "四元数",
  "icon": "minecraft:firework_rocket",
  "category": "trickster-math-tricks:math-tricks"
}
```

下述图案能对四元数进行运算与操作。

;;;;;

<|glyph@trickster-math-tricks:templates|trick-id=trickster-math-tricks:quat_from_axis,title=旋转之曲变|>

vector, number -> quaternion

---

依照所给旋转轴和角度（弧度）构造四元数。

;;;;;

<|glyph@trickster-math-tricks:templates|trick-id=trickster-math-tricks:quat_from_comp,title=四元吸收之曲变|>

number, number, number, number -> quaternion

---

依照所给XYZW分量构造四元数。

;;;;;

<|glyph@trickster-math-tricks:templates|trick-id=trickster-math-tricks:quat_euler,title=四元角之曲变|>

quaternion -> vector

---

计算所给四元数的欧拉角（弧度）。