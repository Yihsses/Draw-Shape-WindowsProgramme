using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hw2.Models
{

    public static class Shapefactory
    {
        public static Shape GetShape(int ID, string ShapeName, string Literal, int X, int Y, int Shape_Height, int Shape_Width)
        {
            switch (ShapeName)
            {
                case "Start":
                    return new Start( ID,  ShapeName,  Literal,  X,  Y,  Shape_Height,  Shape_Width);

                case "Terminator":
                    return new Terminator(ID, ShapeName, Literal, X, Y, Shape_Height, Shape_Width);
                case "Process":
                    return new Process(ID, ShapeName, Literal, X, Y, Shape_Height, Shape_Width);
                case "Decision":
                    return new Process(ID, ShapeName, Literal, X, Y, Shape_Height, Shape_Width);
                default:
                    throw new Exception("missing");
            }
        }
    }
}
