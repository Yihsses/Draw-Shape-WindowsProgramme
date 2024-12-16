using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Models
{
    public  class DrawCommand : ICommand
    {
        Shape shape = new Shape();
        Model model;
        public DrawCommand(Model m, Shape shpaes)
        {
            shape = shpaes; 
            model = m;
        }

        public void Execute()
        {
            model.Add_shpae(shape);
        }

        public void UnExecute()
        {
            model.DeleteShape();
        }
    }
}
