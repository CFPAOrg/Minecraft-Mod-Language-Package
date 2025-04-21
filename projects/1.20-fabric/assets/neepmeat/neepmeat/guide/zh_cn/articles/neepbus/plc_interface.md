---
id: plc_neepbus_interface
---
# PLC NEEP总线接口

PLC可直接读写NEEP总线的组件，但无法被写入。PLC NEEP总线接口会发出中断请求，PLC可据此在写事件出现时立即回应。

此方块有一个输入端口和一个输出端口。向输入端口写入时，经过`IHANDLER`注册中断处理程序的所有PLC均会收到中断请求。

输入端口的当前值可通过`EXTFETCH`读取。

通过`EXTSTORE`向其发送内存项时，其输出端口会向所有对应地址写值。

## THORD示例：

```
begin
    # Target is a NEEPBus interface [1]
    ihandler @(-19 -60 5 U) handler
    iwait
-1 until

: handler
  idisable
  say "NEEPBus changed" # [2]
  
  # Retrieve the current value of the input port. [3]
  # (this goes onto the stack) [4]
  extfetch @(-19 -60 5 U); 
  
  dup . # Say the result [5]
  
  # Store the result in memory [6]
  store
  
  # Duplicate the pointer [7]
  dup
  
  # Send the memory entry to the interface [8]
  extstore @(-19 -60 5 U)
  
  # Free the memory [9]
  free
;
```
 [1] 目标是PLC NEEP总线接口
 [2] "NEEP总线有变动"
 [3] 获取输入端口的当前值
 [4] （会压入栈中）
 [5] 打印结果
 [6] 将结果存入内存
 [7] 复制指针
 [8] 将内存项发送至接口
 [9] 释放内存