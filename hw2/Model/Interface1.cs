using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Model
{

    public interface factory
    {
         Shape GetShape(int ID , string ShapeName, string Literal, int X, int Y, int Shape_Height, int Shape_Width);
    }
   
}
