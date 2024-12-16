using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Models
{
    internal class TextChangeCommand : ICommand
    {
        string OriginString;
        Shape shape = new Shape(); 
        Model model;
        public TextChangeCommand(Model m, Shape shpaes)
        {
            OriginString = shpaes.Literal;
            shape = shpaes;
            model = m;
        }

        public void Execute()
        {
            string temp = shape.Literal;
            shape.Literal = OriginString;
            OriginString = temp;
        }

        public void UnExecute()
        {
            string temp = shape.Literal; 
            shape.Literal = OriginString;
            OriginString = temp;
        }
    }
}