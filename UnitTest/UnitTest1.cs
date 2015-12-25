using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LRSkipAsync;
using WsuppAsync;

namespace UnitTest
{
    [TestClass]
    public class WsuppAsync_UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            String Result;

            CS_WsuppAsync Wsupp = new CS_WsuppAsync();

            #region 対象：評価対象なし
            String KeyWord = @"This is a Pen.";
            Wsupp.Clear();
            Wsupp.Wbuf = KeyWord;
            Wsupp.Exec();
            Result = Wsupp.Wbuf;

            Assert.AreEqual(KeyWord, Result, @"Wsupp[This is a Pen.] = [This is a Pen.]");
            #endregion
        }

        [TestMethod]
        public void TestMethod2()
        {
            CS_WsuppAsync Wsupp = new CS_WsuppAsync();


            #region 対象：評価対象あり（””）
            String KeyWord = "This is \"a\"  Pen.";
            Wsupp.Clear();
            Wsupp.Wbuf = KeyWord;
            Wsupp.Exec();

            Assert.AreEqual("This is \" \"  Pen.", Wsupp.Wbuf, "Wsupp[This is \"a\" Pen.] = [This is \" \" Pen.]");
            #endregion
        }

        [TestMethod]
        public void TestMethod3()
        {
            CS_WsuppAsync Wsupp = new CS_WsuppAsync();


            #region 対象：評価対象あり（’’）
            String KeyWord = "This is \'a\' Pen.";
            Wsupp.Clear();
            Wsupp.Wbuf = KeyWord;
            Wsupp.Exec();

            Assert.AreEqual("This is \' \' Pen.", Wsupp.Wbuf, "Wsupp[This is \'a\' Pen.] = [This is \' \' Pen.]");
            #endregion
        }

        [TestMethod]
        public void TestMethod4()
        {
            CS_WsuppAsync Wsupp = new CS_WsuppAsync();


            #region 対象：評価対象あり（’”’確認）
            String KeyWord = "This is \'\"\' Pen.";
            Wsupp.Clear();
            Wsupp.Wbuf = KeyWord;
            Wsupp.Exec();

            Assert.AreEqual("This is \' \' Pen.", Wsupp.Wbuf, "Wsupp[This is \'\"\' Pen.] = [This is \' \' Pen.]");
            #endregion
        }
    }
}
