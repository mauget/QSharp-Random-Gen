# QSharp-Random-Gen
## Q# Quantum Random Number Generator

### What
A quantum random number generator (QRNG) that consists of three parts:
1. Quantum computer hardware (or simulator software) used like a coprocessor
1. Microsoft Q# code that orchestrates the quantum computer
1. Microsoft C# controller code that invokes and handles the Q# code 

### Quantum Computer
Qqbits and quantum gates compose a quantum computer. A qbit corresponds to classical 
computer bits ... somewhat. Its characteristics defy everyday macro-world experience, however. 
If we connect a _sufficient_ number of qbits via a selection of well-known (to quantum 
computing people) quantum gates, we would have a quantum application task.
We could create a quantum task that could outperform certain classical computational tasks.
Additionally, it could possibliy carry some some tasks that are thought to be impossible
by conceivable classical computers. Think about breaking RSA encryption, for example.

A hardware implementation of a _logical_ qbit typically involves thousands of _physical_ qbits 
founded on elemental particles. A statiscal vote amount physical qubits derives state from 
a logical qbit.Expect to see supercooling to near-zero degrees Kelvin as well. You won't
soon own a quantum smart watch soon.

### Today's Applications
Where are the practical applications? The kicker is the word, "sufficient". Currently,
qbits are profoundly expensive and error-prone due to "noise" in them. That is one reason
for the near-zero Kelvin temperatures invovled. A quantum application may run 
many "shots" at a solution, plucking a statical winner from error noise. 

Where are the real quantum computers? Big organizations are making breakthroughs. 
Cloud-based qunatum computer access for small tasks is a current or near-future on-ramp 
to limited quantum computing acess. We have run a QRNG on  IBM Q, for example.
Check out this non-exhaustive list: 

- [IBM Q Experience](https://www.ibm.com/quantum-computing/technology/experience/?p1=Search&p4=p50386405608&p5=b&cm_mmc=Search_Google-_-1S_1S-_-WW_NA-_-%2Bquantum%20%2Bcomputers_b&cm_mmca7=71700000061253577&cm_mmca8=kwd-320795842941&cm_mmca9=Cj0KCQiAjfvwBRCkARIsAIqSWlMB60-YX89C4X58atBOqJLgkrwww9OWy07F2WAr_SONnKMPqWCDCk0aAoc-EALw_wcB&cm_mmca10=406149579079&cm_mmca11=b&gclid=Cj0KCQiAjfvwBRCkARIsAIqSWlMB60-YX89C4X58atBOqJLgkrwww9OWy07F2WAr_SONnKMPqWCDCk0aAoc-EALw_wcB&gclsrc=aw.ds) 
- [Microsoft (Azure Quantum)](https://www.wired.com/story/microsoft-taking-quantum-computers-cloud/)
- [Rigetti (AWS)](https://www.rigetti.com/)
- [D-Wave Systems](https://www.dwavesys.com/quantum-computing)
- [Google Quantum Computing](https://research.google/teams/applied-science/quantum/)

### Characteristics
We mentioned non-intutive characteristics that defy our macro-world senses. Quantum
characteristics manifest in the pico-world. For a longer, more authoratative discussion refer to 
[https://en.wikipedia.org/wiki/Qubit](https://en.wikipedia.org/wiki/Qubit). Note that if you
drill down, you encounter the math foundations. 

Here, let's skim a couple of concepts at the 40,000 foot level:

#### Entanglement
The state of two qbits can be shared, meaning that one tracks the state of the other. They
can be separated by a great distance. In 2017 scientists experimentally verified entanglement
at a 750-mile-separation. Entanglement has application in the field of 
[quantum information theory](https://en.wikipedia.org/wiki/Quantum_information).

#### Superposition
Our QRNG uses superposition, a strange, wonderful, quantum characteristic.
Placing a qbit into a "superposition" state, means for us that its state is indeterminate 
until we measure it. Moreover, that measured state could be any value between zero and one. 
We believe that a value from a qbit is truly as random as anything in nature can be.

#### Measurement
We determine a qbit's state by observing it, but that clears its state, taking it
out of superposition. This is one of the hurdles of quantum computing. It's as if 
obtaining a bank account's balance closes the account. Einstein wasn't a fan: "Even a
sidelong glance by a mouse would do it?" Yet quantum computing works. It's built
upon observing an entity that is in superposition. Measurement takes it out of 
superposition, yielding its state.

Our Q# code causes a single qbit to generate a random bit. It repeats, accumulating
many results into a set of random numbers returned as a result to a C# controller.

### Q# Language
Programming a raw quantum computer could involve rearranging or plugging in physical hardware 
components. That was how users "programmed" the first analog computers to solve problems.
We've used IBM's Q Experience cloud to visually arrange a circuit to return simple results. 

Instead of visually arranging entities,  Q# uses a procedural approach to abstract oddities 
of quantum computer hardware to a more-classical language environment. This seems more
like programming to some of us.

Q# supports an interface or contract that enables pluggable backend hardware or quantum 
simulators. Our Q# currently uses a quantum simulator, so, yes, our results boil down 
plain old psuedo-random sequences. When Microsoft allows the unwashed to queue jobs to 
an actual (expensive) quantum computer, our QRNG would exploit it.

### Quantum Simulator
If we can simulate a quantum computer on a classical computer what is the point of a
quantum computer? It's that pesky entanglement characteristic composed with the floating
states of superposition. Complexity increases exponentially with the numer of qbits.
Our QRNG uses just one qbit, so the simualtor is up to the job.



## Refs

+ Quantum Information Theory: [https://en.wikipedia.org/wiki/Quantum_information](https://en.wikipedia.org/wiki/Quantum_information)
+ Quantum Inspire: [https://www.quantum-inspire.com/](https://www.quantum-inspire.com/)
+ Dilbert: [https://dilbert.com/strip/2012-04-17](https://dilbert.com/strip/2012-04-17)
+ Quantum Information Theory: [https://en.wikipedia.org/wiki/Quantum_information_theory](https://en.wikipedia.org/wiki/Quantum_information_theory)
+ 2017 Entanglement Distance Record: [https://www.sciencealert.com/physicists-just-quantum-entangled-photons-between-earth-and-space](https://www.sciencealert.com/physicists-just-quantum-entangled-photons-between-earth-and-space)

