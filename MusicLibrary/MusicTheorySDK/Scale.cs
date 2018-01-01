using System;
using System.Collections.Generic;
using System.Text;

namespace MusicTheorySDK
{
    public class Scale
    {
        public Note Key { get; set; }
        public SortedList<int, Interval> Intervals { get; set; }

        public Scale(Note key, SortedList<int, Interval> intervals)
        {
            this.Key = key;
            this.Intervals = intervals;
        }

        public string GetNotation()
        {
            StringBuilder notation = new StringBuilder();
            SortedList<int, Note> notes = GetNotes();
            if(notes != null)
            {
                foreach(KeyValuePair<int, Note> note in notes)
                {
                    notation.Append(note.Value.Name.GetDescription<Notes>()).Append(" ");
                }
            }
            return notation.ToString();
        }

        public SortedList<int, Note> GetNotes()
        {
            if (this.Key == null)
            {
                return null;
            }

            SortedList<int, Note> notes = new SortedList<int, Note>();
            Note nextNote = this.Key;
            int i = 0;
            notes.Add(i++, nextNote);
            foreach (KeyValuePair<int, Interval> interval in this.Intervals)
            {
                nextNote = NotesFactory.Instance.GetNextNote(this.Key, nextNote, interval.Value);
                notes.Add(i++, nextNote);
            }
            return notes;
        }
    }
}
