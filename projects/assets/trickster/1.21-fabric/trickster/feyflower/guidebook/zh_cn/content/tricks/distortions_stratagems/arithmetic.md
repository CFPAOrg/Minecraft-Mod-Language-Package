```json
{
  "title": "算术",
  "icon": "minecraft:copper_bulb"
}
```

本节的戏法主要涉及基础算术及数学操作。


部分基础戏法能接受多种类型的片段。它们的签名会采用特殊标记，如$$dev.enjarai.trickster.spell.fragment.AddableFragment$$或$$dev.enjarai.trickster.spell.fragment.RoundableFragment$$。这些术语的全称见后页：

;;;;;

$$dev.enjarai.trickster.spell.fragment.AddableFragment$$、$$dev.enjarai.trickster.spell.fragment.SubtractableFragment$$可以是$$trickster:number$$、$$trickster:vector$$、$$trickster:pattern$$。


$$dev.enjarai.trickster.spell.fragment.MultiplicableFragment$$、$$dev.enjarai.trickster.spell.fragment.DivisibleFragment$$、$$dev.enjarai.trickster.spell.fragment.RoundableFragment$$则只能是$$trickster:number$$或$$trickster:vector$$。


$$trickster:color$$也接受算术操作，它们是$$dev.enjarai.trickster.spell.fragment.AddableFragment$$、$$dev.enjarai.trickster.spell.fragment.MultiplicableFragment$$、$$dev.enjarai.trickster.spell.fragment.RoundableFragment$$、$$dev.enjarai.trickster.spell.fragment.AverageableFragment$$的片段。

;;;;;

能一次性接受多个输入的曲变术会逐输入执行其操作。例如：


1, 2, 3 传入吞并之谋略 = 1 + 2 + 3 = 6


以及


1, 2, 3 传入屈从之谋略 = 1 / 2 / 3 = 0.1666...

;;;;;

#<trickster:revision id="trickster:two" />

[常量修订术](*trickster:constants)，会将符记替换为数“2”。可用此修订术和后页各戏法制造出其他数。

;;;;;

#<trickster:trick id="trickster:add" />

求各片段的和。

;;;;;

#<trickster:trick id="trickster:subtract" />

从首个片段中减去其他片段。

;;;;;

#<trickster:trick id="trickster:multiply" />

求各片段的积。

;;;;;

#<trickster:trick id="trickster:divide" />

从首个片段开始，按顺序连除。

;;;;;

#<trickster:trick id="trickster:remainder" />

返回第一个数除以第二个数的余数。

;;;;;

#<trickster:trick id="trickster:modulo" />

返回第一个数除以第二个数的模。

;;;;;

#<trickster:trick id="trickster:power" />

返回底数为第一个数，指数为第二个数的幂。

;;;;;

#<trickster:trick id="trickster:logarithm" />

给定两个数。返回值是在计算幂时，为让底数为第一个数的幂等于第二个数，指数应为的数值。

;;;;;

#<trickster:trick id="trickster:max" />

返回所有输入值中的最大值。

;;;;;

#<trickster:trick id="trickster:min" />

返回所有输入值中的最小值。

;;;;;

#<trickster:trick id="trickster:avg" />

返回各输入值的平均值。

;;;;;

#<trickster:trick id="trickster:ceil" />

将输入值向上取整。

;;;;;

#<trickster:trick id="trickster:floor" />

将输入值向下取整。

;;;;;

#<trickster:trick id="trickster:round" />

将输入值四舍五入。

;;;;;

#<trickster:trick id="trickster:sqrt" />

返回输入值的平方根。

;;;;;

#<trickster:trick id="trickster:invert" />

取反所给数或向量。

;;;;;

#<trickster:trick id="trickster:abs" />

若所给数为负，返回其相反数。否则原样传出。

;;;;;

#<trickster:trick id="trickster:sin" />

返回所给数的正弦。

;;;;;

#<trickster:trick id="trickster:cos" />

返回所给数的余弦。

;;;;;

#<trickster:trick id="trickster:tan" />

返回所给数的正切。

;;;;;

#<trickster:trick id="trickster:arcsin" />

返回所给数的反正弦。

;;;;;

#<trickster:trick id="trickster:arccos" />

返回所给数的反余弦。

;;;;;

#<trickster:trick id="trickster:arctan" />

返回所给数的反正切。

;;;;;

#<trickster:trick id="trickster:arctan2" />

返回X轴正向与原点至点(y, x)射线的夹角。
