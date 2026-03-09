---
navigation:
  title: "标信器"
  icon: "tag"
  parent: little_big_redstone:logic.md
  position: 12
categories:
  - logic
item_ids:
  - little_big_redstone:tag
---

# 标信器

<RecipeFor id="tag" />

标信器可在电路间无线收发信号。它有两个模式：发信和探测。探测端是接受信号的一端，发信端则是发送的一端。

<br />

每个标信器都有一个标签集合。探测端只能探测到同标签的发信端。标签对**大小写敏感**。可以选择不填写标签，留空标签的探测端只能探测到同样留空标签的发信端。

探测端有一个阈值设置，它只会在探测到该数量个发信端后输出ON。例如，有一个阈值为2、标签为“something”的探测端；要让它输出ON，就必须有至少2个标签为“something”的发信端为ON。

注意，探测端可以探测到同一个电路中的发信端。

<br />

还可设置探测端是否全局。也即，它是否会探测多人服务端中其他人放置的发信端。默认情况下，探测端不是全局的——它们只会探测你自己放置的发信端。

<br />

下方示例中，发信端和探测端的标签相同。而因为两者标签一致，且探测端阈值为1，所以只要发信端为ON，探测端就会输出ON。

<Row>
	<Column>
		<MicrochipScene color="red" marginWidth="16" includeToolbar={true}>
			<Logic name="input1" x="0" y="0" type="io" hide={true} />
			<Logic name="output1" x="32" y="0" type="tag" data="{config:{input:false,label:'something'}}" />

			<Logic name="tag2" x="64" y="0" type="tag" data="{config:{label:'something'}}" />
			<Logic name="input2" x="64" y="0" type="io" hide={true} />
			<Logic name="output2" x="96" y="0" type="io" data="{config:{input:false,signal_strength:15}}" hide={true} />

			<Wire from="input1" fromPort="0" to="output1" toPort="0" />
			<Wire from="input2" fromPort="0" to="output2" toPort="0" />

			<RedstoneSignal step="0" direction="north" strength="15" />
			<RedstoneSignal step="1" direction="north" strength="0" />
		</MicrochipScene>
	</Column>
</Row>

而此处示例中两标信器的标签不同。因此探测端无法探测到发信端。

<Row>
	<Column>
		<MicrochipScene color="red" marginWidth="16" includeToolbar={true}>
			<Logic name="input1" x="0" y="0" type="io" hide={true} />
			<Logic name="output1" x="32" y="0" type="tag" data="{config:{input:false,label:'something'}}" />

			<Logic name="input2" x="64" y="0" type="tag" data="{config:{label:'something_else'}}" />
			<Logic name="output2" x="96" y="0" type="io" data="{config:{input:false,signal_strength:15}}" hide={true} />

			<Wire from="input1" fromPort="0" to="output1" toPort="0" />
			<Wire from="input2" fromPort="0" to="output2" toPort="0" />

			<RedstoneSignal step="0" direction="north" strength="15" />
			<RedstoneSignal step="1" direction="north" strength="0" />
		</MicrochipScene>
	</Column>
</Row>