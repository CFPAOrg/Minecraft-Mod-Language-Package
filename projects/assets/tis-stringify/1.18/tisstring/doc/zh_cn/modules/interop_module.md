# 互操作模块
![跨平台！](item:tisstring:interop_module)

（警告：此模块可能不存在，请不必担心，这意味着你没有安装ComputerCraft）

互操作模块使你能用CC电脑与TIS-3D计算机交互， 只需 用`peripheral.find("casing")`来绑定安装了此模块的外壳，就可以尽情使用它提供的功能，此模块始终可读写。

可用的CC函数有：
`casing.popInt(): Number|nil`
从互操作模块取出一个数值（有符号整数），如果为空则返回`nil`
`casing.popUint(): Number|nil`
从互操作模块取出一个无符号数值（无符号整数），如果为空则返回`nil`
`casing.popFloat(): Number|nil`
从互操作模块取 出一个16位浮点数，如果为空则返回`nil`
`casing.pushInt(Number)`
向模块压入一个整数，如果超过Short.MAX_VALUE（即16位有符号数范围上限）会自动判断符号。
`casing.pushFloat(Number)`
向模块压入一个浮点数，可能会出现精度丢失
`casing.getLen():Number`
返回当前互操作模块中可供取出数值的数量

注意：在同一个外壳上安装多个互操作模块并无作用，外壳只会使用其中一个
（而且是“随机”选择用哪一个）
