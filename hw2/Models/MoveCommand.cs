using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Models
{
    public class MoveCommand : ICommand
    {
        Shape shape = new Shape();
        Model model;
        Point OriginPoint,Strpoint; 
        public MoveCommand(Model m, Shape shpaes)
        {
            shape = shpaes;
            OriginPoint = new Point(shape.X, shape.Y);
            Strpoint = new Point(shape.str_x, shape.str_y); 
            model = m;
        }

        public void Execute()
        {
            Point TempPoint = new Point(shape.X, shape.Y);
            shape.X = OriginPoint.X;
            shape.Y = OriginPoint.Y;
            OriginPoint.X = TempPoint.X;
            OriginPoint.Y = TempPoint.Y;
            TempPoint.X = shape.str_x;
            TempPoint.Y = shape.str_y;
            shape.str_x = Strpoint.X;
            shape.str_y = Strpoint.Y;
            Strpoint.X = TempPoint.X;
            Strpoint.Y = TempPoint.Y;
            shape.renewLinePoint();
        }

        public void UnExecute()
        {
            Point TempPoint = new Point(shape.X, shape.Y);
            shape.X = OriginPoint.X;
            shape.Y = OriginPoint.Y;
            OriginPoint.X = TempPoint.X; 
            OriginPoint.Y = TempPoint.Y;
            TempPoint.X = shape.str_x;
            TempPoint.Y = shape.str_y;
            shape.str_x = Strpoint.X;
            shape.str_y = Strpoint.Y;
            Strpoint.X = TempPoint.X;
            Strpoint.Y = TempPoint.Y;
            shape.renewLinePoint();
            //    model.DeleteShape();
        }
    }
}
