---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 终端
  icon: crafting_terminal
  position: 210
categories:
- devices
item_ids:
- ae2:terminal
- ae2:crafting_terminal
- ae2:pattern_encoding_terminal
- ae2:pattern_access_terminal
---

# 终端

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/terminals.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

<ItemLink id="pattern_provider" />、<ItemLink id="import_bus" />、<ItemLink id="storage_bus" />等是AE2网络与世界交互的基础方式，终端则是AE2网络与*你*交互的基础方式。终端有多种功能各异的变种。

终端会继承支持其的[线缆](cables.md)的颜色。

它们是[线缆子部件](../ae2-mechanics/cable-subparts.md)。

## 终端的放置

终端通常是最先放置的[子部件](../ae2-mechanics/cable-subparts.md)，因此出现放置问题或反着放置等都是正常现象。应当做和不应当做的事见下方示例：

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/assemblies/terminal_placement.snbt" />
  <IsometricCamera yaw="195" pitch="30" />

  <LineAnnotation color="#ff3333" from="2.5 .5 .5" to="4.5 2.5 .5" alwaysOnTop={true} thickness="0.05"/>
  <LineAnnotation color="#ff3333" from="2.5 2.5 .5" to="4.5 .5 .5" alwaysOnTop={true} thickness="0.05"/>

  <LineAnnotation color="#33ff33" from="-.5 2.5 .5" to="1 .5 .5" alwaysOnTop={true} thickness="0.05"/>
  <LineAnnotation color="#33ff33" from="1 .5 .5" to="1.5 1 .5" alwaysOnTop={true} thickness="0.05"/>
</GameScene>

终端和能源接收器都还在，但终端的方向正确且网络连接正确，整体的空间占用也更优。

<a name="terminal-ui"></a>

# 终端搜索

搜索框接受正则表达式，因此可以输入“gtceu:.*ore”以搜索所有Gregtech的矿石。正则表达式的学习则留给读者作为练习。

# 终端

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/blocks/terminal.snbt" />
  <IsometricCamera yaw="180" />
</GameScene>

基础终端，使你能访问[网络存储](../ae2-mechanics/import-export-storage.md)的内容，也可向[自动合成](../ae2-mechanics/autocrafting.md)设施发送请求。

## 界面

基础终端的UI分为若干部分。

中间部分为网络存储，可向其中存入或从中取出物品。此部分支持若干鼠标/键盘快捷键：

*   左击拿出一组，右击拿出半组
*   如果某物品或流体等允许[自动合成](../ae2-mechanics/autocrafting.md)，绑定至“选取方块”的按键（通常是鼠标中键）会唤起设置自动合成数量的UI。也可输入诸如`3*64/2`的公式，还可输入`=32`以补齐网络存储中距32个物品缺少的数量
*   按住Shift会将所展示物品固定，防止其在数量变动或物品进入系统时重新组织
*   手持桶或其他流体容器右击可存入流体，以空流体容器左击终端内流体可将其取出

左侧部分有如下设置按钮：

*   按物品名称、物品数量、模组等排序
*   浏览已存储、可合成，或两者均显示
*   浏览物品、流体，或两者均显示
*   更改排序顺序
*   打开详细终端设置窗口
*   更改终端UI的高度

右侧部分是<ItemLink id="view_cell" />槽位。

中间部分的右上角（锤子图标）会显示[自动合成](../ae2-mechanics/autocrafting.md)状态UI，允许查看自动合成的进度和各个[合成CPU](crafting_cpu_multiblock.md)的当前任务。

## 配方

<RecipeFor id="terminal" />

<a name="crafting-terminal-ui"></a>

# 合成终端

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/blocks/crafting_terminal.snbt" />
  <IsometricCamera yaw="180" />
</GameScene>

合成终端和普通终端比较相似，它们的UI区域与设置均相同，但合成终端新增了可自动从[网络存储](../ae2-mechanics/import-export-storage.md)中补充的合成方格。按住Shift合成时要小心谨慎！

应当**尽快**将普通终端升级为合成终端。

## 界面

合成终端的UI与普通终端的相同，并在中间加入了合成方格。

新增了2个按钮，可将合成方格内物品清空至网络存储或物品栏。

## 配方

<RecipeFor id="crafting_terminal" />

<a name="pattern-encoding-terminal-ui"></a>

# 样板编码终端

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/blocks/pattern_encoding_terminal.snbt" />
  <IsometricCamera yaw="180" />
</GameScene>

样板编码终端和普通终端比较相似，它们的UI区域与设置均相同，但样板编码终端新增了[样板](patterns.md)编码界面。其和合成终端的UI外形较为相似，不过此处的合成方格并不能真正进行合成。

应当在拥有合成终端后再配一个样板编码终端。

## 界面

样板编码终端的UI与普通终端的相同，并在中间加入了[样板](patterns.md)编码界面。

样板编码界面分为若干区域：

*   可放入<ItemLink id="blank_pattern" />的槽位
*   用于编码样板的大箭头
*   可放入经过编码的样板的槽位；在此处放入经过编码的样板以修改，按下“编码”箭头即可保存
*   右侧用于更改样板至如下类型的4个选项栏：
    *   合成
    *   处理
    *   锻造台
    *   切石机

中间的UI会根据所选编码类型而变：

*   合成模式：
    *   左击或从JEI/REI拖拽以将材料加至配方；右击以移除材料
    *   允许替代配方可支持类似任意木板合成木棍的配方；应当仅在绝对必要时才启用
    *   流体替代允许使用存储中的流体替代桶装流体
    *   也可直接从JEI/REI配方界面中编码样板

*   处理模式：
    * 左击，右击或从JEI/REI拖拽以设定配方的输入和输出
    * 持有一组物品时，左击放入整组，右击放入一个物品；左击已有的材料移除整组，右击则减少一个；绑定至“选取方块”的按键（通常是鼠标中键）可精确设定物品或流体所需量
    * 输出槽中有一个主产物槽和若干副产物槽，方便自动合成算法获取信息
    * 输入和输出槽都可滚动，共有81个材料槽和26个副产物槽
    * 也可直接从JEI/REI配方界面中编码样板

*   锻造台和切石机模式的UI和实际的锻造台与切石机类似。

## 配方

<RecipeFor id="pattern_encoding_terminal" />

<a name="pattern-access-terminal-ui"></a>

# 样板管理终端

<GameScene zoom="6" background="transparent">
  <ImportStructure src="../assets/blocks/pattern_access_terminal.snbt" />
  <IsometricCamera yaw="180" />
</GameScene>

样板管理终端可以解决此类问题：在一整个紧凑的<ItemLink id="pattern_provider" />和<ItemLink id="molecular_assembler" />阵列中无法直接向供应器放入样板。此外，也可解决不想跑到基地其他位置放[样板](patterns.md)的懒惰问题。样板管理终端允许访问网络中的所有样板供应器。

## 界面

样板管理终端的UI和其他终端不同。

此UI有UI高度和显示何种样板供应器的设置。

终端中每一行都对应一个样板供应器。

各样板供应器会根据其连接的方块以及名称（铁砧或<ItemLink id="name_press" />赋予）分类。

## 配方

<RecipeFor id="pattern_access_terminal" />
