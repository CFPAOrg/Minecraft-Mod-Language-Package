```json
{
  "title": "法术抄绘",
  "icon": "trickster:scroll_and_quill",
  "ordinal": 1
}
```

<|pattern@trickster:templates|pattern=0\,4\,8\,7,title=延枝之修订|>

{gray}（抄绘图案）{}

---

向任意圆添加一个新子圆。

;;;;;

![](trickster:textures/gui/img/extension_revision.png,fit)

在蓝色圆中绘制延枝之修订后，即会创建绿色圆。

;;;;;

<|pattern@trickster:templates|pattern=0\,4\,8\,5,title=内环之修订|>

{gray}（抄绘图案）{}

---

向现有的圆添加一个内圆。内圆的功效与符记类似，激活条件也相同。参见[法术片段](^trickster:distortions/functions)。

;;;;;

![](trickster:textures/gui/img/inner_revision.png,fit)

在蓝色圆中绘制内环之修订后，即会创建绿色圆。

;;;;;

内圆的功效与符记类似，能返回其结果，或使用参数执行。


无相接的子圆时，包含内圆的圆会将内圆返回为法术片段。此性质可用于元编程、递归、动态法术的持久存储，诸如此类。

;;;;;

*确有*相接的子圆时，内圆会直接像被[宏伟之谋略](^trickster:distortions/functions#3)调用那样执行，并使用相接子圆的输出作为参数。


需要在多处使用一个值的时候，此性质很实用，因为内圆和法术片段是将片段移回叶节点的唯一方式。

;;;;;

<|pattern@trickster:templates|pattern=3\,0\,4\,8,title=分枝之修订|>

{gray}（抄绘图案）{}

---

将绘制处的圆换成新圆，原有的圆变成新圆的子圆。

;;;;;

![](trickster:textures/gui/img/split_revision.png,fit)

在蓝色圆中绘制分枝之修订后，即会创建绿色圆，并将蓝色圆变成绿色圆的子圆。

;;;;;

<|pattern@trickster:templates|pattern=1\,0\,4\,8,title=生长之修订|>

{gray}（抄绘图案）{}

---

将绘制处的圆作为内圆嵌入其他圆。

;;;;;

![](trickster:textures/gui/img/growth_revision.png,fit)

在蓝色圆中绘制生长之修订后，即会创建绿色圆，并将蓝色圆变成绿色圆的内圆。

;;;;;

<|pattern@trickster:templates|pattern=0\,4\,8,title=嫁接之修订|>

{gray}（抄绘图案）{}

---

移除绘制处的圆。若有子圆，则替换为其第一子圆。

;;;;;

![](trickster:textures/gui/img/grafting_revision.png,fit)

在黄色圆中绘制嫁接之修订后，黄色圆和红色圆都会被删除，并由绿色圆替换黄色圆。

;;;;;

<|pattern@trickster:templates|pattern=0\,4\,8\,5\,2\,1\,0\,3\,6\,7\,8,title=剪枝之修订|>

{gray}（抄绘图案）{}

---

移除绘制处的圆及其子圆。

;;;;;

![](trickster:textures/gui/img/pruning_revision.png,fit)

在黄色圆中绘制剪枝之修订后，黄色圆和红色圆都会被删除。

;;;;;

<|pattern@trickster:templates|pattern=1\,2\,4\,6,title=登升之修订|>

{gray}（抄绘图案）{}

---

扩展绘制处的圆，以替换其外圆。

;;;;;

![](trickster:textures/gui/img/ascension_revision.png,fit)

在蓝色圆中绘制登升之修订后，即会删除红色圆，并由蓝色圆替换。

;;;;;

<|pattern@trickster:templates|pattern=6\,3\,0\,4\,8,title=奉献之修订|>

{gray}（抄绘图案）{}

---

为外圆添加一个子圆。

;;;;;

![](trickster:textures/gui/img/devotion_revision.png,fit)

在蓝色圆中绘制奉献之修订后，即会创建绿色圆。

;;;;;

<|pattern@trickster:templates|pattern=1\,2\,5,title=旋移之修订|>

{gray}（抄绘图案）{}

---

顺时针循环移动绘制处圆的子圆，即最后一个子圆变为第一子圆。

;;;;;

<|pattern@trickster:templates|pattern=1\,0\,3,title=反向旋移之修订|>

{gray}（抄绘图案）{}

---

功效与旋移之修订相反，会逆时针循环移动子圆。

;;;;;

<|pattern@trickster:templates|pattern=2\,4\,3,title=对换之修订|>

{gray}（抄绘图案）{}

---

交换第一子圆和第二子圆。

;;;;;

<|pattern@trickster:templates|pattern=4\,0\,1\,4\,2\,1,title=记事员之修订|>

{gray}（抄绘图案）{}

---

从施法者副手物品中读出法术，并替换绘制处的圆。

;;;;;

<|pattern@trickster:templates|pattern=1\,2\,4\,1\,0\,4\,7,title=内环记事员之修订|>

{gray}（抄绘图案）{}

---

从施法者副手物品中读出法术，并加作绘制处圆的符记。

;;;;;

<|pattern@trickster:templates|pattern=4\,3\,0\,4\,5\,2\,4\,1,title=宏伟之修订|>

{gray}（抄绘图案）{}

---

将绘制处圆的符记换为施法者副手物品中法术施放的结果。需持有[手镜](^trickster:items/mirror_of_evaluation)。

;;;;;

<|pattern@trickster:templates|pattern=1\,4\,7\,6\,4\,8\,7,title=剽窃者之修订|>

{gray}（抄绘图案）{}

---

将绘制处的圆复制入施法者的副手物品。

;;;;;

<|pattern@trickster:templates|pattern=1\,8\,6\,1,title=释义之修订|>

{gray}（抄绘图案）{}

---

将绘制处圆中已有的图案变为图案字面量。

;;;;;

<|pattern@trickster:templates|pattern=1\,0\,4\,8\,7\,6\,4\,2\,1\,4,title=地址之修订|>

{gray}（抄绘图案）{}

---

将绘制处圆的[地址](^trickster:distortions/tree#2)写入另一只手中的物品。
