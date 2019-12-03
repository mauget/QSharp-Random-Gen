using System;
using Microsoft.Quantum.Simulation.Simulators;
using Quantum;

namespace QSharp_Random_Gen
{
    class Driver
    {
        static int ResultCount = 10;

        static void Main(string[] args)
        {
            // Ping simulator
            using var quantumSimulator = new QuantumSimulator();
            PingQ.Run(quantumSimulator).Wait();
            
            // Gen random numbers
            Console.WriteLine($"{ResultCount} q#-generated 64-bit random integers:");
            for (var d = 0; d < ResultCount; d++)
            {
                // Call q# processing here
                var res = QuantumRandomNumberGenerator.Run(quantumSimulator).Result;
                Console.WriteLine("{0,20:X16}", res);
            }
        }
    }
}