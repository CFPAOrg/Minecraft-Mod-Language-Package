```json
{
  "title": "3. 你的第一个法术",
  "icon": "minecraft:paper",
  "ordinal": 2,
  "category": "trickster:tutorials"
}
```

准备好一张[卷轴](^trickster:items/scroll_and_quill)之后，手持右击就可打开法术编写界面。法术是一系列圆相互相交而成的树状结构，每个圆中都有符记用以说明其功能。

;;;;;

第一次打开新卷轴时，只会出现一个圆。这就是**根节点**。法术中其他的圆自此绘制开去。


如需编写法术，可使用所谓“抄绘图案”或“修订术”来添加、移除、移动圆。最基础的抄绘图案是[延枝之修订](^trickster:editing#1)，能为绘制处的圆添加一个子圆。

;;;;;

修订术图案与绝大多数图案不同，它们在卷轴和手镜中均会立即执行。它们是修改法术形状的唯一方式。


还有一个抄绘图案在基础法术中也很实用——[嫁接之修订](^trickster:editing#12)，它能移除法术层次结构中多余的圆。


解决了绘圆问题后，请在卷轴中绘制后页法术：

;;;;;

<|spell-preview-unloadable@trickster:templates|spell=YwyT9+YP6GBjZQQxGFwOMIAZHCEMDAwA8vUGkRwAAAA=|>

{gray}（拖动可平移，滚动滚轮可缩放）{}

;;;;;

完成后，副手持卷轴，再在手镜内绘制下述法术：

<|spell-preview-unloadable@trickster:templates|spell=YwyT9+bf6MPEyghiMLo0tTIAADybrxgTAAAA|>

;;;;;

绘制时你可能会发现，最上方的图案会直接变成卷轴中的法术。


之后，如果没有意外，法术应当会破坏你看着的方块！这就是最基础的施法方式了：在卷轴中编写法术，再用手镜施放。


**但这么做又为什么能行呢？**

;;;;;

施放法术时，所绘制的符记会使用其子圆的输出作为输入，执行某个操作，再将结果输出给其父圆。


可以把法术想成分出很多枝条的树。首先，树的叶圆（嵌套到最深处的圆）会产生或从世界中读出值。这些值可以是常量或施法者的引用。此类符记称作[错觉术](^trickster:delusions_ingresses)。

;;;;;

在那之后，中间的符记会将信息处理成合适的格式。比如接受生物的引用，再返回其位置。此类法术可为[曲变术](^trickster:distortions)和[辑流术](^trickster:delusions_ingresses)。


某些符记可能不会返回值，常称作[技巧术](^trickster:ploys)。这些符记会对世界造成影响，通常也是整个法术的最终目标。

;;;;;

知道这些知识后再回看卷轴中的法术，就可以辨认出其中的三种符记（又称“戏法”）了。


嵌套在最深处的符记必须为错觉术，它不可有输入。而根节点处的符记则必须为技巧术，它只接受输入而没有输出。也即，两者之间的圆中绘制的必须是曲变术或辑流术。

;;;;;

再到本书[戏法](^trickster:tricks)分类中找出这些图案，就能完全证明这一点。按从小到大顺序看，所绘制的法术可分为：

- [自审之错觉](^trickster:delusions_ingresses/caster_tricks#4)
- [弓箭手之辑流](^trickster:delusions_ingresses/raycast#2)
- 以及[摧毁之技巧](^trickster:ploys/block#2)

记下这些戏法的输入和输出，再看看这则法术是怎么组织它们的吧！

;;;;;

**好的，但我们又要如何施放它呢？**


很好，我们会借用手镜“施放一切所触之物”的倾向。在手镜里绘制的图案分别是[记事员之错觉](^trickster:tricks/basic#3)和[宏伟之谋略](^trickster:distortions/functions#3)。前者会返回施法者副手物品内的法术，后者则会接受法术并施放。


对头，法术可以施放其他法术。

;;;;;

本节介绍了自行编写简单法术所需的基础概念。掏出工具去实验吧，看看法术到底能做到什么！
