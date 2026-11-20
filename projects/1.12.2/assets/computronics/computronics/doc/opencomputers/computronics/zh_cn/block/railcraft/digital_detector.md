# 数字化矿车传感器

![数字化探测。](block:computronics:digital_detector)

数字化矿车传感器会在矿车紧贴其通过时作出响应，并发出一个`minecart`Lua事件，此事件可被电脑检测到。数字化传感器只有特定面才能与电脑连接。

`minecart`事件的格式如下所示。如果你不理解信号格式，可参考[这篇指南](http://ocdoc.cil.li/component:signals:zh)。

`minecart(detectorAddress:string, minecartType:string, minecartName:string [, primaryColor:number, secondaryColor:number, destination:string, ownerName:string])`

若矿车未被命名，`minecartName`参数可能为空字符串。若矿车为机车，信号中还会提供机车的颜色、目的地（若不存在目的地则返回空字符串）以及所有者姓名（若不存在所有者则返回空字符串）。
