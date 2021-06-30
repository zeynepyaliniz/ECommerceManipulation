using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManipulation.Models
{
    public class ParamModel
    {
        public ParamModel()
        {

        }
        public string Command { get; set; }
        public List<string> Param { get; set; }
    }
}
