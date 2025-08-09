---
navigation:
  title: "红石位粒"
  icon: "redstone_bit"
  position: 2
item_ids:
  - little_big_redstone:redstone_bit
---

# 红石位粒

<FloatingColumn align="right">
	<PaddedBox left="5">
		<RecipeFor id="redstone_bit" />
	</PaddedBox>
</FloatingColumn>

<FloatingColumn>
	<ItemImage id="redstone_bit" scale="2" />
</FloatingColumn>

红石位粒可用于创建连接端口的导线。[逻辑元件](logic/introduction.md)侧面的三角形突起即是此处说的“端口”。输出端口必定位于元件右侧，输入端口必定位于左侧。

一个输入端口只能连接一条导线，输出端口则没有导线数量限制。如需将多条导线汇集到单个输入端口处，应使用[或门](logic/or_gate.md)。

传统红石信号的强度可为0到15的整数，红石位粒的信号强度则只可为0或1。换句简单点的话，那就是导线里要么有信号，要么没信号——它是一个严格意义上的布尔系统。

### 导线的使用

左击输出端口再左击输入端口即可创建导线。右击已创建的导线可将其清除，左击已创建的导线则可拿起位粒进行调整。

每条导线均只消耗一枚红石位粒，且只会在导线连接到输入端口时消耗位粒。