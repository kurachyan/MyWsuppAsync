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
        public async void TestMethod1()
        {
            String Result;

            CS_WsuppAsync Wsupp = new CS_WsuppAsync();

            #region 対象：評価対象なし
            String KeyWord = @"This is a Pen.";
            await Wsupp.ClearAsync();
            Wsupp.Wbuf = KeyWord;
            await Wsupp.ExecAsync();
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
            Wsupp.ClearAsync();
//            Wsupp.Wbuf = KeyWord;
            Wsupp.ExecAsync(KeyWord);

            Assert.AreEqual("This is \" \"  Pen.", Wsupp.Wbuf, "Wsupp[This is \"a\" Pen.] = [This is \" \" Pen.]");
            #endregion
        }

        [TestMethod]
        public void TestMethod3()
        {
            CS_WsuppAsync Wsupp = new CS_WsuppAsync();


            #region 対象：評価対象あり（’’）
//            String KeyWord = "This is \'a\' Pen.";
            Wsupp.ClearAsync();
//            Wsupp.Wbuf = KeyWord;
            Wsupp.ExecAsync(@"This is 'a' Pen.");

            Assert.AreEqual("This is \' \' Pen.", Wsupp.Wbuf, "Wsupp[This is \'a\' Pen.] = [This is \' \' Pen.]");
            #endregion
        }

        [TestMethod]
        public async void TestMethod4()
        {
            CS_WsuppAsync Wsupp = new CS_WsuppAsync();


            #region 対象：評価対象あり（’”’確認）
            String KeyWord = "This is \'\"\' Pen.";
            await Wsupp.ClearAsync();
            Wsupp.Wbuf = KeyWord;
            await Wsupp.ExecAsync();

            Assert.AreEqual("This is \' \' Pen.", Wsupp.Wbuf, "Wsupp[This is \'\"\' Pen.] = [This is \' \' Pen.]");
            #endregion
        }
    }
}
