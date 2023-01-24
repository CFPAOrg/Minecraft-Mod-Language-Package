# 打包机制-自定义文件检索策略

本仓库的打包器支持对不同模组使用不同的**检索策略**。
注意：检索策略仅对**文本文件**有效；**非文本文件**无法通过默认的检索途径，需要在`config/packer.json`中设置绕过检索。详见[此处](./CONTRIBUTING.md#configpackerjson)

## 策略配置

对于每个**asset-domain**，策略文件为`./projects/<version>/assets/<mod-name>/<asset-domain>/packer-policy.json`。
若找不到该策略，默认策略文件为`{"type": "noaction"}`。

### 策略文件的格式

packer-policy.json
- 根标签
  - `type` string -> 策略的类型。可为以下选项之一：
    - `noaction` 默认选项。不进行特殊处理，直接按照此处的文件结构打包。如果没有对文件同步或版本对照的特殊要求，使用该类型。如：[示例文件](./projects/1.19/assets/0-example-nop/nop/packer-policy.json)
    - `plainclone` 直接引用另一位置的文件结构。如果需要文本完全同步，使用该类型。如：[示例文件](./projects/1.19/assets/0-example-simple-clone/clone/packer-policy.json)
      - `source` string -> 复制的源地址。需要从本仓库的根目录开始计算，使用`./`前缀。
    - `clonemissing` 使用此处的文件结构，但在检索完文件后，根据另一位置的文件结构补充文本。对于出现冲突的条目，若为`lang/`下的内容，将会按照`key`合并，冲突项采用此处的文本；若为其他位置的文件，直接采用此处的文件。如：[示例文件](./projects/1.19/assets/0-example-mixed-clone/mixed-clone/packer-policy.json)
      - `source` string -> 补充文件的源地址。需要从本仓库的根目录开始计算，使用`./`前缀。
    - `patch` 引用另一位置的文件结构，但在其中的部分文件上额外应用自定义的修改。修改使用[Google Diff-Match-Patch算法](https://github.com/google/diff-match-patch)生成；尽管原则上可以放在任意位置、采用任意后缀名，建议将修改文件放在被修改文件相应的位置，采用`.patch`后缀，以保持统一性。如：[示例文件](./projects/1.19/assets/0-example-patch/patch/packer-policy.json)
      - `source` string -> 复制的源地址。需要从本仓库的根目录开始计算，使用`./`前缀。
      - `patches` object -> 修改文件，以及对应的修改目标。
        - `修改目标的相对路径` string -> 修改文件的源地址。需要从本仓库的根目录开始计算，使用`./`前缀；`修改目标的相对路径`需要为在复制源地址的`<asset-domain>/`下方的相对位置，必须使用`\\`作为分隔符，如`lang\\zh_cn.json`。
