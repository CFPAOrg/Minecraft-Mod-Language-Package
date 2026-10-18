---
navigation:
  parent: ae2-mechanics/ae2-mechanics-index.md
  title: 输入、输出，与存储
---

# 输入、输出，与存储

**你的ME系统与世界**

AE2中的一个重要概念便是网络存储，也即网络内容存储的地方，通常会是[存储元件](../items-blocks-machines/storage_cells.md)或连接于<ItemLink id="storage_bus" />的容器。大部分AE2[设备](../ae2-mechanics/devices.md)都会与之以某种方式交互。

例如：

*   <ItemLink id="import_bus" />将事物向网络存储输入
*   <ItemLink id="export_bus" />将事物从网络存储输出
*   <ItemLink id="interface" />可向网络存储输入或从网络存储输出
*   [终端](../items-blocks-machines/terminals.md)在向其中放入、拿取，或填充合成方格时输入或输出物品
*   <ItemLink id="storage_bus" />并不会对网络存储输入或输出，而是会对所连接的容器执行这些操作，相当于将这些容器视作网络存储（也即是其他设备从*这些总线*输入或输出）

<GameScene zoom="4" interactive={true}>
  <ImportStructure src="../assets/assemblies/import_export_storage.snbt" />

  <BoxAnnotation color="#dddddd" min="8 1 1" max="9 1.3 2">
        输入总线从其面对的容器中提取物品并输入网络存储
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="8 2 1" max="9 3 1.3">
        从物品栏向终端放入物品视作输入网络存储
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="7 0 1" max="8 1 2">
        接口会将其内部未设置存储的槽位中的物品，以及超出槽位设定存储量的物品输入网络存储，可通过它们将事物输入网络
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="6 0 1" max="7 1 2">
        样板供应器会将返回栏内物品输入网络存储，可通过它们将事物输入网络
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="4 1 1" max="5 2 2">
        驱动器装有的元件视作网络存储
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="3 1 1" max="4 1.3 2">
        存储总线将其连接的容器视作网络存储
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="1 1 1" max="2 1.3 2">
        输出总线将网络存储中的物品输出到其面对的容器
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="1 2 1" max="2 3 1.3">
        从终端中拿取事物视作从网络存储输出
  </BoxAnnotation>

  <BoxAnnotation color="#dddddd" min="0 1 1" max="1 2 2">
        接口会将在内部设置有存储的槽位中的物品从网络存储输出，可通过它们从网络中输出事物
  </BoxAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

需在设计自动化和物流设施时着重考虑从网络存储中输出和向网络存储输入事物的行为/事件。

## 存储优先级

可点击GUI右上角扳手以设置优先级。输入网络的物品会优先进入最高优先级的存储位置，如果有两个优先级相同的存储位置，则会优先选择已经存有该物品的那个。所有白名单元件在同优先级情况下视作已经存有该物品。从存储中输出的物品会优先从最低优先级的位置输出。这一优先级系统使得在输入输出物品的过程中，高优先级的存储位置会被填满，而低优先级的会被搬空。