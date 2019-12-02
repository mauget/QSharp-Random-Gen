
namespace Quantum {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Bitwise;

    operation QuantumRandomNumberGenerator() : Int {
        mutable randomNumber = 0;
        
        // Accumulate 64 random bits, each taken one-by-one from a single qbit
        for (i in 1 .. 64) {
        
            using(q = Qubit())  {   // Allocate a qubit.
                H(q);               // Put the qubit to superposition. It now has a 50% chance of being 0 or 1.
                let res = M(q);     // Measure the qubit value.
                
                set randomNumber = LeftShiftedI(randomNumber, 1);
                if (res == One) {
                    set randomNumber = Or(randomNumber, 1);
                }
                Reset(q);
            }
        }
        
        return randomNumber;
    }
}