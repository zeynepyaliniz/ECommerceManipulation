using ECommerceManipulation.Business;
using ECommerceManipulation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManipulationTester.TestScenarios
{
    public static class Scenarios
    {
        public static void RunScenario1() {
            TextModel scenario = new TextModel
            {
                InputFile = @"Scenario1.txt",
            };
            RunBusinessRule.RunCommands(scenario);
        }
        public static void RunScenario2()
        {
            TextModel scenario = new TextModel
            {
                InputFile = @"Scenario2.txt",
            };
            RunBusinessRule.RunCommands(scenario);
        }
        public static void RunScenario3()
        {
            TextModel scenario = new TextModel
            {
                InputFile = @"Scenario3.txt",
            };
            RunBusinessRule.RunCommands(scenario);
        }
        public static void RunScenario4()
        {
            TextModel scenario = new TextModel
            {
                InputFile = @"Scenario4.txt",
            };
            RunBusinessRule.RunCommands(scenario);
        }
        public static void RunScenario5()
        {
            TextModel scenario = new TextModel
            {
                InputFile = @"Scenario5.txt",
            };
            RunBusinessRule.RunCommands(scenario);
        }
    }
}
