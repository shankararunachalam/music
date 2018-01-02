using MusicTheorySDK.Core;
using MusicTheorySDK.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicTheoryTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            Console.OutputEncoding = Encoding.UTF8;
            string allNotes = "C CSharp D DSharp E F FSharp G GSharp A ASharp B";
            string majorIntervals = "2 2 1 2 2 2 1";
            string naturalMinorIntervals = "2 1 2 2 1 2 2";
            string[] allNoteNames = allNotes.Split(new char[] { ',', ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            DisplayScale("Major", allNoteNames, majorIntervals);
            Console.WriteLine();
            DisplayScale("Minor", allNoteNames, naturalMinorIntervals);
            Console.Read();
        }

        static void DisplayScale(string scaleName, string[] allNoteNames, string intervalRepresentation)
        {
            Console.WriteLine(String.Format("{0} scales: ", scaleName));
            List<Interval> intervals = IntervalFactory.CreateIntervals(intervalRepresentation);

            foreach (string noteName in allNoteNames)
            {
                Notes note;
                if (Enum.TryParse<Notes>(noteName, out note))
                {
                    Note rootNote = new Note(note);
                    Scale scale = new Scale(rootNote, intervals);
                    Console.WriteLine(String.Format("{0} {1}: {2}", note.GetDescription<Notes>(), scaleName, scale.Display));
                }
            }
        }
    }
}
