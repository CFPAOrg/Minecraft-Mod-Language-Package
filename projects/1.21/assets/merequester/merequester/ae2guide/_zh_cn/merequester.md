---
navigation:
  title: ME请求器
  icon: requester
  position: 100
item_ids:
  - merequester:requester
  - merequester:requester_terminal
---

# ME请求器

<Row>
  <ItemImage id="requester" scale="3"/>
  <ItemImage id="requester_terminal" scale="3"/>
</Row>

AE2的附属模组，可让你在[ME系统](ae2:getting-started.md#你的第一个ME系统)中维持一定数量的物品和流体。
<br/>

## 开始与入门

开始之前，放置一个<ItemLink id="requester"/>并将其接入网络。务必要将其接入[自动合成](ae2:ae2-mechanics/autocrafting.md)设施所在的网络，该网络应当具有[合成CPU](ae2:ae2-mechanics/autocrafting.md#合成CPU)和<ItemLink id="ae2:pattern_provider"/>。

<RecipeFor id="requester"/>

为让<ItemLink id="requester"/>运作，网络中应当具有所需维持库存的物品或流体的样板，即，以玩家身份发出合成请求时应当可以合成。请求器只会自动化请求的操作。合成的步骤则需由[ME系统](ae2:getting-started.md#你的第一个ME系统)处理。
<br/>

<FloatingImage src="assets/gui.png" align="right"/>

## 配置

第一次打开<ItemLink id="requester"/>时会显示各请求设置的概览。单个请求器能处理的槽位数可在配置中修改。GUI中的每一行都对应一个请求任务。
<br/>

### 开关切换

行左侧的选择框决定该行的请求是否启用。禁用请求后不会进行相应的检查，所请求事物的存量也不会得到维持。<br/>
此功能可用于暂时禁用某个请求，或是在修改行设置的过程中阻止<ItemLink id="requester"/>发出合成请求。
<br/>

### 维持什么库存

第二列用于指定需维持库存的事物。这些槽位是“幽灵槽”，不存储实际物品。将物品拖动到槽位处时，右击可将数量设为1，左击则将数量设为所持堆叠中物品的数量。将流体桶拖动到槽位处时，右击可维持其中流体的库存，左击则可维持流体桶本身的库存。也可Shift点击物品以快速设定物品类型。如果物品栏中没有所需的物品，可选择从应用能源（Applied Energistics）支持的配方查看器中拖放。
<br/>

### 库存数量

库存数量字段用于指明需维持库存的量。需先指定维持的事物，然后再输入维持量。非物品请求的该字段会自动进行适应。例如，流体请求的该字段会显示`B`，指代“桶”这一单位。<br/>
当网络中的存量低于给定值时，<ItemLink id="requester"/>即会进行请求。
<br/>

### 单批数量

下一个输入字段用于指定请求的单批数量，即，在网络库存低于“库存数量”字段中值时所发出请求的请求量。<br/>
此设置可减轻合成所用[合成CPU](ae2:ae2-mechanics/autocrafting.md#合成CPU)与机器的压力；两字段值一致时会同时请求全部的数量，而非拆分为多个子任务。
<br/>

### 提交按钮

在“库存数量”和“单批数量”字段填写完毕后，按下Enter或点击行右侧“提交更改”按钮即可应用。将焦点切换到其他行时，会将正在修改的行恢复为修改前的状态。
<br/>

### 状态栏

输入框和提交按钮下方的横栏会显示请求的当前状态。
<br clear="all" />
<br/>

## 状态

各个请求的状态均可分为如下几种。
<br/>

### 灰色 - 空

当前行已被禁用，或是未指定需维持的事物。
<br/>

### 绿色 - 空闲

已达成维持量，或是所配置的请求没有对应样板。
<br/>

### 红色 - 缺少材料

系统缺少发出合成作业的材料。网络中出现足量材料时会立刻恢复。
<br/>

### 黄色 - 合成中

指定的请求正在进行合成。请求器在等待合成作业结束。<br/>
处于此状态时，<ItemLink id="requester"/>中对应请求的设置会进入锁定状态，无法修改。
<br/>

### 紫色 - 输出中

<ItemLink id="requester"/>已收到当前作业的所有产物，且正在尝试将其输出至存储系统。<br/>
此状态通常不会出现。如果其长时间处于该状态，则意味着存储系统空间不足。
<br/>

### 方块外观

如果<ItemLink id="requester"/>中任意请求进入“空闲”和“空”之外的状态，则请求器的外观会发生变化。

<Row>
  <Column>
    未启动请求
    <BlockImage id="requester" scale="3" p:active="false"/>
  </Column>
  <Column>
    启动请求
    <BlockImage id="requester" scale="3" p:active="true"/>
  </Column>
</Row>
<br/>

## 终端

本模组添加了一个新终端：<ItemLink id="requester_terminal"/>。它可将同一网络中所有<ItemLink id="requester"/>的访问操作集中到单个位置。

该终端的特性与<ItemLink id="ae2:pattern_access_terminal"/>一致，且可在其中搜索特定的请求。而因为默认情况下所有<ItemLink id="requester"/>的名称都相同，所有的请求都会分入到同一个组。若需在<ItemLink id="requester_terminal"/>中单独分出<ItemLink id="requester"/>组，可选择通过铁砧或<ItemLink id="ae2:name_press"/>重命名。
