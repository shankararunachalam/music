using MusicTheorySDK.Core;
using System;
using System.Collections.Generic;

namespace MusicTheorySDK.Utils
{
    public class NoteFactory
    {
        public static List<Note> AllNotes
        {
            get
            {
                List<Note> notes = new List<Note>();
                foreach (Notes noteName in Enum.GetValues(typeof(Notes)))
                {
                    Note thisNote = new Note(noteName);
                    notes.Add(thisNote);
                }
                return notes;
            }
        }

        public static List<Note> CreateNotes(string notation)
        {
            string[] noteStrings = notation.Split(new char[]{ ',', ' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            Notes[] noteNames = new Notes[noteStrings.Length];
            for(int i = 0; i < noteStrings.Length; i++)
            {
                Notes parsedResult;
                if(Enum.TryParse<Notes>(noteStrings[i], out parsedResult))
                {
                    noteNames[i] = parsedResult;
                }
            }
            return CreateNotes(noteNames);
        }

        public static List<Note> CreateNotes(Notes[] noteNames)
        {
            List<Note> notes = new List<Note>();
            foreach(Notes noteName in noteNames)
            {
                notes.Add(new Note(noteName));
            }
            return notes;
        }
    }
}
