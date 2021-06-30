using System;

namespace ECommerceManipulationTester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestScenarios.Scenarios.RunScenario1();
            Console.Clear();
            TestScenarios.Scenarios.RunScenario2();
            Console.Clear();
            TestScenarios.Scenarios.RunScenario3();
            Console.Clear();
            TestScenarios.Scenarios.RunScenario4();
            Console.Clear();
            TestScenarios.Scenarios.RunScenario5();

        }
    }
}
