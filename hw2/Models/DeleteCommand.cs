using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Models
{
    internal class DeleteCommand : ICommand
    {
        Shape shape = new Shape();
        Model model;
        int shape_index = 0; 
        public DeleteCommand(Model m, Shape shpaes,int index)
        {
            this.shape_index = index; 
            shape = shpaes;
            model = m;
        }

        public void Execute()
        {
            model.shapes.RemoveAt(shape_index);
        }

        public void UnExecute()
        {
            model.shapes.Insert(this.shape_index, shape);
        }
    }
}