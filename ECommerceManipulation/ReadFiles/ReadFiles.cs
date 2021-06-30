using ECommerceManipulation.Constants;
using ECommerceManipulation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ECommerceManipulation.ReadFiles
{
    public class ReadFiles
    {
        public List<ParamModel> ReadFile(string filePath)
        {
            filePath = GetFromResources(filePath);
            List<ParamModel> paramModels = new List<ParamModel>();

            if (File.Exists(filePath))
            {
                Console.WriteLine(Messages.AllCommandsAndParams);
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    ParamModel paramModel = new ParamModel();
                    paramModel.Command = GetCommand(line);
                    paramModel.Param = GetParams(line);
                    paramModels.Add(paramModel);
                    Console.WriteLine(line);
                }
                Console.WriteLine(Messages.Stars);
            }
            return paramModels;
        }
        public string GetCommand(string line)
        {
            string[] splitedLine = line.Split(" ");
            return splitedLine[0];
        }
        public List<string> GetParams(string line)
        {
            string[] splitedLine = line.Split(" ");
            List<string> list = new List<string>();
            for (int i = 1; i < splitedLine.Length; i++) { list.Add(splitedLine[i]); }
            return list;
        }
        internal static string GetFromResources(string resourceName)
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath = Directory.GetParent(_filePath).FullName;
            _filePath = Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName;
            _filePath += (Messages.File + resourceName);
            return _filePath;
        }
    }
}

