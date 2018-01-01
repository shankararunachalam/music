using System;
using System.Collections.Generic;
using System.Text;

namespace MusicTheorySDK
{
    public class Note
    {
        public Notes Name { get; set; }
        public bool Accidental { get { return Name.ToString().Length > 1; } }

        public Note(Notes name)
        {
            this.Name = name;
        }
    }
}
