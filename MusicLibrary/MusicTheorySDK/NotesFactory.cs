using System;
using System.Collections.Generic;

namespace MusicTheorySDK
{
    public sealed class NotesFactory
    {
        private static readonly NotesFactory _instance = new NotesFactory();
        public SortedList<int, Note> AllNotes { get; set; }

        public static NotesFactory Instance
        {
            get
            {
                return _instance;
            }
        }

        private NotesFactory()
        {
            int i = 0;
            AllNotes = new SortedList<int, Note>();
            foreach (Notes noteName in Enum.GetValues(typeof(Notes)))
            {
                Note thisNote = new Note(noteName);
                AllNotes.Add(i++, thisNote);
            }
        }

        public Note GetNextNote(Note rootNote, Note thisNote, Interval interval)
        {
            int position = (int)thisNote.Name;
            Note nextNote;
            if (AllNotes.TryGetValue(position + interval.Semitones, out nextNote))
            {
                return nextNote;
            }
            else if (AllNotes.TryGetValue(0, out nextNote))
            {
                return rootNote;
            }
            else
            {
                return null;
            }
        }
    }
}
