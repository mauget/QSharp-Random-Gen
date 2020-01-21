# QSharp-Random-Gen
## Q# Quantum Random Number Generator

### What
A quantum random number generator (QRNG) that consists of three parts:
1. Quantum computer hardware (here, simulator software) used like a coprocessor
1. Microsoft Q# code that orchestrates the quantum computer
1. Microsoft C# driver code that invokes and handles the Q# code 

## Quantum Computer
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

## Quantum Computing Today
Where are the practical applications? The kicker is the word, "sufficient". Currently,
qbits are profoundly expensive and error-prone due to "noise" in them. That is one reason
for the near-zero Kelvin temperatures invovled. A quantum application may run 
many "shots" at a solution, plucking a statical winner from error noise. 

A quamtum application concept often involves specialized algorithms that would not realistically 
complete on a classical computer. Applications such as factoring large numbers, can involve 
cooperation between a classical program and a classicxal program.

Where are real quantum computers? Big organizations are making breakthroughs. 
Cloud-based quantum computer access for small tasks is a current or near-future on-ramp 
to limited quantum computing access. We have run a QRNG queued to _IBM Q Experience_, for example.
Check out this non-exhaustive list of enterprises working in this field:

- [IBM Q Experience](https://www.ibm.com/quantum-computing/technology/experience/?p1=Search&p4=p50386405608&p5=b&cm_mmc=Search_Google-_-1S_1S-_-WW_NA-_-%2Bquantum%20%2Bcomputers_b&cm_mmca7=71700000061253577&cm_mmca8=kwd-320795842941&cm_mmca9=Cj0KCQiAjfvwBRCkARIsAIqSWlMB60-YX89C4X58atBOqJLgkrwww9OWy07F2WAr_SONnKMPqWCDCk0aAoc-EALw_wcB&cm_mmca10=406149579079&cm_mmca11=b&gclid=Cj0KCQiAjfvwBRCkARIsAIqSWlMB60-YX89C4X58atBOqJLgkrwww9OWy07F2WAr_SONnKMPqWCDCk0aAoc-EALw_wcB&gclsrc=aw.ds) 
- [Microsoft (Azure Quantum)](https://www.wired.com/story/microsoft-taking-quantum-computers-cloud/)
- [Rigetti (AWS)](https://www.rigetti.com/)
- [D-Wave Systems](https://www.dwavesys.com/quantum-computing)
- [Google Quantum Computing](https://research.google/teams/applied-science/quantum/)

## Quantum Characteristics
We mentioned non-intutive characteristics that defy our macro-world senses. Quantum
characteristics manifest in the pico-world. For a longer, more authoratative discussion refer to 
[https://en.wikipedia.org/wiki/Qubit](https://en.wikipedia.org/wiki/Qubit). Note that if you
drill down, you encounter the math foundations. 

Here, let's skim a couple of concepts at the 40,000 foot level:

### Entanglement
The state of two qbits can be shared, meaning that one tracks the state of the other. They
can be separated by a great distance. In 2017 scientists experimentally verified entanglement
at a 750-mile-separation. Entanglement has application in the field of 
[quantum information theory](https://en.wikipedia.org/wiki/Quantum_information).

### Superposition
Our QRNG uses superposition, a strange, wonderful, quantum characteristic.
Placing a qbit into a "superposition" state, means for us that its state is indeterminate 
until we measure it. Moreover, that measured state could be any value between zero and one. 
We believe that a value from a qbit is truly as random as anything in nature can be.

### Measurement
We determine a qbit's state by observing it, but that clears its state, taking it
out of superposition. This is one of the hurdles of quantum computing. It's as if 
obtaining a bank account's balance closes the account. Einstein wasn't a fan: "Even a
sidelong glance by a mouse would do it?" Yet quantum computing works. It's built
upon observing an entity that is in superposition. Measurement takes it out of 
superposition, yielding its state.

Our Q# code causes a single qbit to generate a random bit. It repeats, accumulating
many results into a set of random numbers returned as a result to a C# controller.

### Decoherence
Decoherence can mean: "qbit falls out of superposition." Qbits don't stay
in superpostion forever. They decohere ... quickly. Another hurdle in trying
to solve problems via quantum computing.

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

## Quantum Simulator
If we can simulate a quantum computer on a classical computer what is the point of a
quantum computer? It's that pesky entanglement characteristic mixed with the floating
states of superposition. Complexity increases exponentially with the numer of qbits.
Our QRNG uses just one qbit, so the simualtor is up to the job.

## QRNG Demo
Let's discuss the QRNG bottom-up. Output first, followed by relevant code, and then 
wrap up with how to install and run. Our QRNG demo is a .NET Core application consisting of a
C# controller invoking a Q# quantum task.

### Output
A `dotnet run` issued from the root of our QRNG project produced the following
console output:
````
    Hello from Quantum World!
    10 Q#-generated 64-bit random integers:
        03D2167DDA774C0E
        ACB41924DD444D2F
        DE7A33C27DE54698
        7E5F619A4BBF04A7
        1080C9C2EEEC88A4
        FAA9505AB73900FD
        57C4786AAC2E56EF
        A48190371B476BD5
        A425B8E0492E6FEC
        90A797C20D8AC9FE
    
    Process finished with exit code 0
````
It differs with each invocation. This execution runs the core Q# fragment 10 x 64 = 640 
times to accumulate that output. 

### Heart of The Demo
Q# is a statically typed blend of C# and F#. Types follow declaration, but can be omitted for
when static flow type-derivation occurs. The Q# operation follows. It should be readable by 
most JavaScript, C#, Go, or Java programmers. This operation's code is taken from
[Microsoft's Quickstart QRN](https://docs.microsoft.com/en-us/quantum/quickstarts/qrng?view=qsharp-preview).
We suggest reading that page for more details (e.g. check out the "Bloch Sphere").

```c#
    operation QuantumRandomNumberGenerator() : Int {
        mutable randomNumber = 0;
        
        // Accumulate 64 random bits, right-to-left, each taken per-step from a single qubit
        for (i in 1 .. 64) {
        
            using(q = Qubit())  {   // Allocate single qubit.
                H(q);               // Hadamard gate moves qubit into superposition. 
                let res = M(q);     // Measure the qubit value: a 50% chance of seeing 0 or 1.
                
                // Accumulate to sliding bit sequence
                set randomNumber = LeftShiftedI(randomNumber, 1);
                if (res == One) {
                    set randomNumber = Or(randomNumber, 1);
                }
                Reset(q);  // We must always reset released qbits
            }
        }
        return randomNumber;
    }   
```

The core logic is basic:
1. Obtain a single qubit.
1. Send it to a _Hadamard quantum gate_ that consumes the qbit, returning it in superposition state. 
1. Measure the qbit, collapsing the superposition to a random concrete state.

The quantum action centers on this extracted fragment:
```c#
    H(q);               // Hadamard gate moves qubit into superposition. 
    let res = M(q);     // Measure the qubit value: a 50% chance of seeing 0 or 1.          
```

Q# can carry out classical operations as well. 
We coded ours to accumulate a random 64-bit integer from repeatedly measuring the qbit
in superposition. Our invoking C# driver collects ten results, logging each to 
the console:
```c#
// C#: Gen random numbers
Console.WriteLine($"{ResultCount} Q#-generated 64-bit random integers:");
for (var d = 0; d < ResultCount; d++)
{
    // Call q# operation here
    var res = QuantumRandomNumberGenerator.Run(quantumSimulator).Result;
    Console.WriteLine("{0,20:X16}", res);
}
```
## Build and Run

The build tree is at 
[https://github.com/mauget/QSharp-Random-Gen](https://github.com/mauget/QSharp-Random-Gen).

## Dependencies
+ A Linux, MacOS, or Windows system capable of running .NET Core.
+ .NET Core 3 (ours is 3.0.101)

## Installation
Carry out the following steps:
1. `dotnet new -i Microsoft.Quantum.ProjectTemplates`
1. `git clone https://github.com/mauget/QSharp-Random-Gen`

## Run
Enter the following commands:
```bash
    cd QSharp-Random-Gen
    dotnet run
```
 
Verify that the console displays 10 random 64-bit numbers, as shown earlier. Run again. Verify that the numeric values differ from the first run. 

That’s it. Ten distinct random numbers. End of story!

## Refs

+ Quantum Information Theory: [https://en.wikipedia.org/wiki/Quantum_information](https://en.wikipedia.org/wiki/Quantum_information)
+ Quantum Inspire: [https://www.quantum-inspire.com/](https://www.quantum-inspire.com/)
+ Dilbert: [https://dilbert.com/strip/2012-04-17](https://dilbert.com/strip/2012-04-17)
+ Quantum Information Theory: [https://en.wikipedia.org/wiki/Quantum_information_theory](https://en.wikipedia.org/wiki/Quantum_information_theory)
+ 2017 Entanglement Distance Record: [https://www.sciencealert.com/physicists-just-quantum-entangled-photons-between-earth-and-space](https://www.sciencealert.com/physicists-just-quantum-entangled-photons-between-earth-and-space)
+ Decoherence: [https://en.wikipedia.org/wiki/Quantum_decoherence](https://en.wikipedia.org/wiki/Quantum_decoherence)
+ The Q# Programming Language: [https://docs.microsoft.com/en-us/quantum/language/?view=qsharp-preview](https://docs.microsoft.com/en-us/quantum/language/?view=qsharp-preview)
+ Microsoft Quantum Documentation: [https://docs.microsoft.com/en-us/quantum/?view=qsharp-preview](https://docs.microsoft.com/en-us/quantum/?view=qsharp-preview)
+ MS QRNG Example: [https://docs.microsoft.com/en-us/quantum/quickstarts/qrng?view=qsharp-preview](https://docs.microsoft.com/en-us/quantum/quickstarts/qrng?view=qsharp-preview)
+ Quantum Gates: [https://en.wikipedia.org/wiki/Quantum_logic_gate](https://en.wikipedia.org/wiki/Quantum_logic_gate)