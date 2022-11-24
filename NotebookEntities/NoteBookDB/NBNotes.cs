using System;
using System.Collections.Generic;
using System.Text;

namespace NotebookEntities.NoteBookDB
{
    public class NBNotes
    {
        public int IdNote { get; set; }

        public int IdUser { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Created { get; set; }


    }
}
