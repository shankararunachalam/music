using MusicTheorySDK.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicTheorySDK.Core
{
    public class Scale
    {
        public Note Key { get; set; }
        public List<Interval> Intervals { get; set; }
        public List<Note> Notes { get; set; }
        public const int CHROMATIC_NOTE_COUNT = 12;
        public const int DIATONIC_NOTE_COUNT = 7;

        public string Display
        {
            get
            {
                StringBuilder notation = new StringBuilder();
                if (Notes != null)
                {
                    foreach (Note note in Notes)
                    {
                        notation.Append(note.Name.GetDescription<Notes>()).Append(" ");
                    }
                }
                return notation.ToString().Trim();
            }
        }

        public string IntervalDisplay
        {
            get
            {
                StringBuilder intervalNotation = new StringBuilder();
                if (Intervals != null)
                {
                    foreach (Interval interval in Intervals)
                    {
                        intervalNotation.Append(interval.Steps).Append(" ");
                    }
                }
                return intervalNotation.ToString().Trim();
            }
        }

        public string Notation
        {
            get
            {
                StringBuilder notation = new StringBuilder();
                if (Notes != null)
                {
                    foreach (Note note in Notes)
                    {
                        notation.Append(note.Name).Append(" ");
                    }
                }
                return notation.ToString().Trim();
            }
        }

        public Scale(Note key, List<Interval> intervals)
        {
            Key = key;
            Intervals = intervals;
            CalculateNotes();
        }

        public Scale(Note key, List<Note> notes)
        {
            Key = key;
            Notes = notes;
            CalculateIntervals();
        }

        public override bool Equals(Object other)
        {
            if (other == null)
                return false;

            Scale otherScale = other as Scale;
            return this.Notation.Equals(otherScale.Notation);
        }

        public bool Enharmonic(Scale other)
        {
            if (other == null)
                return false;

            //TBD
            return false;
        }

        public override int GetHashCode()
        {
            return this.Notation.GetHashCode();
        }

        private void CalculateNotes()
        {
            Notes = new List<Note>();
            if (Key != null)
            {
                //IndexOf works due to implementation of InEquatable interface on Note class
                int rootNoteIndex = NoteFactory.AllNotes.IndexOf(Key);
                List<Note> allNotesRearranged = NoteFactory.AllNotes.Circle<Note>(rootNoteIndex).ToList();

                int currentNoteIndex = 0;
                int intervalIndex = 0;
                Notes.Add(allNotesRearranged[0]);

                for (int i = 1; i < allNotesRearranged.Count; i++)
                {
                    Note currentNote = allNotesRearranged[currentNoteIndex];
                    Note nextNote = allNotesRearranged[i];
                    int currentNoteOf = currentNote.NoteOf - 'A';
                    int nextNoteOf = nextNote.NoteOf - 'A';
                    int interval = Intervals[intervalIndex].Steps;

                    //to build the notes of the scale:
                    //1. the notes cannot be enharmonic
                    //2. the notes have to fit in the defined interval pattern
                    //3. the notes have to belong to distinct notes of ABCDEFG
                    if (
                        !nextNote.Enharmonic(currentNote) &&
                        (nextNote.Position % CHROMATIC_NOTE_COUNT == (currentNote.Position + interval) % CHROMATIC_NOTE_COUNT) &&
                        (nextNoteOf % DIATONIC_NOTE_COUNT == (currentNoteOf + 1) % DIATONIC_NOTE_COUNT)
                       )
                    {
                        Notes.Add(nextNote);
                        currentNoteIndex = i;
                        intervalIndex++;
                    }
                }
                //first note of the next octave will finish the scale
                Notes.Add(Key);
            }
        }

        private void CalculateIntervals()
        {
            Intervals = new List<Interval>();
            for (int i = 0; i < Notes.Count - 1; i++)
            {
                int interval = Notes[i + 1].Position - Notes[i].Position;
                while(interval < 0)
                {
                    interval += CHROMATIC_NOTE_COUNT;
                }
                Intervals.Add(new Interval(interval));
            }
        }
    }
}
