# Reactors

Fusion Reactors are a very powerful multiblock which can be used to generate large amounts of FE.

However, they are also complex to set up and keep running. 
This page should help you learn how to start and run a healthy reactor. 

You can also ponder any block involved in reactor creation for a more visual tutorial on how to build one.

For the purposes of this page, we will assume you've already built a basic reactor multiblock with all the ins and outs required.

## Flux

Fusion Reactors take in Flux gas, and convert it to Aether in a powerful reaction. This reaction also generates 
massive quantities of heat, which you can siphon off as Forge Energy.

You'll need a steady supply of Flux to keep a reactor going. 
It can be obtained with a **Vaporizer** using Lithium nuggets and blue ice. 
_(Both of which can be automated)_

## Starting the reaction

The Flux will only react into Aether once the reactor temperature is above 50,000K. If you attach Step-Down transformers
to the heat exchangers on your reactor, you can feed it FE to heat it up to the reaction temperature. 
If you attach Step-Up transformers to the heat exchangers, you can siphon off heat from the reactor to generate FE.

Luckily, the heat exchangers also include smart monitoring technology. That is to say they will only feed FE to the reactor
if it is below 55,000K and they will only take FE from the reactor if it is above 55,000K. This means you can have 
both an input and an output of FE attached to your reactor at all times, and you don't have to worry about somehow 
enabling/disabling the transformers.

## Monitoring the reaction

Although the Forge Energy in/out will self regulate, the pressure and temperature of your reactor will not. 
Reactors can fail in a few ways, including:
1. Melting down (internal heat surpasses **200,000K**)
2. Bursting from pressure (internal pressure surpasses **24MPa**)
3. Losing integrity (your friend "accidentally" breaks a wall)

As you take FE out of the reactor, the heat level _will_ lower. 
However, if your system fills up on FE (e.g. your battery banks are full) the Heat Exchangers
will _stop_ converting heat into FE and your reactor will begin heating up drastically, often leading to a meltdown.

## Understanding the gasses

As the Flux reacts into Aether, it will increase the pressure. However, Aether actually _inhibits_ the reaction.
That is to say the more Aether in the reactor, the less the Flux will react. 

Although that makes Pressure mostly self-regulating, it's also a bad thing. Your reactor will get full of Aether and
no longer be able to produce more heat. To deal with this, you need to handle pumping Aether _out_ of the reactor.

## Tip #1

To get a reactor started, you should leave the Aether trapped inside (aka keep the output port closed by giving it no redstone signal).
Then you can let Flux flow in, and start heating it up with FE from your network. 
It's best to restrict the flow of Flux in at first, since its cheaper to heat up less gas and helps avoid bursting once the Flux heats up.

Once it reaches 50,000K, the reaction can begin. It will heat up very quickly, but hopefully the Aether will build up fast
enough to inhibit the reaction from going far enough to melt down. 

Once you've reached a stable, but dwindling (from too much Aether) reaction you can start letting the Aether out. 
You can send an analog (e.g. between 0 and 15) redstone signal to the output hatch to control its exit rate: 
the stronger the signal, the further it opens. 
You don't want it to exit too fast, but you also don't want it to exit too slow.

## Tip #2

You don't have to monitor your power network to see when you are full and shut down your reactor.
Instead (using a script terminal), monitor the _temperature_ of your reactor. 

Since you know it will only heat up once the transformers stop siphoning power from the reactor, 
you know that excessive heat will only happen once the power network is full. 

When that happens, you don't have to shut down the reactor completely. 
Instead, close the Flux input and Aether output hatches completely (by cutting their redstone signal).
The reaction will stop heating up, and instead very slowly cool down. It should be able to stay
above reaction temperature (50,000K) for a long while. 

In the rare case it cools below 50,000K, you'll simply need to jumpstart the reactor again. 
This will potentially happen automatically, if your Step-Down transformers are still able to 
provide power to the reactor and your Flux/Aether flow is steady.

## Tip #3

Enjoy the process! Automating your reactor doesn't have to be a chore, it can be an interesting challenge.

We won't provide a premade script to run a reactor, but we will say this:
It is possible in less than 8 lines of script code. Give it a try!

Don't accidentally overcomplicate it (unless that's your goal, each to their own).