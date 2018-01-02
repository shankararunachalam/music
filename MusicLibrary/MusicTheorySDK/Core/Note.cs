using MusicTheorySDK.Utils;
using System;

namespace MusicTheorySDK.Core
{
    public class Note : IEquatable<Note>
    {
        public Notes Name { get; set; }
        public int Position
        {
            get
            {
                return Name.GetPosition<Notes>();
            }
        }

        public int NoteOf
        {
            get
            {
                return Name.GetNoteOf<Notes>();
            }
        }

        public Note(Notes name)
        {
            Name = name;
        }

        public override bool Equals(Object other)
        {
            return this.Equals(other as Note);
        }

        public bool Equals(Note other)
        {
            if (other == null)
                return false;

            return Name.GetPosition<Notes>() == other.Name.GetPosition<Notes>() && Name.GetNoteOf<Notes>() == other.Name.GetNoteOf<Notes>();
        }

        public bool Enharmonic(Note other)
        {
            if (other == null)
                return false;

            return Name.GetPosition<Notes>() == other.Name.GetPosition<Notes>();
        }

        public override int GetHashCode()
        {
            return this.Name.GetPosition<Notes>().GetHashCode();
        }
    }
}
