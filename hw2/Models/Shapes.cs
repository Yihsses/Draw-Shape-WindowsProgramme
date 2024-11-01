using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Models
{

    public class Shape
    {

        public int ID { get; set; }
        public string Literal { get; set; }
        public string ShapeName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Shape_Width{ get; set; }
        public int Shape_Height { get; set; }
        public object[] Getobject()
        {
             return new object[] { "刪除",ID, ShapeName, Literal, X,Y,Math.Abs(Shape_Height), Math.Abs(Shape_Width) };
        }
    }

}
