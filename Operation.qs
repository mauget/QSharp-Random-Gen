
namespace Quantum {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Bitwise;

    operation PingQ() : Unit {
        Message("Hello from Quantum World!");
    }
    
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
}