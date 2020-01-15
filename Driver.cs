using System;
using Microsoft.Quantum.Simulation.Simulators;
using Quantum;
// ReSharper disable InvalidXmlDocComment

/// -------------------------------------------------------------------------------------------------
///  A C# driver that invokes Q# :operations":
///  1. Calls a Q# quantum ping operation
///  2. Invokes a Q# operation that generates 10 random numbers to the console
/// --------------------------------------------------------------------------------------------------
namespace QSharp_Random_Gen
{
    class Driver
    {
        private static int ResultCount = 10;
        private static Boolean ThrowsOnReleasingQuitsNotInZerosState = true;
        private static Boolean DisableBorrowing = true;

        static void Main(string[] args)
        {
            // Ping simulator
            using var quantumSimulator = new QuantumSimulator(
                ThrowsOnReleasingQuitsNotInZerosState, 
                (uint)Guid.NewGuid().GetHashCode(), 
                DisableBorrowing);
            PingQ.Run(quantumSimulator).Wait();
            
            // Gen random numbers
            Console.WriteLine($"{ResultCount} Q#-generated 64-bit random integers:");
            for (var d = 0; d < ResultCount; d++)
            {
                // Call q# processing here
                var res = QuantumRandomNumberGenerator.Run(quantumSimulator).Result;
                Console.WriteLine("{0,20:X16}", res);
            }
        }
    }
}