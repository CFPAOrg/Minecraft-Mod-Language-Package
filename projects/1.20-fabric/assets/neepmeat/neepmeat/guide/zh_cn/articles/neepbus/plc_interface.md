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
    # Target is a NEEPBus interface
    ihandler @(-19 -60 5 U) handler
    iwait
-1 until

: handler
  idisable
  say "NEEPBus changed"
  
  # Retrieve the current value of the input port.
  # (this goes onto the stack)
  extfetch @(-19 -60 5 U); 
  
  dup . # Say the result
  
  # Store the result in memory
  store
  
  # Duplicate the pointer
  dup
  
  # Send the memory entry to the interface
  extstore @(-19 -60 5 U)
  
  # Free the memory
  free
;
```
