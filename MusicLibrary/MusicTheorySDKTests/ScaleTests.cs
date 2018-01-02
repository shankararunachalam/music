using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicTheorySDK.Core;
using MusicTheorySDK.Utils;
using System.Collections.Generic;

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
            const string intervalRepresentation = "2 2 1 2 2 2 1";
            const string noteRepresentation = "FSharp GSharp ASharp B CSharp DSharp ESharp FSharp";
            Note rootNote = new Note(Notes.FSharp);

            List<Interval> intervals = IntervalFactory.CreateIntervals(intervalRepresentation);
            Scale scaleForIntervals = new Scale(rootNote, intervals);

            List<Note> notes = NoteFactory.CreateNotes(noteRepresentation);
            Scale scaleForNotes = new Scale(rootNote, notes);

            Assert.AreEqual(noteRepresentation, scaleForIntervals.Notation);
            Assert.AreEqual(intervalRepresentation, scaleForNotes.IntervalDisplay);
            Assert.AreEqual(scaleForIntervals, scaleForNotes);
        }

        [TestMethod()]
        public void GetNotesTest()
        {

        }
    }
}