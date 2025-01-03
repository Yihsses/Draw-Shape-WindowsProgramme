using hw2Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
/// <summary>
/// Summary description for MainFormUITest
/// </summary>
namespace hw2.Models.Tests
{
    [TestClass()]
    public class MainFormUITest
    {
        private Robot _robot;
        private string targetAppPath;
        private const string MENU_FORM = "MenuForm";
        private const string APP_NAME = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        private const string CALCULATOR_TITLE = "小算盤";
        private const string EXPECTED_VALUE = "顯示是 444";
        private const string RESULT_CONTROL_NAME = "CalculatorResults";

        /// <summary>
        /// Launches the Calculator
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "hw2";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "hw2.exe");
            _robot = new Robot(targetAppPath, MENU_FORM);

            //_robot = new Robot(APP_NAME, CALCULATOR_TITLE);
        }

        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        private void RunScriptShapeDraw()
        {
            _robot.ClickButton("Start");
            _robot.AssertCheck("Start", true);
            _robot.AssertCheck("Process", false);
            _robot.DragAndDropByCoordinates(200, 81, 99, 70);
     
            _robot.AssertCheck("PointState", true);
            _robot.AssertCheck("Start", false);
            _robot.AssertCheck("Process", false);
            _robot.AssertCheck("Terminator", false);
            _robot.AssertCheck("Decision", false);

            _robot.ClickButton("Process");
            _robot.AssertCheck("Process", true);
            _robot.DragAndDropByCoordinates(195, 228, 90, 60);
            _robot.AssertCheck("PointState", true);
            _robot.AssertCheck("Start", false);
            _robot.AssertCheck("Process", false);
            _robot.AssertCheck("Terminator", false);
            _robot.AssertCheck("Decision", false);

            _robot.ClickButton("Terminator");
            _robot.DragAndDropByCoordinates(258, 340, 150,60);
            _robot.AssertCheck("PointState", true);
            _robot.AssertCheck("Start", false);
            _robot.AssertCheck("Process", false);
            _robot.AssertCheck("Terminator", false);
            _robot.AssertCheck("Decision", false);

            _robot.ClickButton("Decision");
            _robot.DragAndDropByCoordinates(320, 158, 112, 90);
            _robot.AssertCheck("PointState", true);
            _robot.AssertCheck("Start", false);
            _robot.AssertCheck("Process", false);
            _robot.AssertCheck("Terminator", false);
            _robot.AssertCheck("Decision", false);

            List<string[]> testdata = new List<string[]>
                {
                    new string[] { "69", "76", "70", "99" },
                    new string[] { "133", "223", "60", "90" },
                    new string[] { "150", "335", "60", "150" },
                    new string[] { "235", "153", "90", "112" }
                };
            for (int i = 1; i <=4; i++)
            {
                _robot.AssertDataGridViewShape("shap_data_GridView", i - 1, testdata[i-1]);
            }

            _robot.ClickButton("undo");
            _robot.ClickButton("undo");
            _robot.ClickButton("redo");
            _robot.ClickButton("redo");


            _robot.DragAndDropByCoordinates(120, 120, 150, 150); //如果沒拖移成功請多試幾次

            testdata = new List<string[]>
                {
                    new string[] { "250", "231", "70", "99" },
                    new string[] { "133", "223", "60", "90" },
                    new string[] { "150", "335", "60", "150" },
                    new string[] { "235", "153", "90", "112" }
                };
            for (int i = 1; i <= 4; i++)
            {
                _robot.AssertDataGridViewShape("shap_data_GridView", i - 1, testdata[i - 1]);
            } 
            _robot.ClickButton("刪除 資料列 0");
             testdata = new List<string[]>
                {

                    new string[] { "133", "223", "60", "90" },
                    new string[] { "150", "335", "60", "150" },
                    new string[] { "235", "153", "90", "112" }
                };
            for (int i = 1; i <= 3; i++)
            {
                _robot.AssertDataGridViewShape("shap_data_GridView", i - 1, testdata[i - 1]);
            }
        }
        [TestMethod]
        public void TestDraw()
        {
            RunScriptShapeDraw();


            // _robot.AssertText(RESULT_CONTROL_NAME, EXPECTED_VALUE);
        }

    }
}
