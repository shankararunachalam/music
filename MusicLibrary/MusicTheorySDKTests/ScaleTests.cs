using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicTheorySDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTheorySDK.Tests
{
    [TestClass()]
    public class ScaleTests
    {
        [TestMethod()]
        public void ScaleTest()
        {

        }

        [TestMethod()]
        public void GetNotationTest()
        {
            Note note = new Note(Notes.FSharp);
            SortedList<int, Interval> intervals = new SortedList<int, Interval>();
            intervals.Add(0, new Interval(2));
            intervals.Add(1, new Interval(2));
            intervals.Add(2, new Interval(1));
            intervals.Add(3, new Interval(2));
            intervals.Add(4, new Interval(2));
            intervals.Add(5, new Interval(2));
            intervals.Add(6, new Interval(1));
            Scale scale = new Scale(note, intervals);

            Assert.AreEqual("F# G# A# B C# D# E# F# ", scale.GetNotation());
        }

        [TestMethod()]
        public void GetNotesTest()
        {

        }
    }
}