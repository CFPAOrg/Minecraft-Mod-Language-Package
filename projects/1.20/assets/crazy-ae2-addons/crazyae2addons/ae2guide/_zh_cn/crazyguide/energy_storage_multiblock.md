---
navigation:
  parent: crazyae2addons_index.md
  title: 能源仓库多方块结构
  icon: crazyae2addons:energy_storage_controller
categories:
  - Energy and Item Transfer
item_ids:
   - crazyae2addons:energy_storage_controller
   - crazyae2addons:energy_storage_frame
   - crazyae2addons:energy_storage_1k
   - crazyae2addons:energy_storage_4k
   - crazyae2addons:energy_storage_16k
   - crazyae2addons:energy_storage_64k
   - crazyae2addons:energy_storage_256k
   - crazyae2addons:dense_energy_storage_1k
   - crazyae2addons:dense_energy_storage_4k
   - crazyae2addons:dense_energy_storage_16k
   - crazyae2addons:dense_energy_storage_64k
   - crazyae2addons:dense_energy_storage_256k
---

# 能源仓库控制器

<Row>
   <BlockImage id="crazyae2addons:energy_storage_controller" scale="4"></BlockImage>
   <BlockImage id="crazyae2addons:energy_storage_frame" scale="4"></BlockImage>
   <BlockImage id="crazyae2addons:energy_storage_16k" scale="4"></BlockImage>
   <BlockImage id="crazyae2addons:dense_energy_storage_64k" scale="4"></BlockImage>
</Row>

## 控制器只会将能源仓库方块用作指示，所有能量都存储于控制器内部。破坏控制器会丢失其中的所有能量！

能源仓库是为ME系统设计的多方块能量仓储设备，可以用控制器、仓库方块、框架存下大量能量。

启动后，此设备可以用来存储应用能源2（AE2）的能量，相当于可接收和供应能量的能源元件等AE2电池。

---

## 搭建方法

使用下列方块搭建7x7x7的立方体：

- **F** – 能源仓库框架
- **G** – 聚能石英玻璃
- **O** – 能源仓库方块（1k至256k，也可用致密变种）
- **C** – 能源仓库控制器（仅一个）

### 第1层（底部）：
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F C F F F

### 第2-6层：
每层都照此排列：
F G G G G G F<br/>
G O O O O O G<br/>
G O O O O O G<br/>
G O O O O O G<br/>
G O O O O O G<br/>
G O O O O O G<br/>
F G G G G G F

### 第7层（顶部）：
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F<br/>
F F F F F F F

---

## 工作原理

- 结构搭建完成后即会启动。
- 存储容量由结构中仓库方块的类型和数量决定。
- 致密变种的FE储量在十亿量级。
- 可以使用**电流表**或其他模组来监控吞吐量。

控制器会整合至AE2的能量网络，和能源元件类似——只不过前者的容量大得惊人。

---

## 注意事项

- 结构中只允许存在一个控制器。
- 结构（控制器除外）缺损时，能量仍会留存于控制器内部，但在结构恢复前无法取用。