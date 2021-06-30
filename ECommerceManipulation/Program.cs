using ECommerceManipulation.Business;
using ECommerceManipulation.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ECommerceManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            TextModel textModel = new TextModel
            { 
                InputFile = @"Scenario1.txt",
            };
            RunBusinessRule.RunCommands(textModel);
        }
    }
}

