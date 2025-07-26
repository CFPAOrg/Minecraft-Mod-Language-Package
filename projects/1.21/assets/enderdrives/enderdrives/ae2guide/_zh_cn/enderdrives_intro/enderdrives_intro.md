---
navigation:
  parent: enderdrives_intro/enderdrives_intro-index.md
  title: 末影物品存储元件
  icon: enderdrives:ender_disk_1k
categories:
  - enderdrives
item_ids:
  - enderdrives:ender_disk_1k
  - enderdrives:ender_disk_4k
  - enderdrives:ender_disk_16k
  - enderdrives:ender_disk_64k
  - enderdrives:ender_disk_256k
  - enderdrives:ender_disk_creative
---

# 末影驱动器

末影驱动器功能强大，能用于构建全局同步的存储系统；这种系统能跨越ME网络和维度的界限，甚至还能通过频率供给多名玩家使用。

<Row gap="10">
  <Column>
    <ItemImage id="enderdrives:ender_disk_1k" />
  </Column>
  <Column>
    <ItemLink id="enderdrives:ender_disk_1k" />
  </Column>
</Row>

<Row gap="10">
  <Column>
    <ItemImage id="enderdrives:ender_disk_4k" />
  </Column>
  <Column>
    <ItemLink id="enderdrives:ender_disk_4k" />
  </Column>
</Row>

<Row gap="10">
  <Column>
    <ItemImage id="enderdrives:ender_disk_16k" />
  </Column>
  <Column>
    <ItemLink id="enderdrives:ender_disk_16k" />
  </Column>
</Row>

<Row gap="10">
  <Column>
    <ItemImage id="enderdrives:ender_disk_64k" />
  </Column>
  <Column>
    <ItemLink id="enderdrives:ender_disk_64k" />
  </Column>
</Row>

<Row gap="10">
  <Column>
    <ItemImage id="enderdrives:ender_disk_256k" />
  </Column>
  <Column>
    <ItemLink id="enderdrives:ender_disk_256k" />
  </Column>
</Row>

---

## 工作原理
每一个末影驱动器都有三项配置：频率、开放范围、模式。
- **频率**：频率相同的驱动器使用同一个存储空间。
- **开放范围**：决定可访问该驱动器的用户（公开、私人、团队）。
- **模式**：决定物品转移的方向（双向、仅输入、仅输出）。

所有频率和开放范围相同的驱动器对应的是**同一个虚拟存储空间**，无论它们身处何处都是如此。

---

## 类型限制

末影驱动器与传统的AE2元件不同，它们仅在类型上存在限制。受后端物品存储方式的特性影响，唯一的硬性限制就是类型的数量。单个类型下甚至可存储多达2^63 - 1个，也即9,223,372,036,854,775,807个物品。但务必当心，某频率中的物品越多，能量消耗就越大！

每个服务器能够稳定承载的类型总数是不同的，超过某个阈值时性能会开始下降。可以使用“autobenchmark”（自动基准测试）命令测试你的服务端。测试时，需打开终端界面，并通过它访问处于选定频率和“私人”开放范围的驱动器，如此才能得到准确结果。基准测试会持续运行到TPS降至18以下，过程可能持续数分钟。

我个人测试得到的平均值约为275,000个类型。275,000/255 ≈ 1078。也就是说，若向ME驱动器放入物品各异的256k末影驱动器，应当在插满超过107.8个ME驱动器时才会出现性能问题。我遇到过更高和更低的推荐最大类型数。这一上限对同一世界中使用末影驱动器的所有用户都成立。

---

## 驱动器模式

每个驱动器可设置为三种**传输模式**之一：

- ![PEGui1](../pic/transport_bidirectional_alt.png) **双向**_（默认）_  
  标准ME元件行为；可自由存入和取出


- ![PEGui1](../pic/transport_input_alt.png) **仅输入**  
  可以存入物品，但无法取出；适合用作同步输入的缓冲


- ![PEGui1](../pic/transport_output_alt.png) **仅输出**  
  可以取出物品，但无法存入；适合用作输出缓冲和只读访问

---

## 开放范围与隐私

每个驱动器也均有**开放范围**设置，用于控制什么用户可访问存储空间：

- **全局**_（默认）_  
  公开访问！所有使用同频率的玩家都可访问此共享存储空间


- **私人**  
  与你的UUID绑定，只有你能制造可访问该频率的驱动器；使用你的ME系统的其他用户也可访问


- **团队**  
  与你所处的FTB团队共享，团队的所有成员均能制造可访问该频率的驱动器

