---
id: pid_controller
---

# Proportional-Integral-Derivative Controller

The PID Controller is a NEEPBus participant that acts as a discrete time feedback controller for a dynamic system.

Essentially, it tries to keep the *Measurement* input signal as close to the *Setpoint* input by changing the *PID Output* value.

### Ports

In:
- Measurement
- Setpoint

Out:
- PID Output

## Description

The controller updates every *dt* ticks, which can be controlled with the *Loop time interval* parameter.

As shown in the block diagram, the controller reads the *Measurement* and *Setpoint* ports and subtracts *Measurement* from *Setpoint*, producing an error signal. The error signal is fed in parallel to proportional, integral and derivative terms, each with its own configurable gain. The weighted sum of the proportional, integral, and derivative terms is then sent via the output port.

## Usage

The device that the feedback controller is meant to control is referred to as the 'plant'.

As shown in the block diagram, the measurement input signal should be the output of the plant and the controller's output should be the input of the plant, creating a feedback loop.

### kp

*kp* is the proportional gain.

Setting *ki* and *kd* to zero creates a simple proportional gain controller.

### ki

*ki* is the gain of the integral term, which is the sum of all previous error values over time.

It is possible for the integrator to accumulate a very large error if the setpoint changes rapidly. The windup limit parameter prevents this by clamping the integral term's absolute value.

### kd

*kd* is the gain of the differential term, which is the change in error over time.

Increasing *kd* provides more resistance to changes in the input value, effectively damping the system.

It can be used to reduce oscillation, or to reduce the rate at which the system can change.

## Block Diagram

\image[width=256,height=128,scale=0.9]{neepmeat:guide/images/pid_block_diagram.png}
