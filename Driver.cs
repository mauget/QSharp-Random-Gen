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
            Console.WriteLine(String.Format("{0} q#-generated 64-bit random integers:", ResultCount));

            using var quantumSimulator = new QuantumSimulator();
            for (var d = 0; d < ResultCount; d++)
            {
                // Call q# processing here
                var res = QuantumRandomNumberGenerator.Run(quantumSimulator).Result;
                Console.WriteLine("{0,20:X16}", res);
            }
        }
    }
}