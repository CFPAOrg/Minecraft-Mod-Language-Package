---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 样板
  icon: crafting_pattern
  position: 410
categories:
- tools
item_ids:
- ae2:blank_pattern
- ae2:crafting_pattern
- ae2:processing_pattern
- ae2:smithing_table_pattern
- ae2:stonecutting_pattern
---

# 样板

<ItemImage id="crafting_pattern" scale="4" />

样板是在<ItemLink id="pattern_encoding_terminal" />中以空白样板制作而得的，可装入<ItemLink id="pattern_provider" />和<ItemLink id="molecular_assembler" />。

有若干种不同的样板，分别为不同处理方式设计：

*   <ItemLink id="crafting_pattern" />能编码工作台的配方。可将此类样板直接放入<ItemLink id="molecular_assembler" />以令其在收到材料时自动合成，但是它们的主要用途则是放在与分子装配室相邻的<ItemLink id="pattern_provider" />中。样板供应器在此情况下有特殊行为，会将相关样板和材料输入相邻装配室。因为装配室会将产物自动弹出到相邻容器，相邻放置的装配室和样板供应器就是自动化合成样板所需的一切了。

***

*   <ItemLink id="smithing_table_pattern" />与合成样板非常相似，但编码的是锻造台配方。它们也可通过样板供应器和分子装配室自动化，工作流程也完全一致。实际上，合成、锻造台、切石机样板所需的设施均完全一致。

***

*   <ItemLink id="stonecutting_pattern" />与合成样板非常相似，但编码的是切石机配方。它们也可通过样板供应器和分子装配室自动化，工作流程也完全一致。实际上，合成、锻造台、切石机样板所需的设施均完全一致。

***

*   <ItemLink id="processing_pattern" />则是自动合成的灵活性所在。它们是最通用的样板类型，简单来说，“如果样板供应器将这些材料输出到相邻容器，则ME系统会在未来某时间点收到这些物品”。它们是配合几乎所有其他模组机器（或者说熔炉类的机器）自动合成的方式。原因在于它们非常通用，且完全不关心输出材料和输入产物间发生的任何事。你大可做些非常古怪的事，比如将材料输入一整条复杂工厂产线进行分拣，再从无限生产的农场中运出其他材料，打印出一整篇《蜜蜂总动员》的剧本，只要ME系统能拿到样板指明的产物，它就完全不会关心这些。实际上，它甚至不会关心材料和产物之间有没有联系。你可以告诉系统“1x 樱花木板 = 1x 下界之星”，然后让凋灵农场每接收到一个樱花木板时杀一只凋灵即可，完全不会出任何问题。

多个拥有相同样板的<ItemLink id="pattern_provider" />会并行工作，并且，还可以设置诸如“8x 圆石 = 8x 石头”的配方而非“1x 圆石 = 1x 石头”，样板供应器每次运行都会向烧炼设施输入8个圆石而非每次1个。

## 配方

<RecipeFor id="blank_pattern" />
