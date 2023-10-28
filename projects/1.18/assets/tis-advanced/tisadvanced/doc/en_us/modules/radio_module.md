# Radio Module

![The original wireless technology.](item:tisadvanced:radio_module)

The radio module provides longer range transmission of values, without the line-of-sight limitation of the infrared module. A value transmitted by radio will be sent to *all* active radios within 256 meters.

The radio module reads values from all four of its ports and transmits the read value as its payload. The radio module writes the value of the last received radio packet to all four of its ports.

The radio module holds a small queue containing the list of values of the last received packets. The exact length of this list is vendor specific. If a packet is received but the list is already full, the packet will be ignored. The list will be written to radio module's ports in the order in which the values were received. Packets sent earlier will always be received first, however packets sent simultaneously may arrive in an undefined order.

A value in the queue of received values can always only be transferred to one port, i.e. values will never be duplicated; even when multiple reads would occur in one controller cycle, only one will succeed.

Additionally, the radio module has two indicator LEDs in the top right corner on its face to aid in debugging. The green indicator on the left will change to red if there are packets in the module's internal buffer that need to be read, and the indicator on the right will flash blue for a short time when a packet is sent.
