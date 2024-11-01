using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    internal interface IGraphics
    {
        void ClearAll();
        void DrawLine(double x1, double y1, double x2, double y2);
        void DrawStart(double x1, double y1, double x2, double y2);
        void DrawTerminator(double x1, double y1, double width, double height);
        void DrawDecision(double x, double y, double width, double height);
        void DrawProcess(double x, double y, double width, double height);
        void DrawString(double x, double y, string shape_name); 
    }
}
