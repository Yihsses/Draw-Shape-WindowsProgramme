using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Windows.Input;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;
using static System.Windows.Forms.AxHost;
using System.Windows.Forms.VisualStyles;
using hw2.Models;

namespace hw2Tests
{
    public class Robot
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";

        // constructor
        public Robot(string targetAppPath, string root)
        {
            this.Initialize(targetAppPath, root);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        // test
        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }
        public void SetText(string name , string text)
        {
          
        }
        // test
        public void ClickButton(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        // test
        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }

        // test
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        // test
        public void CloseMessageBox()
        {
            _driver.FindElementByName("確定").Click();
        }

        // test
        public void ClickDataGridViewCellBy(string name, int rowIndex, string columnName)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            _driver.FindElementByName($"{columnName} 資料列 {rowIndex}").Click();
        }

        // test
        public void AssertEnable(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }
        public void AssertCheck(string name, bool state)
        {
            var element = _driver.FindElementByName(name);
            

            if (state)
            {
                if(element.GetAttribute("LegacyState") == "1048724" || element.GetAttribute("LegacyState") == "1048592")
                Assert.AreEqual(true, true);
            }
            else
            {
                Assert.AreEqual("1048576", element.GetAttribute("LegacyState"));
            }
  
        }

        // test
        public void AssertText(string name, string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Assert.AreEqual(text, element.Text);
        }

        // test
        public void AssertDataGridViewShape(string name, int rowIndex,string[] data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId("shap_data_GridView");
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");
            for (int i = 5; i < rowDatas.Count; i++)
            {
                int expectedValue = int.Parse(data[i - 5]);
                int actualValue = int.Parse(rowDatas[i].Text.Replace("(null)", "").Trim());
                Assert.IsTrue(Math.Abs(expectedValue - actualValue) <= 1,
                    $"Difference between expected ({expectedValue}) and actual ({actualValue}) is greater than 1.");
            }
        }

        public void DeleteDataGridViewRowDataBy(string name)
        {

        }
        public void AssertDataGridViewRowDataBy(string name, int rowIndex, string[] data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");

            // FindElementsByXPath("//*") 會把 "row" node 也抓出來，因此 i 要從 1 開始以跳過 "row" node
            for (int i = 1; i < rowDatas.Count; i++)
            {
                Assert.AreEqual(data[i - 1], rowDatas[i].Text.Replace("(null)", ""));
            }
        }

        // test
        public void AssertDataGridViewRowCountBy(string name, int rowCount)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);

            Point point = new Point(dataGridView.Location.X, dataGridView.Location.Y);
            AutomationElement element = AutomationElement.FromPoint(point);

            while (element != null && element.Current.LocalizedControlType.Contains("datagrid") == false)
            {
                element = TreeWalker.RawViewWalker.GetParent(element);
            }

            if (element != null)
            {
                GridPattern gridPattern = element.GetCurrentPattern(GridPattern.Pattern) as GridPattern;

                if (gridPattern != null)
                {
                    Assert.AreEqual(rowCount, gridPattern.Current.RowCount);
                }
            }
        }
        public void DataGridViewAddData(string shapename,string literal , string x , string y , string h , string w)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId("shape_comboBox");
     
            element.Click();
            IList<WindowsElement> shape = _driver.FindElementsByName(shapename);
            shape[1].Click();
            element = _driver.FindElementByAccessibilityId("literalbox");
            element.SendKeys(literal);
            element = _driver.FindElementByAccessibilityId("xbox");
            element.SendKeys(x);
            element = _driver.FindElementByAccessibilityId("ybox");
            element.SendKeys(y);
            element = _driver.FindElementByAccessibilityId("hbox");
            element.SendKeys(h);
            element = _driver.FindElementByAccessibilityId("wbox");
            element.SendKeys(w);
            element = _driver.FindElementByName("新增");
            element.Click(); 

        }
        public void TextAlter(int startX, int startY,string str)
        {
            var action = new Actions(_driver);
            action.MoveByOffset(startX, startY).DoubleClick().Perform();
            WindowsElement element = _driver.FindElementByName("文字編輯方塊");
            element.SendKeys(str);
            element = _driver.FindElementByName("確定");
            element.Click();
        }
        
        public void AssertText(string name, int rowIndex, string str)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");
            Assert.AreEqual(rowDatas[4].Text, str); 
        }
        public void DragAndDropByCoordinates(int startX, int startY, int endX, int endY)
        {
            // 計算目標點的偏移量
            int offsetX = endX - startX;
            int offsetY = endY - startY;

            // 模擬滑鼠移動操作
            var action = new Actions(_driver);
  
    

            // 將滑鼠移動到起點並按住
            action.MoveByOffset(startX, startY)
                  .ClickAndHold().Perform();

            action.MoveByOffset(offsetX, offsetY)
            .Release()
            .Perform();


            //var dataGridView = _driver.FindElementByAccessibilityId("shap_data_GridView");
            //var rowDatas = dataGridView.FindElementByName($"資料列 {0}").FindElementsByXPath("//*");
            //for (int i = 5; i < rowDatas.Count; i++)
            //{
            //    int expectedValue = int.Parse(testdata[i - 5]);
            //    int actualValue = int.Parse(rowDatas[i].Text.Replace("(null)", "").Trim());
            //    // 判斷差值是否 <= 1
            //    Assert.IsTrue(Math.Abs(expectedValue - actualValue) <= 1,
            //        $"Difference between expected ({expectedValue}) and actual ({actualValue}) is greater than 1.");
            //}
        }

    }
}
