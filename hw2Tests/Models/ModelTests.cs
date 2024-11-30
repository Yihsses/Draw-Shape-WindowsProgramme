using Microsoft.VisualStudio.TestTools.UnitTesting;
using hw2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Net;
using DrawingModel;
using hw2.PresentationMode;
using System.Reflection;

namespace hw2.Models.Tests
{
    [TestClass()]
    public class ModelTests
    {
        Model model = new Model();
        PresentationMode.PresentationModel _presentationModel;
        [TestMethod()]
        public void ModelTest()
        {
            model = new Model();
        }

        [TestMethod()]
        public void EnterPointerStateTest()
        {
            model.EnterPointerState();
            Assert.AreEqual(model.IsDrawingButtonChecked, false);
            Assert.AreEqual(model.IsPointerButtonChecked, true);
            Assert.AreEqual(model.currentState, model.pointerState); 
        }



        [TestMethod()]
        public void EnterDrawingStateTest()
        {
            model.EnterDrawingState();
            Assert.AreEqual(model.IsDrawingButtonChecked, true);
            Assert.AreEqual(model.IsPointerButtonChecked, false);
            Assert.AreEqual(model.currentState, model.drawingState);
        }
        [TestMethod()]
        public void PointerActionTest()
        {
            model.PointerPressed(3, 4, "Start");
            model.PointerMoved(10, 8);
            model.PointerReleased(10, 20);

            model.EnterDrawingState();
            model.PointerPressed(40, 40, "Terminator");
            model.PointerMoved(50, 50);
            model.PointerReleased(50, 50);

            model.EnterDrawingState();
            model.PointerPressed(54, 20, "Process");
            model.PointerMoved(80, 50);
            model.PointerReleased(20, 4);

            model.EnterDrawingState();
            model.PointerPressed(10, 20, "Decision");
            model.PointerMoved(30, 40);
            model.PointerReleased(12, 55);
        }

        [TestInitialize()]
        public void ini()
        {
            model.EnterDrawingState();
            model.PointerPressed(3, 4, "Start");
            model.PointerMoved(10, 8);
            model.PointerReleased(10,10);

            model.EnterDrawingState();
            model.PointerPressed(70, 70, "Terminator");
            model.PointerMoved(80, 80);
            model.PointerReleased(80, 80);

            model.EnterDrawingState();
            model.PointerPressed(30, 30, "Process");
            model.PointerMoved(40, 40);
            model.PointerReleased(40, 40);

            model.EnterDrawingState();
            model.PointerPressed(50, 50, "Decision");
            model.PointerMoved(60, 60);
            model.PointerReleased(60, 60);
        }
        [TestMethod()]
        public void PointStatePointerActionTest()
        {
            model.EnterPointerState();
            model.PointerPressed(4, 5, "Start");
            model.PointerMoved(10, 8);

            model.EnterPointerState();
            model.PointerPressed(72, 72, "Terminator");
            model.PointerMoved(16, 17);

            model.EnterPointerState();
            model.PointerPressed(35, 35, "Process");
            model.PointerMoved(36,35);

            model.EnterPointerState();
            model.PointerPressed(55, 55, "Decision");
            model.PointerMoved(57, 59);
        }
        [TestMethod()]

        public void OnPaintTest()
        {
            WindowsFormsGraphicsAdaptor g = new WindowsFormsGraphicsAdaptor(); 
            model.OnPaint(g);
        }

        [TestMethod()]
        public void DrawTest()
        {
            WindowsFormsGraphicsAdaptor g = new WindowsFormsGraphicsAdaptor();
            model.Draw(g);
        }
        [TestMethod()]
        public void Delete_shapeTest()
        {
            model.Delete_shape(0);
        }
        [TestMethod()]
        public void PresentationModelTest()
        {
            _presentationModel = new PresentationModel(ref model);
        }


    }
}