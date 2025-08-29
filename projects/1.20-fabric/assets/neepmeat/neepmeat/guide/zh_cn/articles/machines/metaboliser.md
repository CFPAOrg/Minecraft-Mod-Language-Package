---
id: metaboliser
lookup: neepmeat:metaboliser_segment, 
---
# 代谢机

代谢机可消耗液态食物来产出能量。

代谢机由一个胃囊和多个代谢机工作段组成。每追加一个工作段，都会增加食物消耗速率和能量产出速率。功率会通过工作段本身直接输出至脉管网络。

每个工作段每刻消耗4滴流体，且各工作段应独立连接至脉管网络。

输出功率取决于工作段的数量和输入食物的能量密度。

## 能量密度

- 肉浆：40eJ / d
- 动物饲料：60eJ / d
- 液态食物：(1 + 9 * 饥饿值) / d

## 示例

\image[width=332,height=321,scale=0.5]{neepmeat:guide/images/metaboliser.png}