```json
{
  "title": "法术抄绘",
  "icon": "trickster:scroll_and_quill",
  "ordinal": 10
}
```

<|revision@trickster:templates|revision-id=trickster:add_subcircle|>

向任意圆添加一个新子圆。

;;;;;

![](trickster:textures/gui/img/extension_revision.png,fit)

在蓝色圆中绘制延枝之修订后，即会创建绿色圆。

;;;;;

<|revision@trickster:templates|revision-id=trickster:add_inner_circle|>

向现有的圆添加一个内圆。内圆的功效与符记类似，激活条件也相同。参见[法术转离](^trickster:tricks/functions)。

;;;;;

![](trickster:textures/gui/img/inner_revision.png,fit)

在蓝色圆中绘制内环之修订后，即会创建绿色圆。

;;;;;

内圆的功效与符记类似，能返回其结果，或使用参数执行。


无相接的子圆时，包含内圆的圆会将内圆返回为法术片段。此性质可用于元编程、递归、动态法术的持久存储，诸如此类。

;;;;;

*确实有*相接的子圆时，内圆会直接像被[宏伟之转离](^trickster:tricks/functions#4)调用那样执行，并使用与外圆相接的子圆的输出作为参数。


需要在多处使用一个值的时候，此性质很实用，因为内圆和法术片段是将片段移回叶节点的唯一方式。

;;;;;

<|revision@trickster:templates|revision-id=trickster:to_subcircle|>

将绘制处的圆换成新圆，原有的圆变成新圆的子圆。

;;;;;

![](trickster:textures/gui/img/split_revision.png,fit)

在蓝色圆中绘制分枝之修订后，即会创建绿色圆，并将蓝色圆变成绿色圆的子圆。

;;;;;

<|revision@trickster:templates|revision-id=trickster:to_inner_circle|>

将绘制处的圆作为内圆嵌入其他圆。

;;;;;

![](trickster:textures/gui/img/growth_revision.png,fit)

在蓝色圆中绘制生长之修订后，即会创建绿色圆，并将蓝色圆变成绿色圆的内圆。

;;;;;

<|revision@trickster:templates|revision-id=trickster:remove_self|>

移除绘制处的圆。若有子圆，则将其替换为其第一子圆。

;;;;;

![](trickster:textures/gui/img/grafting_revision.png,fit)

在黄色圆中绘制嫁接之修订后，黄色圆和红色圆都会被删除，并由绿色圆替换黄色圆。

;;;;;

<|revision@trickster:templates|revision-id=trickster:remove_self_recursive|>

移除绘制处的圆及其子圆。

;;;;;

![](trickster:textures/gui/img/pruning_revision.png,fit)

在黄色圆中绘制剪枝之修订后，黄色圆和红色圆都会被删除。

;;;;;

<|revision@trickster:templates|revision-id=trickster:remove_outer|>

扩展绘制处的圆，以替换其外圆。

;;;;;

![](trickster:textures/gui/img/ascension_revision.png,fit)

在蓝色圆中绘制登升之修订后，即会删除红色圆，并由蓝色圆替换。

;;;;;

<|revision@trickster:templates|revision-id=trickster:add_outer_subcircle|>

为外圆添加一个子圆。

;;;;;

![](trickster:textures/gui/img/devotion_revision.png,fit)

在蓝色圆中绘制奉献之修订后，即会创建绿色圆。

;;;;;

<|revision@trickster:templates|revision-id=trickster:rotate_cw|>

顺时针循环移动绘制处圆的子圆，以让最后一个子圆变为第一子圆。

;;;;;

<|revision@trickster:templates|revision-id=trickster:rotate_ccw|>

功效与旋移之修订相反，会逆时针循环移动子圆。

;;;;;

<|revision@trickster:templates|revision-id=trickster:swap|>

交换第一子圆和第二子圆。

;;;;;

<|revision@trickster:templates|revision-id=trickster:splice|>

从施法者副手物品中读出法术，用其替换绘制处的圆。

;;;;;

<|revision@trickster:templates|revision-id=trickster:splice_inner|>

从施法者副手物品中读出法术，将其加作绘制处圆的符记。

;;;;;

<|revision@trickster:templates|revision-id=trickster:write|>

将绘制处的圆复制入施法者的副手物品。

;;;;;

<|revision@trickster:templates|revision-id=trickster:quote_pattern|>

将绘制处圆中已有的图案变为图案字面量。

;;;;;

<|revision@trickster:templates|revision-id=trickster:write_path|>

将绘制处圆的[地址](^trickster:distortions/tree#2)写入另一只手中的物品。
